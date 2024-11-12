using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Prova.MarQ.API.DTOs;
using Prova.MarQ.Domain.Entities;
using Prova.MarQ.Domain.Services.Interfaces;

namespace Prova.MarQ.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyDTO>>> GetAllAsync()
        {
            var companies = await _companyService.GetAllAsync();
            var companiesDTO = _mapper.Map<IEnumerable<CompanyDTO>>(companies);
            return Ok(companiesDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyDTO>> GetByIdAsync(Guid id)
        {
            var company = await _companyService.GetByIdAsync(id);
            if (company == null)
                return NotFound();

            var companyDTO = _mapper.Map<CompanyDTO>(company);
            return Ok(companyDTO);
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync(CompanyDTO companyDTO)
        {
            var company = _mapper.Map<Company>(companyDTO);
            await _companyService.AddAsync(company);
            return CreatedAtAction(nameof(GetByIdAsync), new { document = company.Document }, companyDTO);
        }

        [HttpPut("{Document}")]
        public async Task<ActionResult> UpdateAsync(string document, CompanyDTO companyDTO)
        {
            if (document != companyDTO.Document)
                return BadRequest();

            var company = _mapper.Map<Company>(companyDTO);
            await _companyService.UpdateAsync(company);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            await _companyService.DeleteAsync(id);
            return NoContent();
        }
    }
}
