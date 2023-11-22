namespace HospitalService.interfaces;

    public interface IHospitalRepository
    {
        Task<List<HospitalForReturnDTO>> GetAllHospitals();       
        Task<HospitalForReturnDTO?> GetSpecificHospital(string hospitalId);
        Task<List<HospitalForReturnDTO>> GetAllHospitalsThisSurgeonWorkedIn(string[] id) ;
        List<Class_Country_Items> GetAllCountries();
        List<Class_Item> GetAllCities();
        Task<int> UpdateHospital(Class_Hospital p);
        Task<int> UpdateCountry(Class_Hospital p);
        Task<Class_Hospital?> AddHospital(Class_Hospital p);
        Task<bool> CheckHospitalExists(string hospitalNo);
        Task<Class_Hospital> GetClassHospital(string id);
        List<Class_Item> GetAllCitiesPerCountry(string id);
        Task<bool> HospitalImplementsOVI(string id);
        Task<List<Class_Hospital>> GetAllFullHospitals();
        Task<List<Class_Hospital>> GetAllFullHospitalsPerCountry(string id);
        InstitutionalDTO GetInstitutionalReport(int hospitalNo, int soort);
        string CreateInstitutionalReport(int hospitalNo);
        string CreateAdditionalReport(int hospitalNo);
        string UpdateInstitutionalReport(InstitutionalDTO rep, int hospitalNo, int soort);
        AdditionalReportDTO GetAdditionalReportItems(int hospitalNo,int which);
        int UpdateAdditionalReportItem(AdditionalReportDTO l, int id, int which);
        Task AddCountry(CountryDto country);
    }
