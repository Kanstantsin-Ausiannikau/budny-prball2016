using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prBall
{
    public class LinkerEntity
    {
        public string OldLink
        { get; set; }

        public string NewLink
        { get; set; }

        public int? ArticleID
        { get; set; }

        public int ModuleID
        { get; set; }

        public string WhereThisLink
        { get; set; }


        public static void ConvertToCsvFormat(List<LinkerEntity> list, string fileName)
        {
            using (StreamWriter outputLogFile = new StreamWriter(fileName, true))
            {
                foreach (LinkerEntity entity in list)
                {
                    outputLogFile.WriteLine(String.Format("{0};{1};{2};{3};{4}", entity.ArticleID, entity.ModuleID, entity.OldLink, entity.NewLink, entity.WhereThisLink));
                }
            }
        }

    }
}
