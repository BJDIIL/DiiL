using diil.web.DataBase;
using diil.web.Domain;
using diil.web.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace diil.web.Services.Imp
{
    public class ArticleService : IArticleService
    {
        #region Fields

        private readonly IRepository<Article> _articleRepository;


        #endregion
        public ArticleService(IRepository<Article> articleRepository)
        {
            this._articleRepository = articleRepository;
        }
        public virtual Article GetArticleById(int articleId)
        {
            if (articleId == 0)
                return null;

            return _articleRepository.GetById(articleId);
        }
    }
}