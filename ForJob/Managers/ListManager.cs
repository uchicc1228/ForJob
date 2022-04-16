using ForJob.Helpers;
using ForJob.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ForJob.Managers
{
    public class ListManager
    {
        ListModel _model = new ListModel();

        //列出問卷內容 ㄎㄎ
        public List<ListModel> GetAllList()
        {
            List<ListModel> list = new List<ListModel>();

            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                @"  SELECT *
                    FROM Questionary
                    ORDER BY [QNumber] DESC;";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
                        conn.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            ListModel model = new ListModel()
                            {
                                ID = (Guid)reader["QID"],
                                Number = (int)reader["QNumber"],
                                Title = reader["QTitle"] as string,
                                StartTime = (DateTime)reader["QStartTime"],
                                EndTime = reader["QEndTime"] as string,
                                StatusList = reader["QStatus"] as string,
                                Content = reader["QContent"] as string,
                                QuestionUrl =reader["QuestionUrl"] as string,
                                QuestionEditUrl = reader["QuestionEditUrl"] as string,

                            };
                            model.StartTime_string = model.StartTime.ToString("yyyy/MM/dd");

                            if (string.IsNullOrEmpty(model.EndTime))
                            {
                                model.EndTime = "-";
                            }

                            list.Add(model);
                        }
                        return list;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

        //列出題目內容資訊 table Question
        public List<ListModel> GetQuestionModel(Guid id)
        {
            
            List<ListModel> list = new List<ListModel>();

            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                @"  SELECT *
                    FROM Question
                    WHERE QID = @QID";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {


                        command.Parameters.AddWithValue("@QID", id);
                        conn.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            ListModel model = new ListModel()
                            {
                                ID = (Guid)reader["QID"],
                                QuestionID = (Guid)reader["QuestionID"],
                                Number = (int)reader["QNumber"],
                                Question = reader["QQuestion"] as string,
                                Answer = reader["QAnswer"] as string,/////////////QAnswer split !
                                QIsNecessary = reader["QIsNecessary"] as string,
                                QQMode = reader["QQMode"] as string,
                                QCatrgory = reader["QCatrgory"] as string
                            };
                            list.Add(model);
                           
                        }

                        
                        return list;
                    }

                }
            }
            catch (Exception ex)
            {
              
                return null;
            }


        }

        //列出問卷內容資訊 table Questionary
        public ListModel GetQuestionaryModel(Guid id)
        {
           
            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                @"  SELECT *
                    FROM Questionary
                    WHERE QID = @QID";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {


                        command.Parameters.AddWithValue("@QID", id);
                        conn.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            ListModel model = new ListModel()
                            {
                                ID = (Guid)reader["QID"],
                                Title = reader["QTitle"] as string,
                                Content = reader["QContent"] as string,
                                StatusList = reader["QStatus"] as string,
                                StartTime = (DateTime)reader["QStartTime"] ,
                                EndTime = reader["QEndTime"] as string,
                                Number = (int)reader["QNumber"],
                                QuestionUrl = reader["QuestionUrl"] as string,
                            };

                            return model;
                        }


                        return null;
                    }

                }
            }
            catch (Exception ex)
            {
                return null;
            }


        }

        public ListModel GetAllQuestionOnUsweQuestion(Guid id)
        {
           

            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                @"  SELECT *
                    FROM Question
                    WHERE QID = @QID";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {

                        command.Parameters.AddWithValue("@QID", id);
                        conn.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            ListModel model = new ListModel()
                            {
                                ID = (Guid)reader["QID"],
                                QuestionID = (Guid)reader["QTitle"],
                                Number = (int)reader["QNumber"],
                                Question = reader["QQuestion"] as string,
                                Answer = reader["QAnswer"] as string,
                                QIsNecessary = reader["QIsNecessary"] as string,
                                QQMode = reader["QQMode"] as string,
                                QCatrgory = reader["QCatrgory"] as string,
                            };
                            return model;
                           
                        }
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

        public List<ListModel> GetOneList(Guid id)
        {
            List<ListModel> list = new List<ListModel>();

            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                @"  SELECT *
                    FROM Questionary
                    WHERE QID = @QID";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {


                        command.Parameters.AddWithValue("@QID", id);
                        conn.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            ListModel model = new ListModel()
                            {
                                ID = (Guid)reader["QID"],
                                Number = (int)reader["QNumber"],
                                Title = reader["QTitle"] as string,
                                StartTime = (DateTime)reader["QStartTime"],
                                EndTime = reader["QEndTime"] as string,
                                StatusList = reader["QStatus"] as string,
                                Content = reader["QContent"] as string,
                                QuestionUrl = reader["QuestionUrl"] as string
                            };
                            model.StartTime_string = model.StartTime.ToString("yyyy/MM/dd");

                            if (string.IsNullOrEmpty(model.EndTime))
                            {
                                model.EndTime = "-";
                            }
                            list.Add(model);
                        }
                        return list;
                    }

                }
            }
            catch (Exception ex)
            {
                return null;
            }


        }

        public bool DeleteQuestionary(Guid id)
        {

            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                @" Delete from questionary where	QID = @QID";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {

                        command.Parameters.AddWithValue("@QID", id);

                        conn.Open();

                        command.ExecuteNonQuery();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }

        public bool CreateQuestionMember(ListModel model)
        {

            // 2. 新增資料
            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                @" 
                    INSERT INTO UserManager
                        (QID, QTitle, QContent ,QStatus, QStartTime, QEndTime, QuestionUrl,QuestionEditUrl)
                    VALUES
                        (@QID, @QTitle , @QContent, @QStatus, @QStartTime, @QEndTime, @QuestionUrl,@QuestionEditUrl);";




            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {


                        command.Parameters.AddWithValue("@QID", model.ID);
                        command.Parameters.AddWithValue("@QTitle", model.Title);
                        command.Parameters.AddWithValue("@QContent", model.Content);
                        command.Parameters.AddWithValue("@QStatus", model.StatusList);
                        command.Parameters.AddWithValue("@QStartTime", model.StartTime);
                        command.Parameters.AddWithValue("@QEndTime", model.EndTime);
                        command.Parameters.AddWithValue("@QuestionUrl", model.QuestionUrl);
                        command.Parameters.AddWithValue("@QuestionEditUrl", model.QuestionEditUrl);

                        conn.Open();
                        command.ExecuteNonQuery();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {


                return false;
            }
        }

        public List<ListModel> FindList(string title, string time_start, string time_end)
        {

            List<ListModel> list = new List<ListModel>();

            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
               @"select * from Questionary where QTitle like  '%' + @title + '%' and 
                    [QStartTime] >= @QStartTime
                    and [QEndTime] <=   @QEndTime
                    ORDER BY [QNumber] DESC";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {

                        command.Parameters.AddWithValue("@title", title);
                        command.Parameters.AddWithValue("@QStartTime", time_start);
                        command.Parameters.AddWithValue("@QEndTime", time_end);

                        conn.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            ListModel model = new ListModel()
                            {
                                ID = (Guid)reader["QID"],
                                Number = (int)reader["QNumber"],
                                Title = reader["QTitle"] as string,
                                StartTime = (DateTime)reader["QStartTime"],
                                EndTime = reader["QEndTime"] as string,
                                StatusList = reader["QStatus"] as string,
                                Content = reader["QContent"] as string,
                            };
                            model.StartTime_string = model.StartTime.ToString("yyyy/MM/dd");
                            if (string.IsNullOrEmpty(model.EndTime))
                            {
                                model.EndTime = "-";
                            }

                            list.Add(model);

                        }
                        return list;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }


        //用日期列出搜尋結果
        public List<ListModel> FindListTime(string time_start, string time_end)
        {

            List<ListModel> list = new List<ListModel>();

            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
               @"SELECT *
                    From Questionary
                    where [QStartTime] >= @QStartTime
                    and [QEndTime] <=   @QEndTime 
                    ORDER BY [QNumber] DESC";

            //if (string.IsNullOrEmpty(time_end))
            //{
            //    string commandText2 =
            //     @"SELECT *
            //        From Questionary
            //        where [QStartTime] >= @QStartTime ";
            //       commandText += commandText2;

            //}


            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {

                        command.Parameters.AddWithValue("@QStartTime", time_start);
                        command.Parameters.AddWithValue("@QEndTime", time_end);

                        conn.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            ListModel model = new ListModel()
                            {
                                ID = (Guid)reader["QID"],
                                Number = (int)reader["QNumber"],
                                Title = reader["QTitle"] as string,
                                StartTime = (DateTime)reader["QStartTime"],
                                EndTime = reader["QEndTime"] as string,
                                StatusList = reader["QStatus"] as string,
                                Content = reader["QContent"] as string,
                            };
                            model.StartTime_string = model.StartTime.ToString("yyyy/MM/dd");
                            if (string.IsNullOrEmpty(model.EndTime))
                            {
                                model.EndTime = "-";
                            }

                            list.Add(model);

                        }
                        return list;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

        #region"分頁"
        //分頁
        public List<ListModel> Pafination(string time_start, string time_end, int pageSize, int pageIndex)
        {
            List<ListModel> list = new List<ListModel>();
            int skip = pageSize * (pageIndex - 1);  // 計算跳頁數
            if (skip < 0)
                skip = 0;

            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                $@"SELECT TOP  {(pageSize)}  *
                    FROM Questionary 
                     WHERE    QNumber not IN 
                          (
                             SELECT TOP {(skip)}  QNumber
                             FROM Questionary     		    
	                   		 WHERE QNumber IN 
	                   		 ( SELECT QNumber FROM Questionary
	                   		    where [QStartTime] >= @QStartTime
                                and [QEndTime] <=  @QEndTime )
	                   									           ORDER BY QNumber DESC)	  		   
                                                                                                  
	                   	     and  [QStartTime] >= @QStartTime
                             and [QEndTime] <=    @QEndTime	
	                   		 ORDER BY QNumber DESC;   ";

            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
                        command.Parameters.AddWithValue("@QStartTime", time_start);
                        command.Parameters.AddWithValue("@QEndTime", time_end);

                        conn.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        List<ListModel> retList = new List<ListModel>();    // 將資料庫內容轉為自定義型別清單
                        while (reader.Read())
                        {
                            ListModel model = new ListModel()
                            {
                                ID = (Guid)reader["QID"],
                                Number = (int)reader["QNumber"],
                                Title = reader["QTitle"] as string,
                                StartTime = (DateTime)reader["QStartTime"],
                                EndTime = reader["QEndTime"] as string,
                                StatusList = reader["QStatus"] as string,
                                Content = reader["QContent"] as string,
                            };
                            model.StartTime_string = model.StartTime.ToString("yyyy/MM/dd");
                            if (string.IsNullOrEmpty(model.EndTime))
                            {
                                model.EndTime = "-";
                            }
                            list.Add(model);

                        }
                        return list;
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        //有標題的分頁
        public List<ListModel> PafinationHasTitle(string title, string time_start, string time_end, int pageSize, int pageIndex)
        {
            List<ListModel> list = new List<ListModel>();
            int skip = pageSize * (pageIndex - 1);  // 計算跳頁數
            if (skip < 0)
                skip = 0;

            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                $@"SELECT TOP  {(pageSize)}  *
                    FROM Questionary 
                     WHERE    QNumber not IN 
                          (
                             SELECT TOP {(skip)}  QNumber
                             FROM Questionary     		    
	                   		 WHERE QNumber IN 
	                   		 ( SELECT QNumber FROM Questionary
	                   		    where  QTitle like  '%' + @Qtitle + '%' and 
                                [QStartTime] >= @QStartTime
                                and [QEndTime] <=  @QEndTime )
	                   									           ORDER BY QNumber DESC)	 
                             and  [QTitle] like   '%' + @Qtitle +'%'                                                                   
	                   	     and  [QStartTime] >= @QStartTime
                             and [QEndTime] <=    @QEndTime	
	                   		 ORDER BY QNumber DESC;   ";

            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
                        command.Parameters.AddWithValue("@QStartTime", time_start);
                        command.Parameters.AddWithValue("@QEndTime", time_end);
                        command.Parameters.AddWithValue("@Qtitle", title);

                        conn.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        List<ListModel> retList = new List<ListModel>();    // 將資料庫內容轉為自定義型別清單
                        while (reader.Read())
                        {
                            ListModel model = new ListModel()
                            {
                                ID = (Guid)reader["QID"],
                                Number = (int)reader["QNumber"],
                                Title = reader["QTitle"] as string,
                                StartTime = (DateTime)reader["QStartTime"],
                                EndTime = reader["QEndTime"] as string,
                                StatusList = reader["QStatus"] as string,
                                Content = reader["QContent"] as string,
                            };
                            model.StartTime_string = model.StartTime.ToString("yyyy/MM/dd");
                            if (string.IsNullOrEmpty(model.EndTime))
                            {
                                model.EndTime = "-";
                            }
                            list.Add(model);

                        }
                        return list;
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        #endregion"分頁"


        #region "創立問卷資訊、找出問卷"

        //找出是否有相同標題之問卷
        public ListModel GetAccount(string title)
        {
            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                 @" SELECT *
                    FROM Questionary
                    WHERE QTitle = @QTitle";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
                        command.Parameters.AddWithValue("@QTitle", title);

                        conn.Open();

                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            ListModel model = new ListModel()
                            {
                                ID = (Guid)reader["QID"],
                                Number = (int)reader["QNumber"],
                                Title = reader["QTitle"] as string,
                                StartTime = (DateTime)reader["QStartTime"],
                                EndTime = reader["QEndTime"] as string,
                                StatusList = reader["QStatus"] as string,
                                Content = reader["QContent"] as string,

                            };
                            return model;

                        }

                        return null;
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }



        //找出是否有相同GUID之問卷
        public ListModel GetAccount(Guid ID)
        {
            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                 @" SELECT *
                    FROM Questionary
                    WHERE QID = @QID";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
                        command.Parameters.AddWithValue("@QID", ID);

                        conn.Open();

                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            ListModel model = new ListModel()
                            {
                                ID = (Guid)reader["QID"],
                                Number = (int)reader["QNumber"],
                                Title = reader["QTitle"] as string,
                                StartTime = (DateTime)reader["QStartTime"],
                                EndTime = reader["QEndTime"] as string,
                                StatusList = reader["QStatus"] as string,
                                Content = reader["QContent"] as string,

                            };
                            return model;

                        }

                        return null;
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        //創建問卷
        public bool CreateQuestionary(ListModel model)
        {

            // 2. 新增資料
            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                @" 
                    INSERT INTO Questionary
                        (QID, QTitle, QContent ,QStatus, QStartTime, QEndTime, QuestionUrl,QuestionEditUrl)
                    VALUES
                        (@QID, @QTitle , @QContent, @QStatus, @QStartTime, @QEndTime, @QuestionUrl,@QuestionEditUrl);";




            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {


                        command.Parameters.AddWithValue("@QID", model.ID);
                        command.Parameters.AddWithValue("@QTitle", model.Title);
                        command.Parameters.AddWithValue("@QContent", model.Content);
                        command.Parameters.AddWithValue("@QStatus", model.StatusList);
                        command.Parameters.AddWithValue("@QStartTime", model.StartTime);
                        command.Parameters.AddWithValue("@QEndTime", model.EndTime);
                        command.Parameters.AddWithValue("@QuestionUrl",model.QuestionUrl);
                        command.Parameters.AddWithValue("@QuestionEditUrl", model.QuestionEditUrl);

                        conn.Open();
                        command.ExecuteNonQuery();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {


                return false;
            }
        }


        //創建問題
        public bool CreateQuestion(ListModel model)
        {
            model.QuestionID = Guid.NewGuid();
            // 2. 新增資料
            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                @" 
                    INSERT INTO Question
                        (QID, QuestionID, QQuestion, QAnswer, QIsNecessary ,QQMode, QCatrgory)
                    VALUES
                        (@QID, @QuestionID, @QQuestion, @QAnswer, @QIsNecessary, @QQMode , @QCatrgory);"  
                                                        
                                                        +
                @"INSERT INTO UserManager 
                        (QuestionID)
                  VALUES 
                        (@QuestionID)";




            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {

                        command.Parameters.AddWithValue("@QID", model.ID);
                        command.Parameters.AddWithValue("@QuestionID", model.QuestionID);
                        command.Parameters.AddWithValue("@QQuestion", model.Question);
                        command.Parameters.AddWithValue("@QAnswer", model.Answer);
                        command.Parameters.AddWithValue("@QIsNecessary", model.QIsNecessary);
                        command.Parameters.AddWithValue("@QQMode", model.QQMode);
                        command.Parameters.AddWithValue("@QCatrgory", model.QCatrgory);
                        //command.Parameters.AddWithValue("@QNumber", model.Number);

                        conn.Open();
                        command.ExecuteNonQuery();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {


                return false;
            }
        }

        //找出該ID所有問題
        public List<ListModel> GetAllQuestion(Guid ID)
        {
            List<ListModel> list = new List<ListModel>();

            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                @"  SELECT *
                    FROM Question
                    WHERE QID  =  @QID
                    ORDER BY [QNumber] DESC;";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
                        command.Parameters.AddWithValue("@QID", ID);
                        conn.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            ListModel model = new ListModel()
                            {
                                ID = (Guid)reader["QID"],
                                Question = reader["QQuestion"] as string,
                                QQMode = reader["QQMode"] as string,
                                QIsNecessary = reader["QIsNecessary"] as string,
                                Number = (int)reader["QNumber"],
                                QuestionID = (Guid)reader["QuestionID"]
                            };

                            list.Add(model);
                        }
                        return list;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }


        //找出問卷資訊

        public ListModel GetAllQuestionInfo(Guid ID)
        {
            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                @"  SELECT *
                    FROM Question
                    WHERE QID  =  @QID
                    ORDER BY [QNumber] DESC;";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
                        command.Parameters.AddWithValue("@QID", ID);
                        conn.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            ListModel model = new ListModel()
                            {
                                ID = (Guid)reader["QID"],
                                Question = reader["QQuestion"] as string,
                                QQMode = reader["QQMode"] as string,
                                QIsNecessary = reader["QIsNecessary"] as string,
                                QCatrgory = reader["QCatrgory"] as string,
                                Number = (int)reader["QNumber"],
                                Answer = reader["QAnswer"] as string
                            };

                            return model;
                        }
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }
        public ListModel GetAllQuestionInfo(ListModel model)
        {
            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                @"  SELECT *
                    FROM Question
                    WHERE QID  =  @QID and
                    QNumber = @QNumber;";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
                        command.Parameters.AddWithValue("@QID", model.ID);
                        command.Parameters.AddWithValue("@QNumber", model.Number);
                        conn.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {

                            model.ID = (Guid)reader["QID"];
                            model.Question = reader["QQuestion"] as string;
                            model.QQMode = reader["QQMode"] as string;
                            model.QIsNecessary = reader["QIsNecessary"] as string;
                            model.QCatrgory = reader["QCatrgory"] as string;
                            model.Number = (int)reader["QNumber"];
                            model.Answer = reader["QAnswer"] as string;
                            return model;
                        }
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

        //變更問卷資訊的方法

        public bool UpdateQuestion(ListModel model)
        {

            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                @"  UPDATE Question
                    SET 
                        QQuestion = @QQuestion,
                        QAnswer = @QAnswer,
                        QIsNecessary = @QIsNecessary,
                        QQMode = @QQMode,
                        QCatrgory = @QCatrgory                           
                    WHERE
                        QID = @id  and
                        QNumber = @QNumber";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {


                        command.Parameters.AddWithValue("@id", model.ID);
                        command.Parameters.AddWithValue("@QQuestion", model.Question);
                        command.Parameters.AddWithValue("@QAnswer", model.Answer);
                        command.Parameters.AddWithValue("@QIsNecessary", model.QIsNecessary);
                        command.Parameters.AddWithValue("@QQMode", model.QQMode);
                        command.Parameters.AddWithValue("@QCatrgory", model.QCatrgory);
                        command.Parameters.AddWithValue("@QNumber", model.Number);
                        conn.Open();

                        command.ExecuteNonQuery();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }


        //刪除問題
        public bool DeleteQuestion(ListModel model)
        {

            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                @" Delete from question where	QuestionID = @QuestionID";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {



                        command.Parameters.AddWithValue("@QuestionID", model.QuestionID);

                        conn.Open();

                        command.ExecuteNonQuery();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }
        #endregion








    }
}