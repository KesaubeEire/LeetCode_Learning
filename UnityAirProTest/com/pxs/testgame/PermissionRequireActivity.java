//
// Source code recreated from a .class file by IntelliJ IDEA
// (powered by Fernflower decompiler)
//

package com.pxs.testgame;

import android.content.Context;
import android.content.Intent;
import android.net.Uri;
import android.os.Handler;
import android.os.Build.VERSION;
import android.support.annotation.NonNull;
import android.support.v4.app.ActivityCompat;
import android.support.v4.content.ContextCompat;
import android.widget.Toast;
import com.unity3d.player.UnityPlayerActivity;

public abstract class PermissionRequireActivity extends UnityPlayerActivity
{
	protected Handler handler = new Handler();
	Runnable permissionRunnable = new Runnable()
	{
		public void run()
		{
			PermissionRequireActivity.this.checkPermission();
		}
	};

	public PermissionRequireActivity()
	{
	}

	protected void onResume()
	{
		super.onResume();
		if (VERSION.SDK_INT >= 21)
		{
			this.handler.postDelayed(this.permissionRunnable, 500L);
		}
		else
		{
			this.permissionInitOk();
		}

	}

	protected void onPause()
	{
		if (VERSION.SDK_INT >= 21)
		{
			this.handler.removeCallbacks(this.permissionRunnable);
		}

		super.onPause();
	}

	private void checkPermission()
	{
		if (ContextCompat.checkSelfPermission(this, "android.permission.READ_EXTERNAL_STORAGE") == 0 && ContextCompat.checkSelfPermission(this, "android.permission.WRITE_EXTERNAL_STORAGE") == 0 && ContextCompat.checkSelfPermission(this, "android.permission.ACCESS_COARSE_LOCATION") == 0 && ContextCompat.checkSelfPermission(this, "android.permission.ACCESS_FINE_LOCATION") == 0)
		{
			this.permissionInitOk();
		}
		else if (!ActivityCompat.shouldShowRequestPermissionRationale(this, "android.permission.READ_EXTERNAL_STORAGE") && !ActivityCompat.shouldShowRequestPermissionRationale(this, "android.permission.WRITE_EXTERNAL_STORAGE") && !ActivityCompat.shouldShowRequestPermissionRationale(this, "android.permission.ACCESS_COARSE_LOCATION") && !ActivityCompat.shouldShowRequestPermissionRationale(this, "android.permission.ACCESS_FINE_LOCATION"))
		{
			ActivityCompat.requestPermissions(this, new String[]{"android.permission.READ_EXTERNAL_STORAGE", "android.permission.WRITE_EXTERNAL_STORAGE", "android.permission.ACCESS_COARSE_LOCATION", "android.permission.ACCESS_FINE_LOCATION"}, 136);
		}
		else
		{
			Toast.makeText(this, "应用权限被拒绝，请打开权限。", 1).show();
			this.getAppDetailSettingIntent(this);
		}

	}

	public void onRequestPermissionsResult(int requestCode, @NonNull String[] permissions, @NonNull int[] grantResults)
	{
		for (int i = 0; i < grantResults.length; ++i)
		{
			if (grantResults[i] == -1)
			{
				Toast.makeText(this, "应用权限" + permissions[i] + "被拒绝，请打开权限。", 1).show();
				this.getAppDetailSettingIntent(this);
				break;
			}
		}
	}

	private void getAppDetailSettingIntent(Context context)
	{
		Intent localIntent = new Intent();
		localIntent.addFlags(268435456);
		if (VERSION.SDK_INT >= 9)
		{
			localIntent.setAction("android.settings.APPLICATION_DETAILS_SETTINGS");
			localIntent.setData(Uri.fromParts("package", this.getPackageName(), (String) null));
		}
		else if (VERSION.SDK_INT <= 8)
		{
			localIntent.setAction("android.intent.action.VIEW");
			localIntent.setClassName("com.android.settings", "com.android.settings.InstalledAppDetails");
			localIntent.putExtra("com.android.settings.ApplicationPkgName", this.getPackageName());
		}

		this.startActivity(localIntent);
	}

	protected abstract void permissionInitOk();
}
