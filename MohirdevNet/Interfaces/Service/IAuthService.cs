using MohirdevNet.Dto;

namespace MohirdevNet.Interfaces.Service
{
    public interface IAuthService
    {
        bool Create(UserDto user);   
    }
}
