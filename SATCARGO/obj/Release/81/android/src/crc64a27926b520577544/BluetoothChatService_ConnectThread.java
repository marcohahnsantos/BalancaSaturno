package crc64a27926b520577544;


public class BluetoothChatService_ConnectThread
	extends java.lang.Thread
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_run:()V:GetRunHandler\n" +
			"";
		mono.android.Runtime.register ("SATCARGO.BluetoothChatService+ConnectThread, SATCARGO", BluetoothChatService_ConnectThread.class, __md_methods);
	}


	public BluetoothChatService_ConnectThread ()
	{
		super ();
		if (getClass () == BluetoothChatService_ConnectThread.class)
			mono.android.TypeManager.Activate ("SATCARGO.BluetoothChatService+ConnectThread, SATCARGO", "", this, new java.lang.Object[] {  });
	}


	public void run ()
	{
		n_run ();
	}

	private native void n_run ();

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
