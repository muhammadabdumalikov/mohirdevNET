using MohirdevNet.Data;
using MohirdevNet.Interfaces.Repository;
using MohirdevNet.Model;

namespace MohirdevNet.Repository
{
    public class AuthRepository: IAuthRepository
    {
        private DataContext _context;

        public AuthRepository(DataContext context)
        {
            _context = context;
        } 

        public bool Create(User user)
        {
            _context.Add(user);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
