using System;

namespace DiiL.Core
{
    public partial class Article : BaseEntity
    {
        public Guid ArticleId { get; set; }
        public string Content { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreateTime { get; set; }
        public string Title { get; set; }
        public int Status { get; set; }
        //新增字段 如果不想发布到正式环境需要在ArticleMap 添加Ignore
        public int? MyProperty { get; set; }
    }
}