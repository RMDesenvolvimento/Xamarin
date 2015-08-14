package md528b6b15eae6810011aefd3a4f96b497b;


public class DSAbsoluteLayout
	extends android.view.ViewGroup
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onMeasure:(II)V:GetOnMeasure_IIHandler\n" +
			"n_generateDefaultLayoutParams:()Landroid/view/ViewGroup$LayoutParams;:GetGenerateDefaultLayoutParamsHandler\n" +
			"n_onLayout:(ZIIII)V:GetOnLayout_ZIIIIHandler\n" +
			"n_generateLayoutParams:(Landroid/util/AttributeSet;)Landroid/view/ViewGroup$LayoutParams;:GetGenerateLayoutParams_Landroid_util_AttributeSet_Handler\n" +
			"n_checkLayoutParams:(Landroid/view/ViewGroup$LayoutParams;)Z:GetCheckLayoutParams_Landroid_view_ViewGroup_LayoutParams_Handler\n" +
			"n_generateLayoutParams:(Landroid/view/ViewGroup$LayoutParams;)Landroid/view/ViewGroup$LayoutParams;:GetGenerateLayoutParams_Landroid_view_ViewGroup_LayoutParams_Handler\n" +
			"n_shouldDelayChildPressedState:()Z:GetShouldDelayChildPressedStateHandler\n" +
			"";
		mono.android.Runtime.register ("DSoft.UI.Views.DSAbsoluteLayout, DSoft.UI.Android, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null", DSAbsoluteLayout.class, __md_methods);
	}


	public DSAbsoluteLayout (android.content.Context p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == DSAbsoluteLayout.class)
			mono.android.TypeManager.Activate ("DSoft.UI.Views.DSAbsoluteLayout, DSoft.UI.Android, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}


	public DSAbsoluteLayout (android.content.Context p0, android.util.AttributeSet p1) throws java.lang.Throwable
	{
		super (p0, p1);
		if (getClass () == DSAbsoluteLayout.class)
			mono.android.TypeManager.Activate ("DSoft.UI.Views.DSAbsoluteLayout, DSoft.UI.Android, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0, p1 });
	}


	public DSAbsoluteLayout (android.content.Context p0, android.util.AttributeSet p1, int p2) throws java.lang.Throwable
	{
		super (p0, p1, p2);
		if (getClass () == DSAbsoluteLayout.class)
			mono.android.TypeManager.Activate ("DSoft.UI.Views.DSAbsoluteLayout, DSoft.UI.Android, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public void onMeasure (int p0, int p1)
	{
		n_onMeasure (p0, p1);
	}

	private native void n_onMeasure (int p0, int p1);


	public android.view.ViewGroup.LayoutParams generateDefaultLayoutParams ()
	{
		return n_generateDefaultLayoutParams ();
	}

	private native android.view.ViewGroup.LayoutParams n_generateDefaultLayoutParams ();


	public void onLayout (boolean p0, int p1, int p2, int p3, int p4)
	{
		n_onLayout (p0, p1, p2, p3, p4);
	}

	private native void n_onLayout (boolean p0, int p1, int p2, int p3, int p4);


	public android.view.ViewGroup.LayoutParams generateLayoutParams (android.util.AttributeSet p0)
	{
		return n_generateLayoutParams (p0);
	}

	private native android.view.ViewGroup.LayoutParams n_generateLayoutParams (android.util.AttributeSet p0);


	public boolean checkLayoutParams (android.view.ViewGroup.LayoutParams p0)
	{
		return n_checkLayoutParams (p0);
	}

	private native boolean n_checkLayoutParams (android.view.ViewGroup.LayoutParams p0);


	public android.view.ViewGroup.LayoutParams generateLayoutParams (android.view.ViewGroup.LayoutParams p0)
	{
		return n_generateLayoutParams (p0);
	}

	private native android.view.ViewGroup.LayoutParams n_generateLayoutParams (android.view.ViewGroup.LayoutParams p0);


	public boolean shouldDelayChildPressedState ()
	{
		return n_shouldDelayChildPressedState ();
	}

	private native boolean n_shouldDelayChildPressedState ();

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
