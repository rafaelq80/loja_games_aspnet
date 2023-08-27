using loja_games.Model;

namespace loja_games.Security
{
    public interface IAuthService
    {
        Task<UserLogin?> Autenticar(UserLogin userLogin);
    }
}
