using Microsoft.VisualBasic;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace XST.Exam.Helper
{
    public class ExcelHelper
    {  /// <summary>
       /// 读取excel转换成list集合
       /// </summary>
       /// <typeparam name="T">对象</typeparam>
       /// <param name="stream">文件流</param>
       /// <param name="startIndex">从第几行开始读取</param>
       /// <param name="sheetIndex">读取第几个sheet</param>
       /// <returns></returns>
        public static async Task<List<T>> ExcelLoadeToList<T>(Stream stream, int startIndex, int sheetIndex = 0)
            where T : class
        {
            List<T> ts = new List<T>();
            try
            {
                IWorkbook workbook = WorkbookFactory.Create(stream);
                var sheet = workbook.GetSheetAt(sheetIndex);
                if (sheet != null)
                {
                    IRow firstRow = sheet.GetRow(0);
                    //一行最后一个cell的编号 即总的列数
                    int cellCount = firstRow.LastCellNum;
                    //最后一列的标号
                    int rowCount = sheet.LastRowNum;
                    await Task.Run(() =>
                    {
                        for (int i = startIndex; i <= rowCount; ++i)
                        {
                            //获取行的数据
                            IRow row = sheet.GetRow(i);
                            if (row == null) continue; //没有数据的行默认是null　　　　　　　
                            {
                                T model = Activator.CreateInstance<T>();
                                for (int j = row.FirstCellNum; j < cellCount; ++j)
                                {
                                    if (row.GetCell(j) != null)
                                    {
                                        var rowTemp = row.GetCell(j);
                                        string value = null;
                                        if (rowTemp.CellType == CellType.Numeric)
                                        {
                                            short format = rowTemp.CellStyle.DataFormat;
                                            if (format == 14 || format == 31 || format == 57 || format == 58 || format == 20)
                                                value = rowTemp.DateCellValue.ToString("yyyy-MM-dd");
                                            else
                                                value = rowTemp.NumericCellValue.ToString();
                                        }
                                        else
                                            value = rowTemp.ToString();
                                        //赋值
                                        foreach (System.Reflection.PropertyInfo item in typeof(T).GetProperties())
                                        {
                                            var column = item.GetCustomAttributes(true).First(x => x is ColumnAttribute) as ColumnAttribute;
                                            if (column.Index == j)
                                            {
                                                item.SetValue(model, value);
                                                break;
                                            }
                                        }
                                    }
                                }
                                ts.Add(model);
                            }
                        }
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (stream != null) stream.Close();
            }
            return ts;
        }

        /// <summary>
        /// 将List数据导出到Excel文件 需要在实体类中添加[DisplayAttribute(Name = "名称")]
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="dataList">包含数据的List</param>
        /// <param name="filePath">保存Excel文件的路径</param>
        public static void ExportToExcel<T>(List<T> dataList, string filePath)
        {
            IWorkbook workbook = new XSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("Sheet1");

            // 添加表头
            IRow headerRow = sheet.CreateRow(0);
            int columnIndex = 0;
            foreach (var property in typeof(T).GetProperties())
            {
                string columnHeader = GetDisplayName(property);

                // 使用属性名作为表头的列名
                headerRow.CreateCell(columnIndex).SetCellValue(columnHeader);
                columnIndex++;
            }

            // 添加数据行
            int rowIndex = 1;

            foreach (var data in dataList)
            {
                IRow dataRow = sheet.CreateRow(rowIndex);
                columnIndex = 0;
                foreach (var property in typeof(T).GetProperties())
                {
                    // 获取属性值并将其写入到对应的单元格
                    object value = property.GetValue(data);
                    if (value != null)
                    {
                        dataRow.CreateCell(columnIndex).SetCellValue(value.ToString());
                    }

                    columnIndex++;
                }

                rowIndex++;
            }

            string directoryPath = Path.GetDirectoryName(filePath);
            Directory.CreateDirectory(directoryPath);

            // 保存工作簿到文件
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                workbook.Write(fs);
            }
        }

        public static Byte[] ExportToExcel(DataTable dataTable)
        {
            IWorkbook workbook = new XSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("Sheet1");

            // 添加表头
            IRow headerRow = sheet.CreateRow(0);
            int columnIndex = 0;

            foreach (var data in dataTable.Columns)
            {
                // 使用属性名作为表头的列名
                headerRow.CreateCell(columnIndex).SetCellValue(data.ToString());
                columnIndex++;
            }

            // 添加数据行

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                IRow dataRow = sheet.CreateRow(i + 1);
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    dataRow.CreateCell(j).SetCellValue(dataTable.Rows[i][j].ToString());
                }
            }

            MemoryStream memoryStream = new MemoryStream();
            workbook.Write(memoryStream);

            return memoryStream.ToArray();
        }

        /// <summary>
        ///获取DisplayAttribute
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        private static string GetDisplayName(PropertyInfo property)
        {
            var displayAttribute = property.GetCustomAttribute<DisplayAttribute>();
            if (displayAttribute != null)
            {
                return displayAttribute.Name;
            }
            // 如果没有Display属性，则返回属性名
            return property.Name;
        }
    }
}
