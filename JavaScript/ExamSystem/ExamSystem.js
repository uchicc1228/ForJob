$(document).ready(function () {
    //正確數
    var right = 0;
    //題目進程
    var scheddule = 0;
    //判斷為考題或解答畫面
    var IsExam = false;
    //題目資料
    var examDataList;
    //使用者答案
    var userAnswer = "";
    //正確答案
    var examAnswer = "";
    //初次試驗
    //初次試驗進程
    var theFirstExamScheddule = -1;
    //正確和錯誤次數，如果連續錯2次等急就會變動
    var theFirstExamSuccess = 0;
    var theFirstExamError = 0;


    //確定考題等級、模式
    if (IsTheFirstExam) {
        theFirstExamScheddule = -1;
        TestLevel = 3;
        IsExam = false;
        TheFirstExamWelcom();
    }
    else if (userPoint >= 100 && userLevel != 1 && IsChalleng === true) {
        TestLevel = userLevel - 1;
        scheddule = -1;
        LevelUpMsg();
    } else if (IsChalleng === true) {
        TestLevel = userLevel;
        scheddule = 0;
        IsExam = true;
        StartExam();
    } else {

        scheddule = -1;
        ChoiseLevel();
    }


    function LevelUpMsg() {
        var rowsText = ` <div style="height:100%; text-align:center; line-height:300px; font-size:30pt;">
                                    積分已達標準，開始向下一階段的挑戰!
                                 </div>`;
        $("#divQuestion").empty();
        $("#divQuestion").append(rowsText);

        $("#divOption").empty();

    }
    //使用者自選等級
    function ChoiseLevel() {
        var lvOpt = "";
        for (var i = userLevel; i < 6; i++) {
            lvOpt += `<li>
                        <label>
                            <input type="radio" name="option" value="${i}" checked="checked" /><span class="round btnOption">N ${i}</span>
                        </label>
                    </li>`;
        }
        var qusText =
            `
            
            `;
        var optText =
            `<div id="divChoiseLevel">
            <ul>
                <li>
                    <label>
                        <h2>請選擇想練習的等級</h2>
                    </label>
                </li>
                ${lvOpt}
            </ul>
            </div>`;
        $("#divQuestion").empty();
        $("#divQuestion").append(qusText);

        $("#divOption").empty();
        $("#divOption").append(optText);

    }

    //點擊下一步
    $("#btnSure").click(function () {
        var note = document.getElementById("btnNote");
        var msgBoard = document.getElementById("btnMsgBoard");

        if (theFirstExamScheddule > 9 || scheddule > TestCount - 1) {
            window.location.href = "../AfterLogin/Index.aspx";
        } else if (IsExam === false && theFirstExamScheddule > 8 || scheddule > TestCount - 2) {
            //判斷看完解答&作完所有題目
            if (IsTheFirstExam) {
                //初次試驗進程
                userLevel = TestLevel;
                TheFirstExamSettlement();
            }
            else if (IsChalleng) {
                Settlement();
            } else {
                SettlementNoRecord();
            }
            note.style.visibility = "hidden";
            msgBoard.style.visibility = "hidden";
            scheddule += 1;
            theFirstExamScheddule += 1;
        } else if (IsExam === false && scheddule === -1 && IsTheFirstExam === false) {
            //升級提示or選擇等級(練習模式)
            scheddule += 1;
            IsExam = true;
            //判斷為挑戰或練習模式
            if (IsChalleng === false) {
                var choisedLevel = $("[name='option']:checked").val();
                TestLevel = choisedLevel;
            }
            StartExam();
        }
        else if (IsExam === false) {
            //看完解答、升級挑戰等提示
            IsExam = true;
            note.style.visibility = "hidden";
            msgBoard.style.visibility = "hidden";
            if (IsTheFirstExam && theFirstExamScheddule === -1) {
                //初次試驗進程看完歡迎文字後
                TheFirstStartExam();
            }
            else if (IsTheFirstExam) {
                //初次試驗進程
                theFirstExamScheddule += 1;
                scheddule = theFirstExamScheddule + (TestLevel - 1) * 10;
                NextQuestion();
            } else {
                //練習、挑戰模式
                scheddule += 1;
                NextQuestion();
            }

        } else {
            //做完這一題
            IsExam = false;
            userAnswer = $("[name='option']:checked").val();
            examAnswer = examDataList[scheddule].TestAnswer.trim();
            //判斷正確與否
            if (IsTheFirstExam) {
                //初次試驗進程
                if (userAnswer === examAnswer) {
                    theFirstExamSuccess += 1;
                    theFirstExamError = 0;
                    right += 1;
                } else {
                    theFirstExamSuccess = 0;
                    theFirstExamError += 1;
                }
                //難度浮動
                if (theFirstExamSuccess > 1) {
                    //升級
                    theFirstExamSuccess = 0;
                    TestLevel = ((TestLevel - 1) === 0) ? 1 : (TestLevel - 1);
                } else if (theFirstExamError > 1) {
                    //降級
                    theFirstExamError = 0;
                    TestLevel = ((TestLevel + 1) === 6) ? 5 : (TestLevel + 1);
                }
            }
            else if (userAnswer === examAnswer) {
                //練習、挑戰模式
                right += 1;
            }
            SaveAnswer();
            note.style.visibility = "visible";
            msgBoard.style.visibility = "visible";
        }


    });

    //初次等級決定試驗歡迎文字
    function TheFirstExamWelcom() {
        var qusTextInDiv = `歡迎加入鮭魚的行列<br/>讓我們做個測試來判斷自己是個怎麼樣的鮭魚吧!`;

        var qusText =
            `<div style="height:100%; text-align:center; line-height:150px; font-size:30pt;">
                                ${qusTextInDiv}
                             </div>`;

        var optText =
            `<div style="text-align:center;">
                                 
                                 
                              </div>
                             `;

        $("#divQuestion").empty();
        $("#divQuestion").append(qusText);

        $("#divOption").empty();
        $("#divOption").append(optText);
    }
    //初次等級決定試驗
    function TheFirstStartExam() {
        var postData = {
            "TestCount": TestCount,
            "UserID": userID
        };
        $.ajax({
            url: "../API/ExamSystemHandler.ashx?Exam=FirstStart",
            method: "POST",
            data: postData,
            dataType: "JSON",
            success: function (objDataList) {
                examDataList = objDataList;
                theFirstExamScheddule += 1;
                scheddule = theFirstExamScheddule + (TestLevel - 1) * 10;
                TestCount = 50;
                userFinalLevel = TestLevel;
                NextQuestion();
            },
            error: function (msg) {
                console.log(msg);
                alert("連線失敗，請聯絡管理員。");
            }
        });
    }

    //正式進入考試畫面，獲取資料
    function StartExam() {
        var postData = {
            "TestLevel": TestLevel,
            "TestCount": TestCount,
            "UserID": userID,
            "IsChalleng": IsChalleng
        };
        $.ajax({
            url: "../API/ExamSystemHandler.ashx?Exam=Start",
            method: "POST",
            data: postData,
            dataType: "JSON",
            success: function (objDataList) {
                examDataList = objDataList;
                NextQuestion();
            },
            error: function (msg) {
                console.log(msg);
                alert("連線失敗，請聯絡管理員。");
            }
        });
    }
    //將使用者答案存入資料庫
    function SaveAnswer() {
        var examData = examDataList[scheddule];
        var postData = {
            "UserID": userID,
            "TestID": examData.TestID,
            "UserAnswer": userAnswer,
            "UserNote": examData.UserNote,
            "IsNew": ((examData.UserAnswer != null) ? false : true)
        };
        $.ajax({
            url: "../API/ExamSystemHandler.ashx?Exam=SaveAnswer",
            method: "POST",
            data: postData,
            success: function (objDataList) {
                BuildAnswer();
            },
            error: function (msg) {
                console.log(msg);
                alert("連線失敗，請聯絡管理員。");
            }
        });
    };

    //從解答、升級提示切換為考題
    function NextQuestion() {
        var examData = examDataList[scheddule];
        var qusText =
            `
                                <h4>${examData.TypeContext}</h4>
                                <h2>${examData.TestContent}</h2>
                            `;
        var optText =
            `
                                <ul class="nav justify-content-center">
                                    <li class="nav-item">
                                        <label>
                                            <input type="radio" name="option" value="A" checked="checked" /><span id="A" class="round btnOption">A.${examData.OptionsA}</span>
                                        </label>
                                    </li>
                                    <li class="nav-item">
                                        <label>
                                            <input type="radio" name="option" value="B" checked="checked" /><span id="B" class="round btnOption">B.${examData.OptionsB}</span>
                                        </label>
                                    </li>
                                    <li class="nav-item">
                                        <label>
                                            <input type="radio" name="option" value="C" checked="checked" /><span id="C" class="round btnOption">C.${examData.OptionsC}</span>
                                        </label>
                                    </li>
                                    <li class="nav-item">
                                        <label>
                                            <input type="radio" name="option" value="D" checked="checked" /><span id="D" class="round btnOption">D.${examData.OptionsD}</span>
                                        </label>
                                    </li>
                                </ul>
                            `;
        $("#divQuestion").empty();
        $("#divQuestion").append(qusText);

        $("#divOption").empty();
        $("#divOption").append(optText);


    };
    //從考題切換為解答
    function BuildAnswer() {
        var examData = examDataList[scheddule];
        //帶入文正解文字資訊
        var examAnswerText = document.getElementById(`${examAnswer}`).textContent;
        var userAnswerText = document.getElementById(`${userAnswer}`).textContent;
        //正確/錯誤
        var ansText = "正確";
        //判斷使用者答案正確與否

        //編輯顯示字串
        var qusText =
            `
                                <h4>${examData.TypeContext}</h4>
                                <h2>${examData.TestContent}</h2>
                            `;
        var optText =
            `
                                <ul class="nav justify-content-center">
                                    
                                    <li class="nav-item">
                                        <p class="nav-link disabled">正確答案為 : ${examAnswerText}</p>
                                    </li>
                                    <li class="nav-item">
                                        <p class="nav-link disabled">選擇答案為 : ${userAnswerText}</p>
                                    </li>
                                   
                                </ul>
                                
                            `;
        $("#divQuestion").empty();
        $("#divQuestion").append(qusText);

        $("#divOption").empty();
        $("#divOption").append(optText);

    };

    //成果結算畫面
    function Settlement() {
        var point = right * 2;
        var money = right * 3;

        var postData = {
            "UserID": userID,
            "Correct": right,
            "UserLevel": userLevel,
            "Point": point,
            "UserPoints": userPoint,
            "Money": money
        };
        $.ajax({
            url: "../API/ExamSystemHandler.ashx?Exam=Settlement",
            method: "POST",
            data: postData,
            success: function (objDataList) {
                var qusTextInDiv = "";
                if (userLevel > 1 && userPoint >= 90 && point > 10) {
                    qusTextInDiv = `升級挑戰成功 ! 從今天起就是 N${userLevel - 1} 級的鮭魚了!`;
                    point = 10;
                } else if (userLevel > 1 && userPoint >= 90 && point < 10) {
                    qusTextInDiv = `升級挑戰失敗!`;
                } else {
                    qusTextInDiv = "挑戰結束!";
                }
                var qusText =
                    `<div style="height:100%; text-align:center; line-height:300px; font-size:30pt;">
                                ${qusTextInDiv}
                             </div>`;

                var optText =
                    `<div style="text-align:center;">
                                 <p>答對題數 : ${right} / ${TestCount} 題</p>
                                 <p>獲得積分 : ${point - 10} 分</P>
                                 <p>獲得金幣 : ${money} 個</P>
                              </div>
                             `;

                $("#divQuestion").empty();
                $("#divQuestion").append(qusText);

                $("#divOption").empty();
                $("#divOption").append(optText);

            },
            error: function (msg) {
                console.log(msg);
                alert("連線失敗，請聯絡管理員。");
            }
        });

    };
    //不計分成果結算畫面
    function SettlementNoRecord() {
        var qusText =
            `<div style="height:100%; text-align:center; line-height:300px; font-size:30pt;">
                N ${TestLevel} 考題練習<br/>
                練習結束!
            </div>`;

        var optText =
            `<div style="text-align:center;">
                <p>答對題數 : ${right} / ${TestCount} 題</p>
             </div>
            `;

        $("#divQuestion").empty();
        $("#divQuestion").append(qusText);

        $("#divOption").empty();
        $("#divOption").append(optText);
    }

    //初次試驗成果結算畫面
    function TheFirstExamSettlement() {
        var point = 0;
        var money = right;

        var postData = {
            "UserID": userID,
            "Correct": right,
            "UserLevel": userLevel,
            "Point": point,
            "UserPoints": userPoint,
            "Money": money
        };
        $.ajax({
            url: "../API/ExamSystemHandler.ashx?Exam=Settlement",
            method: "POST",
            data: postData,
            success: function (objDataList) {
                var qusTextInDiv = `試驗結束! 你是隻 ${userLevel} 級的鮭魚!!`;

                var qusText =
                    `<div style="height:100%; text-align:center; line-height:300px; font-size:30pt;">
                                ${qusTextInDiv}
                             </div>`;

                var optText =
                    `<div style="text-align:center;">
                                 <p>答對題數 : ${right} / 10 題</p>
                                 
                              </div>
                             `;

                $("#divQuestion").empty();
                $("#divQuestion").append(qusText);

                $("#divOption").empty();
                $("#divOption").append(optText);

            },
            error: function (msg) {
                console.log(msg);
                alert("連線失敗，請聯絡管理員。");
            }
        });
    }
    //筆記
    function BulidNote(testID, testContent) {
        var postData = {
            "userID": userID,
            "testID": testID
        }
        $.ajax({
            url: "../API/ExamReviewHandler.ashx?Action=Note",
            method: "POST",
            data: postData,
            dataType: "JSON",
            success: function (objData) {

                var noteTitle = `<h6> Q : <span id="noteTestContent">${testContent}</span></h6>`
                var noteContent = ` <textarea id="Note" rows="10" cols="50" style="resize: none;" placeholder="記錄自己的想法吧!">${objData.UserNote}</textarea>`;

                $("#divNote").empty();
                $("#divNote").append(noteContent);

                $("#divNoteTitle").empty();
                $("#divNoteTitle").append(noteTitle);

            },
            error: function (msg) {
                console.log(msg);
                alert("通訊失敗，請聯絡管理員。");
            }
        });

    };

    $("#btnNote").click(function () {
        var testID = examDataList[scheddule].TestID;
        var testContent = examDataList[scheddule].TestContent;
        BulidNote(testID, testContent);

    });
    $("#btnNoteSave").click(function () {
        var noteContent = document.getElementById("Note").value;
        var testContent = document.getElementById("noteTestContent").innerText;
        var postData = {
            "userID": userID,
            "testID": examDataList[scheddule].TestID,
            "UserNote": noteContent,
            "UserAnswer": userAnswer
        };
        $.ajax({
            url: "../API/ExamReviewHandler.ashx?Action=NoteWrite",
            method: "POST",
            data: postData,
            success: function () {
                alert("筆記已儲存");
                BulidNote(testID, testContent);

            },
            error: function (msg) {
                console.log(msg);
                alert("通訊失敗，請聯絡管理員。");
            }
        });
    });

    //留言板
    function BulidMsgBoard(testID, testContent) {
        $.ajax({
            url: "../API/ExamReviewHandler.ashx?Action=MsgBoard",
            method: "POST",
            data: { "testID": testID },
            dataType: "JSON",
            success: function (objDataList) {

                var msgTitle =
                    `<h5> Q : <span id="msgTestContent">${testContent}</span></h5>
                `;
                var msgContent = "";
                for (var item of objDataList) {
                    var msgDate = new Date(item.CreateDate);
                    msgDate = msgDate.toLocaleString();
                    msgContent +=
                        `
                                <div class="card mb-3" style="max-width: 540px;">
                                  <div class="row g-0">
                                    <div class="col-md-4">
                                      <img src="${item.Character}" class="img-fluid rounded-start" alt="失蹤的鮭魚...">
                                    </div>
                                    <div class="col-md-8">
                                      <div class="card-body">
                                        <h5 class="card-title">${item.UserName}<span style="font-size:8pt;">( N${item.UserLevel} )</span></h5>
                                        <p class="card-text">${item.MessageContent}</p>
                                        <p class="card-text"><small class="text-muted">${msgDate}</small></p>
                                      </div>
                                    </div>
                                  </div>
                                </div>
                                 `;
                }

                var msgWrite =
                    `<textarea id="txtMsgBoard" rows="4" cols="50" style="resize: none;" placeholder="留言分享自己的看法吧!"></textarea>`;

                $("#divMsgBoard").empty();
                $("#divMsgBoard").append(`<ul class="list - group list - group - flush">` + msgContent + "</ul >");

                $("#divMsgTitle").empty();
                $("#divMsgTitle").append(msgTitle);

                $("#divMsgWriteContent").empty();
                $("#divMsgWriteContent").append(msgWrite);

            },
            error: function (msg) {
                console.log(msg);
                alert("通訊失敗，請聯絡管理員。");
            }
        });

    }

    $("#btnMsgBoard").click(function () {
        var testID = examDataList[scheddule].TestID;
        var testContent = examDataList[scheddule].TestContent;
        BulidMsgBoard(testID, testContent);
    });

    $("#btnMsgWrite").click(function () {
        var msgWriteContent = document.getElementById("txtMsgBoard").value;
        var testContent = document.getElementById("msgTestContent").innerText;
        var postData = {
            "userID": userID,
            "testID": examDataList[scheddule].TestID,
            "msg": msgWriteContent
        };
        $.ajax({
            url: "../API/ExamReviewHandler.ashx?Action=MsgWrite",
            method: "POST",
            data: postData,
            success: function (txtMsg) {
                BulidMsgBoard(examDataList[scheddule].TestID, testContent);

            },
            error: function (msg) {
                console.log(msg);
                alert("通訊失敗，請聯絡管理員。");
            }
        });
    });

})