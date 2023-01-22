using AutoMapper;
using CVManagementSystem.Context;
using CVManagementSystem.Dto;
using CVManagementSystem.Exceptions;
using CVManagementSystem.Models;
using System.Net;

namespace CVManagementSystem.Interface.Implementation
{
    public class ExperienceInformationRepository : IExperienceInformation
    {
        private readonly IMapper _mapper;
        private readonly CVContext _ctx;
        public ExperienceInformationRepository(IMapper mapper, CVContext ctx)
        {
            _ctx = ctx;
            _mapper = mapper;
        }
        public async Task<ExperienceInformationDto> GetById(int id)
        {
            var item = await _ctx.ExperienceInformations.FindAsync(id) ??
                              throw new ValidationException("Experience Information is not exist", (int)HttpStatusCode.BadRequest);

            return _mapper.Map<ExperienceInformationDto>(item);
        }

        public async Task<int> Insert(ExperienceInformationDto model)
        {
            var item = _mapper.Map<ExperienceInformation>(model);
            await _ctx.ExperienceInformations.AddAsync(item);
            await _ctx.SaveChangesAsync();

            return item.Id;
        }

        public async Task<int> Update(ExperienceInformationDto model)
        {
            var item = await _ctx.ExperienceInformations.FindAsync(model.Id) ??
                              throw new ValidationException("Experience Information is not exist", (int)HttpStatusCode.BadRequest);

            item.Id = model.Id;
            item.City = model.City;
            item.CompanyName = model.CompanyName;
            item.CompanyField = model.CompanyField;
            await _ctx.SaveChangesAsync();

            return item.Id;
        }
    }
}
