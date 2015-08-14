package md564fc4851e664b4cef7f336377553b5f4;


public class LayoutActivity
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("DSComponentsSample.LayoutActivity, DScomponentsSample, Version=2.6.0.0, Culture=neutral, PublicKeyToken=null", LayoutActivity.class, __md_methods);
	}


	public LayoutActivity () throws java.lang.Throwable
	{
		super ();
		if (getClass () == LayoutActivity.class)
			mono.android.TypeManager.Activate ("DSComponentsSample.LayoutActivity, DScomponentsSample, Version=2.6.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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
