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

	public class RegistoUsuario 

	{

		public int id { get; set; }
		public string nome { get; set; }
		public string usuario { get; set; }
		public string email { get; set; }

	}

	public class Usuarios 
	{

		public Usuarios (string json, string campo = "", string pesquisa = "") 
		{
			JObject jObject = JObject.Parse(json);
			Console.WriteLine("Objeto {0}",jObject);

			JToken jUser = jObject["data_usuario"];
			Console.WriteLine("Array {0}",jUser);

			RegistoUsuario um = new RegistoUsuario ();
			List<RegistoUsuario> todos = new List<RegistoUsuario>();

			string registro = "";
			foreach (var item in jUser) {
				registro = item.ToString();	

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

				todos.Add(um);

			}
			foreach (var oi in todos)
				Console.WriteLine("Todos -> {0}",oi.nome);
		}

		public int flag { get; set; }
		public int id { get; set; }
		public string nome { get; set; }
		public string usuario { get; set; }
		public string email { get; set; }

		// Verificar Amanha
		public List<RegistoUsuario> todos { get; set; }

	}

	[Activity (Label = "[PDV] Sistema de Comandas", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Main);
			EditText usuario = FindViewById<EditText>(Resource.Id.edtUsuario);
			EditText senha = FindViewById<EditText>(Resource.Id.edtSenha);
			Button login = FindViewById<Button>(Resource.Id.btnLogin);

			AlertCenter.Default.Init (Application);
			AlertCenter.Default.TimeToClose = new TimeSpan (0, 0, 0, 3, 0);

			login.Click += (sender, e) => {

				string url = "http://192.168.0.103/rest";

				var client = new RestClient(url);
				client.Authenticator = new SimpleAuthenticator("usuario", usuario.Text, "senha", senha.Text);

				var request = new RestRequest("login", RestSharp.Method.POST);
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
					AlertCenter.Default.PostMessage ("Erro login", mensagem,Resource.Drawable.Icon);

				} else {
					
					Usuarios user = new Usuarios(response.Content);

					Console.WriteLine("Nome : {0}" , user.nome);
					Console.WriteLine("Usuario: {0}" , user.usuario);
					Console.WriteLine("Email: {0}" , user.email);
// Verificar Amanha
//					foreach (var oi in user.todos)
//						Console.WriteLine("Todos -> {0}",oi.nome);
					AlertCenter.Default.BackgroundColor = Color.White;
					AlertCenter.Default.PostMessage ("Seja Bem Vindo", user.nome,Resource.Drawable.Icon);

					StartActivity(typeof(produtos));

				}

			};
		}
		 
	}
}


