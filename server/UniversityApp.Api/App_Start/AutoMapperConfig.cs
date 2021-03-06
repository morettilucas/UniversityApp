﻿using AutoMapper;
using UniversityApp.Api.Models;
using UniversityApp.DB;
using UniversityApp.Model;

namespace UniversityApp.Api
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<Alumno, AlumnoDTO>().ReverseMap();
                config.CreateMap<Asignatura, AsignaturaDTO>().ReverseMap();
                config.CreateMap<Curso, CursoDTO>().ReverseMap();
                config.CreateMap<EstadoAcademico, EstadoAcademicoDTO>().ReverseMap();
            });
        }
    }
}