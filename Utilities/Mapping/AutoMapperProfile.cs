using AutoMapper;
using ColegioApp.Entity.DTOs;
using ColegioApp.Entity.Models;

namespace ColegioApp.Utilities.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // ============================
            //  ESTUDIANTE
            // ============================
            CreateMap<Estudiante, EstudianteDto>().ReverseMap();

            // ============================
            //  PROFESOR
            // ============================
            CreateMap<Profesor, ProfesorDto>().ReverseMap();

            // ============================
            //  MATERIA
            // ============================
            CreateMap<Materia, MateriaDto>().ReverseMap();

            // ============================
            //  PERIODO
            // ============================
            CreateMap<Periodo, PeriodoDto>().ReverseMap();

            // ============================
            //  CURSO
            // ============================
            CreateMap<Curso, CursoDto>().ReverseMap();

            // ============================
            //  NOTA
            // ============================
            CreateMap<Nota, NotaDto>().ReverseMap();
        }
    }
}
