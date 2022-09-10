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

        public User GetOne(string phone)
        {
            return _context.Users.SingleOrDefault(user => user.Phone == phone);
        }

        public bool Verify(int id)
        {
            var record = _context.Users.Single(user => user.UserId == id);
            record.Verified = true;
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            Console.WriteLine(saved);

            return saved > 0 ? true : false;
        }
    }
}
