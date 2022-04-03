using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoboApi.Model;
using System.IO;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace RoboApi.Service
{
    public class ReadFile
    {
        public static List<Passageiro> ExtrairDados(string pathFile)
        {
            StreamReader reader = new(pathFile);
            string jsonString = reader.ReadToEnd();
            var dados = JsonConvert.DeserializeObject<List<Passageiro>>(jsonString);
            if (dados != null)
                return dados;
            return null;

        }

    }
}
