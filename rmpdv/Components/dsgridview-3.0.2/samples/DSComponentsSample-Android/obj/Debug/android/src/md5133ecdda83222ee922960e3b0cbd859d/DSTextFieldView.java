package md5133ecdda83222ee922960e3b0cbd859d;


public class DSTextFieldView
	extends android.view.View
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("DSComponentsSample.Views.DSTextFieldView, DScomponentsSample, Version=2.6.0.0, Culture=neutral, PublicKeyToken=null", DSTextFieldView.class, __md_methods);
	}


	public DSTextFieldView (android.content.Context p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == DSTextFieldView.class)
			mono.android.TypeManager.Activate ("DSComponentsSample.Views.DSTextFieldView, DScomponentsSample, Version=2.6.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}


	public DSTextFieldView (android.content.Context p0, android.util.AttributeSet p1) throws java.lang.Throwable
	{
		super (p0, p1);
		if (getClass () == DSTextFieldView.class)
			mono.android.TypeManager.Activate ("DSComponentsSample.Views.DSTextFieldView, DScomponentsSample, Version=2.6.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0, p1 });
	}


	public DSTextFieldView (android.content.Context p0, android.util.AttributeSet p1, int p2) throws java.lang.Throwable
	{
		super (p0, p1, p2);
		if (getClass () == DSTextFieldView.class)
			mono.android.TypeManager.Activate ("DSComponentsSample.Views.DSTextFieldView, DScomponentsSample, Version=2.6.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1, p2 });
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
