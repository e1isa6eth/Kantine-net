using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Kantine_net
{
    public partial class admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDownListKategori();
                DropDownListKategori_SelectedIndexChanged(sender, e);

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

            ListDesc.Items.Clear();
            ListDesc.Items.Add(new ListItem("Velg kategori", ""));

            foreach (DataRow row in dt.Rows)
            {
                ListItem item = new ListItem(row["Kategori"].ToString(), row["Kategori"].ToString());
                ListDesc.Items.Add(item);
            }
        }


        private void BindDropDownListProdukter(string kategori)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnCms"].ConnectionString;
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Navn FROM Produkter WHERE Kategori = @Kategori", conn);
                cmd.Parameters.AddWithValue("@Kategori", kategori);
                cmd.CommandType = CommandType.Text;
                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                reader.Close();
            }

            ListArtic.Items.Clear();
            ListArtic.Items.Add(new ListItem("Velg produkt", ""));

            foreach (DataRow row in dt.Rows)
            {
                ListItem item = new ListItem(row["Navn"].ToString(), row["Navn"].ToString());
                ListArtic.Items.Add(item);
            }
        }

        protected void DropDownListKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedKategori = ListDesc.SelectedValue;
            BindDropDownListProdukter(selectedKategori);
            ListArtic.Items.Add(new ListItem("Ny produkt", "Ny produkt"));
        }


        protected void Lagre_Click(object sender, EventArgs e)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnCms"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql;
                if (ListArtic.SelectedValue == "Ny produkt")
                {
                    // SQL for å legge til et nytt produkt
                    sql = "INSERT INTO Produkter (Kategori, Navn, Pris) VALUES (@Kategori, @Navn, @Pris)";
                    lbl.Text = "Lagret ny produkt";
                }
                else
                {
                    // SQL for å oppdatere eksisterende produkt
                    sql = "UPDATE Produkter SET Navn = @Navn, Pris = @Pris WHERE Navn = @OldNavn";
                    lbl.Text = "Oppdatert produktet";
                }

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@Kategori", ListDesc.SelectedValue);
                cmd.Parameters.AddWithValue("@Navn", textnavn.Text);
                cmd.Parameters.AddWithValue("@Pris", Convert.ToDecimal(textpris.Text));

                if (ListArtic.SelectedValue != "Ny produkt")
                {
                    cmd.Parameters.AddWithValue("@OldNavn", ListArtic.SelectedValue);
                }

                cmd.ExecuteNonQuery();
            }

            BindDropDownListProdukter(ListDesc.SelectedValue);

        }



        protected void ListArtic_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListArtic.SelectedValue == "Ny produkt")
            {
                textnavn.Text = ""; // Tømmer tekstboksene for navn og pris
                textpris.Text = "";
            }
            else 
            {
                // tekstboksene med navn og pris for det valgte produktet
                string selectedProduct = ListArtic.SelectedValue;
                var connectionString = ConfigurationManager.ConnectionStrings["ConnCms"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT Navn, Pris FROM Produkter WHERE Navn = @Navn", conn);
                    cmd.Parameters.AddWithValue("@Navn", selectedProduct);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        textnavn.Text = reader["Navn"].ToString();
                        textpris.Text = reader["Pris"].ToString();
                    }
                    reader.Close();
                }
                
            }
            
            
        }

        protected void slettmeny_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(ListArtic.SelectedValue))
            {
                string selectedProduct = ListArtic.SelectedValue;
                var connectionString = ConfigurationManager.ConnectionStrings["ConnCms"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Bruk en DELETE-spørring for å slette produktet basert på navn
                    SqlCommand cmd = new SqlCommand("DELETE FROM Produkter WHERE Navn = @Navn;", conn);
                    cmd.Parameters.AddWithValue("@Navn", selectedProduct);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    // Sjekk om spørringen faktisk slettet noen rader
                    if (rowsAffected > 0)
                    {
                        lbll.Text = "Produktet har blitt slettet.";
                    }
                    else
                    {
                        lbll.Text = "Produktet ble ikke funnet eller kunne ikke slettes.";
                    }
                }

                // Oppdater drop down for å reflektere endringene
                BindDropDownListKategori();
                ListArtic.Items.Clear();
                ListArtic.Items.Add(new ListItem("Velg produkt", ""));
            }
            else
            {
                lbll.Text = "Velg produkt for å slette.";
            }




        }

        protected void ukemenybtn_Click(object sender, EventArgs e)
        {
           
                var connectionString = ConfigurationManager.ConnectionStrings["ConnCms"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                //sletter data
                    var deleteCmd = new SqlCommand("DELETE FROM Meny", conn);
                    deleteCmd.ExecuteNonQuery();

                    // Velg fem unike tilfeldige retter fra kategorien rett
                    // og tilordne dem til ukedagene.
                    var insertCmd = new SqlCommand(@"
                        WITH RandomRetter AS (
                            SELECT TOP 5 ProduktID, NEWID() as RandomOrder
                            FROM Produkter
                            WHERE Kategori = 'RETT'
                            ORDER BY NEWID()
                        )
                        INSERT INTO Meny (Dag, ProduktID)
                        SELECT 
                            CASE 
                                WHEN ROW_NUMBER() OVER(ORDER BY RandomOrder) = 1 THEN 'Mandag'
                                WHEN ROW_NUMBER() OVER(ORDER BY RandomOrder) = 2 THEN 'Tirsdag'
                                WHEN ROW_NUMBER() OVER(ORDER BY RandomOrder) = 3 THEN 'Onsdag'
                                WHEN ROW_NUMBER() OVER(ORDER BY RandomOrder) = 4 THEN 'Torsdag'
                                WHEN ROW_NUMBER() OVER(ORDER BY RandomOrder) = 5 THEN 'Fredag'
                            END as Dag,
                            ProduktID
                        FROM RandomRetter", conn);

                    insertCmd.ExecuteNonQuery();
                }
            lblll.Text = "Lagret ny ukesmeny.";
        }


    }
}




