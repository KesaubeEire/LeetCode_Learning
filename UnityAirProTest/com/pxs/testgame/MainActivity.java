//
// Source code recreated from a .class file by IntelliJ IDEA
// (powered by Fernflower decompiler)
//

package com.pxs.testgame;

import android.os.Bundle;
import com.unity3d.player.UnityPlayer;

public class MainActivity extends GameActivity
{
	public MainActivity()
	{
	}

	protected void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
	}

	protected void callUnityFunc(String objName, String funcStr, String content)
	{
		UnityPlayer.UnitySendMessage(objName, funcStr, content);
	}

	protected void permissionInitOk()
	{
	}
}
