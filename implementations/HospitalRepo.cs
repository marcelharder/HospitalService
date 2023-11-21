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



    public Task AddCountry(CountryDto country)
    {
        throw new NotImplementedException();
    }

    public async Task<Class_Hospital?> AddHospital(Class_Hospital cp)
    {
        var query = "INSERT INTO Hospitals (SelectedHospitalName,HospitalName,HospitalNo,Description,Address,Telephone," +
      "Fax,City,Country,SampleMrn,RegExpr,UsesOnlineValveInventory,ImageUrl,OpReportDetails1,OpReportDetails2,OpReportDetails3," +
      "OpReportDetails4,OpReportDetails5,OpReportDetails6,OpReportDetails7,OpReportDetails8,OpReportDetails9)" +
      "VALUES (@SelectedHospitalName,@HospitalName,@HospitalNo,@Description,@Address,@Telephone,@Fax,@City,@Country,@SampleMrn," +
      "@RegExpr,@UsesOnlineValveInventory,@ImageUrl,@OpReportDetails1,@OpReportDetails2,@OpReportDetails3," +
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
                    OpReportDetails1 = cp.OpReportDetails1,
                    OpReportDetails2 = cp.OpReportDetails2,
                    OpReportDetails3 = cp.OpReportDetails3,
                    OpReportDetails4 = cp.OpReportDetails4,
                    OpReportDetails5 = cp.OpReportDetails5,
                    OpReportDetails6 = cp.OpReportDetails6,
                    OpReportDetails7 = cp.OpReportDetails7,
                    OpReportDetails8 = cp.OpReportDetails8,
                    OpReportDetails9 = cp.OpReportDetails9,
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

    public Task<bool> HospitalImplementsOVI(string id)
    {
        throw new NotImplementedException();
    }

    public int UpdateAdditionalReportItem(AdditionalReportDTO l, int id, int which)
    {
        throw new NotImplementedException();
    }

    public async Task<int> UpdateHospital(Class_Hospital pv)
    {
        var query = "UPDATE Hospitals SET HospitalName = @hn, selectedHospitalName = @shn, " +
       "HospitalNo = @HospitalNo, Description = @Description, Address = @Address, Telephone = @Telephone, Fax = @Fax, " +
       "City = @City, Country = @Country, SampleMrn = @SampleMrn, Regexpr = @Regexpr, " +
       "usesOnlineValveInventory = @usesOnlineValveInventory, ImageUrl = @ImageUrl,OpReportDetails1 = @OpreportDetails1, " +
       "OpreportDetails2 = @OpreportDetails2, OpreportDetails3 = @OpreportDetails3, OpreportDetails4 = @OpreportDetails4, " +
       "OpreportDetails5 = @OpreportDetails5, OpreportDetails6 = @OpreportDetails6, OpreportDetails7 = @OpreportDetails7, " +
       "OpreportDetails8 = @OpreportDetails8, OpreportDetails9 = @OpreportDetails9 WHERE hospitalNo = @hospitalNo";

        var parameters = new DynamicParameters();

        parameters.Add("hn", pv.HospitalName);
        parameters.Add("shn", pv.SelectedHospitalName);
        parameters.Add("HospitalNo", pv.HospitalNo);
        parameters.Add("Description", pv.Description);
        parameters.Add("Address", pv.Address);
        parameters.Add("Telephone", pv.Telephone);
        parameters.Add("Fax", pv.Fax);
        parameters.Add("City", pv.City);
        parameters.Add("Country", pv.Country);
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
        parameters.Add("hospitalNo", pv.HospitalNo);

        using (var connection = _dc.CreateConnection()) { await connection.ExecuteAsync(query, parameters); }

        return 1;
    }

    public string UpdateInstitutionalReport(InstitutionalDTO rep, int hospitalNo, int soort)
    {
        throw new NotImplementedException();
    }
}