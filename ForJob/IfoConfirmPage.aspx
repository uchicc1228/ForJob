<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IfoConfirmPage.aspx.cs" Inherits="ForJob.IfoConfirmPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
           <label>問卷標題：</label> <asp:Label runat="server" ID="lblTtile"></asp:Label> <br />
           <label>問卷內容：</label> <asp:Label runat="server" ID="lblContent"></asp:Label> <br />
           <label>填寫人姓名：</label> <asp:Label runat="server" ID="lblName"></asp:Label> <br />
           <label>填寫人信箱：</label> <asp:Label runat="server" ID="lblEmail"></asp:Label> <br />
           <label>填寫人年齡：</label> <asp:Label runat="server" ID="lblAge"></asp:Label> <br />
           <label>填寫人電話：</label><asp:Label runat="server" ID="lblPhone"></asp:Label>
        </div>
    </form>
</body>
</html>
