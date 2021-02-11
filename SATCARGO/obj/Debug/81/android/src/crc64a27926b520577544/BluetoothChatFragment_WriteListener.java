package crc64a27926b520577544;


public class BluetoothChatFragment_WriteListener
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.widget.TextView.OnEditorActionListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onEditorAction:(Landroid/widget/TextView;ILandroid/view/KeyEvent;)Z:GetOnEditorAction_Landroid_widget_TextView_ILandroid_view_KeyEvent_Handler:Android.Widget.TextView/IOnEditorActionListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("SATCARGO.BluetoothChatFragment+WriteListener, SATCARGO", BluetoothChatFragment_WriteListener.class, __md_methods);
	}


	public BluetoothChatFragment_WriteListener ()
	{
		super ();
		if (getClass () == BluetoothChatFragment_WriteListener.class)
			mono.android.TypeManager.Activate ("SATCARGO.BluetoothChatFragment+WriteListener, SATCARGO", "", this, new java.lang.Object[] {  });
	}

	public BluetoothChatFragment_WriteListener (crc64a27926b520577544.BluetoothChatFragment p0)
	{
		super ();
		if (getClass () == BluetoothChatFragment_WriteListener.class)
			mono.android.TypeManager.Activate ("SATCARGO.BluetoothChatFragment+WriteListener, SATCARGO", "SATCARGO.BluetoothChatFragment, SATCARGO", this, new java.lang.Object[] { p0 });
	}


	public boolean onEditorAction (android.widget.TextView p0, int p1, android.view.KeyEvent p2)
	{
		return n_onEditorAction (p0, p1, p2);
	}

	private native boolean n_onEditorAction (android.widget.TextView p0, int p1, android.view.KeyEvent p2);

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
