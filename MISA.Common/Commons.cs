using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Common
{
    public class Commons
    {
        public static string ConvertGuidToNvarchar(object id)
        {
            return "'" + id + "'";
        }
    }
}
