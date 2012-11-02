using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility2
{
    class Current
    {
        public const string TimeStamp = "yyyy.MM.dd HH-mm-ss";
        public static string DataFolder()
        {
            return Environment.CurrentDirectory + "\\";
        }
    }
}
