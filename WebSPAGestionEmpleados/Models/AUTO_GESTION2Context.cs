using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebSPAGestionEmpleados.Models
{
    public partial class AUTO_GESTION2Context : DbContext
    {
        public AUTO_GESTION2Context()
        {
        }

        public AUTO_GESTION2Context(DbContextOptions<AUTO_GESTION2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Cargos> Cargos { get; set; }
        public virtual DbSet<Cias> Cias { get; set; }
        public virtual DbSet<Conceptos> Conceptos { get; set; }
        public virtual DbSet<Configuracion> Configuracion { get; set; }
        public virtual DbSet<Departamentos> Departamentos { get; set; }
        public virtual DbSet<Direcciones> Direcciones { get; set; }
        public virtual DbSet<Historico> Historico { get; set; }
        public virtual DbSet<HistoricoSueldos> HistoricoSueldos { get; set; }
        public virtual DbSet<InterfazControl> InterfazControl { get; set; }
        public virtual DbSet<InterfazEstructura> InterfazEstructura { get; set; }
        public virtual DbSet<Maestro> Maestro { get; set; }
        public virtual DbSet<MaestroDatos> MaestroDatos { get; set; }
        public virtual DbSet<Procesos> Procesos { get; set; }
        public virtual DbSet<Profesiones> Profesiones { get; set; }
        public virtual DbSet<Promedios> Promedios { get; set; }
        public virtual DbSet<PromediosConceptos> PromediosConceptos { get; set; }
        public virtual DbSet<PromediosDetalle> PromediosDetalle { get; set; }
        public virtual DbSet<Saldos> Saldos { get; set; }
        public virtual DbSet<Tablas> Tablas { get; set; }
        public virtual DbSet<Telefonos> Telefonos { get; set; }
        public virtual DbSet<TipoNomina> TipoNomina { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=AUTO_GESTION2;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Cargos>(entity =>
            {
                entity.HasKey(e => new { e.CiaCd, e.CargoCd });

                entity.ToTable("CARGOS");

                entity.Property(e => e.CiaCd)
                    .HasColumnName("CIA_CD")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.CargoCd)
                    .HasColumnName("CARGO_CD")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ActivoFg).HasColumnName("ACTIVO_FG");

                entity.Property(e => e.CargoDesc)
                    .IsRequired()
                    .HasColumnName("CARGO_DESC")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CreaDate)
                    .HasColumnName("CREA_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CreaUsr)
                    .IsRequired()
                    .HasColumnName("CREA_USR")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MttoDate)
                    .HasColumnName("MTTO_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MttoUsr)
                    .IsRequired()
                    .HasColumnName("MTTO_USR")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.CiaCdNavigation)
                    .WithMany(p => p.Cargos)
                    .HasForeignKey(d => d.CiaCd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CARGOS_CIAS");
            });

            modelBuilder.Entity<Cias>(entity =>
            {
                entity.HasKey(e => e.CiaCd)
                    .HasName("CIAS_XP");

                entity.ToTable("CIAS");

                entity.Property(e => e.CiaCd)
                    .HasColumnName("CIA_CD")
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CiaDesc)
                    .IsRequired()
                    .HasColumnName("CIA_DESC")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CreaDate)
                    .HasColumnName("CREA_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreaUsr)
                    .IsRequired()
                    .HasColumnName("CREA_USR")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MttoDate)
                    .HasColumnName("MTTO_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.MttoUsr)
                    .IsRequired()
                    .HasColumnName("MTTO_USR")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RifNbr)
                    .IsRequired()
                    .HasColumnName("RIF_NBR")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RifTipo)
                    .IsRequired()
                    .HasColumnName("RIF_TIPO")
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Conceptos>(entity =>
            {
                entity.HasKey(e => new { e.CiaCd, e.NominaCd, e.ConceptoNbr });

                entity.ToTable("CONCEPTOS");

                entity.Property(e => e.CiaCd)
                    .HasColumnName("CIA_CD")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.NominaCd)
                    .HasColumnName("NOMINA_CD")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.ConceptoNbr).HasColumnName("CONCEPTO_NBR");

                entity.Property(e => e.ActivoFg)
                    .HasColumnName("ACTIVO_FG")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ConceptoDesc)
                    .IsRequired()
                    .HasColumnName("CONCEPTO_DESC")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CreaDate)
                    .HasColumnName("CREA_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreaUsr)
                    .IsRequired()
                    .HasColumnName("CREA_USR")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FuncionNbr).HasColumnName("FUNCION_NBR");

                entity.Property(e => e.MttoDate)
                    .HasColumnName("MTTO_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MttoUsr)
                    .IsRequired()
                    .HasColumnName("MTTO_USR")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SalarioSal)
                    .HasColumnName("SALARIO_SAL")
                    .HasColumnType("decimal(21, 5)");

                entity.HasOne(d => d.CiaCdNavigation)
                    .WithMany(p => p.Conceptos)
                    .HasForeignKey(d => d.CiaCd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CONCEPTOS_CIAS");
            });

            modelBuilder.Entity<Configuracion>(entity =>
            {
                entity.HasKey(e => e.CiaCd)
                    .HasName("CONFIGURACION_XP");

                entity.ToTable("CONFIGURACION");

                entity.Property(e => e.CiaCd)
                    .HasColumnName("CIA_CD")
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CarpetaBackupTxt)
                    .IsRequired()
                    .HasColumnName("CARPETA_BACKUP_TXT")
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CarpetaErrorTxt)
                    .IsRequired()
                    .HasColumnName("CARPETA_ERROR_TXT")
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CarpetaFilesTxt)
                    .IsRequired()
                    .HasColumnName("CARPETA_FILES_TXT")
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CreaDate)
                    .HasColumnName("CREA_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreaUsr)
                    .IsRequired()
                    .HasColumnName("CREA_USR")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmailEnvioTxt)
                    .IsRequired()
                    .HasColumnName("EMAIL_ENVIO_TXT")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EmailSoporteTxt)
                    .IsRequired()
                    .HasColumnName("EMAIL_SOPORTE_TXT")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExtensionBackupTxt)
                    .IsRequired()
                    .HasColumnName("EXTENSION_BACKUP_TXT")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExtensionErrorTxt)
                    .IsRequired()
                    .HasColumnName("EXTENSION_ERROR_TXT")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExtensionFilesTxt)
                    .IsRequired()
                    .HasColumnName("EXTENSION_FILES_TXT")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MttoDate)
                    .HasColumnName("MTTO_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.MttoUsr)
                    .IsRequired()
                    .HasColumnName("MTTO_USR")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TimeZoneTxt)
                    .IsRequired()
                    .HasColumnName("TIME_ZONE_TXT")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('00:00')");
            });

            modelBuilder.Entity<Departamentos>(entity =>
            {
                entity.HasKey(e => new { e.CiaCd, e.DptoCd });

                entity.ToTable("DEPARTAMENTOS");

                entity.Property(e => e.CiaCd)
                    .HasColumnName("CIA_CD")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.DptoCd)
                    .HasColumnName("DPTO_CD")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ActivoFg).HasColumnName("ACTIVO_FG");

                entity.Property(e => e.CreaDate)
                    .HasColumnName("CREA_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CreaUsr)
                    .IsRequired()
                    .HasColumnName("CREA_USR")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DptoDesc)
                    .IsRequired()
                    .HasColumnName("DPTO_DESC")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MttoDate)
                    .HasColumnName("MTTO_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MttoUsr)
                    .IsRequired()
                    .HasColumnName("MTTO_USR")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.CiaCdNavigation)
                    .WithMany(p => p.Departamentos)
                    .HasForeignKey(d => d.CiaCd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DEPARTAMENTOS_CIAS");
            });

            modelBuilder.Entity<Direcciones>(entity =>
            {
                entity.HasKey(e => new { e.CiaCd, e.FichaCd, e.ParentescoNbr, e.ItemNbr })
                    .HasName("DIRECCIONES_XP");

                entity.ToTable("DIRECCIONES");

                entity.Property(e => e.CiaCd)
                    .HasColumnName("CIA_CD")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.FichaCd)
                    .HasColumnName("FICHA_CD")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ParentescoNbr).HasColumnName("PARENTESCO_NBR");

                entity.Property(e => e.ItemNbr).HasColumnName("ITEM_NBR");

                entity.Property(e => e.ActivoFg)
                    .HasColumnName("ACTIVO_FG")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CiudadNbr).HasColumnName("CIUDAD_NBR");

                entity.Property(e => e.CreaDate)
                    .HasColumnName("CREA_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CreaUsr)
                    .IsRequired()
                    .HasColumnName("CREA_USR")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DireccionTxt)
                    .IsRequired()
                    .HasColumnName("DIRECCION_TXT")
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EstadoNbr).HasColumnName("ESTADO_NBR");

                entity.Property(e => e.MttoDate)
                    .HasColumnName("MTTO_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MttoUsr)
                    .IsRequired()
                    .HasColumnName("MTTO_USR")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PaisNbr).HasColumnName("PAIS_NBR");

                entity.HasOne(d => d.CiaCdNavigation)
                    .WithMany(p => p.Direcciones)
                    .HasForeignKey(d => d.CiaCd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DIRECCIONES_CIAS");

                entity.HasOne(d => d.Maestro)
                    .WithMany(p => p.Direcciones)
                    .HasForeignKey(d => new { d.CiaCd, d.FichaCd })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DIRECCIONES_MAESTRO");

                entity.HasOne(d => d.MaestroDatos)
                    .WithOne(p => p.Direcciones)
                    .HasForeignKey<Direcciones>(d => new { d.CiaCd, d.FichaCd, d.ParentescoNbr, d.ItemNbr })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DIRECCIONES_MAESTRO_DATOS");
            });

            modelBuilder.Entity<Historico>(entity =>
            {
                entity.HasKey(e => new { e.CiaCd, e.FichaCd, e.NominaCd, e.AnoNbr, e.MesNbr, e.PeriodoNbr, e.ProcesoNbr, e.SubprocesoNbr, e.ItemNbr })
                    .HasName("PK_HISTORICO_1");

                entity.ToTable("HISTORICO");

                entity.Property(e => e.CiaCd)
                    .HasColumnName("CIA_CD")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.FichaCd)
                    .HasColumnName("FICHA_CD")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NominaCd)
                    .HasColumnName("NOMINA_CD")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.AnoNbr).HasColumnName("ANO_NBR");

                entity.Property(e => e.MesNbr).HasColumnName("MES_NBR");

                entity.Property(e => e.PeriodoNbr).HasColumnName("PERIODO_NBR");

                entity.Property(e => e.ProcesoNbr).HasColumnName("PROCESO_NBR");

                entity.Property(e => e.SubprocesoNbr).HasColumnName("SUBPROCESO_NBR");

                entity.Property(e => e.ItemNbr).HasColumnName("ITEM_NBR");

                entity.Property(e => e.CantidadQty)
                    .HasColumnName("CANTIDAD_QTY")
                    .HasColumnType("decimal(15, 5)");

                entity.Property(e => e.CargoCd)
                    .IsRequired()
                    .HasColumnName("CARGO_CD")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ConceptoNbr).HasColumnName("CONCEPTO_NBR");

                entity.Property(e => e.CreaDate)
                    .HasColumnName("CREA_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreaUsr)
                    .IsRequired()
                    .HasColumnName("CREA_USR")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CuentaBco)
                    .IsRequired()
                    .HasColumnName("CUENTA_BCO")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CuentaContable)
                    .IsRequired()
                    .HasColumnName("CUENTA_CONTABLE")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CuentaNro).HasColumnName("CUENTA_NRO");

                entity.Property(e => e.DepositoBco)
                    .IsRequired()
                    .HasColumnName("DEPOSITO_BCO")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DepositoFg).HasColumnName("DEPOSITO_FG");

                entity.Property(e => e.DepositoTipo)
                    .IsRequired()
                    .HasColumnName("DEPOSITO_TIPO")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DptoCd)
                    .IsRequired()
                    .HasColumnName("DPTO_CD")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FactorQty)
                    .HasColumnName("FACTOR_QTY")
                    .HasColumnType("decimal(15, 8)");

                entity.Property(e => e.FuncionNbr).HasColumnName("FUNCION_NBR");

                entity.Property(e => e.MontoSal)
                    .HasColumnName("MONTO_SAL")
                    .HasColumnType("decimal(21, 5)");

                entity.Property(e => e.MovimientoDate)
                    .HasColumnName("MOVIMIENTO_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.MttoDate)
                    .HasColumnName("MTTO_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MttoUsr)
                    .IsRequired()
                    .HasColumnName("MTTO_USR")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PrioridadNbr).HasColumnName("PRIORIDAD_NBR");

                entity.Property(e => e.PromedioCd)
                    .IsRequired()
                    .HasColumnName("PROMEDIO_CD")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SaldoSal)
                    .HasColumnName("SALDO_SAL")
                    .HasColumnType("decimal(21, 5)");

                entity.Property(e => e.SueldoSal)
                    .HasColumnName("SUELDO_SAL")
                    .HasColumnType("decimal(21, 5)");

                entity.Property(e => e.SueldoTipo)
                    .IsRequired()
                    .HasColumnName("SUELDO_TIPO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SumarizaFg).HasColumnName("SUMARIZA_FG");

                entity.Property(e => e.ValorSal)
                    .HasColumnName("VALOR_SAL")
                    .HasColumnType("decimal(21, 5)");

                entity.HasOne(d => d.CiaCdNavigation)
                    .WithMany(p => p.Historico)
                    .HasForeignKey(d => d.CiaCd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HISTORICO_CIAS");

                entity.HasOne(d => d.Maestro)
                    .WithMany(p => p.Historico)
                    .HasForeignKey(d => new { d.CiaCd, d.FichaCd })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HISTORICO_MAESTRO");
            });

            modelBuilder.Entity<HistoricoSueldos>(entity =>
            {
                entity.HasKey(e => new { e.CiaCd, e.FichaCd, e.SueldoDate, e.SueldoTipo, e.ItemNbr });

                entity.ToTable("HISTORICO_SUELDOS");

                entity.Property(e => e.CiaCd)
                    .HasColumnName("CIA_CD")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.FichaCd)
                    .HasColumnName("FICHA_CD")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SueldoDate)
                    .HasColumnName("SUELDO_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.SueldoTipo)
                    .HasColumnName("SUELDO_TIPO")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ItemNbr).HasColumnName("ITEM_NBR");

                entity.Property(e => e.ActivoFg).HasColumnName("ACTIVO_FG");

                entity.Property(e => e.CreaDate)
                    .HasColumnName("CREA_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreaUsr)
                    .IsRequired()
                    .HasColumnName("CREA_USR")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MttoDate)
                    .HasColumnName("MTTO_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MttoUsr)
                    .IsRequired()
                    .HasColumnName("MTTO_USR")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SueldoSal)
                    .HasColumnName("SUELDO_SAL")
                    .HasColumnType("decimal(21, 5)");

                entity.HasOne(d => d.CiaCdNavigation)
                    .WithMany(p => p.HistoricoSueldos)
                    .HasForeignKey(d => d.CiaCd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HISTORICO_SUELDOS_CIAS");

                entity.HasOne(d => d.Maestro)
                    .WithMany(p => p.HistoricoSueldos)
                    .HasForeignKey(d => new { d.CiaCd, d.FichaCd })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HISTORICO_SUELDOS_MAESTRO");
            });

            modelBuilder.Entity<InterfazControl>(entity =>
            {
                entity.HasKey(e => new { e.CiaCd, e.ItemNbr });

                entity.ToTable("INTERFAZ_CONTROL");

                entity.Property(e => e.CiaCd)
                    .HasColumnName("CIA_CD")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.ItemNbr).HasColumnName("ITEM_NBR");

                entity.Property(e => e.ActivoFg).HasColumnName("ACTIVO_FG");

                entity.Property(e => e.ArchivoInterfaz)
                    .IsRequired()
                    .HasColumnName("ARCHIVO_INTERFAZ")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ArchivoNm)
                    .IsRequired()
                    .HasColumnName("ARCHIVO_NM")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CreaDate)
                    .HasColumnName("CREA_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreaUsr)
                    .IsRequired()
                    .HasColumnName("CREA_USR")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EjecutarDate)
                    .HasColumnName("EJECUTAR_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.EjecutarFg)
                    .HasColumnName("EJECUTAR_FG")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FrecuenciaNbr).HasColumnName("FRECUENCIA_NBR");

                entity.Property(e => e.InterfazDate)
                    .HasColumnName("INTERFAZ_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.InterfazDesc)
                    .IsRequired()
                    .HasColumnName("INTERFAZ_DESC")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ItemTbl).HasColumnName("ITEM_TBL");

                entity.Property(e => e.MttoDate)
                    .HasColumnName("MTTO_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.MttoUsr)
                    .IsRequired()
                    .HasColumnName("MTTO_USR")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CiaCdNavigation)
                    .WithMany(p => p.InterfazControl)
                    .HasForeignKey(d => d.CiaCd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_INTERFAZ_CONTROL_CIAS");
            });

            modelBuilder.Entity<InterfazEstructura>(entity =>
            {
                entity.HasKey(e => new { e.ColumnaNm, e.CiaCd, e.ArchivoNm, e.ArchivoIoCd })
                    .HasName("TFILES_STRUCTURE_XP");

                entity.ToTable("INTERFAZ_ESTRUCTURA");

                entity.Property(e => e.ColumnaNm)
                    .HasColumnName("COLUMNA_NM")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CiaCd)
                    .HasColumnName("CIA_CD")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.ArchivoNm)
                    .HasColumnName("ARCHIVO_NM")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ArchivoIoCd)
                    .HasColumnName("ARCHIVO_IO_CD")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CheckTableNm)
                    .IsRequired()
                    .HasColumnName("CHECK_TABLE_NM")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CreaDate)
                    .HasColumnName("CREA_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreaUsr)
                    .IsRequired()
                    .HasColumnName("CREA_USR")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DataTipo)
                    .IsRequired()
                    .HasColumnName("DATA_TIPO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('A')");

                entity.Property(e => e.DecimalesQty).HasColumnName("DECIMALES_QTY");

                entity.Property(e => e.FormatoTxt)
                    .IsRequired()
                    .HasColumnName("FORMATO_TXT")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InicioQty).HasColumnName("INICIO_QTY");

                entity.Property(e => e.LongitudQty).HasColumnName("LONGITUD_QTY");

                entity.Property(e => e.MttoDate)
                    .HasColumnName("MTTO_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.MttoUsr)
                    .IsRequired()
                    .HasColumnName("MTTO_USR")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CiaCdNavigation)
                    .WithMany(p => p.InterfazEstructura)
                    .HasForeignKey(d => d.CiaCd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_INTERFAZ_ESTRUCTURA_CIAS");
            });

            modelBuilder.Entity<Maestro>(entity =>
            {
                entity.HasKey(e => new { e.CiaCd, e.FichaCd });

                entity.ToTable("MAESTRO");

                entity.Property(e => e.CiaCd)
                    .HasColumnName("CIA_CD")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.FichaCd)
                    .HasColumnName("FICHA_CD")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CargoCd)
                    .IsRequired()
                    .HasColumnName("CARGO_CD")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CreaDate)
                    .HasColumnName("CREA_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CreaUsr)
                    .IsRequired()
                    .HasColumnName("CREA_USR")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DptoCd)
                    .IsRequired()
                    .HasColumnName("DPTO_CD")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IngresoDate)
                    .HasColumnName("INGRESO_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.JefeCd)
                    .IsRequired()
                    .HasColumnName("JEFE_CD")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MttoDate)
                    .HasColumnName("MTTO_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MttoUsr)
                    .IsRequired()
                    .HasColumnName("MTTO_USR")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NivelNbr).HasColumnName("NIVEL_NBR");

                entity.Property(e => e.NivelOrg).HasColumnName("NIVEL_ORG");

                entity.Property(e => e.NominaCd)
                    .IsRequired()
                    .HasColumnName("NOMINA_CD")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.RetiroDate)
                    .HasColumnName("RETIRO_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.RetiroFg).HasColumnName("RETIRO_FG");

                entity.Property(e => e.SindicatoFg).HasColumnName("SINDICATO_FG");

                entity.Property(e => e.Sueldo1Sal)
                    .HasColumnName("SUELDO1_SAL")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.Sueldo2Sal)
                    .HasColumnName("SUELDO2_SAL")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.Sueldo3Sal)
                    .HasColumnName("SUELDO3_SAL")
                    .HasColumnType("decimal(18, 5)");

                entity.HasOne(d => d.CiaCdNavigation)
                    .WithMany(p => p.Maestro)
                    .HasForeignKey(d => d.CiaCd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MAESTRO_CIAS");
            });

            modelBuilder.Entity<MaestroDatos>(entity =>
            {
                entity.HasKey(e => new { e.CiaCd, e.FichaCd, e.ParentescoNbr, e.ItemNbr })
                    .HasName("MAESTRO_DATOS_XP");

                entity.ToTable("MAESTRO_DATOS");

                entity.Property(e => e.CiaCd)
                    .HasColumnName("CIA_CD")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.FichaCd)
                    .HasColumnName("FICHA_CD")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ParentescoNbr).HasColumnName("PARENTESCO_NBR");

                entity.Property(e => e.ItemNbr).HasColumnName("ITEM_NBR");

                entity.Property(e => e.CedulaNac)
                    .IsRequired()
                    .HasColumnName("CEDULA_NAC")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CedulaNbr)
                    .IsRequired()
                    .HasColumnName("CEDULA_NBR")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CreaDate)
                    .HasColumnName("CREA_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CreaUsr)
                    .IsRequired()
                    .HasColumnName("CREA_USR")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CuentaBco)
                    .IsRequired()
                    .HasColumnName("CUENTA_BCO")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CuentaNro).HasColumnName("CUENTA_NRO");

                entity.Property(e => e.DepositoBco)
                    .IsRequired()
                    .HasColumnName("DEPOSITO_BCO")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EdocivilNbr).HasColumnName("EDOCIVIL_NBR");

                entity.Property(e => e.EmailTxt)
                    .IsRequired()
                    .HasColumnName("EMAIL_TXT")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FichaNm)
                    .IsRequired()
                    .HasColumnName("FICHA_NM")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MttoDate)
                    .HasColumnName("MTTO_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MttoUsr)
                    .IsRequired()
                    .HasColumnName("MTTO_USR")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NacimientoDate)
                    .HasColumnName("NACIMIENTO_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.PasaporteNbr)
                    .IsRequired()
                    .HasColumnName("PASAPORTE_NBR")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProfesionNbr).HasColumnName("PROFESION_NBR");

                entity.Property(e => e.RifNbr)
                    .IsRequired()
                    .HasColumnName("RIF_NBR")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RifTipo)
                    .IsRequired()
                    .HasColumnName("RIF_TIPO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SexoNbr).HasColumnName("SEXO_NBR");

                entity.Property(e => e.SsoNbr)
                    .IsRequired()
                    .HasColumnName("SSO_NBR")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.CiaCdNavigation)
                    .WithMany(p => p.MaestroDatos)
                    .HasForeignKey(d => d.CiaCd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MAESTRO_DATOS_CIAS");

                entity.HasOne(d => d.Maestro)
                    .WithMany(p => p.MaestroDatos)
                    .HasForeignKey(d => new { d.CiaCd, d.FichaCd })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MAESTRO_DATOS_MAESTRO");
            });

            modelBuilder.Entity<Procesos>(entity =>
            {
                entity.HasKey(e => new { e.CiaCd, e.ProcesoNbr });

                entity.ToTable("PROCESOS");

                entity.Property(e => e.CiaCd)
                    .HasColumnName("CIA_CD")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.ProcesoNbr).HasColumnName("PROCESO_NBR");

                entity.Property(e => e.ActivoFg)
                    .HasColumnName("ACTIVO_FG")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CreaDate)
                    .HasColumnName("CREA_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreaUsr)
                    .IsRequired()
                    .HasColumnName("CREA_USR")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MttoDate)
                    .HasColumnName("MTTO_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MttoUsr)
                    .IsRequired()
                    .HasColumnName("MTTO_USR")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProcesoDesc)
                    .IsRequired()
                    .HasColumnName("PROCESO_DESC")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.CiaCdNavigation)
                    .WithMany(p => p.Procesos)
                    .HasForeignKey(d => d.CiaCd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PROCESOS_CIAS");
            });

            modelBuilder.Entity<Profesiones>(entity =>
            {
                entity.HasKey(e => new { e.CiaCd, e.FichaCd, e.ParentescoNbr, e.ItemNbr, e.ProfesionNbr });

                entity.ToTable("PROFESIONES");

                entity.Property(e => e.CiaCd)
                    .HasColumnName("CIA_CD")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.FichaCd)
                    .HasColumnName("FICHA_CD")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ParentescoNbr).HasColumnName("PARENTESCO_NBR");

                entity.Property(e => e.ItemNbr).HasColumnName("ITEM_NBR");

                entity.Property(e => e.ProfesionNbr).HasColumnName("PROFESION_NBR");

                entity.Property(e => e.ActivoFg)
                    .HasColumnName("ACTIVO_FG")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CreaDate)
                    .HasColumnName("CREA_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreaUsr)
                    .IsRequired()
                    .HasColumnName("CREA_USR")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GraduacionDate)
                    .HasColumnName("GRADUACION_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.MttoDate)
                    .HasColumnName("MTTO_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MttoUsr)
                    .IsRequired()
                    .HasColumnName("MTTO_USR")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.CiaCdNavigation)
                    .WithMany(p => p.Profesiones)
                    .HasForeignKey(d => d.CiaCd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PROFESIONES_CIAS");

                entity.HasOne(d => d.Maestro)
                    .WithMany(p => p.Profesiones)
                    .HasForeignKey(d => new { d.CiaCd, d.FichaCd })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PROFESIONES_MAESTRO");

                entity.HasOne(d => d.MaestroDatos)
                    .WithMany(p => p.Profesiones)
                    .HasForeignKey(d => new { d.CiaCd, d.FichaCd, d.ParentescoNbr, d.ItemNbr })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PROFESIONES_MAESTRO_DATOS");
            });

            modelBuilder.Entity<Promedios>(entity =>
            {
                entity.HasKey(e => new { e.CiaCd, e.NominaCd, e.PromedioCd });

                entity.ToTable("PROMEDIOS");

                entity.Property(e => e.CiaCd)
                    .HasColumnName("CIA_CD")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.NominaCd)
                    .HasColumnName("NOMINA_CD")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.PromedioCd)
                    .HasColumnName("PROMEDIO_CD")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.ActivoFg).HasColumnName("ACTIVO_FG");

                entity.Property(e => e.CreaDate)
                    .HasColumnName("CREA_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreaUsr)
                    .IsRequired()
                    .HasColumnName("CREA_USR")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MttoDate)
                    .HasColumnName("MTTO_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.MttoUsr)
                    .IsRequired()
                    .HasColumnName("MTTO_USR")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PromedioDesc)
                    .IsRequired()
                    .HasColumnName("PROMEDIO_DESC")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SalarioNbr).HasColumnName("SALARIO_NBR");

                entity.HasOne(d => d.CiaCdNavigation)
                    .WithMany(p => p.Promedios)
                    .HasForeignKey(d => d.CiaCd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PROMEDIOS_CIAS");
            });

            modelBuilder.Entity<PromediosConceptos>(entity =>
            {
                entity.HasKey(e => new { e.CiaCd, e.NominaCd, e.PromedioCd, e.ConceptoNbr });

                entity.ToTable("PROMEDIOS_CONCEPTOS");

                entity.Property(e => e.CiaCd)
                    .HasColumnName("CIA_CD")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.NominaCd)
                    .HasColumnName("NOMINA_CD")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.PromedioCd)
                    .HasColumnName("PROMEDIO_CD")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.ConceptoNbr).HasColumnName("CONCEPTO_NBR");

                entity.Property(e => e.ActivoFg).HasColumnName("ACTIVO_FG");

                entity.Property(e => e.CreaDate)
                    .HasColumnName("CREA_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreaUsr)
                    .IsRequired()
                    .HasColumnName("CREA_USR")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MttoDate)
                    .HasColumnName("MTTO_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.MttoUsr)
                    .IsRequired()
                    .HasColumnName("MTTO_USR")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CiaCdNavigation)
                    .WithMany(p => p.PromediosConceptos)
                    .HasForeignKey(d => d.CiaCd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PROMEDIOS_CONCEPTOS_CIAS");

                entity.HasOne(d => d.Promedios)
                    .WithMany(p => p.PromediosConceptos)
                    .HasForeignKey(d => new { d.CiaCd, d.NominaCd, d.PromedioCd })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PROMEDIOS_CONCEPTOS_PROMEDIOS");
            });

            modelBuilder.Entity<PromediosDetalle>(entity =>
            {
                entity.HasKey(e => new { e.CiaCd, e.NominaCd, e.FichaCd, e.AnoNbr, e.MesNbr, e.PeriodoNbr, e.PromedioCd });

                entity.ToTable("PROMEDIOS_DETALLE");

                entity.Property(e => e.CiaCd)
                    .HasColumnName("CIA_CD")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.NominaCd)
                    .HasColumnName("NOMINA_CD")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.FichaCd)
                    .HasColumnName("FICHA_CD")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AnoNbr).HasColumnName("ANO_NBR");

                entity.Property(e => e.MesNbr).HasColumnName("MES_NBR");

                entity.Property(e => e.PeriodoNbr).HasColumnName("PERIODO_NBR");

                entity.Property(e => e.PromedioCd)
                    .HasColumnName("PROMEDIO_CD")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.ActivoFg).HasColumnName("ACTIVO_FG");

                entity.Property(e => e.CantidadQty)
                    .HasColumnName("CANTIDAD_QTY")
                    .HasColumnType("decimal(15, 5)");

                entity.Property(e => e.CreaDate)
                    .HasColumnName("CREA_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreaUsr)
                    .IsRequired()
                    .HasColumnName("CREA_USR")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MttoDate)
                    .HasColumnName("MTTO_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.MttoUsr)
                    .IsRequired()
                    .HasColumnName("MTTO_USR")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ValorSal)
                    .HasColumnName("VALOR_SAL")
                    .HasColumnType("decimal(21, 5)");

                entity.HasOne(d => d.CiaCdNavigation)
                    .WithMany(p => p.PromediosDetalle)
                    .HasForeignKey(d => d.CiaCd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PROMEDIOS_DETALLE_CIAS");

                entity.HasOne(d => d.Promedios)
                    .WithMany(p => p.PromediosDetalle)
                    .HasForeignKey(d => new { d.CiaCd, d.NominaCd, d.PromedioCd })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PROMEDIOS_DETALLE_PROMEDIOS");
            });

            modelBuilder.Entity<Saldos>(entity =>
            {
                entity.HasKey(e => new { e.CiaCd, e.NominaCd, e.FichaCd, e.ConceptoNbr });

                entity.ToTable("SALDOS");

                entity.Property(e => e.CiaCd)
                    .HasColumnName("CIA_CD")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.NominaCd)
                    .HasColumnName("NOMINA_CD")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.FichaCd)
                    .HasColumnName("FICHA_CD")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ConceptoNbr).HasColumnName("CONCEPTO_NBR");

                entity.Property(e => e.ActivoFg).HasColumnName("ACTIVO_FG");

                entity.Property(e => e.CantidadQty)
                    .HasColumnName("CANTIDAD_QTY")
                    .HasColumnType("decimal(15, 5)");

                entity.Property(e => e.CreaDate)
                    .HasColumnName("CREA_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreaUsr)
                    .IsRequired()
                    .HasColumnName("CREA_USR")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MttoDate)
                    .HasColumnName("MTTO_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MttoUsr)
                    .IsRequired()
                    .HasColumnName("MTTO_USR")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SaldoSal)
                    .HasColumnName("SALDO_SAL")
                    .HasColumnType("decimal(21, 5)");

                entity.Property(e => e.ValorSal)
                    .HasColumnName("VALOR_SAL")
                    .HasColumnType("decimal(21, 5)");

                entity.HasOne(d => d.CiaCdNavigation)
                    .WithMany(p => p.Saldos)
                    .HasForeignKey(d => d.CiaCd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SALDOS_CIAS");

                entity.HasOne(d => d.Maestro)
                    .WithMany(p => p.Saldos)
                    .HasForeignKey(d => new { d.CiaCd, d.FichaCd })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SALDOS_MAESTRO");
            });

            modelBuilder.Entity<Tablas>(entity =>
            {
                entity.HasKey(e => new { e.TablaNbr, e.ItemNbr })
                    .HasName("TABLAS_XP");

                entity.ToTable("TABLAS");

                entity.Property(e => e.TablaNbr).HasColumnName("TABLA_NBR");

                entity.Property(e => e.ItemNbr).HasColumnName("ITEM_NBR");

                entity.Property(e => e.ActivoFg)
                    .HasColumnName("ACTIVO_FG")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CreaDate)
                    .HasColumnName("CREA_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CreaUsr)
                    .IsRequired()
                    .HasColumnName("CREA_USR")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MttoDate)
                    .HasColumnName("MTTO_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MttoUsr)
                    .IsRequired()
                    .HasColumnName("MTTO_USR")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TablaDesc)
                    .IsRequired()
                    .HasColumnName("TABLA_DESC")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Telefonos>(entity =>
            {
                entity.HasKey(e => new { e.CiaCd, e.FichaCd, e.ParentescoNbr, e.ItemNbr })
                    .HasName("TELEFONOS_XP");

                entity.ToTable("TELEFONOS");

                entity.Property(e => e.CiaCd)
                    .HasColumnName("CIA_CD")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.FichaCd)
                    .HasColumnName("FICHA_CD")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ParentescoNbr).HasColumnName("PARENTESCO_NBR");

                entity.Property(e => e.ItemNbr).HasColumnName("ITEM_NBR");

                entity.Property(e => e.ActivoFg).HasColumnName("ACTIVO_FG");

                entity.Property(e => e.CreaDate)
                    .HasColumnName("CREA_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreaUsr)
                    .IsRequired()
                    .HasColumnName("CREA_USR")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdentificadorCd)
                    .IsRequired()
                    .HasColumnName("IDENTIFICADOR_CD")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.MttoDate)
                    .HasColumnName("MTTO_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MttoUsr)
                    .IsRequired()
                    .HasColumnName("MTTO_USR")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OperadoraNbr)
                    .IsRequired()
                    .HasColumnName("OPERADORA_NBR")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.ReferenciaDesc)
                    .IsRequired()
                    .HasColumnName("REFERENCIA_DESC")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TelefonoNbr)
                    .IsRequired()
                    .HasColumnName("TELEFONO_NBR")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.CiaCdNavigation)
                    .WithMany(p => p.Telefonos)
                    .HasForeignKey(d => d.CiaCd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TELEFONOS_CIAS");

                entity.HasOne(d => d.Maestro)
                    .WithMany(p => p.Telefonos)
                    .HasForeignKey(d => new { d.CiaCd, d.FichaCd })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TELEFONOS_MAESTRO");

                entity.HasOne(d => d.MaestroDatos)
                    .WithOne(p => p.Telefonos)
                    .HasForeignKey<Telefonos>(d => new { d.CiaCd, d.FichaCd, d.ParentescoNbr, d.ItemNbr })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TELEFONOS_MAESTRO_DATOS");
            });

            modelBuilder.Entity<TipoNomina>(entity =>
            {
                entity.HasKey(e => new { e.CiaCd, e.NominaCd });

                entity.ToTable("TIPO_NOMINA");

                entity.Property(e => e.CiaCd)
                    .HasColumnName("CIA_CD")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.NominaCd)
                    .HasColumnName("NOMINA_CD")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.ActivoFg).HasColumnName("ACTIVO_FG");

                entity.Property(e => e.CreaDate)
                    .HasColumnName("CREA_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CreaUsr)
                    .IsRequired()
                    .HasColumnName("CREA_USR")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FrecuenciaNbr).HasColumnName("FRECUENCIA_NBR");

                entity.Property(e => e.MttoDate)
                    .HasColumnName("MTTO_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MttoUsr)
                    .IsRequired()
                    .HasColumnName("MTTO_USR")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NominaDesc)
                    .IsRequired()
                    .HasColumnName("NOMINA_DESC")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.CiaCdNavigation)
                    .WithMany(p => p.TipoNomina)
                    .HasForeignKey(d => d.CiaCd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TIPO_NOMINA_CIAS");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => new { e.CiaCd, e.LoginUsr, e.LoginPwd, e.CedulaNbr })
                    .HasName("USUARIOS_XP");

                entity.ToTable("USUARIOS");

                entity.Property(e => e.CiaCd)
                    .HasColumnName("CIA_CD")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.LoginUsr)
                    .HasColumnName("LOGIN_USR")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LoginPwd)
                    .HasColumnName("LOGIN_PWD")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CedulaNbr)
                    .HasColumnName("CEDULA_NBR")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ActivoFg).HasColumnName("ACTIVO_FG");

                entity.Property(e => e.CreaDate)
                    .HasColumnName("CREA_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreaUsr)
                    .HasColumnName("CREA_USR")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FotoImg)
                    .HasColumnName("FOTO_IMG")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MttoDate)
                    .HasColumnName("MTTO_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.MttoUsr)
                    .HasColumnName("MTTO_USR")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CiaCdNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.CiaCd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USUARIOS_CIAS");
            });
        }
    }
}
