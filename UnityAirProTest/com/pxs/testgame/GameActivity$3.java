
package com.pxs.testgame;

class GameActivity$3 implements Runnable
{
	GameActivity$3(GameActivity this$0)
	{
		this.this$0 = this$0;
	}

	public void run()
	{
		this.this$0.callUnityFunc(this.this$0.stateCallBackName, "OnDeviceStateChanged", GameActivity.access$000(this.this$0).getDeviceState().toString());
	}
}
