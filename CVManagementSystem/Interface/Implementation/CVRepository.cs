using AutoMapper;
using CVManagementSystem.Context;
using CVManagementSystem.Dto;
using CVManagementSystem.Exceptions;
using CVManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace CVManagementSystem.Interface.Implementation
{
    public class CVRepository : ICV
    {
        private readonly IMapper _mapper;
        private readonly CVContext _ctx;
        public CVRepository(IMapper mapper, CVContext ctx)
        {
            _ctx = ctx;
            _mapper = mapper;
        }
        public async Task<int> Delete(int id)
        {
            var item = await _ctx.CVs.FindAsync(id) ??
                               throw new ValidationException("CV is not exist", (int)HttpStatusCode.BadRequest);

            _ctx.CVs.Remove(item);
            await _ctx.SaveChangesAsync();

            return item.Id;
        }

        public async Task<List<CVDto>> GetAll()
        {
            var items = await _ctx.CVs.ToListAsync();
            return _mapper.Map<List<CVDto>>(items);
        }

        public async Task<CVDtoPage> GetById(int id)
        {
            var item = await _ctx.CVs.Where(a => a.Id == id).Select(r => new CVDtoPage
            {
                Id = r.Id,
                Name = r.Name,
                Experience_Information_Id = r.Experience_Information_Id,
                Personal_Information_Id = r.Personal_Information_Id,
                Experience_Information = new ExperienceInformationDto
                {
                    Id = r.Experience_Information.Id,
                    City = r.Experience_Information.City,
                    CompanyField = r.Experience_Information.CompanyField,
                    CompanyName = r.Experience_Information.CompanyName
                },
                Personal_Information = new PersonalInformationDto
                {
                    Id= r.Personal_Information.Id,
                    Cityname= r.Personal_Information.Cityname,
                    Email= r.Personal_Information.Email,
                    Fullname = r.Personal_Information.Fullname ,
                    Mobile = r.Personal_Information.Mobile
                }
            }).FirstOrDefaultAsync();

            return _mapper.Map<CVDtoPage>(item);
        }

        public async Task<int> Insert(CVDto model)
        {
            var item = _mapper.Map<CV>(model);
            await _ctx.CVs.AddAsync(item);
            await _ctx.SaveChangesAsync();

            return item.Id;
        }

        public async Task<int> Update(CVDto model)
        {
            var item = await _ctx.CVs.FindAsync(model.Id) ??
                              throw new ValidationException("CV is not exist", (int)HttpStatusCode.BadRequest);

            item.Id = model.Id;
            item.Name = model.Name;
            item.Personal_Information_Id = model.Personal_Information_Id;
            item.Experience_Information_Id = model.Experience_Information_Id;
            await _ctx.SaveChangesAsync();

            return item.Id;
        }
    }
}
