using diil.web.DataBase;
using System;
namespace diil.web.Domain
{
    /// <summary>
    /// System_Role表实体类
    /// </summary>
    public partial class SystemRole : BaseEntity
    {
        /// <summary>
        /// 角色id
        /// </summary>		
		public Guid RoleId { get; set; }

        /// <summary>
        /// 组织机构id
        /// </summary>		
        public Guid OrganizationId { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>		
        public string Name { get; set; }

        /// <summary>
        /// 状态,临时角色等
        /// </summary>		
        public short? State { get; set; }

        /// <summary>
        /// 是否允许删除
        /// </summary>		
        public bool CanbeDelete { get; set; }

        /// <summary>
        /// 排序
        /// </summary>		
        public int OrderNo { get; set; }

        /// <summary>
        /// 备注
        /// </summary>		
        public string Remark { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>		
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建用户Id
        /// </summary>		
        public Guid CreateUserId { get; set; }

        /// <summary>
        /// 创建人员名称
        /// </summary>
        public string CreateUserName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>		
        public DateTime? UpdateTime { get; set; }

        /// <summary>
        /// 创建用户Id
        /// </summary>		
        public Guid? UpdateUserId { get; set; }

        /// <summary>
        /// 修改人员名称
        /// </summary>
        public string UpdateUserName { get; set; }

        /// <summary>
        /// 冻结
        /// </summary>		
        public bool IsFreeze { get; set; }
    }
}
