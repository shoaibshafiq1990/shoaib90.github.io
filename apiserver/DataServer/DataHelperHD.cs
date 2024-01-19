using System.Data;
using System.Data.SqlClient;
using HelpDeskShared;
using HelpDeskShared.Models;

namespace apiserver.DataServer
{
    public static class DataHelperHD
    {
        private const string constr = @"Data Source=tcp:10.10.204.171,1433;Initial Catalog=servicedesk;User ID=sa;Password=Giga$Byte;";

        //get 
        public static List<SDOrganization> GetOrgsAll()
        {
            List<SDOrganization> ulist = new();
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM SDOrganization", conn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ulist.Add(new SDOrganization() { ORG_ID = Convert.ToInt32(reader["ORG_ID"]), NAME = (string)reader["NAME"] });
            }
            cmd.Dispose();
            conn.Close();
            return ulist;
        }


        //get CategoryDefinition
        public static List<CategoryDefinition> GetCategoryAll()
        {
            List<CategoryDefinition> ulist = new();
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM CategoryDefinition", conn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ulist.Add(new CategoryDefinition() { CATEGORYID = Convert.ToInt32(reader["CATEGORYID"]), CATEGORYNAME = (string)reader["CATEGORYNAME"] });
            }
            cmd.Dispose();
            conn.Close();
            return ulist;
        }

        //get SubCategoryDefinition
        public static List<SubCategoryDefinition> GetSubCategoryAll()
        {
            List<SubCategoryDefinition> ulist = new();
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM SubCategoryDefinition", conn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ulist.Add(new SubCategoryDefinition() { 
                    SUBCATEGORYID = Convert.ToInt32(reader["SUBCATEGORYID"]),
                    CATEGORYID = Convert.ToInt32(reader["CATEGORYID"]),
                    NAME = (string)reader["NAME"]  
                });
            }
            cmd.Dispose();
            conn.Close();
            return ulist;
        }

        public static List<SubCategoryDefinition> GetSubCategoryById(int catID)
        {
            List<SubCategoryDefinition> ulist = new List<SubCategoryDefinition>();

            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM SubCategoryDefinition WHERE CategoryID = @catID", conn))
                {
                    cmd.Parameters.AddWithValue("@catID", catID);
                    cmd.CommandType = CommandType.Text;

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ulist.Add(new SubCategoryDefinition()
                        {
                            SUBCATEGORYID = Convert.ToInt32(reader["SUBCATEGORYID"]),
                            CATEGORYID = Convert.ToInt32(reader["CATEGORYID"]),
                            NAME = (string)reader["NAME"]
                        });
                    }
                }
            }

            return ulist;
        }


        //get DepartmentDefinition
        public static List<DepartmentDefinition> GetDepartmentAll()
        {
            List<DepartmentDefinition> ulist = new();
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM DepartmentDefinition", conn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ulist.Add(new DepartmentDefinition()
                {
                    DEPTID = Convert.ToInt32(reader["DEPTID"]),
                    SITEID = Convert.ToInt32(reader["SITEID"]),
                    DEPTNAME = (string)reader["DEPTNAME"]
                });
            }
            cmd.Dispose();
            conn.Close();
            return ulist;
        }


        //get PriorityDefinition
        public static List<PriorityDefinition> GetPriorityAll()
        {
            List<PriorityDefinition> ulist = new();
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM PriorityDefinition where HELPDESKID = 1 and ISDELETED = 0 order by PRIORITYORDER", conn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ulist.Add(new PriorityDefinition()
                {
                    PRIORITYID = Convert.ToInt32(reader["PRIORITYID"]),
                    PRIORITYNAME = (string)reader["PRIORITYNAME"],
                    PRIORITYCOLOR = (string)reader["PRIORITYCOLOR"],
                    PRIORITYORDER = Convert.ToInt32(reader["PRIORITYORDER"]),
                    PRIORITYDESCRIPTION = (string)reader["PRIORITYDESCRIPTION"],
                    ISDELETED = Convert.ToInt32(reader["ISDELETED"]),
                    HELPDESKID = Convert.ToInt32(reader["HELPDESKID"])
                });
            }
            cmd.Dispose();
            conn.Close();
            return ulist;
        }

        //get CI
        public static List<QueueDefinition> GetCiById(int siteID)
        {
            List<QueueDefinition> ulist = new List<QueueDefinition>();

            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM QueueDefinition WHERE HELPDESKID = 1  and SITEID  = @siteID", conn))
                {
                    cmd.Parameters.AddWithValue("@siteID", siteID);
                    cmd.CommandType = CommandType.Text;

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ulist.Add(new QueueDefinition()
                        {
                            QUEUEID = Convert.ToInt32(reader["QUEUEID"]), 
                            QUEUENAME = reader["QUEUENAME"] == DBNull.Value ? null : (string)reader["QUEUENAME"],
                            QUEUEDESCRIPTION = reader["QUEUEDESCRIPTION"] == DBNull.Value ? null : (string)reader["QUEUEDESCRIPTION"],
                            SENDERNAME = reader["SENDERNAME"] == DBNull.Value ? null : (string)reader["SENDERNAME"],
                            REPLYADDRESS = reader["REPLYADDRESS"] == DBNull.Value ? null : (string)reader["REPLYADDRESS"],
                            SITEID =  Convert.ToInt32(reader["SITEID"]),
                            CIID = Convert.ToInt32(reader["CIID"]) 
                        });
                    }
                }
            }

            return ulist;
        }


        //get CI
        public static List<TechnicianUsers> GetTechUserById(int siteID)
        {
            List<TechnicianUsers> ulist = new List<TechnicianUsers>();

            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("select s.userid, s.firstname, s.employeeid, s.jobtitle, s.status, s.reportingto  from SDUser s, (SELECT c.ciid, c.ciname, c.siteid FROM CI c WHERE c.HELPDESKID = 1 and c.CITYPEID = 3) cc where s.firstname = cc.ciname and   s.status = 'ACTIVE' and s.reportingto is not null and cc.SITEID = @siteID", conn))
                {
                    cmd.Parameters.AddWithValue("@siteID", siteID);
                    cmd.CommandType = CommandType.Text;

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ulist.Add(new TechnicianUsers()
                        {
                            userid = Convert.ToInt32(reader["userid"]),
                            firstname = reader["firstname"] == DBNull.Value ? null : (string)reader["firstname"],
                            employeeid = Convert.ToInt32(reader["employeeid"]),
                            jobtitle = reader["jobtitle"] == DBNull.Value ? null : (string)reader["jobtitle"],
                            status = reader["status"] == DBNull.Value ? null : (string)reader["status"],
                            reportingto = reader["reportingto"] == DBNull.Value ? null : Convert.ToInt32(reader["reportingto"])
                        });
                    }
                }
            }

            return ulist;
        }


        //Insert date
        public static string InsertServiceReq(InsertServiceRequest sr)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("InsertWorkOrderM_sp", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // For WorkOrder Table
                        cmd.Parameters.AddWithValue("@REQUESTERID", sr.REQUESTERID);
                        cmd.Parameters.AddWithValue("@CREATEDBYID", sr.CREATEDBYID);
                       // cmd.Parameters.AddWithValue("@CREATEDTIME", sr.CREATEDTIME);
                        //cmd.Parameters.AddWithValue("@DUEBYTIME", sr.DUEBYTIME);
                        cmd.Parameters.AddWithValue("@TITLE", sr.TITLE);
                        cmd.Parameters.AddWithValue("@DESCRIPTION", sr.description);
                        //cmd.Parameters.AddWithValue("@MODEID", sr.MODEID);
                        cmd.Parameters.AddWithValue("@DEPTID", sr.DEPTID);
                        cmd.Parameters.AddWithValue("@SITEID", sr.SITEID);
                        //cmd.Parameters.AddWithValue("@ISPARENT", sr.ISPARENT);
                        //cmd.Parameters.AddWithValue("@TEMPLATEID", sr.TEMPLATEID);
                        //cmd.Parameters.AddWithValue("@SERVICEID", sr.serviceid);
                        //cmd.Parameters.AddWithValue("@IS_CATALOG_TEMPLATE", sr.IS_CATALOG_TEMPLATE);
                        //cmd.Parameters.AddWithValue("@FR_DUETIME", sr.FR_DUETIME);
                        //cmd.Parameters.AddWithValue("@HELPDESKID", sr.HELPDESKID);
                        // For WorkOrderStates Table 
                        cmd.Parameters.AddWithValue("@CATEGORYID", sr.CATEGORYID);
                        cmd.Parameters.AddWithValue("@SUBCATEGORYID", sr.SUBCATEGORYID);
                        //cmd.Parameters.AddWithValue("@STATUSID", sr.STATUSID);
                        cmd.Parameters.AddWithValue("@PRIORITYID", sr.PRIORITYID);
                        //cmd.Parameters.AddWithValue("@OLA_STATUS", sr.OLA_STATUS);
                        cmd.Parameters.AddWithValue("@HASATTACHMENT", sr.HASATTACHMENT);
                        cmd.Parameters.AddWithValue("@OWNERID", sr.OWNERID);
                       // cmd.Parameters.AddWithValue("@ASSIGNEDTIME", sr.ASSIGNEDTIME);
                        // For WorkOrder_Queue Table
                        cmd.Parameters.AddWithValue("@QUEUEID", sr.QUEUEID);

                        //SqlParameter outputParam = new SqlParameter("@WORKORDERID", SqlDbType.Int);
                        //outputParam.Direction = ParameterDirection.Output;
                        //cmd.Parameters.Add(outputParam);

                        cmd.ExecuteNonQuery();

                        //Return WorkOrderID through Procedure
                        //sr.WORKORDERID = Convert.ToInt32(outputParam.Value);

                        // Use the generated WORKORDERID as needed

                        return "ok";
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }



    }
}
