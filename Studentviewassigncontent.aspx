<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Studentviewassigncontent.aspx.cs" Inherits="GUCera.Studentviewassigncontent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>




            
            <asp:Label ID="CourseId" runat="server" Text="Please enter courseID"></asp:Label>




            
        </div>
        <asp:TextBox ID="CourseIdtext" runat="server"></asp:TextBox>
        <p>
            <asp:Label ID="StudentId" runat="server" Text="Please enter studentID"></asp:Label>
        </p>
        <asp:TextBox ID="StudentIdtext" runat="server" Width="165px"></asp:TextBox>
        <p>
            <asp:Button ID="click1" runat="server" style="margin-left: 26px" Text="Continue" Width="115px" OnClick="click1_Click" />
        </p>
    </form>
</body>
</html>
