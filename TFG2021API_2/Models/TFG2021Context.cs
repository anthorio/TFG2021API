using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TFG2021API_2.Models
{
    public partial class TFG2021Context : DbContext
    {
        public TFG2021Context()
        {
        }

        public TFG2021Context(DbContextOptions<TFG2021Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Albaran> Albarans { get; set; }
        public virtual DbSet<AlbaranLinea> AlbaranLineas { get; set; }
        public virtual DbSet<Carrito> Carritos { get; set; }
        public virtual DbSet<CarritoLinea> CarritoLineas { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Factura> Facturas { get; set; }
        public virtual DbSet<FacturaLinea> FacturaLineas { get; set; }
        public virtual DbSet<FamiliaProducto> FamiliaProductos { get; set; }
        public virtual DbSet<Pago> Pagos { get; set; }
        public virtual DbSet<Pedido> Pedidos { get; set; }
        public virtual DbSet<PedidoLinea> PedidoLineas { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Proveedor> Proveedors { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-BUT14Q1;Database=TFG2021;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Albaran>(entity =>
            {
                entity.ToTable("Albaran");

                entity.Property(e => e.AlbaranId).HasColumnName("AlbaranID");

                entity.Property(e => e.FechaEntrega).HasColumnType("date");

                entity.Property(e => e.PedidoAlbaran).HasColumnName("Pedido_Albaran");

                entity.HasOne(d => d.PedidoAlbaranNavigation)
                    .WithMany(p => p.Albarans)
                    .HasForeignKey(d => d.PedidoAlbaran)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Albaran_Pedido");
            });

            modelBuilder.Entity<AlbaranLinea>(entity =>
            {
                entity.HasKey(e => e.LineaAlbaranId)
                    .HasName("PK_LineaAlbaran");

                entity.ToTable("AlbaranLinea");

                entity.Property(e => e.LineaAlbaranId).HasColumnName("LineaAlbaranID");

                entity.Property(e => e.AlabaranAlbaranLinea).HasColumnName("Alabaran_AlbaranLinea");

                entity.Property(e => e.Importe).HasColumnType("money");

                entity.Property(e => e.PedidoLineaAlbaranLinea).HasColumnName("PedidoLinea_AlbaranLinea");

                entity.HasOne(d => d.AlabaranAlbaranLineaNavigation)
                    .WithMany(p => p.AlbaranLineas)
                    .HasForeignKey(d => d.AlabaranAlbaranLinea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AlbaranLinea_Albaran");

                entity.HasOne(d => d.PedidoLineaAlbaranLineaNavigation)
                    .WithMany(p => p.AlbaranLineas)
                    .HasForeignKey(d => d.PedidoLineaAlbaranLinea)
                    .HasConstraintName("FK_AlbaranLinea_PedidoLinea");
            });

            modelBuilder.Entity<Carrito>(entity =>
            {
                entity.ToTable("Carrito");

                entity.Property(e => e.CarritoId).HasColumnName("CarritoID");

                entity.HasOne(d => d.UsuarioCarritoNavigation)
                    .WithMany(p => p.Carritos)
                    .HasForeignKey(d => d.UsuarioCarrito)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Carrito_Cliente");
            });

            modelBuilder.Entity<CarritoLinea>(entity =>
            {
                entity.HasKey(e => e.LineaCarritoId)
                    .HasName("PK_LineaCarrito");

                entity.ToTable("CarritoLinea");

                entity.Property(e => e.LineaCarritoId).HasColumnName("LineaCarritoID");

                entity.Property(e => e.CarritoCarritoLinea).HasColumnName("Carrito_CarritoLinea");

                entity.Property(e => e.ProductoCarritoLinea).HasColumnName("Producto_CarritoLinea");

                entity.HasOne(d => d.CarritoCarritoLineaNavigation)
                    .WithMany(p => p.CarritoLineas)
                    .HasForeignKey(d => d.CarritoCarritoLinea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CarritoLinea_Carrito");

                entity.HasOne(d => d.ProductoCarritoLineaNavigation)
                    .WithMany(p => p.CarritoLineas)
                    .HasForeignKey(d => d.ProductoCarritoLinea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CarritoLinea_Producto");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente");

                entity.Property(e => e.ClienteId).HasColumnName("ClienteID");

                entity.Property(e => e.UsuarioIdCliente).HasColumnName("UsuarioID_Cliente");

                entity.HasOne(d => d.UsuarioIdClienteNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.UsuarioIdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cliente_Usuario");
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.ToTable("Factura");

                entity.Property(e => e.FacturaId).HasColumnName("FacturaID");

                entity.Property(e => e.Estado)
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.FechaFactura).HasColumnType("datetime");

                entity.Property(e => e.InfoPedido)
                    .HasMaxLength(250)
                    .IsFixedLength(true);

                entity.Property(e => e.Iva).HasColumnName("IVA");

                entity.Property(e => e.PedidoFactura).HasColumnName("Pedido_Factura");

                entity.Property(e => e.Total).HasColumnType("money");

                entity.HasOne(d => d.PedidoFacturaNavigation)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.PedidoFactura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Factura_Pedido");
            });

            modelBuilder.Entity<FacturaLinea>(entity =>
            {
                entity.HasKey(e => e.LineaFacturaId)
                    .HasName("PK_LineaFactura");

                entity.ToTable("FacturaLinea");

                entity.Property(e => e.LineaFacturaId).HasColumnName("LineaFacturaID");

                entity.Property(e => e.FacturaFacturaLinea).HasColumnName("Factura_FacturaLinea");

                entity.Property(e => e.Importe).HasColumnType("money");

                entity.Property(e => e.ProductoFacturaLinea).HasColumnName("Producto_FacturaLinea");

                entity.HasOne(d => d.FacturaFacturaLineaNavigation)
                    .WithMany(p => p.FacturaLineas)
                    .HasForeignKey(d => d.FacturaFacturaLinea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FacturaLinea_Factura");

                entity.HasOne(d => d.ProductoFacturaLineaNavigation)
                    .WithMany(p => p.FacturaLineas)
                    .HasForeignKey(d => d.ProductoFacturaLinea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FacturaLinea_Producto");
            });

            modelBuilder.Entity<FamiliaProducto>(entity =>
            {
                entity.HasKey(e => e.FamiliaId);

                entity.ToTable("FamiliaProducto");

                entity.Property(e => e.FamiliaId).HasColumnName("FamiliaID");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250)
                    .IsFixedLength(true);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Pago>(entity =>
            {
                entity.ToTable("Pago");

                entity.Property(e => e.PagoId).HasColumnName("PagoID");

                entity.Property(e => e.Cantidad).HasColumnType("money");

                entity.Property(e => e.FacturaPago).HasColumnName("Factura_Pago");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Observaciones)
                    .HasMaxLength(250)
                    .IsFixedLength(true);

                entity.HasOne(d => d.FacturaPagoNavigation)
                    .WithMany(p => p.Pagos)
                    .HasForeignKey(d => d.FacturaPago)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pago_Pago");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.ToTable("Pedido");

                entity.Property(e => e.PedidoId).HasColumnName("PedidoID");

                entity.Property(e => e.EstadoPedido)
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.FechaPedido).HasColumnType("datetime");

                entity.Property(e => e.TipoEnvio)
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.HasOne(d => d.UsuarioPedidoNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.UsuarioPedido)
                    .HasConstraintName("FK_Pedido_Usuario");
            });

            modelBuilder.Entity<PedidoLinea>(entity =>
            {
                entity.HasKey(e => e.LineaPedidoId)
                    .HasName("PK_LineaPedido");

                entity.ToTable("PedidoLinea");

                entity.Property(e => e.LineaPedidoId).HasColumnName("LineaPedidoID");

                entity.Property(e => e.PedidoPedidoLinea).HasColumnName("Pedido_PedidoLinea");

                entity.Property(e => e.PrecioFinal).HasColumnType("money");

                entity.Property(e => e.ProductoPedidoLinea).HasColumnName("Producto_PedidoLinea");

                entity.HasOne(d => d.PedidoPedidoLineaNavigation)
                    .WithMany(p => p.PedidoLineas)
                    .HasForeignKey(d => d.PedidoPedidoLinea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PedidoLinea_Pedido");

                entity.HasOne(d => d.ProductoPedidoLineaNavigation)
                    .WithMany(p => p.PedidoLineas)
                    .HasForeignKey(d => d.ProductoPedidoLinea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PedidoLinea_Producto");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("Producto");

                entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.FamiliaProducto).HasColumnName("Familia_Producto");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.Precio).HasColumnType("money");

                entity.Property(e => e.ProveedorProducto).HasColumnName("Proveedor_Producto");

                entity.Property(e => e.UrlImagen)
                    .HasMaxLength(250)
                    .HasColumnName("URL_imagen")
                    .IsFixedLength(true);

                entity.HasOne(d => d.FamiliaProductoNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.FamiliaProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Producto_FamiliaProducto");

                entity.HasOne(d => d.ProveedorProductoNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.ProveedorProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Producto_Proveedor");
            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.ToTable("Proveedor");

                entity.Property(e => e.ProveedorId).HasColumnName("ProveedorID");

                entity.Property(e => e.CodigoPostal)
                    .HasMaxLength(5)
                    .IsFixedLength(true);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(20)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuario");

                entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.CodigoPostal)
                    .HasMaxLength(5)
                    .IsFixedLength(true);

                entity.Property(e => e.Contrasena)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(250)
                    .IsFixedLength(true);

                entity.Property(e => e.Dni)
                    .HasMaxLength(9)
                    .HasColumnName("DNI")
                    .IsFixedLength(true);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.Poblacion)
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.Rol)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsFixedLength(true);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(20)
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
