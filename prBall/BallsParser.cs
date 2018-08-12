using HtmlAgilityPack;
using prBall.Code;
using System;
using System.Collections.Generic;
using System.Linq;

namespace prBall
{
    public class BallsParser
    {
        internal static List<BallsParsingItem> Parse(HtmlDocument doc)
        {
            List<BallsParsingItem> items = new List<BallsParsingItem>();

            if (doc!=null)
            {
                var s = doc.DocumentNode.SelectNodes("//table")[1];

                TypeLearning? tLearning = null;

                foreach (var row in s.SelectNodes(".//tr"))
                {
                    var cells = row.SelectNodes("td");

                    if (cells!=null)
                    {
                        if (cells.Count==1)
                        {
                            if (cells[0].InnerText == "Заочная сокращенная дистанционная (платная)")
                            {
                                tLearning = TypeLearning.SokrZaochPlatn;
                            }

                            if (cells[0].InnerText == "Дневная")
                            {
                                tLearning = TypeLearning.DnevnoeBudg;
                            }

                            if (cells[0].InnerText == "Дневная (платная)")
                            {
                                tLearning = TypeLearning.DnevnoePlatn;
                            }
                            if (cells[0].InnerText == "Дневная сокращенная")
                            {
                                tLearning = TypeLearning.SokrDnevnBudget;
                            }
                            if (cells[0].InnerText == "Заочная")
                            {
                                tLearning = TypeLearning.ZaochnoeBudg;
                            }
                            if (cells[0].InnerText == "Заочная (платная)")
                            {
                                tLearning = TypeLearning.ZaochnoePlatnoe;
                            }
                            if (cells[0].InnerText == "Заочная сокращенная")
                            {
                                tLearning = TypeLearning.SokrZaochBudg;
                            }

                            if (cells[0].InnerText == "Заочная сокращенная (платная)")
                            {
                                tLearning = TypeLearning.SokrZaochPlatn;
                            }
                        }

                        if (cells.Count>1&&!string.IsNullOrEmpty(cells[1].InnerHtml))
                        {
                            BallsParsingItem parseItem = new BallsParsingItem();

                            parseItem.Speciality = cells[0].InnerHtml;
                            parseItem.Value = Convert.ToDecimal(cells[1].InnerHtml.Replace('.',','));
                            parseItem.Type = tLearning;

                            items.Add(parseItem);

                        }
                    }
                }
            }
            return items;
        }



        internal static string GetBallsArticleText(List<CFData2016> cfData, string shortName, int year)
        {
            VuzBallsArticle article = new VuzBallsArticle();


            var allFakulties = cfData.Select(x => x.FakultetID).Distinct();

            if (cfData.FindAll(t => t.PrBallDnevnBudget != null).Count > 0)
            {

                article.AddBallsCategory($"Проходные баллы в {shortName} на бюджет в {year} году");


                foreach (var id in allFakulties)
                {
                    var facultyName = Data.GetFacultyNameByID(id);

                    var data = cfData.FindAll(t => t.PrBallDnevnBudget != null && t.FakultetID == id);

                    if (data.Count > 0)
                    {
                        StringTable st = VuzBallsArticle.GetStringTableFromCFData(data, TypeLearning.DnevnoeBudg);

                        article.AddSection(st, facultyName);

                        article.AddPTag();
                    }
                }
            }

            if (cfData.FindAll(t => t.PrBallZaochnBudget != null).Count > 0)
            {

                article.AddBallsCategory($"Проходные баллы в {shortName} на заочное отделение в {year} году");

                foreach (var id in allFakulties)
                {
                    var facultyName = Data.GetFacultyNameByID(id);

                    var data = cfData.FindAll(t => t.PrBallZaochnBudget != null && t.FakultetID == id);

                    if (data.Count > 0)
                    {
                        StringTable st = VuzBallsArticle.GetStringTableFromCFData(data, TypeLearning.ZaochnoeBudg);

                        article.AddSection(st, facultyName);

                        article.AddPTag();
                    }
                }
            }

            if (cfData.FindAll(t => t.PrBallDnevnPlatnoe != null).Count > 0)
            {

                article.AddBallsCategory($"{shortName}: Проходные баллы на платное (дневную платную форму обучения) в {year} году");

                foreach (var id in allFakulties)
                {
                    var facultyName = Data.GetFacultyNameByID(id);

                    var data = cfData.FindAll(t => t.PrBallDnevnPlatnoe != null && t.FakultetID == id);

                    if (data.Count > 0)
                    {
                        StringTable st = VuzBallsArticle.GetStringTableFromCFData(data, TypeLearning.DnevnoePlatn);

                        article.AddSection(st, facultyName);

                        article.AddPTag();
                    }
                }
            }

            if (cfData.FindAll(t => t.PrBallZaochnPlatn != null).Count > 0)
            {

                article.AddBallsCategory($"{shortName}: Проходные баллы на заочное платное (заочную платную форму обучения) в {year} году");

                foreach (var id in allFakulties)
                {
                    var facultyName = Data.GetFacultyNameByID(id);

                    var data = cfData.FindAll(t => t.PrBallZaochnPlatn != null && t.FakultetID == id);

                    if (data.Count > 0)
                    {
                        StringTable st = VuzBallsArticle.GetStringTableFromCFData(data, TypeLearning.ZaochnoePlatnoe);

                        article.AddSection(st, facultyName);

                        article.AddPTag();
                    }
                }
            }

            article.AddPTag("Поиск по проходным баллам по другим вузам и другим формам обучения, по сертификатам ЦТ можно найти " + "здесь".A("/abiturient/spsearch"));

           return article.GetHtml();
        }
    }
}
