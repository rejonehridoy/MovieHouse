<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BasicWeb.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!--================login_part Area =================-->
    <section class="login_part section_padding ">
        <div class="container">
            <div class="row align-items-center">
                <div class="col-lg-6 col-md-6">
                    <div class="login_part_text text-center">
                        <div class="login_part_text_iner">
                            <h2>New to our Website?</h2>
                            <p>There are advances being made in science and technology
                                everyday, and a good example of this is the</p>
                            <a href="Signup.aspx" class="btn_3 btn btn-outline-primary">Create an Account</a>
                            
                        </div>
                    </div>
                </div>
                <div class="col-lg-6 col-md-6">
                    <div class="login_part_form">
                        <div class="login_part_form_iner">
                            <h3>Welcome Back ! <br>
                                Please Sign in now</h3>
                            <div class="row contact_form">
                                <div class="col-md-12 form-group p_star">
                                    <!--<input type="text" class="form-control" id="name" name="name" value=""
                                        placeholder="Username">-->
                                    <asp:TextBox ID="UserEmail" class="form-control" placeholder="Email" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-12 form-group p_star">
                                    <!--<input type="password" class="form-control" id="password" name="password" value=""
                                        placeholder="Password">-->
                                    <asp:TextBox ID="UserPassword" class="form-control" placeholder="Password" runat="server" TextMode="Password"></asp:TextBox>
                                </div>
                                <div class="col-md-12 form-group">
                                    <div class="creat_account d-flex align-items-center">
                                        <input type="checkbox" id="f-option" name="selector">
                                        <label for="f-option">Remember me</label>
                                    </div>

                                    <asp:Button ID="LoginButton" CssClass="btn_3 btn btn-outline-primary" runat="server" OnClick="LoginButton_Click" Text="Login" />
                                    
                                    <a class="lost_pass" href="#">forget password?</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!--================login_part end =================-->
</asp:Content>
