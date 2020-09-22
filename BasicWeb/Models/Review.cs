using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicWeb.Models
{
    public class Review
    {
        public string MovieName { get; set; }
        public string Mid { get; set; }
        public string ReleaseYear { get; set; }
        public string PosterURL { get; set; }
        public string PhotoURL { get; set; }
        public string Uid { get; set; }
        public string UserName { get; set; }
        public string Rid { get; set; }
        public string Message { get; set; }
        public string Rating { get; set; }
        public string ReviewDate { get; set; }

        // used in Default.aspx for user review
        public Review(string Mid,string MovieName,string ReleaseYear,string PosterURL,string PhotoURL,
            string Uid,string UserName,string Rid,string Message,string Rating,string ReviewDate)
        {
            this.Mid = Mid;
            this.MovieName = MovieName;
            this.ReleaseYear = ReleaseYear;
            this.PosterURL = PosterURL;
            this.PhotoURL = PhotoURL;
            this.Uid = Uid;
            this.UserName = UserName;
            this.Rid = Rid;
            this.Message = Message;
            this.Rating = Rating;
            this.ReviewDate = ReviewDate;

        }

        //used for MovieDetails.aspx for access movie review
        public Review(string Uid,string Name,string photourl,string rating,string message,string reviewdate)
        {
            this.Uid = Uid;
            UserName = Name;
            PhotoURL = photourl;
            Rating = rating;
            Message = message;
            ReviewDate = reviewdate;
        }
    }
}