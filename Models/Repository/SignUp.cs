using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.CodeAnalysis.Scripting;
using Org.BouncyCastle.Crypto.Generators;
using System.Security.Cryptography;
using System.Text;

namespace Web_Geinie9.Models.Repository
{
    public class SignUp
    {
        private readonly Geinie9Context _context;

        public SignUp(Geinie9Context context)
        {
            _context = context;
                
        }

        public  void AddUser(User user)
        {

            if(isValid(user) )
            {
                     user.Pass = HashedPassword(user.Pass);
                     user.ConfirmPassword =HashedPassword(user.ConfirmPassword);
                    _context.Add(user);
                    _context.SaveChanges();
            }
           

        }



        public bool isValid(User user)
        {
            if (user.FullName != "" && user.Email != "" && user.Pass != "" && user.ConfirmPassword != "")
                if (user.Pass.Equals(user.ConfirmPassword))
                    return true; 
            return false;
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
