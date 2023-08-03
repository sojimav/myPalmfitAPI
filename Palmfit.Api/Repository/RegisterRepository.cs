using Palmfit.Data.AppDbContext;
using Palmfit.Data.Entities;

namespace Palmfit.Api.Repository
{
	public class RegisterRepository : IRegister
	{
		private readonly PalmfitDbContext _context;

		public RegisterRepository(PalmfitDbContext context)
		{
			_context = context;
		}

		public async void RegisterUser(RegisterDTO registerDTO )
		{
			AppUser appUser = new AppUser()
			{
				Id = Guid.NewGuid().ToString(),
				Title = registerDTO.Title,
				FirstName = registerDTO.FirstName,
				LastName = registerDTO.LastName,
				Email = registerDTO.Email,
				UserName = registerDTO.UserName,
				MiddleName = registerDTO.MiddleName,
				PasswordHash = registerDTO.Password,
				Image = registerDTO.Image,
				Address = registerDTO.Address,
				Area = registerDTO.Area,
				State = registerDTO.State,
				Gender = registerDTO.Gender,
				DateOfBirth = registerDTO.DateOfBirth,
				Country = registerDTO.Country,
				InviteCode = "224",
				ReferralCode = "212"
			};

			await _context.Users.AddAsync(appUser);	
			_context.SaveChanges();
		}
	}
}
