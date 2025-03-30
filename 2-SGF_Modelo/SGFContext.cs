using _2_SGF_Modelo.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace _2_SGF_Modelo;

public partial class SGFContext : DbContext
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;

    public SGFContext(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString = _configuration.GetConnectionString("SGF");
    }

    public SGFContext(DbContextOptions<SGFContext> options)
    : base(options)
    {
    }

    public virtual DbSet<usp_ObtenerCategorias> usp_ObtenerCategorias { get; set; }
    public virtual DbSet<usp_ObtenerClasificaciones> usp_ObtenerClasificaciones { get; set; }
    public virtual DbSet<usp_ObtenerTiposUsuario> usp_ObtenerTiposUsuario { get; set; }
    public virtual DbSet<usp_ObtenerTiposPermiso> usp_ObtenerTiposPermiso { get; set; }
    public virtual DbSet<usp_ValidarUsuario> usp_ValidarUsuario { get; set; }
    public virtual DbSet<usp_ObtenerDatosUsuario> usp_ObtenerDatosUsuario { get; set; }
    public virtual DbSet<usp_ObtenerPermisosUsuario> usp_ObtenerPermisosUsuario { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(_connectionString, providerOptions => { providerOptions.EnableRetryOnFailure(); });

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<usp_ObtenerCategorias>(
            entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<usp_ObtenerClasificaciones>(
            entity =>
            {
                entity.HasNoKey();
            });

        modelBuilder.Entity<usp_ObtenerTiposUsuario>(
            entity =>
            {
                entity.HasNoKey();
            });

        modelBuilder.Entity<usp_ObtenerTiposPermiso>(
            entity =>
            {
                entity.HasNoKey();
            });

        modelBuilder.Entity<usp_ValidarUsuario>(
            entity =>
            {
                entity.HasNoKey();
            });
        
        modelBuilder.Entity<usp_ObtenerDatosUsuario>(
            entity =>
            {
                entity.HasNoKey();
            });

        modelBuilder.Entity<usp_ObtenerPermisosUsuario>(
            entity =>
            {
                entity.HasNoKey();
            });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
