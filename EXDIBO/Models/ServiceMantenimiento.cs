using EXDIBO.Util;
using EXDIBO.Data;

namespace EXDIBO.Models

{
    public class ServiceMantenimiento
    {

        public bool StatusIlness(int Id, bool Status)        
        {
            return new RepositoryMantenimiento().StatusIlness( Id, Status);
        }

    }
}
