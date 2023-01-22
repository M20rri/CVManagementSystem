using CoreApiResponse;
using CVManagementSystem.Dto;
using CVManagementSystem.Features.ExperienceInformation.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CVManagementSystem.Controllers
{
    [Route("api/experience-information")]
    [ApiController]
    public class ExperienceInformationController : BaseController
    {
        private readonly ISender _iSender;
        public ExperienceInformationController(ISender iSender)
        {
            _iSender = iSender;
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _iSender.Send(new GetSinglExperienceInformationQuery(id));
            return CustomResult(result, HttpStatusCode.OK);
        }


        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync(ExperienceInformationDto model)
        {
            var item = await _iSender.Send(new CreatExperienceInformationQuery(model));
            return CustomResult("Saved Sucesfully", item, HttpStatusCode.OK);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync(ExperienceInformationDto model)
        {
            var item = await _iSender.Send(new UpdatExperienceInformationQuery(model));
            return CustomResult("Updated Succesfully", item, HttpStatusCode.OK);
        }
    }
}
