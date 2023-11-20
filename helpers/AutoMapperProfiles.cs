namespace api.Helpers;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {

        CreateMap<Class_Hospital, HospitalForReturnDTO>();

        CreateMap<HospitalForReturnDTO, Class_Hospital>()
        .ForMember(dest => dest.RegExpr, opt => opt.Ignore())
        .ForMember(dest => dest.SampleMrn, opt => opt.Ignore())
        .ForMember(dest => dest.ImageUrl, opt => opt.Ignore());

    }
}
