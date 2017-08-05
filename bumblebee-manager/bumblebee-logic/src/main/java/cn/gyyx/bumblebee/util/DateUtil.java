package cn.gyyx.bumblebee.util;

import org.apache.commons.lang3.StringUtils;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;

/**
 * @Author : east.Fu
 * @Description :
 * @Date : Created in  2017/6/27 17:15
 */
public class DateUtil {
    public static final String DEFAULT_DATETIME_FORMAT = "yyyy-MM-dd HH:mm:ss";
    public static final String DEFAULT_DATE_FORMAT = "yyyy-MM-dd";

    public static String currentTimestamp2String(String format){
        if(StringUtils.isEmpty(format)){
            format = DateUtil.DEFAULT_DATETIME_FORMAT;
        }

        SimpleDateFormat sdf = new SimpleDateFormat(format);
        return sdf.format(new Date());
    }

    public static String formatDate(long currentTimeMillis){
        Date date =new Date(currentTimeMillis);
        return date2String(date);
    }

    public static String formatDate(long currentTimeMillis,String format){
        Date date =new Date(currentTimeMillis);
        return date2String(date,format);
    }

    public static Date String2Date(String sourceTime) {
        return string2Date(sourceTime,DateUtil.DEFAULT_DATETIME_FORMAT);
    }

    public static Date string2Date(String sourceTime,String format){
        SimpleDateFormat sdf = new SimpleDateFormat(format);
        Date date = null;
        try {
            date = sdf.parse(sourceTime);
        } catch (ParseException e) {
            e.printStackTrace();
        }
        return date;
    }

    public static String date2String(Date date){
        if (null != date) {
            SimpleDateFormat sdf = new SimpleDateFormat("yyyyMMddHHmmss");
            return sdf.format(date);
        } else {
            return null;
        }
    }

    public static String date2String(Date date,String format){
        if (null == format || StringUtils.isEmpty(format)) {
            format = DateUtil.DEFAULT_DATETIME_FORMAT;
        }

        if (null != date) {
            SimpleDateFormat sdf = new SimpleDateFormat(format);
            return sdf.format(date);
        } else {
            return null;
        }
    }

    /**
     * 获得前几天的时间
     *
     * @param now
     * @param day
     * @return
     */
    public static String getDateBefore(String now, int day) {
        Calendar c = Calendar.getInstance();
        c.setTime(DateUtil.String2Date(now));
        c.set(Calendar.DATE, c.get(Calendar.DATE) - day);
        return DateUtil.date2String(c.getTime());
    }

    /**
     * 获得后几天的时间
     *
     * @param now
     * @param day
     * @return
     */
    public static String getDateAfter(String now, int day) {
        Calendar c = Calendar.getInstance();
        c.setTime(DateUtil.String2Date(now));
        c.set(Calendar.DATE, c.get(Calendar.DATE) + day);
        return DateUtil.date2String(c.getTime());
    }
}
