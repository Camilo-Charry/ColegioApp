using AutoMapper;
using ColegioApp.Data.Interfaces;
using ColegioApp.Entity.DTOs;
using ColegioApp.Entity.Models;

namespace ColegioApp.Business
{
    public class NotaService : BaseService<Nota, NotaDto>
    {
        public NotaService(IRepository<Nota> repository, IMapper mapper)
            : base(repository, mapper) { }
    }
}
