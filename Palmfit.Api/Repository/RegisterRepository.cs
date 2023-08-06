using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Palmfit.Data.AppDbContext;
using Palmfit.Data.Entities;

namespace Palmfit.Api.Repository
{
	public class RegisterRepository : IRegister
	{
		private readonly PalmfitDbContext _context;
		private readonly UserManager<AppUser> _userManager;

		public RegisterRepository(PalmfitDbContext context, UserManager<AppUser> userManager)
		{
			_context = context;
			_userManager = userManager;
		}

		public async Task<string> RegisterUser(RegisterDTO registerDTO )
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

	     	var result = await	_userManager.CreateAsync( appUser, registerDTO.Password);
	  

			if (result.Succeeded)
			return "User sucessfully registered!";

			return "registration failed!";
		}
	}
}
