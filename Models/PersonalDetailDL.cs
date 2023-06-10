using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EmpTask.Models
{
    public class PersonalDetailDL
    {
        public List<PersonalDetail> personalDetails()
        {
            List<PersonalDetail> personalDetails = new List<PersonalDetail>();

            string cs = ConfigurationManager.ConnectionStrings["Employee"].ConnectionString;
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("ViewPersonalDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        PersonalDetail p = new PersonalDetail();
                        p.Id = (int)reader["Id"];
                        p.Name = reader["Name"].ToString();
                        p.MobileNo = reader["MobileNo"].ToString();
                        p.Age = (int)reader["Age"];
                        p.Address = reader["Address"].ToString();
                       
                        personalDetails.Add(p);
                    }
                }
            }
            //catch (Exception ex)
            //{

            //    return null;
            //}
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }

            return personalDetails;
        }
        public bool Create(PersonalDetail personalDetail)
        {

            string cs = ConfigurationManager.ConnectionStrings["Employee"].ConnectionString;
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("CreatePersonalDetail", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", personalDetail.Id);
                cmd.Parameters.AddWithValue("@Name", personalDetail.Name);
                cmd.Parameters.AddWithValue("@MobileNo", personalDetail.MobileNo);
                cmd.Parameters.AddWithValue("@Age", personalDetail.Age);
                cmd.Parameters.AddWithValue("@Address", personalDetail.Address);

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

        public bool Update(PersonalDetail personalDetail)
        {

            string cs = ConfigurationManager.ConnectionStrings["Employee"].ConnectionString;
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("EditPersonalDetail ", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", personalDetail.Id);
                cmd.Parameters.AddWithValue("@Name", personalDetail.Name);
                cmd.Parameters.AddWithValue("@MobileNO", personalDetail.MobileNo);
                cmd.Parameters.AddWithValue("@Age", personalDetail.Age);
                cmd.Parameters.AddWithValue("@Address", personalDetail.Address);

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
        public bool Delete(int id)
        {

            string cs = ConfigurationManager.ConnectionStrings["Employee"].ConnectionString;
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("DeletePersonalDetail", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id",id);


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
        public PersonalDetail DetailsById(int id)
        {


            string cs = ConfigurationManager.ConnectionStrings["Employee"].ConnectionString;
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("PersonalDetailById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        PersonalDetail p = new PersonalDetail();
                        p.Id = (int)reader["Id"];
                        p.Name = reader["Name"].ToString();
                        p.MobileNo = reader["MobileNo"].ToString();
                        p.Age = (int)reader["Age"];
                        p.Address = reader["Address"].ToString();
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