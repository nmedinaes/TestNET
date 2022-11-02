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
    public class CursoController : ControllerBase
    {
        private readonly ICursoRepository _cursoRepository;

        public CursoController(TestDbContext db)
        {
            _cursoRepository = new CursoRepository(db);
        }

        [HttpGet]
        public async Task<List<CursoResponse>> GetAll()
        {
            try
            {
                return _cursoRepository.GetAll();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<CursoResponse> GetById(int Id)
        {
            try
            {
                return _cursoRepository.GetById(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("Save")]
        public async Task<CursoResponse> Save(Curso curso)
        {
            try
            {
                return _cursoRepository.Save(curso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        [Route("Update")]
        public async Task<CursoResponse> Update(Curso curso)
        {
            try
            {
                return _cursoRepository.Update(curso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<CursoResponse> Delete(Curso curso)
        {
            try
            {
                return _cursoRepository.Delete(curso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
