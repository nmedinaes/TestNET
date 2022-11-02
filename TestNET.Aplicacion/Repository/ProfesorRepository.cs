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
    public class ProfesorRepository : IProfesorRepository
    {
        public readonly TestDbContext db = null;

        public ProfesorRepository(TestDbContext _db)
        {
            db = _db;
        }

        public List<ProfesorResponse> GetAll()
        {
            var profesores = db.Profesores.Where(x => x.Activo == true).ToList();
            return MapperProfesor(profesores);
        }

        public ProfesorResponse GetById(int Id)
        {
            var profesor = db.Profesores.Where(x => x.Id == Id).FirstOrDefault();
            return MapperProfesor(profesor);
        }

        public ProfesorResponse Save(Profesor profesor)
        {
            var existProfesor = db.Profesores.Where(x => x.Cedula.Equals(profesor.Cedula)).FirstOrDefault();

            if (existProfesor == null)
            {
                db.Profesores.Add(profesor);
                db.SaveChanges();
            }

            return MapperProfesor(profesor);
        }

        public ProfesorResponse Update(Profesor profesor)
        {
            var existProfesor = db.Profesores.Where(x => x.Id == profesor.Id).FirstOrDefault();

            if (existProfesor != null)
            {
                existProfesor.Cedula = profesor.Cedula;
                existProfesor.Nombres = profesor.Nombres;
                existProfesor.Apellidos = profesor.Apellidos;
                existProfesor.Email = profesor.Email;
                existProfesor.Telefono = profesor.Telefono;
                existProfesor.Activo = profesor.Activo;
                db.SaveChanges();
            }

            return MapperProfesor(profesor);
        }

        public ProfesorResponse Delete(Profesor profesor)
        {
            var existProfesor = db.Profesores.Where(x => x.Id == profesor.Id).FirstOrDefault();

            if (existProfesor != null)
            {
                db.Profesores.Remove(existProfesor);
                db.SaveChanges();
            }

            return MapperProfesor(profesor);
        }

        private ProfesorResponse MapperProfesor(Profesor profesor)
        {
            return new ProfesorResponse
            {
                Cedula = profesor.Cedula,
                Nombres = profesor.Nombres,
                Apellidos = profesor.Apellidos,
                Email = profesor.Email,
                Telefono = profesor.Telefono,
                Activo = profesor.Activo
            };
        }

        private List<ProfesorResponse> MapperProfesor(List<Profesor> profesors)
        {
            var listProfesors = new List<ProfesorResponse>();

            foreach(var item in profesors)
            {
                listProfesors.Add(MapperProfesor(item));
            }

            return listProfesors;
        }
    }
}
