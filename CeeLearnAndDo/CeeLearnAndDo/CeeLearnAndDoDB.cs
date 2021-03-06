﻿using CeeLearnAndDo.Classes;
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
                SqlCommand selectProject = new SqlCommand("SELECT * FROM Project", con);
                SqlDataReader reader = selectProject.ExecuteReader();

                while (reader.Read())
                {
                    ProjectProp p = new ProjectProp();
                    p.Project_Id = Convert.ToInt32(reader["Id"]);
                    p.Project_Name = reader["Name"].ToString();
                    p.Project_Description = reader["Description"].ToString();
                    p.Project_Publisher = reader["Publisher"].ToString();
                    p.Project_Image = reader["Image"].ToString();

                    projects.Add(p);
                }
            }
            return projects;
        }

        public ProjectProp GetHomeProject()
        {
            ProjectProp p = new ProjectProp();
            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();
                SqlCommand selectOneProject = new SqlCommand("SELECT TOP 1 * FROM Project", con);
                SqlDataReader reader = selectOneProject.ExecuteReader();

                reader.Read();
                p.Project_Id = Convert.ToInt32(reader["Id"]);
                p.Project_Name = reader["Name"].ToString();
                p.Project_Description = reader["Description"].ToString();
                p.Project_Publisher = reader["Publisher"].ToString();
                p.Project_Image = reader["Image"].ToString();
            }
            return p;
        }

        public ProjectProp GetOneProject(int id)
        {
            ProjectProp p = new ProjectProp();
            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();
                SqlCommand selectProduct = new SqlCommand("SELECT * FROM Project WHERE Id = @id", con);
                selectProduct.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = selectProduct.ExecuteReader();

                p.Project_Id = Convert.ToInt32(reader["Id"]);
                p.Project_Name = reader["Name"].ToString();
                p.Project_Description = reader["Description"].ToString();
                p.Project_Publisher = reader["Publisher"].ToString();
                p.Project_Image = reader["Image"].ToString();
            }
            return p;
        }

        public List<AdminProjectProp> GetAdminProject()
        {
            List<AdminProjectProp> projects = new List<AdminProjectProp>();
            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();
                SqlCommand selectTape = new SqlCommand("SELECT * FROM Project", con);
                SqlDataReader reader = selectTape.ExecuteReader();

                while (reader.Read())
                {
                    AdminProjectProp p = new AdminProjectProp();
                    p.Project_Id = Convert.ToInt32(reader["Id"]);
                    p.Project_Name = reader["Name"].ToString();
                    p.Project_Publisher = reader["Publisher"].ToString();
                    p.Project_Image = reader["Image"].ToString();

                    projects.Add(p);
                }
            }
            return projects;
        }
    }
}