namespace HospitalService.helpers;
public class reportMapper
{
    private readonly IMapper _map;
    public reportMapper(IMapper map){_map = map; }

    public HospitalForReturnDTO mapToHospitalForReturn(Class_Hospital x) {
         return _map.Map<Class_Hospital, HospitalForReturnDTO>(x); }
    public Class_Hospital mapToHospital(HospitalForReturnDTO x, Class_Hospital h) {
         h = _map.Map<HospitalForReturnDTO, Class_Hospital>(x, h); return h; }

}
