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
    public class EstudianteRepository : IEstudianteRepository
    {
        public readonly TestDbContext db = null;

        public EstudianteRepository(TestDbContext _db)
        {
            db = _db;
        }

        public List<EstudianteResponse> GetAll()
        {
            var estudiantes = db.Estudiantes.Where(x => x.Activo == true).ToList();
            return MapperEstudiante(estudiantes);
        }

        public EstudianteResponse GetById(int Id)
        {
            var estudiante = db.Estudiantes.Where(x => x.Id == Id).FirstOrDefault();
            return MapperEstudiante(estudiante);
        }

        public EstudianteResponse Save(Estudiante estudiante)
        {
            var existEstudiante = db.Estudiantes.Where(x => x.Cedula.Equals(estudiante.Cedula)).FirstOrDefault();

            if (existEstudiante == null)
            {
                db.Estudiantes.Add(estudiante);
                db.SaveChanges();
            }

            return MapperEstudiante(estudiante);
        }

        public EstudianteResponse Update(Estudiante estudiante)
        {
            var existEstudiante = db.Estudiantes.Where(x => x.Id == estudiante.Id).FirstOrDefault();

            if (existEstudiante != null)
            {
                existEstudiante.Cedula = estudiante.Cedula;
                existEstudiante.Nombres = estudiante.Nombres;
                existEstudiante.Apellidos = estudiante.Apellidos;
                existEstudiante.Email = estudiante.Email;
                existEstudiante.Telefono = estudiante.Telefono;
                existEstudiante.CursoId = estudiante.CursoId;
                existEstudiante.Activo = estudiante.Activo;
                db.SaveChanges();
            }

            return MapperEstudiante(estudiante);
        }

        public EstudianteResponse Delete(Estudiante estudiante)
        {
            var existEstudiante = db.Estudiantes.Where(x => x.Id == estudiante.Id).FirstOrDefault();

            if (existEstudiante != null)
            {
                db.Estudiantes.Remove(existEstudiante);
                db.SaveChanges();
            }

            return MapperEstudiante(estudiante);
        }

        private EstudianteResponse MapperEstudiante(Estudiante estudiante)
        {
            return new EstudianteResponse
            {
                Cedula = estudiante.Cedula,
                Nombres = estudiante.Nombres,
                Apellidos = estudiante.Apellidos,
                Email = estudiante.Email,
                Telefono = estudiante.Telefono,
                CursoId = estudiante.CursoId,
                Activo = estudiante.Activo
            };
        }

        private List<EstudianteResponse> MapperEstudiante(List<Estudiante> estudiantes)
        {
            var listEstudiantes = new List<EstudianteResponse>();

            foreach(var item in estudiantes)
            {
                listEstudiantes.Add(MapperEstudiante(item));
            }

            return listEstudiantes;
        }
    }
}
