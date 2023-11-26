using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Http.HttpResults;

namespace HospitalService.implementations;

public class HospitalRepo : IHospitalRepository
{
    private readonly DapperContext _dc;
    private readonly reportMapper _mapper;

    public HospitalRepo(DapperContext dc, reportMapper mapper)
    {
        _dc = dc;
        _mapper = mapper;
    }

    #region <!--Country Stuff -->
    public async Task<ClassCountry?> AddCountry(CountryDto cp)
    {
        var query = "INSERT INTO Countries (TelCode,IsoCode,Description, Cities)" +
                    "VALUES (@TelCode,@IsoCode,@Description,@Cities);" + " SELECT LAST_INSERT_ID() FROM Countries";

        var parameters = new DynamicParameters();

        parameters.Add("TelCode", cp.TelCode, DbType.String);
        parameters.Add("IsoCode", cp.IsoCode, DbType.String);
        parameters.Add("Description", cp.Description, DbType.String);
        parameters.Add("Cities", cp.Cities, DbType.String);

        using (var connection = _dc.CreateConnection())
        {
            var id = await connection.QueryFirstOrDefaultAsync<int>(query, parameters);
            if (id != 0)
            {
                var createdCountry = new ClassCountry
                {
                    Id = id,
                    TelCode = cp.TelCode,
                    IsoCode = cp.IsoCode,
                    Description = cp.Description,
                    Cities = cp.Cities,

                };
                return createdCountry;
            }
            else
            {
                return null;
            }
        }
    }
    public async Task<List<Class_Item>> GetAllCities()
    {
        var list = new List<Class_Item>();
        var counter = 0;
        var allCountries = await GetAllCountries();
        if (allCountries != null)
        {
            foreach (ClassCountry ch in allCountries)
            {
                if (ch.Cities != null)
                {
                    var arrayCities = ch.Cities.Split(',');
                    foreach (string el in arrayCities)
                    {
                        var ci = new Class_Item();
                        ci.Value = counter++;
                        ci.Description = el;
                        list.Add(ci);
                    }
                }
            }

        }
        return list;
    }
    public async Task<List<Class_Item>?> GetAllCitiesPerCountry(string id)
    {
        var list = new List<Class_Item>();
        var counter = 0;
        var query = "SELECT * FROM Countries WHERE IsoCode = @id";
        using (var connection = _dc.CreateConnection())
        {
            var res = await connection.QueryFirstOrDefaultAsync<ClassCountry>(query, new { id });
            if (res != null)
            {
                if (res.Cities != null)
                {
                    var arrayCities = res.Cities.Split(',').ToList();
                    foreach (string el in arrayCities)
                    {
                        var ci = new Class_Item();
                        ci.Value = counter++;
                        ci.Description = el;
                        list.Add(ci);
                    }
                }
            }
        }
        return list;
    }
    public async Task<List<ClassCountry>?> GetAllCountries()
    {
        var list = new List<ClassCountry>();
        var query = "SELECT * FROM Countries";
        using (var connection = _dc.CreateConnection())
        {
            var res = await connection.QueryAsync<ClassCountry>(query);
            if (res != null)
            {
                foreach (ClassCountry cc in res)
                { list.Add(cc); }
            }
        }
        return list;
    }
    public async Task<ClassCountry?> GetSpecificCountry(string IsoCode)
    {
        var result = new ClassCountry();
        var query = "SELECT * FROM Countries WHERE IsoCode = @IsoCode";
        using (var connection = _dc.CreateConnection())
        {
            var res = await connection.QueryFirstOrDefaultAsync<ClassCountry>(query, new { IsoCode });
            if (res != null)
            {
                result = res;
            }

        }
        return result;
    }
    public async Task<int> UpdateCountry(ClassCountry pv)
    {
        var query = "UPDATE Countries SET TelCode = @TelCode, IsoCode = @IsoCode,Description = @Description, Cities = @Cities WHERE Id = @Id";

        var parameters = new DynamicParameters();

        parameters.Add("Id", pv.Id);
        parameters.Add("TelCode", pv.TelCode);
        parameters.Add("IsoCode", pv.IsoCode);
        parameters.Add("Description", pv.Description);
        parameters.Add("Cities", pv.Cities);
        using (var connection = _dc.CreateConnection()) { await connection.ExecuteAsync(query, parameters); }

        return 1;
    }

