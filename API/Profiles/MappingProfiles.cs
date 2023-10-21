using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Domain.Entities;

namespace API.Profiles;

public class MappingProfiles : Profile
{

    public MappingProfiles()
    {
        CreateMap<User, UserWithRolDto>().ReverseMap();
        //.ForMember(dest => dest.Movement, opt => opt.MapFrom(src => src.TypeMovement.Name))
        CreateMap<Empleado, EmpleadoDto>()
        .ForMember(dest => dest.Cargo, opt => opt.MapFrom(src => src.Cargo.Descripcion))
        .ReverseMap();
        CreateMap<Estado, EstadoDto>().ReverseMap();
        CreateMap<Proveedor, ProveedorDto>().ReverseMap();
        CreateMap<Cliente, ClienteDto>().ReverseMap();
        CreateMap<Insumo, InsumoDto>().ReverseMap();
        CreateMap<InsumoPrenda, InsumoPrendaDto>().ReverseMap();
        CreateMap<DetalleOrden, DetalleOrdenDto>().ReverseMap();
        CreateMap<DetalleVenta, DetalleVentaDto>().ReverseMap();
        CreateMap<TipoPersona, TipoPersonaDto>().ReverseMap();
        CreateMap<TipoProteccion, TipoProteccionDto>().ReverseMap();
        CreateMap<Venta, VentaDto>().ReverseMap();
    }

}
