using DiiL.Core;
using PagedList;

namespace DiiL.Services.Articles
{
    public interface IArticleService
    {
        Article GetArticleById(int articleId);

        IPagedList<Article> SearchArticles();
    }
}