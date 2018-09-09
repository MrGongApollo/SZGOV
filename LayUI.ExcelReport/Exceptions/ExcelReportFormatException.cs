//描述：ExcelReport格式化异常

namespace LayUI.ExcelReport.Exceptions
{
    public class ExcelReportFormatException : ExcelReportException
    {
        public ExcelReportFormatException(string message)
            : base(message)
        {
        }
    }
}
