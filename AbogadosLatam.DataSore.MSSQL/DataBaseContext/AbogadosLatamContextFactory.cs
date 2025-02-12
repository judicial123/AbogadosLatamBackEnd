using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace AbogadosLatam.DataSore.MSSQL.DataBaseContext
{
    public class AbogadosLatamContextFactory : IDesignTimeDbContextFactory<AbogadosLatamContext>
    {
        public AbogadosLatamContext CreateDbContext(string[] args)
        {
            // Configuración para cargar el appsettings.json en tiempo de diseño
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // Construir opciones para el DbContext
            var optionsBuilder = new DbContextOptionsBuilder<AbogadosLatamContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("AbogadosLatamConnectionString"));

            return new AbogadosLatamContext(optionsBuilder.Options);
        }
    }
}