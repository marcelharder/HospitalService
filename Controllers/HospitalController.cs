namespace HospitalService.Controllers;
    
    public class HospitalController : BaseApiController
    {
        public IHospitalRepository _hos;
        public reportMapper _map;
        private readonly IOptions<CloudinarySettings> _cloudinaryConfig;
        private readonly Cloudinary _cloudinary;
        private readonly IOptions<ComSettings> _com;

        public HospitalController(
            IHospitalRepository hos, 
            reportMapper map,
            IOptions<ComSettings> com,
            IOptions<CloudinarySettings> cloudinaryConfig)
        {
            _hos = hos;
            _map = map;
            _com = com;
            _cloudinaryConfig = cloudinaryConfig;

            Account acc = new Account(
                _cloudinaryConfig.Value.CloudName,
                _cloudinaryConfig.Value.ApiKey,
                _cloudinaryConfig.Value.ApiSecret
            );
            _cloudinary = new Cloudinary(acc);
        }
       
        [HttpGet("allFullHospitals")]
        public async Task<IActionResult> getAllHospitals()
        {
            var ret = new List<HospitalForReturnDTO>();
            var result = await _hos.GetAllFullHospitals();
            foreach (Class_Hospital ch in result) { ret.Add(_map.mapToHospitalForReturn(ch)); }
            return Ok(ret);
        }
      
        [HttpGet("allFullHospitalsPerCountry/{id}")]
        public async Task<IActionResult> getHospitalsperCountry(string id)
        {
            // id is now bv 31 en moet NL worden
            // var iso_land = _map.getCountryFromCode(id);

            var ret = new List<HospitalForReturnDTO>();
            var result = await _hos.GetAllFullHospitalsPerCountry(id);
            foreach (Class_Hospital ch in result) { ret.Add(_map.mapToHospitalForReturn(ch)); }
            return Ok(ret);
        }
      
        [HttpGet("{id}", Name = "GetHospital")]// get specific hospital details
        public async Task<IActionResult> GetHospital(int id)
        {
            var result = await _hos.GetSpecificHospital(id.ToString().makeSureTwoChar());
            return Ok(result);
        }
      
        [HttpGet("getHospitalNameFromId/{no}")]// get specific hospital details
        public async Task<IActionResult> GetHospitalName(string no)
        {
            var result = await _hos.GetSpecificHospital(no);
            
            return Ok(result.HospitalName);
        }
      
        [HttpPut]
        public async Task<IActionResult> PutHospitalAsync([FromBody] HospitalForReturnDTO hr)
        {
            if(hr.HospitalNo != null){
            var h = await _hos.GetClassHospital(hr.HospitalNo);
            Class_Hospital ch = _map.mapToHospital(hr, h);
            return Ok(await _hos.UpdateHospital(ch));
            }
            return BadRequest("");
        }
      
        [HttpPost("{id}/{no}")]
        public async Task<IActionResult> PostHospitalAsync(string id, int no)
        {
            Class_Hospital ch = new Class_Hospital();
            ch.Country = id;
            ch.HospitalNo = no.ToString().makeSureTwoChar();
            var new_hospital_number = await _hos.AddHospital(ch);
            return CreatedAtRoute("GetHospital", new { id = new_hospital_number }, ch);
        }
      
        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteHospitalAsync(string id)
        {
            var h = await _hos.GetClassHospital(id);
            
            
            if (h != null) { 
                //delete hospital
                
                //return Ok(await _hos.DeleteAsync(h)); 
                }
            
            
            return BadRequest("Hospital not found");

        }
      
        [HttpPost("addHospitalPhoto/{id}")]
        public async Task<IActionResult> AddPhotoForHospital(int id, [FromForm] PhotoForCreationDto photoDto)
        {
            var h = await _hos.GetClassHospital(id.ToString().makeSureTwoChar());
            var file = photoDto.File;
            if(file != null){
            var uploadResult = new ImageUploadResult();
            if (file.Length > 0)
            {
                using (var stream = file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(file.Name, stream),
                        Transformation = new Transformation().Width(500).Height(500).Crop("fill").Gravity("face")
                    };
                    uploadResult = _cloudinary.Upload(uploadParams);
                }
                h.ImageUrl = uploadResult?.SecureUrl?.AbsoluteUri;
                // automap it to class-hospital before save
                var no = await _hos.UpdateHospital(h);
                if (no == 1)
                {
                    return CreatedAtRoute("GetHospital", new { id = h.HospitalId }, h);
                }
            }
        }
            return BadRequest("Could not add the photo ...");
        }
      
        [HttpPost("addCountryNow")]
        public async Task<IActionResult> AddCountryNow(CountryDto model)
        {
            await Task.Run(() =>
            {
                _hos.AddCountry(model);
            });
            return Ok();
        } 
     
        [HttpGet("hospitalByUser/{id}")]
        public async Task<IActionResult> getCurrentHospitalForUser(int id)
        {
            var result = await _hos.GetSpecificHospital(id.ToString().makeSureTwoChar());
            return Ok(result.HospitalName);
        }
     
        [HttpGet("IsThisHospitalImplementingOVI/{id}")]
        public async Task<IActionResult> getOVI(string id)
        {
            return Ok(await _hos.HospitalImplementsOVI(id));
        }
     
        #region <!-- InstitutionalReports stuff -->

        [HttpGet("InstitutionalReport/{hospitalId}/{soort}")]
        public async Task<IActionResult> getIRepAsync(string hospitalId, int soort)
        {
            var help = "";
            var comaddress = _com.Value.ReportURL;
            var st = "InstitutionalReport/" + hospitalId + "/" + soort;
            comaddress = comaddress + st;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(comaddress))
                {
                    help = await response.Content.ReadAsStringAsync();
                }
            }
            return Ok(help);
        }

        [HttpPut("InstitutionalReport/{hospitalId}/{soort}")]
        public async Task<IActionResult> updateIRepAsync([FromBody] InstitutionalDTO cp, string hospitalId, int soort)
        {
            var help = "";
            var comaddress = _com.Value.ReportURL;
            var st = "InstitutionalReport/" + hospitalId + "/" + soort;
            comaddress = comaddress + st;
            var json = JsonConvert.SerializeObject(cp, Formatting.None);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PutAsync(comaddress, content))
                {
                    help = await response.Content.ReadAsStringAsync();
                }
            }
            return Ok(help);
        }


        [HttpGet("AdditionalReportItems/{hospitalId}/{which}")]
        public async Task<IActionResult> getARIAsync(string hospitalId, int which)
        {
            var help = "";
            var comaddress = _com.Value.ReportURL;
            var st = "InstitutionalReport/AdditionalReportitems/" + hospitalId + "/" + which;
            comaddress = comaddress + st;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(comaddress))
                {
                    help = await response.Content.ReadAsStringAsync();
                }
            }
            return Ok(help);
        }

        [HttpPut("UpdateAdditionalReportItems/{hospitalId}/{which}")]
        public async Task<IActionResult> updateIRepAsync([FromBody] AdditionalReportDTO cp, string hospitalId, int which)
        {
            var help = "";
            var comaddress = _com.Value.ReportURL;
            var st = "InstitutionalReport/AdditionalReportitems/" + hospitalId + "/" + which;
            comaddress = comaddress + st;
            var json = JsonConvert.SerializeObject(cp, Formatting.None);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PutAsync(comaddress, content))
                {
                    help = await response.Content.ReadAsStringAsync();
                }
            }
            return Ok(help);
        }

        #endregion

    }

