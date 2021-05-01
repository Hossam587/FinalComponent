<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Student_view_each_asstype_grade.aspx.cs" Inherits="GUCera.Student_view_each_asstype_grade" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="assignmentno" runat="server" Text="Please enter assignment number"></asp:Label>
        <div>
            <asp:TextBox ID="assignmantnotext" runat="server"></asp:TextBox>
        </div>
        <p>
        <asp:Label ID="assignmanttype" runat="server" Text="Please enter assignment type"></asp:Label>
        </p>
        <p>
            <asp:TextBox ID="assignmenttypetext" runat="server"></asp:TextBox>
        </p>
        <asp:Label ID="courseId" runat="server" Text="Please enter course id"></asp:Label>
        <p>
            <asp:TextBox ID="courseIdtext" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="studentId" runat="server" Text="Please enter student id"></asp:Label>
        </p>
        <asp:TextBox ID="studentIdtext" runat="server"></asp:TextBox>
        <p>
            <asp:Button ID="Continue2" runat="server" style="margin-left: 26px" Text="Continue" OnClick="Continue2_Click" />
        </p>
    </form>
</body>
</html>
