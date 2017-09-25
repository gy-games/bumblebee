package cn.gyyx.bumblebee.model;

import java.util.List;

/**
 * @Author : east.Fu
 * @Description :
 * @Date : Created in  2017/9/23 15:37
 */
public class Pagination<T> {
    private Integer draw;
    private Integer recordsTotal;
    private Integer recordsFiltered;
    private List<T> data;

    public Integer getDraw() {
        return draw;
    }
    public Pagination<T> setDraw(Integer draw) {
        this.draw = draw;
        return this;
    }
    public Integer getRecordsTotal() {
        return recordsTotal;
    }
    public Pagination<T> setRecordsTotal(Integer recordsTotal) {
        this.recordsTotal = recordsTotal;
        return this;
    }
    public Integer getRecordsFiltered() {
        return recordsFiltered;
    }
    public Pagination<T> setRecordsFiltered(Integer recordsFiltered) {
        this.recordsFiltered = recordsFiltered;
        return this;
    }
    public List<T> getData() {
        return data;
    }
    public Pagination<T> setData(List<T> data) {
        this.data = data;
        return this;
    }
}
