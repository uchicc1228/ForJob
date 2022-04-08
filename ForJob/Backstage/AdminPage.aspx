<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="ForJob.Backstage.AdminPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>後台問卷管理頁面</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css"
        integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk"
        crossorigin="“anonymous" />
    <script src="../JavaScript/bootstrap/bootstrap.js"></script>
    <script src="../JavaScript/jquery/jquery.js"></script>

    <style>
        div {
            border: 1px solid black;
        }

        body {
            margin: 0px;
            background-repeat: no-repeat;
            background-color: darkgrey;
            background-size: 100%;
            background-position-x: center;
            overflow-x: hidden;
        }

        .divSearch {
            position: relative;
            left: 40%;
            width: 500px;
            padding: 20px;
            height: 150px;
        }

        .btnsearch {
            position: relative;
            float: right;
        }

        .divlist {
            width: 80%;
            height: 100%;
            left: 18%;
            position: relative;
        }



        .list-group {
            position: relative;
            text-align: center;
            width: 100%;
            padding: 0px;
            margin: 0px;
        }

        .pagination {
            position: relative;
            float: left;
            padding: 0px;
            margin: 0px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div class="Main">
            <h1>問卷管理</h1>
            <hr />
            <div class="divSearch">
                <label for="titlesearch" style="padding-right: 62px;">標題</label>
                <input type="text" id="titlesearch" placeholder="請輸入問卷標題" />
                <br />
                <label for="titlesearch" style="padding-right: 15px;">開始 / 結束</label>
                <input type="date" runat="server" id="txtCalender_start" />
                <input type="date" runat="server" id="txtCalender_end" />
                <input type="button" id="btnsearch" value="搜尋" />
            </div>
            <div class="divlist">
                <div class="list-group" id="summarizing">
                </div>
                <div>
                    <nav aria-label="Page navigation example" clcass="pagination">
                        <ul class="pagination">
                            <li class="page-item"><a class="page-link" href="#" style="color: black; background-color: darkgrey;">Previous</a></li>
                            <li class="page-item"><a class="page-link" href="#" style="color: black; background-color: darkgrey;">1</a></li>
                            <li class="page-item"><a class="page-link" href="#" style="color: black; background-color: darkgrey;">2</a></li>
                            <li class="page-item"><a class="page-link" href="#" style="color: black; background-color: darkgrey;">3</a></li>
                            <li class="page-item"><a class="page-link" href="#" style="color: black; background-color: darkgrey;">Next</a></li>
                        </ul>
                    </nav>
                </div>

            </div>
        </div>
    </form>
    <script>
        $(document).ready(function () {
            //列出所有
            function BuildTable() {
                $.ajax({
                    url: "/API/GetALLList.ashx",
                    method: "GET",
                    dataType: "JSON",
                    success: function (objDataList) {
                        console.log(objDataList);

                        var rowsText = `<thead>
                                <table class="table table-dark table-striped">
                        <thead>
                            <tr>
                                <th scope="col"></th>
                                <th scope="col">#</th>
                                <th scope="col">問卷</th>
                                <th scope="col">狀態</th>
                                <th scope="col">開啟時間</th>
                                <th scope="col">結束時間</th>
                                <th scope="col">觀看統計</th>
                            </tr>
                        </thead>`;
                        for (var item of objDataList) {
                            rowsText +=
                                `  
                        <tbody>
                            <tr>
                                <td><input type="radio" id="selectBtn" name="selectBtn" value="selectBtn" /></td>
                                <td>${item.Number}</td>
                                <td> <a href="https://www.google.com/?hl=zh_tw">${item.Title}</a> </td>
                                <td> ${item.StatusList} </td>
                                <td> ${item.StartTime_string} </td>
                                <td> ${item.EndTime} </td>
                                <td><a href="https://www.google.com/?hl=zh_tw">google</a></td>
                                <td><input type="hidden" class="hfID" name="hfID" value="${item.ID}"></td>
                                  
                            </tr>
                        </tbody>
              
                        `;
                        }
                        $("#summarizing").empty();
                        $("#summarizing").append("<table>" + rowsText + "</table>");
                    },
                    error: function (msg) {
                        console.log(msg);
                        alert("通訊失敗，請聯絡管理員。");
                    }
                });
            }
            BuildTable()

            //搜尋
            $("#btnsearch").click(function () {
                var title = $("input[placeholder='請輸入問卷標題'").val().trim();
                var time_start = $("#txtCalender_start").val();
                var time_end = $("#txtCalender_end").val();
                var ID = $("#hfID").val();
                if (title == "") {
                    alert("您未輸入任何標題文字，所以幫您選出日期內所有問卷");
                   /* return false;*/
                }
    
                $.ajax({
                    url: "/API/GetList.ashx",
                    method: "GET",
                    data: {

                        "Title": title,
                        "Time_Start": time_start,
                        "Time_End": time_end
                    },
                    dataType: "JSON",
                    success: function (objDataList) {
                        //alert(time_start)
                        //alert(time_end)
                        console.log(objDataList);

                        var rowsText = `<thead>
                                <table class="table table-dark table-striped">
                        <thead>
                            <tr>
                                <th scope="col"></th>
                                <th scope="col">#</th>
                                <th scope="col">問卷</th>
                                <th scope="col">狀態</th>
                                <th scope="col">開啟時間</th>
                                <th scope="col">結束時間</th>
                                <th scope="col">觀看統計</th>
                            </tr>
                        </thead>`;
                        for (var item of objDataList) {
                            rowsText +=
                                `  
                        <tbody>
                            <tr>
                                <td><input type="radio" id="selectBtn" name="selectBtn" value="selectBtn" /></td>
                                <td>${item.Number}</td>
                                <td> <a href="https://www.google.com/?hl=zh_tw">${item.Title}</a> </td>
                                <td> ${item.StatusList} </td>
                                <td> ${item.StartTime_string} </td>
                                <td> ${item.EndTime} </td>
                                <td><a href="https://www.google.com/?hl=zh_tw">google</a></td>
                                <td><input type="hidden" class="hfID" name="hfID" value="${item.ID}"></td>
                                  
                            </tr>
                        </tbody>
              
                        `;
                        }
                        $("#summarizing").empty();
                        $("#summarizing").append("<table>" + rowsText + "</table>");
                    },
                    error: function (msg) {
                        console.log(msg);
                        alert("通訊失敗，請聯絡管理員。");
                    }
                });
            });

            //日期搜尋
            //$("#btnsearch").click(function () {
            //    var time = $("input[placeholder='請輸入問卷標題'").val();
            //    var ID = $("#hfID").val();
            //    $.ajax({
            //        url: "/API/GetList.ashx",
            //        method: "GET",
            //        data: {

            //            "Title": title
            //        },
            //        dataType: "JSON",
            //        success: function (objDataList) {

            //            console.log(objDataList);

            //            var rowsText = `<thead>
            //                    <table class="table table-dark table-striped">
            //            <thead>
            //                <tr>
            //                    <th scope="col"></th>
            //                    <th scope="col">#</th>
            //                    <th scope="col">問卷</th>
            //                    <th scope="col">狀態</th>
            //                    <th scope="col">開啟時間</th>
            //                    <th scope="col">結束時間</th>
            //                    <th scope="col">觀看統計</th>
            //                </tr>
            //            </thead>`;
            //            for (var item of objDataList) {
            //                rowsText +=
            //                    `  
            //            <tbody>
            //                <tr>
            //                    <td><input type="radio" id="selectBtn" name="selectBtn" value="selectBtn" /></td>
            //                    <td>${item.Number}</td>
            //                    <td> <a href="https://www.google.com/?hl=zh_tw">${item.Title}</a> </td>
            //                    <td> ${item.StatusList} </td>
            //                    <td> ${item.StartTime_string} </td>
            //                    <td> ${item.EndTime} </td>
            //                    <td><a href="https://www.google.com/?hl=zh_tw">google</a></td>
            //                    <td><input type="hidden" class="hfID" name="hfID" value="${item.ID}"></td>

            //                </tr>
            //            </tbody>

            //            `;
            //            }
            //            $("#summarizing").empty();
            //            $("#summarizing").append("<table>" + rowsText + "</table>");
            //        },
            //        error: function (msg) {
            //            console.log(msg);
            //            alert("通訊失敗，請聯絡管理員。");
            //        }
            //    });
            //});


            //跳頁














        })

    </script>
</body>
</html>
