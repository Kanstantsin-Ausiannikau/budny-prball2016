using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prBall
{
    class ExcelData
    {
        //public static DataTable GetDataFromExcel(string fileName)
        //{
        //    DataTable data = GenerateTable();

        //    FileInfo existingFile = new FileInfo(fileName);

        //    using (ExcelPackage package = new ExcelPackage(existingFile))
        //    {
        //        if (package.Workbook.Worksheets.Count == 0)
        //        {
        //            return null;
        //        }

        //        ExcelWorksheet worksheet = package.Workbook.Worksheets[1];

        //        if (worksheet.Cells[1, 1].Value.ToString() == "Артикул")
        //        {
        //            ReadFromFullExcelFile(data, worksheet);
        //        }
        //        else
        //        {
        //            ReadFromCustomExcelFile(data, worksheet);
        //        }
        //    }
        //    return data;
        //}

        //private static void ReadFromCustomExcelFile(DataTable data, ExcelWorksheet worksheet)
        //{
        //    for (int i = 2; i <= worksheet.Dimension.Rows; i++)
        //    {
        //        var row = data.NewRow();

        //        row["Наименование \nтовара"] = worksheet.Cells[i, 1].Value;
        //        row["Цена"] = worksheet.Cells[i, 2].Value;
        //        row["Картинка"] = worksheet.Cells[i, 3].Value;
        //        row["Валюта"] = "Российский рубль";
        //        row["Регион поставки"] = "Москва;Московская;";

        //        data.Rows.Add(row);
        //    }
        //}

        //private static void ReadFromFullExcelFile(DataTable data, ExcelWorksheet worksheet)
        //{
        //    for (int i = 2; i <= worksheet.Dimension.Rows; i++)
        //    {

        //        if (worksheet.Cells[i, 2].Value == null)
        //        {
        //            continue;
        //        }

        //        var row = data.NewRow();


        //        row["Артикул"] = worksheet.Cells[i, 1].Value;
        //        row["Категория \nпродукции"] = worksheet.Cells[i, 2].Value;
        //        row["Наименование \nоферты"] = worksheet.Cells[i, 3].Value;
        //        row["Тип единицы\n измерения"] = worksheet.Cells[i, 4].Value;
        //        row["Единица\n измерения"] = worksheet.Cells[i, 5].Value;
        //        row["Цена"] = worksheet.Cells[i, 6].Value;
        //        row["Ставка НДС"] = worksheet.Cells[i, 7].Value;
        //        row["Минимальное \nколичество"] = worksheet.Cells[i, 8].Value;
        //        row["Максимальное \nколичество"] = worksheet.Cells[i, 9].Value;

        //        try
        //        {
        //            row["Дата начала\nдействия"] = Convert.ToDateTime(worksheet.Cells[i, 10].Value).ToString("dd/MM/yyyy");
        //        }
        //        catch
        //        {
        //            row["Дата начала\nдействия"] = "";
        //        }

        //        try
        //        {
        //            row["Дата окончания\nдействия"] = Convert.ToDateTime(worksheet.Cells[i, 11].Value).ToString("dd/MM/yyyy");
        //        }
        //        catch
        //        {
        //            row["Дата окончания\nдействия"] = "";
        //        }

        //        row["Кол-во дней\nдля поставки ОТ"] = worksheet.Cells[i, 12].Value;
        //        row["Кол-во дней\nдля поставки ДО"] = worksheet.Cells[i, 13].Value;
        //        row["Единица\nупаковки"] = worksheet.Cells[i, 14].Value;
        //        row["Кол-во в\nупаковке"] = worksheet.Cells[i, 15].Value;
        //        row["Регион поставки"] = worksheet.Cells[i, 16].Value;
        //        row["Дополнительно"] = worksheet.Cells[i, 17].Value;

        //        row["Картинка"] = worksheet.Cells[i, 18].Value;
        //        row["Тэги"] = worksheet.Cells[i, 19].Value;
        //        row["Наименование \nтовара"] = worksheet.Cells[i, 20].Value;
        //        row["Показывать\nгосударственным\nзаказчикам"] = worksheet.Cells[i, 21].Value;
        //        row["Доступно для\nзаказа физическими\nлицами"] = worksheet.Cells[i, 22].Value;
        //        row["Детали"] = worksheet.Cells[i, 24].Value;
        //        row["Валюта"] = worksheet.Cells[i, 23].Value;
        //        row["Дополнительные\nсведения"] = worksheet.Cells[i, 26].Value;

        //        row["Проект контракта"] = worksheet.Cells[i, 25].Value;

        //        data.Rows.Add(row);
        //    }
        //}


        //internal static void SaveDataToExcel(DataGridViewRowCollection rows, string fileName)
        //{
        //    if (File.Exists(fileName))
        //    {
        //        try
        //        {
        //            File.Delete(fileName);
        //        }
        //        catch (FieldAccessException)
        //        {
        //            MessageBox.Show("Ошибка доступа к файлу {0}", fileName);
        //        }
        //    }

        //    FileInfo file = new FileInfo(fileName);
        //    using (ExcelPackage package = new ExcelPackage(file))
        //    {
        //        package.Workbook.Worksheets.Add("Лист 1");

        //        ExcelWorksheet worksheet = package.Workbook.Worksheets["Лист 1"];

        //        worksheet.Cells[1, 1].Value = "Артикул";
        //        worksheet.Cells[1, 2].Value = "Категория продукции";
        //        worksheet.Cells[1, 3].Value = "Наименование оферты";
        //        worksheet.Cells[1, 4].Value = "Тип единицы измерения";
        //        worksheet.Cells[1, 5].Value = "Единица измерения";
        //        worksheet.Cells[1, 6].Value = "Цена за единицу продуукции";
        //        worksheet.Cells[1, 7].Value = "Ставка НДС";
        //        worksheet.Cells[1, 8].Value = "Минимальное ко-во";
        //        worksheet.Cells[1, 9].Value = "Максимальное кол-во";
        //        worksheet.Cells[1, 10].Value = "Дата начала действия";
        //        worksheet.Cells[1, 11].Value = "Дата окончания действия";
        //        worksheet.Cells[1, 12].Value = "Количество дней для поставки ОТ";
        //        worksheet.Cells[1, 13].Value = "Количество дне для поставки ДО";
        //        worksheet.Cells[1, 14].Value = "Единица упаковки";
        //        worksheet.Cells[1, 15].Value = "Количество единиц в упаковке";
        //        worksheet.Cells[1, 16].Value = "Регион поставки";
        //        worksheet.Cells[1, 17].Value = "Дополнительные сведения";
        //        worksheet.Cells[1, 18].Value = "Изображение";
        //        worksheet.Cells[1, 19].Value = "Тэги";
        //        worksheet.Cells[1, 20].Value = "Наименование товара";
        //        worksheet.Cells[1, 21].Value = "Показывать государственным заказчикам";
        //        worksheet.Cells[1, 22].Value = "Доступно для заказа физическими лицами";
        //        worksheet.Cells[1, 23].Value = "Валюта";
        //        worksheet.Cells[1, 24].Value = "Детали";
        //        worksheet.Cells[1, 25].Value = "Проект контракта";
        //        worksheet.Cells[1, 26].Value = "Дополнительные сведения";
        //        worksheet.Cells[1, 27].Value = "CategoryId";
        //        worksheet.Cells[1, 28].Value = "NotUsedDetails";


        //        for (int i = 0; i < rows.Count; i++)
        //        {
        //            worksheet.Cells[i + 2, 1].Value = rows[i].Cells[0].Value;
        //            worksheet.Cells[i + 2, 2].Value = rows[i].Cells[2].Value;
        //            worksheet.Cells[i + 2, 3].Value = rows[i].Cells[3].Value;
        //            worksheet.Cells[i + 2, 4].Value = rows[i].Cells[4].Value;
        //            worksheet.Cells[i + 2, 5].Value = rows[i].Cells[5].Value;
        //            worksheet.Cells[i + 2, 6].Value = rows[i].Cells[6].Value;
        //            worksheet.Cells[i + 2, 7].Value = rows[i].Cells[7].Value;
        //            worksheet.Cells[i + 2, 8].Value = rows[i].Cells[8].Value;
        //            worksheet.Cells[i + 2, 9].Value = rows[i].Cells[9].Value;
        //            worksheet.Cells[i + 2, 10].Value = rows[i].Cells[10].Value;
        //            worksheet.Cells[i + 2, 11].Value = rows[i].Cells[11].Value;
        //            worksheet.Cells[i + 2, 12].Value = rows[i].Cells[12].Value;
        //            worksheet.Cells[i + 2, 13].Value = rows[i].Cells[13].Value;
        //            worksheet.Cells[i + 2, 14].Value = rows[i].Cells[14].Value;
        //            worksheet.Cells[i + 2, 15].Value = rows[i].Cells[15].Value;
        //            worksheet.Cells[i + 2, 16].Value = rows[i].Cells[16].Value;
        //            worksheet.Cells[i + 2, 17].Value = rows[i].Cells[1].Value;
        //            worksheet.Cells[i + 2, 18].Value = rows[i].Cells[18].Value;
        //            worksheet.Cells[i + 2, 19].Value = rows[i].Cells[19].Value;
        //            worksheet.Cells[i + 2, 20].Value = rows[i].Cells[1].Value;
        //            worksheet.Cells[i + 2, 21].Value = rows[i].Cells[20].Value;
        //            worksheet.Cells[i + 2, 22].Value = rows[i].Cells[21].Value;
        //            worksheet.Cells[i + 2, 23].Value = rows[i].Cells[25].Value;
        //            //worksheet.Cells[i + 2, 24].Value = rows[i].Cells[23].Value;
        //            worksheet.Cells[i + 2, 25].Value = rows[i].Cells[23].Value;
        //            worksheet.Cells[i + 2, 26].Value = rows[i].Cells[22].Value;
        //            worksheet.Cells[i + 2, 27].Value = "";
        //            worksheet.Cells[i + 2, 28].Value = "";
        //            try
        //            {
        //                worksheet.Cells[i + 2, 24].Value = ((Details)rows[i].Cells[2].Tag).ConvertDetailsToString();
        //            }
        //            catch (NullReferenceException)
        //            {
        //                worksheet.Cells[i + 2, 24].Value = "";
        //            }

        //            // worksheet.Cells[i + 2, 26].Value = rows[i].Cells[22].Value;
        //        }

        //        package.SaveAs(file);

        //    }
        //}
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
                foreach(CFData2016 item in data)
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
