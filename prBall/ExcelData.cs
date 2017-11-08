using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;

namespace prBall
{
    class ExcelData
    {
        public static List<CFData2016> LoadFromExcel(string fileName)
        {
            FileInfo existingFile = new FileInfo(fileName);

            using (ExcelPackage package = new ExcelPackage(existingFile))
            {
                if (package.Workbook.Worksheets.Count == 0)
                {
                    return null;
                }

                List<CFData2016> list = new List<CFData2016>();

                ExcelWorksheet worksheet = package.Workbook.Worksheets[1];

                for (int i = 2; i <= worksheet.Dimension.Rows; i++)
                {
                    CFData2016 item = new CFData2016();

                    item.Title = worksheet.Cells[i, 1].Value.ToString();

                    if (worksheet.Cells[i, 2].Value != null)
                    {
                        item.TypeObuchDnevnoe = worksheet.Cells[i, 2].Value.ToString() == "+";
                    }
                    else
                    {
                        item.TypeObuchDnevnoe = false;
                    }

                    if (worksheet.Cells[i, 3].Value!=null)
                    {
                        item.TypeObuchZaochnoe = worksheet.Cells[i, 3].Value.ToString() == "+";
                    }
                    else
                    {
                        item.TypeObuchZaochnoe = false;
                    }

                    if (worksheet.Cells[i, 4].Value != null)
                    {
                        item.TypeObuchSokrasch = worksheet.Cells[i, 4].Value.ToString() == "+";
                    }
                    else
                    {
                        item.TypeObuchSokrasch = false;
                    }

                    if (worksheet.Cells[i, 5].Value != null)
                    {
                        item.TypeObuchDistanc = worksheet.Cells[i, 5].Value.ToString() == "+";
                    }
                    else
                    {
                        item.TypeObuchDistanc = false;
                    }


                    if (worksheet.Cells[i, 6].Value != null)
                    {
                        item.PrBallDnevnBudget = Convert.ToDecimal(worksheet.Cells[i, 6].Value);
                    }
                    if (worksheet.Cells[i, 7].Value != null)
                    {
                        item.PrBallDnevnPlatnoe = Convert.ToDecimal(worksheet.Cells[i, 7].Value);
                    }
                    if (worksheet.Cells[i, 8].Value != null)
                    {
                        item.PrBallZaochnBudget = Convert.ToDecimal(worksheet.Cells[i, 8].Value);
                    }
                    if (worksheet.Cells[i, 9].Value != null)
                    {
                        item.PrBallZaochnPlatn = Convert.ToDecimal(worksheet.Cells[i, 9].Value);
                    }
                    if (worksheet.Cells[i, 10].Value != null)
                    {
                        item.PrBallSokrDnevnBudg = Convert.ToDecimal(worksheet.Cells[i, 10].Value);
                    }

                    if (worksheet.Cells[i, 11].Value != null)
                    {
                        item.PrBallSokrDnevnPlatn = Convert.ToDecimal(worksheet.Cells[i, 11].Value);
                    }
                    if (worksheet.Cells[i, 12].Value != null)
                    {
                        item.PrBallSokrZaochBudget = Convert.ToDecimal(worksheet.Cells[i, 12].Value);
                    }
                    if (worksheet.Cells[i, 13].Value != null)
                    {
                        item.PrBallSokrZaochPlatnoe = Convert.ToDecimal(worksheet.Cells[i, 13].Value);
                    }
                    if (worksheet.Cells[i, 14].Value != null)
                    {
                        item.PrBallDistBudget = Convert.ToDecimal(worksheet.Cells[i, 14].Value);
                    }
                    if (worksheet.Cells[i, 15].Value != null)
                    {
                        item.PrBallDistPlatnoe = Convert.ToDecimal(worksheet.Cells[i, 15].Value);
                    }
                    item.CertBiologia = worksheet.Cells[i, 16].Value.ToString() == "+";
                    item.CertFizika = worksheet.Cells[i, 17].Value.ToString() == "+";
                    item.CertGeografia = worksheet.Cells[i, 18].Value.ToString() == "+";
                    item.CertHimia = worksheet.Cells[i, 19].Value.ToString() == "+";
                    item.CertInostrYazik = worksheet.Cells[i, 20].Value.ToString() == "+";
                    item.CertIstoriaBelorus = worksheet.Cells[i, 21].Value.ToString() == "+";
                    item.CertMatemat = worksheet.Cells[i, 22].Value.ToString() == "+";
                    item.CertObschestvoved = worksheet.Cells[i, 23].Value.ToString() == "+";
                    item.CertProfSobesed = worksheet.Cells[i, 24].Value.ToString() == "+";
                    item.CertRusskiy = worksheet.Cells[i, 25].Value.ToString() == "+";
                    item.CertSpecEkzamen = worksheet.Cells[i, 26].Value.ToString() == "+";
                    item.CertVsemirIstoria = worksheet.Cells[i, 27].Value.ToString() == "+";
                    item.NapravleniePodgotovki = int.Parse(worksheet.Cells[i, 28].Value.ToString());
                    item.GorodID = int.Parse(worksheet.Cells[i, 29].Value.ToString());
                    item.VuzID = int.Parse(worksheet.Cells[i, 30].Value.ToString());
                    item.FakultetID = int.Parse(worksheet.Cells[i, 31].Value.ToString());
                    item.ArticleID = int.Parse(worksheet.Cells[i, 32].Value.ToString());
                    item.PreviousArticleID = int.Parse(worksheet.Cells[i, 33].Value.ToString());

                    list.Add(item);
                }
                return list;
            }
        }

