namespace Palmfit.Api.Repository
{
	public interface IRegister
	{
		Task<string> RegisterUser(RegisterDTO registerDTO);
	}
}
