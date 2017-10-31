using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prBall.Code
{
    public enum TypeLearning { DnevnoeBudg, DnevnoePlatn, ZaochnoeBudg, ZaochnoePlatnoe, DistancionnoeBudg, DistancionnoePlatn, SokraschennoeBudg, SokraschennoePlatn };

    public static class HtmlHelper
    {
        public static string GetAdaptiveDesignTable(StringTable st)
        {
            StringBuilder sbHtml = new StringBuilder();

            sbHtml.Append(@"<table class=""table table-striped table-bordered"">");
            sbHtml.Append(@"<tbody>");

            for (int i=0;i<st.RowCount;i++)
            { 
                sbHtml.Append("<tr>");

                for (int j=0;j<st.ColumnCount;j++)
                {
                    sbHtml.Append(st[i, j].TD());
                }
                sbHtml.Append("</tr>");
            }

            sbHtml.Append(@"</tbody>");
            sbHtml.Append(@"</table>");

            return sbHtml.ToString();
        }

        public static string TR(this string str)
        {
            return String.Format("<tr>{0}</tr>", str);
        }

        public static string P(this string str)
        {
            return String.Format("<p>{0}</p>", str);
        }

        public static string TD(this string str)
        {
            return $"<td>{str}</td>";
        }


        public static string A(this string text, string link)
        {
            return String.Format(@"<a href=""{0}"">{1}</a>", link, text);
        }

        public static string H2(this string  str)
        {
            return String.Format("<h2>{0}</h2>", str);
        }

        internal static string H1(this string str)
        {
            return String.Format("<h1>{0}</h1>", str);
        }

        public static string Strong(this string str)
        {
            return String.Format("<strong>{0}</strong>", str);
        }
    }
}
