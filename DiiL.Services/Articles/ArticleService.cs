using DiiL.Core;
using DiiL.Core.Data;
using PagedList;
using System;

namespace DiiL.Services.Articles
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

        public IPagedList<Article> SearchArticles()
        {
            throw new Exception("测试 ExceptionFilter");
            return new PagedList<Article>(this._articleRepository.Table, 10, 1);
        }
    }
}