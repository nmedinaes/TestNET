using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestNET.Aplicacion.Repository;
using TestNET.Aplicacion.Repository.Interface;
using TestNET.Dominio.DTO;
using TestNET.Dominio.Entities;
using TestNET.Infraestructura.Persistence;

namespace TestNet.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstudianteController : ControllerBase
    {
        private readonly IEstudianteRepository _estudianteRepository;

        public EstudianteController(TestDbContext db)
        {
            _estudianteRepository = new EstudianteRepository(db);
        }

        [HttpGet]
        public async Task<List<EstudianteResponse>> GetAll()
        {
            try
            {
                return _estudianteRepository.GetAll();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<EstudianteResponse> GetById(int Id)
        {
            try
            {
                return _estudianteRepository.GetById(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("Save")]
        public async Task<EstudianteResponse> Save(Estudiante estudiante)
        {
            try
            {
                return _estudianteRepository.Save(estudiante);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        [Route("Update")]
        public async Task<EstudianteResponse> Update(Estudiante estudiante)
        {
            try
            {
                return _estudianteRepository.Update(estudiante);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<EstudianteResponse> Delete(Estudiante estudiante)
        {
            try
            {
                return _estudianteRepository.Delete(estudiante);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
