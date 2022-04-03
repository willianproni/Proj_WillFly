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
        public static List<Passageiro> ExtrairDadosPassageiro(string pathFile)
        {
            StreamReader reader = new(pathFile);
            string jsonString = reader.ReadToEnd();
            var dados = JsonConvert.DeserializeObject<List<Passageiro>>(jsonString);
            if (dados != null)
                return dados;
            return null;
        }

        public static List<PrecoBase> ExtrairDadosJsonPrecoBase(string pathFile)
        {
            StreamReader reader = new StreamReader(pathFile);
            string jsonString = reader.ReadToEnd();
            var listaPrecoBase = JsonConvert.DeserializeObject<List<PrecoBase>>(jsonString);
            if (listaPrecoBase != null)
                return listaPrecoBase;
            return null;
        }

        public static List<Voo>? GetDataVoo(string pathFile)
        {
            StreamReader lerArquivo = new StreamReader(pathFile);
            string jsonString = lerArquivo.ReadToEnd();
            var lstVoo = JsonConvert.DeserializeObject<List<Voo>>(jsonString);
            if (lstVoo != null)
                return lstVoo;
            return null;

        }

    }
}
