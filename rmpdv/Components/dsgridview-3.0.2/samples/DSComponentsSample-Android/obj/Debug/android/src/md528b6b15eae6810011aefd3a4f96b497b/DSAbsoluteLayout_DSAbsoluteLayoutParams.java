package md528b6b15eae6810011aefd3a4f96b497b;


public class DSAbsoluteLayout_DSAbsoluteLayoutParams
	extends android.view.ViewGroup.LayoutParams
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("DSoft.UI.Views.DSAbsoluteLayout/DSAbsoluteLayoutParams, DSoft.UI.Android, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null", DSAbsoluteLayout_DSAbsoluteLayoutParams.class, __md_methods);
	}


	public DSAbsoluteLayout_DSAbsoluteLayoutParams (android.content.Context p0, android.util.AttributeSet p1) throws java.lang.Throwable
	{
		super (p0, p1);
		if (getClass () == DSAbsoluteLayout_DSAbsoluteLayoutParams.class)
			mono.android.TypeManager.Activate ("DSoft.UI.Views.DSAbsoluteLayout/DSAbsoluteLayoutParams, DSoft.UI.Android, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0, p1 });
	}


	public DSAbsoluteLayout_DSAbsoluteLayoutParams (android.view.ViewGroup.LayoutParams p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == DSAbsoluteLayout_DSAbsoluteLayoutParams.class)
			mono.android.TypeManager.Activate ("DSoft.UI.Views.DSAbsoluteLayout/DSAbsoluteLayoutParams, DSoft.UI.Android, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Views.ViewGroup/LayoutParams, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}


	public DSAbsoluteLayout_DSAbsoluteLayoutParams (int p0, int p1) throws java.lang.Throwable
	{
		super (p0, p1);
		if (getClass () == DSAbsoluteLayout_DSAbsoluteLayoutParams.class)
			mono.android.TypeManager.Activate ("DSoft.UI.Views.DSAbsoluteLayout/DSAbsoluteLayoutParams, DSoft.UI.Android, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null", "System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1 });
	}

	java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
