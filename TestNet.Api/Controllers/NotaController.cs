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
    public class NotaController : ControllerBase
    {
        private readonly INotaRepository _notaRepository;

        public NotaController(TestDbContext db)
        {
            _notaRepository = new NotaRepository(db);
        }

        [HttpGet]
        public async Task<List<NotaResponse>> GetAll()
        {
            try
            {
                return _notaRepository.GetAll();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<NotaResponse> GetById(int Id)
        {
            try
            {
                return _notaRepository.GetById(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("Save")]
        public async Task<NotaResponse> Save(Nota nota)
        {
            try
            {
                return _notaRepository.Save(nota);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        [Route("Update")]
        public async Task<NotaResponse> Update(Nota nota)
        {
            try
            {
                return _notaRepository.Update(nota);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<NotaResponse> Delete(Nota nota)
        {
            try
            {
                return _notaRepository.Delete(nota);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
