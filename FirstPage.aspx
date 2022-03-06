<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FirstPage.aspx.cs" Inherits="WebApplication.FirstPage" %>

        
    
   

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
    </title>
</head>
<body>
    <h1>ASP.NET</h1>
        <p class="lead">This page takes in the ID number then determines dob, gender, citizenship and saves to database after it consumes holidays api to bring back the holidays based on year received from id number
            First enter ID then click on Submit button to save to database then can click on Serach button to search for holidays for given year
        </p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    <p>
        <br />
    </p>
    <p>
        &nbsp;</p>
    
    <form id="form1" runat="server">
        <p>
            &nbsp;</p>
        <p>
            <p>
        Enter ID number</p>
            <asp:TextBox ID="txtID" runat="server" Width="188px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="reqID"  runat="server" ControlToValidate="txtID" ErrorMessage="*"></asp:RequiredFieldValidator>
            <asp:CustomValidator ID="CusID" runat="server" Display="Dynamic" ForeColor="Red" ControlToValidate="txtID" CssClass="text-danger" OnServerValidate="CustomValidator"
                ErrorMessage="" ></asp:CustomValidator>
        </p>
        <p>
            <asp:Button ID="btnSearch" runat="server" Text="Search" Width="109px" OnClick="Search" />
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" Width="122px" OnClick="btnSubmit_Click" />
        </p>
        <div>
            <asp:GridView ID="gvHolidays" runat="server" AutoGenerateColumns="false">
            </asp:GridView>
            <br />
            <br />
        </div>
    </form>
</body>
</html>
    
