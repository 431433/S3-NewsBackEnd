using NewsAPI;
using NewsAPI.Models;
using NewsAPI.Constants;

namespace WebAPITest.Models
{
    public class News
    {
        public int Amount;
        public string? Title;
        public string? SourceName;
        public string? Description;
        public string? Url;
        public DateTime ReleaseDate = DateTime.Today;
        public string Search;

        public List<Article> newslist = new();

        public News()
        {}

        public News(object item)
        {
            Item = item;
        }
        public News(Article news)
        {
            Title = news.Title;
            SourceName = news.Source.Name;
            Description = news.Description;
            ReleaseDate = (DateTime)news.PublishedAt;
            Url = news.Url;
        }

        public object Item { get; }

        public List<Article> GetNews()
        {
            var newsApiClient = new NewsApiClient("64526745974a43a68186465bb4bcc8be");
            var articlesResponse = newsApiClient.GetEverything(new EverythingRequest
            {
                Q = "War",
                SortBy = SortBys.Popularity,
                Language = Languages.EN,
                From = new DateTime(ReleaseDate.Ticks)
            });
            if (articlesResponse.Status == Statuses.Ok)
            {
                // total results found
                Amount = articlesResponse.TotalResults;

                foreach (var article in articlesResponse.Articles)
                {
                    // title
                    Title = article.Title;
                    //source
                    SourceName = article.Source.Name;
                    // description
                    Description = article.Description;
                    //release date
                    ReleaseDate = (DateTime)article.PublishedAt;
                    Url = article.Url;
                    newslist.Add(article);
                }
            }
            return newslist;
        }

        public List<Article> SearchNews(string search)
        {
            var newsApiClient = new NewsApiClient("64526745974a43a68186465bb4bcc8be");
           var articlesResponse = newsApiClient.GetEverything(new EverythingRequest
            {
                Q = search,
                SortBy = SortBys.Popularity,
                Language = Languages.EN,
                From = new DateTime(ReleaseDate.Ticks)
            });
            if (articlesResponse.Status == Statuses.Ok)
            {
                // total results found
                Amount = articlesResponse.TotalResults;

                foreach (var article in articlesResponse.Articles)
                {
                    // title
                    Title = article.Title;
                    //source
                    SourceName = article.Source.Name;
                    // description
                    Description = article.Description;
                    //release date
                    ReleaseDate = (DateTime)article.PublishedAt;
                    Url = article.Url;
                    newslist.Add(article);
                }
            }
            return newslist;
        }
    }
}
