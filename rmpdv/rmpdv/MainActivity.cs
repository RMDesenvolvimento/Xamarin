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

using System.Linq;
using System.ComponentModel;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace rmpdv
{

	[Activity (Label = "(RM) Apollo", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		private Button btLogin;
		private Button btSair;
		private WebClient mClient;
		private Uri mUrl;
		private BackgroundWorker mWorker;
		private List<RegistroUsuario> lUsuario;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Main);

			AlertCenter.Default.Init (Application);
			AlertCenter.Default.TimeToClose = new TimeSpan (0, 0, 0, 3, 0);

			btLogin = FindViewById<Button> (Resource.Id.btnLogin);
			btSair = FindViewById<Button> (Resource.Id.btnSair);

			btLogin.Click += (sender, e) => {

				FragmentTransaction transacao = FragmentManager.BeginTransaction();

				LoginDialogo dialogo = new LoginDialogo();
				dialogo.Show(transacao,"dialog fragment");
				dialogo.eventoCompleto += Dialogo_eventoCompleto;
						
			};
				
			btSair.Click += (sender, e) => {
				Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
			};

		}

		void Dialogo_eventoCompleto (object sender, OnLoginDialogoEventArgs e)
		{

			string mUsuario = e.Usuario;
			string mSenha = e.Senha;

			mWorker = new BackgroundWorker();

			mUrl = new Uri("http://192.168.0.103/rest1/login.php?usuario="+mUsuario+"&senha="+mSenha);

			mClient = new WebClient();
			mClient.DownloadDataAsync(mUrl);
			mClient.DownloadDataCompleted += mClient_DownloadDataCompleted;

		}

		void mClient_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
		{

			RunOnUiThread(() =>
				{
					string json = Encoding.UTF8.GetString(e.Result);
					if ((json == "Usuario ou Senha nao encontrado") || (json == "Usuario ou Senha sem preenchimento"))
					{

						AlertDialog.Builder builder = new AlertDialog.Builder(this);
						builder.SetMessage(json);
						builder.SetCancelable(false);
						builder.SetPositiveButton("OK", delegate {builder.Dispose(); });
						builder.Show();
						return;

					} else {
						
						lUsuario = JsonConvert.DeserializeObject<List<RegistroUsuario>>(json);

						AlertCenter.Default.BackgroundColor = Color.White;
						AlertCenter.Default.PostMessage ("Seja Bem Vindo", lUsuario[0].nome,Resource.Drawable.Icon);

						StartActivity(typeof(MenuPrincipal));
						this.Finish();
					}
				});
		} 



	};
}


