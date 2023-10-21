using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    //[Authorize]
    public class PrendaController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfwork;
        private readonly IMapper _mapper;

        public PrendaController(IUnitOfWork unitofwork, IMapper mapper)
        {
            this._unitOfwork = unitofwork;
            this._mapper = mapper;
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PrendaDto>>> Get()
        {
            var Prenda = await _unitOfwork.Prendas.GetAllAsync();
            return _mapper.Map<List<PrendaDto>>(Prenda);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PrendaDto>> Get(int id)
        {
            var Prenda = await _unitOfwork.Prendas.GetByIdAsync(id);
            if (Prenda == null)
            {
                return NotFound();
            }
            return this._mapper.Map<PrendaDto>(Prenda);
        }

        [HttpGet]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<PrendaDto>>> GetPagination([FromQuery] Params Params)
        {
            var (totalRecords, records) = await _unitOfwork.Prendas.GetAllAsync(Params.PageIndex, Params.PageSize, Params.Search);
            var listPrenda = _mapper.Map<List<PrendaDto>>(records);
            return new Pager<PrendaDto>(listPrenda, totalRecords, Params.PageIndex, Params.PageSize, Params.Search);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Prenda>> Post(PrendaDto PrendaDto)
        {
            var Prenda = this._mapper.Map<Prenda>(PrendaDto);
            this._unitOfwork.Prendas.Add(Prenda);
            await _unitOfwork.SaveAsync();
            if (Prenda == null)
            {
                return BadRequest();
            }
            PrendaDto.Id = Prenda.Id;
            return CreatedAtAction(nameof(Post), new { id = PrendaDto.Id }, PrendaDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PrendaDto>> Put(int id, [FromBody]PrendaDto PrendaDto)
        {
            if (PrendaDto == null)
            {
                return NotFound();
            }
            var Prenda = this._mapper.Map<Prenda>(PrendaDto);
            _unitOfwork.Prendas.Update(Prenda);
            await _unitOfwork.SaveAsync();
            return PrendaDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Prenda = await _unitOfwork.Prendas.GetByIdAsync(id);
            if (Prenda == null)
            {
                return NotFound();
            }
            _unitOfwork.Prendas.Remove(Prenda);
            await _unitOfwork.SaveAsync();
            return NoContent();
        }
    }
}