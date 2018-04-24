using diil.web.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace diil.web.Services.Interface
{
    public interface IArticleService
    {
        Article GetArticleById(int articleId);
    }
}