using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Graphics;
using Android.Views.Animations;

using Xamarin.Controls;
using System.Json;
using System.IO;
using System.Collections.Generic;

using RestSharp;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Linq;

namespace rmpdv
{
	public class RegistroProdutos
	{
		public int id {get; set;}
		public String nome {get; set;}
		public float preco {get; set;}

	}

	public class Produtos 
	{

		public Produtos (string json, string campo = "", string pesquisa = "") 
		{
			JObject jObject = JObject.Parse(json);
			Console.WriteLine("Objeto {0}",jObject);

			JToken jProd = jObject["data_produto"];
			Console.WriteLine("Array {0}",jProd);

			RegistroProdutos um = new RegistroProdutos ();
			List<RegistroProdutos> todos = new List<RegistroProdutos>();

			string registro = "";
			foreach (var item in jProd) {
				registro = item.ToString();	

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

				todos.Add(um);

			}
			foreach (var oi in todos)
				Console.WriteLine("Todos -> {0}",oi.nome);
		}

		public int flag { get; set; }
		public int id {get; set;}
		public String nome {get; set;}
		public float preco {get; set;}
		public List<RegistroProdutos> todos { get; set; }

	}

	[Activity (Label = "produtos")]			
	public class produtos : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Create your application here
			SetContentView(Resource.Layout.produtos);


			Button voltar = FindViewById<Button>(Resource.Id.btnVoltar);
			Button pesquisa = FindViewById<Button>(Resource.Id.btnPesquisa);
			TextView edpesquisa = FindViewById<TextView>(Resource.Id.edtpesquisa);
			var grid = FindViewById<GridView>(Resource.Id.gridProduto);


			voltar.Click += (sender, e) => {
				StartActivity(typeof(MainActivity));
			};

			pesquisa.Click += (sender, e) => {
				string url = "http://192.168.0.103/rest";

				var client = new RestClient(url);
				var request = new RestRequest("produtos");    
				request.AddParameter("nome", pesquisa.Text);
				IRestResponse response = client.Execute(request);

				string conteudo = @response.Content; // raw content as string
				string resposta = response.StatusDescription;

				Console.WriteLine("Resposta {0} --- {1}",conteudo, resposta);

				if (resposta != "OK") {

					var leitura = Newtonsoft.Json.Linq.JObject.Parse (conteudo);
					string status = (String) leitura["status"];

					string mensagem = (String) leitura["msg"];
					//We need to initialize AlertCenter 
					Console.WriteLine("Resposta {0} --- {1}",mensagem, status);
					AlertCenter.Default.BackgroundColor = Color.Red;
					AlertCenter.Default.PostMessage ("Mensagem de Erro", mensagem,Resource.Drawable.Icon);

				} else {

					Produtos Prod = new Produtos(response.Content);

					Console.WriteLine("Nome : {0}" , Prod.nome);
					Console.WriteLine("Preco: {0}" , Prod.preco);
					Console.WriteLine("Id: {0}" , Prod.id);

					// verificar amanha
					// grid.Adapter = Prod.todos;

				}
			};

		}
	}
}

