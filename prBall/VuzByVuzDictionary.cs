using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prBall
{
    public static class VuzByVuzDictionary
    {
        static Dictionary<int, int> vuzCategoryFromArticleId = new Dictionary<int, int>() 
        { 
            {16,108},
            {17,107},
            {54,116},
            {45,582},
            {18,106},
            {19,105},
            {32,583},
            {13,131},
            {20,104},
            {21,103},
            {22,102},
            {23,101},
            {15,109},
            {24,100},
            {25,99},
            {65,126},
            {28,98},
            {29,97},
            {30,96},
            {66,125},
            {8,46},
            {51,81},
            {14,132},
            {27,114},
            {53,113},
            {57,120},
            {58,119},
            {59,118},
            {61,117},
            {5175,543},
            {31,95},
            {67,124},
            {69,123},
            {70,122},
            {71,121},
            {73,112},
            {74,111},
            {75,110},
            {33,93},
            {34,92},
            {35,91},
            {36,90},
            {40,89},
            {41,88},
            {42,87},
            {44,86},
            {47,84},
            {48,83},
            {49,82},
            {9,45},
            {11,44},
            {12,43},
            {72,140},
            {55,115},
            {64,129},
            {52,80}
        };

        public static int GetVuzID(int id)
        {
            try
            {
                return vuzCategoryFromArticleId[id];
            }
            catch (KeyNotFoundException)
            {
                return -1;
            }
        }

        public static int GetVuzArticleIDFromCategoryID(int id)
        {
            var myKey = vuzCategoryFromArticleId.FirstOrDefault(x => x.Value == id).Key;

            return myKey;
        }
    }
}
