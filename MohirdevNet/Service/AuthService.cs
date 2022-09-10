using MohirdevNet.Dto;
using MohirdevNet.Enums;
using MohirdevNet.Exceptions;
using MohirdevNet.Helpers;
using MohirdevNet.Interfaces.Repository;
using MohirdevNet.Interfaces.Service;
using MohirdevNet.Model;
using System.Net;

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

        public bool Verify(string phone, int code)
        {
            var user = _authRepo.GetOne(phone);

            if (user == null)
            {
                throw new AppException("User not found", HttpStatusCode.NotFound);
            }

            if(user.VerificationCode != code)
            {
                throw new AppException("Incorrect code", HttpStatusCode.BadRequest);
            }
            return this._authRepo.Verify(user.UserId);
        }
    }
}
