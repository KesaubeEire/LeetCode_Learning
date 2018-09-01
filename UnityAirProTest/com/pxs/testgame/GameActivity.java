//
// Source code recreated from a .class file by IntelliJ IDEA
// (powered by Fernflower decompiler)
//

package com.pxs.testgame;

import android.bluetooth.BluetoothAdapter;
import android.bluetooth.BluetoothDevice;
import android.bluetooth.BluetoothManager;
import android.bluetooth.BluetoothAdapter.LeScanCallback;
import android.os.Bundle;
import android.os.Vibrator;
import android.util.Log;
import android.widget.Toast;
import com.pxs.ble.BleDeviceState;
import com.pxs.ble.BleLink;
import com.pxs.ble.BleLink.BleListener;
import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

public abstract class GameActivity extends PermissionRequireActivity implements BleListener
{
	private BluetoothAdapter mBluetoothAdapter;
	private BluetoothManager bluetoothManager;
	private BleLink bleLink;
	JSONObject jsonObject = new JSONObject();
	JSONArray jsonArray = new JSONArray();
	LeScanCallback scanCallback = new LeScanCallback()
	{
		public void onLeScan(BluetoothDevice device, int rssi, byte[] scanRecord)
		{
			if ("".equals(GameActivity.this.scanName) || GameActivity.this.scanName.equals(device.getName()))
			{
				try
				{
					GameActivity.this.jsonObject.put("Name", device.getName());
					GameActivity.this.jsonObject.put("Address", device.getAddress());
					GameActivity.this.jsonObject.put("Rssi", rssi);

					for (int i = 0; i < scanRecord.length; ++i)
					{
						if (GameActivity.this.jsonArray.length() > i)
						{
							GameActivity.this.jsonArray.put(i, GameActivity.this.byte2Int(scanRecord[i]));
						}
						else
						{
							GameActivity.this.jsonArray.put(GameActivity.this.byte2Int(scanRecord[i]));
						}
					}

					GameActivity.this.jsonObject.put("ScanRecord", GameActivity.this.jsonArray);
					GameActivity.this.callUnityFunc(GameActivity.this.objName, "OnLeScan", GameActivity.this.jsonObject.toString());
				} catch (JSONException var5)
				{
					var5.printStackTrace();
				}

			}
		}
	};

	String objName = "Object";
	String stateCallBackName = null;
	String receivedCallBackName = null;
	String scanName = "";

	public void SetScanCallback(String objName)
	{
		this.objName = objName;
	}

	public void SetDeviceStateCallBack(String objName)
	{
		this.stateCallBackName = objName;
	}

	public void SetDataReceivedCallBack(String objName)
	{
		this.receivedCallBackName = objName;
	}
	byte[] received = null;
	Runnable deviceStateRunnable = new Runnable()
	{
		public void run()
		{
			GameActivity.this.callUnityFunc(GameActivity.this.stateCallBackName, "OnDeviceStateChanged", GameActivity.this.bleLink.getDeviceState().toString());
		}
	};
	Runnable dataReceivedRunnable = new Runnable()
	{
		public void run()
		{
			GameActivity.this.callUnityFunc(GameActivity.this.receivedCallBackName, "OnDataReceived", GameActivity.this.byteArray2String(GameActivity.this.received));
		}
	};
	StringBuffer stringBuffer = new StringBuffer();

	public GameActivity()
	{
	}

	protected void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		this.initBle();
	}

	private void initBle()
	{
		this.bluetoothManager = (BluetoothManager) this.getSystemService("bluetooth");
		this.mBluetoothAdapter = this.bluetoothManager.getAdapter();
		if (this.mBluetoothAdapter == null)
		{
			this.finish();
		}
		else
		{
			this.mBluetoothAdapter.enable();
			this.bleLink = new BleLink(this);
			this.bleLink.addBleListener(this);
		}
	}

	public void ShowToast(final String mStr2Show)
	{
		this.runOnUiThread(new Runnable()
		{
			public void run()
			{
				Toast.makeText(GameActivity.this.getApplicationContext(), mStr2Show, 1).show();
			}
		});
	}

	public void SetVibrator(long[] pattern, int repeat)
	{
		Vibrator mVibrator = (Vibrator) this.getSystemService("vibrator");
		mVibrator.vibrate(pattern, repeat);
	}

	protected abstract void callUnityFunc(String var1, String var2, String var3);

	int byte2Int(byte num)
	{
		int result = num;
		if (num < 0)
		{
			result = 256 + num;
		}

		return result;
	}

	public boolean StartScan(String name, int timeout)
	{
		this.scanName = name;
		return this.mBluetoothAdapter.startLeScan(this.scanCallback);
	}

	public boolean StopScan()
	{
		this.mBluetoothAdapter.stopLeScan(this.scanCallback);
		return true;
	}

	public boolean LinkDevice(String addrss)
	{
		return this.bleLink.link(this.mBluetoothAdapter.getRemoteDevice(addrss));
	}

	public void DislinkDevice()
	{
		this.bleLink.dislink();
	}

	public int GetDeviceState()
	{
		return this.bleLink.getDeviceState().ordinal();
	}

	public boolean SendData(byte[] data)
	{
		return this.bleLink.sendData(data);
	}

	public byte[] ReceiveData()
	{
		byte[] temp = this.received;
		this.received = null;
		return temp;
	}

	public void OnDeviceStateChanged(BleLink bleLink, BleDeviceState state)
	{
		if (this.stateCallBackName != null)
		{
			this.deviceStateRunnable.run();
		}

		Log.d("DeviceState", state.toString());
	}

	public void OnDataReceived(BleLink bleLink, byte[] data)
	{
		this.received = data;
		if (this.receivedCallBackName != null)
		{
			this.dataReceivedRunnable.run();
		}

		Log.d("Received", "" + data[0]);
	}


	public String byteArray2String(byte[] data)
	{
		if (data == null)
		{
			return "";
		}
		else
		{
			this.stringBuffer.delete(0, this.stringBuffer.length());

			for (int i = 0; i < data.length; ++i)
			{
				this.stringBuffer.append(String.format("%02X", new Object[]{Integer.valueOf(this.byte2Int(data[i]))}));
			}

			return this.stringBuffer.toString();
		}
	}
}
