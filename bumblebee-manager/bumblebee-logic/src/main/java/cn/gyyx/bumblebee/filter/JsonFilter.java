package cn.gyyx.bumblebee.filter;

import com.alibaba.fastjson.serializer.ValueFilter;

/**
 * @Author : east.Fu
 * @Description : 自定义jsonfilter，将null值转化为“”,避免转json后数据丢失
 * @Date : Created in  2017/6/29 9:20
 */
public class JsonFilter {
    public static final ValueFilter filter = new ValueFilter() {
        @Override
        public Object process(Object obj, String s, Object v) {
            if(v==null)
                return "";
            return v;
        }
    };
}
