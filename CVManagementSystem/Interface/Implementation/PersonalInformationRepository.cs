using AutoMapper;
using CVManagementSystem.Context;
using CVManagementSystem.Dto;
using CVManagementSystem.Exceptions;
using CVManagementSystem.Models;
using System.Net;

namespace CVManagementSystem.Interface.Implementation
{
    public class PersonalInformationRepository : IPersonalInformation
    {
        private readonly IMapper _mapper;
        private readonly CVContext _ctx;
        public PersonalInformationRepository(IMapper mapper, CVContext ctx)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<PersonalInformationDto> GetById(int id)
        {
            var item = await _ctx.PersonalInformations.FindAsync(id) ??
                              throw new ValidationException("Personal Information is not exist", (int)HttpStatusCode.BadRequest);

            return _mapper.Map<PersonalInformationDto>(item);
        }

        public async Task<int> Insert(PersonalInformationDto model)
        {
            var item = _mapper.Map<PersonalInformation>(model);
            await _ctx.PersonalInformations.AddAsync(item);
            await _ctx.SaveChangesAsync();

            return item.Id;
        }

        public async Task<int> Update(PersonalInformationDto model)
        {
            var item = await _ctx.PersonalInformations.FindAsync(model.Id) ??
                              throw new ValidationException("Personal Information is not exist", (int)HttpStatusCode.BadRequest);

            item.Id = model.Id;
            item.Fullname = model.Fullname;
            item.Cityname = model.Cityname;
            item.Email = model.Email;
            item.Mobile = model.Mobile;
            await _ctx.SaveChangesAsync();

            return item.Id;
        }
    }
}
