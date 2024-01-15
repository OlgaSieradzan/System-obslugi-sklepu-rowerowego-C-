using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_project
{
    public interface IDatabase
    {
        public string GetInfo(string key);

        public void ZapiszXML(string nazwa);

    }

    public static class DatabaseExtensions
    {
        public static string DictionarieToString<T>(this IDatabase database, Dictionary<string, T> dictionary)
        {
            StringBuilder result = new StringBuilder();

            foreach (var kvp in dictionary)
            {
                result.AppendLine($"{kvp.Value.ToString()}");
            }

            return result.ToString();
        }

        public static string ListToString<T>(this IDatabase database, List<T> list)
        {
            if (list == null)
            {
                return "This objcet doesn't exist in dictionaries";
            }

            StringBuilder result = new StringBuilder();

            foreach (var item in list)
            {
                result.AppendLine(item.ToString());
            }

            return result.ToString();
        }
    }
}
