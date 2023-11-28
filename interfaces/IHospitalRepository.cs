namespace HospitalService.interfaces;

public interface IHospitalRepository
{
    Task<List<HospitalForReturnDTO>?> GetAllHospitals();
    Task<HospitalForReturnDTO?> GetSpecificHospital(string hospitalId);
    Task<int> UpdateHospital(Class_Hospital p);
    Task<int> DeleteHospital(string p);
    Task<Class_Hospital?> AddHospital(Class_Hospital p);
    Task<bool> CheckHospitalExists(string hospitalNo);
    Task<Class_Hospital?> GetClassHospital(string id);
    Task<bool> HospitalImplementsOVI(string id);
    Task<List<Class_Hospital>?> GetAllFullHospitals();
    Task<List<Class_Hospital>?> GetAllFullHospitalsPerCountry(string id);
    Task<List<Class_Item>?> getHospitalsPerCountry(string id);
    Task<List<Class_Item>> getHospitalsWhereUserWorked(string hosp);
    Task<string?> getHospitalNameFromId(string hosp);


    Task<ClassCountry?> AddCountry(CountryDto country);
    Task<ClassCountry?> GetSpecificCountry(string IsoCode);
    Task<List<ClassCountry>?> GetAllCountries();
    Task<List<Class_Item>> GetAllCities();
    Task<List<Class_Item>?> GetAllCitiesPerCountry(string id);
    Task<int> UpdateCountry(ClassCountry p);
    Task<List<Class_Item>?> HospitalsPerCountryTelCode(string telCode);
    Task<List<Class_Item>?> HospitalsPerCountryIso(string country);
}
