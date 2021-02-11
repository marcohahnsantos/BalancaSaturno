package crc64a27926b520577544;


public class BluetoothChatService_AcceptThread
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
		mono.android.Runtime.register ("SATCARGO.BluetoothChatService+AcceptThread, SATCARGO", BluetoothChatService_AcceptThread.class, __md_methods);
	}


	public BluetoothChatService_AcceptThread ()
	{
		super ();
		if (getClass () == BluetoothChatService_AcceptThread.class)
			mono.android.TypeManager.Activate ("SATCARGO.BluetoothChatService+AcceptThread, SATCARGO", "", this, new java.lang.Object[] {  });
	}


	public BluetoothChatService_AcceptThread (java.lang.Runnable p0)
	{
		super (p0);
		if (getClass () == BluetoothChatService_AcceptThread.class)
			mono.android.TypeManager.Activate ("SATCARGO.BluetoothChatService+AcceptThread, SATCARGO", "Java.Lang.IRunnable, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public BluetoothChatService_AcceptThread (java.lang.Runnable p0, java.lang.String p1)
	{
		super (p0, p1);
		if (getClass () == BluetoothChatService_AcceptThread.class)
			mono.android.TypeManager.Activate ("SATCARGO.BluetoothChatService+AcceptThread, SATCARGO", "Java.Lang.IRunnable, Mono.Android:System.String, mscorlib", this, new java.lang.Object[] { p0, p1 });
	}


	public BluetoothChatService_AcceptThread (java.lang.String p0)
	{
		super (p0);
		if (getClass () == BluetoothChatService_AcceptThread.class)
			mono.android.TypeManager.Activate ("SATCARGO.BluetoothChatService+AcceptThread, SATCARGO", "System.String, mscorlib", this, new java.lang.Object[] { p0 });
	}


	public BluetoothChatService_AcceptThread (java.lang.ThreadGroup p0, java.lang.Runnable p1)
	{
		super (p0, p1);
		if (getClass () == BluetoothChatService_AcceptThread.class)
			mono.android.TypeManager.Activate ("SATCARGO.BluetoothChatService+AcceptThread, SATCARGO", "Java.Lang.ThreadGroup, Mono.Android:Java.Lang.IRunnable, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public BluetoothChatService_AcceptThread (java.lang.ThreadGroup p0, java.lang.Runnable p1, java.lang.String p2)
	{
		super (p0, p1, p2);
		if (getClass () == BluetoothChatService_AcceptThread.class)
			mono.android.TypeManager.Activate ("SATCARGO.BluetoothChatService+AcceptThread, SATCARGO", "Java.Lang.ThreadGroup, Mono.Android:Java.Lang.IRunnable, Mono.Android:System.String, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public BluetoothChatService_AcceptThread (java.lang.ThreadGroup p0, java.lang.Runnable p1, java.lang.String p2, long p3)
	{
		super (p0, p1, p2, p3);
		if (getClass () == BluetoothChatService_AcceptThread.class)
			mono.android.TypeManager.Activate ("SATCARGO.BluetoothChatService+AcceptThread, SATCARGO", "Java.Lang.ThreadGroup, Mono.Android:Java.Lang.IRunnable, Mono.Android:System.String, mscorlib:System.Int64, mscorlib", this, new java.lang.Object[] { p0, p1, p2, p3 });
	}


	public BluetoothChatService_AcceptThread (java.lang.ThreadGroup p0, java.lang.String p1)
	{
		super (p0, p1);
		if (getClass () == BluetoothChatService_AcceptThread.class)
			mono.android.TypeManager.Activate ("SATCARGO.BluetoothChatService+AcceptThread, SATCARGO", "Java.Lang.ThreadGroup, Mono.Android:System.String, mscorlib", this, new java.lang.Object[] { p0, p1 });
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