    #endregion



    public async Task<Class_Hospital?> AddHospital(Class_Hospital cp)
    {
        var query = "INSERT INTO Hospitals (SelectedHospitalName,HospitalName,HospitalNo,Description,Address,Telephone," +
      "Fax,City,Country,SampleMrn,RegExpr,UsesOnlineValveInventory,ImageUrl,OpReportDetails1,OpReportDetails2,OpReportDetails3," +
      "Vendors,Rp,SMSMobileNumber,SMSSendTime,TriggerOneMonth,TriggerTwoMonth,TriggerThreeMonth,DBBackend, " +
      "OpReportDetails4,OpReportDetails5,OpReportDetails6,OpReportDetails7,OpReportDetails8,OpReportDetails9)" +
      "VALUES (@SelectedHospitalName,@HospitalName,@HospitalNo,@Description,@Address,@Telephone,@Fax,@City,@Country,@SampleMrn," +
      "@RegExpr,@UsesOnlineValveInventory,@ImageUrl,@OpReportDetails1,@OpReportDetails2,@OpReportDetails3," +
      "@Vendors,@Rp,@SMSMobileNumber,@SMSSendTime,@TriggerOneMonth,@TriggerTwoMonth,@TriggerThreeMonth,@DBBackend, " +
      "@OpReportDetails4,@OpReportDetails5,@OpReportDetails6," +
      "@OpReportDetails7,@OpReportDetails8,@OpReportDetails9);" + " SELECT LAST_INSERT_ID() FROM Hospitals";

        var parameters = new DynamicParameters();


        parameters.Add("SelectedHospitalName", cp.SelectedHospitalName, DbType.String);
        parameters.Add("HospitalName", cp.HospitalName, DbType.String);
        parameters.Add("HospitalNo", cp.HospitalNo, DbType.String);
        parameters.Add("Description", cp.Description, DbType.String);
        parameters.Add("Address", cp.Address, DbType.String);
        parameters.Add("Telephone", cp.Telephone, DbType.String);
        parameters.Add("Fax", cp.Fax, DbType.String);
        parameters.Add("City", cp.City, DbType.String);
        parameters.Add("Country", cp.Country, DbType.String);
        parameters.Add("SampleMrn", cp.SampleMrn, DbType.String);
        parameters.Add("RegExpr", cp.RegExpr, DbType.String);
        parameters.Add("UsesOnlineValveInventory", cp.UsesOnlineValveInventory, DbType.Boolean);
        parameters.Add("ImageUrl", cp.ImageUrl, DbType.String);
        parameters.Add("Vendors", cp.Vendors, DbType.String);
        parameters.Add("Rp", cp.Rp, DbType.String);
        parameters.Add("SMSMobileNumber", cp.SMSMobileNumber, DbType.String);
        parameters.Add("SMSSendTime", cp.SMSSendTime, DbType.String);
        parameters.Add("TriggerOneMonth", cp.TriggerOneMonth, DbType.Boolean);
        parameters.Add("TriggerTwoMonth", cp.TriggerTwoMonth, DbType.Boolean);
        parameters.Add("TriggerThreeMonth", cp.TriggerThreeMonth, DbType.Boolean);
        parameters.Add("DBBackend", cp.DBBackend, DbType.String);

        parameters.Add("OpReportDetails1", cp.OpReportDetails1, DbType.String);
        parameters.Add("OpReportDetails2", cp.OpReportDetails2, DbType.String);
        parameters.Add("OpReportDetails3", cp.OpReportDetails3, DbType.String);
        parameters.Add("OpReportDetails4", cp.OpReportDetails4, DbType.String);
        parameters.Add("OpReportDetails5", cp.OpReportDetails5, DbType.String);
        parameters.Add("OpReportDetails6", cp.OpReportDetails6, DbType.String);
        parameters.Add("OpReportDetails7", cp.OpReportDetails7, DbType.String);
        parameters.Add("OpReportDetails8", cp.OpReportDetails8, DbType.String);
        parameters.Add("OpReportDetails9", cp.OpReportDetails9, DbType.String);

        using (var connection = _dc.CreateConnection())
        {
            var id = await connection.QueryFirstOrDefaultAsync<int>(query, parameters);
            if (id != 0)
            {
                var createdHospital = new Class_Hospital
                {
                    HospitalId = id,
                    SelectedHospitalName = cp.SelectedHospitalName,
                    HospitalName = cp.HospitalName,
                    HospitalNo = cp.HospitalNo,
                    Description = cp.Description,
                    Address = cp.Address,
                    Telephone = cp.Telephone,
                    Fax = cp.Fax,
                    City = cp.City,
                    Country = cp.Country,
                    SampleMrn = cp.SampleMrn,
                    RegExpr = cp.RegExpr,
                    UsesOnlineValveInventory = cp.UsesOnlineValveInventory,
                    ImageUrl = cp.ImageUrl,
                    Vendors = cp.Vendors,
                    Rp = cp.Rp,
                    SMSMobileNumber = cp.SMSMobileNumber,
                    SMSSendTime = cp.SMSSendTime,
                    TriggerOneMonth = cp.TriggerOneMonth,
                    TriggerTwoMonth = cp.TriggerTwoMonth,
                    TriggerThreeMonth = cp.TriggerThreeMonth,
                    DBBackend = cp.DBBackend,
                    OpReportDetails1 = cp.OpReportDetails1,
                    OpReportDetails2 = cp.OpReportDetails2,
                    OpReportDetails3 = cp.OpReportDetails3,
                    OpReportDetails4 = cp.OpReportDetails4,
                    OpReportDetails5 = cp.OpReportDetails5,
                    OpReportDetails6 = cp.OpReportDetails6,
                    OpReportDetails7 = cp.OpReportDetails7,
                    OpReportDetails8 = cp.OpReportDetails8,
                    OpReportDetails9 = cp.OpReportDetails9,
                    RefHospitals = cp.RefHospitals,
                    StandardRef = cp.StandardRef,
                    Email = cp.Email,
                    Contact = cp.Contact,
                    Contact_image = cp.Contact_image,
                    PostalCode = cp.PostalCode
                };
                return createdHospital;
            }
            else
            {
                return null;
            }
        }
    }
    public async Task<bool> CheckHospitalExists(string hospitalNo)
    {
        var help = false;
        await Task.Run(async () =>
        {
            using (var connection = _dc.CreateConnection())
            {
                var sql = "SELECT * FROM Hospitals WHERE HospitalNo = @hospitalNo";
                var count = await connection.ExecuteScalarAsync<int>(sql, new { hospitalNo });
                if (count != 0) { help = true; }
            }
        });
        return help;
    }
    public async Task<List<Class_Hospital>?> GetAllFullHospitals()
    {
        var query = "SELECT * FROM Hospitals";
        using (var connection = _dc.CreateConnection())
        {
            var res = await connection.QueryAsync<Class_Hospital>(query);
            if (res != null)
            {
                return res.ToList();
            }
            return null;
        }
    }
    public async Task<List<Class_Hospital>?> GetAllFullHospitalsPerCountry(string id) // id is bv NL of US
    {
        var query = "SELECT * FROM Hospitals WHERE Country = @id";
        using (var connection = _dc.CreateConnection())
        {
            var res = await connection.QueryAsync<Class_Hospital>(query, new { id });
            if (res != null)
            {
                return res.ToList();
            }
            return null;
        }
    }
    public async Task<List<Class_Item>?> getHospitalsPerCountry(string id) // id is bv NL of US
    {
        var list = new List<Class_Item>();
        var query = "SELECT * FROM Hospitals WHERE Country = @id";
        using (var connection = _dc.CreateConnection())
        {
            var res = await connection.QueryAsync<Class_Hospital>(query, new { id });
            if (res != null)
            {
                foreach (Class_Hospital ch in res)
                {

                    var ci = new Class_Item();
                    ci.Value = Convert.ToInt32(ch.HospitalNo);
                    ci.Description = ch.HospitalName;
                    list.Add(ci);

                }
                return list;
            }
        }
        return null;
    }
    public async Task<List<Class_Item>> getHospitalsWhereUserWorked(string hosp) // bv 4,48,5
    {
        var list = new List<Class_Item>();
        //make array from string
        var ar = hosp.Split(',').ToList();
        foreach(string test in ar){
           HospitalForReturnDTO? help = await GetSpecificHospital(test);
            if (help != null)
            {
                var ci = new Class_Item();
                ci.Value = Convert.ToInt32(help.HospitalNo);
                ci.Description = help.HospitalName;
                list.Add(ci);
            }
        }
        return list;
    }



