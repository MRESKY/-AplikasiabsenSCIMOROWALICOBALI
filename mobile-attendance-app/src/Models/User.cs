using System;

namespace MobileAttendanceApp.Models
{
    /// <summary>
    /// Represents a user in the system.
    /// </summary>
    public class User
    {
        private string _username = string.Empty;
        private string _password = string.Empty;

        /// <summary>
        /// The unique identifier for the user.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// The username of the user.
        /// </summary>
        public string Username
        {
            get => _username;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Username cannot be empty.");
                _username = value;
            }
        }

        /// <summary>
        /// The password of the user. This is stored as a plain string for simplicity.
        /// </summary>
        public string Password
        {
            get => _password;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Password cannot be empty.");
                if (value.Length < 6)
                    throw new ArgumentException("Password must be at least 6 characters long.");
                _password = value;
            }
        }

        /// <summary>
        /// The hashed version of the user's password.
        /// </summary>
        public string PasswordHash { get; private set; }

        /// <summary>
        /// Sets the password and generates a hash for it.
        /// </summary>
        /// <param name="password">The plain text password.</param>
        public void SetPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Password cannot be empty.");
            if (password.Length < 6)
                throw new ArgumentException("Password must be at least 6 characters long.");

            // Example hashing (use a secure library like BCrypt in production)
            PasswordHash = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
        }

        /// <summary>
        /// Verifies if the provided password matches the stored hash.
        /// </summary>
        /// <param name="password">The plain text password to verify.</param>
        /// <returns>True if the password matches, otherwise false.</returns>
        public bool VerifyPassword(string password)
        {
            return PasswordHash == Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
        }

        /// <summary>
        /// Returns a string representation of the user.
        /// </summary>
        /// <returns>A string containing the user's ID and username.</returns>
        public override string ToString()
        {
            return $"UserId: {UserId}, Username: {Username}";
        }
    }
}