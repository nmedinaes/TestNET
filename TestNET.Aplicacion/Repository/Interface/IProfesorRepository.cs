using System;
using System.Collections.Generic;
using System.Text;
using TestNET.Dominio.DTO;
using TestNET.Dominio.Entities;

namespace TestNET.Aplicacion.Repository.Interface
{
    public interface IProfesorRepository
    {
        public List<ProfesorResponse> GetAll();
        public ProfesorResponse GetById(int Id);
        public ProfesorResponse Save(Profesor cruso);
        public ProfesorResponse Update(Profesor curso);
        public ProfesorResponse Delete(Profesor curso);
    }
}
