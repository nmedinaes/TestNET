using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestNET.Aplicacion.Repository.Interface;
using TestNET.Dominio.DTO;
using TestNET.Dominio.Entities;
using TestNET.Infraestructura.Persistence;

namespace TestNET.Aplicacion.Repository
{
    public class CursoRepository : ICursoRepository
    {
        public readonly TestDbContext db = null;

        public CursoRepository(TestDbContext _db)
        {
            db = _db;
        }

        public List<CursoResponse> GetAll()
        {
            var cursos = db.Cursos.Where(x => x.Activo == true).ToList();
            return MapperCurso(cursos);
        }

        public CursoResponse GetById(int Id)
        {
            var curso = db.Cursos.Where(x => x.Id == Id).FirstOrDefault();
            return MapperCurso(curso);
        }

        public CursoResponse Save(Curso curso)
        {
            var existCurso = db.Cursos.Where(x => x.Nombre.Equals(curso.Nombre)).FirstOrDefault();

            if (existCurso == null)
            {
                db.Cursos.Add(curso);
                db.SaveChanges();
            }

            return MapperCurso(curso);
        }

        public CursoResponse Update(Curso curso)
        {
            var existCurso = db.Cursos.Where(x => x.Id == curso.Id).FirstOrDefault();

            if (existCurso != null)
            {
                existCurso.Nombre = curso.Nombre;
                existCurso.Descripcion = curso.Descripcion;
                existCurso.Activo = curso.Activo;
                db.SaveChanges();
            }

            return MapperCurso(curso);
        }

        public CursoResponse Delete(Curso curso)
        {
            var existCurso = db.Cursos.Where(x => x.Id == curso.Id).FirstOrDefault();

            if (existCurso != null)
            {
                db.Cursos.Remove(existCurso);
                db.SaveChanges();
            }

            return MapperCurso(curso);
        }

        private CursoResponse MapperCurso(Curso curso)
        {
            return new CursoResponse
            {
                Nombre = curso.Nombre,
                Descripcion = curso.Descripcion,
                Activo = curso.Activo
            };
        }

        private List<CursoResponse> MapperCurso(List<Curso> cursos)
        {
            var listCursos = new List<CursoResponse>();

            foreach(var item in cursos)
            {
                listCursos.Add(MapperCurso(item));
            }

            return listCursos;
        }
    }
}
