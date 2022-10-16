using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StudentDetails.Models
{
    public class StudentModelManager
    {
        

        public List<StudentModel> GetStudentinfo()
        {
            string scn1 = ConfigurationManager.ConnectionStrings["scn1"].ConnectionString;
            List<StudentModel> OStudentModels = new List<StudentModel>();

            using (SqlConnection cn = new SqlConnection(scn1))
            {
                using(SqlCommand cmd = new SqlCommand("Sp_getstudentinfo",cn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    try
                    {
                        cn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            StudentModel studentModel = new StudentModel();
                            studentModel.ID = Convert.ToInt32(dr["ID"]);
                            studentModel.LastName = Convert.ToString(dr["LastName"]);
                            studentModel.FirstName = Convert.ToString(dr["FirstName"]);
                            studentModel.Email = Convert.ToString(dr["Email"]);
                            studentModel.Age = Convert.ToInt32(dr["Age"]);


                            OStudentModels.Add(studentModel);
                        }
                        dr.Close();
                    }
                    catch(Exception ex)
                    {
                        var exception = ex;
                    }
                    finally
                    {
                        if (cn.State == System.Data.ConnectionState.Open)
                        {
                            cn.Close();
                        }
                    }
                    return OStudentModels;
                }
            }

        }

        public int InsertStudentDetails(StudentModel studentModel)
        {
            string scn1 = ConfigurationManager.ConnectionStrings["scn1"].ConnectionString;
            int count;
            using (SqlConnection cn = new SqlConnection(scn1))
            {
                using (SqlCommand cmd = new SqlCommand("Proc_InsertStudentDetail", cn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    try
                    {
                        cmd.Parameters.AddWithValue("@ID", studentModel.ID);
                        cmd.Parameters.AddWithValue("@LastName",studentModel.LastName);
                        cmd.Parameters.AddWithValue("@FirstName",studentModel.FirstName);
                        cmd.Parameters.AddWithValue("@Email",studentModel.Email);
                        cmd.Parameters.AddWithValue("@Age",studentModel.Age);

                        cn.Open();
                         count = cmd.ExecuteNonQuery();

                    }
                    catch(Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        if (cn.State == System.Data.ConnectionState.Open)
                        {
                            cn.Close();
                        }
                    }
                    return count;
                }

            }

        }

        public int UpdateStudentDetails(StudentModel studentModel)
        {
            string scn1 = ConfigurationManager.ConnectionStrings["scn1"].ConnectionString;
            int count;
            using (SqlConnection cn = new SqlConnection(scn1))
            {
                using(SqlCommand cmd = new SqlCommand("Proc_UpdateStudentDetail", cn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    try
                    {
                        cmd.Parameters.AddWithValue("@ID", studentModel.ID);
                        cmd.Parameters.AddWithValue("@LastName", studentModel.LastName);
                        cmd.Parameters.AddWithValue("@FirstName", studentModel.FirstName);
                        cmd.Parameters.AddWithValue("@Email", studentModel.Email);
                        cmd.Parameters.AddWithValue("@Age", studentModel.Age);

                        cn.Open();
                        count = cmd.ExecuteNonQuery();
                    }
                    catch(Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        if (cn.State == System.Data.ConnectionState.Open)
                        {
                            cn.Close();
                        }
                    }
                    return count;
                }
            }

        }

        public int DeleteStudentDetails(StudentModel studentModel)
        {
            string scn1 = ConfigurationManager.ConnectionStrings["scn1"].ConnectionString;
            int count;
            using(SqlConnection cn = new SqlConnection(scn1))
            {
                using (SqlCommand cmd = new SqlCommand("Proc_DeleteStudentDetail", cn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    try
                    {
                        cmd.Parameters.AddWithValue("@ID",studentModel.ID);

                        cn.Open();
                        count = cmd.ExecuteNonQuery();
                    }
                    catch(Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        if (cn.State == System.Data.ConnectionState.Open)
                        {
                            cn.Close();
                        }
                    }
                    return count;
                }
            }
        }

        public StudentModel SearchStudentDetail(StudentModel studentModel)
        {
            string scn1 = ConfigurationManager.ConnectionStrings["scn1"].ConnectionString;

            using(SqlConnection cn = new SqlConnection(scn1))
            {
                using (SqlCommand cmd = new SqlCommand("Proc_SearchStudentDetail", cn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    try
                    {
                        cmd.Parameters.AddWithValue("@ID", studentModel.ID);
                        cn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            StudentModel objstudentModel = new StudentModel();
                            objstudentModel.ID = Convert.ToInt32(dr["ID"]);
                            objstudentModel.LastName = Convert.ToString(dr["LastName"]);
                            objstudentModel.FirstName = Convert.ToString(dr["FirstName"]);
                            objstudentModel.Email = Convert.ToString(dr["Email"]);
                            objstudentModel.Age = Convert.ToInt32(dr["Age"]);


                            return objstudentModel;
                        }
                        dr.Close();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        if (cn.State == System.Data.ConnectionState.Open)
                        {
                            cn.Close();
                        }
                    }
                }


            }

            return null ;    

        }
    }
}