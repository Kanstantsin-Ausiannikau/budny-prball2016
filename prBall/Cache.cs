using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prBall
{
    public static class Cache
    {
        public static Dictionary<int, List<int>> ArticlesIDs = new Dictionary<int, List<int>>();

        public static Dictionary<int, string> ArticleTexts = new Dictionary<int, string>();

        public static Dictionary<int, int> VuzIDs = new Dictionary<int, int>();

        public static Dictionary<int, string> TitleLinks = new Dictionary<int, string>();

        public static Dictionary<int?, string> Titles = new Dictionary<int?, string>();



    }
}
