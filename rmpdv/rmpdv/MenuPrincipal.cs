
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace rmpdv
{
	[Activity (Label = "MenuPrincipal", Theme="@style/MenuPrincipalTheme")]			
	public class MenuPrincipal : Activity
	{

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.MenuPrincipal);

			ActionBar.SetDisplayShowCustomEnabled (true);
			ActionBar.SetDisplayShowTitleEnabled (false);
			ActionBar.SetDisplayShowHomeEnabled (false);
			ActionBar.SetCustomView (Resource.Layout.BarraMenuPrincipal);

			ActionBar.CustomView.FindViewById (Resource.Id.lComanda).Click += (object sender, EventArgs e) => {
				StartActivity (typeof(ProdutosList));
				this.Finish ();			
			};
			ActionBar.CustomView.FindViewById (Resource.Id.lConsumoInterno).Click += (object sender, EventArgs e) => {
				StartActivity (typeof(ProdutosList));
				this.Finish ();			
			};
			ActionBar.CustomView.FindViewById (Resource.Id.lSenha).Click += (object sender, EventArgs e) => {
				StartActivity (typeof(MainActivity));
				this.Finish ();			
			};
			ActionBar.CustomView.FindViewById (Resource.Id.lSaida).Click += (object sender, EventArgs e) => {
				Android.OS.Process.KillProcess(Android.OS.Process.MyPid());	
			};

		}

	}

}

