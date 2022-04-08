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

        //找出問卷內容 ㄎㄎ
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



        //列出搜尋結果
        public List<ListModel> FindList(string title,string time_start , string time_end)
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


    }
}