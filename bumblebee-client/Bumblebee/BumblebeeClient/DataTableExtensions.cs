using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace BumblebeeClient
{
    static  class DataTableExtensions
    {
        public static DataTable ToDataTable<T>(this List<T> list)
        {
            DataTable result = new DataTable();
            List<PropertyInfo> pList = new List<PropertyInfo>();
            Type type = typeof(T);
            Array.ForEach<PropertyInfo>(type.GetProperties(), prop => { pList.Add(prop); result.Columns.Add(prop.Name, prop.PropertyType); });
            foreach (var item in list)
            {
                DataRow row = result.NewRow();
                pList.ForEach(p => row[p.Name] = p.GetValue(item, null));
                result.Rows.Add(row);
            }
            return result;
        }
    }
}
