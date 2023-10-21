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
    public class VentaController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfwork;
        private readonly IMapper _mapper;

        public VentaController(IUnitOfWork unitofwork, IMapper mapper)
        {
            this._unitOfwork = unitofwork;
            this._mapper = mapper;
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<VentaDto>>> Get()
        {
            var Venta = await _unitOfwork.Ventas.GetAllAsync();
            return _mapper.Map<List<VentaDto>>(Venta);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VentaDto>> Get(int id)
        {
            var Venta = await _unitOfwork.Ventas.GetByIdAsync(id);
            if (Venta == null)
            {
                return NotFound();
            }
            return this._mapper.Map<VentaDto>(Venta);
        }

        [HttpGet]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<VentaDto>>> GetPagination([FromQuery] Params Params)
        {
            var (totalRecords, records) = await _unitOfwork.Ventas.GetAllAsync(Params.PageIndex, Params.PageSize, Params.Search);
            var listVenta = _mapper.Map<List<VentaDto>>(records);
            return new Pager<VentaDto>(listVenta, totalRecords, Params.PageIndex, Params.PageSize, Params.Search);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Venta>> Post(VentaDto VentaDto)
        {
            var Venta = this._mapper.Map<Venta>(VentaDto);
            this._unitOfwork.Ventas.Add(Venta);
            await _unitOfwork.SaveAsync();
            if (Venta == null)
            {
                return BadRequest();
            }
            VentaDto.Id = Venta.Id;
            return CreatedAtAction(nameof(Post), new { id = VentaDto.Id }, VentaDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VentaDto>> Put(int id, [FromBody]VentaDto VentaDto)
        {
            if (VentaDto == null)
            {
                return NotFound();
            }
            var Venta = this._mapper.Map<Venta>(VentaDto);
            _unitOfwork.Ventas.Update(Venta);
            await _unitOfwork.SaveAsync();
            return VentaDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Venta = await _unitOfwork.Ventas.GetByIdAsync(id);
            if (Venta == null)
            {
                return NotFound();
            }
            _unitOfwork.Ventas.Remove(Venta);
            await _unitOfwork.SaveAsync();
            return NoContent();
        }
    }
}