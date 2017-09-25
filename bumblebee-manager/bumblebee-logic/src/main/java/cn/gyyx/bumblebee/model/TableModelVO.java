package cn.gyyx.bumblebee.model;

import java.util.Map;

/**
 * @Author : east.Fu
 * @Description :
 * @Date : Created in  2017/9/23 15:38
 */
public class TableModelVO {

    /**
     * 刷新的次数
     */
    private Integer draw;

    /**
     * 开始序号index
     */
    private Integer start;

    /**
     * pageSize
     */
    private Integer length;

    /**
     * search[value]
     * search[regex]   true/false
     */
    private Map<String,String> search;

    public Integer getDraw() {
        return draw;
    }

    public void setDraw(Integer draw) {
        this.draw = draw;
    }
    public Integer getStart() {
        return start;
    }
    public void setStart(Integer start) {
        this.start = start;
    }
    public Integer getLength() {
        return length;
    }
    public void setLength(Integer length) {
        this.length = length;
    }

    public Map<String, String> getSearch() {
        return search;
    }

    public void setSearch(Map<String, String> search) {
        this.search = search;
    }
}
