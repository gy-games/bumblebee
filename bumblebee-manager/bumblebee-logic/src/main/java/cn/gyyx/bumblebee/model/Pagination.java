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
    public void setDraw(Integer draw) {
        this.draw = draw;
    }
    public Integer getRecordsTotal() {
        return recordsTotal;
    }
    public void setRecordsTotal(Integer recordsTotal) {
        this.recordsTotal = recordsTotal;
    }
    public Integer getRecordsFiltered() {
        return recordsFiltered;
    }
    public void setRecordsFiltered(Integer recordsFiltered) {
        this.recordsFiltered = recordsFiltered;
    }
    public List<T> getData() {
        return data;
    }
    public void setData(List<T> data) {
        this.data = data;
    }

}
