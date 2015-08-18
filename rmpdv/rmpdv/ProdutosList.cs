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
using Android.Views.InputMethods;

namespace rmpdv
{

	[Activity (Label = "Listagem de Produtos")]			
	public class ProdutosList : Activity
	{
		private ListView lstProdutoView;
		private TextView edPesquisa;
		private TextView mCabecalhoProduto;
		private LinearLayout mContainer;
		ProdutosViewAdapter mProdutoAdapter;
		private bool mAnimacaoDown;
		private bool mAnicamcao;
		private Produtos prod;
		private List<RegistroProdutos> lProduto;
		private bool mOrdemConsulta;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Create your application here
			SetContentView(Resource.Layout.produtos);

			edPesquisa = FindViewById<TextView>(Resource.Id.edtpesquisa);
			lstProdutoView = FindViewById<ListView> (Resource.Id.ListaProduto);
			mContainer = FindViewById<LinearLayout>(Resource.Id.llContainer);

			mCabecalhoProduto = FindViewById<TextView> (Resource.Id.txxCabecalhoProduto);

			edPesquisa.Alpha = 0;

			mContainer.BringToFront ();

			mCabecalhoProduto.Click += MCabecalhoProduto_Click;
			edPesquisa.TextChanged += edPesquisa_TextChange;

			string url = "http://192.168.0.103/rest";

			var client = new RestClient(url);
			var request = new RestRequest("produtos", Method.GET);    
			request.AddParameter("nome", "COCA");

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

				prod = new Produtos(response.Content);
				lProduto = prod.Todos;
				//Console.WriteLine("Nome : {0}" , prod.nome);
				///Console.WriteLine("Preco: {0}" , prod.preco);
				//Console.WriteLine("Id: {0}" , prod.id);

				mProdutoAdapter = new ProdutosViewAdapter (this, Resource.Layout.ProdutosListItem, lProduto);
				lstProdutoView.Adapter = mProdutoAdapter;

			}

		}

		void MCabecalhoProduto_Click (object sender, EventArgs e)
		{
			if (!mOrdemConsulta) {
				List<RegistroProdutos> mPesquisaProdutos = (from pProduto in lProduto
					orderby pProduto.nome
					select pProduto).ToList<RegistroProdutos>();
				mProdutoAdapter = new ProdutosViewAdapter(this, Resource.Layout.ProdutosListItem, mPesquisaProdutos);
			} else {
				List<RegistroProdutos> mPesquisaProdutos = (from pProduto in lProduto
					orderby pProduto.nome descending
					select pProduto).ToList<RegistroProdutos>();				
				mProdutoAdapter = new ProdutosViewAdapter(this, Resource.Layout.ProdutosListItem, mPesquisaProdutos);
			}
			 
			lstProdutoView.Adapter = mProdutoAdapter;

			mOrdemConsulta = !mOrdemConsulta;

		}

		public void edPesquisa_TextChange(object sender, Android.Text.TextChangedEventArgs e)
		{
			List<RegistroProdutos> mPesquisaProdutos = (from pProduto in lProduto
				where pProduto.nome.Contains(edPesquisa.Text, StringComparison.OrdinalIgnoreCase)  
				select pProduto).ToList<RegistroProdutos>();

			mProdutoAdapter = new ProdutosViewAdapter(this, Resource.Layout.ProdutosListItem, mPesquisaProdutos);
			lstProdutoView.Adapter = mProdutoAdapter;

		}

		public override bool OnOptionsItemSelected(IMenuItem item)
		{
//			RegistroProdutos selectedFromList = new RegistroProdutos() ;
//			selectedFromList = mProdutoAdapter[ (item.ItemId) ];
//			AlertCenter.Default.BackgroundColor = Color.Red;
//			AlertCenter.Default.PostMessage ("Selecionado Produto", selectedFromList.nome,Resource.Drawable.Icon);
		
			switch (item.ItemId)
			{

			case Resource.Id.pesquisa:
				
				//Search icon has been clicked

				if (mAnicamcao)
				{
					return true;
				}

				if (!mAnimacaoDown)
				{
					edPesquisa.Visibility = ViewStates.Visible;

					//Listview is up
					Animacao anim = new Animacao(lstProdutoView, lstProdutoView.Height - edPesquisa.Height);
					anim.Duration = 500;
					lstProdutoView.StartAnimation(anim);
					anim.AnimationStart += anim_AnimationStartDown;
					anim.AnimationEnd += anim_AnimationEndDown;
					mContainer.Animate().TranslationYBy(edPesquisa.Height).SetDuration(500).Start();
				}

				else
				{
					//Listview is down
					Animacao anim = new Animacao(lstProdutoView, lstProdutoView.Height + edPesquisa.Height);
					anim.Duration = 500;
					lstProdutoView.StartAnimation(anim);
					anim.AnimationStart += anim_AnimationStartUp;
					anim.AnimationEnd += anim_AnimationEndUp;
					mContainer.Animate().TranslationYBy(-edPesquisa.Height).SetDuration(500).Start();
				}

				mAnimacaoDown = !mAnimacaoDown;
				return true;

			default:
				return base.OnOptionsItemSelected(item);
			}
				
		}

		void anim_AnimationEndUp(object sender, Android.Views.Animations.Animation.AnimationEndEventArgs e)
		{
			mAnicamcao = false;
			edPesquisa.ClearFocus();
			InputMethodManager inputManager = (InputMethodManager)this.GetSystemService(Context.InputMethodService);
			inputManager.HideSoftInputFromWindow(this.CurrentFocus.WindowToken, HideSoftInputFlags.NotAlways);
		}

		void anim_AnimationEndDown(object sender, Android.Views.Animations.Animation.AnimationEndEventArgs e)
		{
			mAnicamcao = false;
		}

		void anim_AnimationStartDown(object sender, Android.Views.Animations.Animation.AnimationStartEventArgs e)
		{
			mAnicamcao = true;
			edPesquisa.Animate().AlphaBy(1.0f).SetDuration(500).Start();
		}

		void anim_AnimationStartUp(object sender, Android.Views.Animations.Animation.AnimationStartEventArgs e)
		{
			mAnicamcao = true;
			edPesquisa.Animate().AlphaBy(-1.0f).SetDuration(300).Start();
		}

		public override bool OnCreateOptionsMenu(IMenu menu)
		{
			MenuInflater.Inflate(Resource.Menu.BarraAcao, menu);
			return base.OnCreateOptionsMenu(menu);
		}

	}
}

