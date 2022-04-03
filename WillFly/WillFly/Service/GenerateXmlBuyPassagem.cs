using System;
using System.Linq;
using System.Xml.Linq;

namespace WillFly.Service
   
{
    public class GenerateXmlBuyPassagem
    {
        public void Metodo()
        {
            string passagem = @"https://localhost:44367/api/Passageiroes";

            Console.WriteLine("Inicio");

            var listaPassageiro = ReadFile.getData(passagem);

            if (listaPassageiro != null)
            {
                
            }
        }
    }
}
