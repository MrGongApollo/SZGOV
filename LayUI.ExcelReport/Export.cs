//描述：导出

using NPOI.SS.UserModel;
using NPOI.Extend;

namespace LayUI.ExcelReport
{
    public static class Export
    {
        /// <summary>
        ///     导出格式化处理后的文件到二进制文件流
        /// </summary>
        /// <param name="templateFile"></param>
        /// <param name="sheetFormatters"></param>
        /// <returns></returns>
        public static byte[] ExportToBuffer(string templateFile, params SheetFormatter[] sheetFormatters)
        {
            IWorkbook workbook = NPOIHelper.LoadWorkbook(templateFile);
            foreach (SheetFormatter sheetFormatter in sheetFormatters)
            {
                sheetFormatter.Format(workbook);
            }
            return workbook.SaveToBuffer();
        }
    }
}
