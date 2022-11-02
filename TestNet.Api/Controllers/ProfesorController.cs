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
    public class profesorController : ControllerBase
    {
        private readonly IProfesorRepository _profesorRepository;

        public profesorController(TestDbContext db)
        {
            _profesorRepository = new ProfesorRepository(db);
        }

        [HttpGet]
        public async Task<List<ProfesorResponse>> GetAll()
        {
            try
            {
                return _profesorRepository.GetAll();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<ProfesorResponse> GetById(int Id)
        {
            try
            {
                return _profesorRepository.GetById(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("Save")]
        public async Task<ProfesorResponse> Save(Profesor profesor)
        {
            try
            {
                return _profesorRepository.Save(profesor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        [Route("Update")]
        public async Task<ProfesorResponse> Update(Profesor profesor)
        {
            try
            {
                return _profesorRepository.Update(profesor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<ProfesorResponse> Delete(Profesor profesor)
        {
            try
            {
                return _profesorRepository.Delete(profesor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
