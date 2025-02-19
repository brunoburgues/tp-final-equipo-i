USE [Ventas_Web_DB]
GO
use master 
go
create database Ventas_Web_DB2
go
use Ventas_Web_DB2
go

CREATE TABLE [dbo].[CATEGORIAS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_CATEGORIAS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO



CREATE TABLE [dbo].[ARTICULOS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	
	[Nombre] [varchar](50) NULL,
	[Descripcion] [varchar](150) NULL,
	
	[IdCategoria] [int] NULL,
	[Precio] [money] NULL,
	[EnPromocion] bit NOT NULL DEFAULT 0,
 CONSTRAINT [PK_ARTICULOS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ARTICULOS]  WITH CHECK ADD  CONSTRAINT [FK_ARTICULOS_CATEGORIAS] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[CATEGORIAS] ([Id])
GO

ALTER TABLE [dbo].[ARTICULOS] CHECK CONSTRAINT [FK_ARTICULOS_CATEGORIAS]
GO




CREATE TABLE [dbo].[IMAGENES](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdArticulo] [int] NOT NULL,
	[ImagenUrl] [varchar](1000) NOT NULL,
 CONSTRAINT [PK_IMAGENES] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[IMAGENES]  WITH CHECK ADD  CONSTRAINT [FK_IMAGENES_ARTICULOS] FOREIGN KEY([IdArticulo])
REFERENCES [dbo].[ARTICULOS] ([Id])
GO

ALTER TABLE [dbo].[IMAGENES] CHECK CONSTRAINT [FK_IMAGENES_ARTICULOS]
GO

CREATE TABLE [dbo].[CLIENTES](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Documento] [varchar](50) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Direccion] [varchar](50) NOT NULL,
	[Ciudad] [varchar](50) NOT NULL,
	[CP] [int] NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ESTADOS_CARRITO] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Estado] VARCHAR(20) NOT NULL UNIQUE
);
GO

CREATE TABLE [dbo].[CARRITO](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [IdCliente] [int] NOT NULL,
    [FechaCreacion] [datetime] NOT NULL,
	[CostoTotal] [money] NOT NULL DEFAULT 0,
	[IdEstado] [int] NOT NULL DEFAULT 2,
	[CostoEnvio] [money] NULL,
 CONSTRAINT [PK_CARRITO] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CARRITO] ADD CONSTRAINT [FK_CARRITO_CLIENTES] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Clientes] ([Id])
GO
ALTER TABLE [dbo].[CARRITO] 
ADD CONSTRAINT [FK_CARRITO_ESTADO] FOREIGN KEY([IdEstado])
REFERENCES [dbo].[ESTADOS_CARRITO] ([Id]);
GO

CREATE TABLE [dbo].[CARRITO_PRODUCTOS](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [IdCarrito] [int] NOT NULL,
    [IdArticulo] [int] NOT NULL,
    [Cantidad] [int] NOT NULL, 
    [PrecioUnitario] [money] NOT NULL,
 CONSTRAINT [PK_CARRITO_PRODUCTOS] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CARRITO_PRODUCTOS] ADD CONSTRAINT [FK_CARRITO_PRODUCTOS_CARRITO] FOREIGN KEY([IdCarrito])
REFERENCES [dbo].[CARRITO] ([Id])
GO

ALTER TABLE [dbo].[CARRITO_PRODUCTOS] 
ADD CONSTRAINT [FK_CARRITO_PRODUCTOS_CARRITO] FOREIGN KEY([IdCarrito])
REFERENCES [dbo].[CARRITO] ([Id]) 
ON DELETE CASCADE
GO

