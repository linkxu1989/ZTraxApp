using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace ZTraxApp.Models
{
    public class EventService
    {
        public string ZTrax = ConfigurationManager.ConnectionStrings["ZTrax"].ConnectionString;

        public DataTable GetList(string command, string table)
        {
            SqlConnection sqlConnection = new SqlConnection(ZTrax);
            SqlCommand sqlCommand = new SqlCommand
            {
                CommandText = command,
                Connection = sqlConnection,
                CommandType = CommandType.Text
            };
            DataTable dt = new DataTable();
            try
            {
                if (sqlConnection.State != System.Data.ConnectionState.Open)
                {
                    sqlConnection.Open();
                }
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, table);
                dt = dataSet.Tables[table];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dt;
        }

        public List<Events> GetAll()
        {
            var command = @"SELECT ID,Description,TimeStamp,TypeOfEvent,Hostname,Location,TagID,AssetID,Name from ZebraTrax.dbo.EcrtCribEvents;";
            var table = @"EcrtCribEvents";
            List<Events> ObjEventsList = new List<Events>();
            DataTable dt = GetList(command, table);

            var items = (from t in dt.AsEnumerable()
                         select (new Events
                         {
                             ID = t.Field<int>("ID"),
                             Description = t.Field<string>("Description"),
                             TimeStamp = t.Field<DateTime>("TimeStamp"),
                             TypeOfEvent = t.Field<string>("TypeOfEvent"),
                             Hostname = t.Field<string>("Hostname"),
                             Location = t.Field<string>("Location"),
                             TagID = t.Field<string>("TagID"),
                             AssetID = t.Field<string>("AssetID"),
                             Name = t.Field<string>("Name"),
                         })).OrderBy(x => Guid.NewGuid().ToString()).ToList();
            ObjEventsList = items;

            return ObjEventsList;
        }

        //public bool Add(Contacts objNewContacts)
        //{
        //    bool IsAdded = false;
        //    //Age must be between 21 t0 58
        //    if (objNewContacts.Age < 21 || objNewContacts.Age > 58)
        //        throw new ArgumentException("Invalid age limit for Contacts");
        //    try
        //    {
        //        ObjSqlCommand.Parameters.Clear();
        //        ObjSqlCommand.CommandText = "Insert";
        //        ObjSqlCommand.Parameters.AddWithValue("@Id", objNewContacts.Id);
        //        ObjSqlCommand.Parameters.AddWithValue("@Name", objNewContacts.Name);
        //        ObjSqlCommand.Parameters.AddWithValue("@Age", objNewContacts.Age);

        //        ObjSqlConnection.Open();
        //        int NoOfRowsAffected = ObjSqlCommand.ExecuteNonQuery();
        //        IsAdded = NoOfRowsAffected > 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        ObjSqlConnection.Close();
        //    }
        //    return IsAdded;
        //}

        //public bool Update(Contacts objContactsToUpdate)
        //{
        //    bool IsUpdated = false;
        //    try
        //    {
        //        ObjSqlCommand.Parameters.Clear();
        //        ObjSqlCommand.CommandText = "Update";
        //        ObjSqlCommand.Parameters.AddWithValue("@Id", objContactsToUpdate.Id);
        //        ObjSqlCommand.Parameters.AddWithValue("@Name", objContactsToUpdate.Name);
        //        ObjSqlCommand.Parameters.AddWithValue("@Age", objContactsToUpdate.Age);

        //        ObjSqlConnection.Open();
        //        int NoOfRowsAffected = ObjSqlCommand.ExecuteNonQuery();
        //        IsUpdated = NoOfRowsAffected > 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        ObjSqlConnection.Close();
        //    }
        //    return IsUpdated;
        //}

        //public bool Delete(int id)
        //{
        //    bool IsDelete = true;
        //    try
        //    {
        //        ObjSqlCommand.Parameters.Clear();
        //        ObjSqlCommand.CommandText = "Delete";
        //        ObjSqlCommand.Parameters.AddWithValue("@Id", id);

        //        ObjSqlConnection.Open();
        //        int NoOfRowsAffected = ObjSqlCommand.ExecuteNonQuery();
        //        IsDelete = NoOfRowsAffected > 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        ObjSqlConnection.Close();
        //    }
        //    return IsDelete;
        //}

        //public Contacts Search(int id)
        //{
        //    Contacts ObjContacts = null;
        //    try
        //    {
        //        ObjSqlCommand.Parameters.Clear();
        //        ObjSqlCommand.CommandText = "Search";
        //        ObjSqlCommand.Parameters.AddWithValue("@Id", id);

        //        ObjSqlConnection.Open();
        //        var ObjSqlDataReader = ObjSqlCommand.ExecuteReader();
        //        if(ObjSqlDataReader.HasRows)
        //        {
        //            ObjSqlDataReader.Read();
        //            ObjContacts = new Contacts();
        //            ObjContacts.Id = ObjSqlDataReader.GetInt32(0);
        //            ObjContacts.Name = ObjSqlDataReader.GetString(1);
        //            ObjContacts.Age = ObjSqlDataReader.GetInt32(2);
        //        }
        //        ObjSqlDataReader.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        ObjSqlConnection.Close();
        //    }
        //    return ObjContacts;
        //}

    }
}
