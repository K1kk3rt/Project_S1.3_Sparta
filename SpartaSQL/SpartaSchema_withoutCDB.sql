USE [SpartaA1]
GO
/****** Object:  User [writer]    Script Date: 2016-10-11 15:39:46 ******/
CREATE USER [writer] FOR LOGIN [spartainholland] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [reader]    Script Date: 2016-10-11 15:39:46 ******/
CREATE USER [reader] FOR LOGIN [spartainholland] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_datareader] ADD MEMBER [writer]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [writer]
GO
ALTER ROLE [db_datareader] ADD MEMBER [reader]
GO
/****** Object:  Table [dbo].[BlokTijd]    Script Date: 2016-10-11 15:39:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlokTijd](
	[BlokId] [int] NOT NULL,
	[BeginTijd] [smallint] NOT NULL,
	[EindTijd] [smallint] NOT NULL,
 CONSTRAINT [PK_BlokTijd] PRIMARY KEY CLUSTERED 
(
	[BlokId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ContactInfo]    Script Date: 2016-10-11 15:39:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactInfo](
	[ContactInfoId] [int] IDENTITY(10,1) NOT NULL,
	[PersoonId] [int] NOT NULL,
	[Straat] [nvarchar](50) NOT NULL,
	[Huisnummer] [int] NOT NULL CONSTRAINT [DF_ContactInfo_Huisnummer]  DEFAULT ((0)),
	[Huisnummertoevoeging] [nvarchar](10) NULL,
	[Plaats] [nvarchar](50) NOT NULL,
	[Postcode] [nchar](6) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[Telefoon] [nvarchar](20) NULL,
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[ContactInfoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Cursus]    Script Date: 2016-10-11 15:39:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cursus](
	[CursusId] [int] IDENTITY(1,1) NOT NULL,
	[Naam] [nvarchar](50) NOT NULL,
	[Niveau] [smallint] NOT NULL,
	[Toelichting] [nvarchar](50) NOT NULL,
	[Categorie] [smallint] NOT NULL,
 CONSTRAINT [PK_Sport] PRIMARY KEY CLUSTERED 
(
	[CursusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Inschrijving]    Script Date: 2016-10-11 15:39:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inschrijving](
	[InschrijvingId] [int] IDENTITY(1,1) NOT NULL,
	[PersoonId] [int] NOT NULL,
	[CursusId] [int] NOT NULL,
 CONSTRAINT [PK_Inschrijving] PRIMARY KEY CLUSTERED 
(
	[InschrijvingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InstructeurRooster]    Script Date: 2016-10-11 15:39:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InstructeurRooster](
	[InstructeurId] [int] NOT NULL,
	[RoosterId] [int] NOT NULL,
 CONSTRAINT [PK_InstructeurRooster] PRIMARY KEY CLUSTERED 
(
	[InstructeurId] ASC,
	[RoosterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Instructie]    Script Date: 2016-10-11 15:39:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Instructie](
	[InstructeurId] [int] IDENTITY(1,1) NOT NULL,
	[PersoonId] [int] NOT NULL,
	[CursusId] [int] NOT NULL,
 CONSTRAINT [PK_Instructeur] PRIMARY KEY CLUSTERED 
(
	[InstructeurId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Locatie]    Script Date: 2016-10-11 15:39:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Locatie](
	[LocatieId] [int] IDENTITY(1,1) NOT NULL,
	[Gebouw] [nvarchar](50) NULL,
	[Zaal] [nvarchar](10) NULL,
	[Omschrijving] [nvarchar](50) NULL,
 CONSTRAINT [PK_Locatie] PRIMARY KEY CLUSTERED 
(
	[LocatieId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Login]    Script Date: 2016-10-11 15:39:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login](
	[LoginId] [int] IDENTITY(1,1) NOT NULL,
	[AanmeldNaam] [nvarchar](50) NOT NULL,
	[PwdHash] [nchar](32) NOT NULL,
	[PersoonId] [int] NOT NULL,
 CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED 
(
	[LoginId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Persoon]    Script Date: 2016-10-11 15:39:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persoon](
	[PersoonId] [int] IDENTITY(1,1) NOT NULL,
	[Naam] [nvarchar](50) NOT NULL,
	[Achternaam] [nvarchar](50) NOT NULL,
	[Categorie] [smallint] NOT NULL CONSTRAINT [DF_pers_Categorie]  DEFAULT ((0)),
	[GeboorteDatum] [date] NULL,
 CONSTRAINT [PK_pers] PRIMARY KEY CLUSTERED 
(
	[PersoonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rooster]    Script Date: 2016-10-11 15:39:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rooster](
	[RoosterId] [int] IDENTITY(1,1) NOT NULL,
	[CursusId] [int] NOT NULL,
	[LocatieId] [int] NOT NULL,
	[DagId] [int] NOT NULL,
	[BlokId] [int] NOT NULL,
 CONSTRAINT [PK_Rooster] PRIMARY KEY CLUSTERED 
(
	[RoosterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Index [IX_ContactPersoon]    Script Date: 2016-10-11 15:39:46 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_ContactPersoon] ON [dbo].[ContactInfo]
(
	[PersoonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Instructeur]    Script Date: 2016-10-11 15:39:46 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Instructeur] ON [dbo].[Instructie]
(
	[PersoonId] ASC,
	[CursusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Aanmeld]    Script Date: 2016-10-11 15:39:46 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Aanmeld] ON [dbo].[Login]
(
	[AanmeldNaam] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_LoginPersoon]    Script Date: 2016-10-11 15:39:46 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_LoginPersoon] ON [dbo].[Login]
(
	[PersoonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Instructeur]    Script Date: 2016-10-11 15:39:46 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Instructeur] ON [dbo].[Rooster]
(
	[CursusId] ASC,
	[DagId] ASC,
	[BlokId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ContactInfo]  WITH CHECK ADD  CONSTRAINT [FK_ContactInfo_Persoon] FOREIGN KEY([PersoonId])
REFERENCES [dbo].[Persoon] ([PersoonId])
GO
ALTER TABLE [dbo].[ContactInfo] CHECK CONSTRAINT [FK_ContactInfo_Persoon]
GO
ALTER TABLE [dbo].[Inschrijving]  WITH CHECK ADD  CONSTRAINT [FK_Inschrijving_Cursus] FOREIGN KEY([CursusId])
REFERENCES [dbo].[Cursus] ([CursusId])
GO
ALTER TABLE [dbo].[Inschrijving] CHECK CONSTRAINT [FK_Inschrijving_Cursus]
GO
ALTER TABLE [dbo].[Inschrijving]  WITH CHECK ADD  CONSTRAINT [FK_Inschrijving_Persoon] FOREIGN KEY([PersoonId])
REFERENCES [dbo].[Persoon] ([PersoonId])
GO
ALTER TABLE [dbo].[Inschrijving] CHECK CONSTRAINT [FK_Inschrijving_Persoon]
GO
ALTER TABLE [dbo].[InstructeurRooster]  WITH CHECK ADD  CONSTRAINT [FK_InstructeurRooster_Instructeur] FOREIGN KEY([InstructeurId])
REFERENCES [dbo].[Instructie] ([InstructeurId])
GO
ALTER TABLE [dbo].[InstructeurRooster] CHECK CONSTRAINT [FK_InstructeurRooster_Instructeur]
GO
ALTER TABLE [dbo].[InstructeurRooster]  WITH CHECK ADD  CONSTRAINT [FK_InstructeurRooster_Rooster] FOREIGN KEY([RoosterId])
REFERENCES [dbo].[Rooster] ([RoosterId])
GO
ALTER TABLE [dbo].[InstructeurRooster] CHECK CONSTRAINT [FK_InstructeurRooster_Rooster]
GO
ALTER TABLE [dbo].[Instructie]  WITH CHECK ADD  CONSTRAINT [FK_Instructeur_Cursus] FOREIGN KEY([CursusId])
REFERENCES [dbo].[Cursus] ([CursusId])
GO
ALTER TABLE [dbo].[Instructie] CHECK CONSTRAINT [FK_Instructeur_Cursus]
GO
ALTER TABLE [dbo].[Instructie]  WITH CHECK ADD  CONSTRAINT [FK_Instructeur_Persoon] FOREIGN KEY([PersoonId])
REFERENCES [dbo].[Persoon] ([PersoonId])
GO
ALTER TABLE [dbo].[Instructie] CHECK CONSTRAINT [FK_Instructeur_Persoon]
GO
ALTER TABLE [dbo].[Login]  WITH CHECK ADD  CONSTRAINT [FK_Login_Persoon] FOREIGN KEY([PersoonId])
REFERENCES [dbo].[Persoon] ([PersoonId])
GO
ALTER TABLE [dbo].[Login] CHECK CONSTRAINT [FK_Login_Persoon]
GO
ALTER TABLE [dbo].[Rooster]  WITH CHECK ADD  CONSTRAINT [FK_Rooster_BlokTijd] FOREIGN KEY([BlokId])
REFERENCES [dbo].[BlokTijd] ([BlokId])
GO
ALTER TABLE [dbo].[Rooster] CHECK CONSTRAINT [FK_Rooster_BlokTijd]
GO
ALTER TABLE [dbo].[Rooster]  WITH CHECK ADD  CONSTRAINT [FK_Rooster_Cursus] FOREIGN KEY([CursusId])
REFERENCES [dbo].[Cursus] ([CursusId])
GO
ALTER TABLE [dbo].[Rooster] CHECK CONSTRAINT [FK_Rooster_Cursus]
GO
ALTER TABLE [dbo].[Rooster]  WITH CHECK ADD  CONSTRAINT [FK_Rooster_Locatie] FOREIGN KEY([LocatieId])
REFERENCES [dbo].[Locatie] ([LocatieId])
GO
ALTER TABLE [dbo].[Rooster] CHECK CONSTRAINT [FK_Rooster_Locatie]
GO
USE [master]
GO
ALTER DATABASE [SpartaA1] SET  READ_WRITE 
GO
