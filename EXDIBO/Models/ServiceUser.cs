using EXDIBO.Util;
using EXDIBO.Data;

namespace EXDIBO.Models
{
    public class ServiceUser : IServiceUser
    {
        public List<User> GetAllUsers()
        {
            return new RepositoryUser().GetAllUsers();
        }

        public User GetUserById(int IdUsuario)
        {
            return new RepositoryUser().GetUserById(IdUsuario);
        }

        public User GetValidateUser(string email, string password)
        {
            return new RepositoryUser().GetValidateUser(email, password);
        }

        public bool SaveUser(User oUser)
        {
            return new RepositoryUser().SaveUser(oUser);
        }

        public bool ChangeStatusUser(int Id,bool Status)
        {
            return new RepositoryUser().ChangeStatusUser(Id, Status);
        }

        public bool EditUser(User oUser) {
            return new RepositoryUser().EditUser(oUser);
        }
    }
}
