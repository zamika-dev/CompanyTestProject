using CompanyTestProject.Application.Models.Authentication;

namespace CompanyTestProject.Infrustructure.Authentication
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> Login(AuthenticationRequest request);
        Task<AuthenticationResponse> Registeration(AuthenticationRequest request);
    }
}
