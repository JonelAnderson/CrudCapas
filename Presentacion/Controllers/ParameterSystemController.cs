using Domain.Logic;
using Microsoft.AspNetCore.Mvc;

namespace Presentacion.Controllers
{
    public class ParameterSystemController : Controller
    {
        private readonly LogicParameterSystem parametersLogic = new LogicParameterSystem();
        public IActionResult Index()
        {
            return View(parametersLogic.GetAllParametersSystem());
        }

        [HttpPost]
        public IActionResult Update(int id, string value, int state)
        {
            bool stateBool = true;
            if (state == 0)
            {
                stateBool = false;
            }
            parametersLogic.UpdateParametersSystem(id, value, stateBool);
            return RedirectToAction("Index");
        }
    }
}
