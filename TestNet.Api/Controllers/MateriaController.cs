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
    public class MateriaController : ControllerBase
    {
        private readonly IMateriaRepository _materiaRepository;

        public MateriaController(TestDbContext db)
        {
            _materiaRepository = new MateriaRepository(db);
        }

        [HttpGet]
        public async Task<List<MateriaResponse>> GetAll()
        {
            try
            {
                return _materiaRepository.GetAll();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<MateriaResponse> GetById(int Id)
        {
            try
            {
                return _materiaRepository.GetById(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("Save")]
        public async Task<MateriaResponse> Save(Materia materia)
        {
            try
            {
                return _materiaRepository.Save(materia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        [Route("Update")]
        public async Task<MateriaResponse> Update(Materia materia)
        {
            try
            {
                return _materiaRepository.Update(materia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<MateriaResponse> Delete(Materia materia)
        {
            try
            {
                return _materiaRepository.Delete(materia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
