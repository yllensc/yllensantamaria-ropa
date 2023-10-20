using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;
    public class UseroleRepository: GenericRepository<UserRol>, IUserRol
{
    private readonly ClothingDbContext _context;

    public UseroleRepository(ClothingDbContext context) : base(context)
    {
        _context = context;
    }
}