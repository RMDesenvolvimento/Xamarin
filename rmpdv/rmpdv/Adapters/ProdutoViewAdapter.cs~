using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Graphics;

namespace rmpdv
{
	class ProdutosViewAdapter : BaseAdapter<RegistroProdutos>
	{
		private List<RegistroProdutos> mvProdutos;
		private Context mContext;

		private int mRowLayout;
		private int [] mAlternatingColors;

		public ProdutosViewAdapter (Context context, int rowLayout, List<RegistroProdutos> tprodutos)
		{
			mContext = context;
			mvProdutos = tprodutos;
			mRowLayout = rowLayout;
			mAlternatingColors = new int[] { 0xF2F2F2, 0x009900 };
		}

		public override int Count {
			get {return mvProdutos.Count;}
		}

		public override long GetItemId (int position)
		{
			return position;
		}

		public override RegistroProdutos this[int position] {
			get	{ return mvProdutos [position]; }
		}

		public override View GetView( int position, View convertView, ViewGroup parent) {

			View linha = convertView;

			if (linha == null) {
				linha = LayoutInflater.From (mContext).Inflate (Resource.Layout.ProdutosListItem, null, false);
			}

			linha.SetBackgroundColor(GetColorFromInteger(mAlternatingColors[position % mAlternatingColors.Length]));

			TextView txtId = linha.FindViewById<TextView> (Resource.Id.edtCodigo);
			TextView txtNome = linha.FindViewById<TextView> (Resource.Id.edtProduto);
			TextView txtPreco = linha.FindViewById<TextView> (Resource.Id.edtPreco);

			txtId.Text = (string) mvProdutos[position].id.ToString();
			txtNome.Text = (string) mvProdutos[position].nome;
			txtPreco.Text = String.Format("{0:C}", mvProdutos[position].preco);

			if ((position % 2) == 1)
			{
				txtId.SetTextColor(Color.White);
				txtNome.SetTextColor(Color.White);
				txtPreco.SetTextColor(Color.White);
			}

			else
			{
				txtId.SetTextColor(Color.Black);
				txtNome.SetTextColor(Color.Black);
				txtPreco.SetTextColor(Color.Black);
			}


			return linha;
		}
		private Color GetColorFromInteger(int color)
		{
			return Color.Rgb(Color.GetRedComponent(color), Color.GetGreenComponent(color), Color.GetBlueComponent(color));
		}

	}
}

