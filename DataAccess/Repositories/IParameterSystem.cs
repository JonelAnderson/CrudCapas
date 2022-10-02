using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
   public interface IParameterSystem
    {
        bool UpdateParametersSystem(int id, string value, bool state);
        bool UpdateStateParameter(int id, bool state);
        ParameterSystem GetParametersSystemById(int id);
        List<ParameterSystem> GetAllParametersSystem();
    }
}
