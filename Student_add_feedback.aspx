<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Student_add_feedback.aspx.cs" Inherits="GUCera.Student_add_feedback" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="comment" runat="server" Text="Write your feedback"></asp:Label>
        </div>
        <asp:TextBox ID="commenttext" runat="server" Height="65px" Width="306px"></asp:TextBox>
        <p>
            <asp:Label ID="Cid" runat="server" Text="Please enter courseid"></asp:Label>
        </p>
        <asp:TextBox ID="Cidtext" runat="server"></asp:TextBox>
        <p>
            <asp:Label ID="Sid" runat="server" Text="Please enter studentid"></asp:Label>
        </p>
        <p>
            <asp:TextBox ID="Sidtext" runat="server"></asp:TextBox>
        </p>
        <asp:Button ID="continue3" runat="server" style="margin-left: 38px" Text="ADD" OnClick="continue3_Click" />
    </form>
</body>
</html>
