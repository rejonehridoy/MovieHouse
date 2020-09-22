<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BasicWeb._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    

    <!-- ##### Hero Area Start ##### -->
    <div class="hero-area">
        <!-- Hero Post Slides -->
        <div class="hero-post-slides owl-carousel">



                            <% 
    if (movies_list.Count > 0)
    {
        foreach (var movie in movies_list)
        { %>

            <!-- Single Slide -->
            <div class="single-slide bg-img bg-overlay" style="background-image: url(<%=movie.PhotoURL%>);">
                <!-- Blog Content -->
                <div class="container-fluid h-100">
                    <div class="row h-100 align-items-center">
                        <div class="col-12 col-lg-9">
                            <div class="blog-content" data-animation="fadeInUp" data-delay="100ms">
                                <a href="MovieDetails.aspx?Mid=<%=movie.Mid%>"><h2 data-animation="fadeInUp" data-delay="400ms"><%=movie.Name %> (<%=movie.ReleaseYear%>)</h2></a>
                                <p data-animation="fadeInUp" data-delay="700ms"><%=movie.Description %></p>
                                
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <%}
    }
    else
    {
                    %>
                <h2>No Movies Available</h2>
                <%} %>
            
            <!-- Single Slide -->
            <!--<div class="single-slide bg-img bg-overlay" style="background-image: url(img/bg-img/terminator.jpg);">-->
                <!-- Blog Content -->
                <!--<div class="container-fluid h-100">
                    <div class="row h-100 align-items-center">
                        <div class="col-12 col-lg-9">
                            <div class="blog-content" data-animation="fadeInUp" data-delay="100ms">
                                <h2 data-animation="fadeInUp" data-delay="400ms">Terminator Dark Fate</h2>
                                <p data-animation="fadeInUp" data-delay="700ms">An augmented human and Sarah Connor must stop an advanced liquid Terminator from hunting down a young girl, whose fate is critical to the human race.</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>-->

        </div>
    </div>
    <!-- ##### Hero Area End ##### -->

    <!-- ##### Games Area Start ##### -->
    <div class="games-area section-padding-100-0">
        <div class="container-fluid">
            <div class="row">
                <!-- Single Games Area -->
                <div class="col-12 col-md-4">
                    <div class="single-games-area text-center mb-100 wow fadeInUp" data-wow-delay="100ms">
                        <img src="images/mcu.jpg" width="210" alt="">
                        <a href="Search.aspx?key=Marvel cinematic universe" class="btn egames-btn mt-30">View Movies</a>
                    </div>
                </div>

                <!-- Single Games Area -->
                <div class="col-12 col-md-4">
                    <div class="single-games-area text-center mb-100 wow fadeInUp" data-wow-delay="300ms">
                        <img src="images/dc.jpg" width="210" alt="">
                        <a href="Search.aspx?key=dc" class="btn egames-btn mt-30">View Movies</a>
                    </div>
                </div>

                <!-- Single Games Area -->
                <div class="col-12 col-md-4">
                    <div class="single-games-area text-center mb-100 wow fadeInUp" data-wow-delay="500ms">
                        <img src="images/paramount.jpg" width="210" alt="">
                        <a href="Search.aspx?key=Paramount Pictures" class="btn egames-btn mt-30">View Movies</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- ##### Games Area End ##### -->

    <!-- ##### Monthly Picks Area Start ##### -->
    <section class="monthly-picks-area section-padding-100 bg-pattern">
        <div class="container-fluid">
            <div class="row">
                <div class="col-12">
                  <div class="left-right-pattern" style="margin-left: 85px;margin-right: 85px;"></div>
                </div>
            </div>
        </div>

        <div class="container-fluid">
            <div class="row">
                <div class="col-12">
                    <!-- Title -->
                   <h2 class="section-title mb-70 wow fadeInUp" data-wow-delay="100ms" style="visibility: visible; animation-delay: 100ms; animation-name: fadeInUp;margin-left: 610px;">This Month’s Pick </h2>
                </div>
            </div>

            <div class="row">
                <div class="col-12">
                   <ul class="nav nav-tabs wow fadeInUp" data-wow-delay="300ms" id="myTab" role="tablist" style="visibility: visible; animation-delay: 300ms; animation-name: fadeInUp;margin-left: 414px;">
                        <li class="nav-item">
                            <a class="nav-link active" id="popular-tab" data-toggle="tab" href="#popular" role="tab" aria-controls="popular" aria-selected="true">Popular</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" id="latest-tab" data-toggle="tab" href="#latest" role="tab" aria-controls="latest" aria-selected="false">Latest</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" id="editor-tab" data-toggle="tab" href="#editor" role="tab" aria-controls="editor" aria-selected="false">Most Viwed</a>
                        </li>
                    </ul>   
                      
                </div>
            </div>
        </div>

        <div class="tab-content wow fadeInUp" data-wow-delay="500ms" id="myTabContent">
            <div class="tab-pane fade show active" id="popular" role="tabpanel" aria-labelledby="popular-tab">
                <!-- Popular Games Slideshow -->
                <div class="popular-games-slideshow owl-carousel">

             <% 
                 if (movies_popular.Count > 0)
                 {
                     for (var movie= 0; movie < movies_popular.Count; movie++)
                { %>

                    <!-- Single Games -->
                    <div class="single-games-slide">
                        <img src="<%=movies_popular[movie].PosterURL%>" alt="">
                        <div class="slide-text">
                            <a href="MovieDetails.aspx?Mid=<%=movies_popular[movie].Mid%>" class="game-title"><%=movies_popular[movie].Name%></a>
                            <div class="meta-data">
                                <a href="MovieDetails.aspx?Mid=<%=movies_popular[movie].Mid%>">Rating: <%=movies_popular[movie].Ratings%>/10</a><br />
                                <br><a href="MovieDetails.aspx?Mid=<%=movies_popular[movie].Mid%>"><%=movie_popular_info_genre[movie]%></a>
                            </div>
                        </div>
                    </div>

                <%}
            }
            else
            {
                            %>
                        <h2>No Movies Available</h2>
             <%} %>


                    

                </div>
            </div>
            <div class="tab-pane fade" id="latest" role="tabpanel" aria-labelledby="latest-tab">
                <!-- Latest Games Slideshow -->
                <div class="latest-games-slideshow owl-carousel">

                     <% 
            if (movies_latest.Count > 0)
            {
                for (var movie= 0; movie < movies_latest.Count; movie++)
                { %>

                    <!-- Single Games -->
                    <div class="single-games-slide">
                        <img src="<%=movies_latest[movie].PosterURL%>" alt="">
                        <div class="slide-text">
                            <a href="MovieDetails.aspx?Mid=<%=movies_latest[movie].Mid%>" class="game-title"><%=movies_latest[movie].Name%></a>
                            <div class="meta-data">
                                <a href="MovieDetails.aspx?Mid=<%=movies_latest[movie].Mid%>">Rating: <%=movies_latest[movie].Ratings%>/10</a>
                                <br><a href="MovieDetails.aspx?Mid=<%=movies_latest[movie].Mid%>"><%=movie_latest_info_genre[movie]%></a>
                            </div>
                        </div>
                    </div>

                <%}
            }
            else
            {
                            %>
                        <h2>No Movies Available</h2>
             <%} %>

                    

                </div>
            </div>
            <div class="tab-pane fade" id="editor" role="tabpanel" aria-labelledby="editor-tab">
                <!-- Most Viwed Slideshow -->
                <div class="editor-games-slideshow owl-carousel">

                             <% 
                    if (movies_mostViewd.Count > 0)
                    {
                        for (var movie= 0; movie < movies_mostViewd.Count; movie++)
                        { %>

                            <!-- Single Games -->
                            <div class="single-games-slide">
                                <img src="<%=movies_mostViewd[movie].PosterURL%>" alt="">
                                <div class="slide-text">
                                    <a href="MovieDetails.aspx?Mid=<%=movies_mostViewd[movie].Mid%>" class="game-title"><%=movies_mostViewd[movie].Name%></a>
                                    <div class="meta-data">
                                        <a href="MovieDetails.aspx?Mid=<%=movies_mostViewd[movie].Mid%>">Rating: <%=movies_mostViewd[movie].Ratings%>/10</a>
                                        <br><a href="MovieDetails.aspx?Mid=<%=movies_mostViewd[movie].Mid%>"><%=movie_mostViwed_info_genre[movie]%></a>
                                    </div>
                                </div>
                            </div>

                        <%}
                    }
                    else
                    {
                                    %>
                                <h2>No Movies Available</h2>
                     <%} %>

                </div>
            </div>
        </div>
    </section>
    <!-- ##### Monthly Picks Area End ##### -->

    <!-- ##### Video Area Start ##### -->
    <div class="egames-video-area section-padding-100 bg-pattern2">
        <div class="container-fluid">
            <div class="row no-gutters">
                <div class="col-12 col-md-6 col-lg-4">
                    <div class="egames-nav-btn">
                        <div class="nav flex-column" id="video-tab" role="tablist" aria-orientation="vertical">
                            <a class="nav-link active" id="video<%=movies_latest[0].Mid%>" data-toggle="pill" href="#video-<%=movies_latest[0].Mid%>" role="tab" aria-controls="video-<%=movies_latest[0].Mid%>" aria-selected="true">
                                <!-- Single Video Widget -->
                                <div class="single-video-widget d-flex wow fadeInUp" data-wow-delay="100ms">
                                    <div class="video-thumbnail">
                                        <img src="<%=movies_latest[0].PosterURL%>" alt="">
                                    </div>
                                    <div class="video-text">
                                        <p class="video-title mb-0"><%=movies_latest[0].Name%></p>
                                        <span><%=movies_latest[0].Genre%></span>
                                    </div>
                                    <div class="video-rating"><%=movies_latest[0].Ratings%>/10</div>
                                </div>
                            </a>

                                     <% 
                            if (movies_latest.Count > 0)
                            {
                                for (int movie=1; movie<movies_latest.Count; movie++)
                                { %>

                                    <a class="nav-link" id="video<%=movies_latest[movie].Mid%>" data-toggle="pill" href="#video-<%=movies_latest[movie].Mid%>" role="tab" aria-controls="video-<%=movies_latest[movie].Mid%>" aria-selected="false">
                                        <!-- Single Video Widget -->
                                        <div class="single-video-widget d-flex wow fadeInUp" data-wow-delay="200ms">
                                            <div class="video-thumbnail">
                                                <img src="<%=movies_latest[movie].PosterURL%>" alt="">
                                            </div>
                                            <div class="video-text">
                                                <p class="video-title mb-0"><%=movies_latest[movie].Name%></p>
                                                <span><%=movies_latest[movie].Genre%></span>
                                            </div>
                                            <div class="video-rating"><%=movies_latest[movie].Ratings%>/10</div>
                                        </div>
                                    </a>

                                     <%}
                            }
                            else
                            {
                                            %>
                                        <h2>No Movies Available</h2>
                             <%} %>


                            
                        </div>
                    </div>
                </div>

                <div class="col-12 col-md-6 col-lg-8">
                    <div class="tab-content" id="video-tabContent">
                        <div class="tab-pane fade show active" id="video-<%=movies_latest[0].Mid%>" role="tabpanel" aria-labelledby="video<%=movies_latest[0].Mid%>">
                            <div class="video-playground bg-img" style="background-image: url(<%=movies_latest[0].PhotoURL%>);">
                                <!-- Play Button -->
                                <div class="play-btn">
                                    <a href="<%=movies_latest[0].Trailer%>" class="play-button"><img src="img/core-img/play.png" alt=""></a>
                                </div>
                            </div>
                        </div>

                        <% 
                            if (movies_latest.Count > 0)
                            {
                                for (int movie=1; movie<movies_latest.Count; movie++)
                                { %>
                                    <div class="tab-pane fade" id="video-<%=movies_latest[movie].Mid%>" role="tabpanel" aria-labelledby="video<%=movies_latest[movie].Mid%>">
                                        <div class="video-playground bg-img" style="background-image: url(<%=movies_latest[movie].PhotoURL%>);">
                                            <!-- Play Button -->
                                            <div class="play-btn">
                                                <a href="<%=movies_latest[movie].Trailer%>" class="play-button"><img src="img/core-img/play.png" alt=""></a>
                                            </div>
                                        </div>
                                    </div>

                        <%}
                            }
                            else
                            {
                                            %>
                                        <h2>No Movies Available</h2>
                             <%} %>


                        
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- ##### Video Area End ##### -->

    <!-- ##### Latest Review Area Start ##### -->
    <section class="latest-articles-area section-padding-100-0 bg-img bg-pattern bg-fixed" style="background-image: url(img/bg-img/5.jpg);">
        <div class="container-fluid">
            <div class="row justify-content-center">
                <div class="col-12 col-lg-10">
                    <div class="mb-100">
                        <!-- Title -->
                        <h2 class="section-title mb-70 wow fadeInUp" data-wow-delay="100ms">Latest Reviews</h2>

                            <% 
                        if (movies_Review.Count > 0)
                        {
                            foreach (var movie in movies_Review)
                            { %>

                                <!-- *** Single Articles Area *** -->
                                <div class="single-articles-area style-2 d-flex flex-wrap mb-30 wow fadeInUp" data-wow-delay="300ms">
                                    <div class="article-thumbnail">
                                        <img src="<%=movie.PhotoURL%>" alt="">
                                    </div>
                                    <div class="article-content">
                                        <a href="MovieDetails.aspx?Mid=<%=movie.Mid%>" class="post-title"><%=movie.MovieName%> (<%=movie.ReleaseYear%>)</a>
                                        <div class="post-meta">
                                            <a href="#" class="post-date"><%=movie.ReviewDate%></a>
                                            <a href="#" class="post-comments"><%=movie.UserName%></a>
                                            <a href="#" class="post-date">Rating: <%=movie.Rating%>/10</a>
                                        </div>
                                        <p><%=movie.Message%></p>
                                    </div>
                                </div>

                        <%}
                            }
                            else
                            {
                                            %>
                                        <h2 style="color:white">No Review Available</h2>
                             <%} %>

                        
                    </div>
                </div>

                
            </div>
        </div>
    </section>
    <!-- ##### Articles Area End ##### -->

</asp:Content>
