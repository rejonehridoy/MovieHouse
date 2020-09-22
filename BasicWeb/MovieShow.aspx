<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MovieShow.aspx.cs" Inherits="BasicWeb.MovieShow" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="section-sm .MovieDetails">
	<div class="container">
		
		<div class="row">
			<div class="col-md-3">
				<div class="category-sidebar">
					<div class="widget category-list">
						<h4 class="widget-header">All Category</h4>
						<ul class="category-list">
                            <% 
                            if (category_count.Count > 0)
                            {
                                foreach (var category in category_count)
                                { %>
							        <li><a href="MovieShow.aspx?Category=<%=category.CategoryName%>"><%=category.CategoryName%> <span><%=category.Count%></span></a></li>
							<%}
                            }
                            else
                            {
                                            %>
                                        <h6>No category Found</h6>
                                        <%} %>    
						</ul>
					</div>

					<div class="widget category-list">
						<h4 class="widget-header">Popular Genre</h4>
						<ul class="category-list">
                            <% 
                            if (movie_genre.Count > 0)
                            {
                                foreach (var genre in movie_genre)
                                { %>

							<li><a href="MovieShow.aspx?Gid=<%=genre.Gid%>"><%=genre.Name%> <span><%=genre.MovieCount%></span></a></li>
							
                            <%}
                            }
                            else
                            {
                                    %>
                                <h6>No genre Found</h6>
                                <%} %>
                            
						</ul>
					</div>

					<div class="widget filter">
						<h4 class="widget-header">Release Year</h4>
                        <asp:DropDownList ID="releaseYearList" AutoPostBack = "true" OnSelectedIndexChanged="releaseYearList_SelectedIndexChanged" runat="server" Height="30px" Width="170px">
                            
                        </asp:DropDownList>
					</div>
					




				</div>
			</div>
			<div class="col-md-9">
				<div class="category-search-filter">
					<div class="row">
						<div class="col-md-6">
							<strong>Sort</strong>
							
                            <br />
                            <asp:DropDownList ID="SortList" CssClass="form-control" AutoPostBack = "true" runat="server">
                                <asp:ListItem>Most Recent</asp:ListItem>
                                <asp:ListItem>Most Popular</asp:ListItem>
                                <asp:ListItem>Most Viewed</asp:ListItem>
                                <asp:ListItem>Suggested For you</asp:ListItem>
                            </asp:DropDownList>
						</div>
						<!--<div class="col-md-6">
							<div class="view">
								<strong>Views</strong>
								<ul class="list-inline view-switcher">
									<li class="list-inline-item">
										<a href="category.html"><i class="fa fa-th-large"></i></a>
									</li>
									<li class="list-inline-item">
										<a href="category.html" class="text-info"><i class="fa fa-reorder"></i></a>
									</li>
								</ul>
							</div>
						</div>-->
					</div>
				</div>
				<div class="product-grid-list">
					<div class="row mt-30">
                        <% 
                            if (movie_info.Count > 0)
                            {
                                for (var movie= 0; movie < movie_info.Count; movie++)
                                { %>

						<div class="col-sm-12 col-lg-4 col-md-6">
							<!-- product card -->
							<div class="product-item bg-light">
								<div class="card">
									<div class="thumb-content">
										<!-- <div class="price">$200</div> -->
										<a href="MovieDetails.aspx?Mid=<%=movie_info[movie].Mid%>">
											<img class="card-img-top img-fluid" src="<%=movie_info[movie].PosterURL%>" alt="Card image cap">
										</a>
									</div>
									<div class="card-body">
										<h4 class="card-title"><a href="MovieDetails.aspx?Mid=<%=movie_info[movie].Mid%>"><%=movie_info[movie].Name%></a></h4>
										<ul class="list-inline product-meta">
											<li class="list-inline-item">
												<a href=""><%=movie_info[movie].Category%></a>
											</li>
											<li class="list-inline-item">
												<a href="#">Rating: <%=movie_info[movie].Ratings%></a>
											</li>
										</ul>
										<p class="card-text"><%=movie_info_genre[movie]%></p>
										<p class="">Release Year: <%=movie_info[movie].ReleaseYear%></p>
										
										
										
										<!--<div class="product-ratings">
											<ul class="list-inline">
												<li class="list-inline-item selected"><i class="fa fa-star"></i></li>
												<li class="list-inline-item selected"><i class="fa fa-star"></i></li>
												<li class="list-inline-item selected"><i class="fa fa-star"></i></li>
												<li class="list-inline-item selected"><i class="fa fa-star"></i></li>
												<li class="list-inline-item"><i class="fa fa-star"></i></li>
											</ul>
										</div>-->
									</div>
								</div>
							</div>
						</div>
						
                        <%}
                            }
                            else
                            {
                                            %>
                                        <center><h3>No Movies Found</h3></center>
                                        <%} %> 
	
						
					</div>
				</div>
				<!--<div class="pagination justify-content-center">
					<nav aria-label="Page navigation example">
						<ul class="pagination">
							<li class="page-item">
								<a class="page-link" href="#" aria-label="Previous">
									<span aria-hidden="true">&laquo;</span>
									<span class="sr-only">Previous</span>
								</a>
							</li>
							<li class="page-item"><a class="page-link" href="#">1</a></li>
							<li class="page-item active"><a class="page-link" href="#">2</a></li>
							<li class="page-item"><a class="page-link" href="#">3</a></li>
							<li class="page-item">
								<a class="page-link" href="#" aria-label="Next">
									<span aria-hidden="true">&raquo;</span>
									<span class="sr-only">Next</span>
								</a>
							</li>
						</ul>
					</nav>
				</div>-->
			</div>
		</div>
	</div>
</section>
</asp:Content>
