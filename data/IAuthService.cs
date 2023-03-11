namespace TravelCompany.data
{
    public interface IAuthService
    {
        Task<ActionResult<AuthModel>> Register(VMUser login);
    }
}
