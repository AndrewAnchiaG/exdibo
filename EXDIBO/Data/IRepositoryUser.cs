using EXDIBO.Util;

namespace EXDIBO.Data
{
    public interface IRepositoryUser
    {
        public List<User> GetAllUsers();

        public User GetUserById(int IdUser);

        public User GetValidateUser(string email, string password);

        public bool SaveUser(User oUser);

        public bool EditUser(User oUser);

        public bool ChangeStatusUser(int IdUsuario, bool status);
    }
}
