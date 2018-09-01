package com.pxs.testgame;

class GameActivity$4 implements Runnable
{
	GameActivity$4(GameActivity this$0)
	{
		this.this$0 = this$0;
	}

	public void run()
	{
		this.this$0.callUnityFunc(this.this$0.receivedCallBackName, "OnDataReceived", this.this$0.byteArray2String(this.this$0.received));
	}
}
