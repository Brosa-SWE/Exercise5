using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5
{
    public static class Extensions
    {
        #region Left function
        // The parameter source is the source string, the value is the substring to be looked up,
        // and the include indicates whether the returned result contains the substring to be looked up.
        // The parameters of the following methods have similar meanings.
        public static string Left(this string source, string value, bool include)
        {
            int pos = source.IndexOf(value);
            if (pos > -1)
            {
                if (include)
                {
                    return source.Substring(0, pos + value.Length);
                }
                else
                {
                    return source.Substring(0, pos);
                }
            }
            else
            {
                return "";
            }
        }
 
             // The overload of the above method, only accept two string parameters,
             // the returned results do not include the substring to be found.
       public static string Left(this string source, string value)
        {
            return Left(source, value, false);
        }

        // Override the second string argument of the first Left method to a character type.
        public static string Left(this string source, char value, bool include)
        {
            return Left(source, Convert.ToString(value), include);
        }

        public static string Left(this string source, char value)
        {
            return Left(source, value, false);
        }

        #endregion

        #region Right() function

        public static string Right(this string source, string value, bool include)
        {
            int pos = source.IndexOf(value);
            if (pos > -1)
            {
                if (include)
                {
                    return source.Substring(pos);
                }
                else
                {
                    return source.Substring(pos + value.Length);
                }
            }
            else
            {
                return "";
            }
        }

        public static string Right(this string source, string value)
        {
            return Right(source, value, false);
        }

        public static string Right(this string source, char value, bool include)
        {
            return Right(source, Convert.ToString(value), include);
        }

        public static string Right(this string source, char value)
        {
            return Right(source, value, false);
        }

        #endregion

        #region LeftBack() function

        public static string LeftBack(this string source, string value, bool include)
        {
            int pos = source.LastIndexOf(value);
            if (pos > -1)
            {
                if (include)
                {
                    return source.Substring(0, pos + value.Length);
                }
                else
                {
                    return source.Substring(0, pos);
                }
            }
            else
            {
                return "";
            }
        }

        public static string LeftBack(this string source, string value)
        {
            return LeftBack(source, value, false);
        }

        public static string LeftBack(this string source, char value, bool include)
        {
            return LeftBack(source, Convert.ToString(value), false);
        }

        public static string LeftBack(this string source, char value)
        {
            return LeftBack(source, value, false);
        }

        #endregion

        #region RightBack() function

        public static string RightBack(this string source, string value, bool include)
        {
            int pos = source.LastIndexOf(value);
            if (pos > -1)
            {
                if (include)
                {
                    return source.Substring(pos);
                }
                else
                {
                    return source.Substring(pos + value.Length);
                }
            }
            else
            {
                return "";
            }
        }

        public static string RightBack(this string source, string value)
        {
            return RightBack(source, value, false);
        }

        public static string RightBack(this string source, char value, bool include)
        {
            return RightBack(source, Convert.ToString(value), include);
        }

        public static string RightBack(this string source, char value)
        {
            return RightBack(source, value, false);
        }

        #endregion
    }
}
