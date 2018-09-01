//
// Source code recreated from a .class file by IntelliJ IDEA
// (powered by Fernflower decompiler)
//

package com.pxs.testgame;

import android.widget.Toast;

class GameActivity$1 implements Runnable
{
	GameActivity$1(GameActivity this$0, String var2)
	{
		this.this$0 = this$0;
		this.val$mStr2Show = var2;
	}

	public void run()
	{
		Toast.makeText(this.this$0.getApplicationContext(), this.val$mStr2Show, 1).show();
	}
}
