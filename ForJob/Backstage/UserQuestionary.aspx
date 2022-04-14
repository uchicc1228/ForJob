<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserQuestionary.aspx.cs" Inherits="ForJob.Backstage.UserQuestionary" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
      <style>
          div{
              border: 1px solid black;
          }
          .timediv{
              float:right;
              padding-right: 100px;
          }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        
        <div class="timediv">
             <%--時間--%>
            <asp:Label runat="server" ID="lblTime"></asp:Label>
        </div>     
        <div>
            <%--標題--%>
            <asp:Label runat="server" ID="lbltitle"></asp:Label> <br/>      
            <%--內文--%>
            <asp:Label runat="server" ID="lblContent"></asp:Label> <br/>  <br/>      

            <%--姓名--%>
            <asp:Label runat="server" ID="lalName">姓名</asp:Label> <asp:TextBox  runat="server" ID="txtName" placeholder="輸入姓名"></asp:TextBox> <br/>
             <%--手機--%>
            <asp:Label runat="server" ID="Label1">手機</asp:Label> <asp:TextBox  runat="server" ID="TextBox1" placeholder="輸入手機"></asp:TextBox> <br/>
             <%--Email--%>
            <asp:Label runat="server" ID="Label2">信箱</asp:Label> <asp:TextBox  runat="server" ID="TextBox2" placeholder="輸入email"></asp:TextBox> <br/>
             <%--年齡--%>
            <asp:Label runat="server" ID="Label3">年齡</asp:Label> <asp:TextBox  runat="server" ID="TextBox3" placeholder="輸入年齡"></asp:TextBox> <br/>
        </div>
        <div>
            <asp:Button runat="server" ID="btnyes" Text="確定送出" OnClick="btnyes_Click" />
            <asp:Button runat="server" ID="btnback" Text="取消返回"  OnClick="btnback_Click"/>
        </div>
    </form>
</body>
</html>
