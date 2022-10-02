using DataAccess.DBContetx;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
   public class GenericParametersSystem : IParameterSystem
    {
        public bool UpdateStateParameter(int id, bool state)
        {
            bool confirmar = false;
            try
            {
                using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
                {
                    var result = context.ParameterSystems.SingleOrDefault(p => p.Id == id);
                    if (result != null)
                    {
                        result.State = state;
                        context.SaveChanges();
                        confirmar = true;
                    }
                }
            }
            catch (Exception error)
            {
                throw new DataException("Failed to insert data.", error);
            }
            return confirmar;
        }

        public bool UpdateParametersSystem(int id, string value, bool state)
        {
            bool confirmar = true;
            try
            {
                using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
                {
                    var result = context.ParameterSystems.SingleOrDefault(p => p.Id == id);
                    if (result != null)
                    {
                        result.Value = value;
                        result.State = state;
                        context.SaveChanges();
                    }
                    else
                    {
                        confirmar = false;
                    }
                }
            }
            catch (Exception error)
            {
                throw new DataException("Failed to insert data.", error);
            }
            return confirmar;
        }

        public ParameterSystem GetParametersSystemById(int id)
        {
            ParameterSystem NewParameter = new ParameterSystem();
            try
            {
                using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
                {
                    var result = context.ParameterSystems.SingleOrDefault(p => p.Id == id);
                    if (result != null)
                    {
                        NewParameter.Id = result.Id;
                        NewParameter.Type = result.Type;
                        NewParameter.Value = result.Value;
                        NewParameter.State = result.State;
                    }
                }
            }
            catch (Exception error)
            {
                throw new DataException("Failed to insert data.", error);
            }
            return NewParameter;
        }


        public List<ParameterSystem> GetAllParametersSystem()
        {
            List<ParameterSystem> parameters = new List<ParameterSystem>();
            try
            {
                using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
                {
                    parameters = context.ParameterSystems.ToList();
                }
            }
            catch (Exception error)
            {
                throw new DataException("Failed to insert data.", error);
            }
            return parameters;
        }
    }
}

