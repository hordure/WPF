using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMaster2016
{
    public class CloseWindow
    {
        

        public static void CloseW()
        {
            App.Current.Properties["CloseWindow"] = true;
        }
    }
}
