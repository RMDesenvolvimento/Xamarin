package md55c19f8a177f964fe76e730c6af02b391;


public class MenuPrincipal
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("rmpdv.MenuPrincipal, rmpdv, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MenuPrincipal.class, __md_methods);
	}


	public MenuPrincipal () throws java.lang.Throwable
	{
		super ();
		if (getClass () == MenuPrincipal.class)
			mono.android.TypeManager.Activate ("rmpdv.MenuPrincipal, rmpdv, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
