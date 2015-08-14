package md528b6b15eae6810011aefd3a4f96b497b;


public class DSNavigationBarView
	extends md528b6b15eae6810011aefd3a4f96b497b.DSToolbarView
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("DSoft.UI.Views.DSNavigationBarView, DSoft.UI.Android, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null", DSNavigationBarView.class, __md_methods);
	}


	public DSNavigationBarView (android.content.Context p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == DSNavigationBarView.class)
			mono.android.TypeManager.Activate ("DSoft.UI.Views.DSNavigationBarView, DSoft.UI.Android, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}


	public DSNavigationBarView (android.content.Context p0, android.util.AttributeSet p1) throws java.lang.Throwable
	{
		super (p0, p1);
		if (getClass () == DSNavigationBarView.class)
			mono.android.TypeManager.Activate ("DSoft.UI.Views.DSNavigationBarView, DSoft.UI.Android, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0, p1 });
	}


	public DSNavigationBarView (android.content.Context p0, android.util.AttributeSet p1, int p2) throws java.lang.Throwable
	{
		super (p0, p1, p2);
		if (getClass () == DSNavigationBarView.class)
			mono.android.TypeManager.Activate ("DSoft.UI.Views.DSNavigationBarView, DSoft.UI.Android, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1, p2 });
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
