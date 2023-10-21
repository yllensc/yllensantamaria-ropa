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
    public class OrdenController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfwork;
        private readonly IMapper _mapper;

        public OrdenController(IUnitOfWork unitofwork, IMapper mapper)
        {
            this._unitOfwork = unitofwork;
            this._mapper = mapper;
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<OrdenDto>>> Get()
        {
            var Orden = await _unitOfwork.Ordenes.GetAllAsync();
            return _mapper.Map<List<OrdenDto>>(Orden);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrdenDto>> Get(int id)
        {
            var Orden = await _unitOfwork.Ordenes.GetByIdAsync(id);
            if (Orden == null)
            {
                return NotFound();
            }
            return this._mapper.Map<OrdenDto>(Orden);
        }

        [HttpGet]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<OrdenDto>>> GetPagination([FromQuery] Params Params)
        {
            var (totalRecords, records) = await _unitOfwork.Ordenes.GetAllAsync(Params.PageIndex, Params.PageSize, Params.Search);
            var listOrden = _mapper.Map<List<OrdenDto>>(records);
            return new Pager<OrdenDto>(listOrden, totalRecords, Params.PageIndex, Params.PageSize, Params.Search);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Orden>> Post(OrdenDto OrdenDto)
        {
            var Orden = this._mapper.Map<Orden>(OrdenDto);
            this._unitOfwork.Ordenes.Add(Orden);
            await _unitOfwork.SaveAsync();
            if (Orden == null)
            {
                return BadRequest();
            }
            OrdenDto.Id = Orden.Id;
            return CreatedAtAction(nameof(Post), new { id = OrdenDto.Id }, OrdenDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrdenDto>> Put(int id, [FromBody]OrdenDto OrdenDto)
        {
            if (OrdenDto == null)
            {
                return NotFound();
            }
            var Orden = this._mapper.Map<Orden>(OrdenDto);
            _unitOfwork.Ordenes.Update(Orden);
            await _unitOfwork.SaveAsync();
            return OrdenDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Orden = await _unitOfwork.Ordenes.GetByIdAsync(id);
            if (Orden == null)
            {
                return NotFound();
            }
            _unitOfwork.Ordenes.Remove(Orden);
            await _unitOfwork.SaveAsync();
            return NoContent();
        }
    }
}