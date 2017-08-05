package cn.gyyx.bumblebee.util;

import org.apache.commons.codec.binary.Base64;

import javax.crypto.Cipher;
import javax.crypto.KeyGenerator;
import javax.crypto.SecretKey;
import javax.crypto.spec.SecretKeySpec;
import java.security.NoSuchAlgorithmException;

/**
 * @Author : east.Fu
 * @Description :
 * @Date : Created in  2017/6/27 17:23
 */
public class AesUtil {
    private static final String AESTYPE = "AES";//加密方式
    /*
     * 密钥的长度:
     * DES算法，则密钥长度必须是56位；
     * DESede，则可以是112或168位，其中112位有效；
     * AES，可以是128, 192或256位；
     * Blowfish，则可以是32至448之间可以被8整除的数；
     * HmacMD5和HmacSHA1默认的密钥长度都是64个字节。
     */
    private static final int KEY_LENGTH=128;


    /**
     * @Title: AES_Encrypt
     * @Description: AES 加密:因为加密后的byte数组是不能强制转换成字符串的，换言之：字符串和byte数组在这种情况下不是互逆的
     * 				<p>这里将Base64.encodeBase64(byte[])(同样也可以使用二进制byte[]转化为16进制字符串返回)</p>
     * @param keyStr	key
     * @param plainText	需要加密的字符串
     * @return String	返回AES加密后的字符串
     */
    public static String AES_Encrypt(String keyStr, String plainText) {
        byte[] encrypt = null;
        try {
            SecretKeySpec key = new SecretKeySpec(keyStr.getBytes(), AESTYPE);
            Cipher cipher = Cipher.getInstance(AESTYPE);
            cipher.init(Cipher.ENCRYPT_MODE, key);
            encrypt = cipher.doFinal(plainText.getBytes());
        } catch (Exception e) {
            e.printStackTrace();
        }
//		return parseByte2HexStr(encrypt);
        return new String(Base64.encodeBase64(encrypt));
    }

    /**
     * @Title: AES_Decrypt
     * @Description: AES 解密：如果用Base加密的byte[]，用Base64.decodeBase64(byte[])进行处理后解密
     * 				<p>注：将16进制的字符串转化为二进制的byte[]进行AES解密，获得解密后的字符串</p>
     * @param keyStr	key
     * @param encryptData	需要解密的字符串
     * @return String 返回类型
     */
    public static String AES_Decrypt(String keyStr, String encryptData) {
        byte[] decrypt = null;
        try {
            SecretKeySpec key = new SecretKeySpec(keyStr.getBytes(), AESTYPE);
            Cipher cipher = Cipher.getInstance(AESTYPE);
            cipher.init(Cipher.DECRYPT_MODE, key);
//			decrypt = cipher.doFinal(parseHexStr2Byte(encryptData));
            decrypt = cipher.doFinal(Base64.decodeBase64(encryptData));
        } catch (Exception e) {
            e.printStackTrace();
        }
        return new String(decrypt).trim();
    }


    /**
     * @Title: getKey
     * @Description: 自动生成AES128位密钥：AES 加密密钥长度可以是 128、192、256
     * 				<p>生成的密钥为byte[]数组，转化为16进制的字符串进行使用</p>
     * @return String    返回类型
     */
    public static String getKey() {
        try {
            KeyGenerator kg = KeyGenerator.getInstance(AESTYPE);
            kg.init(KEY_LENGTH);
            SecretKey sk = kg.generateKey();
            byte[] b = sk.getEncoded();
            String s = parseByte2HexStr(b);
            return s;
        } catch (NoSuchAlgorithmException e) {
            e.printStackTrace();
            return null;
        }
    }

    /**
     * @Title: parseByte2HexStr
     * @Description: 将二进制转换成16进制String
     * @param buf
     * @return String    返回类型
     */
    public static String parseByte2HexStr(byte buf[]) {
        StringBuffer sb = new StringBuffer();
        for (int i = 0; i < buf.length; i++) {
            String hex = Integer.toHexString(buf[i] & 0xFF);
            if (hex.length() == 1) {
                hex = '0' + hex;
            }
            sb.append(hex.toUpperCase());
        }
        return sb.toString();
    }

    /**
     * @Title: parseHexStr2Byte
     * @Description: 将16进制转换为二进制字符串
     * @param hexStr
     * @return byte[]    返回类型
     */
    public static byte[] parseHexStr2Byte(String hexStr) {
        if (hexStr.length() < 1){
            return null;
        }
        byte[] result = new byte[hexStr.length() / 2];
        for (int i = 0; i < hexStr.length() / 2; i++) {
            int high = Integer.parseInt(hexStr.substring(i * 2, i * 2 + 1), 16);
            int low = Integer.parseInt(hexStr.substring(i * 2 + 1, i * 2 + 2), 16);
            result[i] = (byte) (high * 16 + low);
        }
        return result;
    }

    public static void main(String[] args) throws Exception {
        //密钥
        String keyStr = getKey();
        System.out.println(keyStr);

        //加密字符串
        String plainText = "[{'idc_id':'1','sum':'10','name':'kekong'},{'idc_id':'1','sum':'15','name':'kekong'},{'idc_id':'1','sum':'15','name':'kekong'},{'idc_id':'1','sum':'15','name':'kekong'},{'idc_id':'1','sum':'15','name':'kekong'},{'idc_id':'1','sum':'15','name':'kekong'},{'idc_id':'1','sum':'15','name':'kekong'},{'idc_id':'1','sum':'15','name':'kekong'},{'idc_id':'1','sum':'15','name':'kekong'},{'idc_id':'1','sum':'15','name':'kekong'},{'idc_id':'1','sum':'15','name':'kekong'},{'idc_id':'1','sum':'15','name':'kekong'}]";

        //加密
        String encText = AES_Encrypt(keyStr, plainText);
        System.out.println(encText);

        //解密
        String decString = AES_Decrypt(keyStr, "059zxKy2Ip5lgsLuceqGRzlI6mfDy+/kh7z9nkPohypOdTuDC1/Orgig1sF176LWz6FP7aAiNEs2Zz37Xl0OpLATcXZ0hnjxZW6HO5Ji6aIawukC7Pl06INDCI8PHdODX2Nb4P8x0e9ARdwcWLW1lm/zlXaL4jUv6sDrRtg1T+B88TTHTDsx21Dg7PY0v0og");
        System.out.println(decString);

    }
}
