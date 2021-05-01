<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentsubmitAssignment.aspx.cs" Inherits="GUCera.StudentsubmitAssignment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form30" runat="server">
        <div>
        </div>
        <asp:Label ID="Assigmnenttype" runat="server" Text="Please enter assignment type"></asp:Label>
        <p>
            <asp:TextBox ID="Asstypetext" runat="server"></asp:TextBox>
        </p>
        <asp:Label ID="Assignmentnumber" runat="server" Text="Plese enter assignment number"></asp:Label>
        <p>
            <asp:TextBox ID="Assnumbertext" runat="server"></asp:TextBox>
        </p>
        <asp:Label ID="sid" runat="server" Text="Please enter student ID"></asp:Label>
        <p>
            <asp:TextBox ID="sidtext" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="cid" runat="server" Text="Please enter course ID"></asp:Label>
        </p>
        <asp:TextBox ID="cidtext" runat="server"></asp:TextBox>
        <p>
            <asp:Button ID="Submission" runat="server" style="margin-left: 23px" Text="Submit" Width="102px" OnClick="Submission_Click" />
        </p>
    </form>
</body>
</html>
