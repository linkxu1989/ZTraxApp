using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace ZTraxApp.Models
{
    public class BadgeService
    {
        public string AC2 = ConfigurationManager.ConnectionStrings["AccessControl2"].ConnectionString;

        public DataTable GetList(string command, string table)
        {
            SqlConnection sqlConnection = new SqlConnection(AC2);
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

        public List<Badges> GetAll()
        {
            var command = @"SELECT LASTNAME, FIRSTNAME, EMAIL_ID as EMAIL, [Employee #] as EMPLOYEE,[Date/Time] as CREATEDTIME FROM AccessControl2.dbo.NY21_Tool_Crib_Access;";
            var table = @"NY21_Tool_Crib_Access";
            List<Badges> ObjBadgesList = new List<Badges>();
            DataTable dt = GetList(command, table);

            var items = (from t in dt.AsEnumerable()
                         select (new Badges
                         {
                             LASTNAME = t.Field<string>("LASTNAME"),
                             FIRSTNAME = t.Field<string>("FIRSTNAME"),
                             EMAIL = t.Field<string>("EMAIL"),
                             EMPLOYEE = t.Field<string>("EMPLOYEE"),
                             CREATEDTIME = t.Field<DateTime>("CREATEDTIME"),
                         })).OrderBy(x => Guid.NewGuid().ToString()).ToList();
            ObjBadgesList = items;

            return ObjBadgesList;
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
