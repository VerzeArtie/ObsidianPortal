using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using Npgsql;
//using NpgsqlTypes;
//using System.Data;
using UnityEngine;

namespace ObsidianPortal
{
    public class ControlSQL : MonoBehaviour
    {
        //public string connection = string.Empty;

        //private string TABLE_CHARACTER = "character_data";
        //private string TABLE_OWNER_DATA = "owner_data";
        //private string TABLE_ARCHIVEMENT = "archivement";
        //private string TABLE_DUEL = "duel";
        //public void SetupSql()
        //{
        //    if (ONE.SupportLog == false) { return; }

        //    try
        //    {
        //        string connection = string.Empty;
        //        StringBuilder sb = new StringBuilder();
        //        sb.Append("Server=133.242.151.26;");
        //        sb.Append("Port=36712;");
        //        sb.Append("User Id=postgres;");
        //        sb.Append("Password=volgan3612;");
        //        sb.Append("Database=postgres;");
        //        sb.Append("Timeout=1;");

        //        connection = sb.ToString();
        //        this.connection = connection;

        //    }
        //    catch
        //    {
        //        Debug.Log("SetupSql error");
        //    } // ログ失敗時は、そのまま進む
        //}

        //public string SelectOwner(string name)
        //{
        //    if (ONE.SupportLog == false) { return String.Empty; }

        //    string table = TABLE_OWNER_DATA;
        //    string jsonData = String.Empty;
        //    try
        //    {
        //        using (Npgsql.NpgsqlConnection con = new NpgsqlConnection(connection))
        //        {
        //            //Debug.Log("SelectOwner timeout: " + con.ConnectionTimeout);
        //            con.Open();
        //            NpgsqlCommand cmd = new NpgsqlCommand(@"select to_json(" + table + ") from " + table + " where name = '" + name + "'", con);
        //            var dataReader = cmd.ExecuteReader();
        //            while (dataReader.Read())
        //            {
        //                jsonData += dataReader[0].ToString();
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        Debug.Log("SelectOwner error");
        //    } // ログ失敗時は、そのまま進む

        //    return jsonData;
        //}

        //public void CreateOwner(string name)
        //{
        //    if (ONE.SupportLog == false) { return; }

        //    try
        //    {
        //        System.Guid guid = System.Guid.NewGuid();
        //        DateTime create_time = DateTime.Now;
        //        using (Npgsql.NpgsqlConnection con = new NpgsqlConnection(connection))
        //        {
        //            Debug.Log("CreateOwner timeout: " + con.ConnectionTimeout);
        //            con.Open();
        //            string sqlCmd = "INSERT INTO " + TABLE_OWNER_DATA + " ( name, guid, create_time ) VALUES ( :name, :guid, :create_time )";
        //            var cmd = new NpgsqlCommand(sqlCmd, con);
        //            //cmd.Prepare();
        //            cmd.Parameters.Add(new NpgsqlParameter("name", NpgsqlDbType.Varchar) { Value = name });
        //            cmd.Parameters.Add(new NpgsqlParameter("guid", NpgsqlDbType.Varchar) { Value = guid });
        //            cmd.Parameters.Add(new NpgsqlParameter("create_time", NpgsqlDbType.Timestamp) { Value = create_time });
        //            cmd.ExecuteNonQuery();
        //        }
        //    }
        //    catch
        //    {
        //        Debug.Log("CreateOwner error");
        //    } // ログ失敗時は、そのまま進む
        //}

        //public bool ExistOwnerName(string name)
        //{
        //    // if (ONE.SupportLog == false) { return false; }

        //    try
        //    {
        //        string existName = String.Empty;

        //        using (Npgsql.NpgsqlConnection con = new NpgsqlConnection(connection))
        //        {
        //            con.Open();
        //            NpgsqlCommand cmd = new NpgsqlCommand(@"select name from " + TABLE_OWNER_DATA + " where name = '" + name + "'", con);
        //            var dataReader = cmd.ExecuteReader();
        //            while (dataReader.Read())
        //            {
        //                existName += dataReader[0].ToString();
        //            }
        //        }

        //        if (existName == name)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }

        //    }
        //    catch
        //    {
        //        return false;
        //    } // 取得失敗時は名前がぶつかっている可能性があるが、ひとまず通しとする。
        //}
    }
}
