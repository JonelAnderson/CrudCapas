using Domain.Services;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using Presentacion.Models.ViewModel;

namespace Presentacion.Controllers
{
    public class TratamientoController : Controller
    {
        private readonly ITratamientoService _tratamientoService;
        private readonly IUserService _usertoService;

        public TratamientoController(ITratamientoService tratamientoService, IUserService usertoService)
        {
            _tratamientoService = tratamientoService;
            _usertoService = usertoService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
           

            IQueryable<Tratamiento> tratamientos = await _tratamientoService.GetAll();

            List<TratamientoVM> lista = tratamientos
                        .Select(c => new TratamientoVM()
                        {
                            IdTratamiento = c.IdTratamiento,
                            Tipo = c.Tipo,
                            Medicamento = c.Medicamento,
                            Descripcion = c.Descripcion,
                            IdUser = c.IdUser

                        }).ToList(); 

            return StatusCode(StatusCodes.Status200OK, lista);
        }

        [HttpGet]
        public IActionResult ListarUsuario()
        {
            return Json(_usertoService.GetAll());

        }
    }
}
