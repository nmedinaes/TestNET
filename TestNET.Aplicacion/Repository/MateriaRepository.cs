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
    public class MateriaRepository : IMateriaRepository
    {
        public readonly TestDbContext db = null;

        public MateriaRepository(TestDbContext _db)
        {
            db = _db;
        }

        public List<MateriaResponse> GetAll()
        {
            var materias = db.Materias.Where(x => x.Activo == true).ToList();
            return MapperMateria(materias);
        }

        public MateriaResponse GetById(int Id)
        {
            var materia = db.Materias.Where(x => x.Id == Id).FirstOrDefault();
            return MapperMateria(materia);
        }

        public MateriaResponse Save(Materia materia)
        {
            var existMateria = db.Materias.Where(x => x.Nombre.Equals(materia.Nombre) && x.CursoId.Equals(materia.CursoId)).FirstOrDefault();

            if (existMateria == null)
            {
                db.Materias.Add(materia);
                db.SaveChanges();
            }

            return MapperMateria(materia);
        }

        public MateriaResponse Update(Materia materia)
        {
            var existMateria = db.Materias.Where(x => x.Id == materia.Id).FirstOrDefault();

            if (existMateria != null)
            {
                existMateria.Nombre = materia.Nombre;
                existMateria.Descripcion = materia.Descripcion;
                existMateria.Semestre = materia.Semestre;
                existMateria.ProfesorId = materia.ProfesorId;
                existMateria.CursoId = materia.CursoId;
                existMateria.Activo = materia.Activo;
                db.SaveChanges();
            }

            return MapperMateria(materia);
        }

        public MateriaResponse Delete(Materia materia)
        {
            var existMateria = db.Materias.Where(x => x.Id == materia.Id).FirstOrDefault();

            if (existMateria != null)
            {
                db.Materias.Remove(existMateria);
                db.SaveChanges();
            }

            return MapperMateria(materia);
        }

        private MateriaResponse MapperMateria(Materia materia)
        {
            return new MateriaResponse
            {
                Nombre = materia.Nombre,
                Descripcion = materia.Descripcion,
                Semestre = materia.Semestre,
                ProfesorId = materia.ProfesorId,
                CursoId = materia.CursoId,
                Activo = materia.Activo
            };
        }

        private List<MateriaResponse> MapperMateria(List<Materia> materias)
        {
            var listMaterias = new List<MateriaResponse>();

            foreach(var item in materias)
            {
                listMaterias.Add(MapperMateria(item));
            }

            return listMaterias;
        }
    }
}
