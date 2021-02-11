package crc642c7c3d794f307ce5;


public class ActCadastroPesagem1_1
	extends android.support.v7.app.AppCompatActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("SATCARGO.Activitys.ActCadastroPesagem1_1, SATCARGO", ActCadastroPesagem1_1.class, __md_methods);
	}


	public ActCadastroPesagem1_1 ()
	{
		super ();
		if (getClass () == ActCadastroPesagem1_1.class)
			mono.android.TypeManager.Activate ("SATCARGO.Activitys.ActCadastroPesagem1_1, SATCARGO", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	private java.util.ArrayList refList;
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
