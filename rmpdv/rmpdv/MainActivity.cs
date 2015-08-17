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

	[Activity (Label = "(RM) Apollo", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		private Button btLogin;
		private Button btSair;
		private ProgressBar pbLer;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Main);

			AlertCenter.Default.Init (Application);
			AlertCenter.Default.TimeToClose = new TimeSpan (0, 0, 0, 3, 0);

			btLogin = FindViewById<Button> (Resource.Id.btnLogin);
			btSair = FindViewById<Button> (Resource.Id.btnSair);
			pbLer = FindViewById<ProgressBar>(Resource.Id.progressoBar);
			pbLer.Visibility = ViewStates.Invisible;

			btLogin.Click += (sender, e) => {

				FragmentTransaction transacao = FragmentManager.BeginTransaction();

				LoginDialogo dialogo = new LoginDialogo();
				dialogo.Show(transacao,"dialog fragment");
				dialogo.eventoCompleto += Dialogo_eventoCompleto;

			 	// pbLer.visibility = "invisible";
						
			};
				
			btSair.Click += (sender, e) => {
				Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
			};

		}

		void Dialogo_eventoCompleto (object sender, OnLoginDialogoEventArgs e)
		{
			pbLer.Visibility = ViewStates.Visible;

			string mUsuario = e.Usuario;
			string mSenha = e.Senha;

			string url = "http://192.168.0.103/rest";

			var client = new RestClient(url);
			client.Authenticator = new SimpleAuthenticator("usuario", mUsuario, "senha", mSenha);

			var request = new RestRequest("login", RestSharp.Method.POST);
			IRestResponse response = client.Execute(request);

			string conteudo = @response.Content; // raw content as string
			string resposta = response.StatusDescription;

			Console.WriteLine("Resposta {0} --- {1}",conteudo, resposta);

			if (resposta != "OK") {

				var leitura = Newtonsoft.Json.Linq.JObject.Parse (conteudo);
				string status = (String) leitura["status"];

				string mensagem = (String) leitura["msg"];

				Console.WriteLine("Resposta {0} --- {1}",mensagem, status);
				AlertCenter.Default.BackgroundColor = Color.Red;
				AlertCenter.Default.PostMessage ("Erro login", mensagem,Resource.Drawable.Icon);

			} else {

				Usuarios user = new Usuarios(response.Content);

				Console.WriteLine("Nome : {0}" , user.nome);
				Console.WriteLine("Usuario: {0}" , user.usuario);
				Console.WriteLine("Email: {0}" , user.email);

				foreach (var oi in user.Todos)
					Console.WriteLine("Todos -> {0}",oi.nome);
				AlertCenter.Default.BackgroundColor = Color.White;
				AlertCenter.Default.PostMessage ("Seja Bem Vindo", user.nome,Resource.Drawable.Icon);

				// verificar como pode executar somente depois Da mensagem
				StartActivity(typeof(ProdutosList));
				this.Finish ();

			}

			pbLer.Visibility = ViewStates.Invisible;

		}

		 
	}
}


