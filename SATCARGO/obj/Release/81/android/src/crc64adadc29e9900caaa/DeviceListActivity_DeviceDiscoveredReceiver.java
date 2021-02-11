package crc64adadc29e9900caaa;


public class DeviceListActivity_DeviceDiscoveredReceiver
	extends android.content.BroadcastReceiver
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onReceive:(Landroid/content/Context;Landroid/content/Intent;)V:GetOnReceive_Landroid_content_Context_Landroid_content_Intent_Handler\n" +
			"";
		mono.android.Runtime.register ("com.xamarin.samples.bluetooth.bluetoothchat.DeviceListActivity+DeviceDiscoveredReceiver, SATCARGO", DeviceListActivity_DeviceDiscoveredReceiver.class, __md_methods);
	}


	public DeviceListActivity_DeviceDiscoveredReceiver ()
	{
		super ();
		if (getClass () == DeviceListActivity_DeviceDiscoveredReceiver.class)
			mono.android.TypeManager.Activate ("com.xamarin.samples.bluetooth.bluetoothchat.DeviceListActivity+DeviceDiscoveredReceiver, SATCARGO", "", this, new java.lang.Object[] {  });
	}

	public DeviceListActivity_DeviceDiscoveredReceiver (android.app.Activity p0)
	{
		super ();
		if (getClass () == DeviceListActivity_DeviceDiscoveredReceiver.class)
			mono.android.TypeManager.Activate ("com.xamarin.samples.bluetooth.bluetoothchat.DeviceListActivity+DeviceDiscoveredReceiver, SATCARGO", "Android.App.Activity, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public void onReceive (android.content.Context p0, android.content.Intent p1)
	{
		n_onReceive (p0, p1);
	}

	private native void n_onReceive (android.content.Context p0, android.content.Intent p1);

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
