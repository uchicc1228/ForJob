<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddQuestionary.aspx.cs" Inherits="ForJob.Backstage.AddQuestionary" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>後台管理-新增問卷</title>
    <script src="../JavaScript/bootstrap/bootstrap.js"></script>
    <script src="../JavaScript/jquery/jquery.js"></script>
    <style>
        div {
            border: 1px solid black;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>後台1-問卷新增管理</h1>
        <asp:PlaceHolder runat="server" ID="plc1" Visible="false">
            <label>問卷名稱</label>
            <asp:TextBox runat="server" placeholder="輸入問卷名稱" ID="txtName"></asp:TextBox>
            </br>
            <label>描述內容</label>
            <asp:TextBox runat="server" placeholder="輸入描述內容" ID="txtExplain"></asp:TextBox>
            </br>
            <label>開始時間</label>
            <input type="date" runat="server" id="txtTime_start" />
            </br>
            <label>結束時間</label>
            <input type="date" runat="server" id="txtTime_end" />
            </br>
             <label>啟用</label>
            <asp:CheckBox runat="server" ID="checkcheck" />
            <asp:Button runat="server" ID="btnConfirm" Text="送出DeSu" OnClick="btnConfirm_Click" />
        </asp:PlaceHolder>


        <asp:PlaceHolder runat="server" ID="plc2">
            <div>
                <label>問卷名稱</label>
                <asp:Label runat="server" ID="lblName"></asp:Label>
                <br />
                <label>描述內容</label>
                <asp:Label runat="server" ID="lblContent"></asp:Label><br />
                <label>開始時間</label>
                <asp:Label runat="server" ID="lblStartTime"></asp:Label><br />
                <label>結束時間</label>
                <asp:Label runat="server" ID="lblEndTime"></asp:Label><br />

                <label>種類</label>
                <asp:DropDownList runat="server" ID="dowList" AutoPostBack="true" OnSelectedIndexChanged="dowList_SelectedIndexChanged1">
                    <asp:ListItem Value="0">自訂問題</asp:ListItem>
                    <asp:ListItem Value="1" Selected="True">常用問題</asp:ListItem>
                </asp:DropDownList><br />
                <label>問題</label>
                <asp:TextBox runat="server" ID="txtQuestion" placeholder="輸入問題"></asp:TextBox>
                <asp:DropDownList runat="server" ID="dowMode" AutoPostBack="true" OnSelectedIndexChanged="dowMode_SelectedIndexChanged">
                    <asp:ListItem Value="0">單選方塊</asp:ListItem>
                    <asp:ListItem Value="1" Selected="True">複選方塊</asp:ListItem>
                    <asp:ListItem Value="2">文字</asp:ListItem>
                </asp:DropDownList><br />
                <label>回答</label>
                <asp:TextBox runat="server" ID="txtanswer" placeholder="輸入回答 多個回答請以,分隔"></asp:TextBox><br />
                <label>是否必填</label>
                <asp:CheckBox runat="server" ID="checknecessary" />

                <asp:Button runat="server" ID="btnconfirmQ" Text="加入" OnClick="btnconfirmQ_Click" />
                <asp:Button runat="server" ID="btnchanged" Text="確認編輯" OnClick="btnchanged_Click" />
                <asp:Label runat="server" ID="lblmsg"></asp:Label>
        </asp:PlaceHolder>


        <div>
            <asp:Repeater runat="server" ID="ret1" OnItemCommand="ret1_ItemCommand" OnItemDataBound="ret1_ItemDataBound1">
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:Label runat="server" Visible="false" ID="Label1" Text='<%# DataBinder.Eval(Container.DataItem, "Number") %>'></asp:Label>
                            <%# Container.ItemIndex + 1 %>
                        </td>
                        <td><%# DataBinder.Eval(Container.DataItem, "Question") %> </td>
                        <td><%# DataBinder.Eval(Container.DataItem, "QQMode") %> </td>
                        <td><%# DataBinder.Eval(Container.DataItem, "QIsNecessary") %> </td>
                        <td>
                            <asp:Button runat="server" ID="btnEdit" OnClick="btnEdit_Click" Text="編輯" CommandName="btnEdit" CommandArgument='<%# Eval("ID") +","+ Eval("Number") + "," + Eval("QuestionID")%>' /></td>
                        <td>
                            <asp:Button runat="server" ID="btnDelete" Text="刪除" CommandName="btnDelete" CommandArgument='<%# Eval("ID")+ ","+ Eval("QuestionID") %>' /></td>
                    </tr>

                </ItemTemplate>
                <HeaderTemplate>
                    <table border="1">
                        <tr>

                            <td><b>#</b></td>
                            <td><b>問題</b></td>
                            <td><b>模式</b></td>
                            <td><b>是否必填</b></td>
                            <td><b>編輯</b></td>
                            <td><b>刪除</b></td>
                        </tr>
                </HeaderTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>

        </div>

        <asp:Button runat="server" ID="btnDelete" Text="刪除" OnClick="btnDelete_Click" />
        <asp:Button runat="server" ID="btnSend" Text="送出" OnClick="btnSend_Click" />
    </form>

</body>
</html>
