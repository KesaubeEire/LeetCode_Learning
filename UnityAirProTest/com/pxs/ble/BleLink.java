//
// Source code recreated from a .class file by IntelliJ IDEA
// (powered by Fernflower decompiler)
//

package com.pxs.ble;

import android.bluetooth.BluetoothDevice;
import android.bluetooth.BluetoothGatt;
import android.bluetooth.BluetoothGattCallback;
import android.bluetooth.BluetoothGattCharacteristic;
import android.bluetooth.BluetoothGattDescriptor;
import android.bluetooth.BluetoothGattService;
import android.content.Context;

import java.util.ArrayList;
import java.util.Iterator;
import java.util.UUID;

public class BleLink
{
	public static String RX_SERVER_UUID = "6e400001-b5a3-f393-e0a9-e50e24dcca9e";
	public static String TX_SERVER_UUID = "6e400001-b5a3-f393-e0a9-e50e24dcca9e";
	public static String RX_UUID = "6e400002-b5a3-f393-e0a9-e50e24dcca9e";
	public static String TX_UUID = "6e400003-b5a3-f393-e0a9-e50e24dcca9e";
	public static final String DESC_UUID = "00002902-0000-1000-8000-00805f9b34fb";
	public int id = 0;
	private BluetoothGatt mBluetoothGatt;
	private BluetoothGattCharacteristic txChar;
	private BluetoothGattCharacteristic rxChar;
	private String address = "";
	private String name = "";
	private byte[] recivedData;
	private int rssi;
	private BluetoothGattCallback bleCallBack = new BluetoothGattCallback()
	{
		public void onConnectionStateChange(BluetoothGatt gatt, int status, int newState)
		{
			if (status == 0)
			{
				if (newState == 1)
				{
					;
				}

				if (newState == 2)
				{
					if (gatt.discoverServices())
					{
						BleLink.this.OnDeviceStateChanged(BleDeviceState.DEVICE_STATE_DISCOVERING);
					}
					else
					{
						BleLink.this.errorMsg = "发现服务失败！";
						BleLink.this.OnDeviceStateChanged(BleDeviceState.DEVICE_STATE_LINKFAILED);
						BleLink.this.OnDeviceStateChanged(BleDeviceState.DEVICE_STATE_DISLINK);
					}
				}

				if (newState == 0)
				{
					if (BleLink.this.deviceState == BleDeviceState.DEVICE_STATE_LINKING)
					{
						BleLink.this.OnDeviceStateChanged(BleDeviceState.DEVICE_STATE_LINKFAILED);
						BleLink.this.OnDeviceStateChanged(BleDeviceState.DEVICE_STATE_DISLINK);
					}

					if (BleLink.this.deviceState == BleDeviceState.DEVICE_STATE_DISCOVERING)
					{
						BleLink.this.OnDeviceStateChanged(BleDeviceState.DEVICE_STATE_LINKFAILED);
						BleLink.this.OnDeviceStateChanged(BleDeviceState.DEVICE_STATE_DISLINK);
					}

					if (BleLink.this.deviceState == BleDeviceState.DEVICE_STATE_LINKED)
					{
						BleLink.this.OnDeviceStateChanged(BleDeviceState.DEVICE_STATE_LINKLOST);
						BleLink.this.OnDeviceStateChanged(BleDeviceState.DEVICE_STATE_DISLINK);
					}
				}
			}
			else
			{
				BleLink.this.errorMsg = "status=" + String.format("0x%02X", new Object[]{Integer.valueOf(status)});
				if (BleLink.this.deviceState == BleDeviceState.DEVICE_STATE_LINKED)
				{
					BleLink.this.OnDeviceStateChanged(BleDeviceState.DEVICE_STATE_LINKLOST);
					BleLink.this.OnDeviceStateChanged(BleDeviceState.DEVICE_STATE_DISLINK);
				}
				else
				{
					BleLink.this.OnDeviceStateChanged(BleDeviceState.DEVICE_STATE_LINKFAILED);
					BleLink.this.OnDeviceStateChanged(BleDeviceState.DEVICE_STATE_DISLINK);
				}
			}

		}

		public void onServicesDiscovered(BluetoothGatt gatt, int status)
		{
			if (status == 0)
			{
				BluetoothGattService bleServer = gatt.getService(UUID.fromString(BleLink.TX_SERVER_UUID));
				if (bleServer == null)
				{
					BleLink.this.errorMsg = "未发现TX服务";
					BleLink.this.OnDeviceStateChanged(BleDeviceState.DEVICE_STATE_LINKFAILED);
					BleLink.this.OnDeviceStateChanged(BleDeviceState.DEVICE_STATE_DISLINK);
					return;
				}

				BleLink.this.OnDeviceStateChanged(BleDeviceState.DEVICE_STATE_CHARACTER);
				BleLink.this.txChar = bleServer.getCharacteristic(UUID.fromString(BleLink.TX_UUID));
				if (BleLink.this.txChar == null)
				{
					BleLink.this.errorMsg = "未发现TX特性：" + BleLink.TX_UUID;
					BleLink.this.OnDeviceStateChanged(BleDeviceState.DEVICE_STATE_LINKFAILED);
					BleLink.this.OnDeviceStateChanged(BleDeviceState.DEVICE_STATE_DISLINK);
					return;
				}

				if (!BleLink.this.mBluetoothGatt.setCharacteristicNotification(BleLink.this.txChar, true))
				{
					BleLink.this.errorMsg = "通知使能失败：mBluetoothGatt.setCharacteristicNotification(txChar, true)";
					BleLink.this.OnDeviceStateChanged(BleDeviceState.DEVICE_STATE_LINKFAILED);
					BleLink.this.OnDeviceStateChanged(BleDeviceState.DEVICE_STATE_DISLINK);
					return;
				}

				BluetoothGattDescriptor descriptor = BleLink.this.txChar.getDescriptor(UUID.fromString("00002902-0000-1000-8000-00805f9b34fb"));
				descriptor.setValue(BluetoothGattDescriptor.ENABLE_NOTIFICATION_VALUE);
				if (!BleLink.this.mBluetoothGatt.writeDescriptor(descriptor))
				{
					BleLink.this.errorMsg = "通知使能失败：mBluetoothGatt.writeDescriptor(descriptor)";
					BleLink.this.OnDeviceStateChanged(BleDeviceState.DEVICE_STATE_LINKFAILED);
					BleLink.this.OnDeviceStateChanged(BleDeviceState.DEVICE_STATE_DISLINK);
				}

				if (!BleLink.RX_SERVER_UUID.equals(BleLink.TX_SERVER_UUID))
				{
					bleServer = gatt.getService(UUID.fromString(BleLink.RX_SERVER_UUID));
				}

				if (bleServer == null)
				{
					BleLink.this.errorMsg = "未发现RX服务";
					BleLink.this.OnDeviceStateChanged(BleDeviceState.DEVICE_STATE_LINKFAILED);
					BleLink.this.OnDeviceStateChanged(BleDeviceState.DEVICE_STATE_DISLINK);
					return;
				}

				BleLink.this.OnDeviceStateChanged(BleDeviceState.DEVICE_STATE_CHARACTER);
				BleLink.this.rxChar = bleServer.getCharacteristic(UUID.fromString(BleLink.RX_UUID));
				if (BleLink.this.rxChar == null)
				{
					BleLink.this.errorMsg = "未发现RX特性：" + BleLink.RX_UUID;
					BleLink.this.OnDeviceStateChanged(BleDeviceState.DEVICE_STATE_LINKFAILED);
					BleLink.this.OnDeviceStateChanged(BleDeviceState.DEVICE_STATE_DISLINK);
					return;
				}

				BleLink.this.rxChar.setWriteType(1);
				BleLink.this.OnDeviceStateChanged(BleDeviceState.DEVICE_STATE_LINKED);
			}
			else
			{
				BleLink.this.errorMsg = "发现服务操作失败";
				BleLink.this.OnDeviceStateChanged(BleDeviceState.DEVICE_STATE_LINKFAILED);
				BleLink.this.OnDeviceStateChanged(BleDeviceState.DEVICE_STATE_DISLINK);
			}

		}

		public void onCharacteristicRead(BluetoothGatt gatt, BluetoothGattCharacteristic characteristic, int status)
		{
			super.onCharacteristicRead(gatt, characteristic, status);
		}

		public void onCharacteristicWrite(BluetoothGatt gatt, BluetoothGattCharacteristic characteristic, int status)
		{
			super.onCharacteristicWrite(gatt, characteristic, status);
		}

		public void onCharacteristicChanged(BluetoothGatt gatt, BluetoothGattCharacteristic characteristic)
		{
			if (characteristic == BleLink.this.txChar)
			{
				byte[] data = characteristic.getValue();
				BleLink.this.recivedData = data;
				if (data != null)
				{
					BleLink.this.OnDataReceived(data);
				}
			}

		}

		public void onDescriptorRead(BluetoothGatt gatt, BluetoothGattDescriptor descriptor, int status)
		{
			super.onDescriptorRead(gatt, descriptor, status);
		}

		public void onDescriptorWrite(BluetoothGatt gatt, BluetoothGattDescriptor descriptor, int status)
		{
			super.onDescriptorWrite(gatt, descriptor, status);
		}

		public void onReliableWriteCompleted(BluetoothGatt gatt, int status)
		{
			super.onReliableWriteCompleted(gatt, status);
		}

		public void onReadRemoteRssi(BluetoothGatt gatt, int rssi, int status)
		{
			super.onReadRemoteRssi(gatt, rssi, status);
			BleLink.this.rssi = rssi;
		}
	};
	private String errorMsg = "";
	private ArrayList<BleLink.BleListener> bleListener = new ArrayList();
	private Context context;
	private BleDeviceState deviceState;

