using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

static public partial class Puwu
{

    public static class Parsers
    {
        public static List<T> ValuesListFromString<T>(string s, Func<string, T> parseFunc, char sliptter = ',')
        {
            List<T> list = new List<T>();

            string[] term = s.Split(sliptter);

            foreach (string t in term)
            {
                string _t = t.Trim();
                if (_t == "") continue;

                list.Add(parseFunc(_t));
            }

            return list;
        }

        public static Dictionary<string, object> Class2Dic<T>(T parseClass)
        {
            return (parseClass.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
            .ToDictionary(prop => prop.Name, prop => prop.GetValue(parseClass, null)));
        }

        public static T Dic2Class<T>(Dictionary<string, object> dict)
        {
            Type type = typeof(T);
            var obj = Activator.CreateInstance(type);

            foreach (var kv in dict)
            {
                type.GetProperty(kv.Key).SetValue(obj, kv.Value);
            }
            return (T)obj;
        }
    }
}