// encryption
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

// import data annotations for validation
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace WebAppProject3.Models
{
    public class UserModel

    {
        // private fields for all properties
        private int _userId = 0;
        private string _username = "";
        private string _passwordHash = "";
        private string _passwordSalt = "";
        private string _password = "";
        private string _passwordConfirmation = "";


        // public getters and setters for all properties, specifying private fields as backing fields and default values, add data annotations for validation

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        public string PasswordHash
        {
            get { return _passwordHash; }
            set { _passwordHash = value; }
        }

        public string PasswordSalt
        {
            get { return _passwordSalt; }
            set { _passwordSalt = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string PasswordConfirmation
        {
            get { return _passwordConfirmation; }
            set { _passwordConfirmation = value; }
        }

        public UserModel() {
            _userId = 0;
            _username = "";
            _passwordHash = "";
            _passwordSalt = "";
            _password = "";

        }

        // hash and salt password, taking username from current instance, salt as generated uid, and password from parameter. Also save both hash and salt to current instance
        public void HashAndSaltPassword(string password)
        {
            _passwordSalt = System.Guid.NewGuid().ToString();

            // use the cryptographic import to generate a hash from the password and salt
            _passwordHash = Convert.ToBase64String(KeyDerivation.Pbkdf2(password: password, salt: System.Text.Encoding.ASCII.GetBytes(PasswordSalt), prf: KeyDerivationPrf.HMACSHA512, iterationCount: 10000, numBytesRequested: 256 / 8));
        }

        // check if password matches hash and salt, taking password from parameter
        public bool ComparePasswordFromDB(string inputPassword)
        {
            // use the cryptographic import to generate a hash from the password and salt
            string passwordHash = Convert.ToBase64String(KeyDerivation.Pbkdf2(password: inputPassword, salt: System.Text.Encoding.ASCII.GetBytes(PasswordSalt), prf: KeyDerivationPrf.HMACSHA512, iterationCount: 10000, numBytesRequested: 256 / 8));

            // return true if the password hash matches the current instance's password hash
            return passwordHash == PasswordHash;
        }

        // validate password format, taking password from parameter, return true if password is valid
        public bool ValidatePassword(string inputPassword)
        {
            // password must be at least 8 characters long, contain at least one uppercase letter, one lowercase letter, one number, and one special character
            return inputPassword.Length >= 8 && System.Text.RegularExpressions.Regex.IsMatch(inputPassword, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$");
        }

        // method to compare password and password confirmation, return true if they match
        public bool ComparePasswordConfirmation()
        {
            return _password.Equals(_passwordConfirmation);
        }

        // method to delete password and password confirmation from current instance
        public void DeletePlainPasswordFields()
        {
            _password = "";
            _passwordConfirmation = "";
        }

    }
}
