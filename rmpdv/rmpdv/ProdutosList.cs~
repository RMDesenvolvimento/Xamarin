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
using System.ComponentModel;
using System.Net;
using Newtonsoft.Json;
using System.Text;
using System.Collections.Specialized;
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
		private List<RegistroProdutos> lProduto;
		private bool mOrdemConsulta;
		private WebClient mClient;
		private Uri mUrl;
		private ProgressBar mProgressBar;
		private BackgroundWorker mWorker;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Create your application here
			SetContentView(Resource.Layout.produtos);

			edPesquisa = FindViewById<TextView>(Resource.Id.edtpesquisa);
			lstProdutoView = FindViewById<ListView> (Resource.Id.ListaProduto);
			mContainer = FindViewById<LinearLayout>(Resource.Id.llContainer);
			mProgressBar = FindViewById<ProgressBar>(Resource.Id.progressBar);
			mCabecalhoProduto = FindViewById<TextView> (Resource.Id.txxCabecalhoProduto);

			mWorker = new BackgroundWorker();

			edPesquisa.Alpha = 0;

			mContainer.BringToFront ();
			mProgressBar.BringToFront ();

			mProgressBar.Visibility = ViewStates.Visible;

			mUrl = new Uri("http://192.168.0.103/rest1/getprodutos.php?nome=VINHO");

			mClient = new WebClient();
			mClient.DownloadDataAsync(mUrl);
			mClient.DownloadDataCompleted += mClient_DownloadDataCompleted;

			mCabecalhoProduto.Click += MCabecalhoProduto_Click;
			edPesquisa.TextChanged += edPesquisa_TextChange;

		
		}

		void mClient_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
		{

			RunOnUiThread(() =>
				{
					string json = Encoding.UTF8.GetString(e.Result);
					if (json == "Sem Registro")
					{
						lProduto = new List<RegistroProdutos>();
						mProdutoAdapter = new ProdutosViewAdapter(this, Resource.Layout.ProdutosListItem, lProduto);
						lstProdutoView.Adapter = mProdutoAdapter;

						AlertDialog.Builder builder = new AlertDialog.Builder(this);
						builder.SetMessage("Seleção sem Registro");
						builder.SetCancelable(false);
						builder.SetPositiveButton("OK", delegate {builder.Dispose(); });
						builder.Show();
						return;

					} else {

						lProduto = JsonConvert.DeserializeObject<List<RegistroProdutos>>(json);
						mProdutoAdapter = new ProdutosViewAdapter(this, Resource.Layout.ProdutosListItem, lProduto);
						lstProdutoView.Adapter = mProdutoAdapter;
						mProgressBar.Visibility = ViewStates.Gone;
					}
				});
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

			switch (item.ItemId)
			{

			case Resource.Id.voltarproduto:

				StartActivity (typeof(MenuPrincipal));
				this.Finish ();	
				return true;
			
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