	public String getErrorMsg()
	{
		return this.errorMsg;
	}

	public void addBleListener(BleLink.BleListener bleListener)
	{
		if (this.bleListener.indexOf(bleListener) == -1)
		{
			this.bleListener.add(bleListener);
		}

	}

	public void removeBleListener(BleLink.BleListener bleListener)
	{
		this.bleListener.remove(bleListener);
	}

	public void removeBleListener()
	{
		this.bleListener.clear();
	}

	public void clearBleListener()
	{
		this.bleListener.clear();
	}

	public String getAddress()
	{
		return this.address;
	}

	public String getName()
	{
		return this.name;
	}

	public BleLink(Context context)
	{
		this.deviceState = BleDeviceState.DEVICE_STATE_DISLINK;
		this.context = context;
	}

	public synchronized boolean link(BluetoothDevice device)
	{
		this.errorMsg = "";
		this.address = device.getAddress();
		this.name = device.getName();
		this.mBluetoothGatt = device.connectGatt(this.context, false, this.bleCallBack);
		if (this.mBluetoothGatt != null)
		{
			this.OnDeviceStateChanged(BleDeviceState.DEVICE_STATE_LINKING);
			return true;
		}
		else
		{
			this.OnDeviceStateChanged(BleDeviceState.DEVICE_STATE_LINKFAILED);
			this.OnDeviceStateChanged(BleDeviceState.DEVICE_STATE_DISLINK);
			return false;
		}
	}

