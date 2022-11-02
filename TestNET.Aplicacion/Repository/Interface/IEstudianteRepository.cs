using System;
using System.Collections.Generic;
using System.Text;
using TestNET.Dominio.DTO;
using TestNET.Dominio.Entities;

namespace TestNET.Aplicacion.Repository.Interface
{
    public interface IEstudianteRepository
    {
        public List<EstudianteResponse> GetAll();
        public EstudianteResponse GetById(int Id);
        public EstudianteResponse Save(Estudiante cruso);
        public EstudianteResponse Update(Estudiante curso);
        public EstudianteResponse Delete(Estudiante curso);
    }
}
