using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace BuggyCarsDemo.Modal
{
    public static class JasonHandler
    {
        public static List<T> DeserializeJasonArray<T>(string file)
        {
            var jasonData = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, file));
            return JsonConvert.DeserializeObject<List<T>>(jasonData);
        }
    }
}
