USE [master]
GO
IF EXISTS (Select name from sys.databases where name = N'ReservasHotel')
	ALTER DATABASE [ReservasHotel] set single_user WITH rollback IMMEDIATE
go
	
IF EXISTS (Select name from sys.databases where name = N'ReservasHotel')
	DROP DATABASE [ReservasHotel]
GO


/****** Object:  Database [ReservasHotel]    Script Date: 5/16/2022 1:49:08 PM ******/
CREATE DATABASE [ReservasHotel]
 CONTAINMENT = NONE
GO
ALTER DATABASE [ReservasHotel] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ReservasHotel].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ReservasHotel] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ReservasHotel] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ReservasHotel] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ReservasHotel] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ReservasHotel] SET ARITHABORT OFF 
GO
ALTER DATABASE [ReservasHotel] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ReservasHotel] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ReservasHotel] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ReservasHotel] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ReservasHotel] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ReservasHotel] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ReservasHotel] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ReservasHotel] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ReservasHotel] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ReservasHotel] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ReservasHotel] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ReservasHotel] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ReservasHotel] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ReservasHotel] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ReservasHotel] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ReservasHotel] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ReservasHotel] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ReservasHotel] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ReservasHotel] SET  MULTI_USER 
GO
ALTER DATABASE [ReservasHotel] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ReservasHotel] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ReservasHotel] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ReservasHotel] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [ReservasHotel] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ReservasHotel] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ReservasHotel] SET QUERY_STORE = OFF
GO
USE [ReservasHotel]
GO
/****** Object:  Table [dbo].[Administrador]    Script Date: 5/16/2022 1:49:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Administrador](
	[administrador_id] [bigint] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[is_active] [bit] NOT NULL,
 CONSTRAINT [PK_Administrador] PRIMARY KEY CLUSTERED 
(
	[administrador_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 5/16/2022 1:49:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[IdCliente] [bigint] IDENTITY(1,1) NOT NULL,
	[NombreCompleto] [nvarchar](50) NULL,
	[Direccion] [nvarchar](55) NULL,
	[Telefono] [nvarchar](30) NULL,
	[EstadoCliente] [bit] NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Habitacion]    Script Date: 5/16/2022 1:49:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Habitacion](
	[idhabitacion] [bigint] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[capacidad] [tinyint] NOT NULL,
 CONSTRAINT [PK_Habitacion] PRIMARY KEY CLUSTERED 
(
	[idhabitacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Historial]    Script Date: 5/16/2022 1:49:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Historial](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [varchar](50) NULL,
	[Fecha] [datetime] NULL,
 CONSTRAINT [PK_Historial] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hotel]    Script Date: 5/16/2022 1:49:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hotel](
	[idhotel] [bigint] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[descripcion] [varchar](1000) NOT NULL,
	[categoria] [tinyint] NOT NULL,
	[domicilio] [varchar](100) NOT NULL,
	[localidad] [varchar](50) NOT NULL,
	[provincia] [varchar](50) NOT NULL,
	[codpostal] [varchar](50) NOT NULL,
	[telefono] [varchar](50) NOT NULL,
	[administrador_id] [bigint] NOT NULL,
 CONSTRAINT [PK_Hotel] PRIMARY KEY CLUSTERED 
(
	[idhotel] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reserva]    Script Date: 5/16/2022 1:49:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reserva](
	[idreserva] [bigint] IDENTITY(1,1) NOT NULL,
	[fechainicio] [datetime] NOT NULL,
	[fechafin] [datetime2](7) NOT NULL,
	[precio] [money] NOT NULL,
	[ocupacion] [tinyint] NOT NULL,
	[nombretomador] [varchar](100) NOT NULL,
	[cantidad] [int] NOT NULL,
	[cliente_id] [bigint] NULL,
	[usuario_id] [bigint] NULL,
	[hotel_id] [bigint] NULL,
	[habitacion_id] [bigint] NULL,
 CONSTRAINT [PK_Reserva] PRIMARY KEY CLUSTERED 
(
	[idreserva] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoHabitacion]    Script Date: 5/16/2022 1:49:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoHabitacion](
	[tipoHabitacion_id] [bigint] IDENTITY(1,1) NOT NULL,
	[hotel_id] [bigint] NOT NULL,
	[habitacion_id] [bigint] NOT NULL,
	[descripcion] [varchar](1000) NOT NULL,
	[precio] [money] NOT NULL,
	[numhabitaciones] [tinyint] NOT NULL,
 CONSTRAINT [PK_TipoHabitacion] PRIMARY KEY CLUSTERED 
(
	[tipoHabitacion_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 5/16/2022 1:49:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[idusuario] [bigint] IDENTITY(1,1) NOT NULL,
	[usuario] [varchar](50) NULL,
	[nombres] [varchar](50) NULL,
	[correo] [varchar](255) NULL,
	[clave] [varchar](60) NULL,
	[is_active] [bit] NOT NULL,
	[is_admin] [bit] NOT NULL,
	[fechacreacion] [datetime] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[idusuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Administrador] ON 
GO
INSERT [dbo].[Administrador] ([administrador_id], [nombre], [is_active]) VALUES (1, N'Robot2', 1)
GO
INSERT [dbo].[Administrador] ([administrador_id], [nombre], [is_active]) VALUES (3, N'Robot3', 1)
GO
INSERT [dbo].[Administrador] ([administrador_id], [nombre], [is_active]) VALUES (4, N'Robot4 ', 1)
GO
SET IDENTITY_INSERT [dbo].[Administrador] OFF
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 
GO
INSERT [dbo].[Cliente] ([IdCliente], [NombreCompleto], [Direccion], [Telefono], [EstadoCliente]) VALUES (1, N'Victor', N'Prueba', N'(849) 353-5664', 0)
GO
INSERT [dbo].[Cliente] ([IdCliente], [NombreCompleto], [Direccion], [Telefono], [EstadoCliente]) VALUES (2, N'Ramon Lopez', N'Nueva Barquita', N'(829) 435-3643', 1)
GO
SET IDENTITY_INSERT [dbo].[Cliente] OFF
GO
SET IDENTITY_INSERT [dbo].[Habitacion] ON 
GO
INSERT [dbo].[Habitacion] ([idhabitacion], [nombre], [capacidad]) VALUES (1, N'3B', 8)
GO
INSERT [dbo].[Habitacion] ([idhabitacion], [nombre], [capacidad]) VALUES (2, N'4B', 7)
GO
SET IDENTITY_INSERT [dbo].[Habitacion] OFF
GO
SET IDENTITY_INSERT [dbo].[Historial] ON 
GO
INSERT [dbo].[Historial] ([Id], [Usuario], [Fecha]) VALUES (1, N'DESKTOP-6DNDTP0\crist', CAST(N'2022-05-15T13:51:42.407' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Historial] OFF
GO
SET IDENTITY_INSERT [dbo].[Hotel] ON 
GO
INSERT [dbo].[Hotel] ([idhotel], [nombre], [descripcion], [categoria], [domicilio], [localidad], [provincia], [codpostal], [telefono], [administrador_id]) VALUES (1, N'Estrella', N'Paraiso', 5, N'Prueba', N'Prueba', N'NA', N'12424345', N'(809) 456-7882', 1)
GO
SET IDENTITY_INSERT [dbo].[Hotel] OFF
GO
SET IDENTITY_INSERT [dbo].[Reserva] ON 
GO
INSERT [dbo].[Reserva] ([idreserva], [fechainicio], [fechafin], [precio], [ocupacion], [nombretomador], [cantidad], [cliente_id], [usuario_id], [hotel_id], [habitacion_id]) VALUES (1, CAST(N'2022-05-09T00:00:00.000' AS DateTime), CAST(N'2022-05-10T00:00:00.0000000' AS DateTime2), 3400.0000, 3, N'Hugo Sanchez', 2, 2, 1, 1, 1)
GO
INSERT [dbo].[Reserva] ([idreserva], [fechainicio], [fechafin], [precio], [ocupacion], [nombretomador], [cantidad], [cliente_id], [usuario_id], [hotel_id], [habitacion_id]) VALUES (2, CAST(N'2022-05-09T00:00:00.000' AS DateTime), CAST(N'2022-05-10T00:00:00.0000000' AS DateTime2), 3300.0000, 1, N'Juan Valdez', 1, 2, 2, 1, 2)
GO
INSERT [dbo].[Reserva] ([idreserva], [fechainicio], [fechafin], [precio], [ocupacion], [nombretomador], [cantidad], [cliente_id], [usuario_id], [hotel_id], [habitacion_id]) VALUES (3, CAST(N'2022-05-15T00:00:00.000' AS DateTime), CAST(N'2022-05-15T00:00:00.0000000' AS DateTime2), 4500.0000, 2, N'Juan Marte', 2, 2, 2, 1, 2)
GO
SET IDENTITY_INSERT [dbo].[Reserva] OFF
GO
SET IDENTITY_INSERT [dbo].[TipoHabitacion] ON 
GO
INSERT [dbo].[TipoHabitacion] ([tipoHabitacion_id], [hotel_id], [habitacion_id], [descripcion], [precio], [numhabitaciones]) VALUES (1, 1, 1, N'Nuevo', 2600.0000, 5)
GO
SET IDENTITY_INSERT [dbo].[TipoHabitacion] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 
GO
INSERT [dbo].[Usuario] ([idusuario], [usuario], [nombres], [correo], [clave], [is_active], [is_admin], [fechacreacion]) VALUES (1, N'yerlin022', N'Yerlin', N'yerlin022@gmail.com', N'1234', 1, 1, CAST(N'2022-04-27T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Usuario] ([idusuario], [usuario], [nombres], [correo], [clave], [is_active], [is_admin], [fechacreacion]) VALUES (2, N'admin', N'Robot', N'robot@gmail.com', N'1234', 1, 1, CAST(N'2022-04-30T23:48:22.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
ALTER TABLE [dbo].[Administrador] ADD  CONSTRAINT [DF_Administrador_is_active]  DEFAULT ((1)) FOR [is_active]
GO
ALTER TABLE [dbo].[Usuario] ADD  CONSTRAINT [DF_Usuario_is_active]  DEFAULT ((1)) FOR [is_active]
GO
ALTER TABLE [dbo].[Usuario] ADD  CONSTRAINT [DF_Usuario_is_admin]  DEFAULT ((0)) FOR [is_admin]
GO
ALTER TABLE [dbo].[Hotel]  WITH CHECK ADD  CONSTRAINT [FK_Hotel_Administrador] FOREIGN KEY([administrador_id])
REFERENCES [dbo].[Administrador] ([administrador_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Hotel] CHECK CONSTRAINT [FK_Hotel_Administrador]
GO
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD  CONSTRAINT [FK_Reserva_Cliente] FOREIGN KEY([cliente_id])
REFERENCES [dbo].[Cliente] ([IdCliente])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Reserva] CHECK CONSTRAINT [FK_Reserva_Cliente]
GO
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD  CONSTRAINT [FK_Reserva_Habitacion] FOREIGN KEY([habitacion_id])
REFERENCES [dbo].[Habitacion] ([idhabitacion])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Reserva] CHECK CONSTRAINT [FK_Reserva_Habitacion]
GO
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD  CONSTRAINT [FK_Reserva_Hotel] FOREIGN KEY([hotel_id])
REFERENCES [dbo].[Hotel] ([idhotel])
GO
ALTER TABLE [dbo].[Reserva] CHECK CONSTRAINT [FK_Reserva_Hotel]
GO
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD  CONSTRAINT [FK_Reserva_Usuario] FOREIGN KEY([usuario_id])
REFERENCES [dbo].[Usuario] ([idusuario])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Reserva] CHECK CONSTRAINT [FK_Reserva_Usuario]
GO
ALTER TABLE [dbo].[TipoHabitacion]  WITH CHECK ADD  CONSTRAINT [FK_TipoHabitacion_Habitacion] FOREIGN KEY([habitacion_id])
REFERENCES [dbo].[Habitacion] ([idhabitacion])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TipoHabitacion] CHECK CONSTRAINT [FK_TipoHabitacion_Habitacion]
GO
ALTER TABLE [dbo].[TipoHabitacion]  WITH CHECK ADD  CONSTRAINT [FK_TipoHabitacion_Hotel] FOREIGN KEY([hotel_id])
REFERENCES [dbo].[Hotel] ([idhotel])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TipoHabitacion] CHECK CONSTRAINT [FK_TipoHabitacion_Hotel]
GO
/****** Object:  StoredProcedure [dbo].[SpCambiarEstadoCliente]    Script Date: 5/16/2022 1:49:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SpCambiarEstadoCliente](

  @IdCliente int,
 
  @EstadoCliente bit)
AS 

UPDATE Cliente SET EstadoCliente=@EstadoCliente WHERE IdCliente =@IdCliente
GO
/****** Object:  StoredProcedure [dbo].[SpEditarAdministradores]    Script Date: 5/16/2022 1:49:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SpEditarAdministradores](

 @idAdministrador bigint,
 @Nombre VARCHAR(100),
 @IsActive bit
 )
AS

 UPDATE Administrador SET nombre=@Nombre, is_active=@IsActive WHERE administrador_id=@idAdministrador





GO
/****** Object:  StoredProcedure [dbo].[SpEditarCliente]    Script Date: 5/16/2022 1:49:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SpEditarCliente](

 @IdCliente int,
 @NombreCompleto NVARCHAR(30),
 @Direccion NVARCHAR(30),
 @Telefono NVARCHAR(30)
)

AS

UPDATE Cliente SET NombreCompleto=@NombreCompleto,Direccion=@Direccion,Telefono=@Telefono WHERE IdCliente=@IdCliente
GO
/****** Object:  StoredProcedure [dbo].[SpEditarHabitaciones]    Script Date: 5/16/2022 1:49:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[SpEditarHabitaciones](

 @IdHabitacion int,
 @Nombre VARCHAR(100),
 @Capacidad int
 )
AS

 UPDATE Habitacion SET nombre=@Nombre, capacidad=@Capacidad WHERE idhabitacion=@IdHabitacion




GO
/****** Object:  StoredProcedure [dbo].[SpEditarHoteles]    Script Date: 5/16/2022 1:49:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SpEditarHoteles](
 @IdHotel bigint,
 @Nombre VARCHAR(100),
 @Descripcion VARCHAR(100),
 @Categoria tinyint,
 @Domicilio VARCHAR(100),
 @Localidad VARCHAR(50),
 @Provincia VARCHAR(50),
 @CodPostal VARCHAR(50),
 @Telefono VARCHAR(50),
 @AdministradorId bigint)
 AS

 UPDATE Hotel SET nombre = @Nombre, descripcion = @Descripcion,
 categoria =@Categoria,domicilio =@Domicilio,localidad =@Localidad,
 provincia =@Provincia,codpostal =@CodPostal,telefono= @Telefono,
 administrador_id = @AdministradorId WHERE idhotel = @IdHotel

GO
/****** Object:  StoredProcedure [dbo].[SpEditarReserva]    Script Date: 5/16/2022 1:49:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE PROC [dbo].[SpEditarReserva](

 @IdReserva bigint,
 @Fechainicio datetime,
 @FechaFin datetime2(7),
 @Precio money,
 @Ocupacion tinyint,
 @NombreTomador varchar(100),
 @Cantidad int,
 @IdCliente bigint,
 @IdUsuario bigint,
 @IdHotel bigint,
 @IdHabitacion bigint)

 AS

 UPDATE Reserva SET fechainicio= @Fechainicio, fechafin=@FechaFin,precio=@Precio,
 ocupacion =@Ocupacion,nombretomador =@NombreTomador,cantidad=@Cantidad,cliente_id=@IdCliente,
 usuario_id=@IdUsuario,hotel_id=@IdHotel,habitacion_id=@IdHabitacion WHERE idreserva =@IdReserva


GO
/****** Object:  StoredProcedure [dbo].[SpEditarTipoHabitaciones]    Script Date: 5/16/2022 1:49:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SpEditarTipoHabitaciones](

 @IdTipoHabitacion bigint,
 @IdHotel bigint,
 @IdHabitacion bigint,
 @Descripcion varchar(1000),
 @Precio money,
 @NumHabitaciones tinyint)

 AS


 UPDATE TipoHabitacion SET hotel_id = @IdHotel, habitacion_id = @IdHabitacion,descripcion =@Descripcion,
 precio =@Precio,numhabitaciones =@NumHabitaciones WHERE tipoHabitacion_id = @IdTipoHabitacion
GO
/****** Object:  StoredProcedure [dbo].[SpEditarUsuarios]    Script Date: 5/16/2022 1:49:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SpEditarUsuarios](

 @IdUsuario int,
 @Usuario VARCHAR(50),
 @Nombres VARCHAR(50),
 @Correo VARCHAR(255),
 @Clave VARCHAR(60),
 @IsActive bit,
 @IsAdmin bit)
AS

 UPDATE Usuario SET usuario=@Usuario, nombres=@Nombres,correo=@Correo, 
 clave=@Clave,is_active=@IsActive,is_admin=@IsAdmin WHERE idusuario=@IdUsuario



GO
/****** Object:  StoredProcedure [dbo].[SpEliminarAdministradores]    Script Date: 5/16/2022 1:49:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SpEliminarAdministradores](

@IdAdministrador int
)

AS

DELETE FROM Administrador WHERE administrador_id =@IdAdministrador




GO
/****** Object:  StoredProcedure [dbo].[SpEliminarCliente]    Script Date: 5/16/2022 1:49:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SpEliminarCliente](

@IdCliente int
)

AS

DELETE FROM Cliente WHERE IdCliente =@IdCliente
GO
/****** Object:  StoredProcedure [dbo].[SpEliminarHabitaciones]    Script Date: 5/16/2022 1:49:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[SpEliminarHabitaciones](

@IdHabitacion int
)

AS

DELETE FROM Habitacion WHERE idhabitacion =@IdHabitacion




GO
/****** Object:  StoredProcedure [dbo].[SpEliminarHoteles]    Script Date: 5/16/2022 1:49:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[SpEliminarHoteles](

@IdHotel int
)

AS

DELETE FROM Hotel WHERE idhotel =@IdHotel




GO
/****** Object:  StoredProcedure [dbo].[SpEliminarReserva]    Script Date: 5/16/2022 1:49:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 CREATE PROC [dbo].[SpEliminarReserva](

 @IdReserva bigint)

 AS

 DELETE FROM Reserva WHERE idreserva =@IdReserva


GO
/****** Object:  StoredProcedure [dbo].[SpEliminarTipoHabitaciones]    Script Date: 5/16/2022 1:49:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SpEliminarTipoHabitaciones](

@IdTipoHabitacion int
)

AS

DELETE FROM TipoHabitacion WHERE tipoHabitacion_id =@IdTipoHabitacion





GO
/****** Object:  StoredProcedure [dbo].[SpEliminarUsuarios]    Script Date: 5/16/2022 1:49:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SpEliminarUsuarios](

@IdUsuario int
)

AS

DELETE FROM Usuario WHERE idusuario =@IdUsuario



GO
/****** Object:  StoredProcedure [dbo].[SpInsertarAdministradores]    Script Date: 5/16/2022 1:49:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SpInsertarAdministradores](

 @Nombre VARCHAR(100),
 @IsActive bit)
 AS

 INSERT INTO Administrador VALUES(@Nombre, @IsActive)




GO
/****** Object:  StoredProcedure [dbo].[SpInsertarCliente]    Script Date: 5/16/2022 1:49:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SpInsertarCliente](

 @NombreCompleto NVARCHAR(30),
 @Direccion NVARCHAR(30),
 @Telefono NVARCHAR(30),
 @EstadoCliente bit
)

AS

INSERT INTO Cliente VALUES(@NombreCompleto,@Direccion,@Telefono,@EstadoCliente)

GO
/****** Object:  StoredProcedure [dbo].[SpInsertarHabitaciones]    Script Date: 5/16/2022 1:49:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[SpInsertarHabitaciones](

 @Nombre VARCHAR(100),
 @Capacidad tinyint)
 AS

 INSERT INTO Habitacion VALUES(@Nombre, @Capacidad)



GO
/****** Object:  StoredProcedure [dbo].[SpInsertarHoteles]    Script Date: 5/16/2022 1:49:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SpInsertarHoteles](

 @Nombre VARCHAR(100),
 @Descripcion VARCHAR(100),
 @Categoria tinyint,
 @Domicilio VARCHAR(100),
 @Localidad VARCHAR(50),
 @Provincia VARCHAR(50),
 @CodPostal VARCHAR(50),
 @Telefono VARCHAR(50),
 @AdministradorId bigint)
 AS

 INSERT INTO Hotel VALUES(@Nombre, @Descripcion,@Categoria,@Domicilio,@Localidad,@Provincia,@CodPostal,@Telefono,@AdministradorId)



GO
/****** Object:  StoredProcedure [dbo].[SpInsertarReserva]    Script Date: 5/16/2022 1:49:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SpInsertarReserva](

 @Fechainicio datetime,
 @FechaFin datetime2(7),
 @Precio money,
 @Ocupacion tinyint,
 @NombreTomador varchar(100),
 @Cantidad int,
 @IdCliente bigint,
 @IdUsuario bigint,
 @IdHotel bigint,
 @IdHabitacion bigint)

 AS

 INSERT INTO Reserva VALUES(@Fechainicio, @FechaFin,@Precio,@Ocupacion,@NombreTomador,@Cantidad,@IdCliente,@IdUsuario,@IdHotel,@IdHabitacion)


GO
/****** Object:  StoredProcedure [dbo].[SpInsertarTipoHabitaciones]    Script Date: 5/16/2022 1:49:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SpInsertarTipoHabitaciones](

 @IdHotel bigint,
 @IdHabitacion bigint,
 @Descripcion varchar(1000),
 @Precio money,
 @NumHabitaciones tinyint)

 AS

 INSERT INTO TipoHabitacion VALUES(@IdHotel, @IdHabitacion,@Descripcion,@Precio,@NumHabitaciones)


GO
/****** Object:  StoredProcedure [dbo].[SpInsertarUsuarios]    Script Date: 5/16/2022 1:49:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SpInsertarUsuarios](

 @Usuario VARCHAR(50),
 @Nombres VARCHAR(50),
 @Correo VARCHAR(255),
 @Clave VARCHAR(60),
 @IsActive bit,
 @IsAdmin bit,
 @FechaCreacion datetime)
 AS
 if(not exists(select usuario FROM Usuario where  usuario=@Usuario))
 INSERT INTO Usuario VALUES(@Usuario, @Nombres,@Correo,@Clave,@IsActive,@IsAdmin,@FechaCreacion)


GO
/****** Object:  StoredProcedure [dbo].[SpListarAdministradores]    Script Date: 5/16/2022 1:49:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SpListarAdministradores]

AS

SELECT administrador_id, nombre AS NOMBRE, is_active AS ACTIVO FROM Administrador




GO
/****** Object:  StoredProcedure [dbo].[SpListarCliente]    Script Date: 5/16/2022 1:49:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SpListarCliente]

AS

SELECT IdCliente, NombreCompleto AS NOMBRECOMPLETO, Direccion AS DIRECCION, Telefono AS TELEFONO, 
EstadoCliente AS ESTADOCLIENTE FROM Cliente WHERE EstadoCliente=1
GO
/****** Object:  StoredProcedure [dbo].[SpListarHabitacion]    Script Date: 5/16/2022 1:49:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[SpListarHabitacion]

AS

SELECT idhabitacion, nombre AS NOMBRE, capacidad AS CAPACIDAD FROM Habitacion



GO
/****** Object:  StoredProcedure [dbo].[SpListarHoteles]    Script Date: 5/16/2022 1:49:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SpListarHoteles]

AS

SELECT idhotel, H.nombre AS NOMBRE, descripcion AS DESCRIPCION, categoria AS CATEGORIA, domicilio AS DOMICILIO, 
localidad AS LOCALIDAD, provincia AS PROVINCIA,codpostal AS CODPOSTAL, telefono AS TELEFONO, A.nombre AS ADMINISTRADOR,H.administrador_id AS ADMINISTRADORID FROM Hotel AS H

INNER JOIN Administrador AS A on A.administrador_id = H.administrador_id


GO
/****** Object:  StoredProcedure [dbo].[SpListarNombreAdministradores]    Script Date: 5/16/2022 1:49:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[SpListarNombreAdministradores]

AS

SELECT administrador_id, nombre FROM Administrador



GO
/****** Object:  StoredProcedure [dbo].[SpListarNombresHabitaciones]    Script Date: 5/16/2022 1:49:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[SpListarNombresHabitaciones]

AS

SELECT idhabitacion, nombre FROM Habitacion




GO
/****** Object:  StoredProcedure [dbo].[SpListarNombresHoteles]    Script Date: 5/16/2022 1:49:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[SpListarNombresHoteles]

AS

SELECT idhotel, nombre FROM Hotel




GO
/****** Object:  StoredProcedure [dbo].[SpListarReserva]    Script Date: 5/16/2022 1:49:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[SpListarReserva]

AS
SELECT idreserva, fechainicio AS FECHAINICIO, fechafin AS FECHAFIN, precio AS PRECIO,ocupacion AS OCUPACION, nombretomador AS NOMBRETOMADOR, 
cantidad AS CANTIDAD,C.NombreCompleto AS CLIENTE,R.cliente_id AS CLIENTEID, U.nombres AS USUARIO,R.usuario_id AS USUARIOID,
H.nombre AS HOTEL,R.hotel_id AS HOTELID,HA.nombre AS HABITACION,R.habitacion_id AS HABITACIONID FROM Reserva AS R
INNER JOIN Cliente AS C ON C.IdCliente = R.cliente_id
INNER JOIN Usuario AS U ON U.idusuario = R.usuario_id
INNER JOIN Hotel AS H ON H.idhotel = R.hotel_id
INNER JOIN Habitacion AS HA ON HA.idhabitacion = R.habitacion_id
GO
/****** Object:  StoredProcedure [dbo].[SpListarTipoHabitacion]    Script Date: 5/16/2022 1:49:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SpListarTipoHabitacion]

AS

SELECT tipoHabitacion_id,H.nombre AS HOTEL,H.idhotel AS HOTELID, HA.nombre AS HABITACION,HA.idhabitacion AS HABITACIONID, T.descripcion AS DESCRIPCION, precio AS PRECIO, numhabitaciones AS NUMHABITACIONES FROM TipoHabitacion AS T
INNER JOIN Hotel AS H ON H.idhotel = T.hotel_id
INNER JOIN Habitacion AS HA ON HA.idhabitacion = T.habitacion_id


GO
/****** Object:  StoredProcedure [dbo].[SpListarUsuarios]    Script Date: 5/16/2022 1:49:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SpListarUsuarios]

AS

SELECT idusuario, usuario AS USUARIO, nombres AS NOMBRES, correo AS CORREO, clave AS CLAVE, is_active AS ACTIVO, is_admin AS ADMINISTRADOR, fechacreacion AS FECHACREACION FROM Usuario


GO
/****** Object:  StoredProcedure [dbo].[SpLogin]    Script Date: 5/16/2022 1:49:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SpLogin] 
    @Usuario varchar(50), 
    @Clave varchar(60) 
AS 
    SELECT * FROM Usuario
    WHERE usuario = @Usuario AND clave = @Clave;



GO
/****** Object:  StoredProcedure [dbo].[SpReportesReserva]    Script Date: 5/16/2022 1:49:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[SpReportesReserva]
(
  @FechaInicio datetime,
  @FechaFin datetime2(7)
)
AS

SELECT idreserva, fechainicio AS FECHAINICIO, fechafin AS FECHAFIN, precio AS PRECIO,ocupacion AS OCUPACION, nombretomador AS NOMBRETOMADOR, 
cantidad AS CANTIDAD,C.NombreCompleto AS CLIENTE,U.nombres AS USUARIO,H.nombre AS HOTEL,HA.nombre AS HABITACION FROM Reserva AS R
INNER JOIN Cliente AS C ON C.IdCliente = R.cliente_id
INNER JOIN Usuario AS U ON U.idusuario = R.usuario_id
INNER JOIN Hotel AS H ON H.idhotel = R.hotel_id
INNER JOIN Habitacion AS HA ON HA.idhabitacion = R.habitacion_id
WHERE fechainicio>=@FechaInicio  AND fechafin<=@FechaFin


GO

GO
/** Object:  Trigger [dbo].[DisHistorialArticulosRegistrados]    Script Date: 5/15/2022 1:29:19 PM **/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[DisHistorial]

on [dbo].[Reserva]
  for insert
  as
   
  begin
  SET NOCOUNT ON

  INSERT INTO Historial VALUES(SYSTEM_USER,GETDATE());

  end

GO

/** Object:  Trigger [dbo].[DIS_Reserva]    Script Date: 5/15/2022 8:33:48 PM **/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

 CREATE trigger [dbo].[DIS_Reserva]
  on [dbo].[Reserva]
  for insert
  as
   SET NOCOUNT ON
   declare @stock int
   select @stock= capacidad from Habitacion
		 join inserted
		 on inserted.habitacion_id=Habitacion.idhabitacion
		 where Habitacion.idhabitacion=inserted.habitacion_id
  if (@stock>=(select cantidad from inserted))
    UPDATE Habitacion set capacidad=capacidad-inserted.cantidad
     from Habitacion
     join inserted
     on inserted.habitacion_id=Habitacion.idhabitacion
     where idhabitacion=inserted.habitacion_id
  else
  begin
    raiserror ('Hay menos habitaciones en stock de las solicitadas para la reserva', 16, 1)
    rollback transaction
  end
GO
USE [master]
GO
ALTER DATABASE [ReservasHotel] SET  READ_WRITE 
GO



