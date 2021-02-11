package crc64a27926b520577544;


public class BluetoothChatFragment_ChatHandler
	extends android.os.Handler
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_handleMessage:(Landroid/os/Message;)V:GetHandleMessage_Landroid_os_Message_Handler\n" +
			"";
		mono.android.Runtime.register ("SATCARGO.BluetoothChatFragment+ChatHandler, SATCARGO", BluetoothChatFragment_ChatHandler.class, __md_methods);
	}


	public BluetoothChatFragment_ChatHandler ()
	{
		super ();
		if (getClass () == BluetoothChatFragment_ChatHandler.class)
			mono.android.TypeManager.Activate ("SATCARGO.BluetoothChatFragment+ChatHandler, SATCARGO", "", this, new java.lang.Object[] {  });
	}


	public BluetoothChatFragment_ChatHandler (android.os.Looper p0)
	{
		super (p0);
		if (getClass () == BluetoothChatFragment_ChatHandler.class)
			mono.android.TypeManager.Activate ("SATCARGO.BluetoothChatFragment+ChatHandler, SATCARGO", "Android.OS.Looper, Mono.Android", this, new java.lang.Object[] { p0 });
	}

	public BluetoothChatFragment_ChatHandler (crc64a27926b520577544.BluetoothChatFragment p0)
	{
		super ();
		if (getClass () == BluetoothChatFragment_ChatHandler.class)
			mono.android.TypeManager.Activate ("SATCARGO.BluetoothChatFragment+ChatHandler, SATCARGO", "SATCARGO.BluetoothChatFragment, SATCARGO", this, new java.lang.Object[] { p0 });
	}


	public void handleMessage (android.os.Message p0)
	{
		n_handleMessage (p0);
	}

	private native void n_handleMessage (android.os.Message p0);

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
