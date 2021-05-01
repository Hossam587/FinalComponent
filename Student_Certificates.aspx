<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Student_Certificates.aspx.cs" Inherits="GUCera.Student_Certificates" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="courseid1" runat="server" Text="Please enter courseid"></asp:Label>
        </div>
        <asp:TextBox ID="courseid1text" runat="server"></asp:TextBox>
        <p>
            <asp:Label ID="studentid1" runat="server" Text="Please enter studentid"></asp:Label>
        </p>
        <asp:TextBox ID="student1text" runat="server"></asp:TextBox>
        <p>
            &nbsp;</p>
        <p>
            <asp:Button ID="viewcertificate1" runat="server" style="margin-left: 0px" Text="View Certificates" OnClick="viewcertificate1_Click" />
        </p>
    </form>
</body>
</html>
