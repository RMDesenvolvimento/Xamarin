using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using RestSharp;
using Xamarin.Controls;
using Android.Graphics;

namespace rmpdv
{
	public class OnLoginDialogoEventArgs : EventArgs
	{
		private string mUsuario;
		private string mSenha;

		public string Usuario 
		{
			get { return mUsuario; }
			set { mUsuario = value; }
		}
		public string Senha 
		{
			get { return mSenha; }
			set { mSenha = value; }
		}

		public OnLoginDialogoEventArgs( string usuario, string senha ) : base()
		{
			Usuario = usuario;
			Senha = senha;
		}

	}

	class LoginDialogo: DialogFragment
	{
		private Button btEntrar;
		private EditText usuario;
		private EditText senha;

		public event EventHandler<OnLoginDialogoEventArgs> eventoCompleto;

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			base.OnCreateView (inflater, container, savedInstanceState);
			var view = inflater.Inflate(Resource.Layout.DialogoLogin, container, false);

			btEntrar = view.FindViewById<Button> (Resource.Id.btnEntar);
			usuario = view.FindViewById<EditText>(Resource.Id.edtUsuario);
			senha = view.FindViewById<EditText>(Resource.Id.edtSenha);

			btEntrar.Click += btEntrar_Click;

			return view;
		}

		void btEntrar_Click(object sender, EventArgs e) 
		{

			eventoCompleto(this, new OnLoginDialogoEventArgs( usuario.Text, senha.Text ));
			this.Dismiss();

		}

		public override void OnActivityCreated (Bundle savedInstanceState)
		{
			Dialog.Window.RequestFeature (WindowFeatures.NoTitle);
			base.OnActivityCreated (savedInstanceState);

			Dialog.Window.Attributes.WindowAnimations = Resource.Style.AnimacaoDialogo;
		}
	}
}

