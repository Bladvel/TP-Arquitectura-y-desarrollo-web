USE [master]
GO
/****** Object:  Database [MOODFLIX]    Script Date: 6/9/2024 5:59:43 PM ******/
CREATE DATABASE [MOODFLIX]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MOODFLIX', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\MOODFLIX.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MOODFLIX_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\MOODFLIX_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [MOODFLIX] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MOODFLIX].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MOODFLIX] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MOODFLIX] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MOODFLIX] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MOODFLIX] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MOODFLIX] SET ARITHABORT OFF 
GO
ALTER DATABASE [MOODFLIX] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MOODFLIX] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MOODFLIX] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MOODFLIX] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MOODFLIX] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MOODFLIX] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MOODFLIX] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MOODFLIX] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MOODFLIX] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MOODFLIX] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MOODFLIX] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MOODFLIX] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MOODFLIX] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MOODFLIX] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MOODFLIX] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MOODFLIX] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MOODFLIX] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MOODFLIX] SET RECOVERY FULL 
GO
ALTER DATABASE [MOODFLIX] SET  MULTI_USER 
GO
ALTER DATABASE [MOODFLIX] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MOODFLIX] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MOODFLIX] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MOODFLIX] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MOODFLIX] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MOODFLIX] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'MOODFLIX', N'ON'
GO
ALTER DATABASE [MOODFLIX] SET QUERY_STORE = ON
GO
ALTER DATABASE [MOODFLIX] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [MOODFLIX]
GO
/****** Object:  Table [dbo].[EMOCION]    Script Date: 6/9/2024 5:59:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EMOCION](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [varchar](50) NOT NULL,
	[URI_RELATIVO] [varchar](50) NULL,
 CONSTRAINT [PK_EMOCION] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LIBRO]    Script Date: 6/9/2024 5:59:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LIBRO](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [varchar](100) NOT NULL,
	[DESCRIPCION] [varchar](max) NOT NULL,
	[FECHA] [datetime] NOT NULL,
	[AUTOR] [varchar](50) NOT NULL,
	[EDITORIAL] [varchar](50) NOT NULL,
	[ID_EMOCION] [int] NOT NULL,
	[URI_RELATIVA] [varchar](50) NULL,
 CONSTRAINT [PK_LIBRO] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PELICULA]    Script Date: 6/9/2024 5:59:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PELICULA](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [varchar](50) NOT NULL,
	[DESCRIPCION] [varchar](max) NOT NULL,
	[FECHA] [datetime] NOT NULL,
	[GENERO] [varchar](50) NOT NULL,
	[DIRECTOR] [varchar](50) NOT NULL,
	[ID_EMOCION] [int] NOT NULL,
	[URI_RELATIVO] [varchar](50) NULL,
 CONSTRAINT [PK_PELICULA] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USUARIO]    Script Date: 6/9/2024 5:59:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USUARIO](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[USERNAME] [varchar](50) NOT NULL,
	[EMAIL] [varchar](50) NOT NULL,
	[PASSWORD] [varchar](200) NOT NULL,
 CONSTRAINT [PK_USUARIO] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[EMOCION] ON 

INSERT [dbo].[EMOCION] ([ID], [NOMBRE], [URI_RELATIVO]) VALUES (1, N'Aburrido', N'Imagenes/Emociones/Aburrido.png')
INSERT [dbo].[EMOCION] ([ID], [NOMBRE], [URI_RELATIVO]) VALUES (2, N'Amoroso', N'Imagenes/Emociones/Amoroso.png')
INSERT [dbo].[EMOCION] ([ID], [NOMBRE], [URI_RELATIVO]) VALUES (3, N'Ansiedad', N'Imagenes/Emociones/Ansiedad.png')
INSERT [dbo].[EMOCION] ([ID], [NOMBRE], [URI_RELATIVO]) VALUES (4, N'Curioso', N'Imagenes/Emociones/Curioso.png')
INSERT [dbo].[EMOCION] ([ID], [NOMBRE], [URI_RELATIVO]) VALUES (5, N'Disgusto', N'Imagenes/Emociones/Disgusto.png')
INSERT [dbo].[EMOCION] ([ID], [NOMBRE], [URI_RELATIVO]) VALUES (6, N'Enojo', N'Imagenes/Emociones/Enojo.png')
INSERT [dbo].[EMOCION] ([ID], [NOMBRE], [URI_RELATIVO]) VALUES (7, N'Felicidad', N'Imagenes/Emociones/Felicidad.png')
INSERT [dbo].[EMOCION] ([ID], [NOMBRE], [URI_RELATIVO]) VALUES (8, N'Miedo', N'Imagenes/Emociones/Miedo.png')
INSERT [dbo].[EMOCION] ([ID], [NOMBRE], [URI_RELATIVO]) VALUES (9, N'Optimista', N'Imagenes/Emociones/Optimista.png')
INSERT [dbo].[EMOCION] ([ID], [NOMBRE], [URI_RELATIVO]) VALUES (10, N'Pasion', N'Imagenes/Emociones/Pasion.png')
INSERT [dbo].[EMOCION] ([ID], [NOMBRE], [URI_RELATIVO]) VALUES (11, N'Sorpresa', N'Imagenes/Emociones/Sorpresa.png')
INSERT [dbo].[EMOCION] ([ID], [NOMBRE], [URI_RELATIVO]) VALUES (12, N'Tristeza', N'Imagenes/Emociones/Tristeza.png')
SET IDENTITY_INSERT [dbo].[EMOCION] OFF
GO
SET IDENTITY_INSERT [dbo].[LIBRO] ON 

INSERT [dbo].[LIBRO] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [AUTOR], [EDITORIAL], [ID_EMOCION], [URI_RELATIVA]) VALUES (1, N'Resultados Extraordinarios', N'Técnicas y estrategias sencillas para hacer realidad tus sueños', CAST(N'2018-01-01T00:00:00.000' AS DateTime), N'Bernando Stamateas', N'B de Bolsillo', 9, NULL)
INSERT [dbo].[LIBRO] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [AUTOR], [EDITORIAL], [ID_EMOCION], [URI_RELATIVA]) VALUES (2, N'Kryptonita', N'29 de junio de 2009. Lunes por la madrugada. En la guardia del Hospital Paroissiens de Isidro Casanova ingresa herido de muerte Nafta Súper, líder de una banda criminal de la zona. Sus compañeros les exigen a los médicos que le salven la vida, mientras se atrincheran esperando la llegada de la policía.', CAST(N'2014-01-01T00:00:00.000' AS DateTime), N'Leonardo Oyola', N'Literatura Random House', 3, NULL)
INSERT [dbo].[LIBRO] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [AUTOR], [EDITORIAL], [ID_EMOCION], [URI_RELATIVA]) VALUES (3, N'Mujeres que corren con los lobos', N'La mujer salvaje una especie en peligro de extincion, que representa la escencia femenina instintiva.', CAST(N'2019-01-01T00:00:00.000' AS DateTime), N'Clarissa Pinkola Estés', N'Penguin Random House', 10, NULL)
INSERT [dbo].[LIBRO] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [AUTOR], [EDITORIAL], [ID_EMOCION], [URI_RELATIVA]) VALUES (4, N'Mi planta de naranja lima', N'En esta novela se nos cuenta la historia de Zezé. Es el menor de una familia muy pobre que tiene que afrontar muchos momentos de dolor, ya que vive en uno de los barrios más austeros de Brasil. Vivían de alquiler en un hogar muy humilde, pero no podían estar al día con los pagos. Un día, el casero exige a los padres de Zezé pagar sus deudas o, de lo contrario, tendrían que desalojar la vivienda.', CAST(N'1968-01-01T00:00:00.000' AS DateTime), N'José Mauro de Vasconcelos', N'El Ateneo', 12, NULL)
INSERT [dbo].[LIBRO] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [AUTOR], [EDITORIAL], [ID_EMOCION], [URI_RELATIVA]) VALUES (5, N'Cronicas Marcianas', N'Crónicas marcianas es una serie de relatos del escritor Ray Bradbury. Los relatos carecen de una línea argumental lineal fija, pero la referencia contextual y temporal es la misma en todos ellos: narra la llegada a Marte y la colonización del planeta por parte de los humanos.', CAST(N'1950-01-01T00:00:00.000' AS DateTime), N'Ray Bradbury', N'Doubleday & Company', 10, NULL)
INSERT [dbo].[LIBRO] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [AUTOR], [EDITORIAL], [ID_EMOCION], [URI_RELATIVA]) VALUES (6, N'El hombre en busca de sentido', N'Este libro relata las experiencias del autor en los campos de concentración nazis y explora cómo, incluso en las circunstancias más difíciles, los seres humanos pueden encontrar un sentido a su vida. La tristeza y el sufrimiento son temas centrales en su análisis de la condición humana.', CAST(N'1946-01-01T00:00:00.000' AS DateTime), N'Viktor Frankl', N'Herder', 12, NULL)
INSERT [dbo].[LIBRO] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [AUTOR], [EDITORIAL], [ID_EMOCION], [URI_RELATIVA]) VALUES (7, N'La campana de cristal', N'Esta novela semiautobiográfica narra la lucha de Esther Greenwood con la depresión y su sentimiento de alienación. La obra ofrece una visión profunda de la tristeza y la enfermedad mental.', CAST(N'1963-01-01T00:00:00.000' AS DateTime), N'Sylvia Plath', N'Harper & Row', 12, NULL)
INSERT [dbo].[LIBRO] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [AUTOR], [EDITORIAL], [ID_EMOCION], [URI_RELATIVA]) VALUES (8, N'La lentitud del mundo', N'Esta novela cuenta la historia de un hombre que enfrenta la tristeza y el dolor tras una tragedia personal. La narrativa se enfoca en su viaje emocional y su búsqueda de consuelo.', CAST(N'2000-01-01T00:00:00.000' AS DateTime), N'Nicolás Casariego', N'Siruela', 12, NULL)
INSERT [dbo].[LIBRO] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [AUTOR], [EDITORIAL], [ID_EMOCION], [URI_RELATIVA]) VALUES (9, N'La ciencia de la felicidad', N'Este libro presenta una base científica para entender cómo se puede aumentar la felicidad. Lyubomirsky ofrece estrategias prácticas basadas en investigaciones para mejorar el bienestar y la satisfacción personal.', CAST(N'2008-01-01T00:00:00.000' AS DateTime), N'Sonja Lyubomirsky', N'Urano', 7, NULL)
INSERT [dbo].[LIBRO] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [AUTOR], [EDITORIAL], [ID_EMOCION], [URI_RELATIVA]) VALUES (10, N'El arte de la felicidad', N'A través de conversaciones con el Dalai Lama, el psiquiatra Howard Cutler explora cómo la filosofía budista puede ayudar a las personas a encontrar la felicidad en sus vidas diarias.', CAST(N'1998-01-01T00:00:00.000' AS DateTime), N'Dalai Lama y Howard Cutler', N'Ediciones B', 7, NULL)
INSERT [dbo].[LIBRO] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [AUTOR], [EDITORIAL], [ID_EMOCION], [URI_RELATIVA]) VALUES (11, N'Las ventajas de ser un marginado', N'La novela se centra en Charlie, un adolescente que escribe cartas sobre su vida, abordando temas como la tristeza, la soledad y la búsqueda de identidad en medio de la turbulencia emocional de la adolescencia.', CAST(N'1999-01-01T00:00:00.000' AS DateTime), N'Stephen Chbosky', N'MTV Books', 12, NULL)
INSERT [dbo].[LIBRO] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [AUTOR], [EDITORIAL], [ID_EMOCION], [URI_RELATIVA]) VALUES (12, N'El pequeño libro del enojo', N'Este libro ofrece técnicas y consejos prácticos para manejar el enojo y convertirlo en una fuerza positiva.', CAST(N'2006-01-01T00:00:00.000' AS DateTime), N'Erika M. Hunter', N'EDAF', 6, NULL)
INSERT [dbo].[LIBRO] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [AUTOR], [EDITORIAL], [ID_EMOCION], [URI_RELATIVA]) VALUES (13, N'El manejo del enojo: Una guía para hombres', N'Este libro proporciona estrategias específicas para que los hombres puedan entender y manejar su enojo de manera efectiva.', CAST(N'2000-01-01T00:00:00.000' AS DateTime), N'Thomas J. Harbin', N'HarperCollins', 6, NULL)
INSERT [dbo].[LIBRO] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [AUTOR], [EDITORIAL], [ID_EMOCION], [URI_RELATIVA]) VALUES (14, N'Cien años de soledad', N'Esta novela épica narra la historia de la familia Buendía en el pueblo ficticio de Macondo. A lo largo de la obra, la tristeza y el sufrimiento de los personajes se entrelazan con la historia, reflejando la condición humana y la lucha contra la soledad.', CAST(N'1967-01-01T00:00:00.000' AS DateTime), N'Gabriel García Márquez', N'Editorial Sudamericana', 12, NULL)
INSERT [dbo].[LIBRO] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [AUTOR], [EDITORIAL], [ID_EMOCION], [URI_RELATIVA]) VALUES (15, N'La trampa de la felicidad', N'Russ Harris explica cómo las ideas erróneas sobre la felicidad pueden conducir a la infelicidad y ofrece herramientas basadas en la Terapia de Aceptación y Compromiso (ACT) para vivir una vida más plena y significativa.', CAST(N'2007-01-01T00:00:00.000' AS DateTime), N'Russ Harris', N'Desclée de Brouwer', 7, NULL)
INSERT [dbo].[LIBRO] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [AUTOR], [EDITORIAL], [ID_EMOCION], [URI_RELATIVA]) VALUES (16, N'El exorcista', N'Inspirado en un exorcismo real, esta novela narra el aterrador caso de posesión demoníaca de una niña y los esfuerzos de dos sacerdotes por salvarla.', CAST(N'1971-01-01T00:00:00.000' AS DateTime), N'William Peter Blatty', N'Harper & Row', 8, NULL)
INSERT [dbo].[LIBRO] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [AUTOR], [EDITORIAL], [ID_EMOCION], [URI_RELATIVA]) VALUES (17, N'Misery', N'La novela sigue a un escritor que es secuestrado y torturado por su fanática número uno, explorando el miedo al aislamiento y la obsesión.', CAST(N'1987-01-01T00:00:00.000' AS DateTime), N'Stephen King', N'Viking Press', 8, NULL)
INSERT [dbo].[LIBRO] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [AUTOR], [EDITORIAL], [ID_EMOCION], [URI_RELATIVA]) VALUES (18, N'La felicidad es el camino', N'Wayne Dyer explora el concepto de que la felicidad no es un destino, sino un camino que se debe recorrer día a día. Ofrece consejos prácticos para vivir en el presente y encontrar la alegría en la vida cotidiana.', CAST(N'2001-01-01T00:00:00.000' AS DateTime), N'Wayne W. Dyer', N'Urano', 7, NULL)
INSERT [dbo].[LIBRO] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [AUTOR], [EDITORIAL], [ID_EMOCION], [URI_RELATIVA]) VALUES (19, N'Enojo: Una guía para cuidadores', N'Orientado a quienes cuidan de otros, este libro ofrece herramientas para manejar el enojo en situaciones de estrés y cuidado.', CAST(N'1999-01-01T00:00:00.000' AS DateTime), N'Jane Middleton-Moz', N'Health Communications Inc.', 6, NULL)
INSERT [dbo].[LIBRO] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [AUTOR], [EDITORIAL], [ID_EMOCION], [URI_RELATIVA]) VALUES (20, N'La sabiduria del enojo', N'Este libro explora el enojo desde una perspectiva budista, proporcionando insights sobre cómo transformarlo en sabiduría y compasión.', CAST(N'2001-01-01T00:00:00.000' AS DateTime), N'Thich Nhat Hanh', N'HarperOne', 6, NULL)
INSERT [dbo].[LIBRO] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [AUTOR], [EDITORIAL], [ID_EMOCION], [URI_RELATIVA]) VALUES (21, N'La arquitectura de la felicidad', N'Alain de Botton analiza cómo los espacios físicos y la arquitectura pueden influir en nuestras emociones y bienestar, proponiendo que el entorno construido tiene un impacto significativo en nuestra felicidad.', CAST(N'2006-01-01T00:00:00.000' AS DateTime), N'Alain de Botton', N'Taurus', 7, NULL)
INSERT [dbo].[LIBRO] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [AUTOR], [EDITORIAL], [ID_EMOCION], [URI_RELATIVA]) VALUES (22, N'El enojo en el trabajo: Estrategias para manejar el enojo laboral', N'Proporciona técnicas para manejar el enojo y la frustración en el entorno laboral.', CAST(N'2000-01-01T00:00:00.000' AS DateTime), N'Lynne McClure', N'AMACOM', 6, NULL)
INSERT [dbo].[LIBRO] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [AUTOR], [EDITORIAL], [ID_EMOCION], [URI_RELATIVA]) VALUES (23, N'El resplandor', N'La historia sigue a Jack Torrance y su familia, quienes se mudan al aislado Hotel Overlook, donde comienzan a suceder fenómenos aterradores.', CAST(N'1977-01-01T00:00:00.000' AS DateTime), N'Stephen King', N'Doubleday', 8, NULL)
INSERT [dbo].[LIBRO] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [AUTOR], [EDITORIAL], [ID_EMOCION], [URI_RELATIVA]) VALUES (24, N'El amor en los tiempos del cólera', N'Esta novela narra la historia de amor entre Fermina Daza y Florentino Ariza, que abarca más de cincuenta años. Es un retrato profundo del amor en sus múltiples formas y el paso del tiempo.', CAST(N'1985-01-01T00:00:00.000' AS DateTime), N'Gabriel García Márquez', N'Editorial Oveja Negra', 2, NULL)
INSERT [dbo].[LIBRO] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [AUTOR], [EDITORIAL], [ID_EMOCION], [URI_RELATIVA]) VALUES (25, N'Rayuela', N'Esta obra maestra del boom latinoamericano ofrece una visión profunda y experimental del amor a través de la relación entre Horacio Oliveira y La Maga, explorando la complejidad y la ambigüedad de las emociones humanas.', CAST(N'1963-01-01T00:00:00.000' AS DateTime), N'Julio Cortázar', N'Editorial Sudamericana', 2, NULL)
INSERT [dbo].[LIBRO] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [AUTOR], [EDITORIAL], [ID_EMOCION], [URI_RELATIVA]) VALUES (26, N'Como agua para chocolate', N'En esta novela, la autora combina recetas de cocina, magia y romance para contar la historia de Tita y Pedro, cuyo amor enfrenta numerosas barreras sociales y familiares en la época de la Revolución Mexicana.', CAST(N'1989-01-01T00:00:00.000' AS DateTime), N'Laura Esquivel', N'Editorial Planeta', 2, NULL)
INSERT [dbo].[LIBRO] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [AUTOR], [EDITORIAL], [ID_EMOCION], [URI_RELATIVA]) VALUES (27, N'La paradoja del disgusto: Sobre la repulsión y la fascinación', N'Este libro explora la paradoja del disgusto, donde ciertos elementos que deberían ser repulsivos pueden generar atracción y fascinación. Menninghaus analiza cómo el disgusto juega un papel en el arte, la literatura y la cultura en general.', CAST(N'2003-01-01T00:00:00.000' AS DateTime), N'Winfried Menninghaus', N'Amorrortu Editores', 5, NULL)
INSERT [dbo].[LIBRO] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [AUTOR], [EDITORIAL], [ID_EMOCION], [URI_RELATIVA]) VALUES (28, N'El animal que cocina: Una historia natural del asco', N'Rachel Herz ofrece una exploración científica y cultural del asco, investigando sus orígenes evolutivos, su papel en nuestras vidas diarias y su impacto en nuestras decisiones alimenticias.', CAST(N'2012-01-01T00:00:00.000' AS DateTime), N'Rachel Herz', N'Ediciones Destino', 5, NULL)
INSERT [dbo].[LIBRO] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [AUTOR], [EDITORIAL], [ID_EMOCION], [URI_RELATIVA]) VALUES (29, N'El poder del ahora', N'Este libro enseña a vivir en el presente, liberándonos del pasado y del futuro para alcanzar la paz interior y la felicidad.', CAST(N'1997-01-01T00:00:00.000' AS DateTime), N'Eckhart Tolle', N'Namaste Publishing', 9, NULL)
INSERT [dbo].[LIBRO] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [AUTOR], [EDITORIAL], [ID_EMOCION], [URI_RELATIVA]) VALUES (30, N'Asco y temor: El control cultural de las emociones', N'William Ian Miller examina cómo el disgusto y el miedo han sido utilizados históricamente para controlar y regular las conductas sociales. El libro se centra en el análisis cultural y psicológico de estas emociones.', CAST(N'1997-01-01T00:00:00.000' AS DateTime), N'William Ian Miller', N'Harvard University Press', 5, NULL)
INSERT [dbo].[LIBRO] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [AUTOR], [EDITORIAL], [ID_EMOCION], [URI_RELATIVA]) VALUES (31, N'Optimismo aprendido', N'Seligman, uno de los padres de la psicología positiva, explica cómo se puede aprender y cultivar el optimismo para mejorar la vida personal y profesional.', CAST(N'1990-01-01T00:00:00.000' AS DateTime), N'Martin Seligman', N'Vintage Books', 9, NULL)
INSERT [dbo].[LIBRO] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [AUTOR], [EDITORIAL], [ID_EMOCION], [URI_RELATIVA]) VALUES (32, N'La magia del pensamiento positivo', N'Un clásico que propone técnicas y métodos para vivir una vida más optimista y alcanzar el éxito personal y profesional.', CAST(N'1952-01-01T00:00:00.000' AS DateTime), N'Norman Vincent Peale', N'Prentice Hall', 9, NULL)
INSERT [dbo].[LIBRO] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [AUTOR], [EDITORIAL], [ID_EMOCION], [URI_RELATIVA]) VALUES (33, N'El arte de no amargarse la vida', N'Ofrece herramientas y consejos prácticos para superar las preocupaciones y problemas cotidianos, fomentando una visión optimista de la vida.', CAST(N'2011-01-01T00:00:00.000' AS DateTime), N'Rafael Santandreu', N'Grijalbo', 9, NULL)
INSERT [dbo].[LIBRO] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [AUTOR], [EDITORIAL], [ID_EMOCION], [URI_RELATIVA]) VALUES (34, N'El curioso incidente del perro a medianoche', N'Esta novela sigue la historia de Christopher, un adolescente con trastorno del espectro autista, quien se embarca en una aventura para resolver el misterio del asesinato de un perro, enfrentándose a sorpresas y desafíos inesperados en el camino.', CAST(N'2003-01-01T00:00:00.000' AS DateTime), N'Mark Haddon', N'Editorial Salamandra', 11, NULL)
INSERT [dbo].[LIBRO] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [AUTOR], [EDITORIAL], [ID_EMOCION], [URI_RELATIVA]) VALUES (35, N'La sombra del viento', N'Ambientada en la Barcelona de posguerra, esta novela sigue a Daniel, un joven que descubre un libro misterioso que lo lleva a una serie de sorprendentes revelaciones sobre su ciudad, su familia y su propio destino.', CAST(N'2001-01-01T00:00:00.000' AS DateTime), N'Ruiz Zafón', N'Editorial Planeta', 11, NULL)
INSERT [dbo].[LIBRO] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [AUTOR], [EDITORIAL], [ID_EMOCION], [URI_RELATIVA]) VALUES (36, N'La insoportable levedad del ser', N'Esta obra examina la sorpresa y la incertidumbre en las relaciones humanas a través de las vidas entrelazadas de cuatro personajes en la Praga comunista y poscomunista.', CAST(N'1984-01-01T00:00:00.000' AS DateTime), N'Milan Kundera', N'Editorial Tusquets', 11, NULL)
INSERT [dbo].[LIBRO] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [AUTOR], [EDITORIAL], [ID_EMOCION], [URI_RELATIVA]) VALUES (37, N'El poder de la mente', N'En este libro, Hay explora cómo los pensamientos y las emociones afectan la salud mental, incluida la ansiedad, y ofrece técnicas para cambiar patrones mentales negativos.', CAST(N'2008-01-01T00:00:00.000' AS DateTime), N'Louise L. Hay', N'Editorial Urano', 3, NULL)
INSERT [dbo].[LIBRO] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [AUTOR], [EDITORIAL], [ID_EMOCION], [URI_RELATIVA]) VALUES (38, N'El monstruo de colores', N'Aunque es un libro infantil, ofrece una forma creativa de explorar y entender las emociones, incluida la ansiedad, a través del color y la metáfora.', CAST(N'2012-01-01T00:00:00.000' AS DateTime), N'Anna Llenas', N'Editorial Flamboyant', 3, NULL)
INSERT [dbo].[LIBRO] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [AUTOR], [EDITORIAL], [ID_EMOCION], [URI_RELATIVA]) VALUES (39, N'Vivir sin miedo: El camino a la libertad', N'Yogananda ofrece enseñanzas espirituales y prácticas para superar el miedo y la ansiedad, basadas en la filosofía del yoga.', CAST(N'2015-01-01T00:00:00.000' AS DateTime), N'Paramahansa Yogananda', N'Self-Realization Fellowship', 3, NULL)
INSERT [dbo].[LIBRO] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [AUTOR], [EDITORIAL], [ID_EMOCION], [URI_RELATIVA]) VALUES (40, N'El miedo a la libertad', N'Fromm analiza las raíces sociales y psicológicas de la ansiedad y el miedo en la sociedad moderna, explorando cómo afectan la libertad individual y colectiva.', CAST(N'2017-01-01T00:00:00.000' AS DateTime), N'Erich Fromm', N'Editorial Paidós', 3, NULL)
INSERT [dbo].[LIBRO] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [AUTOR], [EDITORIAL], [ID_EMOCION], [URI_RELATIVA]) VALUES (41, N'Sapiens: De animales a dioses', N'Este libro ofrece una visión panorámica de la historia de la humanidad, explorando cómo los humanos han evolucionado y han dado forma al mundo moderno. Harari cuestiona nuestras suposiciones sobre la historia y el futuro de nuestra especie.', CAST(N'2011-01-01T00:00:00.000' AS DateTime), N'Yuval Noah Harari', N'Debate', 4, NULL)
INSERT [dbo].[LIBRO] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [AUTOR], [EDITORIAL], [ID_EMOCION], [URI_RELATIVA]) VALUES (42, N'El gen: Una historia íntima', N'Este libro explora la historia y la ciencia de la genética, desentrañando los secretos de lo que nos hace humanos y satisfaciendo la curiosidad sobre el fundamento biológico de la vida.', CAST(N'2016-01-01T00:00:00.000' AS DateTime), N'Siddhartha Mukherjee', N'Debate', 4, NULL)
INSERT [dbo].[LIBRO] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [AUTOR], [EDITORIAL], [ID_EMOCION], [URI_RELATIVA]) VALUES (43, N'El universo en tu mano', N'Galfard lleva al lector en un viaje imaginativo y educativo a través del universo, respondiendo a preguntas fundamentales sobre el espacio y el tiempo de una manera accesible y fascinante.', CAST(N'2016-01-01T00:00:00.000' AS DateTime), N'Christophe Galfard', N'Blackie Books', 4, NULL)
INSERT [dbo].[LIBRO] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [AUTOR], [EDITORIAL], [ID_EMOCION], [URI_RELATIVA]) VALUES (44, N'El libro de la curiosidad', N'Wagensberg recopila reflexiones y ensayos sobre la curiosidad y el deseo de saber, explorando cómo esta emoción impulsa la ciencia y el conocimiento.', CAST(N'2005-01-01T00:00:00.000' AS DateTime), N'Jorge Wagensberg', N'Tusquets Editores', 4, NULL)
SET IDENTITY_INSERT [dbo].[LIBRO] OFF
GO
SET IDENTITY_INSERT [dbo].[PELICULA] ON 

INSERT [dbo].[PELICULA] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [GENERO], [DIRECTOR], [ID_EMOCION], [URI_RELATIVO]) VALUES (1, N'The Matrix', N'Un programador de computadoras descubre que el mundo en el que vive es una simulación creada por inteligencias artificiales y se une a la rebelión para liberarla.', CAST(N'1999-01-01T00:00:00.000' AS DateTime), N'Ciencia Ficción', N'Hermanas Wachoski', 4, NULL)
INSERT [dbo].[PELICULA] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [GENERO], [DIRECTOR], [ID_EMOCION], [URI_RELATIVO]) VALUES (2, N'Titanic', N'Dos jóvenes que se conocen y se enamoran a bordo del transatlántico RMS Titanic en su viaje inaugural', CAST(N'1997-01-01T00:00:00.000' AS DateTime), N'Romance', N'James Cameron', 10, NULL)
INSERT [dbo].[PELICULA] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [GENERO], [DIRECTOR], [ID_EMOCION], [URI_RELATIVO]) VALUES (3, N'En busca de la felicidad', N'La vida es una lucha para Chris Gardner. Expulsado de su apartamento, él y su joven hijo se encuentran solos sin ningún lugar a donde ir. A pesar de que Chris ocasionalmente consigue trabajo como interno en una prestigiada firma financiera, la posición no le da dinero.', CAST(N'2006-01-01T00:00:00.000' AS DateTime), N'Drama', N'Gabriele Muccino', 7, NULL)
INSERT [dbo].[PELICULA] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [GENERO], [DIRECTOR], [ID_EMOCION], [URI_RELATIVO]) VALUES (4, N'Top Gun: Maverik', N'Maverick, quien lleva 30 años de servicio, es ahora instructor de pilotos militares. Una última misión, un sacrificio final, obliga a este maestro de los cielos a enfrentar las heridas abiertas del pasado y sus temores más profundos.', CAST(N'2022-01-01T00:00:00.000' AS DateTime), N'Acción', N'Joseph Kosinski', 7, NULL)
INSERT [dbo].[PELICULA] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [GENERO], [DIRECTOR], [ID_EMOCION], [URI_RELATIVO]) VALUES (5, N'Cantando bajo la lluvia', N'El ídolo del cine Don Lockwood pensaba que lo tenía todo en la vida: fama, fortuna y éxito hasta que conoce a la aspirante a actriz Kathy Selden. La joven y la llegada del cine sonoro revolucionarán la vida de Don.', CAST(N'1952-01-01T00:00:00.000' AS DateTime), N'Musical', N'Stanley Donen', 7, NULL)
INSERT [dbo].[PELICULA] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [GENERO], [DIRECTOR], [ID_EMOCION], [URI_RELATIVO]) VALUES (6, N'La lista de Schindler', N'Durante la Segunda Guerra Mundial, las tropas alemanas de ocupación han forzado a los judíos polacos a vivir recluidos en un gueto. El empresario Oskar Schindler (Liam Neeson), de etnia alemana y miembro del Partido Nazi, llega a la ciudad decidido a hacer fortuna y comienza por sobornar a diversos oficiales de las fuerzas armadas alemanas y de las SS.', CAST(N'1993-01-01T00:00:00.000' AS DateTime), N'Belica', N'Steven Spielberg', 12, NULL)
INSERT [dbo].[PELICULA] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [GENERO], [DIRECTOR], [ID_EMOCION], [URI_RELATIVO]) VALUES (7, N'El pianista', N'La película es una adaptación de las memorias del músico polaco de origen judío Wladyslaw Szpilman2? sobre como sobrevivió al holocausto y a la ocupación de Varsovia (Polonia) por la Alemania Nazi en 1939.', CAST(N'2007-01-01T00:00:00.000' AS DateTime), N'Drama', N'Roman Polanski', 12, NULL)
INSERT [dbo].[PELICULA] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [GENERO], [DIRECTOR], [ID_EMOCION], [URI_RELATIVO]) VALUES (8, N'Diario de una pasión', N'Así empiezan a vivir el amor pesar de las peleas que ambos tienen y muy especialmente sus diferencias de estrato social. La madre de Allie cuando se entera de este romance y conocer la clase social de Noah se opone y decide separarlos.', CAST(N'2004-01-01T00:00:00.000' AS DateTime), N'Drama', N'Nick Cassavetes', 10, NULL)
INSERT [dbo].[PELICULA] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [GENERO], [DIRECTOR], [ID_EMOCION], [URI_RELATIVO]) VALUES (9, N'El juego del miedo', N'La película cuenta una narración no lineal que gira en torno al misterio del asesino Jigsaw, que pone a prueba la voluntad de vivir de sus víctimas sometiéndolas a "juegos" mortales en los que deben infligirse un gran dolor físico para sobrevivir. La trama sigue a las últimas víctimas de Jigsaw (Whannell y Elwes), que despiertan en un gran cuarto de baño en ruinas, y a una de ellas se le ordena matar a la otra para salvar a su propia familia.', CAST(N'2004-01-01T00:00:00.000' AS DateTime), N'Terror', N'James Wan', 8, NULL)
INSERT [dbo].[PELICULA] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [GENERO], [DIRECTOR], [ID_EMOCION], [URI_RELATIVO]) VALUES (10, N'Mi pobre angelito', N'Kevin es un niño de 8 años que vive junto a su familia en Chicago. La película comienza con una cena en la víspera de un viaje que se pensaba realizar para celebrar la Navidad en Francia. Mientras la familia estaba enfocada en los preparativos del viaje y de la cena, sus movimientos son monitoreados por el delincuente Harry (Joe Pesci), quien había logrado entrar a la casa con un disfraz de policía.', CAST(N'1990-01-01T00:00:00.000' AS DateTime), N'Comedia', N'Chris Columbus', 11, NULL)
INSERT [dbo].[PELICULA] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [GENERO], [DIRECTOR], [ID_EMOCION], [URI_RELATIVO]) VALUES (11, N'Comer, rezar, amar', N'Elizabeth Gilbert (Julia Roberts) tenía un esposo, una casa preciosa y una exitosa carrera profesional. Pero, un día se preguntó qué deseaba realmente en su vida y decidió dejarlo todo para viajar durante un año. Y así fue como comió en Italia, rezó en India y amó en Indonesia.', CAST(N'2010-01-01T00:00:00.000' AS DateTime), N'Drama', N'Ryan Murphy', 9, NULL)
INSERT [dbo].[PELICULA] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [GENERO], [DIRECTOR], [ID_EMOCION], [URI_RELATIVO]) VALUES (12, N'Intensamente', N'Las cinco emociones que conviven en el interior de una niña llamada Riley, alegría, miedo, desagrado, ira y tristeza, compiten por tomar el control de sus acciones cuando la pequeña se traslada, junto a su familia, a vivir a San Francisco.', CAST(N'2015-01-01T00:00:00.000' AS DateTime), N'Animación', N'Pete Docter', 11, NULL)
INSERT [dbo].[PELICULA] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [GENERO], [DIRECTOR], [ID_EMOCION], [URI_RELATIVO]) VALUES (13, N'El cienpiés humano', N'Un científico loco secuestra a tres turistas y los une quirúrgicamente para formar un "cienpiés humano"', CAST(N'2009-01-01T00:00:00.000' AS DateTime), N'Terror', N'Tom Six', 5, NULL)
INSERT [dbo].[PELICULA] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [GENERO], [DIRECTOR], [ID_EMOCION], [URI_RELATIVO]) VALUES (14, N'El perfume: Historia de un asesino', N'Un joven con un sentido del olfato extraordinario se obsesiona con capturar el aroma perfecto y recurre al asesinato', CAST(N'2006-01-01T00:00:00.000' AS DateTime), N'Drama', N'Tom Tykwer', 5, NULL)
INSERT [dbo].[PELICULA] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [GENERO], [DIRECTOR], [ID_EMOCION], [URI_RELATIVO]) VALUES (15, N'Martyrs', N'Dos mujeres buscan venganza contra quienes las torturaron de niñas, enfrentando horrores inimaginables.', CAST(N'2008-01-01T00:00:00.000' AS DateTime), N'Terror', N'Pascal Laugier', 5, NULL)
INSERT [dbo].[PELICULA] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [GENERO], [DIRECTOR], [ID_EMOCION], [URI_RELATIVO]) VALUES (16, N'La piel que habito', N'Un cirujano plástico lleva a cabo experimentos con una mujer a quien mantiene prisionera, buscando crear una piel perfecta', CAST(N'2011-01-01T00:00:00.000' AS DateTime), N'Drama', N'Pedro Almodóvar', 5, NULL)
INSERT [dbo].[PELICULA] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [GENERO], [DIRECTOR], [ID_EMOCION], [URI_RELATIVO]) VALUES (17, N'The Truman Show', N'Un hombre descubre que toda su vida ha sido el escenario de un reality show televisivo, lo que despierta su curiosidad por el mundo real y su propia identidad.', CAST(N'1998-01-01T00:00:00.000' AS DateTime), N'Comedia', N'Peter Weir', 4, NULL)
INSERT [dbo].[PELICULA] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [GENERO], [DIRECTOR], [ID_EMOCION], [URI_RELATIVO]) VALUES (18, N'The Prestige', N'Dos magos rivales intentan superar al otro con trucos cada vez más impresionantes, desatando una serie de eventos llenos de misterio y obsesión', CAST(N'2006-01-01T00:00:00.000' AS DateTime), N'Suspenso', N'Christopher Nolan', 4, NULL)
INSERT [dbo].[PELICULA] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [GENERO], [DIRECTOR], [ID_EMOCION], [URI_RELATIVO]) VALUES (19, N'Interstellar', N'Un grupo de astronautas emprende un viaje a través de un agujero de gusano en busca de un nuevo hogar para la humanidad, despertando preguntas sobre el tiempo, el espacio y la existencia.', CAST(N'2014-01-01T00:00:00.000' AS DateTime), N'Ciencia Ficción', N'Christopher Nolan', 4, NULL)
INSERT [dbo].[PELICULA] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [GENERO], [DIRECTOR], [ID_EMOCION], [URI_RELATIVO]) VALUES (20, N'El sexto sentido', N'Un niño que puede ver y comunicarse con los muertos busca la ayuda de un psicólogo infantil. La película es conocida por su sorprendente giro final.', CAST(N'1999-01-01T00:00:00.000' AS DateTime), N'Terror', N'M. Night Shyamalan', 11, NULL)
INSERT [dbo].[PELICULA] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [GENERO], [DIRECTOR], [ID_EMOCION], [URI_RELATIVO]) VALUES (21, N'El club de la pelea', N'Un hombre insomne busca un cambio radical en su vida al unirse a un club de pelea clandestino, liderado por el carismático Tyler Durden. La narrativa contiene un giro inesperado que cambia la perspectiva de toda la historia.', CAST(N'1999-01-01T00:00:00.000' AS DateTime), N'Drama', N'David Fincher', 11, NULL)
INSERT [dbo].[PELICULA] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [GENERO], [DIRECTOR], [ID_EMOCION], [URI_RELATIVO]) VALUES (22, N'Los otros', N'Una mujer vive en una mansión oscura con sus dos hijos fotosensibles y empieza a sospechar que su casa está encantada. La revelación final es sorprendente.', CAST(N'2001-01-01T00:00:00.000' AS DateTime), N'Suspenso', N'Alejandro Amenábar', 11, NULL)
INSERT [dbo].[PELICULA] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [GENERO], [DIRECTOR], [ID_EMOCION], [URI_RELATIVO]) VALUES (23, N'Seven', N'Dos detectives investigan una serie de asesinatos que representan los siete pecados capitales. La revelación del asesino y el desenlace son profundamente impactantes.', CAST(N'1995-01-01T00:00:00.000' AS DateTime), N'Crimen', N'David Fincher', 11, NULL)
INSERT [dbo].[PELICULA] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [GENERO], [DIRECTOR], [ID_EMOCION], [URI_RELATIVO]) VALUES (24, N'Requiem for a Dream', N'La historia sigue a cuatro personas y sus experiencias con diferentes tipos de adicción, mostrando su descenso a la desesperación y la autodestrucción.', CAST(N'2000-01-01T00:00:00.000' AS DateTime), N'Psicologico', N'Darren Aronofsky', 3, NULL)
INSERT [dbo].[PELICULA] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [GENERO], [DIRECTOR], [ID_EMOCION], [URI_RELATIVO]) VALUES (25, N'Panic Room', N'Una madre y su hija se refugian en una habitación de pánico cuando unos intrusos irrumpen en su casa, enfrentándose a una tensa situación de vida o muerte.', CAST(N'2002-01-01T00:00:00.000' AS DateTime), N'Suspenso', N'David Fincher', 3, NULL)
INSERT [dbo].[PELICULA] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [GENERO], [DIRECTOR], [ID_EMOCION], [URI_RELATIVO]) VALUES (26, N'Hereditary', N'Tras la muerte de su madre, una familia se enfrenta a eventos siniestros y perturbadores mientras desentrañan oscuros secretos familiares.', CAST(N'2018-01-01T00:00:00.000' AS DateTime), N'Terror', N'Ari Aster', 3, NULL)
INSERT [dbo].[PELICULA] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [GENERO], [DIRECTOR], [ID_EMOCION], [URI_RELATIVO]) VALUES (27, N'El secreto de sus ojos', N'Un exfuncionario judicial decide escribir una novela sobre un caso de asesinato no resuelto, mientras revive su amor no correspondido por una colega.', CAST(N'2009-01-01T00:00:00.000' AS DateTime), N'Romance', N'Juan José Campanella', 10, NULL)
INSERT [dbo].[PELICULA] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [GENERO], [DIRECTOR], [ID_EMOCION], [URI_RELATIVO]) VALUES (28, N'Realmente amor', N'Entrecruzando varias historias de amor y relaciones durante la época navideña en Londres, esta película muestra diferentes facetas del amor.', CAST(N'2003-01-01T00:00:00.000' AS DateTime), N'Romance', N'Richard Curtis', 2, NULL)
INSERT [dbo].[PELICULA] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [GENERO], [DIRECTOR], [ID_EMOCION], [URI_RELATIVO]) VALUES (29, N'Triste San Valentín', N'Una mirada íntima y realista a la relación de una pareja, desde el inicio apasionado de su amor hasta su eventual desmoronamiento', CAST(N'2010-01-01T00:00:00.000' AS DateTime), N'Drama', N'Derek Cianfrance', 2, NULL)
INSERT [dbo].[PELICULA] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [GENERO], [DIRECTOR], [ID_EMOCION], [URI_RELATIVO]) VALUES (30, N'Bajo la misma estrella', N'Dos adolescentes con cáncer se enamoran y enfrentan juntos los desafíos de sus enfermedades y su amor', CAST(N'2014-01-01T00:00:00.000' AS DateTime), N'Drama', N'Josh Boone', 2, NULL)
INSERT [dbo].[PELICULA] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [GENERO], [DIRECTOR], [ID_EMOCION], [URI_RELATIVO]) VALUES (31, N'Lost in Translation', N'Dos estadounidenses, un actor envejecido y una joven casada, se encuentran en Tokio y desarrollan una conexión especial mientras ambos lidian con el aburrimiento y la soledad en una ciudad extranjera.', CAST(N'2003-01-01T00:00:00.000' AS DateTime), N'Comedia', N'Sofia Coppola', 1, NULL)
INSERT [dbo].[PELICULA] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [GENERO], [DIRECTOR], [ID_EMOCION], [URI_RELATIVO]) VALUES (32, N'American Beauty', N'Un hombre de mediana edad, atrapado en una vida suburbana monótona, experimenta una crisis de la mediana edad que lo lleva a redescubrir el significado de la vida y la libertad.', CAST(N'1999-01-01T00:00:00.000' AS DateTime), N'Drama', N'Sam Mendes', 1, NULL)
INSERT [dbo].[PELICULA] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [GENERO], [DIRECTOR], [ID_EMOCION], [URI_RELATIVO]) VALUES (33, N'Her', N'Un escritor solitario desarrolla una relación amorosa con un sistema operativo diseñado para satisfacer todas sus necesidades, explorando temas de aislamiento y aburrimiento en la era digital.', CAST(N'2013-01-01T00:00:00.000' AS DateTime), N'Romance', N'Spike Jonze', 1, NULL)
INSERT [dbo].[PELICULA] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [GENERO], [DIRECTOR], [ID_EMOCION], [URI_RELATIVO]) VALUES (34, N'Office Space', N'La vida de unos empleados de oficina que están insatisfechos y aburridos con sus trabajos rutinarios en una compañía de software, y su plan para rebelarse contra su tediosa realidad laboral.', CAST(N'1999-01-01T00:00:00.000' AS DateTime), N'Comedia', N'Mike Judge', 1, NULL)
INSERT [dbo].[PELICULA] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [GENERO], [DIRECTOR], [ID_EMOCION], [URI_RELATIVO]) VALUES (35, N'Falling Down', N'Un hombre desempleado y divorciado atraviesa una crisis personal y comienza una serie de actos violentos y destructivos en la ciudad de Los Ángeles, reflejando su ira y frustración', CAST(N'1993-01-01T00:00:00.000' AS DateTime), N'Drama', N'Joel Schumacher', 6, NULL)
INSERT [dbo].[PELICULA] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [GENERO], [DIRECTOR], [ID_EMOCION], [URI_RELATIVO]) VALUES (36, N'Taxi Driver', N'Un veterano de Vietnam convertido en taxista en Nueva York se ve consumido por el enojo y la alienación, lo que lo lleva a un camino de violencia en un intento desesperado por encontrar algún sentido en su vida.', CAST(N'1976-01-01T00:00:00.000' AS DateTime), N'Drama', N'Martin Scorsese', 6, NULL)
INSERT [dbo].[PELICULA] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [GENERO], [DIRECTOR], [ID_EMOCION], [URI_RELATIVO]) VALUES (37, N'Relatos salvajes', N'Una colección de seis historias cortas que exploran los extremos a los que puede llegar la gente cuando se siente agraviada, explotada o enojada. Cada relato muestra una explosión de ira y las consecuencias de dejarse llevar por el enojo', CAST(N'2014-01-01T00:00:00.000' AS DateTime), N'Comedia Negra', N'Damián Szifron', 6, NULL)
INSERT [dbo].[PELICULA] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [GENERO], [DIRECTOR], [ID_EMOCION], [URI_RELATIVO]) VALUES (38, N'Carancho', N'Sosa es un abogado especializado en accidentes de tráfico, conocido como "carancho", que se gana la vida explotando el sufrimiento ajeno. Su vida cambia cuando conoce a Luján, una joven doctora. Su relación se ve marcada por el enojo y la frustración de la violencia y la corrupción que los rodea.', CAST(N'2010-01-01T00:00:00.000' AS DateTime), N'Thriller', N'Pablo Trapero', 6, NULL)
INSERT [dbo].[PELICULA] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [GENERO], [DIRECTOR], [ID_EMOCION], [URI_RELATIVO]) VALUES (39, N'Corazón de León', N'Cuenta la historia de Ivana, una abogada que se enamora de León, un hombre carismático pero de baja estatura. A través de esta relación, ambos personajes descubren el verdadero significado del amor y la aceptación.', CAST(N'2013-01-01T00:00:00.000' AS DateTime), N'Comedia Romantica', N'Marcos Carnevale', 9, NULL)
INSERT [dbo].[PELICULA] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [GENERO], [DIRECTOR], [ID_EMOCION], [URI_RELATIVO]) VALUES (40, N'La vida es bella', N'Durante la Segunda Guerra Mundial, un hombre utiliza su imaginación y humor para proteger a su hijo de los horrores del campo de concentración.', CAST(N'1997-01-01T00:00:00.000' AS DateTime), N'Comedia Dramatica', N'Roberto Benigni', 9, NULL)
INSERT [dbo].[PELICULA] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [GENERO], [DIRECTOR], [ID_EMOCION], [URI_RELATIVO]) VALUES (41, N'Forrest Gump', N'La historia de un hombre con habilidades limitadas pero con un corazón puro que vive experiencias extraordinarias, enseñándonos sobre la simplicidad y la esperanza.', CAST(N'1994-01-01T00:00:00.000' AS DateTime), N'Drama', N'Robert Zemeckis', 9, NULL)
INSERT [dbo].[PELICULA] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [GENERO], [DIRECTOR], [ID_EMOCION], [URI_RELATIVO]) VALUES (42, N'Invictus', N'Relata cómo Nelson Mandela se une al capitán del equipo de rugby de Sudáfrica para unir al país tras el apartheid a través del deporte', CAST(N'2009-01-01T00:00:00.000' AS DateTime), N'Drama Biografico', N'Mike Newell', 9, NULL)
INSERT [dbo].[PELICULA] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [GENERO], [DIRECTOR], [ID_EMOCION], [URI_RELATIVO]) VALUES (43, N'La sonrisa de Mona Lisa', N'Una profesora de arte en una universidad femenina desafía las normas sociales de los años 50 y motiva a sus estudiantes a luchar por sus sueños.', CAST(N'2003-01-01T00:00:00.000' AS DateTime), N'Drama', N'Mike Newell', 9, NULL)
INSERT [dbo].[PELICULA] ([ID], [NOMBRE], [DESCRIPCION], [FECHA], [GENERO], [DIRECTOR], [ID_EMOCION], [URI_RELATIVO]) VALUES (44, N'Psicosis', N'Una secretaria roba una gran suma de dinero y se refugia en un motel aislado, donde se enfrenta al perturbado propietario Norman Bates.', CAST(N'1960-01-01T00:00:00.000' AS DateTime), N'Terror', N'Alfred Hitchcock', 8, NULL)
SET IDENTITY_INSERT [dbo].[PELICULA] OFF
GO
SET IDENTITY_INSERT [dbo].[USUARIO] ON 

INSERT [dbo].[USUARIO] ([ID], [USERNAME], [EMAIL], [PASSWORD]) VALUES (1, N'admin', N'admin@admin.com', N'8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918')
SET IDENTITY_INSERT [dbo].[USUARIO] OFF
GO
ALTER TABLE [dbo].[LIBRO]  WITH CHECK ADD  CONSTRAINT [FK_LIBRO_EMOCION] FOREIGN KEY([ID_EMOCION])
REFERENCES [dbo].[EMOCION] ([ID])
GO
ALTER TABLE [dbo].[LIBRO] CHECK CONSTRAINT [FK_LIBRO_EMOCION]
GO
ALTER TABLE [dbo].[PELICULA]  WITH CHECK ADD  CONSTRAINT [FK_PELICULA_EMOCION] FOREIGN KEY([ID_EMOCION])
REFERENCES [dbo].[EMOCION] ([ID])
GO
ALTER TABLE [dbo].[PELICULA] CHECK CONSTRAINT [FK_PELICULA_EMOCION]
GO
/****** Object:  StoredProcedure [dbo].[LISTAR_USUARIO]    Script Date: 6/9/2024 5:59:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[LISTAR_USUARIO]
	-- Add the parameters for the stored procedure here
	AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.

    -- Insert statements for procedure here
	SELECT * from USUARIO;
END
GO
USE [master]
GO
ALTER DATABASE [MOODFLIX] SET  READ_WRITE 
GO
