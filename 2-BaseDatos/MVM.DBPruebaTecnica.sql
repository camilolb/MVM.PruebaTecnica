USE [MVM.PruebaTecnica]
GO
/****** Object:  User [usrPruebaTecnica]    Script Date: 08/02/2019 18:12:45 ******/
CREATE USER [usrPruebaTecnica] FOR LOGIN [usrPruebaTecnica] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [usrPruebaTecnica]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [usrPruebaTecnica]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [usrPruebaTecnica]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [usrPruebaTecnica]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [usrPruebaTecnica]
GO
ALTER ROLE [db_datareader] ADD MEMBER [usrPruebaTecnica]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [usrPruebaTecnica]
GO
ALTER ROLE [db_denydatareader] ADD MEMBER [usrPruebaTecnica]
GO
ALTER ROLE [db_denydatawriter] ADD MEMBER [usrPruebaTecnica]
GO
/****** Object:  Table [dbo].[Clasificacion]    Script Date: 08/02/2019 18:12:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clasificacion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](150) NOT NULL,
	[Creado] [datetime] NOT NULL,
	[Modificado] [datetime] NULL,
 CONSTRAINT [PK_Clasificacion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Documentacion]    Script Date: 08/02/2019 18:12:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Documentacion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NombreFuncionario] [nvarchar](250) NOT NULL,
	[NumComunicacion] [int] NOT NULL,
	[IdClasificacion] [int] NOT NULL,
	[IdEmpleado] [int] NOT NULL,
	[Estado] [bit] NOT NULL,
	[Creado] [datetime] NOT NULL,
	[Modificado] [datetime] NULL,
	[Observaciones] [nvarchar](max) NULL,
 CONSTRAINT [PK_Actividad] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 08/02/2019 18:12:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleado](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](150) NOT NULL,
	[Password] [nvarchar](150) NOT NULL,
	[Creado] [datetime] NOT NULL,
	[Modificado] [datetime] NULL,
 CONSTRAINT [PK_Empleado] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Clasificacion] ON 

INSERT [dbo].[Clasificacion] ([Id], [Nombre], [Creado], [Modificado]) VALUES (1, N'Internas', CAST(0x0000A9EE01038932 AS DateTime), NULL)
INSERT [dbo].[Clasificacion] ([Id], [Nombre], [Creado], [Modificado]) VALUES (2, N'Externas', CAST(0x0000A9EE01038E55 AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Clasificacion] OFF
SET IDENTITY_INSERT [dbo].[Documentacion] ON 

INSERT [dbo].[Documentacion] ([Id], [NombreFuncionario], [NumComunicacion], [IdClasificacion], [IdEmpleado], [Estado], [Creado], [Modificado], [Observaciones]) VALUES (1, N'SADSAD', 3131, 1, 1, 0, CAST(0x0000A9EE0108DF34 AS DateTime), NULL, NULL)
INSERT [dbo].[Documentacion] ([Id], [NombreFuncionario], [NumComunicacion], [IdClasificacion], [IdEmpleado], [Estado], [Creado], [Modificado], [Observaciones]) VALUES (2, N'fdgfddfg', 6546456, 1, 1, 1, CAST(0x0000A9EE010A40A4 AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Documentacion] OFF
SET IDENTITY_INSERT [dbo].[Empleado] ON 

INSERT [dbo].[Empleado] ([Id], [Email], [Password], [Creado], [Modificado]) VALUES (1, N'clopezb@hotmail.com', N'123456', CAST(0x0000A9E800AB1242 AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Empleado] OFF
ALTER TABLE [dbo].[Clasificacion] ADD  CONSTRAINT [DF_Clasificacion_Creado]  DEFAULT (getdate()) FOR [Creado]
GO
ALTER TABLE [dbo].[Empleado] ADD  CONSTRAINT [DF_Empleado_Creado]  DEFAULT (getdate()) FOR [Creado]
GO
ALTER TABLE [dbo].[Documentacion]  WITH CHECK ADD  CONSTRAINT [FK_Documentacion_Clasificacion] FOREIGN KEY([IdClasificacion])
REFERENCES [dbo].[Clasificacion] ([Id])
GO
ALTER TABLE [dbo].[Documentacion] CHECK CONSTRAINT [FK_Documentacion_Clasificacion]
GO
ALTER TABLE [dbo].[Documentacion]  WITH CHECK ADD  CONSTRAINT [FK_Documentacion_Empleado1] FOREIGN KEY([IdEmpleado])
REFERENCES [dbo].[Empleado] ([Id])
GO
ALTER TABLE [dbo].[Documentacion] CHECK CONSTRAINT [FK_Documentacion_Empleado1]
GO
