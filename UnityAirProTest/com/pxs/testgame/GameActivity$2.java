package com.pxs.testgame;

import android.bluetooth.BluetoothDevice;
import android.bluetooth.BluetoothAdapter.LeScanCallback;
import org.json.JSONException;

class GameActivity$2 implements LeScanCallback
{
	GameActivity$2(GameActivity this$0)
	{
		this.this$0 = this$0;
	}

	public void onLeScan(BluetoothDevice device, int rssi, byte[] scanRecord)
	{
		if ("".equals(this.this$0.scanName) || this.this$0.scanName.equals(device.getName()))
		{
			try
			{
				this.this$0.jsonObject.put("Name", device.getName());
				this.this$0.jsonObject.put("Address", device.getAddress());
				this.this$0.jsonObject.put("Rssi", rssi);

				for (int i = 0; i < scanRecord.length; ++i)
				{
					if (this.this$0.jsonArray.length() > i)
					{
						this.this$0.jsonArray.put(i, this.this$0.byte2Int(scanRecord[i]));
					}
					else
					{
						this.this$0.jsonArray.put(this.this$0.byte2Int(scanRecord[i]));
					}
				}

				this.this$0.jsonObject.put("ScanRecord", this.this$0.jsonArray);
				this.this$0.callUnityFunc(this.this$0.objName, "OnLeScan", this.this$0.jsonObject.toString());
			} catch (JSONException var5)
			{
				var5.printStackTrace();
			}

		}
	}
}
