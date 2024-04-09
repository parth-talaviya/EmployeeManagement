namespace UserManagement.Application.Others;

public sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateUserViewModel, User>().ReverseMap();
        CreateMap<UserViewModel, User>().ReverseMap();
        CreateMap<LoginRequestViewModel, LoginUser>().ReverseMap();
        CreateMap<UserPasswordUpdateViewModel, User>().ReverseMap();
        CreateMap<UserUpdateProfileViewModel, User>().ReverseMap();
        CreateMap<RoleViewModel, Role>().ReverseMap();
        CreateMap<UpdateRoleViewModel, Role>().ReverseMap();
        CreateMap<AddRoleViewModel, Role>().ReverseMap();
        CreateMap<UserRoleViewModel, UserRole>().ReverseMap();
        CreateMap<AddUserRoleViewModel, UserRole>().ReverseMap();
        CreateMap<CreateContactDetailViewModel, ContactDetails>().ReverseMap();
        CreateMap<UpdateContactViewModel, ContactDetails>().ReverseMap();
        CreateMap<ContactOrganizationViewModel, ContactOrganization>().ReverseMap();
        CreateMap<OrganizationViewModel, Organization>().ReverseMap();
        CreateMap<AddOrganizationViewModel, Organization>().ReverseMap();
        CreateMap<UpdateOrganizationViewModel, Organization>().ReverseMap();
        CreateMap<AddContactOrganizationViewModel, ContactOrganization>().ReverseMap();
        CreateMap<ContactDetailsViewModel, ContactDetails>().ReverseMap();
        CreateMap<GetAllContactViewModel, GetAllContactModel>().ReverseMap();
        CreateMap<OrganizationLocationDetailsViewModel, LocationDetails>().ReverseMap();
        CreateMap<AddLocationDetailsViewModel, LocationDetails>().ReverseMap();
        CreateMap<UpdateLocationDetailsViewModel, LocationDetails>().ReverseMap();
        CreateMap<GetAllLocationDetailsViewModel, LocationDetails>().ReverseMap();
        CreateMap<GetAllLocationViewModel, LocationDetails>().ReverseMap();
        CreateMap<AddProvidersViewModel, ProvidersDetails>().ReverseMap();
        CreateMap<EditProvidersViewModel, ProvidersDetails>().ReverseMap();
        CreateMap<ProvidersDetailsViewModel, ProvidersDetails>().ReverseMap();
        CreateMap<AddServiceViewModel, ServiceDetails>().ReverseMap();
        CreateMap<EditServiceViewModel, ServiceDetails>().ReverseMap();
        CreateMap<ServiceDetailsViewModel, ServiceDetails>().ReverseMap();
        CreateMap<ServiceProviderDetailsViewModel, ServiceProviderDetails>().ReverseMap();
        CreateMap<AddServiceProviderViewModel, ServiceProviderDetails>().ReverseMap();
        CreateMap<GetAllServiceWithOrganizationAndLocationViewModel, ServiceDetails>().ReverseMap();
        CreateMap<AddBookingDetailsViewModel, BookingDetails>().ReverseMap();
        CreateMap<GetAllProviderswithLocationAndOrganizationViewModel, ProvidersDetails>().ReverseMap();
        CreateMap<GetAllBookingViewModel, BookingDetails>().ReverseMap();
        CreateMap<GetBookingByIdViewModel, BookingDetails>().ReverseMap();
        CreateMap<CancelBookingViewModel, BookingDetails>().ReverseMap();
        CreateMap<ConfirmBookingViewModel, BookingDetails>().ReverseMap();
        CreateMap<ResheduleBookingViewModel, BookingDetails>().ReverseMap();
        CreateMap<GetAllProviderswithLocationServiceAndOrganizationViewModel, ProvidersDetails>().ReverseMap();
        CreateMap<AddCountryDetailsViewModel, CountryDetails>().ReverseMap();
        CreateMap<EditCountryDetailsViewModel, CountryDetails>().ReverseMap();
        CreateMap<GetCountryDetailsViewModel, CountryDetails>().ReverseMap();
        CreateMap<CountryDetailsViewModel, CountryDetails>().ReverseMap();
    }
}