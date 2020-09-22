<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="BasicWeb.Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-md-12">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4 class="font-bold">Search Result</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MovieHouseConnectionString %>" SelectCommand="SELECT Mid, Name, Category, ReleaseYear, Description, NoOfView, Ratings, PosterURL, NoOfReview, Language, StudioName FROM Movies WHERE (Name LIKE @key ) OR (Category LIKE @key ) OR (Language LIKE @key ) OR (ReleaseYear LIKE @key ) OR (StudioName LIKE @key )">
            <SelectParameters>
                <asp:QueryStringParameter Name="key" QueryStringField="key" />
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

                                        &nbsp;| Studio Name:
                                        <asp:Label ID="Label8" runat="server" Font-Bold="True" Text='<%# Eval("StudioName") %>'></asp:Label>

                                    </div>
                                </div>
                                <!--4th Line: NoofView	NoofReview	Watched Date -->
                                <div class="row">
                                    <div class="col-12">

                                        No of View:
                                        <asp:Label ID="Label5" runat="server" Font-Bold="True" Text='<%# Eval("NoOfView") %>'></asp:Label>
                                        &nbsp;| No of Review:
                                        <asp:Label ID="Label6" runat="server" Font-Bold="True" Text='<%# Eval("NoOfReview") %>'></asp:Label>
                                        &nbsp;| Language:
                                        <asp:Label ID="Label7" runat="server" Font-Bold="True" Text='<%# Eval("Language") %>'></asp:Label>

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
