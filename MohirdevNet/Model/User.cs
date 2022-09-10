using MohirdevNet.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MohirdevNet.Model
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public Roles Role { get; set; }
        public string Password { get; set; }
        public bool Verified { get; set; }
        public int? VerificationCode { get; set; }
    }
}
