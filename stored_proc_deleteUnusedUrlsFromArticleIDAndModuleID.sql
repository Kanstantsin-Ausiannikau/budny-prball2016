CREATE PROCEDURE [dbo].[DeleteUnusedUrls]
(
@ArticleId int,
@ModuleId int
)
AS
BEGIN

	DELETE
	FROM [budnyby_test].[dbo].[dnn_temp]


	INSERT INTO [budnyby_test].[dbo].[dnn_temp] 
           ([PortalID]
           ,[LinkTitle]
           ,[OriginalUrlString]
           ,[TabID]
           ,[ModuleID]
           ,[ArtMID]
           ,[ArticleID]
           ,[PID]
           ,[CategoryID]
           ,[TagID]
           ,[mcat]
           ,[authorid]
           ,[profilegroupid]
           ,[ArtDate]
           ,[ArticleName]
           ,[TagName]
           ,[CategoryName]
           ,[AuthorName]
           ,[ProfileGroupName]
           ,[ev]
           ,[evl]
           ,[LinkType])
SELECT TOP 1 
           [PortalID]
           ,[LinkTitle]
           ,[OriginalUrlString]
           ,[TabID]
           ,[ModuleID]
           ,[ArtMID]
           ,[ArticleID]
           ,[PID]
           ,[CategoryID]
           ,[TagID]
           ,[mcat]
           ,[authorid]
           ,[profilegroupid]
           ,[ArtDate]
           ,[ArticleName]
           ,[TagName]
           ,[CategoryName]
           ,[AuthorName]
           ,[ProfileGroupName]
           ,[ev]
           ,[evl]
           ,[LinkType]
FROM [budnyby_test].[dbo].[EasyDNNnewsUrlNewProviderData]
WHERE ArticleID=@ArticleId and ModuleID=@ModuleID

DELETE FROM [budnyby_test].[dbo].[EasyDNNnewsUrlNewProviderData]
WHERE ArticleID=@ArticleId

INSERT INTO [budnyby_test].[dbo].[EasyDNNnewsUrlNewProviderData] 
           ([PortalID]
           ,[LinkTitle]
           ,[OriginalUrlString]
           ,[TabID]
           ,[ModuleID]
           ,[ArtMID]
           ,[ArticleID]
           ,[PID]
           ,[CategoryID]
           ,[TagID]
           ,[mcat]
           ,[authorid]
           ,[profilegroupid]
           ,[ArtDate]
           ,[ArticleName]
           ,[TagName]
           ,[CategoryName]
           ,[AuthorName]
           ,[ProfileGroupName]
           ,[ev]
           ,[evl]
           ,[LinkType])
SELECT
           [PortalID]
           ,[LinkTitle]
           ,[OriginalUrlString]
           ,[TabID]
           ,[ModuleID]
           ,[ArtMID]
           ,[ArticleID]
           ,[PID]
           ,[CategoryID]
           ,[TagID]
           ,[mcat]
           ,[authorid]
           ,[profilegroupid]
           ,[ArtDate]
           ,[ArticleName]
           ,[TagName]
           ,[CategoryName]
           ,[AuthorName]
           ,[ProfileGroupName]
           ,[ev]
           ,[evl]
           ,[LinkType]
FROM [budnyby_test].[dbo].[dnn_temp]

END
GO


