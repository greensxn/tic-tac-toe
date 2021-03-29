using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormXO
{
    class Start
    {
        public static bool IsName;
        public static String name1;
        public static String name2;
        public static String[,] mat = new String[3,3] { { " ", " ", " " }, { " ", " ", " " }, { " ", " ", " " } };

        public Start() {
            name1 = "";
            name2 = "";
            IsName = false;
        }
    }
}