    public async Task<List<HospitalForReturnDTO>?> GetAllHospitals()
    {
        var help = new HospitalForReturnDTO();
        var help_list = new List<HospitalForReturnDTO>();
        var query = "SELECT * FROM Hospitals";
        using (var connection = _dc.CreateConnection())
        {
            var res = await connection.QueryAsync<Class_Hospital>(query);
            if (res != null)
            {
                foreach (Class_Hospital ch in res)
                {
                    help_list.Add(_mapper.mapToHospitalForReturn(ch));
                }
                return help_list;
            }
            return null;
        }
    }
   
    public async Task<Class_Hospital?> GetClassHospital(string hospitalNo)
    {
        var hos = hospitalNo.makeSureTwoChar();
        var query = "SELECT * FROM Hospitals WHERE HospitalNo = @hos";
        using (var connection = _dc.CreateConnection())
        {
            var res = await connection.QueryFirstOrDefaultAsync<Class_Hospital>(query, new { hos });
            if (res != null)
            {
                return res;
            }
            return null;
        }
    }
    public async Task<HospitalForReturnDTO?> GetSpecificHospital(string no)
    {
        var hospitalNo = no.makeSureTwoChar();
        var query = "SELECT * FROM Hospitals WHERE HospitalNo = @hospitalNo";
        using (var connection = _dc.CreateConnection())
        {
            var res = await connection.QueryFirstOrDefaultAsync<Class_Hospital>(query, new { hospitalNo });
            if (res != null)
            {
                return _mapper.mapToHospitalForReturn(res);
            }
            return null;
        }
    }
    public async Task<bool> HospitalImplementsOVI(string id)
    {
        var selectedHospital = await GetSpecificHospital(id);
        if (selectedHospital != null)
        {
            return selectedHospital.UsesOnlineValveInventory;
        }
        else
        {
            return false;
        }
    }
    public async Task<int> UpdateHospital(Class_Hospital pv)
    {
        var query = "UPDATE Hospitals SET HospitalName = @hn, selectedHospitalName = @shn, " +
       "HospitalNo = @HospitalNo, Description = @Description, Address = @Address, Telephone = @Telephone, Fax = @Fax, " +
       "City = @City, Country = @Country, SampleMrn = @SampleMrn, Regexpr = @Regexpr, " +
       "RefHospitals = @RefHospitals,StandardRef = @StandardRef,Email = @Email, " +
       "Vendors = @Vendors,Rp = @Rp,SMSMobileNumber = @SMSMobileNumber, " +
       "SMSSendTime = @SMSSendTime ,TriggerOneMonth = @TriggerOneMonth,TriggerTwoMonth = @TriggerTwoMonth, " +
       "TriggerThreeMonth = @TriggerThreeMonth,DBBackend = @DBBackend, " +
       "Contact = @Contact,Contact_image = @Contact_image,PostalCode = @PostalCode, " +
       "usesOnlineValveInventory = @usesOnlineValveInventory, ImageUrl = @ImageUrl,OpReportDetails1 = @OpreportDetails1, " +
       "OpreportDetails2 = @OpreportDetails2, OpreportDetails3 = @OpreportDetails3, OpreportDetails4 = @OpreportDetails4, " +
       "OpreportDetails5 = @OpreportDetails5, OpreportDetails6 = @OpreportDetails6, OpreportDetails7 = @OpreportDetails7, " +
       "OpreportDetails8 = @OpreportDetails8, OpreportDetails9 = @OpreportDetails9 WHERE HospitalNo = @hospitalNo";

        var parameters = new DynamicParameters();

        parameters.Add("hn", pv.HospitalName);
        parameters.Add("shn", pv.SelectedHospitalName);
        parameters.Add("hospitalNo", pv.HospitalNo);
        parameters.Add("Description", pv.Description);
        parameters.Add("Address", pv.Address);
        parameters.Add("Telephone", pv.Telephone);
        parameters.Add("Fax", pv.Fax);
        parameters.Add("City", pv.City);
        parameters.Add("Country", pv.Country);

        parameters.Add("RefHospitals", pv.RefHospitals);
        parameters.Add("StandardRef", pv.StandardRef);
        parameters.Add("Telephone", pv.Telephone);
        parameters.Add("Email", pv.Email);
        parameters.Add("Contact", pv.Contact);
        parameters.Add("Contact_image", pv.Contact_image);
        parameters.Add("PostalCode", pv.PostalCode);

        parameters.Add("SampleMrn", pv.SampleMrn);
        parameters.Add("Regexpr", pv.RegExpr);
        parameters.Add("usesOnlineValveInventory", pv.UsesOnlineValveInventory);
        parameters.Add("ImageUrl", pv.ImageUrl);
        parameters.Add("OpreportDetails1", pv.OpReportDetails1);
        parameters.Add("OpreportDetails2", pv.OpReportDetails2);
        parameters.Add("OpreportDetails3", pv.OpReportDetails3);
        parameters.Add("OpreportDetails4", pv.OpReportDetails4);
        parameters.Add("OpreportDetails5", pv.OpReportDetails5);
        parameters.Add("OpreportDetails6", pv.OpReportDetails6);
        parameters.Add("OpreportDetails7", pv.OpReportDetails7);
        parameters.Add("OpreportDetails8", pv.OpReportDetails8);
        parameters.Add("OpreportDetails9", pv.OpReportDetails9);

        parameters.Add("Vendors", pv.Vendors, DbType.String);
        parameters.Add("Rp", pv.Rp, DbType.String);
        parameters.Add("SMSMobileNumber", pv.SMSMobileNumber, DbType.String);
        parameters.Add("SMSSendTime", pv.SMSSendTime, DbType.String);
        parameters.Add("TriggerOneMonth", pv.TriggerOneMonth, DbType.Boolean);
        parameters.Add("TriggerTwoMonth", pv.TriggerTwoMonth, DbType.Boolean);
        parameters.Add("TriggerThreeMonth", pv.TriggerThreeMonth, DbType.Boolean);
        parameters.Add("DBBackend", pv.DBBackend, DbType.String);


        using (var connection = _dc.CreateConnection()) { await connection.ExecuteAsync(query, parameters); }

        return 1;
    }
    public async Task<int> DeleteHospital(string hospitalNo)
    {
        var query = "DELETE FROM Hospitals WHERE HospitalNo = @hospitalNo";
        using (var connection = _dc.CreateConnection())
        {
            await connection.ExecuteAsync(query, new { hospitalNo });
        }
        return 1;
    }




    public string CreateInstitutionalReport(int hospitalNo)
    {
        throw new NotImplementedException();
    }

    public string UpdateInstitutionalReport(InstitutionalDTO rep, int hospitalNo, int soort)
    {
        throw new NotImplementedException();
    }

    public InstitutionalDTO GetInstitutionalReport(int hospitalNo, int soort)
    {
        throw new NotImplementedException();
    }










}