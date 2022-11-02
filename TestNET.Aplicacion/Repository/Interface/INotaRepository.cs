using System;
using System.Collections.Generic;
using System.Text;
using TestNET.Dominio.DTO;
using TestNET.Dominio.Entities;

namespace TestNET.Aplicacion.Repository.Interface
{
    public interface INotaRepository
    {
        public List<NotaResponse> GetAll();
        public NotaResponse GetById(int Id);
        public NotaResponse Save(Nota cruso);
        public NotaResponse Update(Nota curso);
        public NotaResponse Delete(Nota curso);
    }
}
