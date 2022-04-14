<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dd.aspx.cs" Inherits="ForJob.dd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>


    <script>
        $(document).ready(function () {

            // 動態加入文字
            $("#checkarea").css("background-color", "yellow");

            $("#checkarea").append(`<label>
  <input type="checkbox" name="hoge" value="1" />リンゴ
</label><br/>
<label>
  <input type="checkbox" name="hoge" value="2" />バナナ
</label><br/>
<label>
  <input type="checkbox" name="hoge" value="3" />オレンジ
</label>
`);

            // 定義CheckBox function
            var checkfunction = (function () {
                $('input[name=hoge]').on('change', function () {
                    /// チェックされたvalue値を配列として取得
                    var vals = $('input[name=hoge]:checked').map(function () {
                        return $(this).val();
                    }).get();
                    console.log(vals);
                });
            })

            $("#btn1").click(function () {
                var vals = $('input[name=hoge]:checked').map(function () {
                    return $(this).val();
                }).get();


                alert(vals);
            });

            //呼叫方法
          
            $('input[name=hoge]').change(checkfunction);

        });
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div id="checkarea">
        </div>

        <button id="btn1">get value</button>
    </form>
</body>
</html>
