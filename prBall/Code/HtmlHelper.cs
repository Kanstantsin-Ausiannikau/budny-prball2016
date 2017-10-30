using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prBall.Code
{
    enum TypeLearning { Dnevnoe, Zaochnoe, Distancionnoe, Sokraschennoe };

    public class HtmlHelper
    {
        public static string AddAdaptiveDesignTable(string html, StringTable st)
        {
            StringBuilder sbHtml = new StringBuilder(html);

            sbHtml.Append(@"<table class=""table table-striped table-bordered"">");
            sbHtml.Append(@"<tbody>");

            for (int i=0;i<st.RowCount;i++)
            { 
                sbHtml.Append("<tr>");

                for (int j=0;j<st.ColumnCount;j++)
                {
                    sbHtml.Append("<td>");

                    sbHtml.Append(st[i, j]);

                    sbHtml.Append("</td>");
                }
                sbHtml.Append("</tr>");
            }

            sbHtml.Append(@"</tbody>");
            sbHtml.Append(@"</table>");

            return sbHtml.ToString();
        }

        internal static string CreateLink(string link, string text)
        {
            return String.Format("<a href={0}>{1}</a>", link, text);
        }
    }
}
