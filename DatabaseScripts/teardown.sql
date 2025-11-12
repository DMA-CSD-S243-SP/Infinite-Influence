Use [InfiniteInfluence]
ALTER TABLE [AnnouncementInfluencer] DROP Constraint [CHK_SufficientFollowers]
GO

DROP FUNCTION [HasSufficientFollowers]
GO

ALTER TABLE [AnnouncementInfluencer] DROP Constraint [CHK_FullAnnouncement]
GO

DROP FUNCTION [dbo].[AvailableSpots]
GO

DROP TABLE [AnnouncementInfluencer]
GO

DROP TABLE [Announcement]
GO

DROP TABLE [Company]
GO

DROP TABLE [Influencer]
GO