using System;
using System.Collections.Generic;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using ShoeService.BL.Interfaces;
using ShoeService.Models.Dto;
using ShoeService.Models.Entities;

namespace ShoeService.Host.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShoeController : ControllerBase
    {
        private readonly ICustomerCrudService _shoeService;

        public ShoeController(ICustomerCrudService shoeService)
        {
            _shoeService = shoeService;
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var result = _shoeService.GetAllCustomers();
            var mapped = result.Adapt<List<ShoeDto>>();
            return Ok(mapped);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var shoe = _shoeService.GetById(id);
            if (shoe == null)
                return NotFound("Shoe not found");

            var mapped = shoe.Adapt<ShoeDto>();
            return Ok(mapped);
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] Shoe shoe)
        {
            _shoeService.AddCustomer(shoe);
            return Ok("Shoe added successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _shoeService.DeleteCustomer(id);
            return Ok("Shoe deleted successfully");
        }
    }
}
