namespace HospitalService.Controllers;

public class CountryController : BaseApiController
{
    public IHospitalRepository _hos;
    public CountryController(IHospitalRepository hos)
    {
        _hos = hos;
    }
    [HttpPost]
    public async Task<IActionResult> AddCountryNow(CountryDto model){return Ok(await _hos.AddCountry(model));}
    [HttpPut]
    public async Task<IActionResult> updateCountryNow(ClassCountry model){return Ok(await _hos.UpdateCountry(model));}
    [HttpGet("{IsoCode}")]
    public async Task<IActionResult> getSpecificCountry(string IsoCode){return Ok(await _hos.GetSpecificCountry(IsoCode));}
    [HttpGet("all")]
    public async Task<IActionResult> getAllCountries(){return Ok(await _hos.GetAllCountries());}
    [HttpGet("allCities")]
    public async Task<IActionResult> getAllCities(){return Ok(await _hos.GetAllCities());}
    [HttpGet("allCitiesPerCountry/{IsoCode}")]
    public async Task<IActionResult> getAllCitiesPerCountry(string IsoCode){return Ok(await _hos.GetAllCitiesPerCountry(IsoCode));}

}

