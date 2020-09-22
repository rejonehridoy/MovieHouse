<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="BasicWeb.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="section bg-gray">
    <div class="container">
        <div class="row">
            <div class="col-md-6 text-center mx-auto">
                <div class="404-img">
                    <br /><br />
                    <img src="images/404.png" class="img-fluid" alt="">
                </div>
                <div class="404-content">
                    <h1 class="display-1 pt-1 pb-2">Oops</h1>
                    <p class="px-3 pb-2 text-dark">Something went wrong,we can't find the page that you are looking for :(But there is a lot more for you!</p>
                    <a href="Default.aspx" class="btn btn-info">GO HOME</a>
                    <br /><br />
                </div>
            </div>
        </div>
    </div>
</section>
</asp:Content>
