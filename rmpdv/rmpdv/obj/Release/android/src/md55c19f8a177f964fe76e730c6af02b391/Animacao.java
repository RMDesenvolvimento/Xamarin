package md55c19f8a177f964fe76e730c6af02b391;


public class Animacao
	extends android.view.animation.Animation
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_applyTransformation:(FLandroid/view/animation/Transformation;)V:GetApplyTransformation_FLandroid_view_animation_Transformation_Handler\n" +
			"n_willChangeBounds:()Z:GetWillChangeBoundsHandler\n" +
			"";
		mono.android.Runtime.register ("rmpdv.Animacao, rmpdv, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", Animacao.class, __md_methods);
	}


	public Animacao () throws java.lang.Throwable
	{
		super ();
		if (getClass () == Animacao.class)
			mono.android.TypeManager.Activate ("rmpdv.Animacao, rmpdv, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public Animacao (android.content.Context p0, android.util.AttributeSet p1) throws java.lang.Throwable
	{
		super (p0, p1);
		if (getClass () == Animacao.class)
			mono.android.TypeManager.Activate ("rmpdv.Animacao, rmpdv, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0, p1 });
	}

	public Animacao (android.view.View p0, int p1) throws java.lang.Throwable
	{
		super ();
		if (getClass () == Animacao.class)
			mono.android.TypeManager.Activate ("rmpdv.Animacao, rmpdv, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Views.View, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1 });
	}


	public void applyTransformation (float p0, android.view.animation.Transformation p1)
	{
		n_applyTransformation (p0, p1);
	}

	private native void n_applyTransformation (float p0, android.view.animation.Transformation p1);


	public boolean willChangeBounds ()
	{
		return n_willChangeBounds ();
	}

	private native boolean n_willChangeBounds ();

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
