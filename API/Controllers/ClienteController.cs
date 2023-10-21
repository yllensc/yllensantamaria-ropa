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
    public class ClienteController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfwork;
        private readonly IMapper _mapper;

        public ClienteController(IUnitOfWork unitofwork, IMapper mapper)
        {
            this._unitOfwork = unitofwork;
            this._mapper = mapper;
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ClienteDto>>> Get()
        {
            var Cliente = await _unitOfwork.Clientes.GetAllAsync();
            return _mapper.Map<List<ClienteDto>>(Cliente);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ClienteDto>> Get(int id)
        {
            var Cliente = await _unitOfwork.Clientes.GetByIdAsync(id);
            if (Cliente == null)
            {
                return NotFound();
            }
            return this._mapper.Map<ClienteDto>(Cliente);
        }

        [HttpGet]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<ClienteDto>>> GetPagination([FromQuery] Params Params)
        {
            var (totalRecords, records) = await _unitOfwork.Clientes.GetAllAsync(Params.PageIndex, Params.PageSize, Params.Search);
            var listCliente = _mapper.Map<List<ClienteDto>>(records);
            return new Pager<ClienteDto>(listCliente, totalRecords, Params.PageIndex, Params.PageSize, Params.Search);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Cliente>> Post(ClienteDto ClienteDto)
        {
            var Cliente = this._mapper.Map<Cliente>(ClienteDto);
            this._unitOfwork.Clientes.Add(Cliente);
            await _unitOfwork.SaveAsync();
            if (Cliente == null)
            {
                return BadRequest();
            }
            ClienteDto.Id = Cliente.Id;
            return CreatedAtAction(nameof(Post), new { id = ClienteDto.Id }, ClienteDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ClienteDto>> Put(int id, [FromBody]ClienteDto ClienteDto)
        {
            if (ClienteDto == null)
            {
                return NotFound();
            }
            var Cliente = this._mapper.Map<Cliente>(ClienteDto);
            _unitOfwork.Clientes.Update(Cliente);
            await _unitOfwork.SaveAsync();
            return ClienteDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Cliente = await _unitOfwork.Clientes.GetByIdAsync(id);
            if (Cliente == null)
            {
                return NotFound();
            }
            _unitOfwork.Clientes.Remove(Cliente);
            await _unitOfwork.SaveAsync();
            return NoContent();
        }
    }
}