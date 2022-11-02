using System;
using System.Collections.Generic;
using System.Text;
using TestNET.Dominio.DTO;
using TestNET.Dominio.Entities;

namespace TestNET.Aplicacion.Repository.Interface
{
    public interface ICursoRepository
    {
        public List<CursoResponse> GetAll();
        public CursoResponse GetById(int Id);
        public CursoResponse Save(Curso cruso);
        public CursoResponse Update(Curso curso);
        public CursoResponse Delete(Curso curso);
    }
}
