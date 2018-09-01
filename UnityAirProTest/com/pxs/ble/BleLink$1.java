package com.pxs.ble;

import android.bluetooth.BluetoothGatt;
import android.bluetooth.BluetoothGattCallback;
import android.bluetooth.BluetoothGattCharacteristic;
import android.bluetooth.BluetoothGattDescriptor;
import android.bluetooth.BluetoothGattService;

import java.util.UUID;

class BleLink$1 extends BluetoothGattCallback
{
	BleLink$1(BleLink this$0)
	{
		this.this$0 = this$0;
	}

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
					this.this$0.OnDeviceStateChanged(BleDeviceState.DEVICE_STATE_DISCOVERING);
				}
				else
				{
					BleLink.access$002(this.this$0, "发现服务失败！");
					this.this$0.OnDeviceStateChanged(BleDeviceState.DEVICE_STATE_LINKFAILED);
					this.this$0.OnDeviceStateChanged(BleDeviceState.DEVICE_STATE_DISLINK);
				}
			}

			if (newState == 0)
			{
				if (BleLink.access$100(this.this$0) == BleDeviceState.DEVICE_STATE_LINKING)
				{
					this.this$0.OnDeviceStateChanged(BleDeviceState.DEVICE_STATE_LINKFAILED);
					this.this$0.OnDeviceStateChanged(BleDeviceState.DEVICE_STATE_DISLINK);
				}

				if (BleLink.access$100(this.this$0) == BleDeviceState.DEVICE_STATE_DISCOVERING)
				{
					this.this$0.OnDeviceStateChanged(BleDeviceState.DEVICE_STATE_LINKFAILED);
					this.this$0.OnDeviceStateChanged(BleDeviceState.DEVICE_STATE_DISLINK);
				}

				if (BleLink.access$100(this.this$0) == BleDeviceState.DEVICE_STATE_LINKED)
				{
					this.this$0.OnDeviceStateChanged(BleDeviceState.DEVICE_STATE_LINKLOST);
					this.this$0.OnDeviceStateChanged(BleDeviceState.DEVICE_STATE_DISLINK);
				}
			}
		}
		else
		{
			BleLink.access$002(this.this$0, "status=" + String.format("0x%02X", new Object[]{Integer.valueOf(status)}));
			if (BleLink.access$100(this.this$0) == BleDeviceState.DEVICE_STATE_LINKED)
			{
				this.this$0.OnDeviceStateChanged(BleDeviceState.DEVICE_STATE_LINKLOST);
				this.this$0.OnDeviceStateChanged(BleDeviceState.DEVICE_STATE_DISLINK);
			}
			else
			{
				this.this$0.OnDeviceStateChanged(BleDeviceState.DEVICE_STATE_LINKFAILED);
				this.this$0.OnDeviceStateChanged(BleDeviceState.DEVICE_STATE_DISLINK);
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
				BleLink.access$002(this.this$0, "未发现TX服务");
				this.this$0.OnDeviceStateChanged(BleDeviceState.DEVICE_STATE_LINKFAILED);
				this.this$0.OnDeviceStateChanged(BleDeviceState.DEVICE_STATE_DISLINK);
				return;
			}

			this.this$0.OnDeviceStateChanged(BleDeviceState.DEVICE_STATE_CHARACTER);
			BleLink.access$202(this.this$0, bleServer.getCharacteristic(UUID.fromString(BleLink.TX_UUID)));
			if (BleLink.access$200(this.this$0) == null)
			{
				BleLink.access$002(this.this$0, "未发现TX特性：" + BleLink.TX_UUID);
				this.this$0.OnDeviceStateChanged(BleDeviceState.DEVICE_STATE_LINKFAILED);
				this.this$0.OnDeviceStateChanged(BleDeviceState.DEVICE_STATE_DISLINK);
				return;
			}

			if (!BleLink.access$300(this.this$0).setCharacteristicNotification(BleLink.access$200(this.this$0), true))
			{
				BleLink.access$002(this.this$0, "通知使能失败：mBluetoothGatt.setCharacteristicNotification(txChar, true)");
				this.this$0.OnDeviceStateChanged(BleDeviceState.DEVICE_STATE_LINKFAILED);
				this.this$0.OnDeviceStateChanged(BleDeviceState.DEVICE_STATE_DISLINK);
				return;
			}

			BluetoothGattDescriptor descriptor = BleLink.access$200(this.this$0).getDescriptor(UUID.fromString("00002902-0000-1000-8000-00805f9b34fb"));
			descriptor.setValue(BluetoothGattDescriptor.ENABLE_NOTIFICATION_VALUE);
			if (!BleLink.access$300(this.this$0).writeDescriptor(descriptor))
			{
				BleLink.access$002(this.this$0, "通知使能失败：mBluetoothGatt.writeDescriptor(descriptor)");
				this.this$0.OnDeviceStateChanged(BleDeviceState.DEVICE_STATE_LINKFAILED);
				this.this$0.OnDeviceStateChanged(BleDeviceState.DEVICE_STATE_DISLINK);
			}

			if (!BleLink.RX_SERVER_UUID.equals(BleLink.TX_SERVER_UUID))
			{
				bleServer = gatt.getService(UUID.fromString(BleLink.RX_SERVER_UUID));
			}

			if (bleServer == null)
			{
				BleLink.access$002(this.this$0, "未发现RX服务");
				this.this$0.OnDeviceStateChanged(BleDeviceState.DEVICE_STATE_LINKFAILED);
				this.this$0.OnDeviceStateChanged(BleDeviceState.DEVICE_STATE_DISLINK);
				return;
			}

			this.this$0.OnDeviceStateChanged(BleDeviceState.DEVICE_STATE_CHARACTER);
			BleLink.access$402(this.this$0, bleServer.getCharacteristic(UUID.fromString(BleLink.RX_UUID)));
			if (BleLink.access$400(this.this$0) == null)
			{
				BleLink.access$002(this.this$0, "未发现RX特性：" + BleLink.RX_UUID);
				this.this$0.OnDeviceStateChanged(BleDeviceState.DEVICE_STATE_LINKFAILED);
				this.this$0.OnDeviceStateChanged(BleDeviceState.DEVICE_STATE_DISLINK);
				return;
			}

			BleLink.access$400(this.this$0).setWriteType(1);
			this.this$0.OnDeviceStateChanged(BleDeviceState.DEVICE_STATE_LINKED);
		}
		else
		{
			BleLink.access$002(this.this$0, "发现服务操作失败");
			this.this$0.OnDeviceStateChanged(BleDeviceState.DEVICE_STATE_LINKFAILED);
			this.this$0.OnDeviceStateChanged(BleDeviceState.DEVICE_STATE_DISLINK);
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
		if (characteristic == BleLink.access$200(this.this$0))
		{
			byte[] data = characteristic.getValue();
			BleLink.access$502(this.this$0, data);
			if (data != null)
			{
				this.this$0.OnDataReceived(data);
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
		BleLink.access$602(this.this$0, rssi);
	}
}
