using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prBall.Code
{
    public class VuzBallsArticle
    {

        static List<Article> _articles;

        StringBuilder _html;

        public void AddBallsCategory(string category)
        {
            _html.Append(category.H2());
        }
        public VuzBallsArticle()
        {
            _html = new StringBuilder();
        }

        public void AddSection(StringTable st, string name)
        {
            _html.Append(name.P().Strong());
            _html.Append(HtmlHelper.GetAdaptiveDesignTable(st));

            _html = _html.Replace("<td>Проходной балл</td>", @"<td style=""width:130px"">Проходной балл</td>");
        }

        public string GetHtml()
        {
            return _html.ToString();
        }

        public static StringTable GetStringTableFromCFData(List<CFData2016> data, TypeLearning type)
        {
            StringTable st = new StringTable(data.Count + 1, 2);
            st.AddHeader("Специальности (направления специальностей)", "Проходной балл");

            List<Article> articles = GetAllSpecialityArticles();

            for (int i = 0; i < data.Count; i++)
            {
                var currentArticle = articles.Find(a => a.SubTitle.Contains(data[i].Title.Substring(0, 10)));

                string link = String.Format("/abiturient/specialnosty/artmid/520/articleid/{0}/{1}", currentArticle.ArticleID, currentArticle.TitleLink).ToLower();

                string aTeg = data[i].Title.A(link);

                switch (type)
                {
                    case TypeLearning.DnevnoeBudg:
                        st.AddRow(aTeg, data[i].PrBallDnevnBudget.ToString());
                        break;
                    case TypeLearning.DnevnoePlatn:
                        st.AddRow(aTeg, data[i].PrBallDnevnPlatnoe.ToString());
                        break;
                    case TypeLearning.ZaochnoeBudg:
                        st.AddRow(aTeg, data[i].PrBallZaochnBudget.ToString());
                        break;
                    case TypeLearning.ZaochnoePlatnoe:
                        st.AddRow(aTeg, data[i].PrBallZaochnPlatn.ToString());
                        break;
                    case TypeLearning.DistancionnoeBudg:
                        st.AddRow(aTeg, data[i].PrBallDistBudget.ToString());
                        break;
                    case TypeLearning.DistancionnoePlatn:
                        st.AddRow(aTeg, data[i].PrBallDistPlatnoe.ToString());
                        break;
                    case TypeLearning.SokrDnevnBudget:
                        st.AddRow(aTeg, data[i].PrBallSokrDnevnBudg.ToString());
                        break;
                    case TypeLearning.SokrDnevnPlatn:
                        st.AddRow(aTeg, data[i].PrBallSokrDnevnPlatn.ToString());
                        break;
                    case TypeLearning.SokrZaochBudg:
                        st.AddRow(aTeg, data[i].PrBallSokrZaochBudget.ToString());
                        break;
                    case TypeLearning.SokrZaochPlatn:
                        st.AddRow(aTeg, data[i].PrBallSokrZaochPlatnoe.ToString());
                        break;
                    default:
                        break;
                }
            }

            return st;
        }

        private static List<Article> GetAllSpecialityArticles()
        {
            if (_articles==null)
            {
                _articles = new List<Article>();
            }
            else
            {
                return _articles;
            }

            var specArticles = Data.GetArticlesIDFromCategoryID(29);

            foreach (int id in specArticles)
            {
                _articles.Add(Data.GetArticleFromID(id));
            }

            return _articles;
        }

        internal void AddPTag(string txt="")
        {
            _html.Append(txt.P());
        }
    }
}
