using System.Reflection;
using System.Web.Mvc;

namespace DiiL.Web.Framework.Mvc.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled)
            {
                return;
            }

            /*  
             * 错误日志 
              */
            var logger = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            logger.Error(filterContext.Exception.Message, filterContext.Exception);
            /*  
             * 设置自定义异常已经处理,避免其他过滤器异常覆盖 
              */
            filterContext.ExceptionHandled = true;

            /*  
             * 在派生类重写时,设置或者重写一个值该值指定是否禁用ISS7.0中自定义错误 
              */
            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
        }
    }
}
