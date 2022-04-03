using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using WillFly.Model;

namespace WillFly.Service
{
    public class ReadFile
    {
        public static List<Passageiro>? getData(string pathFile)
        {
            StreamReader r = new StreamReader(pathFile);
            string jsonString = r.ReadToEnd();
            var lst = JsonConvert.DeserializeObject<List<Passageiro >> (jsonString);
            if (lst != null)
                return lst;
            return null;
        }
    }
}
