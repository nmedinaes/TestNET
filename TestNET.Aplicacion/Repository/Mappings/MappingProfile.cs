using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TestNET.Dominio.DTO;
using TestNET.Dominio.Entities;

namespace TestNET.Aplicacion.Repository.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CursoResponse, Curso>();
        }
    }
}
