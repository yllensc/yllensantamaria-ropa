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
    public class ProveedorController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfwork;
        private readonly IMapper _mapper;

        public ProveedorController(IUnitOfWork unitofwork, IMapper mapper)
        {
            this._unitOfwork = unitofwork;
            this._mapper = mapper;
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ProveedorDto>>> Get()
        {
            var Proveedor = await _unitOfwork.Proveedores.GetAllAsync();
            return _mapper.Map<List<ProveedorDto>>(Proveedor);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProveedorDto>> Get(int id)
        {
            var Proveedor = await _unitOfwork.Proveedores.GetByIdAsync(id);
            if (Proveedor == null)
            {
                return NotFound();
            }
            return this._mapper.Map<ProveedorDto>(Proveedor);
        }

        [HttpGet]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<ProveedorDto>>> GetPagination([FromQuery] Params Params)
        {
            var (totalRecords, records) = await _unitOfwork.Proveedores.GetAllAsync(Params.PageIndex, Params.PageSize, Params.Search);
            var listProveedor = _mapper.Map<List<ProveedorDto>>(records);
            return new Pager<ProveedorDto>(listProveedor, totalRecords, Params.PageIndex, Params.PageSize, Params.Search);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Proveedor>> Post(ProveedorDto ProveedorDto)
        {
            var Proveedor = this._mapper.Map<Proveedor>(ProveedorDto);
            this._unitOfwork.Proveedores.Add(Proveedor);
            await _unitOfwork.SaveAsync();
            if (Proveedor == null)
            {
                return BadRequest();
            }
            ProveedorDto.Id = Proveedor.Id;
            return CreatedAtAction(nameof(Post), new { id = ProveedorDto.Id }, ProveedorDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProveedorDto>> Put(int id, [FromBody]ProveedorDto ProveedorDto)
        {
            if (ProveedorDto == null)
            {
                return NotFound();
            }
            var Proveedor = this._mapper.Map<Proveedor>(ProveedorDto);
            _unitOfwork.Proveedores.Update(Proveedor);
            await _unitOfwork.SaveAsync();
            return ProveedorDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Proveedor = await _unitOfwork.Proveedores.GetByIdAsync(id);
            if (Proveedor == null)
            {
                return NotFound();
            }
            _unitOfwork.Proveedores.Remove(Proveedor);
            await _unitOfwork.SaveAsync();
            return NoContent();
        }
    }
}