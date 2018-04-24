using diil.web.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace diil.web.Domain
{
    public partial class Article : BaseEntity
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreateTime { get; set; }
        public string Title { get; set; }
    }
}