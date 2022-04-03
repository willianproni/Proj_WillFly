using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RoboApi.Service
{
    internal class RelatorioPrecoBase
    {
        public static void ArquivoXmlPrecoBase()
        {
            string pathFile = @"C:\5by5\WillFly\PrecoBases.json";

            Console.WriteLine("Start");

            var listaPrecoBase = ReadFile.ExtrairDadosJsonPrecoBase(pathFile);

            if (listaPrecoBase != null)
            {
                var precoBaseXML = new XElement("Root",
                    from data in listaPrecoBase
                    select new XElement("precobase",
                            new XElement("id", data.Id),
                            new XElement("voo_origem",
                            new XElement("cep", data.Voo.Origem.Endereco.Cep),
                            new XElement("localidade", data.Voo.Origem.Endereco.Localidade),
                            new XElement("uf", data.Voo.Origem.Endereco.Uf),
                            new XElement("bairro", data.Voo.Origem.Endereco.Bairro),
                            new XElement("complemento", data.Voo.Origem.Endereco.Complemento),
                            new XElement("voo_destino",
                            new XElement("cep", data.Voo.Destino.Endereco.Cep),
                            new XElement("localidade", data.Voo.Destino.Endereco.Localidade),
                            new XElement("uf", data.Voo.Destino.Endereco.Uf),
                            new XElement("bairro", data.Voo.Destino.Endereco.Bairro),
                            new XElement("complemento", data.Voo.Destino.Endereco.Complemento),
                            new XElement("valor", data.Valor),
                            new XElement("valortotal", data.ValorTotal),
                            new XElement("promocaoporcentagem", data.PromocaoPorcentagem),
                            new XElement("classe",
                            new XElement("classe_descricao", data.Classe.Descricao),
                            new XElement("datainclusao", data.DataInclusao)
                            )))));

                Console.WriteLine(precoBaseXML);

            }
            Console.WriteLine("Fim");
        }
    }
}