        internal static void SaveToExcel(List<CFData2016> data, string fileName)
        {
            if (File.Exists(fileName))
            {
                try
                {
                    File.Delete(fileName);
                }
                catch (FieldAccessException ex)
                {
                    throw ex;
                }
            }

            FileInfo file = new FileInfo(fileName);
            using (ExcelPackage package = new ExcelPackage(file))
            {
                package.Workbook.Worksheets.Add("Лист 1");
                ExcelWorksheet worksheet = package.Workbook.Worksheets["Лист 1"];

                SetHeader(worksheet);

                int i = 2;
                foreach (CFData2016 item in data)
                {
                    worksheet.Cells[i, 1].Value = item.Title;
                    worksheet.Cells[i, 2].Value = item.TypeObuchDnevnoe == true ? "+" : "";
                    worksheet.Cells[i, 3].Value = item.TypeObuchZaochnoe == true ? "+" : "";
                    worksheet.Cells[i, 4].Value = item.TypeObuchSokrasch == true ? "+" : "";
                    worksheet.Cells[i, 5].Value = item.TypeObuchDistanc == true ? "+" : "";
                    worksheet.Cells[i, 6].Value = item.PrBallDnevnBudget;
                    worksheet.Cells[i, 7].Value = item.PrBallDnevnPlatnoe;
                    worksheet.Cells[i, 8].Value = item.PrBallZaochnBudget;
                    worksheet.Cells[i, 9].Value = item.PrBallZaochnPlatn;
                    worksheet.Cells[i, 10].Value = item.PrBallSokrDnevnBudg;
                    worksheet.Cells[i, 11].Value = item.PrBallSokrDnevnPlatn;
                    worksheet.Cells[i, 12].Value = item.PrBallSokrZaochBudget;
                    worksheet.Cells[i, 13].Value = item.PrBallSokrZaochPlatnoe;
                    worksheet.Cells[i, 14].Value = item.PrBallDistBudget;
                    worksheet.Cells[i, 15].Value = item.PrBallDistPlatnoe;
                    worksheet.Cells[i, 16].Value = item.CertBiologia == true ? "+" : "";
                    worksheet.Cells[i, 17].Value = item.CertFizika == true ? "+" : "";
                    worksheet.Cells[i, 18].Value = item.CertGeografia == true ? "+" : "";
                    worksheet.Cells[i, 19].Value = item.CertHimia == true ? "+" : "";
                    worksheet.Cells[i, 20].Value = item.CertInostrYazik == true ? "+" : "";
                    worksheet.Cells[i, 21].Value = item.CertIstoriaBelorus == true ? "+" : "";
                    worksheet.Cells[i, 22].Value = item.CertMatemat == true ? "+" : "";
                    worksheet.Cells[i, 23].Value = item.CertObschestvoved == true ? "+" : "";
                    worksheet.Cells[i, 24].Value = item.CertProfSobesed == true ? "+" : "";
                    worksheet.Cells[i, 25].Value = item.CertRusskiy == true ? "+" : "";
                    worksheet.Cells[i, 26].Value = item.CertSpecEkzamen == true ? "+" : "";
                    worksheet.Cells[i, 27].Value = item.CertVsemirIstoria == true ? "+" : "";
                    worksheet.Cells[i, 28].Value = item.NapravleniePodgotovki;
                    worksheet.Cells[i, 29].Value = item.GorodID;
                    worksheet.Cells[i, 30].Value = item.VuzID;
                    worksheet.Cells[i, 31].Value = item.FakultetID;
                    worksheet.Cells[i, 32].Value = item.ArticleID;
                    worksheet.Cells[i, 33].Value = item.PreviousArticleID;

                    i++;
                }
                package.SaveAs(file);
            }
        }

