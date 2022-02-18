using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Threading.Tasks;
using UnitOfWorkConVariosRepositorios.DA.UoW;
using UnitOfWorkConVariosRepositorios.Models;

namespace UnitOfWorkConVariosRepositorios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public ValuesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [SwaggerOperation("Update")]
        [Route("Update")]
        [HttpGet]
        public async Task<IActionResult> UpdateUsuario()
        {
            try
            {
                Persona persona = new Persona()
                {
                    Id = 1,
                    Nombre = "UnaPersona",
                    Telefono = "555555555"
                };

                await _unitOfWork.Personasrepository.Update(persona);
                await _unitOfWork.Commit();

                return Ok();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [SwaggerOperation("Nuevo")]
        [Route("NuevoUsuario")]
        [HttpGet]
        public async Task<IActionResult> NuevoUsuario()
        {
            try
            {
                Persona persona = new Persona()
                {
                    Nombre = "Eze",
                    Telefono = "123456"
                };

                Auto auto = new Auto()
                {
                    Marca = "Patanglen",
                    Modelo = "5 personas"
                };

                await _unitOfWork.Autosrepository.Insert(auto);
                await _unitOfWork.Personasrepository.Insert(persona);
                await _unitOfWork.Commit();

                return Ok();

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
