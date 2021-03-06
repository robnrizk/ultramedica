USE [master]
GO
/****** Object:  Database [DB_ULTRAMEDICA]    Script Date: 02/23/2014 22:32:04 ******/
CREATE DATABASE [DB_ULTRAMEDICA] ON  PRIMARY 
( NAME = N'DB_ULTRAMEDICA', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\DB_ULTRAMEDICA.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DB_ULTRAMEDICA_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\DB_ULTRAMEDICA_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DB_ULTRAMEDICA] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DB_ULTRAMEDICA].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DB_ULTRAMEDICA] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [DB_ULTRAMEDICA] SET ANSI_NULLS OFF
GO
ALTER DATABASE [DB_ULTRAMEDICA] SET ANSI_PADDING OFF
GO
ALTER DATABASE [DB_ULTRAMEDICA] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [DB_ULTRAMEDICA] SET ARITHABORT OFF
GO
ALTER DATABASE [DB_ULTRAMEDICA] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [DB_ULTRAMEDICA] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [DB_ULTRAMEDICA] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [DB_ULTRAMEDICA] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [DB_ULTRAMEDICA] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [DB_ULTRAMEDICA] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [DB_ULTRAMEDICA] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [DB_ULTRAMEDICA] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [DB_ULTRAMEDICA] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [DB_ULTRAMEDICA] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [DB_ULTRAMEDICA] SET  DISABLE_BROKER
GO
ALTER DATABASE [DB_ULTRAMEDICA] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [DB_ULTRAMEDICA] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [DB_ULTRAMEDICA] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [DB_ULTRAMEDICA] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [DB_ULTRAMEDICA] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [DB_ULTRAMEDICA] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [DB_ULTRAMEDICA] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [DB_ULTRAMEDICA] SET  READ_WRITE
GO
ALTER DATABASE [DB_ULTRAMEDICA] SET RECOVERY SIMPLE
GO
ALTER DATABASE [DB_ULTRAMEDICA] SET  MULTI_USER
GO
ALTER DATABASE [DB_ULTRAMEDICA] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [DB_ULTRAMEDICA] SET DB_CHAINING OFF
GO
USE [DB_ULTRAMEDICA]
GO
/****** Object:  Table [dbo].[ROLE]    Script Date: 02/23/2014 22:32:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ROLE](
	[ROLE_ID] [int] IDENTITY(1,1) NOT NULL,
	[ROLE_NAME] [varchar](50) NULL,
 CONSTRAINT [PK_TBL_R_ROLE] PRIMARY KEY CLUSTERED 
(
	[ROLE_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MASTER_SELECT]    Script Date: 02/23/2014 22:32:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MASTER_SELECT](
	[KEY_SELECT] [varchar](50) NULL,
	[VALUE] [varchar](50) NULL,
	[TEXT] [varchar](255) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[USER]    Script Date: 02/23/2014 22:32:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[USER](
	[NIK] [varchar](15) NOT NULL,
	[NAMA] [varchar](30) NULL,
	[POSISI] [varchar](30) NULL,
	[USERNAME] [varchar](50) NULL,
	[PASSWORD] [varchar](20) NULL,
	[ROLES] [varchar](255) NULL,
 CONSTRAINT [PK_TBL_R_ULTRAEMPLOYEE] PRIMARY KEY CLUSTERED 
(
	[NIK] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[COMPANY]    Script Date: 02/23/2014 22:32:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[COMPANY](
	[COMPANY_ID] [int] IDENTITY(1,1) NOT NULL,
	[COMPANY_NAME] [varchar](50) NULL,
	[COMPANY_STATUS] [bit] NOT NULL,
 CONSTRAINT [PK_TBL_R_COMPANY] PRIMARY KEY CLUSTERED 
(
	[COMPANY_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EMPLOYEE]    Script Date: 02/23/2014 22:32:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EMPLOYEE](
	[EMPLOYEE_ID] [varchar](20) NOT NULL,
	[NAME] [varchar](50) NULL,
	[SEX] [varchar](1) NULL,
	[AGE] [int] NULL,
	[MESS_STATUS] [bit] NULL,
	[POSITION] [varchar](50) NULL,
	[DISTRICT] [varchar](20) NOT NULL,
	[DEPARTMENT] [varchar](30) NULL,
	[COMPANY_ID] [int] NOT NULL,
	[STATUS] [bit] NOT NULL,
 CONSTRAINT [PK_TBL_R_FO_1] PRIMARY KEY CLUSTERED 
(
	[EMPLOYEE_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FO]    Script Date: 02/23/2014 22:32:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FO](
	[LAB_ID] [int] NOT NULL,
	[EMPLOYEE_ID] [varchar](20) NOT NULL,
	[YEAR_CHECKUP] [varchar](4) NOT NULL,
	[DATE] [date] NULL,
	[DISTRICT] [varchar](20) NULL,
 CONSTRAINT [PK_FO] PRIMARY KEY CLUSTERED 
(
	[EMPLOYEE_ID] ASC,
	[YEAR_CHECKUP] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FISIK]    Script Date: 02/23/2014 22:32:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FISIK](
	[FISIK_ID] [int] IDENTITY(1,1) NOT NULL,
	[EMPLOYEE_ID] [varchar](20) NULL,
	[YEAR_CHECKUP] [varchar](4) NOT NULL,
	[TEMPAT_KERJA] [varchar](1) NULL,
	[POSISI_KERJA] [varchar](1) NULL,
	[PAPARAN] [varchar](1) NULL,
	[METODE_KERJA] [varchar](1) NULL,
	[RIWAYAT_ASMA] [bit] NULL,
	[RIWAYAT_EPILEPSI] [bit] NULL,
	[RIWAYAT_LEPRA] [bit] NULL,
	[RIWAYAT_ANSIETAS] [bit] NULL,
	[RIWAYAT_DEPRESI] [bit] NULL,
	[RIWAYAT_DM] [bit] NULL,
	[RIWAYAT_PROSTAT] [bit] NULL,
	[RIWAYAT_HEMOROID] [bit] NULL,
	[RIWAYAT_KELAMIN] [bit] NULL,
	[VAKSIN_HEPATITIS] [bit] NULL,
	[RIWAYAT_OPERASI] [bit] NULL,
	[RIWAYAT_KECELAKAAN_KERJA] [bit] NULL,
	[SUMMARY_RIWAYAT_PENYAKIT] [varchar](max) NULL,
	[KEBIASAAN_ALKOHOL] [varchar](1) NULL,
	[KEBIASAAN_OLAHRAGA] [varchar](1) NULL,
	[KEBIASAAN_MEROKOK] [varchar](1) NULL,
	[KEBIASAAN_NARKOBA] [varchar](1) NULL,
	[TINGGI_BADAN] [int] NULL,
	[BERAT_BADAN] [int] NULL,
	[BMI] [decimal](18, 2) NULL,
	[LKR_DD] [int] NULL,
	[LKR_PRT] [int] NULL,
	[T_SISTOL] [int] NULL,
	[T_DIASTOL] [int] NULL,
	[NADI] [int] NULL,
	[RESPIRASI] [int] NULL,
	[VISUS_JAUH_TANPA_KACMATA] [varchar](6) NULL,
	[VISUS_JAUH_DENGAN] [varchar](6) NULL,
	[VISUS_DEKAT_TANPA_KACAMATA] [varchar](6) NULL,
	[VISUS_DEKAT_DENGAN_KACAMATA] [varchar](6) NULL,
	[BUTA_WARNA] [bit] NULL,
	[ANAMNESA_KELUHAN_UTAMA] [varchar](30) NULL,
	[ANAMNESA_KELUHAN_TAMBAHAN] [varchar](30) NULL,
	[MATA] [varchar](30) NULL,
	[TELINGA] [varchar](30) NULL,
	[HIDUNG] [varchar](30) NULL,
	[MULUT] [varchar](30) NULL,
	[FARING] [varchar](30) NULL,
	[TONSIL] [varchar](30) NULL,
	[THYROID] [varchar](30) NULL,
	[LYMP_NODE] [varchar](30) NULL,
	[DADA] [varchar](30) NULL,
	[PERUT] [varchar](30) NULL,
	[HERNIA] [varchar](30) NULL,
	[ANUS] [varchar](30) NULL,
	[PAYUDARA] [varchar](30) NULL,
	[VARICHES_HEMOROID] [varchar](30) NULL,
	[KULIT_KUKU] [varchar](30) NULL,
	[PULMO_SIST_RESPIRASI] [varchar](30) NULL,
	[COR_SIST_CV] [varchar](30) NULL,
	[HATI_LIEN_GIT] [varchar](30) NULL,
	[SUG] [varchar](30) NULL,
	[SIST_REPROD] [varchar](30) NULL,
	[EXTRIMITAS_ATAS] [varchar](30) NULL,
	[EXTRIMITAS_BAWAH] [varchar](30) NULL,
	[OTOT_TULANG_LAIN] [varchar](30) NULL,
	[BAU_MULUT] [bit] NULL,
	[KARIES] [int] NULL,
	[TANGGAL] [int] NULL,
	[SISA_AKAR] [int] NULL,
	[REFLEX_PATOLOGIS] [bit] NULL,
	[PARESTESI] [bit] NULL,
	[PARESE] [bit] NULL,
	[LASSAGUESIGN] [bit] NULL,
	[PATRICK_SIGN] [bit] NULL,
	[CONTRA_PATRICK_SIGN] [bit] NULL,
	[SUMMARY_KESIMPULAN] [varchar](max) NULL,
	[CHECKED_BY] [varchar](15) NULL,
 CONSTRAINT [PK_FISIK] PRIMARY KEY CLUSTERED 
(
	[FISIK_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EKG]    Script Date: 02/23/2014 22:32:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EKG](
	[EKG_ID] [int] NOT NULL,
	[EMPLOYEE_ID] [varchar](20) NOT NULL,
	[YEAR_CHECKUP] [varchar](4) NOT NULL,
	[EKG_RESULT] [varchar](30) NULL,
	[EKG_FILE_NAME] [varchar](50) NULL,
	[CHECKED_BY] [varchar](15) NULL,
 CONSTRAINT [PK_TBL_T_EKG_1] PRIMARY KEY CLUSTERED 
(
	[EKG_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AUDIO]    Script Date: 02/23/2014 22:32:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AUDIO](
	[AUDIO_ID] [int] IDENTITY(1,1) NOT NULL,
	[EMPLOYEE_ID] [varchar](20) NOT NULL,
	[YEAR_CHECKUP] [varchar](4) NOT NULL,
	[AUDIOMETRY_RESULT] [varchar](30) NULL,
	[AUDIOMETRY_FILE_NAME] [varchar](50) NULL,
	[CHECKED_BY] [varchar](15) NULL,
 CONSTRAINT [PK_TBL_T_AUDIO] PRIMARY KEY CLUSTERED 
(
	[AUDIO_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SPIRO]    Script Date: 02/23/2014 22:32:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SPIRO](
	[SPIRO_ID] [int] IDENTITY(1,1) NOT NULL,
	[EMPLOYEE_ID] [varchar](20) NOT NULL,
	[YEAR_CHECKUP] [varchar](4) NOT NULL,
	[SPIROMETRY_RESULT] [varchar](30) NULL,
	[SPIROMETRY_FILE_NAME] [varchar](50) NULL,
	[CHECKED_BY] [varchar](15) NULL,
 CONSTRAINT [PK_TBL_T_SPIRO_1] PRIMARY KEY CLUSTERED 
(
	[SPIRO_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RONTGEN]    Script Date: 02/23/2014 22:32:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RONTGEN](
	[RONTGEN_ID] [int] IDENTITY(1,1) NOT NULL,
	[EMPLOYEE_ID] [varchar](20) NOT NULL,
	[YEAR_CHECKUP] [varchar](4) NOT NULL,
	[RONTGEN_RESULT] [varchar](30) NULL,
	[RONTGEN_FILE_NAME] [varchar](50) NULL,
	[CHECKED_BY] [varchar](15) NULL,
 CONSTRAINT [PK_TBL_T_RONTGEN_1] PRIMARY KEY CLUSTERED 
(
	[RONTGEN_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LABS]    Script Date: 02/23/2014 22:32:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LABS](
	[LABORATORIUM_ID] [int] IDENTITY(1,1) NOT NULL,
	[EMPLOYEE_ID] [varchar](20) NOT NULL,
	[YEAR_CHECKUP] [varchar](4) NOT NULL,
	[HB] [decimal](18, 1) NULL,
	[HCT] [int] NULL,
	[LEUKOSIT] [int] NULL,
	[TROMBOSIT] [int] NULL,
	[ERITROSIT] [decimal](18, 1) NULL,
	[LED] [int] NULL,
	[DIFLIM] [int] NULL,
	[DIFMON] [int] NULL,
	[DIFGRAN] [int] NULL,
	[HBSAG] [bit] NULL,
	[AHBS] [int] NULL,
	[VDRL] [int] NULL,
	[CHOLESTEROL] [int] NULL,
	[TRIGLISERIN] [int] NULL,
	[HDL] [int] NULL,
	[LDL] [int] NULL,
	[BUN] [decimal](18, 1) NULL,
	[CREATINE] [decimal](18, 1) NULL,
	[UA] [decimal](18, 0) NULL,
	[BSN] [int] NULL,
	[2JPP] [int] NULL,
	[OT] [int] NULL,
	[PT] [int] NULL,
	[REDUKSI_PUASA] [bit] NULL,
	[REDUKSI_2JPP] [bit] NULL,
	[WARNA_URINE] [varchar](20) NULL,
	[BJ] [int] NULL,
	[PH] [int] NULL,
	[KETON] [bit] NULL,
	[BIL] [bit] NULL,
	[NITRIT] [bit] NULL,
	[EPITEL] [int] NULL,
	[URINE_LEKOSIT] [int] NULL,
	[URINE_ERITROSIT] [int] NULL,
	[BAKTERI] [bit] NULL,
	[SIL] [bit] NULL,
	[KRISTAL] [bit] NULL,
	[LAB_RESUME] [varchar](max) NULL,
	[CHECKED_BY] [varchar](50) NULL,
 CONSTRAINT [PK_TBL_T_LABS_1] PRIMARY KEY CLUSTERED 
(
	[LABORATORIUM_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[vw_CheckupIDDetail]    Script Date: 02/23/2014 22:32:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_CheckupIDDetail]
AS
SELECT     dbo.FO.EMPLOYEE_ID, dbo.FO.YEAR_CHECKUP, dbo.AUDIO.AUDIO_ID, dbo.EKG.EKG_ID, dbo.FISIK.FISIK_ID, dbo.LABS.LABORATORIUM_ID, 
                      dbo.RONTGEN.RONTGEN_ID, dbo.SPIRO.SPIRO_ID
FROM         dbo.AUDIO INNER JOIN
                      dbo.FO ON dbo.AUDIO.EMPLOYEE_ID = dbo.FO.EMPLOYEE_ID AND dbo.AUDIO.YEAR_CHECKUP = dbo.FO.YEAR_CHECKUP INNER JOIN
                      dbo.EKG ON dbo.FO.EMPLOYEE_ID = dbo.EKG.EMPLOYEE_ID AND dbo.FO.YEAR_CHECKUP = dbo.EKG.YEAR_CHECKUP INNER JOIN
                      dbo.FISIK ON dbo.FO.EMPLOYEE_ID = dbo.FISIK.EMPLOYEE_ID AND dbo.FO.YEAR_CHECKUP = dbo.FISIK.YEAR_CHECKUP INNER JOIN
                      dbo.LABS ON dbo.FO.EMPLOYEE_ID = dbo.LABS.EMPLOYEE_ID AND dbo.FO.YEAR_CHECKUP = dbo.LABS.YEAR_CHECKUP INNER JOIN
                      dbo.RONTGEN ON dbo.FO.EMPLOYEE_ID = dbo.RONTGEN.EMPLOYEE_ID AND dbo.FO.YEAR_CHECKUP = dbo.RONTGEN.YEAR_CHECKUP INNER JOIN
                      dbo.SPIRO ON dbo.FO.EMPLOYEE_ID = dbo.SPIRO.EMPLOYEE_ID
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[53] 4[8] 2[20] 3) )"
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
         Begin Table = "AUDIO"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 163
               Right = 254
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "EKG"
            Begin Extent = 
               Top = 6
               Left = 292
               Bottom = 125
               Right = 461
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "FISIK"
            Begin Extent = 
               Top = 6
               Left = 499
               Bottom = 125
               Right = 763
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "FO"
            Begin Extent = 
               Top = 248
               Left = 478
               Bottom = 367
               Right = 645
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "LABS"
            Begin Extent = 
               Top = 126
               Left = 243
               Bottom = 245
               Right = 429
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "RONTGEN"
            Begin Extent = 
               Top = 126
               Left = 467
               Bottom = 245
               Right = 665
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "SPIRO"
            Begin Extent = 
               Top = 126
               Left = 703
               Bottom = 245
               Right = 917
            End
            DisplayFlags = 280
            TopCol' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_CheckupIDDetail'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'umn = 0
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_CheckupIDDetail'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_CheckupIDDetail'
GO
/****** Object:  ForeignKey [FK_TBL_R_FO_TBL_R_COMPANY]    Script Date: 02/23/2014 22:32:06 ******/
ALTER TABLE [dbo].[EMPLOYEE]  WITH CHECK ADD  CONSTRAINT [FK_TBL_R_FO_TBL_R_COMPANY] FOREIGN KEY([COMPANY_ID])
REFERENCES [dbo].[COMPANY] ([COMPANY_ID])
GO
ALTER TABLE [dbo].[EMPLOYEE] CHECK CONSTRAINT [FK_TBL_R_FO_TBL_R_COMPANY]
GO
/****** Object:  ForeignKey [FK_TBL_T_FO_TBL_R_FO]    Script Date: 02/23/2014 22:32:06 ******/
ALTER TABLE [dbo].[FO]  WITH CHECK ADD  CONSTRAINT [FK_TBL_T_FO_TBL_R_FO] FOREIGN KEY([EMPLOYEE_ID])
REFERENCES [dbo].[EMPLOYEE] ([EMPLOYEE_ID])
GO
ALTER TABLE [dbo].[FO] CHECK CONSTRAINT [FK_TBL_T_FO_TBL_R_FO]
GO
/****** Object:  ForeignKey [FK_FISIK_FO]    Script Date: 02/23/2014 22:32:06 ******/
ALTER TABLE [dbo].[FISIK]  WITH CHECK ADD  CONSTRAINT [FK_FISIK_FO] FOREIGN KEY([EMPLOYEE_ID], [YEAR_CHECKUP])
REFERENCES [dbo].[FO] ([EMPLOYEE_ID], [YEAR_CHECKUP])
GO
ALTER TABLE [dbo].[FISIK] CHECK CONSTRAINT [FK_FISIK_FO]
GO
/****** Object:  ForeignKey [FK_EKG_FO]    Script Date: 02/23/2014 22:32:06 ******/
ALTER TABLE [dbo].[EKG]  WITH CHECK ADD  CONSTRAINT [FK_EKG_FO] FOREIGN KEY([EMPLOYEE_ID], [YEAR_CHECKUP])
REFERENCES [dbo].[FO] ([EMPLOYEE_ID], [YEAR_CHECKUP])
GO
ALTER TABLE [dbo].[EKG] CHECK CONSTRAINT [FK_EKG_FO]
GO
/****** Object:  ForeignKey [FK_AUDIO_FO]    Script Date: 02/23/2014 22:32:06 ******/
ALTER TABLE [dbo].[AUDIO]  WITH CHECK ADD  CONSTRAINT [FK_AUDIO_FO] FOREIGN KEY([EMPLOYEE_ID], [YEAR_CHECKUP])
REFERENCES [dbo].[FO] ([EMPLOYEE_ID], [YEAR_CHECKUP])
GO
ALTER TABLE [dbo].[AUDIO] CHECK CONSTRAINT [FK_AUDIO_FO]
GO
/****** Object:  ForeignKey [FK_SPIRO_FO]    Script Date: 02/23/2014 22:32:06 ******/
ALTER TABLE [dbo].[SPIRO]  WITH CHECK ADD  CONSTRAINT [FK_SPIRO_FO] FOREIGN KEY([EMPLOYEE_ID], [YEAR_CHECKUP])
REFERENCES [dbo].[FO] ([EMPLOYEE_ID], [YEAR_CHECKUP])
GO
ALTER TABLE [dbo].[SPIRO] CHECK CONSTRAINT [FK_SPIRO_FO]
GO
/****** Object:  ForeignKey [FK_RONTGEN_FO]    Script Date: 02/23/2014 22:32:06 ******/
ALTER TABLE [dbo].[RONTGEN]  WITH CHECK ADD  CONSTRAINT [FK_RONTGEN_FO] FOREIGN KEY([EMPLOYEE_ID], [YEAR_CHECKUP])
REFERENCES [dbo].[FO] ([EMPLOYEE_ID], [YEAR_CHECKUP])
GO
ALTER TABLE [dbo].[RONTGEN] CHECK CONSTRAINT [FK_RONTGEN_FO]
GO
/****** Object:  ForeignKey [FK_LABS_FO]    Script Date: 02/23/2014 22:32:06 ******/
ALTER TABLE [dbo].[LABS]  WITH CHECK ADD  CONSTRAINT [FK_LABS_FO] FOREIGN KEY([EMPLOYEE_ID], [YEAR_CHECKUP])
REFERENCES [dbo].[FO] ([EMPLOYEE_ID], [YEAR_CHECKUP])
GO
ALTER TABLE [dbo].[LABS] CHECK CONSTRAINT [FK_LABS_FO]
GO
