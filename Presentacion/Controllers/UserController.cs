using Domain.Services;
using Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentacion.Models;
using Presentacion.Models.ViewModel;
using System.Diagnostics;

namespace Presentacion.Controllers
{
    
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {

            IQueryable<User> users = await _userService.GetAll();

            List<UserVM> lista = users
                        .Select(c => new UserVM()
                        {
                            Id = c.Id,
                            Name = c.Name,
                            LastName = c.LastName,
                            Email = c.Email,
                            Phone = c.Phone
                        }).ToList();

            return StatusCode(StatusCodes.Status200OK, lista);

        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] UserVM request)
        {

            User NewUser = new User()
            {
                Name = request.Name,
                LastName = request.LastName,
                Email = request.Email,
                Phone = request.Phone
            };

            bool respuesta = await _userService.Insert(NewUser);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });

        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UserVM request)
        {

            User NewUser = new User()
            {
                Id = request.Id,
                Name = request.Name,
                LastName = request.LastName,
                Email = request.Email,
                Phone = request.Phone
            };

            bool respuesta = await _userService.Update(NewUser);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });

        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {

            bool respuesta = await _userService.Delete(id);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
