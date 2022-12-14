USE [PROG260FA22]
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPaneCount' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_EldenRingFullReport'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPane1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_EldenRingFullReport'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPaneCount' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_EldenRingChartTwo'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPane1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_EldenRingChartTwo'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPaneCount' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_EldenRingChartOne'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPane1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_EldenRingChartOne'
GO
/****** Object:  StoredProcedure [dbo].[spSelectFromView]    Script Date: 12/12/2022 1:07:20 PM ******/
DROP PROCEDURE [dbo].[spSelectFromView]
GO
/****** Object:  StoredProcedure [dbo].[spGetAllLocations]    Script Date: 12/12/2022 1:07:20 PM ******/
DROP PROCEDURE [dbo].[spGetAllLocations]
GO
/****** Object:  StoredProcedure [dbo].[spGetAllDamages]    Script Date: 12/12/2022 1:07:20 PM ******/
DROP PROCEDURE [dbo].[spGetAllDamages]
GO
ALTER TABLE [dbo].[EldenRing_Bosses] DROP CONSTRAINT [FK_EldenRing_Bosses_EldenRing_Types]
GO
ALTER TABLE [dbo].[EldenRing_Bosses] DROP CONSTRAINT [FK_EldenRing_Bosses_EldenRing_Locations]
GO
ALTER TABLE [dbo].[EldenRing_Bosses] DROP CONSTRAINT [FK_EldenRing_Bosses_EldenRing_Damage1]
GO
ALTER TABLE [dbo].[EldenRing_Bosses] DROP CONSTRAINT [FK_EldenRing_Bosses_EldenRing_Damage]
GO
/****** Object:  View [dbo].[vw_EldenRingChartTwo]    Script Date: 12/12/2022 1:07:20 PM ******/
DROP VIEW [dbo].[vw_EldenRingChartTwo]
GO
/****** Object:  View [dbo].[vw_EldenRingChartOne]    Script Date: 12/12/2022 1:07:20 PM ******/
DROP VIEW [dbo].[vw_EldenRingChartOne]
GO
/****** Object:  View [dbo].[vw_EldenRingFullReport]    Script Date: 12/12/2022 1:07:20 PM ******/
DROP VIEW [dbo].[vw_EldenRingFullReport]
GO
/****** Object:  Table [dbo].[EldenRing_Damage]    Script Date: 12/12/2022 1:07:20 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EldenRing_Damage]') AND type in (N'U'))
DROP TABLE [dbo].[EldenRing_Damage]
GO
/****** Object:  Table [dbo].[EldenRing_Locations]    Script Date: 12/12/2022 1:07:20 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EldenRing_Locations]') AND type in (N'U'))
DROP TABLE [dbo].[EldenRing_Locations]
GO
/****** Object:  Table [dbo].[EldenRing_Types]    Script Date: 12/12/2022 1:07:20 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EldenRing_Types]') AND type in (N'U'))
DROP TABLE [dbo].[EldenRing_Types]
GO
/****** Object:  Table [dbo].[EldenRing_Bosses]    Script Date: 12/12/2022 1:07:20 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EldenRing_Bosses]') AND type in (N'U'))
DROP TABLE [dbo].[EldenRing_Bosses]
GO
/****** Object:  Table [dbo].[EldenRing_Bosses]    Script Date: 12/12/2022 1:07:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EldenRing_Bosses](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[boss_name] [nvarchar](max) NOT NULL,
	[type_id] [int] NOT NULL,
	[location_id] [int] NOT NULL,
	[strength_id] [int] NOT NULL,
	[weakness_id] [int] NULL,
 CONSTRAINT [PK_EldenRing_Bosses] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EldenRing_Types]    Script Date: 12/12/2022 1:07:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EldenRing_Types](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[type] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_EldenRing_Types] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EldenRing_Locations]    Script Date: 12/12/2022 1:07:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EldenRing_Locations](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[location] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_EldenRing_Locations] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EldenRing_Damage]    Script Date: 12/12/2022 1:07:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EldenRing_Damage](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[damage_type] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_EldenRing_Damage] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[vw_EldenRingFullReport]    Script Date: 12/12/2022 1:07:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vw_EldenRingFullReport]
AS
SELECT     dbo.EldenRing_Bosses.id, dbo.EldenRing_Bosses.boss_name AS Name, dbo.EldenRing_Types.type AS Type, dbo.EldenRing_Locations.location AS Location, D1.damage_type AS Strength, D2.damage_type AS Weakness
FROM        dbo.EldenRing_Bosses LEFT JOIN
                  dbo.EldenRing_Damage D1 ON dbo.EldenRing_Bosses.strength_id = D1.id LEFT JOIN 
				  dbo.EldenRing_Damage D2 ON dbo.EldenRing_Bosses.weakness_id = D2.id LEFT JOIN
                  dbo.EldenRing_Locations ON dbo.EldenRing_Bosses.location_id = dbo.EldenRing_Locations.id LEFT JOIN
                  dbo.EldenRing_Types ON dbo.EldenRing_Bosses.type_id = dbo.EldenRing_Types.id
GO
/****** Object:  View [dbo].[vw_EldenRingChartOne]    Script Date: 12/12/2022 1:07:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE VIEW [dbo].[vw_EldenRingChartOne]
AS
SELECT DISTINCT dbo.EldenRing_Types.type AS X, COUNT(dbo.EldenRing_Bosses.boss_name) AS Y
FROM        dbo.EldenRing_Bosses INNER JOIN
                  dbo.EldenRing_Types ON dbo.EldenRing_Bosses.type_id = dbo.EldenRing_Types.id
GROUP BY dbo.EldenRing_Types.type
GO
/****** Object:  View [dbo].[vw_EldenRingChartTwo]    Script Date: 12/12/2022 1:07:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_EldenRingChartTwo]
AS
SELECT DISTINCT dbo.EldenRing_Damage.damage_type AS X, COUNT(dbo.EldenRing_Bosses.boss_name) AS Y
FROM        dbo.EldenRing_Bosses INNER JOIN
                  dbo.EldenRing_Damage ON dbo.EldenRing_Bosses.strength_id = dbo.EldenRing_Damage.id
GROUP BY dbo.EldenRing_Damage.damage_type
GO
SET IDENTITY_INSERT [dbo].[EldenRing_Bosses] ON 

INSERT [dbo].[EldenRing_Bosses] ([id], [boss_name], [type_id], [location_id], [strength_id], [weakness_id]) VALUES (1, N'Godrick the Grafted', 1, 1, 7, NULL)
INSERT [dbo].[EldenRing_Bosses] ([id], [boss_name], [type_id], [location_id], [strength_id], [weakness_id]) VALUES (2, N'Rennala, Queen of the Full Moon', 2, 2, 1, 8)
INSERT [dbo].[EldenRing_Bosses] ([id], [boss_name], [type_id], [location_id], [strength_id], [weakness_id]) VALUES (3, N'Starscourge Radahn', 1, 3, 6, NULL)
INSERT [dbo].[EldenRing_Bosses] ([id], [boss_name], [type_id], [location_id], [strength_id], [weakness_id]) VALUES (4, N'Morgott the Omen King', 1, 4, 7, 6)
INSERT [dbo].[EldenRing_Bosses] ([id], [boss_name], [type_id], [location_id], [strength_id], [weakness_id]) VALUES (5, N'Rykard, Lord of Blasphemy', 1, 5, 3, 9)
INSERT [dbo].[EldenRing_Bosses] ([id], [boss_name], [type_id], [location_id], [strength_id], [weakness_id]) VALUES (6, N'Mohg, Lord of Blood', 1, 6, 3, NULL)
INSERT [dbo].[EldenRing_Bosses] ([id], [boss_name], [type_id], [location_id], [strength_id], [weakness_id]) VALUES (7, N'Malenia Blade of Miquella', 1, 7, 5, NULL)
INSERT [dbo].[EldenRing_Bosses] ([id], [boss_name], [type_id], [location_id], [strength_id], [weakness_id]) VALUES (8, N'Lichdragon Fortissax', 2, 8, 4, 8)
INSERT [dbo].[EldenRing_Bosses] ([id], [boss_name], [type_id], [location_id], [strength_id], [weakness_id]) VALUES (9, N'Maliketh', 2, 9, 7, NULL)
INSERT [dbo].[EldenRing_Bosses] ([id], [boss_name], [type_id], [location_id], [strength_id], [weakness_id]) VALUES (10, N'Astel Naturalborn of the Void', 2, 10, 4, NULL)
INSERT [dbo].[EldenRing_Bosses] ([id], [boss_name], [type_id], [location_id], [strength_id], [weakness_id]) VALUES (11, N'Regal Ancestor Spirit', 2, 11, 1, 7)
INSERT [dbo].[EldenRing_Bosses] ([id], [boss_name], [type_id], [location_id], [strength_id], [weakness_id]) VALUES (12, N'Radagon of the Golden Order', 3, 12, 4, NULL)
INSERT [dbo].[EldenRing_Bosses] ([id], [boss_name], [type_id], [location_id], [strength_id], [weakness_id]) VALUES (13, N'Elden Beast', 3, 12, 7, NULL)
INSERT [dbo].[EldenRing_Bosses] ([id], [boss_name], [type_id], [location_id], [strength_id], [weakness_id]) VALUES (14, N'Godfrey, First Elden Lord', 2, 4, 2, NULL)
INSERT [dbo].[EldenRing_Bosses] ([id], [boss_name], [type_id], [location_id], [strength_id], [weakness_id]) VALUES (15, N'Fire Giant', 2, 13, 3, 6)
INSERT [dbo].[EldenRing_Bosses] ([id], [boss_name], [type_id], [location_id], [strength_id], [weakness_id]) VALUES (16, N'Dragonlord Placidusax', 2, 9, 7, NULL)
SET IDENTITY_INSERT [dbo].[EldenRing_Bosses] OFF
GO
SET IDENTITY_INSERT [dbo].[EldenRing_Damage] ON 

INSERT [dbo].[EldenRing_Damage] ([id], [damage_type]) VALUES (1, N'Magic')
INSERT [dbo].[EldenRing_Damage] ([id], [damage_type]) VALUES (2, N'Standard')
INSERT [dbo].[EldenRing_Damage] ([id], [damage_type]) VALUES (3, N'Fire')
INSERT [dbo].[EldenRing_Damage] ([id], [damage_type]) VALUES (4, N'Lightning')
INSERT [dbo].[EldenRing_Damage] ([id], [damage_type]) VALUES (5, N'Physical')
INSERT [dbo].[EldenRing_Damage] ([id], [damage_type]) VALUES (6, N'Slash')
INSERT [dbo].[EldenRing_Damage] ([id], [damage_type]) VALUES (7, N'Holy')
INSERT [dbo].[EldenRing_Damage] ([id], [damage_type]) VALUES (8, N'Pierce')
INSERT [dbo].[EldenRing_Damage] ([id], [damage_type]) VALUES (9, N'Frostbite')
SET IDENTITY_INSERT [dbo].[EldenRing_Damage] OFF
GO
SET IDENTITY_INSERT [dbo].[EldenRing_Locations] ON 

INSERT [dbo].[EldenRing_Locations] ([id], [location]) VALUES (1, N'Stormveil Castle')
INSERT [dbo].[EldenRing_Locations] ([id], [location]) VALUES (2, N'Raya Lucaria Academy')
INSERT [dbo].[EldenRing_Locations] ([id], [location]) VALUES (3, N'Wailing Dunes')
INSERT [dbo].[EldenRing_Locations] ([id], [location]) VALUES (4, N'Leyndell')
INSERT [dbo].[EldenRing_Locations] ([id], [location]) VALUES (5, N'Mt. Gelmir')
INSERT [dbo].[EldenRing_Locations] ([id], [location]) VALUES (6, N'Siofra River')
INSERT [dbo].[EldenRing_Locations] ([id], [location]) VALUES (7, N'Elphael')
INSERT [dbo].[EldenRing_Locations] ([id], [location]) VALUES (8, N'Deeproot Depths')
INSERT [dbo].[EldenRing_Locations] ([id], [location]) VALUES (9, N'Crumbling Farum Azula')
INSERT [dbo].[EldenRing_Locations] ([id], [location]) VALUES (10, N'Grand Cloister')
INSERT [dbo].[EldenRing_Locations] ([id], [location]) VALUES (11, N'Nokron')
INSERT [dbo].[EldenRing_Locations] ([id], [location]) VALUES (12, N'Elden Throne')
INSERT [dbo].[EldenRing_Locations] ([id], [location]) VALUES (13, N'Mountaintops of the Giants')
SET IDENTITY_INSERT [dbo].[EldenRing_Locations] OFF
GO
SET IDENTITY_INSERT [dbo].[EldenRing_Types] ON 

INSERT [dbo].[EldenRing_Types] ([id], [type]) VALUES (1, N'Demigod')
INSERT [dbo].[EldenRing_Types] ([id], [type]) VALUES (2, N'Legend')
INSERT [dbo].[EldenRing_Types] ([id], [type]) VALUES (3, N'God')
SET IDENTITY_INSERT [dbo].[EldenRing_Types] OFF
GO
ALTER TABLE [dbo].[EldenRing_Bosses]  WITH CHECK ADD  CONSTRAINT [FK_EldenRing_Bosses_EldenRing_Damage] FOREIGN KEY([strength_id])
REFERENCES [dbo].[EldenRing_Damage] ([id])
GO
ALTER TABLE [dbo].[EldenRing_Bosses] CHECK CONSTRAINT [FK_EldenRing_Bosses_EldenRing_Damage]
GO
ALTER TABLE [dbo].[EldenRing_Bosses]  WITH CHECK ADD  CONSTRAINT [FK_EldenRing_Bosses_EldenRing_Damage1] FOREIGN KEY([weakness_id])
REFERENCES [dbo].[EldenRing_Damage] ([id])
GO
ALTER TABLE [dbo].[EldenRing_Bosses] CHECK CONSTRAINT [FK_EldenRing_Bosses_EldenRing_Damage1]
GO
ALTER TABLE [dbo].[EldenRing_Bosses]  WITH CHECK ADD  CONSTRAINT [FK_EldenRing_Bosses_EldenRing_Locations] FOREIGN KEY([location_id])
REFERENCES [dbo].[EldenRing_Locations] ([id])
GO
ALTER TABLE [dbo].[EldenRing_Bosses] CHECK CONSTRAINT [FK_EldenRing_Bosses_EldenRing_Locations]
GO
ALTER TABLE [dbo].[EldenRing_Bosses]  WITH CHECK ADD  CONSTRAINT [FK_EldenRing_Bosses_EldenRing_Types] FOREIGN KEY([type_id])
REFERENCES [dbo].[EldenRing_Types] ([id])
GO
ALTER TABLE [dbo].[EldenRing_Bosses] CHECK CONSTRAINT [FK_EldenRing_Bosses_EldenRing_Types]
GO
/****** Object:  StoredProcedure [dbo].[spGetAllDamages]    Script Date: 12/12/2022 1:07:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spGetAllDamages]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.EldenRing_Damage
END
GO
/****** Object:  StoredProcedure [dbo].[spGetAllLocations]    Script Date: 12/12/2022 1:07:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spGetAllLocations]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.EldenRing_Locations
END
GO
/****** Object:  StoredProcedure [dbo].[spSelectFromView]    Script Date: 12/12/2022 1:07:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spSelectFromView]
	-- Add the parameters for the stored procedure here
	@ViewName nvarchar(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @SQL nvarchar(max)

    -- Insert statements for procedure here
	SET @SQL = 'SELECT * FROM ' + @ViewName

	EXEC sys.sp_executesql @SQL
END
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
         Begin Table = "EldenRing_Bosses"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 170
               Right = 242
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "EldenRing_Locations"
            Begin Extent = 
               Top = 7
               Left = 290
               Bottom = 126
               Right = 484
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
         Table = 1176
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
         SortOrder = 1416
         GroupBy = 1350
         Filter = 1356
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_EldenRingChartOne'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_EldenRingChartOne'
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
         Left = -1491
      End
      Begin Tables = 
         Begin Table = "EldenRing_Bosses"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 170
               Right = 258
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "EldenRing_Damage"
            Begin Extent = 
               Top = 7
               Left = 1539
               Bottom = 126
               Right = 1749
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
         Table = 1176
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
         SortOrder = 1416
         GroupBy = 1350
         Filter = 1356
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_EldenRingChartTwo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_EldenRingChartTwo'
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
         Begin Table = "EldenRing_Bosses"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 170
               Right = 242
            End
            DisplayFlags = 280
            TopColumn = 2
         End
         Begin Table = "EldenRing_Damage"
            Begin Extent = 
               Top = 7
               Left = 290
               Bottom = 126
               Right = 484
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "EldenRing_Locations"
            Begin Extent = 
               Top = 7
               Left = 532
               Bottom = 126
               Right = 726
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "EldenRing_Types"
            Begin Extent = 
               Top = 7
               Left = 774
               Bottom = 126
               Right = 968
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
      Begin ColumnWidths = 11
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_EldenRingFullReport'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_EldenRingFullReport'
GO
