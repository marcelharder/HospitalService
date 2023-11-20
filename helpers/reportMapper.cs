namespace HospitalService.helpers;
public class reportMapper
{
    private readonly IMapper _map;
    private IWebHostEnvironment _env;
    private IHospitalRepository _hos;


    public reportMapper(
        IMapper map,
        IWebHostEnvironment env,
        IHospitalRepository hos
      )
    {
        _map = map;
        _env = env;
        _hos = hos;
    }

    public HospitalForReturnDTO mapToHospitalForReturn(Class_Hospital x) { return _map.Map<Class_Hospital, HospitalForReturnDTO>(x); }
    public Class_Hospital mapToHospital(HospitalForReturnDTO x, Class_Hospital h) { h = _map.Map<HospitalForReturnDTO, Class_Hospital>(x, h); return h; }

}
