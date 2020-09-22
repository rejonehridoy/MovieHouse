<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="BasicWeb.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
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
                                <h2 data-animation="fadeInUp" data-delay="400ms"><%=movie.Name %> (<%=movie.ReleaseYear%>)</h2>
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
    <link href="css/about.css" rel="stylesheet" />
<br />
<div class="about-section">
  
  <h1><strogn>About Us  </strogn></h1>
  <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris velit arcu, scelerisque dignissim massa quis, mattis facilisis erat. Aliquam erat volutpat. Sed efficitur diam ut interdum ultricies.</p>
  
</div>

<h1 style="text-align:center">Our Team</h1>
<div class="row">
  <div class="column">
    <div class="card">
     <img src="images/User/sami.jpg" alt="Sami" style="width:70%;margin-left: 16%;padding:50px">
      <div class="container">
          <div>
              <center>
                <h2>Mehedi Hasan Sami</h2>
                <p class="title" sytle="height: 25px;">
                    ASP.Net Developer<br />
                    Ahsanullah University Of Science & Technology<br />
                    ID :170104118<br />
                    mhsami@gmail.com
               
                </p> 
              </center>
          </div>
        
        
      </div>
    </div>
  </div>

  <div class="column">
    <div class="card">
      <img src="images/User/hridoy.jpg " alt="Hridoy" style="width:70%;margin-left: 16%; padding:50px">
     
      <div class="container">
        <div>
              <center>
                <h2>Rejone E Rasul Hridoy</h2>
                <p class="title" sytle="height: 25px;">
                    ASP.Net Developer<br />
                    Ahsanullah University Of Science & Technology<br />
                    ID :170104116<br />
                    rejonerasul@gmail.com
               
                </p> 
              </center>
          </div>
       
      </div>
    </div>
  </div>

 
</div>
  
</asp:Content>
