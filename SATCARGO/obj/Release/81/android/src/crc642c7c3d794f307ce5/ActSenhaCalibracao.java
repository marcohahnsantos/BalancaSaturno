package crc642c7c3d794f307ce5;


public class ActSenhaCalibracao
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
		mono.android.Runtime.register ("SATCARGO.Activitys.ActSenhaCalibracao, SATCARGO", ActSenhaCalibracao.class, __md_methods);
	}


	public ActSenhaCalibracao ()
	{
		super ();
		if (getClass () == ActSenhaCalibracao.class)
			mono.android.TypeManager.Activate ("SATCARGO.Activitys.ActSenhaCalibracao, SATCARGO", "", this, new java.lang.Object[] {  });
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
