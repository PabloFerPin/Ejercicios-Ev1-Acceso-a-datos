USE [master]
GO
/****** Objeto: Database [ClubTenis] Fecha de script: 10/11/2026 18:21:56 ******/
CREATE DATABASE [ClubTenis]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ClubTenis', FILENAME = N'C:\Users\pablo\ClubTenis.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ClubTenis_log', FILENAME = N'C:\Users\pablo\ClubTenis_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [ClubTenis] SET COMPATIBILITY_LEVEL = 170
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ClubTenis].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ClubTenis] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ClubTenis] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ClubTenis] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ClubTenis] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ClubTenis] SET ARITHABORT OFF 
GO
ALTER DATABASE [ClubTenis] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ClubTenis] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ClubTenis] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ClubTenis] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ClubTenis] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ClubTenis] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ClubTenis] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ClubTenis] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ClubTenis] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ClubTenis] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ClubTenis] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ClubTenis] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ClubTenis] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ClubTenis] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ClubTenis] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ClubTenis] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ClubTenis] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ClubTenis] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ClubTenis] SET  MULTI_USER 
GO
ALTER DATABASE [ClubTenis] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ClubTenis] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ClubTenis] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ClubTenis] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ClubTenis] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ClubTenis] SET OPTIMIZED_LOCKING = OFF 
GO
ALTER DATABASE [ClubTenis] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ClubTenis] SET QUERY_STORE = ON
GO
ALTER DATABASE [ClubTenis] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [ClubTenis]
GO
/****** Objeto: Table [dbo].[Pistas] Fecha de script: 10/11/2026 18:21:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pistas](
	[IdPista] [int] NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Superficie] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPista] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Objeto: Table [dbo].[Reservas] Fecha de script: 10/11/2026 18:21:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservas](
	[IdReserva] [int] IDENTITY(1,1) NOT NULL,
	[IdPista] [int] NOT NULL,
	[NombreJugador] [nvarchar](100) NOT NULL,
	[EsSocio] [bit] NOT NULL,
	[Fecha] [date] NOT NULL,
	[HoraInicio] [int] NOT NULL,
	[Horas] [int] NOT NULL,
	[Importe] [decimal](6, 2) NOT NULL,
	[Estado] [nvarchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdReserva] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Objeto: View [dbo].[vw_ResumenPistas] Fecha de script: 10/11/2026 18:21:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_ResumenPistas]
AS
SELECT        dbo.Pistas.IdPista, dbo.Pistas.Nombre, dbo.Pistas.Superficie, COUNT(dbo.Reservas.IdReserva) AS NumReservas, SUM(dbo.Reservas.Horas) AS HorasReservadas, SUM(dbo.Reservas.Importe) AS Ingresos
FROM            dbo.Pistas INNER JOIN
                         dbo.Reservas ON dbo.Pistas.IdPista = dbo.Reservas.IdPista
WHERE        (dbo.Reservas.Estado = N'Activo')
GROUP BY dbo.Pistas.IdPista, dbo.Pistas.Nombre, dbo.Pistas.Superficie, dbo.Reservas.IdReserva
GO
/****** Objeto: Index [IX_Reservas_Fecha] Fecha de script: 10/11/2026 18:21:57 ******/
CREATE NONCLUSTERED INDEX [IX_Reservas_Fecha] ON [dbo].[Reservas]
(
	[Fecha] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Reservas] ADD  DEFAULT ('Activa') FOR [Estado]
GO
ALTER TABLE [dbo].[Reservas]  WITH CHECK ADD FOREIGN KEY([IdPista])
REFERENCES [dbo].[Pistas] ([IdPista])
GO
ALTER TABLE [dbo].[Pistas]  WITH CHECK ADD CHECK  (([Superficie]='Hierba' OR [Superficie]='Dura' OR [Superficie]='Tierra Batida'))
GO
ALTER TABLE [dbo].[Reservas]  WITH CHECK ADD CHECK  (([Estado]='Cancelada' OR [Estado]='Activa'))
GO
ALTER TABLE [dbo].[Reservas]  WITH CHECK ADD CHECK  (([HoraInicio]>=(8) AND [HoraInicio]<=(21)))
GO
ALTER TABLE [dbo].[Reservas]  WITH CHECK ADD CHECK  (([Horas]=(1) OR [Horas]=(2)))
GO
ALTER TABLE [dbo].[Reservas]  WITH CHECK ADD CHECK  (([Importe]>=(0)))
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Pistas"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 119
               Right = 247
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Reservas"
            Begin Extent = 
               Top = 6
               Left = 285
               Bottom = 136
               Right = 494
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 12
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_ResumenPistas'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_ResumenPistas'
GO
USE [master]
GO
ALTER DATABASE [ClubTenis] SET  READ_WRITE 
GO
