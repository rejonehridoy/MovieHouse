<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="BasicWeb.Signup" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
       $(document).ready(function () {
           $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
       });
 
       function readURL(input) {
           if (input.files && input.files[0]) {
               var reader = new FileReader();
 
               reader.onload = function (e) {
                   $('#imgview').attr('src', e.target.result);
               };
 
               reader.readAsDataURL(input.files[0]);
           }
       }
 
   </script>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!--================Signup Area =================-->
    <section class="login_part section_padding ">
        <div class="container-fluid">
            <div class="row align-items-center">
                <div class="col-lg-6 col-md-6">
                    <div class="login_part_text text-center">
                        <div class="login_part_text_iner">
                            <h2>Already have account?</h2>
                            <p>Please login and enjoy more features</p>
                            <a href="Login.aspx" class="btn_3 btn btn-outline-primary">Go to Login</a>
                            
                        </div>
                    </div>
                </div>
                <div class="col-lg-6 col-md-6">
                    <div class="login_part_form">
                        <div class="login_part_form_iner">
                            <h3>New User ! <br>
                                Please Sign up now</h3>
                            <div class="row">
                                <div class="col-md-12 form-group p_star">
                                    <center>
                                        <img id="imgview" class="p-3" Height="250px" Width="200px" src="images/user.png" />
                                        <asp:FileUpload  onchange="readURL(this);" class="form-control" ID="FileUpload1" runat="server" />
                                    </center>
                                </div>
                                <div class="col-md-12 form-group p_star">
                                    <!--<input type="text" class="form-control" id="name" name="name" value=""
                                        placeholder="Username">-->
                                    <asp:TextBox ID="Name" class="form-control" placeholder="Name" runat="server" ></asp:TextBox>
                                </div>
                                <div class="col-md-12 form-group p_star">
                                    <!--<input type="text" class="form-control" id="name" name="name" value=""
                                        placeholder="Username">-->
                                    <asp:TextBox ID="Email" class="form-control" placeholder="Email" runat="server" ></asp:TextBox>
                                </div>
                                <div class="col-md-12 form-group p_star">
                                    <asp:RadioButtonList ID="Gender" CssClass="form-control text-center" runat="server" RepeatDirection="Horizontal">
                                        
                                            <asp:ListItem Text="Male"  class="p-5" Value="Male"></asp:ListItem>
                                            <asp:ListItem Text="Female" class="p-5" Value="Female"></asp:ListItem>
                                        
                                        
                                    </asp:RadioButtonList>
                                </div>

                                <div class="col-md-12 form-group p_star">
                                    <!--<input type="text" class="form-control" id="name" name="name" value=""
                                        placeholder="Username">-->
                                    <asp:TextBox ID="Phone" class="form-control" placeholder="Phone" runat="server" ></asp:TextBox>
                                </div>
                                <div class="col-md-12 form-group p_star">
                                    <!--<input type="password" class="form-control" id="password" name="password" value=""
                                        placeholder="Password">-->
                                    <asp:TextBox ID="Password" class="form-control" placeholder="Password" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-12 form-group">
                                    <asp:Button ID="SignupButton" CssClass="btn_3 btn btn-outline-primary" runat="server" Text="Signup" OnClick="SignupButton_Click"  />
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
