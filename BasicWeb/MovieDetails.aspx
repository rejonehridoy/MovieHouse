<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MovieDetails.aspx.cs" Inherits="BasicWeb.MovieDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <!--===================================
=            Store Section            =
====================================-->
<section class="MovieDetails section1 bg-gray">
	<!-- Container Start -->
	<div class="container">
		<div class="row">
			<!-- Left sidebar -->
			<div class="col-md-8">
				<div class="product-details">
					
                    <asp:Label ID="MovieName" runat="server" Text="" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
					<div class="product-meta">
						<ul class="list-inline">
							
							<li class="list-inline-item">Category<a href=""><%=movie_info[0].Category%></a></li>
							<li class="list-inline-item">Genre<a href=""><%=genre%></a></li>
						</ul>
					</div>

					<!-- product slider -->
					<div > <!--class="product-slider"-->
                        <br /><br /><br /><br />
						<div data-image="images/user.png">
							<img class="img-fluid w-100" src="<%=movie_info[0].PhotoURL%>" alt="product-img">
						</div>
						<!--<div class="product-slider-item my-4" data-image="images/products/products-2.jpg">
							<img class="d-block img-fluid w-100" src="images/products/products-2.jpg" alt="Second slide">
						</div>
						<div class="product-slider-item my-4" data-image="images/products/products-3.jpg">
							<img class="d-block img-fluid w-100" src="images/products/products-3.jpg" alt="Third slide">
						</div>
						<div class="product-slider-item my-4" data-image="images/products/products-1.jpg">
							<img class="d-block img-fluid w-100" src="images/products/products-1.jpg" alt="Third slide">
						</div>
						<div class="product-slider-item my-4" data-image="images/products/products-2.jpg">
							<img class="d-block img-fluid w-100" src="images/products/products-2.jpg" alt="Third slide">
						</div>-->
					</div>
					<!-- product slider -->

					<div class="content mt-5 pt-5">
						<ul class="nav nav-pills  justify-content-center" id="pills-tab" role="tablist">
							<li class="nav-item">
								<a class="nav-link active" id="pills-description-tab" data-toggle="pill" href="#pills-description" role="tab" aria-controls="pills-description"
								 aria-selected="true">Description</a>
							</li>
						
							<li class="nav-item">
								<a class="nav-link" id="pills-info-tab" data-toggle="pill" href="#pills-info" role="tab" aria-controls="pills-info"
								 aria-selected="false">Information</a>
							</li>
							<li class="nav-item">
								<a class="nav-link" id="pills-cast-tab" data-toggle="pill" href="#pills-cast" role="tab" aria-controls="pills-cast"
								 aria-selected="false">Cast</a>
							</li>


							<li class="nav-item">
								<a class="nav-link" id="pills-review-tab" data-toggle="pill" href="#pills-review" role="tab" aria-controls="pills-review"
								 aria-selected="false">Reviews</a>
							</li>
						</ul>
						<div class="tab-content" id="pills-tabContent">
							<div class="tab-pane fade show active" id="pills-description" role="tabpanel" aria-labelledby="pills-description-tab">
								<h3 class="tab-title">Description</h3>
								
                                <asp:Label ID="MovieDescription" runat="server" Text="
                                    Lorem ipsum dolor sit amet, consectetur adipisicing elit. Officia laudantium beatae quod perspiciatis, neque
									dolores eos rerum, ipsa iste cum culpa numquam amet provident eveniet pariatur, sunt repellendus quas
									voluptate dolor cumque autem molestias. Ab quod quaerat molestias culpa eius, perferendis facere vitae commodi
									maxime qui numquam ex voluptatem voluptate, fuga sequi, quasi! Accusantium eligendi vitae unde iure officia
									amet molestiae velit assumenda, quidem beatae explicabo dolore laboriosam mollitia quod eos, eaque voluptas
									enim fuga laborum, error provident labore nesciunt ad. Libero reiciendis necessitatibus voluptates ab
									excepturi rem non, nostrum aut aperiam? Itaque, aut. Quas nulla perferendis neque eveniet ullam?

                                " Font-Names="Segoe UI" Font-Size="Large"></asp:Label>
                                <br /><br />
                                <center>

                                    <asp:Label ID="Label3" runat="server" Text="Trailer" Font-Bold="True" Font-Size="X-Large"></asp:Label>
                                </center>
                                <br /><br />
								<iframe width="100%" height="400" src="<%=movie_info[0].EmbedURL%>" frameborder="0" allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>					 

							</div>
							<div class="tab-pane fade" id="pills-info" role="tabpanel" aria-labelledby="pills-info-tab">
								<h3 class="tab-title">Movie Information</h3>
								<table class="table table-bordered product-table">
									<tbody>
										<tr>
											<td>Release Year</td>
											<td><%=movie_info[0].ReleaseYear%></td>
										</tr>
										<tr>
											<td>Run Time</td>
											<td><%=movie_info[0].RunTime%> min</td>
										</tr>
										<tr>
											<td>Studio Name</td>
											<td><%=movie_info[0].StudioName%></td>
										</tr>
										<tr>
											<td>Language</td>
											<td><%=movie_info[0].Language%></td>
										</tr>
										<tr>
											<td>Director</td>
											<td><%=directors%></td>
										</tr>
										<tr>
											<td>Rating</td>
											<td><%=movie_info[0].Ratings%></td>
										</tr>
										<tr>
											<td>No of View</td>
											<td><%=movie_info[0].NoOfView%></td>
										</tr>
										<tr>
											<td>No of Review</td>
											<td><%=movie_info[0].NoOfReview%></td>
										</tr>
									</tbody>
								</table>
							</div>
							<div class="tab-pane fade" id="pills-cast" role="tabpanel" aria-labelledby="pills-cast-tab">
								<h3 class="tab-title">Movie Cast</h3>
								<table class="table table-bordered product-table">
									<tbody>

                                         <% 
                                        if (movie_cast.Count > 0)
                                        {
                                            foreach (var cast in movie_cast)
                                            { %>
										        <tr>
											        <td><%=cast.Name%></td>
											        <td><%=cast.RoleName%></td>
										        </tr>
                                            <%}
                                        }%>
										
									</tbody>
								</table>
							</div>
							<div class="tab-pane fade" id="pills-review" role="tabpanel" aria-labelledby="pills-review-tab">
								<h3 class="tab-title">Movie Review</h3>
								<div class="product-review">
                                    <% 
                                        if (movie_review.Count > 0)
                                        {
                                            foreach (var review in movie_review)
                                            { %>

									            <div class="media">
										            <!-- Avater -->
										            <img src="<%=review.PhotoURL%>" alt="avater">
										            <div class="media-body">
											            <!-- Ratings -->
											            <!--<div class="ratings">
												            <ul class="list-inline">
													            <li class="list-inline-item">
														            <i class="fa fa-star"></i>
													            </li>
													            <li class="list-inline-item">
														            <i class="fa fa-star"></i>
													            </li>
													            <li class="list-inline-item">
														            <i class="fa fa-star"></i>
													            </li>
													            <li class="list-inline-item">
														            <i class="fa fa-star"></i>
													            </li>
													            <li class="list-inline-item">
														            <i class="fa fa-star"></i>
													            </li>
												            </ul>
											            </div>-->
											            <div class="name">
												            <h5><%=review.UserName%></h5>
											            </div>
											            <div class="date">
												            <div class="row">
													            <div class="col-6">
														            <p><%=review.ReviewDate%></p>
													            </div>
													            <div class="col-6">
														            <p>Rating: <%=review.Rating%>/10</p>
													            </div>
													
												            </div>
											            </div>
											            <div class="review-comment">
												            <p>
													            <%=review.Message%>
												            </p>
											            </div>
										            </div>
									            </div>
                                    <%}
                                    }
                                    else
                                    {
                                                    %>
                                                <h4>No reviews found for this movie</h4>
                                                <br />
                                     <%} %>


									



									<div class="review-submission">
										<h3 class="tab-title">Submit your review</h3>
										<!-- Rate -->
										<!--<div class="rate">
											<div class="starrr"></div>
										</div>-->
										<div class="review-submit">
											<div class="row">
												<div class="col-lg-12">
													<label>Rating</label>
												</div>
												<div class="col-lg-12">
													<!--<input type="number" name="Rating" id="rating" class="form-control" placeholder="Rate this movie out of 10">-->
                                                    <asp:TextBox ID="Rating" placeholder="Rate this movie out of 10" class="form-control" TextMode="Number" runat="server"></asp:TextBox>
												</div>
												
												<div class="col-12">
													<!--<textarea name="review" id="review" rows="10" class="form-control" placeholder="Message"></textarea>-->
                                                    <asp:TextBox ID="Message" rows="10" placeholder="Message" class="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>
												</div>
												<div class="col-12">
													 <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" CssClass="btn btn-offer d-inline-block btn-primary ml-n1 my-1 px-lg-4 px-md-3" runat="server" Text="Submit" />
                                                    <!--<button type="submit" class="btn btn-contact d-inline-block  btn-primary px-lg-5 my-1 px-md-3">Sumbit</button>-->
												</div>
											</div>
										</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
			<div class="col-md-4">
				<div class="sidebar">
					<div class="widget price text-center">
						<h4>Ratings</h4>
						<p><%=movie_info[0].Ratings%>/10</p>
					</div>
					<!-- User Profile widget -->
					<div class="widget user text-center">
						<img class="img-fluid" src="<%=movie_info[0].PosterURL%>" alt="">
						<!--<h4><a href="">Jonathon Andrew</a></h4>
						<p class="member-time">Member Since Jun 27, 2017</p>
						<a href="">See all ads</a>-->
						<ul class="list-inline mt-20">
							<br/>
							<!--<li class="list-inline-item"><a href="" class="btn btn-contact d-inline-block  btn-primary px-lg-5 my-1 px-md-3">Add to Watch List</a></li>-->
							<li class="list-inline-item">
                                <asp:Button ID="btnAddtoWatch" OnClick="btnAddtoWatch_Click" runat="server" class="btn btn-contact d-inline-block  btn-primary px-lg-5 my-1 px-md-3"  Text="Add to watch list" /></li>
                            <!--<li class="list-inline-item"><a href="" class="btn btn-offer d-inline-block btn-primary ml-n1 my-1 px-lg-4 px-md-3">Suggest a friend</a></li>-->
                            <li class="list-inline-item">
                                <asp:Button ID="btnSuggestFriend" OnClick="btnSuggestFriend_Click" Visible="true" CssClass="btn btn-offer d-inline-block btn-primary ml-n1 my-1 px-lg-4 px-md-3" runat="server" Text="Suggest a friend" /></li>
						</ul>
                        <ul class="list-inline mt-20">
							<li class="list-inline-item">
                                <div class="row"> <!--Search components-->
                                    <div class="col-8">
                                        <asp:TextBox ID="SearchBox" Visible="false" CssClass="form-control" placeholder="Name or email" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-4">
                                        <asp:Button ID="btnSearchButton" OnClick="btnSearchButton_Click" Visible="false" CssClass="btn btn-offer d-inline-block btn-primary" runat="server" Text="Search" />
                                    </div>
                                </div>
                                <!-- If results found-->
                                <br />
                                <div class="row">
                                    <div class="col-3"> 
                                        <asp:Image ID="ImageUser" CssClass="img-fluid" Visible="false" ImageUrl="images/user.png" runat="server" />
                                    </div>
                                    <div class="col-9">
                                        <asp:Label ID="NameUser" CssClass="pt-5" Visible="false" runat="server" Text="Rejone E Rasul Hridoy" Font-Bold="True" Font-Size="Medium"></asp:Label>
                                    </div>
                                </div>
                                <!-- if complete-->
                                <!-- else :results not found-->
                                <div class="row">
                                        <h4><asp:Label ID="MessageNotFound" Visible="false" runat="server" Text="No Results Found"></asp:Label></h4>                                
                                </div>
                                <!--else complete-->

							</li>
                            <li class="list-inline-item">
                                <asp:Button ID="btnSuggestSearchFriend" OnClick="btnSuggestSearchFriend_Click" Visible="false" CssClass="btn btn-offer d-inline-block btn-primary ml-n1 my-1 px-lg-4 px-md-3" runat="server" Text="Suggest" />
                            </li>
						</ul>
					</div>
					<!-- Map Widget -->
					<!--<div class="widget map">
						<div class="map">
							<div id="map_canvas" data-latitude="51.507351" data-longitude="-0.127758"></div>
						</div>
					</div>-->
					<!-- Rate Widget -->
					<!--<div class="widget rate">
						
						<h5 class="widget-header text-center">What would you rate
							<br>
							this product</h5>
						
						<div class="starrr"></div>
					</div>-->
					<!-- Safety tips widget -->
					<!--<div class="widget disclaimer">
						<h5 class="widget-header">Safety Tips</h5>
						<ul>
							<li>Meet seller at a public place</li>
							<li>Check the item before you buy</li>
							<li>Pay only after collecting the item</li>
							<li>Pay only after collecting the item</li>
						</ul>
					</div>-->
					<!-- Coupon Widget -->
					<!--<div class="widget coupon text-center">
						
						<p>Have a great product to post ? Share it with
							your fellow users.
						</p>
						
						<a href="" class="btn btn-transparent-white">Submit Listing</a>
					</div>-->

				</div>
			</div>

		</div>
	</div>
	<!-- Container End -->
</section>


</asp:Content>
