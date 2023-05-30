using System.Data;

namespace ServisTakip.Core.Extensions
{
    public static class ToolsExtensions
    {
        public static DataSet ToDataSet<T>(this List<T> list, string tableName)
        {
            Type elementType = typeof(T);
            DataSet ds = new DataSet();
            DataTable t = new DataTable();
            ds.Tables.Add(t);

            //add a column to table for each public property on T
            foreach (var propInfo in elementType.GetProperties())
            {
                Type ColType = Nullable.GetUnderlyingType(propInfo.PropertyType) ?? propInfo.PropertyType;

                t.Columns.Add(propInfo.Name, ColType);
            }

            //go through each property on T and add each value to the table
            foreach (T item in list)
            {
                DataRow row = t.NewRow();

                foreach (var propInfo in elementType.GetProperties())
                {
                    row[propInfo.Name] = propInfo.GetValue(item, null) ?? DBNull.Value;
                }

                t.Rows.Add(row);
            }

            ds.Tables[0].TableName = tableName;
            return ds;
        }

        public static DataSet ToDataSet<T>(this T data, string tableName)
        {
            Type elementType = typeof(T);
            DataSet ds = new DataSet();
            DataTable t = new DataTable();
            ds.Tables.Add(t);

            //add a column to table for each public property on T
            foreach (var propInfo in elementType.GetProperties())
            {
                Type ColType = Nullable.GetUnderlyingType(propInfo.PropertyType) ?? propInfo.PropertyType;

                t.Columns.Add(propInfo.Name, ColType);
            }

            //go through each property on T and add each value to the table
            DataRow row = t.NewRow();

            foreach (var propInfo in elementType.GetProperties())
            {
                row[propInfo.Name] = propInfo.GetValue(data, null) ?? DBNull.Value;
            }

            t.Rows.Add(row);

            ds.Tables[0].TableName = tableName;
            return ds;
        }
    }
}
