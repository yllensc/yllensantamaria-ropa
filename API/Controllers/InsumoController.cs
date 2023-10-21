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
    public class InsumoController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfwork;
        private readonly IMapper _mapper;

        public InsumoController(IUnitOfWork unitofwork, IMapper mapper)
        {
            this._unitOfwork = unitofwork;
            this._mapper = mapper;
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<InsumoDto>>> Get()
        {
            var Insumo = await _unitOfwork.Insumos.GetAllAsync();
            return _mapper.Map<List<InsumoDto>>(Insumo);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<InsumoDto>> Get(int id)
        {
            var Insumo = await _unitOfwork.Insumos.GetByIdAsync(id);
            if (Insumo == null)
            {
                return NotFound();
            }
            return this._mapper.Map<InsumoDto>(Insumo);
        }

        [HttpGet]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<InsumoDto>>> GetPagination([FromQuery] Params Params)
        {
            var (totalRecords, records) = await _unitOfwork.Insumos.GetAllAsync(Params.PageIndex, Params.PageSize, Params.Search);
            var listInsumo = _mapper.Map<List<InsumoDto>>(records);
            return new Pager<InsumoDto>(listInsumo, totalRecords, Params.PageIndex, Params.PageSize, Params.Search);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Insumo>> Post(InsumoDto InsumoDto)
        {
            var Insumo = this._mapper.Map<Insumo>(InsumoDto);
            this._unitOfwork.Insumos.Add(Insumo);
            await _unitOfwork.SaveAsync();
            if (Insumo == null)
            {
                return BadRequest();
            }
            InsumoDto.Id = Insumo.Id;
            return CreatedAtAction(nameof(Post), new { id = InsumoDto.Id }, InsumoDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<InsumoDto>> Put(int id, [FromBody]InsumoDto InsumoDto)
        {
            if (InsumoDto == null)
            {
                return NotFound();
            }
            var Insumo = this._mapper.Map<Insumo>(InsumoDto);
            _unitOfwork.Insumos.Update(Insumo);
            await _unitOfwork.SaveAsync();
            return InsumoDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Insumo = await _unitOfwork.Insumos.GetByIdAsync(id);
            if (Insumo == null)
            {
                return NotFound();
            }
            _unitOfwork.Insumos.Remove(Insumo);
            await _unitOfwork.SaveAsync();
            return NoContent();
        }
    }
}