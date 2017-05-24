using System;
using System.Collections.Generic;
using MyProject.Domain.Model;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using NHibernate.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace MyProject.Repository
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly AplicationUserManager _userManager;
        private readonly AplicationRoleManager _roleManager;
        private readonly IProfileRepository _profileRepository;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, AplicationUserManager userManager, IProfileRepository profileRepository, AplicationRoleManager roleManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
            _profileRepository = profileRepository;
            _roleManager = roleManager;
        }

        public ClaimsIdentity Authenticate(UserDTO userDto)
        {
            ClaimsIdentity claims = null;
            var user = _userManager.FindByName(userDto.UserName);
            if (user != null)
            {
                claims = _userManager.CreateIdentity(user,
                    DefaultAuthenticationTypes.ApplicationCookie);
                var profile = _profileRepository.GetById(user.Profile.Id);
                claims.AddClaim(new Claim("FirstName", profile.FirstName));
                claims.AddClaim(new Claim("LastName", profile.LastName));
            }
            return claims;
        }

        public void SetInitialData(UserDTO adminDto, List<string> roles)
        {
            foreach (string roleName in roles)
            {
                var role = _roleManager.FindByName(roleName);
                if (role == null)
                {
                    role = new Role { Name = roleName };
                    _roleManager.Create(role);
                }
            }
            RegistrationNewUser(adminDto);
        }

        public void RegistrationNewUser(UserDTO userDto)
        {
            var user = _userManager.FindByName(userDto.UserName);
            if (user == null)
            {
                user = _mapper.Map<UserDTO, User>(userDto);

                var result = _userManager.Create(user, userDto.Password);
                if (result.Errors.Any())
                {
                    throw new Exception(result.Errors.FirstOrDefault());
                }
                var role = _roleManager.FindByName(userDto.Role);
                if (role == null)
                {
                    role = new Role();
                    role.Name = userDto.Role;
                    _roleManager.Create(role);
                }
                _userManager.AddToRole(user.Id, userDto.Role);

                NeighborsGarage.DAL.Models.Profile profile = _mapper.Map<UserDTO, NeighborsGarage.DAL.Models.Profile>(userDto);
                profile.User = user;
                _profileRepository.Create(profile);
                user.Profile = profile;

                _unitOfWork.Commit();
            }
        }
    }
}
