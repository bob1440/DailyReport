using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

static public partial class Puwu
{

    public class Verify
    {

        static public bool String(string s)
        {
            return (s != null && s.Length > 0);
        }

        static public bool List<T>(List<T> l)
        {
            return (l != null && l.Count > 0);
        }

        static public bool Dictionary<K, V>(Dictionary<K, V> dict)
        {
            return (dict != null && dict.Count > 0);
        }
    }
}