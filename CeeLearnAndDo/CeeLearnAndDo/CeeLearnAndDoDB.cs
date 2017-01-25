using CeeLearnAndDo.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CeeLearnAndDo
{
    public class CeeLearnAndDoDB
    {
        string connect = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CeeLearnAndDoDB.mdf;Integrated Security=True";

        public List<TickertapeProp> GetTickertape()
        {
            List<TickertapeProp> tapes = new List<TickertapeProp>();
            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();
                SqlCommand selectTape = new SqlCommand("SELECT * FROM Tickertape", con);
                SqlDataReader reader = selectTape.ExecuteReader();

                while (reader.Read())
                {
                    TickertapeProp t = new TickertapeProp();
                    t.Tickertape_Id = Convert.ToInt32(reader["Id"]);
                    t.Tickertape_Description = reader["Description"].ToString();

                    tapes.Add(t);
                }
            }
            return tapes;
        }

        public List<ProjectProp> GetProject()
        {
            List<ProjectProp> projects = new List<ProjectProp>();
            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();
                SqlCommand selectTape = new SqlCommand("SELECT * FROM Project", con);
                SqlDataReader reader = selectTape.ExecuteReader();

                while (reader.Read())
                {
                    ProjectProp p = new ProjectProp();
                    p.Project_Id = Convert.ToInt32(reader["Id"]);
                    p.Project_Name = reader["Naam"].ToString();
                    p.Project_Description = reader["Description"].ToString();
                    p.Project_Publisher = reader["Publisher"].ToString();
                    p.Project_Image = reader["Image"].ToString();

                    projects.Add(p);
                }
            }
            return projects;
        }
    }
}