using System;
using System.Collections.Generic;
using System.Windows;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ZTraxApp.Models
{
    public class LocationService
    {
        public List<Locations> GetAll()
        {
            JObject jObject = CommonService.SendGet("Locations");
            List<Locations> locationsList = new List<Locations>();
            try
            {
                locationsList = JsonConvert.DeserializeObject<List<Locations>>(jObject["value"].ToString());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
                
            return locationsList;
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
