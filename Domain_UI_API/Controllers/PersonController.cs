using Domain_DataBase.Domain_Entity;
using Domain_DataBase.Domain_UnitOfWork;
using Domain_DTO.Request.PersonRequest;
using Domain_DTO.Response.PersonResponse;
using Domain_Servies.Domain_IServices;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Domain_UI_API.Controllers
{
    [ApiController]
    [Route("Person")]
    public class PersonController : BaseController
    {
        private readonly IPersonServices _person;
        private readonly IUnitOfWork _unit;

        public PersonController(IPersonServices person, IUnitOfWork unit)
        {
            _person = person;
            _unit = unit;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(new PersonGetAllResponse().Map(await _person.GetAll()));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] PersonAddRequest request)
        {
            Person person = request.Map(request);

            try
            {
                var response = await _person.CreateAsync(person, request.personimageurl);
                await _unit.CommitTranssections();
                return Ok(response);
            }
            catch (Exception ex)
            {
                await _unit.RollbackTranssections();
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{personId}")]
        public async Task<IActionResult> GetById(long personId)
        {
            var response = await _person.GetByIdAsync(personId);

            return Ok(new PersonGetByIdResponse().Map(response));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] PersonUpdateRequest request)
        {
           
            Person person = request.Map(request);

            try
            {
                var response = await _person.UpdateAsync(person,request.personmageurl);
                await _unit.CommitTranssections();

                return Ok(new { id = response });
            }
            catch (Exception ex)
            {
                await _unit.RollbackTranssections();

                return BadRequest(new { error = new { status = 400, message = ex.Message } });
            }
        }

        [HttpDelete("{personId}")]
        public async Task<IActionResult> Delete(long personId)
        {
            try
            {
                var response = await _person.GetByIdAsync(personId);

                await _person.DeleteAsync(response);
                await _unit.CommitTranssections();

                return Ok(new { id = response });
            }
            catch (Exception ex)
            {
                await _unit.RollbackTranssections();

                return BadRequest(new { error = new { status = 400, message = ex.Message } });
            }


        }
    }
}