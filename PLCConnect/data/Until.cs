using IniParser;
using IniParser.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLCConnect
{
    public class Until
    {
        private static readonly Until m_instance = new Until();
        private readonly string _path;
        private readonly FileIniDataParser _parser = new FileIniDataParser();
        public static Until Instance => m_instance;
        public Until(string path="config.ini")
        {
            _path = path;
        }

        public void SaveObject<T>(T obj, string sectionName = "General")
        {
            var data = new IniData();
            var section = data[sectionName];

            foreach (var prop in typeof(T).GetProperties())
            {
                object value = prop.GetValue(obj);
                section[prop.Name] = value?.ToString() ?? "";
            }

            _parser.WriteFile(_path, data);
        }

        public T LoadObject<T>(string sectionName = "General") where T : new()
        {
            T obj = new T();
            if (!System.IO.File.Exists(_path)) return obj;

            var data = _parser.ReadFile(_path);
            if (!data.Sections.ContainsSection(sectionName)) return obj;

            var section = data[sectionName];

            foreach (var prop in typeof(T).GetProperties())
            {
                if (section.ContainsKey(prop.Name))
                {
                    string raw = section[prop.Name];
                    object converted = Convert.ChangeType(raw, prop.PropertyType);
                    prop.SetValue(obj, converted);
                }
            }

            return obj;
        }

    }
}
