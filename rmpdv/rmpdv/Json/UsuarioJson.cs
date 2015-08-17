using System;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace rmpdv
{
	public class Usuarios 
	{

		public Usuarios (string json, string campo = "", string pesquisa = "") 
		{
			JObject jObject = JObject.Parse(json);
			Console.WriteLine("Objeto {0}",jObject);

			JToken jUser = jObject["data_usuario"];
			Console.WriteLine("Array {0}",jUser);

			RegistoUsuario um = new RegistoUsuario ();
			Todos = new List<RegistoUsuario>();

			foreach (var item in jUser) {
				string registro = item.ToString();	

				var leitura = Newtonsoft.Json.Linq.JObject.Parse (registro);

				if ((campo != "" && pesquisa != "") || (campo == "" && pesquisa == "")) {

					id = (int)leitura ["id"];
					nome = (string) leitura["nome"];
					usuario = (string) leitura["usuario"];
					email = (string) leitura["email"];

				} else {

					id = 0;
					nome = "";
					usuario = "";
					email = "";
				}

				um.nome = nome;
				um.usuario = usuario;
				um.email = email;
				um.id = id;

				Todos.Add(um);

			}
			foreach (var oi in Todos)
				Console.WriteLine("Todos -> {0}",oi.nome);
		}

		public int flag { get; set; }
		public int id { get; set; }
		public string nome { get; set; }
		public string usuario { get; set; }
		public string email { get; set; }

		// Verificar Amanha
		public List<RegistoUsuario> Todos { get; set; }

	}

}

