using NewsAPI;
using NewsAPI.Models;
using NewsAPI.Constants;

namespace WebAPITest.Models
{
    public class News
    {
        public int Amount { get; private set; }
        public string? Title { get; private set; }
        public string? SourceName { get; private set; }
        public string? Description { get; private set; }
        public string? Url { get; private set; }
        public DateTime ReleaseDate = DateTime.Today;
        public string Search { get; private set; }
        public string Image { get; private set; }
        public int Amount { get; private set; }
    
        public List<Article> newslist = new();

        public News()
        {}

        public News(object item)
        {
            Item = item;
        }
        public News(Article news, int amount)
        {
            Title = news.Title;
            SourceName = news.Source.Name;
            Description = news.Description;
            ReleaseDate = (DateTime)news.PublishedAt;
            Url = news.Url;
            Image = news.UrlToImage;
            Amount = amount;
        }

        public object Item { get; }

        public List<Article> GetNews()
        {
            var newsApiClient = new NewsApiClient("64526745974a43a68186465bb4bcc8be");
            var articlesResponse = newsApiClient.GetEverything(new EverythingRequest
            {
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
                    Image = article.UrlToImage;
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
                    Image = article.UrlToImage;
                    newslist.Add(article);
                }
            }
            return newslist;
        }

        public List<Article> SearchNewsDate(string search, DateTime date)
        {
            var newsApiClient = new NewsApiClient("64526745974a43a68186465bb4bcc8be");
            var articlesResponse = newsApiClient.GetEverything(new EverythingRequest
            {
                Q = search,
                SortBy = SortBys.Popularity,
                Language = Languages.EN,
                From = new DateTime(date.Ticks)
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
