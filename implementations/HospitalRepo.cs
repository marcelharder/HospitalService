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

    public async Task<int> AddHospital(Class_Hospital cp)
    {
         var query = "INSERT INTO Hospital (HospitalId,SelectedHospitalName, HospitalName, ImageUrl, Address, Regel_5, " +
       "Regel_6, Regel_7, Regel_8, Regel_9, Regel_10, " +
       "Regel_11, Regel_12, Regel_13, Regel_14, Regel_15, " +
       "Regel_16, Regel_17, Regel_18, Regel_19, Regel_20, " +
       "Regel_21, Regel_22, Regel_23, Regel_24, Regel_25, " +
       "Regel_26, Regel_27, Regel_28, Regel_29, Regel_30, " +
       "Regel_31, Regel_32, Regel_33 )" +
       "VALUES (@HospitalId, @SelectedHospitalName, @HospitalName, @ImageUrl, @Address, @Regel_5,  " +
       "@Regel_6, @Regel_7, @Regel_8, @Regel_9, @Regel_10, " +
       "@Regel_11, @Regel_12, @Regel_13, @Regel_14, @Regel_15, " +
       "@Regel_16, @Regel_17, @Regel_18, @Regel_19, @Regel_20, " +
       "@Regel_21, @Regel_22, @Regel_23, @Regel_24, @Regel_25, " +
       "@Regel_26, @Regel_27, @Regel_28, @Regel_29, @Regel_30, " +
       "@Regel_31, @Regel_32, @Regel_33);" + "SELECT LAST_INSERT_ID();";

        var parameters = new DynamicParameters();

        parameters.Add("HospitalId", cp.HospitalId, DbType.Int32);
        parameters.Add("SelectedHospitalName", cp.SelectedHospitalName, DbType.String);
        parameters.Add("HospitalName", cp.HospitalName, DbType.String);
        parameters.Add("ImageUrl", cp.ImageUrl, DbType.String);
        parameters.Add("Address", cp.Address, DbType.String);
        parameters.Add("Regel_5", cp.regel_5, DbType.String);
        parameters.Add("Regel_6", cp.regel_6, DbType.String);
        parameters.Add("Regel_7", cp.regel_7, DbType.String);
        parameters.Add("Regel_8", cp.regel_8, DbType.String);
        parameters.Add("Regel_9", cp.regel_9, DbType.String);
        parameters.Add("Regel_10", cp.regel_10, DbType.String);

        parameters.Add("Regel_11", cp.regel_11, DbType.String);
        parameters.Add("Regel_12", cp.regel_12, DbType.String);
        parameters.Add("Regel_13", cp.regel_13, DbType.String);
        parameters.Add("Regel_14", cp.regel_14, DbType.String);
        parameters.Add("Regel_15", cp.regel_15, DbType.String);
        parameters.Add("Regel_16", cp.regel_16, DbType.String);
        parameters.Add("Regel_17", cp.regel_17, DbType.String);
        parameters.Add("Regel_18", cp.regel_18, DbType.String);
        parameters.Add("Regel_19", cp.regel_19, DbType.String);
        parameters.Add("Regel_20", cp.regel_20, DbType.String);

        parameters.Add("Regel_21", cp.regel_21, DbType.String);
        parameters.Add("Regel_22", cp.regel_22, DbType.String);
        parameters.Add("Regel_23", cp.regel_23, DbType.String);
        parameters.Add("Regel_24", cp.regel_24, DbType.String);
        parameters.Add("Regel_25", cp.regel_25, DbType.String);
        parameters.Add("Regel_26", cp.regel_26, DbType.String);
        parameters.Add("Regel_27", cp.regel_27, DbType.String);
        parameters.Add("Regel_28", cp.regel_28, DbType.String);
        parameters.Add("Regel_29", cp.regel_29, DbType.String);
        parameters.Add("Regel_30", cp.regel_30, DbType.String);

        parameters.Add("Regel_31", cp.regel_31, DbType.String);
        parameters.Add("Regel_32", cp.regel_32, DbType.String);
        parameters.Add("Regel_33", cp.regel_33, DbType.String);

        using (var connection = _dc.CreateConnection())
        {
            var id = await connection.QuerySingleAsync<int>(query, parameters);
            var createdHospital = new Class_Hospital
            {
                HospitalId = id,
                SelectedHospitalName = cp.SelectedHospitalName,
                HospitalName = cp.HospitalName,
                regel_2 = cp.regel_2,
                regel_3 = cp.regel_3,
                regel_4 = cp.regel_4,
                regel_5 = cp.regel_5,
                regel_6 = cp.regel_6,
                regel_7 = cp.regel_7,
                regel_8 = cp.regel_8,
                regel_9 = cp.regel_9,
                regel_10 = cp.regel_10,
                regel_11 = cp.regel_11,
                regel_12 = cp.regel_12,
                regel_13 = cp.regel_13,
                regel_14 = cp.regel_14,
                regel_15 = cp.regel_15,
                regel_16 = cp.regel_16,
                regel_17 = cp.regel_17,
                regel_18 = cp.regel_18,
                regel_19 = cp.regel_19,
                regel_20 = cp.regel_20,
                regel_21 = cp.regel_21,
                regel_22 = cp.regel_22,
                regel_23 = cp.regel_23,
                regel_24 = cp.regel_24,
                regel_25 = cp.regel_25,
                regel_26 = cp.regel_26,
                regel_27 = cp.regel_27,
                regel_28 = cp.regel_28,
                regel_29 = cp.regel_29,
                regel_30 = cp.regel_30,
                regel_31 = cp.regel_31,
                regel_32 = cp.regel_32,
                regel_33 = cp.regel_33


            };
            return createdPreviewReport;
        }
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

    public async Task<HospitalForReturnDTO> GetSpecificHospital(string no)
    {
       var hospitalNo = no.makeSureTwoChar();
       var query = "SELECT * FROM hospital_per_country WHERE HospitalNo = @hospitalNo";
       using (var connection = _dc.CreateConnection())
        {
            var res = await connection.QuerySingleOrDefaultAsync<Class_Hospital>(query, new { hospitalNo });
            var result =  _mapper.mapToHospitalForReturn(res);
             return result;
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
         var query = "UPDATE Hospital SET HospitalName = @hn, Regel_2 = @Regel_2, " +
        "Regel_3 = @Regel_3, Regel_4 = @Regel_4, Regel_5 = @Regel_5, " +
        "Regel_6 = @Regel_6, Regel_7 = @Regel_7, Regel_8 = @Regel_8, " +
        "Regel_9 = @Regel_9, Regel_10 = @Regel_10, Regel_11 = @Regel_11, " +
        "Regel_12 = @Regel_12, Regel_13 = @Regel_13, Regel_14 = @Regel_14, " +
        "Regel_15 = @Regel_15, Regel_16 = @Regel_16, Regel_17 = @Regel_17, " +
        "Regel_18 = @Regel_18, Regel_19 = @Regel_19, Regel_20 = @Regel_20, " +
        "Regel_21 = @Regel_21, Regel_22 = @Regel_22, Regel_23 = @Regel_23, " +
        "Regel_24 = @Regel_24, Regel_25 = @Regel_25, Regel_26 = @Regel_26, " +
        "Regel_27 = @Regel_27, Regel_28 = @Regel_28, Regel_29 = @Regel_29, " +
        "Regel_30 = @Regel_30, Regel_31 = @Regel_31, Regel_32 = @Regel_32, " +
        "Regel_33 = @Regel_33 WHERE hospitalNo = @hospitalNo";
        var parameters = new DynamicParameters();
        parameters.Add("hospitalNo", pv.HospitalNo, DbType.Int32);
        parameters.Add("hn", pv.HospitalName, DbType.String);
        parameters.Add("Regel_2", pv.regel_2, DbType.String);
        parameters.Add("Regel_3", pv.regel_3, DbType.String);
        parameters.Add("Regel_4", pv.regel_4, DbType.String);
        parameters.Add("Regel_5", pv.regel_5, DbType.String);
        parameters.Add("Regel_6", pv.regel_6, DbType.String);
        parameters.Add("Regel_7", pv.regel_7, DbType.String);
        parameters.Add("Regel_8", pv.regel_8, DbType.String);
        parameters.Add("Regel_9", pv.regel_9, DbType.String);
        parameters.Add("Regel_10", pv.regel_10, DbType.String);
        parameters.Add("Regel_11", pv.regel_11, DbType.String);
        parameters.Add("Regel_12", pv.regel_12, DbType.String);
        parameters.Add("Regel_13", pv.regel_13, DbType.String);
        parameters.Add("Regel_14", pv.regel_14, DbType.String);
        parameters.Add("Regel_15", pv.regel_15, DbType.String);
        parameters.Add("Regel_16", pv.regel_16, DbType.String);
        parameters.Add("Regel_17", pv.regel_17, DbType.String);
        parameters.Add("Regel_18", pv.regel_18, DbType.String);
        parameters.Add("Regel_19", pv.regel_19, DbType.String);
        parameters.Add("Regel_20", pv.regel_20, DbType.String);
        parameters.Add("Regel_21", pv.regel_21, DbType.String);
        parameters.Add("Regel_22", pv.regel_22, DbType.String);
        parameters.Add("Regel_23", pv.regel_23, DbType.String);
        parameters.Add("Regel_24", pv.regel_24, DbType.String);
        parameters.Add("Regel_25", pv.regel_25, DbType.String);
        parameters.Add("Regel_26", pv.regel_26, DbType.String);
        parameters.Add("Regel_27", pv.regel_27, DbType.String);
        parameters.Add("Regel_28", pv.regel_28, DbType.String);
        parameters.Add("Regel_29", pv.regel_29, DbType.String);
        parameters.Add("Regel_30", pv.regel_30, DbType.String);
        parameters.Add("Regel_31", pv.regel_31, DbType.String);
        parameters.Add("Regel_32", pv.regel_32, DbType.String);
        parameters.Add("Regel_33", pv.regel_33, DbType.String);

        using (var connection = _dc.CreateConnection()) { await connection.ExecuteAsync(query, parameters); }

        return 1;
    }

    public string UpdateInstitutionalReport(InstitutionalDTO rep, int hospitalNo, int soort)
    {
        throw new NotImplementedException();
    }
}