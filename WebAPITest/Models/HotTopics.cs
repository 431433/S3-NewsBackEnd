using NewsAPI;
using NewsAPI.Models;
using NewsAPI.Constants;

namespace BackEnd.Models
{
    public class HotTopics
    {
        public int Amount;
        public string? Title;
        public string? SourceName;
        public string? Description;
        public string? Url;
        public DateTime ReleaseDate = DateTime.Today;
        public string Search;

        public List<Article> newsArticles = new();

        public HotTopics()
        {
        }

        public HotTopics(Article news)
        {
            Title = news.Title;
            SourceName = news.Source.Name;
            Description = news.Description;
            ReleaseDate = (DateTime)news.PublishedAt;
            Url = news.Url;
        }


        public List<Article> NavBar(Languages language, DateTime date, string subject)
        {
            var newsApiClient = new NewsApiClient("64526745974a43a68186465bb4bcc8be");
                var articlesResponse = newsApiClient.GetEverything(new EverythingRequest
                {
                    Q = subject,
                    SortBy = SortBys.Popularity,
                    Language = language,
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
                    newsArticles.Add(article);
                }
            }
            return newsArticles;
        }
    }
}
