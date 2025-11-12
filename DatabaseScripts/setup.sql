If DB_ID('InfinitInfluence') IS NOT NULL
Create Database [InfiniteInfluence];
GO

Use [InfiniteInfluence]

Create Table [Influencer]
(
	[Id] int identity(1,1) primary key NOT NULL,
	[Username] varchar(32) NOT NULL,
	[Credentials] varchar (256) NOT NULL,
	[DisplayName] nvarchar(64) NOT NULL,
	[VerificationStatus] bit NOT NULL,
	[ProfileImageUrl] varchar(256) NOT NULL,
	[Location] varchar(64) NOT NULL,
	[MainPlatformUrl] varchar(256) NOT NULL,
	[Followers] int NOT NULL,
);
GO

Create Table [Company]
(
	[Id] int identity(1,1) primary key NOT NULL,
	[Username] varchar(32) NOT NULL,
	[Credentials] varchar (256) NOT NULL,
	[CompanyName] nvarchar(64) NOT NULL,
	[VerificationStatus] bit NOT NULL,
	[CompanyLogoUrl] varchar(256) NOT NULL,
	[Location] varchar(64) NOT NULL,
	[Email] varchar(64) NOT NULL,
	[PhoneNumer] varchar(32) NOT NULL,
);
GO

Create Table [Announcement]
(
	[Id] int identity(1,1) primary key NOT NULL,
	[BannerUrl] varchar(256) NOT NULL,
	[Title] varchar(32) NOT NULL,
	[Description] varchar(512) NOT NULL,
	[StatusType] bit NOT NULL,
	[CreationDate] datetime2 NOT NULL default SYSDATETIME(), -- If no creation time is given, then current time is assumed.
	[VisibilityState] bit NOT NULL,
	[StartDisplayDate] datetime2 NOT NULL default SYSDATETIME(), -- If no start time is given, then current time is assumed.
	[EndDisplayDate] datetime2 NOT NULL default '9999-12-31 23:59:59.997', -- If no end time is given, effectively indefinite is assumed.
	[MaximumApplicants] int NOT NULL default 2147483647, -- If no limit is given, max integer value is assumed.
	[RequiredFollowers] int NOT NULL default 0, -- If no requirement is given, none is assumed.
	[CompanyId] int NOT NULL,

	Constraint [FK_Announcement_Company] foreign Key ([CompanyId]) references Company(Id) on delete cascade
	-- It doesn't make sense to have an announcement for a deleted company, so announcements are deleted with it.
);
GO

Create Table [AnnouncementInfluencer]
(
	[AnnouncementId] int NOT NULL,
	[InfluencerId] int NOT NULL,
	[ApplicationDate] datetime2 NOT NULL default SYSDATETIME(), -- If no creation time is given, then current time is assumed.
	
	Constraint [PK_AnnouncementInfluencer] primary key (AnnouncementId, InfluencerId),
	Constraint [FK_AnnouncementInfluencer_Announcement] foreign key (AnnouncementId) references Announcement(Id),
	Constraint [FK_AnnouncementInfluencer_Influencer] foreign key (InfluencerId) references Influencer(Id),
);
GO

-- This function checks how many available spots a given Announcement has
Create Function [AvailableSpots](@AnnouncementId int)
Returns int as
Begin
	IF EXISTS(SELECT * FROM [dbo].[Announcement] where Announcement.Id = @AnnouncementId)
	BEGIN	
		DECLARE @MaxApplicants int;
		SELECT @MaxApplicants = [Announcement].[MaximumApplicants] FROM [Announcement] WHERE [Announcement].[Id] = @AnnouncementId;
		DECLARE @CurrentApplicants int;
		SELECT @CurrentApplicants = COUNT(*) FROM [AnnouncementInfluencer] WHERE [AnnouncementInfluencer].[AnnouncementId] = @AnnouncementId;
		Return @MaxApplicants - @CurrentApplicants;
	END;
	Return 0; -- Catches if AnnouncementId is invalid
End;
GO

ALTER TABLE [AnnouncementInfluencer] ADD Constraint [CHK_FullAnnouncement] CHECK ([dbo].[AvailableSpots]([AnnouncementId]) > 0);
GO