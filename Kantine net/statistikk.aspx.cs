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
    public partial class statistikk : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDownListKategori();
                BindChart(ListDesc.SelectedValue);
            }
        }

        private void BindDropDownListKategori()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnCms"].ConnectionString;
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT Kategori FROM Produkter", conn);
                cmd.CommandType = CommandType.Text;
                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                reader.Close();
            }


            foreach (DataRow row in dt.Rows)
            {
                ListItem item = new ListItem(row["Kategori"].ToString(), row["Kategori"].ToString());
                ListDesc.Items.Add(item);
            }
        }


        private void BindChart(string kategori)
        {

            string yValueMember = "AntallKjøpt";
            // Set up the chart series
            chartview.Series[0].XValueMember = "navn";
            chartview.Series[0].YValueMembers = yValueMember; // Use the provided YValueMembers parameter
            chartview.Series[0].ChartType = SeriesChartType.Column;


            DataTable dataSource = null;

            if (ListTid.SelectedValue == "Denne uka" && ListDesc.SelectedIndex > 0)
            {
                dataSource = GetUke(kategori);
            }
            else if (ListTid.SelectedValue == "Denne måneden" && ListDesc.SelectedIndex > 0)
            {
                yValueMember = "AntallKjøpt";
                dataSource = GetMåned(kategori);
            }
            else if (ListTid.SelectedValue == "Dette året" && ListDesc.SelectedIndex > 0)
            {
                yValueMember = "AntallKjøpt";
                dataSource = GetÅr(kategori);
            }
            else
            {
                lbl.Text = "Velg kategori og tidsperiode for å se resultater";
                return; // Legg til return her for å unngå null exception
            }

            chartview.Series[0].YValueMembers = yValueMember;
            chartview.DataSource = dataSource;
            chartview.DataBind();
        }

        protected void Button_Click(object sender, EventArgs e)
        {
            BindChart(ListDesc.SelectedValue);
        }


        private DataTable GetUke(string selctedKategori)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnCms"].ConnectionString;
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT p.Navn, COUNT(*) AS AntallKjøpt FROM Produkter p JOIN ProduktSalg ps ON p.ProduktID = ps.ProduktID JOIN Salg s ON ps.SalgID = s.SalgID WHERE p.Kategori = @kategori AND DATEPART(week, s.Dato) = DATEPART(week, CURRENT_TIMESTAMP) AND DATEPART(year, s.Dato) = DATEPART(year, CURRENT_TIMESTAMP) GROUP BY p.Navn;", conn))
                {
                    // Add the parameter as a string
                    cmd.Parameters.Add("@kategori", SqlDbType.NVarChar).Value = selctedKategori;

                    cmd.CommandType = CommandType.Text;
                    SqlDataReader reader = cmd.ExecuteReader();
                    dt.Load(reader);
                    reader.Close();
                }

                conn.Close();
            }

            return dt;
        }


        private DataTable GetMåned(string selctedKategori)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnCms"].ConnectionString;
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT p.Navn, COUNT(*) AS AntallKjøpt FROM Produkter p JOIN ProduktSalg ps ON p.ProduktID = ps.ProduktID JOIN Salg s ON ps.SalgID = s.SalgID WHERE p.Kategori = @kategori AND YEAR(s.Dato) = YEAR(CURRENT_TIMESTAMP) AND MONTH(s.Dato) = MONTH(CURRENT_TIMESTAMP) GROUP BY p.Navn;", conn))
                {
                    // Add the parameter as a string
                    cmd.Parameters.Add("@kategori", SqlDbType.NVarChar).Value = selctedKategori;

                    cmd.CommandType = CommandType.Text;
                    SqlDataReader reader = cmd.ExecuteReader();
                    dt.Load(reader);
                    reader.Close();
                }

                conn.Close();
            }

            return dt;
        }


        private DataTable GetÅr(string selctedKategori)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnCms"].ConnectionString;
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT p.Navn, COUNT(*) AS AntallKjøpt FROM Produkter p JOIN ProduktSalg ps ON p.ProduktID = ps.ProduktID JOIN Salg s ON ps.SalgID = s.SalgID WHERE p.Kategori = @kategori AND YEAR(s.Dato) = YEAR(CURRENT_TIMESTAMP) GROUP BY p.Navn;", conn))
                {
                    // Add the parameter as a string
                    cmd.Parameters.Add("@kategori", SqlDbType.NVarChar).Value = selctedKategori;

                    cmd.CommandType = CommandType.Text;
                    SqlDataReader reader = cmd.ExecuteReader();
                    dt.Load(reader);
                    reader.Close();
                }

                conn.Close();
            }

            return dt;
        }


    }
}