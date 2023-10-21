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
    public class EstadoController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfwork;
        private readonly IMapper _mapper;

        public EstadoController(IUnitOfWork unitofwork, IMapper mapper)
        {
            this._unitOfwork = unitofwork;
            this._mapper = mapper;
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<EstadoDto>>> Get()
        {
            var Estado = await _unitOfwork.Estados.GetAllAsync();
            return _mapper.Map<List<EstadoDto>>(Estado);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EstadoDto>> Get(int id)
        {
            var Estado = await _unitOfwork.Estados.GetByIdAsync(id);
            if (Estado == null)
            {
                return NotFound();
            }
            return this._mapper.Map<EstadoDto>(Estado);
        }

        [HttpGet]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<EstadoDto>>> GetPagination([FromQuery] Params Params)
        {
            var (totalRecords, records) = await _unitOfwork.Estados.GetAllAsync(Params.PageIndex, Params.PageSize, Params.Search);
            var listEstado = _mapper.Map<List<EstadoDto>>(records);
            return new Pager<EstadoDto>(listEstado, totalRecords, Params.PageIndex, Params.PageSize, Params.Search);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Estado>> Post(EstadoDto EstadoDto)
        {
            var Estado = this._mapper.Map<Estado>(EstadoDto);
            this._unitOfwork.Estados.Add(Estado);
            await _unitOfwork.SaveAsync();
            if (Estado == null)
            {
                return BadRequest();
            }
            EstadoDto.Id = Estado.Id;
            return CreatedAtAction(nameof(Post), new { id = EstadoDto.Id }, EstadoDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EstadoDto>> Put(int id, [FromBody]EstadoDto EstadoDto)
        {
            if (EstadoDto == null)
            {
                return NotFound();
            }
            var Estado = this._mapper.Map<Estado>(EstadoDto);
            _unitOfwork.Estados.Update(Estado);
            await _unitOfwork.SaveAsync();
            return EstadoDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Estado = await _unitOfwork.Estados.GetByIdAsync(id);
            if (Estado == null)
            {
                return NotFound();
            }
            _unitOfwork.Estados.Remove(Estado);
            await _unitOfwork.SaveAsync();
            return NoContent();
        }
    }
}