	public synchronized void dislink()
	{
		if (this.deviceState != BleDeviceState.DEVICE_STATE_DISLINK)
		{
			if (this.mBluetoothGatt != null)
			{
				this.mBluetoothGatt.disconnect();
				if (this.mBluetoothGatt != null)
				{
					this.mBluetoothGatt.close();
				}

				this.mBluetoothGatt = null;
			}

			this.OnDeviceStateChanged(BleDeviceState.DEVICE_STATE_DISLINK);
		}

	}

	public synchronized boolean sendData(byte... data)
	{
		if (this.deviceState == BleDeviceState.DEVICE_STATE_LINKED)
		{
			this.rxChar.setValue(data);
			return this.mBluetoothGatt.writeCharacteristic(this.rxChar);
		}
		else
		{
			return false;
		}
	}

	public synchronized byte[] readData()
	{
		byte[] result = this.recivedData;
		this.recivedData = null;
		return result;
	}

	public int getRssi()
	{
		this.rssi = 0;
		if (this.deviceState == BleDeviceState.DEVICE_STATE_LINKED && this.mBluetoothGatt.readRemoteRssi())
		{
			for (int i = 0; i < 500 && this.rssi == 0; ++i)
			{
				try
				{
					Thread.sleep(1L);
				} catch (InterruptedException var3)
				{
					break;
				}
			}
		}

		return this.rssi;
	}

	void OnDeviceStateChanged(BleDeviceState state)
	{
		if (this.deviceState != state)
		{
			this.deviceState = state;
			if (state == BleDeviceState.DEVICE_STATE_DISLINK && this.mBluetoothGatt != null)
			{
				this.mBluetoothGatt.close();
				this.mBluetoothGatt = null;
			}

			Iterator var2 = this.bleListener.iterator();

			while (var2.hasNext())
			{
				BleLink.BleListener listener = (BleLink.BleListener) var2.next();
				listener.OnDeviceStateChanged(this, state);
			}
		}

	}

	void OnDataReceived(byte[] data)
	{
		Iterator var2 = this.bleListener.iterator();

		while (var2.hasNext())
		{
			BleLink.BleListener listener = (BleLink.BleListener) var2.next();
			listener.OnDataReceived(this, data);
		}

	}

	public BleDeviceState getDeviceState()
	{
		return this.deviceState;
	}

	public interface BleListener
	{
		void OnDeviceStateChanged(BleLink var1, BleDeviceState var2);

		void OnDataReceived(BleLink var1, byte[] var2);
	}
}
