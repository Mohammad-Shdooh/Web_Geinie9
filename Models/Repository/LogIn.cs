using System.Security.Cryptography;
using System.Text;

namespace Web_Geinie9.Models.Repository
{
    public class LogIn
    {
        private readonly Geinie9Context _context;
        public LogIn( Geinie9Context context)
        {
                this._context= context;
        }

        public User SignIn(string email , string pass )
        {
            pass = HashedPassword(pass);
            User user = _context.Users.FirstOrDefault(usr=>usr.Email== email && usr.Pass == pass);
            if(user==null)
            {
                return user;
            }
            return user;

        }
        public string HashedPassword(string pass)
        {
            var sha = SHA256.Create();
            var asByteArray = Encoding.Default.GetBytes(pass);
            var hashedPass = sha.ComputeHash(asByteArray);
            return Convert.ToBase64String(hashedPass);

        }
    }
}
