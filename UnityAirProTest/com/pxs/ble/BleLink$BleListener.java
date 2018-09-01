//
// Source code recreated from a .class file by IntelliJ IDEA
// (powered by Fernflower decompiler)
//

package com.pxs.ble;

public interface BleLink$BleListener
{
	void OnDeviceStateChanged(BleLink var1, BleDeviceState var2);

	void OnDataReceived(BleLink var1, byte[] var2);
}
