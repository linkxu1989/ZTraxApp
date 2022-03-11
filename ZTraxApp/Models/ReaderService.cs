using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace ZTraxApp.Models
{
    public class ReaderService
    {
        public List<Readers> GetAll()
        {
            List<Readers> ObjReadersList = new List<Readers>();
            DataTable dt = new DataTable();
            dt.Columns.Add("HostName");
            dt.Columns.Add("IPAddress");
            dt.Columns.Add("LocDescription");
            dt.Rows.Add(new object[] { "FX750080037D", "10.61.58.31", "NY21" });
            dt.Rows.Add(new object[] { "FX7500800E63", "10.61.58.32", "NY21" });
            dt.Rows.Add(new object[] { "FX7500800397", "10.61.58.34", "NY21" });
            dt.Rows.Add(new object[] { "FX75008003B5", "10.61.58.35", "NY21" });
            dt.Rows.Add(new object[] { "FX750080037C", "10.61.58.36", "NY21" });
            dt.Rows.Add(new object[] { "FX750080037E", "10.61.58.37", "NY21" });
            dt.Rows.Add(new object[] { "FX7500800380", "10.61.58.38", "NY21" });
            dt.Rows.Add(new object[] { "FX7500800381", "10.61.58.39", "NY21" });
            dt.Rows.Add(new object[] { "FX7500800384", "10.61.58.40", "NY21" });
            dt.Rows.Add(new object[] { "FX7500800498", "10.61.58.41", "NY21" });
            dt.Rows.Add(new object[] { "FX750080037F", "10.61.58.42", "NY21" });
            dt.Rows.Add(new object[] { "FX7500800382", "10.61.58.43", "NY21" });
            dt.Rows.Add(new object[] { "FX75008003B3", "10.61.58.44", "NY21" });
            dt.Rows.Add(new object[] { "FX7500800383", "10.61.58.45", "NY21" });
            dt.Rows.Add(new object[] { "FX7500800E62", "10.61.58.46", "NY21" });
            dt.Rows.Add(new object[] { "FX7500800385", "10.61.58.47", "NY21" });
            dt.Rows.Add(new object[] { "FX75008003B4", "10.61.58.48", "NY21" });
            dt.Rows.Add(new object[] { "FX7500800374", "10.61.58.49", "NY21" });
            dt.Rows.Add(new object[] { "FX7500800378", "10.61.58.50", "NY21" });
            dt.Rows.Add(new object[] { "FX7500800499", "10.61.58.51", "NY21" });
            dt.Rows.Add(new object[] { "FX7500EFB190", "10.61.58.52", "NY21" });
            dt.Rows.Add(new object[] { "FX7500EFB18F", "10.61.58.53", "NY21" });

            var items = (from t in dt.AsEnumerable()
                         select (new Readers
                         {
                             HostName = t.Field<string>("HostName"),
                             IPAddress = t.Field<string>("IPAddress"),
                             LocDescription = t.Field<string>("LocDescription"),
                         })).OrderBy(x => Guid.NewGuid().ToString()).ToList();
            ObjReadersList = items;
            return ObjReadersList;
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
