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

	[Activity (Label = "produtos")]			
	public class ProdutosList : Activity
	{
		private ListView lstProdutoView;
		private TextView edPesquisa;
		private Button pesquisa;
		private Button voltar;
		ProdutosViewAdapter mProdutoAdapter;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Create your application here
			SetContentView(Resource.Layout.produtos);

			voltar = FindViewById<Button>(Resource.Id.btnVoltar);
			pesquisa = FindViewById<Button>(Resource.Id.btnPesquisa);
			edPesquisa = FindViewById<TextView>(Resource.Id.edtpesquisa);
			lstProdutoView = FindViewById<ListView> (Resource.Id.ListaProduto);

			voltar.Click += (sender, e) => {
				StartActivity(typeof(MainActivity));
				this.Finish();
			};

			pesquisa.Click += (sender, e) => {

				string edtPesquisa1 = edPesquisa.Text.ToUpper();

				if (edtPesquisa1.Length < 3) {
					
					AlertCenter.Default.BackgroundColor = Color.Red;
					AlertCenter.Default.PostMessage ("Mensagem de Erro", "Pesquisa com no minimo 3 letras",Resource.Drawable.Icon);

				} else {
					
					string url = "http://192.168.0.103/rest";

					var client = new RestClient(url);
					var request = new RestRequest("produtos", Method.GET);    
					request.AddParameter("nome", edtPesquisa1);

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

						Produtos prod = new Produtos(response.Content);

						Console.WriteLine("Nome : {0}" , prod.nome);
						Console.WriteLine("Preco: {0}" , prod.preco);
						Console.WriteLine("Id: {0}" , prod.id);

						mProdutoAdapter = new ProdutosViewAdapter(this, prod.Todos);

						lstProdutoView.Adapter  = mProdutoAdapter;

					}
				}
			};

			lstProdutoView.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) =>
			{

				RegistroProdutos selectedFromList = new RegistroProdutos() ;
				selectedFromList = mProdutoAdapter[ (e.Position) ];

				AlertCenter.Default.BackgroundColor = Color.Red;
				AlertCenter.Default.PostMessage ("Selecionado Produto", selectedFromList.nome,Resource.Drawable.Icon);

			};
		}
	}
}

