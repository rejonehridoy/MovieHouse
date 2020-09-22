<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="BasicWeb.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your contact page.</h3>
    <address>
        Movie House<br />
        51 Lake Circus,Kalabagan,Dhanmondi<br />
        <abbr title="Phone">P:</abbr>
        123456789
    </address>

    <address>
        <strong>Support:</strong>   <a href="mailto:Support@example.com">Support@moviehouse.com</a><br />
        <strong>Marketing:</strong> <a href="mailto:Marketing@example.com">Marketing@moviehouse.com</a>
    </address>
</asp:Content>
