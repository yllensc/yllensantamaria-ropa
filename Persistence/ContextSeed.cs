using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Persistence
{
    public class ContextSeed
    {
        private readonly UserManager<User> _userManager;

        public ContextSeed(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public static async Task SeedAsync(ClothingDbContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.Roles.Any())
                {
                    var roles = new List<Rol>
                    {
                        new() { Name = "Admi" },
                        new() { Name = "Empleado" },
                        new() { Name = "SinRolAsignado" }
                    };
                    context.Roles.AddRange(roles);
                    await context.SaveChangesAsync();
                }
                if (!context.Cargos.Any())
                {
                    var cargos = new List<Cargo>
                    {
                        new()  { Descripcion = "Vendedor", SueldoBase = 430.0 }
                    };
                    context.Cargos.AddRange(cargos);
                    await context.SaveChangesAsync();
                }
                if (!context.TipoPersonas.Any())
                {
                    var tipoPersonas = new List<TipoPersona>
                    {
                        new()  { Nombre = "Natural"},
                        new()  { Nombre = "Jurídica"}
                    };
                    context.TipoPersonas.AddRange(tipoPersonas);
                    await context.SaveChangesAsync();
                }
                if (!context.Pais.Any())
                {
                    var Pais = new List<Pais>
                    {
                        new()  { Nombre = "Colombia"},
                        new()  { Nombre = "Argentina"}
                    };
                    context.Pais.AddRange(Pais);
                    await context.SaveChangesAsync();
                }
                if (!context.Departamentos.Any())
                {
                    var Departamentos = new List<Departamento>
                    {
                        new()  { Nombre = "Bogotá", IdPais = 1},
                        new()  { Nombre = "Medellín", IdPais = 1}
                    };
                    context.Departamentos.AddRange(Departamentos);
                    await context.SaveChangesAsync();
                }
                if (!context.Municipios.Any())
                {
                    var Municipios = new List<Municipio>
                    {
                        new()  { Nombre = "Bogotá", IdDep = 1},
                        new()  { Nombre = "Medellín", IdDep = 2}
                    };
                    context.Municipios.AddRange(Municipios);
                    await context.SaveChangesAsync();
                }
                if (!context.TipoProtecciones.Any())
                {
                    var TipoProtecciones = new List<TipoProteccion>
                    {
                        new()  { Descripcion = "SUPERProtegido" },
                        new()  { Descripcion = "UnpocoProtegido" }
                    };
                    context.TipoProtecciones.AddRange(TipoProtecciones);
                    await context.SaveChangesAsync();
                }
                if (!context.Generos.Any())
                {
                    var Generos = new List<Genero>
                    {
                        new()  { Descripcion = "NOTIENEGENEROLAROPA" },
                    };
                    context.Generos.AddRange(Generos);
                    await context.SaveChangesAsync();
                }
                if (!context.Prendas.Any())
                {
                    var Prendas = new List<Prenda>
                    {
                        new()  { Nombre = "prendaCool", ValorUnitCop = 123, ValorUnitUsd = 456, IdEstado = 1, IdGenero = 1, IdTipoProteccion = 1 }
                    };
                    context.Prendas.AddRange(Prendas);
                    await context.SaveChangesAsync();
                }

                if (!context.Users.Any())
                {
                    var passwordHasher = new PasswordHasher<User>();
                    using var readerUsers = new StreamReader("../Persistence/Data/Csvs/users.csv");
                    using (var csv = new CsvReader(readerUsers, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        var usersList = csv.GetRecords<User>();
                        List<User> users = new List<User>();
                        foreach (var user in usersList)
                        {
                            var hashedPassword = passwordHasher.HashPassword(null, user.Password);
                            var newUser = new User
                            {
                                Id = user.Id,
                                UserName = user.UserName,
                                IdenNumber = user.IdenNumber,
                                Email = user.Email,
                                Password = hashedPassword
                            };
                            users.Add(newUser);
                        }
                        context.Users.AddRange(users);
                        await context.SaveChangesAsync();
                    }
                }

                if (!context.UserRoles.Any())
                {
                    using (var readerUserRols = new StreamReader("../Persistence/Data/Csvs/userRols.csv"))
                    {
                        using (var csv = new CsvReader(readerUserRols, new CsvConfiguration(CultureInfo.InvariantCulture)
                        {
                            HeaderValidated = null, // Esto deshabilita la validación de encabezados
                            MissingFieldFound = null
                        }))
                        {
                            var userRolList = csv.GetRecords<UserRol>();
                            List<UserRol> userRols = new List<UserRol>();
                            foreach (var userRol in userRolList)
                            {
                                userRols.Add(new UserRol
                                {
                                    Id = userRol.Id,
                                    UserId = userRol.UserId,
                                    RolId = userRol.RolId
                                });
                            }
                            context.UserRoles.AddRange(userRols);
                            await context.SaveChangesAsync();
                        }
                    }
                }
                if (!context.Empleados.Any())
                {
                    using (var readerEmpleado = new StreamReader("../Persistence/Data/Csvs/empleado.csv"))
                    {
                        using (var csv = new CsvReader(readerEmpleado, new CsvConfiguration(CultureInfo.InvariantCulture)
                        {
                            HeaderValidated = null, // Esto deshabilita la validación de encabezados
                            MissingFieldFound = null
                        }))
                        {
                            var empleadoList = csv.GetRecords<Empleado>();
                            List<Empleado> empleados = new List<Empleado>();
                            foreach (var empleado in empleadoList)
                            {
                                empleados.Add(new Empleado
                                {
                                    Id = empleado.Id,
                                    IdUser = empleado.IdUser,
                                    Nombre = empleado.Nombre,
                                    IdCargo = empleado.IdCargo,
                                    IdMunicipio = empleado.IdMunicipio,
                                    FechaIngreso = DateTime.UtcNow
                                });
                            }
                            context.Empleados.AddRange(empleados);
                            await context.SaveChangesAsync();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<ClothingDbContext>();
                logger.LogError(ex.Message);
            }
        }
    }
}