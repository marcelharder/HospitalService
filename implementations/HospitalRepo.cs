

namespace api.implementations;

public class HospitalRepo : IHospitalRepository
{

    public DapperContext _dc;
    public HospitalRepo(DapperContext dc)
    {
        _dc = dc;
    }

   

    public Task AddCountry(CountryDto country)
    {
        throw new NotImplementedException();
    }

    public Task<int> AddHospital(Class_Hospital p)
    {
        throw new NotImplementedException();
    }

    public Task<int> CheckHospitalExists(string hospitalNo)
    {
        throw new NotImplementedException();
    }

    public string CreateAdditionalReport(int hospitalNo)
    {
        throw new NotImplementedException();
    }

    public string CreateInstitutionalReport(int hospitalNo)
    {
        throw new NotImplementedException();
    }

    public AdditionalReportDTO GetAdditionalReportItems(int hospitalNo, int which)
    {
        throw new NotImplementedException();
    }

    public List<Class_Item> GetAllCities()
    {
        throw new NotImplementedException();
    }

    public List<Class_Item> GetAllCitiesPerCountry(string id)
    {
        throw new NotImplementedException();
    }

    public List<Class_Country_Items> GetAllCountries()
    {
        throw new NotImplementedException();
    }

    public Task<List<Class_Hospital>> GetAllFullHospitals()
    {
        throw new NotImplementedException();
    }

    public Task<List<Class_Hospital>> GetAllFullHospitalsPerCountry(string id)
    {
        throw new NotImplementedException();
    }

    public List<HospitalForReturnDTO> GetAllHospitals()
    {
        throw new NotImplementedException();
    }

    public Task<List<HospitalForReturnDTO>> GetAllHospitalsThisSurgeonWorkedIn(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Class_Hospital> GetClassHospital(string id)
    {
        throw new NotImplementedException();
    }

    public InstitutionalDTO GetInstitutionalReport(int hospitalNo, int soort)
    {
        throw new NotImplementedException();
    }

    public Task<HospitalForReturnDTO> GetSpecificHospital(string hospitalId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> HospitalImplementsOVI(string id)
    {
        throw new NotImplementedException();
    }

    public int UpdateAdditionalReportItem(AdditionalReportDTO l, int id, int which)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdateHospital(Class_Hospital p)
    {
        throw new NotImplementedException();
    }

    public string UpdateInstitutionalReport(InstitutionalDTO rep, int hospitalNo, int soort)
    {
        throw new NotImplementedException();
    }
}