CREATE TABLE [dbo].[PAGOS](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [IdCarrito] [int] NOT NULL,
    [FechaPago] [datetime] NOT NULL,
    [MontoTotal] [money] NOT NULL,
CONSTRAINT [PK_PAGOS] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[PAGOS]  WITH CHECK ADD  CONSTRAINT [FK_PAGOS_CARRITO] FOREIGN KEY([IdCarrito])
REFERENCES [dbo].[CARRITO] ([Id])
GO
ALTER TABLE [dbo].[PAGOS] CHECK CONSTRAINT [FK_PAGOS_CARRITO]
GO
<<<<<<< HEAD

insert into CATEGORIAS values ('Mochilas'),('Perif�ricos'), ('Accesorios')
insert into ARTICULOS values ('M01', 'Mochila Porta Notebook', 'Esta mochila combina un dise�o elegante y profesional con la robustez necesaria para enfrentar el ajetreo urbano y los viajes de negocios.', 1, 1, 49999, 0),
('P03', 'Mouse Gamer Hero G502', 'Sum�rgete en el mundo de los videojuegos con el mouse gamer Logitech G Series Hero G502 en color negro', 2, 2, 64999, 0),
('P08', 'Teclado Mec�nico 75% Rk M75', 'Este teclado cuenta con un dise�o compacto con 81 teclas, por lo que es f�cil de transportar y usar en cualquier lugar.', 2, 3, 185000, 0)
=======
insert into MARCAS values ('Wilson'), ('Logitech'), ('Royal Kludge'), ('Huawei'), ('Motorola')
insert into CATEGORIAS values ('Mochilas'),('Perifericos'), ('Accesorios')
insert into ARTICULOS values ('M01', 'Mochila Porta Notebook', 'Esta mochila combina un diseño elegante y profesional con la robustez necesaria para enfrentar el ajetreo urbano y los viajes de negocios.', 1, 1, 49999, 0),
('P03', 'Mouse Gamer Hero G502', 'Sumérgete en el mundo de los videojuegos con el mouse gamer Logitech G Series Hero G502 en color negro', 2, 2, 64999, 0),
('P08', 'Teclado Mecánico 75% Rk M75', 'Este teclado cuenta con un diseño compacto con 81 teclas, por lo que es fácil de transportar y usar en cualquier lugar.', 2, 3, 185000, 0)
>>>>>>> 6639eaa14610f098d01bdde9e7d51d73a5370499

insert into imagenes values
(1,'https://http2.mlstatic.com/D_NQ_NP_703368-MLU76300898146_052024-O.webp'),
(1, 'https://http2.mlstatic.com/D_NQ_NP_842545-MLU76300482840_052024-O.webp'),
(1, 'https://http2.mlstatic.com/D_NQ_NP_747302-MLU76300769244_052024-O.webp'),
(2, 'https://http2.mlstatic.com/D_NQ_NP_701613-MLA45464844877_042021-O.webp'),
(2, 'https://http2.mlstatic.com/D_NQ_NP_987670-MLA45464844880_042021-O.webp'),
(2, 'https://http2.mlstatic.com/D_NQ_NP_793119-MLU72761228270_112023-O.webp'),
(3, 'https://http2.mlstatic.com/D_NQ_NP_767460-MLA74282172500_022024-O.webp'),
(3, 'https://http2.mlstatic.com/D_NQ_NP_848157-MLA74517144673_022024-O.webp'),
(3, 'https://http2.mlstatic.com/D_NQ_NP_616027-MLA74397845971_022024-O.webp')


insert into clientes values ('32333222', 'Doug', 'Narinas', 'doug@narinas.com','avenida 123', 'chuletas city', 1234)

INSERT INTO [dbo].[ESTADOS_CARRITO] ([Estado]) VALUES 
('Cancelado'), ('Pendiente'), ('Abonado'), 
('En preparación'), ('En camino'), ('Entregado'), ('Devuelto');
/****** Object:  Table [dbo].[Usuarios]    Script Date: 30/1/2025 19:22:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Usuarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [varchar](50) NULL,
	[Pass] [varchar](50) NULL,
	[TipoUser] [int] NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

