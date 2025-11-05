using AutoMapper;
using ColegioApp.Data.Interfaces;
using ColegioApp.Entity.DTOs;
using ColegioApp.Entity.Models;

namespace ColegioApp.Business
{
    public class PeriodoService : BaseService<Periodo, PeriodoDto>
    {
        public PeriodoService(IRepository<Periodo> repository, IMapper mapper)
            : base(repository, mapper) { }
    }
}
