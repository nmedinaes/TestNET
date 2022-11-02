using System;
using System.Collections.Generic;
using System.Text;
using TestNET.Dominio.DTO;
using TestNET.Dominio.Entities;

namespace TestNET.Aplicacion.Repository.Interface
{
    public interface IMateriaRepository
    {
        public List<MateriaResponse> GetAll();
        public MateriaResponse GetById(int Id);
        public MateriaResponse Save(Materia cruso);
        public MateriaResponse Update(Materia curso);
        public MateriaResponse Delete(Materia curso);
    }
}
