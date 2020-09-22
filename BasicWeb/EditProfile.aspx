<%@ Page Title="Edit Profile" Language="C#" MasterPageFile="~/Site.Master" enableEventValidation="false" AutoEventWireup="true" CodeFile="EditProfile.aspx.cs" Inherits="BasicWeb.EditProfile" %>
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
    
<div class="container bootstrap snippet">
    <div class="row">
  		<div class="col-sm-10"><h1>Edit Profile</h1></div>
    	
    </div>
    <div class="row">
  		
    	<div class="col-sm-12">
            

              
          <div class="tab-content">
            <div class="tab-pane active" id="home">
                <hr>
                  <div>
                      <div class="form-group">
                          <div class="col-xs-6">
                              <center>
                                    <img id="imgview" class="p-3" Height="250px" Width="200px" src="images/user.png" />
                                    <asp:FileUpload  onchange="readURL(this);" class="form-control" ID="FileUpload1" runat="server" />
                              </center>

                          </div>
                      </div>


                      <div class="form-group">
                          
                          <div class="col-xs-6">
                              <label for="first_name"><h5>Name</h5></label>
                              <asp:TextBox ID="Name" CssClass="form-control" placeholder="Name" runat="server"></asp:TextBox>
                             
                          </div>
                      </div>
                      
          
                      <div class="form-group">
                          
                          <div class="col-xs-6">
                              <label for="contact"><h5>Phone</h5></label>
                              <asp:TextBox ID="Contacts" CssClass="form-control" placeholder="Phone" TextMode="Phone" runat="server"></asp:TextBox>
                          </div>
                      </div>
          
                      
                      <div class="form-group">
                          
                          <div class="col-xs-6">
                              <label for="password"><h5>Current Password</h5></label>
                              <asp:TextBox ID="OldPassword" CssClass="form-control" placeholder="Password" TextMode="Password" runat="server"></asp:TextBox>
                          </div>
                      </div>
                      
                      <div class="form-group">
                          
                          <div class="col-xs-6">
                              <label for="password"><h5>New Password</h5></label>
                              <asp:TextBox ID="NewPassword" CssClass="form-control" placeholder="Password" TextMode="Password" runat="server"></asp:TextBox>
                          </div>
                      </div>
                      <div class="form-group">
                          
                          <div class="col-xs-6">
                            <label for="password2"><h5>Retype Password</h5></label>
                              <asp:TextBox ID="RetypePassword" CssClass="form-control" placeholder="Password" TextMode="Password" runat="server"></asp:TextBox>
                          </div>
                      </div>
                      <div class="form-group">
                           <div class="col-xs-12">
                                <br>
                                <asp:Button runat="server" ID="btnSave" CssClass="btn btn-lg btn-primary" Text="Save" OnClick="btnSave_Click" />
                               <asp:Button runat="server" ID="btnReset" CssClass="btn btn-lg" Text="Reset" OnClick="btnReset_Click" />
                              	
                            </div>
                      </div>
              	</div>
              
              
              
             </div><!--/tab-pane-->
             
             
               
              </div><!--/tab-pane-->
          </div><!--/tab-content-->

        </div><!--/col-9-->
    </div><!--/row-->
                                                      
</asp:Content>
