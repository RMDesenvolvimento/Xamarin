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

namespace rmpdv
{
	class ProdutosViewAdapter : BaseAdapter<RegistroProdutos>
	{
		private List<RegistroProdutos> mvProdutos;
		private Context mContext;
		public ProdutosViewAdapter (Context context, List<RegistroProdutos> tprodutos)
		{
			mContext = context;
			mvProdutos = tprodutos;
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

			TextView txtId = linha.FindViewById<TextView> (Resource.Id.edtCodigo);
			TextView txtNome = linha.FindViewById<TextView> (Resource.Id.edtProduto);
			TextView txtPreco = linha.FindViewById<TextView> (Resource.Id.edtPreco);

			txtId.Text = (string) mvProdutos[position].id.ToString();
			txtNome.Text = (string) mvProdutos[position].nome;
			txtPreco.Text = String.Format("{0:C}", mvProdutos[position].preco);

			return linha;
		}

	}
}

