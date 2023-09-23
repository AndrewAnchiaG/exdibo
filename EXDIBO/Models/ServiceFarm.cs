using EXDIBO.Data;
using EXDIBO.Util;  

namespace EXDIBO.Models
{
    public class ServiceFarm
    {

        public List<Farm> GetAllFarm()
        {
            return new RepositoryFarm().GetAllFarm(); 
        }

        public List<Group> GetAllGroup()
        {
            return new RepositoryFarm().GetAllGroup();
        }
    }
}
