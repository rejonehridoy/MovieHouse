<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reviews.aspx.cs" Inherits="BasicWeb.Reviews" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Watch List GridView Here-->
                <div class="col-md-12">
                    <div class="card">
                       <div class="card-body">
                          <div class="row">
                             <div class="col">
                                <center>
                                   <h4 class="font-bold">Latest Reviews</h4>
                                </center>
                             </div>
                          </div>
                          <div class="row">
                             <div class="col">
                                <hr>
                             </div>
                          </div>

                            

                          <div class="row">

                            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:MovieHouseConnectionString %>" SelectCommand="Select Movies.Mid,Movies.Name,Movies.NoOfView,Movies.PosterURL,Movies.Category,Movies.Ratings,Movies.ReleaseYear,Movies.Language,Movies.Runtime,Review.Rid,Review.Rating,Review.ReviewDate,Review.Message,[User].Name as UserName from Movies inner join Review on Review.Mid = Movies.Mid inner join [User] on Review.Uid = [User].Uid order by Review.Rid desc">
                                
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
                                                            <!--1st Line: Movie Name Release Year-->
                                                            <div class="row">
                                                                <div class="col-12">
                                        
                                                                    <asp:Label ID="MovieName" Font-Bold="True" Font-Size="X-Large" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                                                    &nbsp;
                                                                    <asp:Label ID="Label8" Font-Bold="True" Font-Size="X-Large" runat="server" Text='<%# Eval("ReleaseYear") %>'></asp:Label>
                                                                </div>
                                                            </div>
                                                            
                                                            <!--3rd Line: Category	Language	Global Ratings	 Views-->
                                                            <div class="row">
                                                                <div class="col-12">

                                                                    Category:
                                                                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Text='<%# Eval("Category") %>'></asp:Label>
                                                                    &nbsp;| Language:
                                                                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Text='<%# Eval("Language") %>'></asp:Label>
                                                                    &nbsp;| Global Rating:
                                                                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Text='<%# Eval("Ratings") %>'></asp:Label>
                                                                    &nbsp;| Views:
                                                                    <asp:Label ID="Label9" runat="server" Font-Bold="True" Text='<%# Eval("NoOfView") %>'></asp:Label>

                                                                </div>
                                                            </div>
                                                            <!--3rd Line: Reviewr Name  Personal Rating  Review Date -->
                                                            <div class="row">
                                                                <div class="col-12">

                                                                    Reviwer Name:
                                                                    <asp:Label ID="Label5" runat="server" Font-Bold="True" Text='<%# Eval("UserName") %>'></asp:Label>
                                                                    &nbsp;| Personal Rating:
                                                                    <asp:Label ID="Label6" runat="server" Font-Bold="True" Text='<%# Eval("Rating") %>'></asp:Label>
                                                                    &nbsp;| Review Date:
                                                                    <asp:Label ID="Label7" runat="server" Font-Bold="True" Text='<%# Eval("ReviewDate") %>'></asp:Label>

                                                                </div>
                                                            </div>
                                                            <!--4thd Line: Review Message -->
                                                            <div class="row">
                                                                <div class="col-12">

                                                                    
                                                                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Text='<%# Eval("Message") %>'></asp:Label>
                                                                    

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

</asp:Content>
