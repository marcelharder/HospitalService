
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
    Task<int> HospitalImplementsOVI(string id);
    Task<List<Class_Hospital>?> GetAllFullHospitals();
    Task<List<Class_Hospital>?> GetAllFullHospitalsPerCountry(string id);
    Task<List<Class_Item>?> getHospitalsPerCountry(string id);
    Task<List<Class_Item>> getHospitalsWhereUserWorked(string hosp);
    Task<string?> getHospitalNameFromId(string hosp);
    Task<string?> getHospitalVendors(string id);
    Task<ClassCountry?> AddCountry(CountryDto country);
    Task<ClassCountry?> GetSpecificCountry(string IsoCode);
    Task<List<ClassCountry>?> GetAllCountries();
    Task<List<Class_Item>> GetAllCities();
    Task<List<Class_Item>?> GetAllCitiesPerCountry(string id);
    Task<int> UpdateCountry(ClassCountry p);
    Task<List<Class_Item>?> HospitalsPerCountryTelCode(string telCode);
    Task<List<Class_Item>?> getHospitalsPerCountryCountryId(string countryId);
    Task<List<Class_Item>?> HospitalsPerCountryIso(string country);
    Task<List<Class_Item>?> AllHospitals();
    Task<PagedList<Class_Hospital>?> GetPagedHospitalList(HospitalParams hp);
    Task<int?> GetCountryIdFromDescription(string description);
    Task<string?> addVendors(string vendor, string hospital);
    Task<string?> removeVendor(string vendor, string hospital);
    Task<string?> GetCountryNameFromId(string id);
    Task<string?> GetIsoCodeFromId(string id);
    Task<string?> GetIsoCodeFromDescription(string description);
    Task<List<Class_Hospital>?> GetSpPH(string selectedVendor, string currentCountry);
    Task<List<Class_Hospital>?> GetNegSpPH(string selectedVendor, string currentCountry);
    Task<List<Class_Item>?> GetItemsSpPH(string selectedVendor, string currentCountry);


   
}