        private static void SetHeader(ExcelWorksheet worksheet)
        {
            worksheet.Cells[1, 1].Value = "Специальность";
            worksheet.Cells[1, 2].Value = "Дневное";
            worksheet.Cells[1, 3].Value = "Заочн";
            worksheet.Cells[1, 4].Value = "Сокращ";
            worksheet.Cells[1, 5].Value = "Дистанц";
            worksheet.Cells[1, 6].Value = "Днев-бюдж";
            worksheet.Cells[1, 7].Value = "Днев-платн";
            worksheet.Cells[1, 8].Value = "Заочн-бюдж";
            worksheet.Cells[1, 9].Value = "Заочн-платн";
            worksheet.Cells[1, 10].Value = "Сокр.дневн-бюдж";
            worksheet.Cells[1, 11].Value = "Сокр.дневн-платн";
            worksheet.Cells[1, 12].Value = "Сокр.заочн-бюдж";
            worksheet.Cells[1, 13].Value = "Сокр.заочн-платн";
            worksheet.Cells[1, 14].Value = "Дист-бюдж";
            worksheet.Cells[1, 15].Value = "Дист-платн";
            worksheet.Cells[1, 16].Value = "Серт-биология";
            worksheet.Cells[1, 17].Value = "Серт-физика";
            worksheet.Cells[1, 18].Value = "Серт-география";
            worksheet.Cells[1, 19].Value = "Серт-химия";
            worksheet.Cells[1, 20].Value = "Серт-ин.яз";
            worksheet.Cells[1, 21].Value = "Серт-ист.белор";
            worksheet.Cells[1, 22].Value = "Серт-математика";
            worksheet.Cells[1, 23].Value = "Серт-обществоведение";
            worksheet.Cells[1, 24].Value = "Проф. собесед";
            worksheet.Cells[1, 25].Value = "Серт-Русский";
            worksheet.Cells[1, 26].Value = "Спец.экзамен";
            worksheet.Cells[1, 27].Value = "Серт-Всем.история";
            worksheet.Cells[1, 28].Value = "Направление.подгот";
            worksheet.Cells[1, 29].Value = "Город";
            worksheet.Cells[1, 30].Value = "Вуз";
            worksheet.Cells[1, 31].Value = "Факультет";
            worksheet.Cells[1, 32].Value = "ArticleID";
            worksheet.Cells[1, 33].Value = "PreviousArticleID";
        }
    }
}
