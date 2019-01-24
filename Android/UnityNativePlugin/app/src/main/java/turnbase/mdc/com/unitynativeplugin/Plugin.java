package turnbase.mdc.com.unitynativeplugin;

import android.app.Activity;
import android.content.res.AssetManager;
import android.util.Log;

/**
 * Created by viettho on 8/10/17.
 */

public class Plugin {

    public static native void setAssetsNative(AssetManager assetManager);

    static {
        System.loadLibrary("NativeCore");
    }

    public static String SetAssetManagerForNative(Activity activity) {
        AssetManager assetManager = activity.getAssets();
        if(assetManager!=null){
            setAssetsNative(assetManager);
        }else {
            Log.e("NativeCore", "AssetManager null");
        }
        return "setAssetManager correct";
    }
}