using System;

namespace Model
{
    public class User
    {

        #region ATRIBUTOS
        private int idUser;
        private String email;
        private String password;
        private String token;
        private bool status;
        private Role role;
        #endregion

        public User() { }

        public User(int idUser, string email, string password, string token, bool status, Role role)
        {
            this.IdUser = idUser;
            this.email = email;
            this.password = password;
            this.token = token;
            this.status = status;
            this.role = role;
        }

        public int IdUser { get => idUser; set => idUser = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string Token { get => token; set => token = value; }
        public bool Status { get => status; set => status = value; }
        public Role Role { get => role; set => role = value; }

    }
}
