/****** Скрипт для команды SelectTopNRows из среды SSMS  ******/
SELECT TOP 100 articleid, COUNT(articleid)
  FROM [budnyby_test].[dbo].[EasyDNNnewsUrlNewProviderData]
  GROUP BY articleid
  ORDER BY COUNT(articleid) DESC
