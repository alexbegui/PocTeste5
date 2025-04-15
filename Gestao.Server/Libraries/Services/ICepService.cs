
using Gestao.Server.Libraries.Services;


namespace Gestao.Server.Libraries.Services
{
    public interface ICepService
    {
        Task<LocalAddress?> SearchByPostalCode(string postalCode);
    }
}
