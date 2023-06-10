using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EmpTask.Models
{
    public class QualificationDL
    {
        public List<Qualification> qualificationsDetail()
        {
            List<Qualification> products = new List<Qualification>();

            string cs = ConfigurationManager.ConnectionStrings["Employee"].ConnectionString;
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("QualificationDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Qualification p = new Qualification();
                        p.Id = (int)reader["Id"];
                        p.Name = reader["Name"].ToString();
                        p.Mark = (int)reader["Marks"];
                        products.Add(p);
                    }
                }
            }
            catch (Exception ex)
            {

                return null;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }

            return products;
        }
        public bool CreateQual(Qualification qualification)
        {

            string cs = ConfigurationManager.ConnectionStrings["Employee"].ConnectionString;
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("CreateQualification", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@Id", qualification.Id);
                cmd.Parameters.AddWithValue("@Name", qualification.Name);
                cmd.Parameters.AddWithValue("@Marks", qualification.Mark);

                SqlParameter status = new SqlParameter();
                status.ParameterName = "@Status";
                status.Direction = ParameterDirection.Output;
                status.SqlDbType = SqlDbType.Bit;
                cmd.Parameters.Add(status);

                con.Open();
                cmd.ExecuteNonQuery();
                return (bool)status.Value;
            }
            //catch (Exception ex)
            //{

            //    return false;
            //}
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }
        public bool UpdateQual(Qualification qualification)
        {

            string cs = ConfigurationManager.ConnectionStrings["Employee"].ConnectionString;
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("EditQualification ", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", qualification.Id);
                cmd.Parameters.AddWithValue("@Name", qualification.Name);
                cmd.Parameters.AddWithValue("@Marks", qualification.Mark);
               
                SqlParameter status = new SqlParameter();
                status.ParameterName = "@Status";
                status.Direction = ParameterDirection.Output;
                status.SqlDbType = SqlDbType.Bit;
                cmd.Parameters.Add(status);

                con.Open();
                cmd.ExecuteNonQuery();
                return (bool)status.Value;
            }
            catch (Exception ex)
            {

                return false;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }
        public bool DeleteQual(int id)
        {

            string cs = ConfigurationManager.ConnectionStrings["Employee"].ConnectionString;
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("DeleteQualification", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);


                SqlParameter status = new SqlParameter();
                status.ParameterName = "@Status";
                status.Direction = ParameterDirection.Output;
                status.SqlDbType = SqlDbType.Bit;
                cmd.Parameters.Add(status);

                con.Open();
                cmd.ExecuteNonQuery();
                return (bool)status.Value;
            }
            //catch (Exception ex)
            //{

            //    return false;
            //}
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }
        public Qualification QualDetailsById(int id)
        {


            string cs = ConfigurationManager.ConnectionStrings["Employee"].ConnectionString;
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("QualificationDetailById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Qualification p = new Qualification();
                        p.Id = (int)reader["Id"];
                        p.Name = reader["Name"].ToString();
                        p.Mark = (int)reader["Marks"];
                     
                        return p;
                    }
                }
            }
            catch (Exception ex)
            {

                return null;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }

            return null;
        }

    }
}