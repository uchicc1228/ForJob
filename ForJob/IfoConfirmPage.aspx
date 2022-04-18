<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IfoConfirmPage.aspx.cs" Inherits="ForJob.IfoConfirmPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1><b>您輸入的資料為：</b></h1>
            <label>問卷標題：</label>
            <asp:Label runat="server" ID="lblTtile"></asp:Label>
            <br />
            <label>問卷內容：</label>
            <asp:Label runat="server" ID="lblContent"></asp:Label>
            <br />
            <label>填寫人姓名：</label>
            <asp:Label runat="server" ID="lblName"></asp:Label>
            <br />
            <label>填寫人信箱：</label>
            <asp:Label runat="server" ID="lblEmail"></asp:Label>
            <br />
            <label>填寫人年齡：</label>
            <asp:Label runat="server" ID="lblAge"></asp:Label>
            <br />
            <label>填寫人電話：</label><asp:Label runat="server" ID="lblPhone"></asp:Label>
            <asp:Literal runat="server" ID="ltlRdo"></asp:Literal>

        </div>
        <asp:Button runat="server" ID="btnconfirm" Text="確定並送出" OnClick="btnconfirm_Click" /> <br />
        <asp:Button runat="server" ID="btncancel" Text="取消" OnClick="btncancel_Click" />

    </form>
</body>
</html>
