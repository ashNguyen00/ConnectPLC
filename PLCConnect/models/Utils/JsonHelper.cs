using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PLCConnect
{
    public static class JsonHelper
    {
        private static string path = "Config\\";
        private static string name = "Conf.json";
        public static T LoadSetting<T>() where T : new()
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            string json = File.ReadAllText(path+ name);
            try {
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception ex) {
                MessageBox.Show("SystemFile need to check" + ex.ToString());
                return new T();
            }
        }

        public static void SaveData<T>(T data)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            try
            {
                string _sTestSpecString = JsonConvert.SerializeObject(data);
                string _sTestSpecStringIndented = JToken.Parse(_sTestSpecString).ToString(Formatting.Indented);
                File.WriteAllText(path + name, _sTestSpecStringIndented);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving settings: " + ex.ToString());
            }
        }
    }
}
