using MohirdevNet.Dto;
using MohirdevNet.Enums;
using MohirdevNet.Helpers;
using MohirdevNet.Interfaces.Repository;
using MohirdevNet.Interfaces.Service;
using MohirdevNet.Model;

namespace MohirdevNet.Service
{
    public class AuthService : IAuthService
    {   
        private readonly IAuthRepository _authRepo;
        public AuthService(IAuthRepository authRepo)
        {
            _authRepo = authRepo;
        }
        public bool Create(UserDto request)
        {
            var user = new User();
            user.FirstName = request.firstName;
            user.LastName = request.lastName;
            user.Phone = request.phone;
            user.Role = Roles.Basic;
            user.Password = new PasswordGenerator().Create(request.password);
            user.VerificationCode = new CodeGeneraor().Generate();
            user.Verified = false;

            return this._authRepo.Create(user);
        }
    }
}
