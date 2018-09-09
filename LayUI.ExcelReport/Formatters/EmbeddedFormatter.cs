//描述：内嵌格式化器接口

namespace LayUI.ExcelReport
{
    public abstract class EmbeddedFormatter<TSource>
    {
        /// <summary>
        ///     格式化
        /// </summary>
        /// <param name="sheetAdapter">Sheet适配器</param>
        /// <param name="dataSource">数据源</param>
        public abstract void Format(SheetAdapter sheetAdapter, TSource dataSource);
    }
}
