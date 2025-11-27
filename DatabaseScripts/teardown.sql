Use [InfiniteInfluence]
ALTER TABLE [AnnouncementInfluencer] DROP Constraint IF EXISTS [CHK_SufficientFollowers]
GO

DROP FUNCTION IF EXISTS [HasSufficientFollowers] 
GO

ALTER TABLE [AnnouncementInfluencer] DROP Constraint IF EXISTS [CHK_FullAnnouncement]
GO

DROP FUNCTION IF EXISTS [dbo].[AvailableSpots]
GO

DROP TABLE [AnnouncementInfluencer]
GO

DROP TABLE [Announcement]
GO

DROP TABLE [Company]
GO

DROP TABLE [Influencer]
GO