using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;

namespace Kantine_net
{
    public partial class ukemeny : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDownListKategori();
                BindGrid();
            }
        }

        private void BindDropDownListKategori()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnCms"].ConnectionString;
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT Kategori FROM Produkter WHERE Kategori <> 'Rett'", conn);
                cmd.CommandType = CommandType.Text;
                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                reader.Close();
            }

            ListDesc.Items.Clear();
            ListDesc.Items.Add(new ListItem("UKEMENY", "UKEMENY"));
            

            foreach (DataRow row in dt.Rows)
            {
                ListItem item = new ListItem(row["Kategori"].ToString(), row["Kategori"].ToString());
                ListDesc.Items.Add(item);
            }
        }

        private void BindGrid()
        {
            DataTable dataSource = new DataTable();

            if (ListDesc.SelectedValue == "UKEMENY")
            {
                dataSource = GetUkemeny();
            }
            else if (ListDesc.SelectedValue == "DESSERT")
            {
                dataSource = GetDessert();
            }
            else if (ListDesc.SelectedValue == "DRIKKE")
            {
                dataSource = GetDrikke();
            }
            else if (ListDesc.SelectedValue == "SNACKS")
            {
                dataSource = GetSnacks();
            }
            else
            {
                lbl.Text = "velg kategori for å se resultater";
            }


            GridView.DataSource = dataSource;
            GridView.DataBind();
        }
        



    private DataTable GetUkemeny()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnCms"].ConnectionString;
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT m.Dag, p.Navn, p.Pris FROM Meny m JOIN Produkter p ON m.ProduktID = p.ProduktID ORDER BY    CASE m.Dag        WHEN 'Mandag' THEN 1       WHEN 'Tirsdag' THEN 2        WHEN 'Onsdag' THEN 3        WHEN 'Torsdag' THEN 4        WHEN 'Fredag' THEN 5    END;", conn))
                {
                    cmd.CommandType = CommandType.Text;
                    SqlDataReader reader = cmd.ExecuteReader();
                    dt.Load(reader);
                    reader.Close();
                }

                conn.Close();
            }

            return dt;
        }


        private DataTable GetSnacks()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnCms"].ConnectionString;
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("select navn, pris from Produkter where kategori = 'snacks'", conn))
                {
                    cmd.CommandType = CommandType.Text;
                    SqlDataReader reader = cmd.ExecuteReader();
                    dt.Load(reader);
                    reader.Close();
                }

                conn.Close();
            }

            return dt;
        }



        private DataTable GetDessert()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnCms"].ConnectionString;
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("select navn, pris from Produkter where kategori = 'dessert'", conn))
                {
                    cmd.CommandType = CommandType.Text;
                    SqlDataReader reader = cmd.ExecuteReader();
                    dt.Load(reader);
                    reader.Close();
                }

                conn.Close();
            }

            return dt;
        }



        private DataTable GetDrikke()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnCms"].ConnectionString;
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("select navn, pris from Produkter where kategori = 'drikke'", conn))
                {
                    cmd.CommandType = CommandType.Text;
                    SqlDataReader reader = cmd.ExecuteReader();
                    dt.Load(reader);
                    reader.Close();
                }

                conn.Close();
            }

            return dt;
        }

        protected void ListDesc_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid(); 
        }
    }
}
