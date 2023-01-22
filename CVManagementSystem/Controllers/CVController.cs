using Azure.Core;
using CoreApiResponse;
using CVManagementSystem.Context;
using CVManagementSystem.Dto;
using CVManagementSystem.Exceptions;
using CVManagementSystem.Features.CV.Query;
using CVManagementSystem.Features.ExperienceInformation.Query;
using CVManagementSystem.Features.PersonalInformation.Query;
using CVManagementSystem.Validations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using System.Net;

namespace CVManagementSystem.Controllers
{
    [Route("api/cv")]
    [ApiController]
    public class CVController : BaseController
    {
        private readonly ISender _iSender;
        private readonly CVContext _ctx;
        public CVController(ISender iSender, CVContext ctx)
        {
            _iSender = iSender;
            _ctx = ctx;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _iSender.Send(new GetAllCVQuery());
            return CustomResult(result, HttpStatusCode.OK);
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _iSender.Send(new GetSinglCVQuery(id));
            return CustomResult(result, HttpStatusCode.OK);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync(CVDtoPage model)
        {
            CVValidator validationRules = new CVValidator();
            var result = await validationRules.ValidateAsync(model);
            if (result.Errors.Any())
            {
                var Errors = result.Errors.Select(x => x.ErrorMessage).ToList();
                throw new ValidationException(Errors, (int)HttpStatusCode.BadRequest);
            }

            var cvItem = new CVDto { Name = model.Name };

            cvItem.Experience_Information_Id = await _iSender.Send(new CreatExperienceInformationQuery(model.Experience_Information));
            cvItem.Personal_Information_Id = await _iSender.Send(new CreatPersonalInformationQuery(model.Personal_Information));


            var item = await _iSender.Send(new CreatCVQuery(cvItem));
            return CustomResult("Saved Sucesfully", item, HttpStatusCode.OK);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var item = await _iSender.Send(new DeleteCVQuery(id));
            return CustomResult(item, HttpStatusCode.OK);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync(CVDtoPage model)
        {
            CVValidator validationRules = new CVValidator();
            var result = await validationRules.ValidateAsync(model);
            if (result.Errors.Any())
            {
                var Errors = result.Errors.Select(x => x.ErrorMessage).ToList();
                throw new ValidationException(Errors, (int)HttpStatusCode.BadRequest);
            }

            var cvItem = new CVDto { Name = model.Name , Id = model.Id };

            cvItem.Experience_Information_Id = await _iSender.Send(new UpdatExperienceInformationQuery(model.Experience_Information));
            cvItem.Personal_Information_Id = await _iSender.Send(new UpdatPersonalInformationQuery(model.Personal_Information));



            var item = await _iSender.Send(new UpdatCVQuery(cvItem));
            return CustomResult("Updated Succesfully", item, HttpStatusCode.OK);
        }
    }
}
