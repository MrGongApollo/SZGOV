 //描述：ExcelReport异常
using System;

namespace LayUI.ExcelReport.Exceptions
{
    public class ExcelReportException : ApplicationException
    {
        public ExcelReportException(string message)
            : base(message)
        {
        }
    }
}
