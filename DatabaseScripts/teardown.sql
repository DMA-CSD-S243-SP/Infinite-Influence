Use [InfiniteInfluence]
ALTER TABLE [AnnouncementInfluencer] DROP Constraint IF EXISTS [CHK_SufficientFollowers]
GO

DROP FUNCTION IF EXISTS [HasSufficientFollowers] 
GO

ALTER TABLE [AnnouncementInfluencer] DROP Constraint IF EXISTS [CHK_FullAnnouncement]
GO

DROP FUNCTION IF EXISTS [dbo].[AvailableSpots]
GO

DROP TABLE IF EXISTS [AnnouncementInfluencer]
GO

DROP TABLE IF EXISTS [Announcement]
GO

DROP TABLE IF EXISTS [Company]
GO

DROP TABLE IF EXISTS [Influencer]
GO

DROP TABLE IF EXISTS [Logins]
GO