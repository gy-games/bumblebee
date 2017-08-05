package cn.gyyx.bumblebee.util;

import com.alibaba.fastjson.JSON;

import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * @Author : east.Fu
 * @Description : 校验工具类
 * @Date : Created in  2017/6/27 17:15
 */
public class ValidateUtil {
    private static final String IPADDRESS_PATTERN = "^([01]?\\d\\d?|2[0-4]\\d|25[0-5])\\.([01]?\\d\\d?|2[0-4]\\d|25[0-5])\\."
            + "([01]?\\d\\d?|2[0-4]\\d|25[0-5])\\.([01]?\\d\\d?|2[0-4]\\d|25[0-5])$";

    /**
     * @Title: validateIpAddress
     * @Description: 验证一个字符串是否为ip地址
     * @param ipAddress
     * @return boolean 返回类型
     */
    public static boolean validateIpAddress(String ipAddress) {
        if(null==ipAddress){
            return false;
        }
        Pattern pattern = Pattern.compile(IPADDRESS_PATTERN);
        Matcher matcher = pattern.matcher(ipAddress);
        return matcher.matches();
    }

    /**
     * @Title: validateJson
     * @Description: 验证一个字符串是否为json格式（null值返回false）
     * @param json
     * @return boolean    返回类型
     */
    public static boolean validateJson(String json) {
        if(json==null){
            return false;
        }
        try {
            JSON.parse(json);
        } catch (Exception e) {
            return false;
        }
        return true;
    }

    /**
     * @Title: validateNumber
     * @Description: 验证一个字符串是否为数字
     * @param number
     * @return boolean    返回类型
     */
    public static boolean validateNumber(String number) {
        if(null==number){
            return false;
        }
        for (int i = 0; i < number.length(); i++) {
            if (!Character.isDigit(number.charAt(i))) {
                return false;
            }
        }
        return true;
    }
}
