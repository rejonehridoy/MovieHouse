using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicWeb.Models
{
    public class Movies
    {
        public string Mid { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string PosterURL { get; set; }
        public string PhotoURL { get; set; }
        public string ReleaseYear { get; set; }
        public string StudioName { get; set; }
        public string RunTime { get; set; }
        public string Ratings { get; set; }
        public string NoOfView { get; set; }
        public string NoOfReview { get; set; }
        public string Genre { get; set; }
        public string Trailer { get; set; }
        public string EmbedURL { get; set; }
        public string Language { get; set; }
        public string StoryLine { get; set; }

        // used in Default.aspx for Slider view
        public Movies(string mid,string name,string category,string description,string posterurl,string photourl,
            string releaseyear,string studioname,string runtime,string ratings,string noofview,string noofreviw,string trailer)
        {
            Mid = mid;
            Name = name;
            Category = category;
            Description = description;
            PhotoURL = photourl;
            PosterURL = posterurl;
            ReleaseYear = releaseyear;
            StudioName = studioname;
            RunTime = runtime;
            Ratings = ratings;
            NoOfReview = noofreviw;
            NoOfView = noofview;
            Trailer = trailer;
        }
        // used in Default.aspx for Tab view
        public Movies(string mid,string name,string category,string posterurl,string ratings,string photourl,string trailer)
        {
            Mid = mid;
            Name = name;
            PosterURL = posterurl;
            Category = category;
            Ratings = ratings;
            PhotoURL = photourl;
            Trailer = trailer;
        }

        // used in MovieDetails.aspx for fetching the details of movie
        public Movies(string name, string category, string description, string posterurl, string photourl,
            string releaseyear, string studioname, string runtime, string ratings, string noofreview, string noofview, string trailer,
            string embed,string language,string story)
        {
            
            Name = name;
            Category = category;
            Description = description;
            PhotoURL = photourl;
            PosterURL = posterurl;
            ReleaseYear = releaseyear;
            StudioName = studioname;
            RunTime = runtime;
            Ratings = ratings;
            NoOfReview = noofreview;
            NoOfView = noofview;
            Trailer = trailer;
            EmbedURL = embed;
            Language = language;
            StoryLine = story;
        }
        // used un MovieShow.aspx for fetching a short info of movies
        public Movies(string Mid,string Name,string Category,string PosterURL,string ReleaseYear,
            string Ratings)
        {
            this.Mid = Mid;
            this.Name = Name;
            this.Category = Category;
            this.PosterURL = PosterURL;
            this.ReleaseYear = ReleaseYear;
            this.Ratings = Ratings;
        }


    }
}