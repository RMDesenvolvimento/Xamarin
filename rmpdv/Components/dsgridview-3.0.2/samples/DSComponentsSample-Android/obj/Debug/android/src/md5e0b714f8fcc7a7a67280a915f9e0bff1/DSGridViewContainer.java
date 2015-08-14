package md5e0b714f8fcc7a7a67280a915f9e0bff1;


public class DSGridViewContainer
	extends md52a8be622d6813e8f6df55423fa1f6973.DSMultiDirectionScrollView
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onScrollChanged:(IIII)V:GetOnScrollChanged_IIIIHandler\n" +
			"";
		mono.android.Runtime.register ("DSoft.UI.Grid.Views.DSGridViewContainer, DSoft.UI.Android, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null", DSGridViewContainer.class, __md_methods);
	}


	public DSGridViewContainer (android.content.Context p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == DSGridViewContainer.class)
			mono.android.TypeManager.Activate ("DSoft.UI.Grid.Views.DSGridViewContainer, DSoft.UI.Android, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}


	public DSGridViewContainer (android.content.Context p0, android.util.AttributeSet p1) throws java.lang.Throwable
	{
		super (p0, p1);
		if (getClass () == DSGridViewContainer.class)
			mono.android.TypeManager.Activate ("DSoft.UI.Grid.Views.DSGridViewContainer, DSoft.UI.Android, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0, p1 });
	}


	public DSGridViewContainer (android.content.Context p0, android.util.AttributeSet p1, int p2) throws java.lang.Throwable
	{
		super (p0, p1, p2);
		if (getClass () == DSGridViewContainer.class)
			mono.android.TypeManager.Activate ("DSoft.UI.Grid.Views.DSGridViewContainer, DSoft.UI.Android, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public void onScrollChanged (int p0, int p1, int p2, int p3)
	{
		n_onScrollChanged (p0, p1, p2, p3);
	}

	private native void n_onScrollChanged (int p0, int p1, int p2, int p3);

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
