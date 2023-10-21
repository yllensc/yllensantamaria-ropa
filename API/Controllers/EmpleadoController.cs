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
    public class EmpleadoController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfwork;
        private readonly IMapper _mapper;

        public EmpleadoController(IUnitOfWork unitofwork, IMapper mapper)
        {
            this._unitOfwork = unitofwork;
            this._mapper = mapper;
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<EmpleadoDto>>> Get()
        {
            var Empleado = await _unitOfwork.Empleados.GetAllAsync();
            return _mapper.Map<List<EmpleadoDto>>(Empleado);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EmpleadoDto>> Get(int id)
        {
            var Empleado = await _unitOfwork.Empleados.GetByIdAsync(id);
            if (Empleado == null)
            {
                return NotFound();
            }
            return this._mapper.Map<EmpleadoDto>(Empleado);
        }

        [HttpGet]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<EmpleadoDto>>> GetPagination([FromQuery] Params Params)
        {
            var (totalRecords, records) = await _unitOfwork.Empleados.GetAllAsync(Params.PageIndex, Params.PageSize, Params.Search);
            var listEmpleado = _mapper.Map<List<EmpleadoDto>>(records);
            return new Pager<EmpleadoDto>(listEmpleado, totalRecords, Params.PageIndex, Params.PageSize, Params.Search);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Empleado>> Post(EmpleadoDto EmpleadoDto)
        {
            var Empleado = this._mapper.Map<Empleado>(EmpleadoDto);
            this._unitOfwork.Empleados.Add(Empleado);
            await _unitOfwork.SaveAsync();
            if (Empleado == null)
            {
                return BadRequest();
            }
            EmpleadoDto.Id = Empleado.Id;
            return CreatedAtAction(nameof(Post), new { id = EmpleadoDto.Id }, EmpleadoDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EmpleadoDto>> Put(int id, [FromBody]EmpleadoDto EmpleadoDto)
        {
            if (EmpleadoDto == null)
            {
                return NotFound();
            }
            var Empleado = this._mapper.Map<Empleado>(EmpleadoDto);
            _unitOfwork.Empleados.Update(Empleado);
            await _unitOfwork.SaveAsync();
            return EmpleadoDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Empleado = await _unitOfwork.Empleados.GetByIdAsync(id);
            if (Empleado == null)
            {
                return NotFound();
            }
            _unitOfwork.Empleados.Remove(Empleado);
            await _unitOfwork.SaveAsync();
            return NoContent();
        }
    }
}