<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MovieEntry.aspx.cs" Inherits="BasicWeb.MovieEntry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
       $(document).ready(function () {
           $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
       });
 
       function readURL1(input) {
           if (input.files && input.files[0]) {
               var reader = new FileReader();
 
               reader.onload = function (e) {
                   $('#imgPoster').attr('src', e.target.result);
               };
 
               reader.readAsDataURL(input.files[0]);
           }
       }
       function readURL2(input) {
           if (input.files && input.files[0]) {
               var reader = new FileReader();

               reader.onload = function (e) {
                   $('#imgPicture').attr('src', e.target.result);
               };

               reader.readAsDataURL(input.files[0]);
           }
       }
 
   </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!--Navigation Drawer Menu -->
    <div class="content mt-5 pt-5">
        <!-- List of Drawer Menu -->
		<ul class="nav nav-pills  justify-content-center" id="pills-tab" role="tablist">
            <!-- 1st Item : Movie Entry Form-->
			<li class="nav-item">
				<a class="nav-link active" id="pills-movieEntry-tab" data-toggle="pill" href="#pills-movieEntry" role="tab" aria-controls="pills-movieEntry"
					aria-selected="true">Movie Entry</a>
			</li>
			<!-- 2nd Item : Movie Info-->			
			<li class="nav-item">
				<a class="nav-link" id="pills-movieInfo-tab" data-toggle="pill" href="#pills-movieInfo" role="tab" aria-controls="pills-movieInfo"
					aria-selected="false">Movie Info</a>
			</li>
            <!-- 3rd Item : Cast Info-->
			<li class="nav-item">
				<a class="nav-link" id="pills-castInfo-tab" data-toggle="pill" href="#pills-castInfo" role="tab" aria-controls="pills-castInfo"
					aria-selected="false">Cast Info</a>
			</li>
            <!-- 4th Item : Directors-->
			<li class="nav-item">
				<a class="nav-link" id="pills-directors-tab" data-toggle="pill" href="#pills-directors" role="tab" aria-controls="pills-directors"
					aria-selected="false">Directors</a>
			</li>
            <!-- 5th Item : Users-->
			<li class="nav-item">
				<a class="nav-link" id="pills-users-tab" data-toggle="pill" href="#pills-users" role="tab" aria-controls="pills-users"
					aria-selected="false">Users</a>
			</li>
							
		</ul>   <!-- End of List of Drawer Menu -->
        <!--Start of Navigation Drawer Details -->
        <div class="tab-content" id="pills-tabContent">
            <!--1st Item :Movie Entry Form  Specification-->
            <div class="tab-pane fade show active" id="pills-movieEntry" role="tabpanel" aria-labelledby="pills-movieEntry-tab">
                <!--Movie Entry Form Section -->
                    <div class="container-fluid">
                      <div class="row">
                         <div class="col-md-12">
                            <div class="card">
                               <div class="card-body">
                                  <div class="row">
                                     <div class="col-12">
                                        <center>
                                           <h4><b>Movie Entry Form</b></h4>
                                        </center>
                                     </div>
                      

                                  </div>
                   <!--This is 1st row with 2 showing picture preview -->
                  <div class="row">
                     <div class="col-6">
                        <center>
                           <img id="imgPoster" Height="250px" Width="150px" src="images/movie_poster.png" />
                            <h6>Movie Poster</h6>
                        </center>
                     </div>
                      <div class="col-6">
                        <center>
                           <img id="imgPicture" Height="150px" Width="250px" src="images/movie_picture.png" />
                            <h6>Movie Picture</h6>
                        </center>
                     </div>
                  </div>
                   <!-- End of 1st row -->
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                   <!--This is 2nd row with 2 browse picture -->
                  <div class="row">
                     <div class="col-6">
                        <asp:FileUpload onchange="readURL1(this);" class="form-control" ID="FileUpload1" runat="server" />
                     </div>
                      <div class="col-6">
                        <asp:FileUpload onchange="readURL2(this);" class="form-control" ID="FileUpload2" runat="server" />
                     </div>
                  </div>
                   <!-- End of 2nd row -->
                   <!--This is 3rd row with Movie ID, Movie Name -->
                  <div class="row">
                     <div class="col-md-4">
                        <label>Movie ID</label>
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox CssClass="form-control" ID="tbMid" runat="server" placeholder="Movie ID"></asp:TextBox>
                              <asp:Button class="form-control btn btn-primary" ID="btnMovieIDGo" OnClick="btnMovieIDGo_Click" runat="server" Text="Go" />
                           </div>
                        </div>
                     </div>
                     <div class="col-md-8">
                        <label>Movie Name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tbMovieName" runat="server" placeholder="Movie Name"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                   <!-- End of 3rd row -->
                  <div class="row">
                     <div class="col-md-4">
                        <label>Language</label>
                        <div class="form-group">
                           <asp:DropDownList class="form-control" ID="ddlLanguage" runat="server">
                              <asp:ListItem Text="English" Value="English" />
                              <asp:ListItem Text="Hindi" Value="Hindi" />
                              <asp:ListItem Text="Marathi" Value="Marathi" />
                              <asp:ListItem Text="French" Value="French" />
                              <asp:ListItem Text="German" Value="German" />
                               <asp:ListItem Text="Korean" Value="Korean" />
                               <asp:ListItem Text="Chinese" Value="Chinese" />
                               <asp:ListItem Text="Urdu" Value="Urdu" />
                               <asp:ListItem Text="Tamil" Value="Tamil" />
                               <asp:ListItem Text="Malaylum" Value="Malaylum" />
                               <asp:ListItem Text="Bangla" Value="Bangla" />
                           </asp:DropDownList>
                        </div>
                        <label>Studio Name</label>
                        <div class="form-group">
                           <asp:DropDownList class="form-control" ID="ddlStudioName" runat="server">
                              <asp:ListItem Text="Marvel Cinematic Universe" Value="Marvel Cinematic Universe" />
                              <asp:ListItem Text="DC" Value="DC" />
                               <asp:ListItem Text="Paramount Pictures" Value="Paramount Pictures" />
                               <asp:ListItem Text="Universal Pictures" Value="Universal Pictures" />
                               <asp:ListItem Text="Warner Bros" Value="Warner Bros" />
                               <asp:ListItem Text="Walt Disney Studios" Value="Walt Disney Studios" />
                               <asp:ListItem Text="Fox Searchlight Pictures" Value="Fox Searchlight Pictures" />
                               <asp:ListItem Text="Sony Pictures Motion Picture Group" Value="Sony Pictures Motion Picture Group" />
                               <asp:ListItem Text="20th Century Fox" Value="20th Century Fox" />
                               <asp:ListItem Text="Lionsgate Films" Value="Lionsgate Films" />
                               <asp:ListItem Text="The Weinstein Company" Value="The Weinstein Company" />
                               <asp:ListItem Text="Yash Raj Films" Value="Yash Raj Films" />
                               <asp:ListItem Text="UTV Motion Pictures Ltd" Value="UTV Motion Pictures Ltd" />
                               <asp:ListItem Text="Eros International" Value="Eros International" />
                               <asp:ListItem Text="Dharma Productions" Value="Dharma Productions" />
                               <asp:ListItem Text="Red Chillies Entertainment" Value="Red Chillies Entertainment" />
                               <asp:ListItem Text="Bhansali Productions" Value="Bhansali Productions" />
                           </asp:DropDownList>
                        </div>

                        <label>Run Time(in minutes)</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tbRunTime" runat="server" placeholder="ex: 120"></asp:TextBox>
                        </div>

                     </div>
                     <div class="col-md-4">
                        <label>Category</label>
                        <div class="form-group">
                           <asp:DropDownList class="form-control" ID="ddlCategory" runat="server">
                              <asp:ListItem Text="Hollywood" Value="Hollywood" />
                              <asp:ListItem Text="Bollywood" Value="Bollywood" />
                               <asp:ListItem Text="Tollywood" Value="Tollywood" />
                               <asp:ListItem Text="Kolywood" Value="Kolywood" />
                               <asp:ListItem Text="Dhalywood" Value="Dhalywood" />
                           </asp:DropDownList>
                        </div>
                        <label>Release Year</label>
                        <div class="form-group">
                           <!--<asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Date" TextMode="Date"></asp:TextBox>-->
                            <asp:DropDownList class="form-control" ID="ddlReleaseYear" runat="server">
                                <asp:ListItem Text="2020" Value="2020" />
                                <asp:ListItem Text="2019" Value="2019" />
                                <asp:ListItem Text="2018" Value="2018" />
                                <asp:ListItem Text="2017" Value="2017" />
                                <asp:ListItem Text="2016" Value="2016" />
                                <asp:ListItem Text="2015" Value="2015" />
                                <asp:ListItem Text="2014" Value="2014" />
                                <asp:ListItem Text="2013" Value="2013" />
                                <asp:ListItem Text="2012" Value="2012" />
                                <asp:ListItem Text="2011" Value="2011" />
                                <asp:ListItem Text="2010" Value="2010" />
                                <asp:ListItem Text="2009" Value="2009" />
                                <asp:ListItem Text="2008" Value="2008" />
                                <asp:ListItem Text="2007" Value="2007" />
                                <asp:ListItem Text="2006" Value="2006" />
                                <asp:ListItem Text="2005" Value="2005" />
                                <asp:ListItem Text="2004" Value="2004" />
                                <asp:ListItem Text="2003" Value="2003" />
                                <asp:ListItem Text="2002" Value="2002" />
                                <asp:ListItem Text="2001" Value="2001" />
                                <asp:ListItem Text="2000" Value="2000" />
                           </asp:DropDownList>
                        </div>
                         <label>Rating</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tbRating" runat="server" placeholder="ex: 8.5" ></asp:TextBox>
                        </div>

                     </div>
                     <div class="col-md-4">
                        <label>Genre</label>
                        <div class="form-group">
                           <asp:ListBox CssClass="form-control" ID="lbGenre" runat="server" SelectionMode="Multiple" Rows="9">
                              <asp:ListItem Text="Action" Value="1" />
                              <asp:ListItem Text="Adventure" Value="3" />
                              <asp:ListItem Text="Sci-Fi" Value="2" />
                              <asp:ListItem Text="Animation" Value="4" />
                              <asp:ListItem Text="Adult" Value="5" />
                              <asp:ListItem Text="Biography" Value="6" />
                              <asp:ListItem Text="Comedy" Value="7" />
                              <asp:ListItem Text="Crime" Value="8" />
                              <asp:ListItem Text="Document" Value="9" />
                              <asp:ListItem Text="Drama" Value="10" />
                              <asp:ListItem Text="Family" Value="11" />
                              <asp:ListItem Text="Fantasy" Value="12" />
                              <asp:ListItem Text="FlimNoir" Value="13" />
                              <asp:ListItem Text="GameShow" Value="14" />
                              <asp:ListItem Text="History" Value="15" />
                              <asp:ListItem Text="Horror" Value="16" />
                              <asp:ListItem Text="Music" Value="17" />
                              <asp:ListItem Text="Mystery" Value="18" />
                              <asp:ListItem Text="News" Value="19" />
                              <asp:ListItem Text="RealityTV" Value="20" />
                              <asp:ListItem Text="Romance" Value="21" />
                              <asp:ListItem Text="Short" Value="22" />
                              <asp:ListItem Text="Sport" Value="23" />
                              <asp:ListItem Text="Talkshow" Value="24" />
                              <asp:ListItem Text="thriller" Value="25" />
                              <asp:ListItem Text="War" Value="26" />
                              <asp:ListItem Text="Western" Value="27" />
                           </asp:ListBox>
                        </div>
                     </div>
                  </div>
                  
                  <div class="row">
                     <div class="col-md-6">
                        <label>Trailer URL</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tbTrailerURL" runat="server" placeholder="Trailer URL" ></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Embed Trailer URL</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tbEmbedURL" runat="server" placeholder="Embed Trailer URL"></asp:TextBox>
                        </div>
                     </div>
                     
                  </div>
                  <div class="row">
                     <div class="col-12">
                        <label>Movie Description</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tbDescription" runat="server" placeholder="Description" TextMode="MultiLine" Rows="2"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                   <div class="row">
                     <div class="col-12">
                        <label>Story Line</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="tbStoryLine" runat="server" placeholder="StoryLine" TextMode="MultiLine" Rows="2"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-4">
                        <asp:Button ID="btnAdd" class="btn btn-lg btn-block btn-success" runat="server" OnClick="btnAdd_Click" Text="Add"  />
                     </div>
                     <div class="col-4">
                        <asp:Button ID="btnUpdate" class="btn btn-lg btn-block btn-warning" runat="server" OnClick="btnUpdate_Click" Text="Update" />
                     </div>
                     <div class="col-4">
                        <asp:Button ID="btnDelete" class="btn btn-lg btn-block btn-danger" runat="server" OnClick="btnDelete_Click" Text="Delete"  />
                     </div>
                  </div>
               </div>
            </div>
            <!--<a href="Default.aspx"><< Back to Home</a><br>-->
            <br>
         </div>
         
      </div>
   </div>
    <!--This is Second para -->
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-12">
                <div class="card">
                    <div class="card-body">
                        <!--This is first row of Cast Name,Cast Nationality -->
                        <div class="row">
                            <div class="col-md-6">
                                <label>Cast Name</label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="tbNewCastName" runat="server" placeholder="Cast Name"></asp:TextBox>
                                    </div>
                            </div>
                            <div class="col-md-6">
                                <label>Cast Nationality</label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="ddlNationality" runat="server">
                                        <asp:ListItem Text="English" Value="English" />
                                        <asp:ListItem Text="American" Value="American" />
                                        <asp:ListItem Text="Indian" Value="Indian" />
                                        <asp:ListItem Text="French" Value="French" />
                                        <asp:ListItem Text="Spanish" Value="Spanish" />
                                        <asp:ListItem Text="Swidish" Value="Swidish" />
                                        <asp:ListItem Text="Mexican" Value="Mexican" />
                                        <asp:ListItem Text="Australian" Value="Australian" />
                                        <asp:ListItem Text="Denmark" Value ="Denmark" />
                                        <asp:ListItem Text="Canadian" Value="Canadian" />
                                        <asp:ListItem Text="Colombian" Value="Colombian" />
                                        <asp:ListItem Text="Korean" Value="Korean" />
                                        <asp:ListItem Text="Chinese" Value="Chinese" />
                                        <asp:ListItem Text="Turkish" Value="Turkish" />
                                        <asp:ListItem Text="Bangladeshi" Value="Bangladeshi" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <!--End of first row -->
                        <!--This is second row of Age,Gender -->
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="tbCastAge" runat="server" TextMode="Number" placeholder="Age"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="ddlGender" runat="server">
                                        <asp:ListItem Text="Male" Value="Male" />
                                        <asp:ListItem Text="Female" Value="Female" />
                        
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:Button class="form-control btn btn-success" ID="btnAddNewCast" OnClick="btnAddNewCast_Click" runat="server" Text="Add New Cast" />
                                    </div>
                                </div>    
                            </div>
                        </div>
                        <!--End of second row -->
                        
                        
                        
                        <!--This is 3rd row of Director name,Add director button -->
                        <div class="row">
                            <div class="col-md-8">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="tbDirectorName" runat="server" placeholder="Director Name"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                     <asp:Button class="form-control btn btn-success" ID="btnAddNewDirector" OnClick="btnAddNewDirector_Click" runat="server" Text="Add New Director" />
                                </div>
                            </div>
                        </div>
                        <!--End of 3rd row-->
                        </br>
                        <!--This is 4th row of Movie ID,Movie Name -->
                        <div class="row">
                             <div class="col-md-4">
                                
                                    <div class="form-group">
                                       <div class="input-group">
                                          <asp:TextBox CssClass="form-control" ID="tbMovieID" runat="server" placeholder="Movie ID"></asp:TextBox>
                                          <asp:Button class="form-control btn btn-primary" ID="btnSearchMovieName" OnClick="btnSearchMovieName_Click" runat="server" Text="Go" />
                                       </div>
                                    </div>
                             </div>
                             <div class="col-md-8">
                                
                                <div class="form-group">
                                   <asp:TextBox CssClass="form-control" Enabled="false" ID="tbShowMovieName" runat="server" placeholder="Movie Name"></asp:TextBox>
                                </div>
                             </div>
                        </div>
                        <!--End of 4th row -->
                        <!--This is 5th row of Cast Search,Search Result, ADD Cast button -->
                        <div class="row">
                             <div class="col-md-4">
                                
                                    <div class="form-group">
                                       <div class="input-group">
                                           <div class="row">
                                           <div class="col-md-8">
                                               <asp:TextBox CssClass="form-control" ID="tbCastNameSearch" runat="server" placeholder="Cast Name"></asp:TextBox>
                                           </div>
                                          <div class="col-md-4">
                                              <asp:Button class="form-control btn btn-primary" ID="btnSearchCastName" OnClick="btnSearchCastName_Click" runat="server" Text="Search" />
                                          </div>
                                          </div>
                                       </div>
                                    </div>
                             </div>
                             <div class="col-md-4">
                                <div class="form-group">
                                   <asp:TextBox CssClass="form-control" Enabled="false" ID="tbCastRoleName" runat="server" placeholder="Role Name"></asp:TextBox>
                                </div>
                             </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:Button class="form-control btn btn-success" ID="btnAddCastIntoMovie" OnClick="btnAddCastIntoMovie_Click"  runat="server" Text="Add Cast" />
                                    </div>
                                </div>    
                            </div>
                        </div>
                        <!--End of 5th row -->
                        <!--This is 6th row of Director Search,Search Result, ADD Director button -->
                        <div class="row">
                             <div class="col-md-4">
                                
                                    <div class="form-group">
                                       <div class="input-group">
                                           <div class="row">
                                           <div class="col-md-8">
                                               <asp:TextBox CssClass="form-control" ID="tbSearchDirectorName" runat="server" placeholder="Director Name"></asp:TextBox>
                                           </div>
                                          <div class="col-md-4">
                                              <asp:Button class="form-control btn btn-primary" ID="btnDirectorSearch" OnClick="btnDirectorSearch_Click" runat="server" Text="Search" />
                                          </div>
                                          </div>
                                       </div>
                                    </div>
                             </div>
                             <div class="col-md-4">
                                <div class="form-group">
                                   <asp:TextBox CssClass="form-control" Enabled="false" ID="tbDirectorSearchResult" runat="server" placeholder="Search Result"></asp:TextBox>
                                </div>
                             </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:Button class="form-control btn btn-success" ID="btnAddDirectorIntoMovie" OnClick="btnAddDirectorIntoMovie_Click" runat="server" Text="Add Director" />
                                    </div>
                                </div>    
                            </div>
                        </div>
                        <!--End of 6th row -->
                    </div>
                </div>
            </div>
        
        </div>
    </div>
    <!--End of second para -->
    <!--End of Movie Entry Form Section -->

            </div>
            <!--End of 1st Item : Movie Entry Form-->
            <!--2nd Item : Movie Info Specification-->
            <div class="tab-pane fade" id="pills-movieInfo" role="tabpanel" aria-labelledby="pills-movieInfo-tab">
                <!-- ALL Movie Info Here-->
                <div class="col-md-12">
                    <div class="card">
                       <div class="card-body">
                          <div class="row">
                             <div class="col">
                                <center>
                                   <h4 class="font-bold">Movie List</h4>
                                </center>
                             </div>
                          </div>
                          <div class="row">
                             <div class="col">
                                <hr>
                             </div>
                          </div>
                           <!--Movie info search area -->
                           <div class="row">
                                   <div class="col-md-6">
                                       <div class="form-group">
                                            <div class="input-group">
                                                
                                                    <div class="col-md-8">
                                                        <asp:TextBox CssClass="form-control" ID="tbMovieInfoSearch" runat="server" placeholder="Search key"></asp:TextBox>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <asp:Button class="form-control btn btn-primary" ID="btnMovieInfoSearch" OnClick="btnMovieInfoSearch_Click"  runat="server" Text="Search" />
                                                    </div>
                                                
                                            </div>
                                         </div>
                                   </div>
                                   
                           </div>
                           <!--End of Movie info search area -->
                          <div class="row">

                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MovieHouseConnectionString %>" SelectCommand="SELECT Movies.Mid, Movies.Name, Movies.Category, Movies.ReleaseYear, Movies.Description, Movies.NoOfView, Movies.Ratings, Movies.PosterURL, Movies.Language, Movies.Runtime, Movies.StudioName, Movies.NoOfReview from Movies order by Mid desc">
                                
                            </asp:SqlDataSource>

                            <br />
                            <div class="col">

    
                                <asp:GridView ID="GridView1" Class="table table-striped table-bordered" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <div class="container-fluid">
                                                    <div class="row">
                                                        <div class="col-lg-10">
                                                            <!--1st Line: Movie Name -->
                                                            <div class="row">
                                                                <div class="col-12">
                                        
                                                                    <asp:Label ID="MovieName" Font-Bold="True" Font-Size="X-Large" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                                                </div>
                                                            </div>
                                                            <!--2nd Line: Description -->
                                                            <div class="row">
                                                                <div class="col-12">

                                                                    Description:
                                                                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Text='<%# Eval("Description") %>'></asp:Label>

                                                                </div>
                                                            </div>
                                                            <!--3rd Line: Category	ReleaseYear	Ratings	Language -->
                                                            <div class="row">
                                                                <div class="col-12">
                                                                    ID: 
                                                                    <asp:Label ID="Mid" runat="server" Font-Bold="true" Text='<%# Eval("Mid") %>'></asp:Label>
                                                                    &nbsp;| Category:
                                                                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Text='<%# Eval("Category") %>'></asp:Label>
                                                                    &nbsp;| Release Year:
                                                                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Text='<%# Eval("ReleaseYear") %>'></asp:Label>
                                                                    &nbsp;| Rating:
                                                                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Text='<%# Eval("Ratings") %>'></asp:Label>
                                                                    &nbsp;| Language:
                                                                    <asp:Label ID="Label15" runat="server" Font-Bold="true" Text='<%# Eval("Language") %>'></asp:Label>
                                                                </div>
                                                            </div>
                                                            <!--4th Line: NoofView	NoofReview	Watched Date -->
                                                            <div class="row">
                                                                <div class="col-12">
                                                                    Studio Name:
                                                                    <asp:Label ID="Label12" runat="server" Font-Bold="true" Text='<%# Eval("StudioName") %>'></asp:Label>
                                                                    &nbsp;| RunTime:
                                                                    <asp:Label ID="Label11" runat="server" Font-Bold="true" Text='<%# Eval("Runtime") %>'></asp:Label> minutes
                                                                    &nbsp;| No of View:
                                                                    <asp:Label ID="Label5" runat="server" Font-Bold="True" Text='<%# Eval("NoOfView") %>'></asp:Label>
                                                                    &nbsp;| No of Review:
                                                                    <asp:Label ID="Label6" runat="server" Font-Bold="True" Text='<%# Eval("NoOfReview") %>'></asp:Label>
                                                                    

                                                                </div>
                                                            </div>
                                                            <!--5th Line: Button -->
                                                            <div class="row">
                                                                <div class="col-12">


                                        
                                                                    <!--<asp:HyperLink runat="server" NavigateUrl="#15">HyperLink</asp:HyperLink>-->
                                                                    <asp:LinkButton id="lbtnCustomerName" 
                                                                         CommandArgument='<%#Eval("Mid")%>'
                                                                         CommandName="Mid"
                                                                         OnCommand="LinkButton_Command"
                                                                         Visible="true" runat="server">View Details
                                             
                                                                    </asp:LinkButton>


                                                                </div>
                                                            </div>

                                                        </div>
                                                        <div class="col-lg-2">
                                                            <asp:Image ID="Image1" CssClass="img-fluid p-2" runat="server" ImageUrl='<%# Eval("PosterURL") %>' />

                                                        </div>

                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            </div>
            <!--End of 2nd Item : Movie Info -->
            <!--3rd Item : Cast Info  Specification-->
            <div class="tab-pane fade" id="pills-castInfo" role="tabpanel" aria-labelledby="pills-castInfo-tab">
                <div class="col-md-12">
                    <div class="card">
                       <div class="card-body">
                          <div class="row">
                             <div class="col">
                                <center>
                                   <h4 class="font-bold">Cast List</h4>
                                </center>
                             </div>
                          </div>
                          <div class="row">
                             <div class="col">
                                <hr>
                             </div>
                          </div>
                           <!--Cast info search area -->
                           <div class="row">
                                   <div class="col-md-6">
                                       <div class="form-group">
                                            <div class="input-group">
                                                
                                                    <div class="col-md-8">
                                                        <asp:TextBox CssClass="form-control" ID="tbCastInfoSerachKey" runat="server" placeholder="Search key"></asp:TextBox>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <asp:Button class="form-control btn btn-primary" ID="btnCastInfoSearch" OnClick="btnCastInfoSearch_Click"  runat="server" Text="Search" />
                                                    </div>
                                                
                                            </div>
                                         </div>
                                   </div>
                                   
                           </div>
                           <!--End of Cast info search area -->
                          <div class="row">

                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:MovieHouseConnectionString %>" SelectCommand="Select Cast.Cid,Cast.Name,Cast.Nationality,Cast.Gender,Cast.Age from Cast order by Cast.Name">
                                
                            </asp:SqlDataSource>

                            <br />
                            <div class="col">

    
                                <asp:GridView ID="GridView2" Class="table table-striped table-bordered" runat="server" DataSourceID="SqlDataSource2" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <div class="container-fluid">
                                                    <div class="row">
                                                        <div class="col-lg-12">
                                                            <!--1st Line: Actor/Actress Name -->
                                                            <div class="row">
                                                                <div class="col-12">
                                        
                                                                    <asp:Label ID="ActorName" Font-Bold="True" Font-Size="X-Large" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                                                </div>
                                                            </div>
                                                            
                                                            <!--2nd Line: ID, Gender,Nationality,Age	 -->
                                                            <div class="row">
                                                                <div class="col-12">
                                                                    ID: 
                                                                    <asp:Label ID="CastCid" runat="server" Font-Bold="true" Text='<%# Eval("Cid") %>'></asp:Label>
                                                                    &nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp; Gender:
                                                                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Text='<%# Eval("Gender") %>'></asp:Label>
                                                                    &nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp; Nationality:
                                                                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Text='<%# Eval("Nationality").ToString() == "" ? "N/A" : Eval("Nationality") %>'></asp:Label>
                                                                    &nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp; Age:
                                                                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Text='<%# Eval("Age").ToString() == "" ? "N/A" : Eval("Age") %>'></asp:Label>

                                                                </div>
                                                            </div>
                                                            

                                                        </div>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            </div>
            <!--End of 3rd Item : Cast Info -->
            <!--4th Item : Directors  Specification-->
            <div class="tab-pane fade" id="pills-directors" role="tabpanel" aria-labelledby="pills-directors-tab">
                <div class="col-md-12">
                    <div class="card">
                       <div class="card-body">
                          <div class="row">
                             <div class="col">
                                <center>
                                   <h4 class="font-bold">Directors</h4>
                                </center>
                             </div>
                          </div>
                          <div class="row">
                             <div class="col">
                                <hr>
                             </div>
                          </div>
                          <div class="row">

                            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:MovieHouseConnectionString %>" SelectCommand="Select * from Directors">
                                
                            </asp:SqlDataSource>

                            <br />
                            <div class="col">

    
                                <asp:GridView ID="GridView3" Class="table table-striped table-bordered" runat="server" DataSourceID="SqlDataSource3" AutoGenerateColumns="true">
                                    
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            </div>
            <!--End of 3rd Item : Directors -->
            <!--5th Item :Users  Specification-->
            <div class="tab-pane fade" id="pills-users" role="tabpanel" aria-labelledby="pills-users-tab">
                <div class="col-md-12">
                    <div class="card">
                       <div class="card-body">
                          <div class="row">
                             <div class="col">
                                <center>
                                   <h4 class="font-bold">User Details</h4>
                                </center>
                             </div>
                          </div>
                          <div class="row">
                             <div class="col">
                                <hr>
                             </div>
                          </div>
                          <div class="row">

                            <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:MovieHouseConnectionString %>" SelectCommand="Select * from [User]">
                                
                            </asp:SqlDataSource>

                            <br />
                            <div class="col">

    
                                <asp:GridView ID="GridView4" Class="table table-striped table-bordered" OnRowCommand="GridView4_OnRowCommand" runat="server" DataSourceID="SqlDataSource5" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <div class="container-fluid">
                                                    <div class="row">
                                                        <div class="col-lg-10">
                                                            <!--1st Line: User Full Name -->
                                                            <div class="row">
                                                                <div class="col-12">
                                        
                                                                    <asp:Label ID="UserName" Font-Bold="True" Font-Size="X-Large" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                                                </div>
                                                            </div>
                                                            <!--2nd Line: Id,Status,Email -->
                                                            <div class="row">
                                                                <div class="col-12">

                                                                    ID: 
                                                                    <asp:Label ID="Label7" runat="server" Font-Bold="true" Text='<%# Eval("Uid") %>'></asp:Label>
                                                                    &nbsp;| Status:
                                                                    <asp:Label ID="Label8" runat="server" Font-Bold="True" Text='<%# Eval("Status") %>'></asp:Label>
                                                                    &nbsp;| Email:
                                                                    <asp:Label ID="Label9" runat="server" Font-Bold="True" Text='<%# Eval("Email") %>'></asp:Label>

                                                                </div>
                                                            </div>
                                                            <!--3rd Line: Gender,Phone,Account Creation Date-->
                                                            <div class="row">
                                                                <div class="col-12">
                                                                    Gender: 
                                                                    <asp:Label ID="Mid" runat="server" Font-Bold="true" Text='<%# Eval("Gender") %>'></asp:Label>
                                                                    &nbsp;| Phone:
                                                                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Text='<%# Eval("Phone") %>'></asp:Label>
                                                                    &nbsp;| Account Created:
                                                                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Text='<%# Eval("CreationDate") %>'></asp:Label>
                                                                    

                                                                </div>
                                                            </div>
                                                            <!--4th Line:Total Movie Watched, Total Run time, Password-->
                                                            <div class="row">
                                                                <div class="col-12">

                                                                    Total Movie Watched:
                                                                    <asp:Label ID="Label5" runat="server" Font-Bold="True" Text='<%# Eval("NoOfWatch") %>'></asp:Label>
                                                                    &nbsp;| Total Run Time:
                                                                    <asp:Label ID="Label6" runat="server" Font-Bold="True" Text='<%# Eval("RunTimeWatch") %>'></asp:Label> minutes
                                                                    &nbsp;| Password:
                                                                    <asp:Label ID="Label10" runat="server" Font-Bold="True" Text='<%# Eval("Password") %>'></asp:Label>
                                                                    

                                                                </div>
                                                            </div>
                                                            <!--5th Line: Button -->
                                                            <div class="row">
                                                                <div class="col-12">

                                                                    Change Status:
                                                                        <asp:Button ID="Active" runat="server" CssClass="btn btn-success mt-1" CommandName="ActiveStatus" Text="Active" CommandArgument='<%# Eval("Uid") %>' />
                                                                        <asp:Button ID="Disable" runat="server" CssClass="btn btn-warning mt-1" CommandName="DisableStatus" Text="Disable" CommandArgument='<%# Eval("Uid") %>' />
                                                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                                                        <asp:Button ID="DeleteAccount" runat="server" CssClass="btn btn-danger ml-5 mt-1" CommandName="DeleteUser" Text="Delete User" CommandArgument='<%# Eval("Uid") %>' />
                                        
                                                                    


                                                                </div>
                                                            </div>

                                                        </div>
                                                        <div class="col-lg-2">
                                                            <asp:Image ID="Image1" CssClass="img-fluid p-2" runat="server" ImageUrl='<%# Eval("PhotoURL") %>' />

                                                        </div>

                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            </div>
            <!--End of 5th Item : Users -->


        </div>
        <!--Start of Navigation Drawer Details -->
        </div>
        <!--End of Navigation Drawer Menu -->
</asp:Content>
