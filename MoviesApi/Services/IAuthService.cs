namespace MoviesApi.Services
{
    public interface IAuthService
    {

        Task<AuthModel> RegisterAsync(RegisterModel model);





    }
}
