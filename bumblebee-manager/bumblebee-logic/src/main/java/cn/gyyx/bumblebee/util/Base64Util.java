package cn.gyyx.bumblebee.util;

import org.apache.commons.codec.binary.Base64;

/**
 * @Author : east.Fu
 * @Description : base64 加密解密工具类
 * @Date : Created in  2017/8/8 23:22
 */
public class Base64Util {
    // 加密
    public static String getBase64(String str) {
        byte[] b = null;
        String s = null;
        try {
            b = Base64.encodeBase64(str.getBytes(),false);
            return new String(b);
        } catch (Exception e) {
            return null;
        }
    }

    // 解密
    public static String getFromBase64(String s) {
        byte[] b = null;
        String result = null;
        if (s != null) {
            try {
                b=Base64.decodeBase64(s);
                result = new String(b, "utf-8");
            } catch (Exception e) {
                e.printStackTrace();
            }
        }
        return result;
    }
}