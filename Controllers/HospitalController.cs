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
        if (result == null)
        {
            return NotFound();
        }
        foreach (Class_Hospital ch in result) { ret.Add(_map.mapToHospitalForReturn(ch)); }
        return Ok(ret);
    }

    [HttpGet("getHospitalVendors/{id}")]
    public async Task<IActionResult> getHpspitalVendors(string id) { return Ok(await _hos.getHospitalVendors(id)); }

    [HttpGet("addVendorToHospital/{vendor}/{hospitalNo}")]
    public async Task<IActionResult> addVendorToHospital(string vendor, string hospitalNo) { return Ok(await _hos.addVendors(vendor, hospitalNo)); }

    [HttpGet("removeVendorFromHospital/{vendor}/{hospitalNo}")]
    public async Task<IActionResult> removeVendorToHospital(string vendor, string hospitalNo) { return Ok(await _hos.removeVendor(vendor, hospitalNo)); }

    [HttpGet("allFullHospitalsPerCountry/{id}")]
    public async Task<IActionResult> getHospitalsperCountry(string id)
    {
        var ret = new List<HospitalForReturnDTO>();
        var result = await _hos.GetAllFullHospitalsPerCountry(id);
        if (result != null)
        {
            foreach (Class_Hospital ch in result) { ret.Add(_map.mapToHospitalForReturn(ch)); }
            return Ok(ret);
        }
        return Ok();
    }

    [HttpGet("getHospitalsPerCountry/{id}")]
    public async Task<IActionResult> getHospitalInCountry(string id) { return Ok(await _hos.getHospitalsPerCountry(id)); }

    [HttpGet("getHospitalsWhereUserWorked/{csv}")]
    public async Task<IActionResult> getAllHospitalsThisSurgeonWorkedIn(string csv) { return Ok(await _hos.getHospitalsWhereUserWorked(csv)); }

    [HttpGet("getHospitalName/{hos}")]
    public async Task<IActionResult> getHospitalName(string hos)
    {
        var result = await _hos.getHospitalNameFromId(hos);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpGet("{id}", Name = "GetHospital")]// get specific hospital details 
    public async Task<IActionResult> GetHospital(int id) { return Ok(await _hos.GetSpecificHospital(id.ToString())); }

    [HttpGet("getHospital/{no}")]// get specific hospital details
    public async Task<IActionResult> GetHospitalDetails(string no) { return Ok(await _hos.GetSpecificHospital(no)); }

    [HttpPut]
    public async Task<IActionResult> PutHospitalAsync([FromBody] HospitalForReturnDTO hr)
    {
        if (hr.HospitalNo != null)
        {
            var h = await _hos.GetClassHospital(hr.HospitalNo);
            if (h == null) { return NotFound(); }
            Class_Hospital ch = _map.mapToHospital(hr, h);
            return Ok(await _hos.UpdateHospital(ch));
        }
        return BadRequest("");
    }

    [HttpPost("{country}/{no}")]
    public async Task<IActionResult> PostHospitalAsync(string country, int no)
    {
        if (await _hos.CheckHospitalExists(no.ToString().makeSureTwoChar()))
        {
            return BadRequest("Hospital already exists");
        }
        else
        {
            Class_Hospital ch = new Class_Hospital();
            ch.Country = country;
            ch.HospitalNo = no.ToString().makeSureTwoChar();
            await _hos.AddHospital(ch);
            return Ok(await _hos.GetSpecificHospital(ch.HospitalNo));
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> deleteHospitalAsync(string id) { return Ok(await _hos.DeleteHospital(id)); }

    [HttpPost("addHospitalPhoto/{id}")]
    public async Task<IActionResult> AddPhotoForHospital(int id, [FromForm] PhotoForCreationDto photoDto)
    {
        var h = await _hos.GetClassHospital(id.ToString().makeSureTwoChar());
        if (h == null) { return NotFound(); }
        var file = photoDto.File;
        if (file != null)
        {
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


    [HttpGet("IsThisHospitalImplementingOVI/{id}")]
    public async Task<IActionResult> getOVI(string id) { return Ok(await _hos.HospitalImplementsOVI(id)); }

    [HttpGet("getHospitalItemsPerCountryFromIso/{country}")]
    public async Task<IActionResult> getHIPCFI(string country) { return Ok(await _hos.HospitalsPerCountryIso(country)); }

    [HttpGet("getHospitalItemsPerCountryFromTelCode/{telcode}")]
    public async Task<IActionResult> getHIPDFT(string telcode) { return Ok(await _hos.HospitalsPerCountryTelCode(telcode)); }

    [HttpGet("allHospitals")]
    public async Task<IActionResult> getAH() { return Ok(await _hos.AllHospitals()); }

    [HttpGet("pagedList")]
    public async Task<IActionResult> getPL([FromQuery] HospitalParams hp)
    {

        var hosp = await _hos.GetPagedHospitalList(hp);

        Response.AddPagination(
            hosp.Currentpage,
            hosp.PageSize,
            hosp.TotalCount,
            hosp.TotalPages);

        return Ok(hosp);
    }

    [HttpGet("neg_sphlist_full/{currentVendor}/{currentCountry}")] // In which hospital is the vendor active
    public async Task<IActionResult> NSPH(string currentVendor, string currentCountry) { return Ok(await _hos.GetNegSpPH(currentVendor, currentCountry)); }

    [HttpGet("sphlist_full/{currentVendor}/{currentCountry}")]
    public async Task<IActionResult> SPH(string currentVendor, string currentCountry) { return Ok(await _hos.GetSpPH(currentVendor, currentCountry)); }

    [HttpGet("sphlist/{currentVendor}/{currentCountry}")]
    public async Task<IActionResult> ItemsSPH(string currentVendor, string currentCountry) { return Ok(await _hos.GetItemsSpPH(currentVendor, currentCountry)); }


    [HttpGet("saveContact/{hospitalNo}/{contact}/{contactImage}")]
    public async Task<IActionResult> saveContactToHospital(string hospitalNo, string contact, string contactImage)
    {
        return Ok(await _hos.UpdateContactToHospital(hospitalNo, contact, contactImage));
    }

}

