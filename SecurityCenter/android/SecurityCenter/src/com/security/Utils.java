package com.security;

import android.content.Context;
import android.widget.Toast;

/**
 * Created with IntelliJ IDEA.
 * User: HUANGT5
 * Date: 8/20/13
 * Time: 7:55 PM
 * To change this template use File | Settings | File Templates.
 */
public class Utils {
    public static void ShowMessage(Context ctx, int resourceId){
        Toast.makeText(ctx, resourceId, Toast.LENGTH_SHORT).show();
    }
}
