using CoreApiResponse;
using CVManagementSystem.Dto;
using CVManagementSystem.Features.PersonalInformation.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CVManagementSystem.Controllers
{
    [Route("api/personal-information")]
    [ApiController]
    public class PersonalInformationController : BaseController
    {
        private readonly ISender _iSender;
        public PersonalInformationController(ISender iSender)
        {
            _iSender = iSender;
        }


        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _iSender.Send(new GetSinglPersonalInformationQuery(id));
            return CustomResult(result, HttpStatusCode.OK);
        }


        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync(PersonalInformationDto model)
        {
            var item = await _iSender.Send(new CreatPersonalInformationQuery(model));
            return CustomResult("Saved Sucesfully", item, HttpStatusCode.OK);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync(PersonalInformationDto model)
        {
            var item = await _iSender.Send(new CreatPersonalInformationQuery(model));
            return CustomResult("Updated Succesfully", item, HttpStatusCode.OK);
        }
    }
}
