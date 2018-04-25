using diil.web.DataBase;
using System;

namespace diil.web.Domain
{
    public partial class SystemMenuButtonFunction : BaseEntity
    {
        /// <summary>
        /// 菜单按钮Id
        /// </summary>
        public Guid MenuButtonId { get; set; }

        /// <summary>
        /// 功能项Id
        /// </summary>
        public Guid FunctionId { get; set; }
    }
}