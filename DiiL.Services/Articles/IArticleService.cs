using DiiL.Core.Domain.Articles;
using PagedList;

namespace DiiL.Services.Articles
{
    public interface IArticleService
    {
        Article GetArticleById(int articleId);

        IPagedList<Article> SearchArticles();
    }
}