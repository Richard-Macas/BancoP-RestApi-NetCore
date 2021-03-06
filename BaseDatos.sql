USE [master]
GO
/****** Object:  Database [BaseDatos]    Script Date: 26/06/2022 15:35:20 ******/
CREATE DATABASE [BaseDatos]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BaseDatos', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BaseDatos.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BaseDatos_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BaseDatos_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BaseDatos] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BaseDatos].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BaseDatos] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BaseDatos] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BaseDatos] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BaseDatos] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BaseDatos] SET ARITHABORT OFF 
GO
ALTER DATABASE [BaseDatos] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BaseDatos] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BaseDatos] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BaseDatos] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BaseDatos] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BaseDatos] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BaseDatos] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BaseDatos] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BaseDatos] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BaseDatos] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BaseDatos] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BaseDatos] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BaseDatos] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BaseDatos] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BaseDatos] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BaseDatos] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BaseDatos] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BaseDatos] SET RECOVERY FULL 
GO
ALTER DATABASE [BaseDatos] SET  MULTI_USER 
GO
ALTER DATABASE [BaseDatos] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BaseDatos] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BaseDatos] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BaseDatos] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BaseDatos] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BaseDatos] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'BaseDatos', N'ON'
GO
ALTER DATABASE [BaseDatos] SET QUERY_STORE = OFF
GO
USE [BaseDatos]
GO
/****** Object:  Table [dbo].[Cuenta]    Script Date: 26/06/2022 15:35:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cuenta](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NULL,
	[NumeroCuenta] [varchar](50) NOT NULL,
	[TipoCuenta] [varchar](100) NOT NULL,
	[SaldoInicial] [money] NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Cuenta] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movimiento]    Script Date: 26/06/2022 15:35:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movimiento](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdCuenta] [int] NULL,
	[Fecha] [datetime] NOT NULL,
	[TipoMovimiento] [varchar](100) NOT NULL,
	[Valor] [money] NOT NULL,
	[Saldo] [money] NOT NULL,
 CONSTRAINT [PK_Movimiento] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Persona]    Script Date: 26/06/2022 15:35:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persona](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](150) NOT NULL,
	[Genero] [varchar](100) NULL,
	[Edad] [int] NULL,
	[Identificacion] [varchar](10) NOT NULL,
	[Direccion] [varchar](150) NOT NULL,
	[Telefono] [varchar](10) NOT NULL,
	[TipoPersona] [int] NOT NULL,
	[ClienteId] [varchar](100) NULL,
	[Contrasena] [varchar](max) NULL,
	[Estado] [bit] NULL,
 CONSTRAINT [PK_Persona] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cuenta] ON 

INSERT [dbo].[Cuenta] ([Id], [IdCliente], [NumeroCuenta], [TipoCuenta], [SaldoInicial], [Estado]) VALUES (1, 1, N'478758', N'Ahorro', 2000.0000, 1)
INSERT [dbo].[Cuenta] ([Id], [IdCliente], [NumeroCuenta], [TipoCuenta], [SaldoInicial], [Estado]) VALUES (2, 2, N'225487', N'Corriente', 100.0000, 1)
INSERT [dbo].[Cuenta] ([Id], [IdCliente], [NumeroCuenta], [TipoCuenta], [SaldoInicial], [Estado]) VALUES (3, 3, N'495878', N'Ahorros', 0.0000, 1)
INSERT [dbo].[Cuenta] ([Id], [IdCliente], [NumeroCuenta], [TipoCuenta], [SaldoInicial], [Estado]) VALUES (4, 2, N'496825', N'Ahorros', 540.0000, 1)
INSERT [dbo].[Cuenta] ([Id], [IdCliente], [NumeroCuenta], [TipoCuenta], [SaldoInicial], [Estado]) VALUES (5, 1, N'585545', N'Corriente', 1000.0000, 1)
SET IDENTITY_INSERT [dbo].[Cuenta] OFF
GO
SET IDENTITY_INSERT [dbo].[Movimiento] ON 

INSERT [dbo].[Movimiento] ([Id], [IdCuenta], [Fecha], [TipoMovimiento], [Valor], [Saldo]) VALUES (1, 2, CAST(N'2022-02-10T00:00:00.000' AS DateTime), N'Depósito', 600.0000, 700.0000)
INSERT [dbo].[Movimiento] ([Id], [IdCuenta], [Fecha], [TipoMovimiento], [Valor], [Saldo]) VALUES (2, 4, CAST(N'2022-02-08T00:00:00.000' AS DateTime), N'Retiro', 540.0000, 0.0000)
SET IDENTITY_INSERT [dbo].[Movimiento] OFF
GO
SET IDENTITY_INSERT [dbo].[Persona] ON 

INSERT [dbo].[Persona] ([Id], [Nombre], [Genero], [Edad], [Identificacion], [Direccion], [Telefono], [TipoPersona], [ClienteId], [Contrasena], [Estado]) VALUES (1, N'José Lema', N'M', NULL, N'1122334455', N'Otavalo sn y principal', N'098254785', 1, N'1122334455', N'1234', 1)
INSERT [dbo].[Persona] ([Id], [Nombre], [Genero], [Edad], [Identificacion], [Direccion], [Telefono], [TipoPersona], [ClienteId], [Contrasena], [Estado]) VALUES (2, N'Marianela Montalvo', N'M', NULL, N'1112223334', N'Amazonas y NNUU', N'097548965', 1, N'1112223334', N'5678', 1)
INSERT [dbo].[Persona] ([Id], [Nombre], [Genero], [Edad], [Identificacion], [Direccion], [Telefono], [TipoPersona], [ClienteId], [Contrasena], [Estado]) VALUES (3, N'Juan Osorio', N'M', NULL, N'1234567890', N'13 de junio y Equinoccial', N'0988745670', 1, N'1234567890', N'1245', 1)
SET IDENTITY_INSERT [dbo].[Persona] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Cuenta__E039507B989C741B]    Script Date: 26/06/2022 15:35:21 ******/
ALTER TABLE [dbo].[Cuenta] ADD UNIQUE NONCLUSTERED 
(
	[NumeroCuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Persona__D6F931E528E79694]    Script Date: 26/06/2022 15:35:21 ******/
ALTER TABLE [dbo].[Persona] ADD UNIQUE NONCLUSTERED 
(
	[Identificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cuenta]  WITH CHECK ADD  CONSTRAINT [FK_CUENTA_CLIENTE_C_PERSONA] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Persona] ([Id])
GO
ALTER TABLE [dbo].[Cuenta] CHECK CONSTRAINT [FK_CUENTA_CLIENTE_C_PERSONA]
GO
ALTER TABLE [dbo].[Movimiento]  WITH CHECK ADD  CONSTRAINT [FK_MOVIMIEN_CUENTA_MO_CUENTA] FOREIGN KEY([IdCuenta])
REFERENCES [dbo].[Cuenta] ([Id])
GO
ALTER TABLE [dbo].[Movimiento] CHECK CONSTRAINT [FK_MOVIMIEN_CUENTA_MO_CUENTA]
GO
USE [master]
GO
ALTER DATABASE [BaseDatos] SET  READ_WRITE 
GO
