package cn.gyyx.bumblebee.util;

import com.sun.tools.javac.util.Assert;

import java.util.UUID;

/**
 * @Author : east.Fu
 * @Description : 唯一ID 生成工具类
 * @Date : Created in  2017/6/27 17:22
 */
public class UniqueIdUtil {

    // 用于生成密钥的常量字符串
    private static final String KEY = "GYYX";

    /**
     * @Title: getOpenId
     * @Description: 获取openId,应用唯一
     * @return String 返回类型
     */
    public static String getUUID() {
        UUID uuid = UUID.randomUUID();
        String openId = uuid.toString().toUpperCase();
        return openId.replace("-", "");
    }

    /**
     * @Title: getUniqueKey
     * @Description: 通过应用的openId,生成应用的密钥
     *               <p>原则：（KEY+openId） md5加密字符串 </p>
     * @return String    返回类型
     */
    public static String getUniqueKey(int length) {
        Assert.check(length<=24,"length must less than 24");
        String plain= UniqueIdUtil.KEY + getUUID();
        String key = Md5Util.MD5(plain);
        return key.substring(0, length);
    }

}
