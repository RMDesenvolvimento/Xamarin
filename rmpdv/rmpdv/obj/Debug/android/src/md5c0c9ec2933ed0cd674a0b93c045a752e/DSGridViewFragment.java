package md5c0c9ec2933ed0cd674a0b93c045a752e;


public class DSGridViewFragment
	extends android.app.Fragment
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("DSoft.UI.Grid.DSGridViewFragment, DSoft.UI.Android, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null", DSGridViewFragment.class, __md_methods);
	}


	public DSGridViewFragment () throws java.lang.Throwable
	{
		super ();
		if (getClass () == DSGridViewFragment.class)
			mono.android.TypeManager.Activate ("DSoft.UI.Grid.DSGridViewFragment, DSoft.UI.Android, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
