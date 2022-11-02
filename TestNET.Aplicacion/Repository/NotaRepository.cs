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
    public class NotaRepository : INotaRepository
    {
        public readonly TestDbContext db = null;

        public NotaRepository(TestDbContext _db)
        {
            db = _db;
        }

        public List<NotaResponse> GetAll()
        {
            var notas = db.Notas.Where(x => x.Activo == true).ToList();
            return MapperNota(notas);
        }

        public NotaResponse GetById(int Id)
        {
            var nota = db.Notas.Where(x => x.Id == Id).FirstOrDefault();
            return MapperNota(nota);
        }

        public NotaResponse Save(Nota nota)
        {
            var existNota = db.Notas.Where(x => x.MateriaId.Equals(nota.MateriaId) && x.EstudianteId.Equals(nota.EstudianteId)).FirstOrDefault();

            if (existNota == null)
            {
                db.Notas.Add(nota);
                db.SaveChanges();
            }

            return MapperNota(nota);
        }

        public NotaResponse Update(Nota nota)
        {
            var existNota = db.Notas.Where(x => x.Id == nota.Id).FirstOrDefault();

            if (existNota != null)
            {
                existNota.TotalNota = nota.TotalNota;
                existNota.Descripcion = nota.Descripcion;
                existNota.MateriaId = nota.MateriaId;
                existNota.EstudianteId = nota.EstudianteId;
                existNota.Activo = nota.Activo;
                db.SaveChanges();
            }

            return MapperNota(nota);
        }

        public NotaResponse Delete(Nota nota)
        {
            var existNota = db.Notas.Where(x => x.Id == nota.Id).FirstOrDefault();

            if (existNota != null)
            {
                db.Notas.Remove(existNota);
                db.SaveChanges();
            }

            return MapperNota(nota);
        }

        private NotaResponse MapperNota(Nota nota)
        {
            return new NotaResponse
            {
                TotalNota = nota.TotalNota,
                Descripcion = nota.Descripcion,
                MateriaId = nota.MateriaId,
                EstudianteId = nota.EstudianteId,
                Activo = nota.Activo
            };
        }

        private List<NotaResponse> MapperNota(List<Nota> notas)
        {
            var listNotas = new List<NotaResponse>();

            foreach(var item in notas)
            {
                listNotas.Add(MapperNota(item));
            }

            return listNotas;
        }
    }
}
