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
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] TratamientoVM request)
        {

            Tratamiento NewTratamiento = new Tratamiento()
            {
                Tipo = request.Tipo,
                Medicamento = request.Medicamento,
                Descripcion = request.Descripcion,
                IdUser = request.IdUser
            };
           
            //var users = ListarUsuario();

            var respuesta = await _tratamientoService.Insert(NewTratamiento);

            return Ok(respuesta);

            //return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });

        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] TratamientoVM request)
        {

            Tratamiento NewUser = new Tratamiento()
            {
                IdTratamiento= request.IdTratamiento,
                Tipo = request.Tipo,
                Medicamento = request.Medicamento,
                Descripcion = request.Descripcion,
                IdUser = request.IdUser
            };

            var respuesta = await _tratamientoService.Update(NewUser);
            return Ok(respuesta);

            //return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });

        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {

            bool respuesta = await _tratamientoService.Delete(id);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });

        }
        [HttpGet]
        public IActionResult ListarUsuario()
        {
            return Json(_usertoService.GetAll());

        }
    }
}
