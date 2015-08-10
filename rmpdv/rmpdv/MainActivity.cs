using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using System.Json;
using System.Net;
using System.IO;
using System.Threading.Tasks;

namespace rmpdv
{
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

			// When the user clicks the button, send the REST request to geonames.org,
			login.Click += async (sender, e) => {

				string url = "http://192.168.0.103/rest/login?usuario=" +
					usuario.Text +
					"&senha=" +
					senha.Text;
				//string url = "http://192.168.0.103/rest/users/";

				JsonValue json = await LoginAsync (url);
				// LoginVerificacao (json);
			};
		}
		 
		private async Task<JsonValue> LoginAsync (string url)
		{

			string responseString = string.Empty;
			HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create (new Uri (url));
			request.ContentType = "application/json";
			request.Method = "GET";

			using (WebResponse response = await request.GetResponseAsync ())
			{

					using (Stream stream = response.GetResponseStream ())
					{
						JsonValue jsonDoc = await Task.Run (() => JsonObject.Load (stream));
						Console.Out.WriteLine("Response: {0}", jsonDoc.ToString ());

						// Return the JSON document:
						return jsonDoc;
					}
			}
		}

		private void LoginVerificacao (JsonValue json)
		{
			var resposta = System.Json.JsonObject.Parse (json);

			Boolean ok = true;
			string erro = (string) resposta ["status"];
			if (erro == "error") {
				ok = false;
			}
				
			Console.Out.WriteLine("Status: {0}", ok);
		}
	}
}


