<%@ Page Title="Profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="BasicWeb.Profile" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
       $(document).ready(function () {
           $("#GridView1").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
       });
 
   </script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container emp-profile">
            <div>
                <div class="row">
                    <div class="col-md-4">
                        <div class="profile-img">
                            <img src="<%=photourl%>" alt=""/>
                            
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="profile-head">
                                    <h4>
                                        <%=name%>
                                    </h4>
                                    <h6>
                                        User
                                    </h6>
                                    <p class="proile-rating">Account Created : <span><%=createdDate%></span></p>
                            <ul class="nav nav-tabs" id="myTab" role="tablist">
                                <li class="nav-item">
                                    <a class="nav-link active" id="home-tab" data-toggle="tab" href="#home" role="tab" aria-controls="home" aria-selected="true">About</a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" id="profile-tab" data-toggle="tab" href="#profile" role="tab" aria-controls="profile" aria-selected="false">Timeline</a>
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <!--<input type="submit" class="profile-edit-btn" name="btnAddMore" value="Edit Profile"/>-->
                        <a href="EditProfile.aspx" class="profile-edit-btn">Edit Profile</a>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4">
                        <div class="profile-work">
                            <p>Type of Movies Watched</p>

                            <% 
                            if (user_typeList.Count > 0)
                            {
                                foreach (var type in user_typeList)
                                { %>
                                    <a href="#"><%=type%></a><br/>
                            <%}
                            }
                            else
                            {
                                            %>
                                        <h6>No type Available</h6>
                                        <%} %>



                            <!--<p>SKILLS</p>
                            <a href="#">Web Designer</a><br/>
                            <a href="#">Web Developer</a><br/>
                            <a href="#">WordPress</a><br/>
                            <a href="#">WooCommerce</a><br/>
                            <a href="#">PHP, .Net</a><br/>-->
                        </div>
                    </div>
                    <div class="col-md-8">
                        <div class="tab-content profile-tab" id="myTabContent">
                            <div class="tab-pane fade show active" id="home" role="tabpanel" aria-labelledby="home-tab">
                                        <div class="row">
                                            <div class="col-md-6">
                                                <label>Account Status</label>
                                            </div>
                                            <div class="col-md-6">
                                                <p><%=status%></p>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <label>Name</label>
                                            </div>
                                            <div class="col-md-6">
                                                <p><%=name%></p>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <label>Email</label>
                                            </div>
                                            <div class="col-md-6">
                                                <p><%=email%></p>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <label>Gender</label>
                                            </div>
                                            <div class="col-md-6">
                                                <p><%=gender%></p>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <label>Phone</label>
                                            </div>
                                            <div class="col-md-6">
                                                <p><%=phone%></p>
                                            </div>
                                        </div>
                            </div>
                            <div class="tab-pane fade" id="profile" role="tabpanel" aria-labelledby="profile-tab">
                                        <div class="row">
                                            <div class="col-md-6">
                                                <label>Movies Watched</label>
                                            </div>
                                            <div class="col-md-6">
                                                <p><%=noOfMovies%></p>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <label>No of Hours</label>
                                            </div>
                                            <div class="col-md-6">
                                                <p><%=noOfHours%></p>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <label>Movies in Watchlist</label>
                                            </div>
                                            <div class="col-md-6">
                                                <p><%=noOfwatchList%></p>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <label>No of Reviews</label>
                                            </div>
                                            <div class="col-md-6">
                                                <p><%=noOfReviews%></p>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <label>Friend Suggestion</label>
                                            </div>
                                            <div class="col-md-6">
                                                <p><%=noOfFriendSuggestion%></p>
                                            </div>
                                        </div>
                                <!--<div class="row">
                                    <div class="col-md-12">
                                        <label>Your Bio</label><br/>
                                        <p>Your detail description</p>
                                    </div>
                                </div>-->
                            </div>
                        </div>
                    </div>
                    
                </div>
            </div>           
        </div>

    <!-- Three Table Show Here -->
    <div class="content mt-5 pt-5">
		<ul class="nav nav-pills  justify-content-center" id="pills-tab" role="tablist">
			<li class="nav-item">
				<a class="nav-link <%=navDrawerHeader[1] %>" id="pills-description-tab" data-toggle="pill" href="#pills-description" role="tab" aria-controls="pills-description"
					aria-selected="true">Watch List</a>
			</li>
						
			<li class="nav-item">
				<a class="nav-link <%=navDrawerHeader[2] %>" id="pills-info-tab" data-toggle="pill" href="#pills-info" role="tab" aria-controls="pills-info"
					aria-selected="false">Friend Suggesstion</a>
			</li>
			<li class="nav-item">
				<a class="nav-link <%=navDrawerHeader[3] %>" id="pills-cast-tab" data-toggle="pill" href="#pills-cast" role="tab" aria-controls="pills-cast"
					aria-selected="false">Already Watched</a>
			</li>
            <li class="nav-item">
				<a class="nav-link <%=navDrawerHeader[4] %>" id="pills-myReviews-tab" data-toggle="pill" href="#pills-myReviews" role="tab" aria-controls="pills-myReviews"
					aria-selected="false">My Reviews</a>
			</li>


							
		</ul>
		<div class="tab-content" id="pills-tabContent">

			<div class="tab-pane fade <%=navDrawerDetails[1] %>" id="pills-description" role="tabpanel" aria-labelledby="pills-description-tab">
							
                <!-- Watch List GridView Here-->
                <div class="col-md-12">
                    <div class="card">
                       <div class="card-body">
                          <div class="row">
                             <div class="col">
                                <center>
                                   <h4 class="font-bold">Watch List</h4>
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
                                                        <asp:TextBox CssClass="form-control" ID="tbWatchListSearch" runat="server" placeholder="Search key"></asp:TextBox>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <asp:Button class="form-control btn btn-primary" ID="btnWatchListSearch" OnClick="btnWatchListSearch_Click" runat="server" Text="Search" />
                                                    </div>
                                                
                                             </div>
                                         </div>
                                   </div>
                                 </div>
                                <!--End of Movie info search area -->

                          <div class="row">

                            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:MovieHouseConnectionString %>" SelectCommand="SELECT Movies.Mid, Movies.Name, Movies.Category, Movies.ReleaseYear,Movies.Runtime, Movies.Description, Movies.NoOfView, Movies.Ratings, Movies.PosterURL, Movies.NoOfReview, CONVERT(varchar,Queue.Date,105) as Date FROM Movies INNER JOIN Queue ON Movies.Mid = Queue.Mid WHERE (Queue.Uid = @Uid) order by CONVERT(DateTime, Queue.Date,105) DESC ">
                                <SelectParameters>
                                    <asp:SessionParameter Name="Uid" SessionField="id" />
                                </SelectParameters>
                            </asp:SqlDataSource>

                            <br />
                            <div class="col">

    
                                <asp:GridView ID="GridView3" Class="table table-striped table-bordered" runat="server" DataSourceID="SqlDataSource3" AutoGenerateColumns="False">
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
                                                            <!--3rd Line: Category	ReleaseYear	Ratings	 -->
                                                            <div class="row">
                                                                <div class="col-12">

                                                                    Category:
                                                                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Text='<%# Eval("Category") %>'></asp:Label>
                                                                    &nbsp;| Release Year:
                                                                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Text='<%# Eval("ReleaseYear") %>'></asp:Label>
                                                                    &nbsp;| Rating:
                                                                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Text='<%# Eval("Ratings") %>'></asp:Label>
                                                                    &nbsp;| Runtime:
                                                                    <asp:Label ID="Label9" runat="server" Font-Bold="True" Text='<%# Eval("Runtime") %>'></asp:Label> minutes

                                                                </div>
                                                            </div>
                                                            <!--4th Line: NoofView	NoofReview	Watched Date -->
                                                            <div class="row">
                                                                <div class="col-12">

                                                                    No of View:
                                                                    <asp:Label ID="Label5" runat="server" Font-Bold="True" Text='<%# Eval("NoOfView") %>'></asp:Label>
                                                                    &nbsp;| No of Review:
                                                                    <asp:Label ID="Label6" runat="server" Font-Bold="True" Text='<%# Eval("NoOfReview") %>'></asp:Label>
                                                                    &nbsp;| Added Date:
                                                                    <asp:Label ID="Label7" runat="server" Font-Bold="True" Text='<%# Eval("Date") %>'></asp:Label>

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


                                                                    ||&nbsp;
                                                                    <asp:LinkButton ID="LinkButton1" runat="server"
                                                                        CommandArgument='<%#Eval("Mid")%>'
                                                                        CommandName="Mid"
                                                                        onCommand="LinkButton1_Command"
                                                                        Visible ="true"
                                                                        >Remove

                                                                    </asp:LinkButton>
                                                                    &nbsp;||
                                                                    <asp:LinkButton ID="LinkButton2" runat="server"
                                                                        CommandArgument='<%#Eval("Mid")%>'
                                                                        CommandName="Mid"
                                                                        onCommand="LinkButton2_Command"
                                                                        Visible="true"
                                                                        >Mark as Watched

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
			<div class="tab-pane fade <%=navDrawerDetails[2] %>" id="pills-info" role="tabpanel" aria-labelledby="pills-info-tab">
			
				<!-- Watch List Friend Suggestion Here-->
                <div class="col-md-12">
                    <div class="card">
                       <div class="card-body">
                          <div class="row">
                             <div class="col">
                                <center>
                                   <h4 class="font-bold">Friend Suggestion</h4>
                                </center>
                             </div>
                          </div>
                          <div class="row">
                             <div class="col">
                                <hr>
                             </div>
                          </div>

                            <!--Friend Suggestion search area -->
                              <div class="row">
                                   <div class="col-md-6">
                                       <div class="form-group">
                                            <div class="input-group">
                                                
                                                    <div class="col-md-8">
                                                        <asp:TextBox CssClass="form-control" ID="tbFriendSuggestionSearch" runat="server" placeholder="Search key"></asp:TextBox>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <asp:Button class="form-control btn btn-primary" ID="btnFriendSuggestionSearch" OnClick="btnFriendSuggestionSearch_Click" runat="server" Text="Search" />
                                                    </div>
                                                
                                             </div>
                                         </div>
                                   </div>
                                 </div>
                                <!--End of Friend Suggestion search area -->

                          <div class="row">

                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:MovieHouseConnectionString %>" SelectCommand="SELECT Movies.Mid, Movies.Name, Movies.Category, Movies.ReleaseYear, Movies.Description, Movies.NoOfView, Movies.Ratings, Movies.PosterURL, Movies.NoOfReview, FriendSuggestion.Fid ,CONVERT(varchar,FriendSuggestion.Date,105) as Date ,[User].Name as FriendName FROM Movies INNER JOIN FriendSuggestion ON Movies.Mid = FriendSuggestion.Mid inner join [User] on [User].Uid = FriendSuggestion.Sender WHERE (FriendSuggestion.Receiver = @Uid) order by CONVERT(DateTime, FriendSuggestion.Date,105) DESC">
                                <SelectParameters>
                                    <asp:SessionParameter Name="Uid" SessionField="id" />
                                </SelectParameters>
                            </asp:SqlDataSource>

                            <br />
                            <div class="col">

    
                                <asp:GridView ID="GridView2" Class="table table-striped table-bordered" runat="server" DataSourceID="SqlDataSource2" AutoGenerateColumns="False">
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
                                                            <!--3rd Line: Category	ReleaseYear	Ratings	 -->
                                                            <div class="row">
                                                                <div class="col-12">

                                                                    Category:
                                                                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Text='<%# Eval("Category") %>'></asp:Label>
                                                                    &nbsp;| Release Year:
                                                                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Text='<%# Eval("ReleaseYear") %>'></asp:Label>
                                                                    &nbsp;| Rating:
                                                                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Text='<%# Eval("Ratings") %>'></asp:Label>
                                                                    &nbsp;| Suggested By:
                                                                    <asp:Label ID="Label8" runat="server" Font-Bold="True" Text='<%# Eval("FriendName") %>'></asp:Label>

                                                                </div>
                                                            </div>
                                                            <!--4th Line: NoofView	NoofReview	Watched Date -->
                                                            <div class="row">
                                                                <div class="col-12">

                                                                    No of View:
                                                                    <asp:Label ID="Label5" runat="server" Font-Bold="True" Text='<%# Eval("NoOfView") %>'></asp:Label>
                                                                    &nbsp;| No of Review:
                                                                    <asp:Label ID="Label6" runat="server" Font-Bold="True" Text='<%# Eval("NoOfReview") %>'></asp:Label>
                                                                    &nbsp;| Suggested Date:
                                                                    <asp:Label ID="Label7" runat="server" Font-Bold="True" Text='<%# Eval("Date") %>'></asp:Label>

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

                                                                    ||&nbsp;
                                                                    <asp:LinkButton ID="LinkButton1" runat="server"
                                                                        CommandArgument='<%#Eval("Fid")%>'
                                                                        CommandName="Fid"
                                                                        onCommand="RemoveFromFriendSuggestion_Command"
                                                                        Visible ="true"
                                                                        >Remove

                                                                    </asp:LinkButton>
                                                                    &nbsp;||
                                                                    <asp:LinkButton ID="LinkButton2" runat="server"
                                                                        CommandArgument='<%#Eval("Mid")%>'
                                                                        CommandName="Mid"
                                                                        onCommand="MarkAsWatchedFromFriendSuggestion_Command"
                                                                        Visible="true"
                                                                        >Mark as Watched

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
			<div class="tab-pane fade <%=navDrawerDetails[3] %>" id="pills-cast" role="tabpanel" aria-labelledby="pills-cast-tab">
				
				<!--  Already Watched Here-->
                <div class="col-md-12">
                    <div class="card">
                       <div class="card-body">
                          <div class="row">
                             <div class="col">
                                <center>
                                   <h4 class="font-bold">Already Watched List</h4>
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
                                                        <asp:TextBox CssClass="form-control" ID="tbWatchedMovieInfoSearch" runat="server" placeholder="Search key"></asp:TextBox>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <asp:Button class="form-control btn btn-primary" ID="btnWacthedMovieInfoSearch" OnClick="btnWacthedMovieInfoSearch_Click" runat="server" Text="Search" />
                                                    </div>
                                                
                                             </div>
                                         </div>
                                   </div>
                                 </div>
                                <!--End of Movie info search area -->
                          <div class="row">

                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MovieHouseConnectionString %>" SelectCommand="SELECT Movies.Mid, Movies.Name, Movies.Category, Movies.ReleaseYear, Movies.Description,Movies.Runtime, Movies.NoOfView, Movies.Ratings, Movies.PosterURL, Movies.NoOfReview, CONVERT(varchar,ViewHistory.Date,105) as Date FROM Movies INNER JOIN ViewHistory ON Movies.Mid = ViewHistory.Mid WHERE (ViewHistory.Uid = @Uid) order by CONVERT(DateTime, ViewHistory.Date,105) DESC">
                                <SelectParameters>
                                    <asp:SessionParameter Name="Uid" SessionField="id" />
                                </SelectParameters>
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
                                                            <!--3rd Line: Category	ReleaseYear	Ratings	 -->
                                                            <div class="row">
                                                                <div class="col-12">

                                                                    Category:
                                                                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Text='<%# Eval("Category") %>'></asp:Label>
                                                                    &nbsp;| Release Year:
                                                                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Text='<%# Eval("ReleaseYear") %>'></asp:Label>
                                                                    &nbsp;| Rating:
                                                                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Text='<%# Eval("Ratings") %>'></asp:Label>
                                                                    &nbsp;| Runtime:
                                                                    <asp:Label ID="Label9" runat="server" Font-Bold="True" Text='<%# Eval("Runtime") %>'></asp:Label> minutes
                                                                </div>
                                                            </div>
                                                            <!--4th Line: NoofView	NoofReview	Watched Date -->
                                                            <div class="row">
                                                                <div class="col-12">

                                                                    No of View:
                                                                    <asp:Label ID="Label5" runat="server" Font-Bold="True" Text='<%# Eval("NoOfView") %>'></asp:Label>
                                                                    &nbsp;| No of Review:
                                                                    <asp:Label ID="Label6" runat="server" Font-Bold="True" Text='<%# Eval("NoOfReview") %>'></asp:Label>
                                                                    &nbsp;| Watched Date:
                                                                    <asp:Label ID="Label7" runat="server" Font-Bold="True" Text='<%# Eval("Date") %>'></asp:Label>

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
            <div class="tab-pane fade <%=navDrawerDetails[4] %>" id="pills-myReviews" role="tabpanel" aria-labelledby="pills-myReviews-tab">
                <!-- My Reviews Section -->
                
                <div class="col-md-12">
                    <div class="card">
                       <div class="card-body">
                          <div class="row">
                             <div class="col">
                                <center>
                                   <h4 class="font-bold">Movie Reviews</h4>
                                </center>
                             </div>
                          </div>
                          <div class="row">
                             <div class="col">
                                <hr>
                             </div>
                          </div>

                            <!--My Review search area -->
                              <div class="row">
                                   <div class="col-md-6">
                                       <div class="form-group">
                                            <div class="input-group">
                                                
                                                    <div class="col-md-8">
                                                        <asp:TextBox CssClass="form-control" ID="tbMyReviewSearch" runat="server" placeholder="Search key"></asp:TextBox>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <asp:Button class="form-control btn btn-primary" ID="btnMyReviewSearch" OnClick="btnMyReviewSearch_Click"  runat="server" Text="Search" />
                                                    </div>
                                                
                                             </div>
                                         </div>
                                   </div>
                                 </div>
                                <!--End of My Review search area -->

                          <div class="row">

                            <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:MovieHouseConnectionString %>" SelectCommand="select Review.Rid,Movies.Mid,Movies.Ratings,Movies.Name,Review.Message,Review.Rating as MovieRating , CONVERT(varchar,Review.ReviewDate,105) as ReviewDate,Movies.ReleaseYear from Review inner join Movies on Movies.Mid = Review.Mid where Review.Uid = @Uid order by CONVERT(DateTime, Review.ReviewDate,105) DESC">
                                <SelectParameters>
                                    <asp:SessionParameter Name="Uid" SessionField="id" />
                                </SelectParameters>
                            </asp:SqlDataSource>

                            <br />
                            <div class="col">

    
                                <asp:GridView ID="GridView4" Class="table table-striped table-bordered" runat="server" DataSourceID="SqlDataSource4" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <div class="container-fluid">
                                                    <div class="row">
                                                        <div class="col-lg-12">
                                                            <!--1st Line: Movie Name with Release Year -->
                                                            <div class="row">
                                                                <div class="col-12">
                                        
                                                                    <asp:Label ID="MovieName" Font-Bold="True" Font-Size="X-Large" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                                                    &nbsp;<asp:Label Font-Bold="true" runat="server" Font-Size="X-Large" Text="("></asp:Label>
                                                                    <asp:Label ID="Label10" Font-Bold="True" Font-Size="X-Large" runat="server" Text='<%# Eval("ReleaseYear") %>'></asp:Label>
                                                                    <asp:Label Font-Bold="true" runat="server" Font-Size="X-Large" Text=")"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <!--2nd Line: Personal Rating , Review Date -->
                                                            <div class="row">
                                                                <div class="col-12">

                                                                    Personal Rating: 
                                                                    <asp:Label ID="Personalrating" runat="server" Font-Bold="True" Text='<%# Eval("MovieRating") %>'></asp:Label>
                                                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                                    Review Date: 
                                                                    <asp:Label ID="ReviewDate" runat="server" Font-Bold="True" Text='<%# Eval("ReviewDate") %>'></asp:Label>

                                                                </div>
                                                            </div>
                                                            <!--3rd Line: Review Message	 -->
                                                            <div class="row">
                                                                <div class="col-12">

                                                                    
                                                                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Text='<%# Eval("Message") %>'></asp:Label>
                                                                    

                                                                </div>
                                                            </div>
                                                            
                                                            <!--4th Line: Link Button -->
                                                            <div class="row">
                                                                <div class="col-12">


                                        
                                                                    <!--<asp:HyperLink runat="server" NavigateUrl="#15">HyperLink</asp:HyperLink>-->
                                                                    <asp:LinkButton id="lbtnCustomerName" 
                                                                         CommandArgument='<%#Eval("Mid")%>'
                                                                         CommandName="Mid"
                                                                         OnCommand="MyReviewsViewDetails_Command"
                                                                         Visible="true" runat="server">View Details
                                             
                                                                    </asp:LinkButton>


                                                                    ||&nbsp;
                                                                    <asp:LinkButton ID="LinkButton1" runat="server"
                                                                        CommandArgument='<%#Eval("Rid")%>'
                                                                        CommandName="Rid"
                                                                        onCommand="MyReviewsRemove_Command"
                                                                        Visible ="true"
                                                                        >Remove

                                                                    </asp:LinkButton>
                                                                   


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
                <!-- End of Review Section -->

            </div>
		</div>
	</div>











    <!-- Already Watched List Section -->
    
      
   
</asp:Content>
