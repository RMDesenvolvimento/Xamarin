using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace rmpdv
{
	public class Produtos 
	{

		public Produtos (string json, string campo = "", string pesquisa = "") 
		{
			JObject jObject = JObject.Parse(json);
			Console.WriteLine("Objeto {0}",jObject);

			JToken jProd = jObject["data_produto"];
			Console.WriteLine("Array {0}",jProd);

			Todos = new List<RegistroProdutos>();

			foreach (var item in jProd) {

				RegistroProdutos um = new RegistroProdutos ();
				string registro = item.ToString();	

				var leitura = Newtonsoft.Json.Linq.JObject.Parse (registro);

				if ((campo != "" && pesquisa != "") || (campo == "" && pesquisa == "")) {

					id = (int)leitura ["id"];
					nome = (string) leitura["nome"];
					preco = (float) leitura["preco"];

				} else {

					id = 0;
					nome = "";
					preco = 0;

				}

				um.nome = nome;
				um.preco = preco;
				um.id = id;

				Todos.Add(um);

			}
			foreach (var oi in Todos)
				Console.WriteLine("Lista Todos -> {0}",oi.nome);
		}

		public int flag { get; set; }
		public int id {get; set;}
		public String nome {get; set;}
		public float preco {get; set;}
		public List<RegistroProdutos> Todos { get; set; }

	}
		
}

