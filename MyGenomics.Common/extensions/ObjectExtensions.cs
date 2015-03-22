using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenomics.Common.extensions
{
    public static class ObjectExtensions
    {
        public static string ConvertToString(this object objectToConvert)
        {
            if (objectToConvert != null)
            {
                return objectToConvert.ToString();
            }
            else
            {
                return "";
            }
        }

        public static int ConvertToInt(this object objectToConvert)
        {
            if (objectToConvert != null)
            {
                return Convert.ToInt16(objectToConvert);
            }
            else
            {
                return 0;
            }
        }
    }
}
