//描述：单元格格式化器、内嵌单元格格式化器

using System;
using NPOI.SS.UserModel;
using NPOI.Extend;
using LayUI.ExcelReport.Exceptions;


namespace LayUI.ExcelReport
{
    public class CellFormatter : SimpleFormatter
    {
        #region 0 构造函数

        /// <summary>
        /// 实例化单元格格式化器
        /// </summary>
        /// <param name="parameter">参数</param>
        /// <param name="value">值</param>
        public CellFormatter(Parameter parameter, object value)
            : base(parameter, value)
        {
        }

        #endregion

        #region 1.0 格式化
        /// <summary>
        ///     格式化
        /// </summary>
        /// <param name="sheetAdapter">Sheet适配器</param>
        public override void Format(SheetAdapter sheetAdapter)
        {
            IRow row = sheetAdapter.GetRow(Parameter.RowIndex);
            if (null == row)
            {
                throw new ExcelReportFormatException("row is null");
            }
            ICell cell = row.GetCell(Parameter.ColumnIndex);
            if (null == cell)
            {
                throw new ExcelReportFormatException("cell is null");
            }
            cell.SetValue(Value);
        }
        #endregion
    }

    public class CellFormatter<TSource> : SimpleFormatter<TSource>
    {
        #region 0 构造函数
        /// <summary>
        /// 实例化内嵌单元格格式化器
        /// </summary>
        /// <param name="parameter">参数</param>
        /// <param name="dgSetValue">赋值委托</param>
        public CellFormatter(Parameter parameter, Func<TSource, object> dgSetValue)
            : base(parameter, dgSetValue)
        {
        }
        #endregion

        #region 1.0 格式化
        /// <summary>
        ///     格式化
        /// </summary>
        /// <param name="sheetAdapter">Sheet适配器</param>
        /// <param name="dataSource">数据源</param>
        public override void Format(SheetAdapter sheetAdapter, TSource dataSource)
        {
            IRow row = sheetAdapter.GetRow(Parameter.RowIndex);
            if (null == row)
            {
                throw new ExcelReportFormatException("row is null");
            }
            ICell cell = row.GetCell(Parameter.ColumnIndex);
            if (null == cell)
            {
                throw new ExcelReportFormatException("cell is null");
            }
            if (DgSetValue(dataSource) != null)
            {
                if (DgSetValue(dataSource).ToString().StartsWith("Formula"))
                {
                    cell.SetCellFormula(DgSetValue(dataSource).ToString().Replace("Formula", ""));
                }
                else
                {
                    cell.SetValue(DgSetValue(dataSource));
                }
            }
            else {
                cell.SetValue("");
            }
        }
        #endregion
    }
}
