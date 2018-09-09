 //描述：行标累加器

namespace LayUI.ExcelReport
{
    public class RowIndexAccumulation : Accumulation
    {
        #region 1.0 获取当前行标

        /// <summary>
        ///     获取当前行标
        /// </summary>
        /// <param name="sourceRowIndex">源行标</param>
        /// <returns></returns>
        public int GetCurrentRowIndex(int sourceRowIndex)
        {
            return Value + sourceRowIndex;
        }

        #endregion
    }
}
