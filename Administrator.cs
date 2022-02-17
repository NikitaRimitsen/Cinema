using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kinoteatr_bilet
{
    public partial class Administrator : Form
    {

        static string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\nikit\source\repos\Cinemaaa\AppData\Kino_DB.mdf;Integrated Security=True";
        /*Надо менять            ↑ ↑ ↑ ↑ ↑ ↑ ↑  вот это, если ты пересел за другой комп!!!!!!!!!*/
        SqlConnection connect_to_DB = new SqlConnection(conn);

        SqlCommand command;
        SqlDataAdapter adapter;

        Button film_uuenda;
        Button film_kustuta;
        Button film_insert;

        Button pileti_update;
        Button pileti_kustuta;
        Label lbl1;
        Label lbl2;
        Label lbl3;
        Label lblpi1;
        Label lblpi2;
        Label lblpi3;
        Label lblpi4;
        public Administrator()
        {
            this.ClientSize = new System.Drawing.Size(720, 500);


            Button naita = new Button
            {
                Text = "Naita",
                Location = new System.Drawing.Point(40, 25),//Point(x,y)
                Height = 40,
                Width = 100,
                BackColor = Color.LightYellow
            };
            naita.Click += Film_naita_Click;


            Button piletinaita = new Button
            {
                Text = "PiletiNaita",
                Location = new System.Drawing.Point(160, 25),//Point(x,y)
                Height = 40,
                Width = 100,
                BackColor = Color.LightYellow
            };
            piletinaita.Click += Piletinaita_Click;


            Button vexod = new Button
            {
                Text = "Väljund",
                Location = new System.Drawing.Point(580, 25),//Point(x,y)
                Height = 40,
                Width = 100,
                BackColor = Color.LightYellow
            };
            vexod.Click += Vexod_Click;


            film_uuenda = new Button
            {
                Location = new System.Drawing.Point(600, 75),
                Size = new System.Drawing.Size(80, 25),
                Text = "Uuendamine",
                Visible = false,
                BackColor = Color.LightYellow
            };
            film_uuenda.Click += Film_uuenda_Click;

            film_kustuta = new Button
            {
                Location = new System.Drawing.Point(600, 100),
                Size = new System.Drawing.Size(80, 25),
                Text = "Kustuta",
                Visible = false,
                BackColor = Color.Salmon
            };
            film_kustuta.Click += Film_kustuta_Click;


            film_insert = new Button
            {
                Location = new System.Drawing.Point(600, 125),
                Size = new System.Drawing.Size(80, 25),
                Text = "Lisa uus",
                Visible = false,
                BackColor = Color.PaleGreen
            };
            film_insert.Click += Film_insert_Click;
            /*------------------------------------Button___Pileti------------------------*/

            pileti_kustuta = new Button
            {
                Location = new System.Drawing.Point(600, 100),
                Size = new System.Drawing.Size(80, 25),
                Text = "Kustuta",
                Visible = false,
                BackColor = Color.Salmon
            };
            pileti_kustuta.Click += Pileti_kustuta_Click;

            pileti_update = new Button
            {
                Location = new System.Drawing.Point(600, 75),
                Size = new System.Drawing.Size(80, 25),
                Text = "Uuendamine",
                Visible = false,
                BackColor = Color.LightYellow
            };
            pileti_update.Click += Pileti_update_Click;


            /*-----Label____Filmi----*/
            lbl1 = new Label
            {
                Text = "Nimi:",
                Size = new System.Drawing.Size(50, 25),
                Location = new System.Drawing.Point(400, 75),
                Font = new Font("Oswald", 8, FontStyle.Bold),
                Visible = false
            };

            lbl2 = new Label
            {
                Text = "Aasta:",
                Size = new System.Drawing.Size(50, 25),
                Location = new System.Drawing.Point(400, 100),
                Font = new Font("Oswald", 8, FontStyle.Bold),
                Visible = false
            };

            lbl3 = new Label
            {
                Text = "Pilt:",
                Size = new System.Drawing.Size(50, 25),
                Location = new System.Drawing.Point(400, 125),
                Font = new Font("Oswald", 8, FontStyle.Bold),
                Visible = false
            };



            /*-----------Label_____Pileti----------*/
            lblpi1 = new Label
            {
                Text = "Rida:",
                Size = new System.Drawing.Size(50, 25),
                Location = new System.Drawing.Point(400, 75),
                Font = new Font("Oswald", 8, FontStyle.Bold),
                Visible = false
            };

            lblpi2 = new Label
            {
                Text = "Koht:",
                Size = new System.Drawing.Size(50, 25),
                Location = new System.Drawing.Point(400, 100),
                Font = new Font("Oswald", 8, FontStyle.Bold),
                Visible = false
            };

            lblpi3 = new Label
            {
                Text = "Film:",
                Size = new System.Drawing.Size(50, 25),
                Location = new System.Drawing.Point(400, 125),
                Font = new Font("Oswald", 8, FontStyle.Bold),
                Visible = false
            };

            lblpi4 = new Label
            {
                Text = "Zaal:",
                Size = new System.Drawing.Size(50, 25),
                Location = new System.Drawing.Point(400, 150),
                Font = new Font("Oswald", 8, FontStyle.Bold),
                Visible = false
            };

            /*------------Dobavlenie v formu*/
            this.Controls.Add(piletinaita);
            this.Controls.Add(lbl1);
            this.Controls.Add(lbl2);
            this.Controls.Add(lbl3);
            /*--------:)--------*/
            this.Controls.Add(lblpi1);
            this.Controls.Add(lblpi2);
            this.Controls.Add(lblpi3);
            this.Controls.Add(lblpi4);

            this.Controls.Add(vexod);
            this.Controls.Add(film_insert);
            this.Controls.Add(film_uuenda);
            this.Controls.Add(film_kustuta);
            this.Controls.Add(pileti_kustuta);
            this.Controls.Add(pileti_update);
            this.Controls.Add(naita);
            /*TextBox nimi = new TextBox
            {
                Location = new System.Drawing.Point(50, 40),//Point(x,y)
                Height = 80,
                Width = 150,
            };
            TextBox film = new TextBox
            {
                Location = new System.Drawing.Point(50, 80),//Point(x,y)
                Height = 80,
                Width = 150,
            };
            this.Controls.Add(nimi);
            this.Controls.Add(film);*/
        }



        private void Pileti_kustuta_Click(object sender, EventArgs e)
        {
            if (Id != 0)
            {
                command = new SqlCommand("DELETE Piletid WHERE Id=@Id", connect_to_DB);
                connect_to_DB.Open();
                command.Parameters.AddWithValue("@Id", Id);
                command.ExecuteNonQuery();
                connect_to_DB.Close();
                ClearPiletidData();
                DisplayPiletidData();
                MessageBox.Show("Piletid on kustutatud");
            }
            else
            {
                MessageBox.Show("Piletid viga kustutamisega");
            }
        }

        private void Pileti_update_Click(object sender, EventArgs e)
        {
            if (Rida_txt.Text != "" && Koht_txt.Text != "" && Film_txt.Text != "" && Zaal_txt.Text != "")
            {
                connect_to_DB.Open();
                command = new SqlCommand("UPDATE Piletid  SET Rida=@rida,Koht=@koht,Film=@film,Zaal=@zaal WHERE Id=@Id", connect_to_DB);

                command.Parameters.AddWithValue("@Id", Id);
                command.Parameters.AddWithValue("@rida", Rida_txt.Text);
                command.Parameters.AddWithValue("@koht", Koht_txt.Text);
                command.Parameters.AddWithValue("@film", Film_txt.Text);
                command.Parameters.AddWithValue("@zaal", Zaal_txt.Text);
                command.ExecuteNonQuery();
                connect_to_DB.Close();
                ClearPiletidData();
                DisplayPiletidData();
                MessageBox.Show("Piletid uuendatud");

            }
            else
            {
                MessageBox.Show("Viga");
            }
        }


        /*-------------------------------------------------*/
        private void Vexod_Click(object sender, EventArgs e)
        {
            Menu uus_aken = new Menu();//запускает пустую форму
            uus_aken.StartPosition = FormStartPosition.CenterScreen;
            uus_aken.Show();
            this.Hide();
        }

        DataGridView dataGridView_p;
        int chetpiletov = 0;
        TextBox Rida_txt, Koht_txt, Film_txt, Zaal_txt;
        public void Piletinaita_Click(object sender, EventArgs e)
        {


            if (chetpiletov == 0)
            {
                pileti_kustuta.Visible = true;
                pileti_update.Visible = true;

                lblpi1.Visible = true;
                lblpi2.Visible = true;
                lblpi3.Visible = true;
                lblpi4.Visible = true;

                Rida_txt = new TextBox
                {
                    Location = new System.Drawing.Point(450, 75),
                };
                Koht_txt = new TextBox
                {
                    Location = new System.Drawing.Point(450, 100),
                };
                Film_txt = new TextBox
                {
                    Location = new System.Drawing.Point(450, 125),
                };
                Zaal_txt = new TextBox
                {
                    Location = new System.Drawing.Point(450, 150),
                };

                pileti_Data();

                this.Controls.Add(Rida_txt);
                this.Controls.Add(Koht_txt);
                this.Controls.Add(Film_txt);
                this.Controls.Add(Zaal_txt);
                chetpiletov++;
            }
            else if (chetpiletov == 1)
            {
                pileti_kustuta.Visible = false;
                pileti_update.Visible = false;

                Rida_txt.Visible = false;
                Koht_txt.Visible = false;
                Film_txt.Visible = false;
                Zaal_txt.Visible = false;

                lblpi1.Visible = false;
                lblpi2.Visible = false;
                lblpi3.Visible = false;
                lblpi4.Visible = false;

                ocistka_piletov();
                //OcistkaData();

                chetpiletov = 0;
            }
            
        }


        private void pileti_Data()
        {
            connect_to_DB.Open();
            DataTable tabel_p = new DataTable();
            dataGridView_p = new DataGridView();
            dataGridView_p.RowHeaderMouseClick += DataGridView_p_RowHeaderMouseClick;
            DataSet dataset_p = new DataSet();
            SqlDataAdapter adapter_p = new SqlDataAdapter("SELECT * FROM [dbo].[Piletid]", connect_to_DB);

            //adapter_p.TableMappings.Add("Piletid", "Rida");
            //adapter_p.TableMappings.Add("Filmid", "Filmi_nimetus");
            //adapter_p.Fill(dataset_p);
            adapter_p.Fill(tabel_p);
            dataGridView_p.DataSource = tabel_p;
            dataGridView_p.Location = new System.Drawing.Point(10, 190);
            dataGridView_p.Size = new System.Drawing.Size(550, 200);


            SqlDataAdapter adapter_f = new SqlDataAdapter("SELECT Nimi FROM [dbo].[Film]", connect_to_DB);
            DataTable tabel_f = new DataTable();
            DataSet dataset_f = new DataSet();
            adapter_f.Fill(tabel_f);
            /*fkc = new ForeignKeyConstraint(tabel_f.Columns["Id"], tabel_p.Columns["Film_Id"]);
            tabel_p.Constraints.Add(fkc);*/
            //poster.Image = Image.FromFile("../../Posterid/ezik.jpg");

            /*DataGridViewComboBoxCell cbc = new DataGridViewComboBoxCell();
            ComboBox com_f = new ComboBox();
            foreach (DataRow row in tabel_f.Rows)
            {
                com_f.Items.Add(row["Nimi"]);
                cbc.Items.Add(row["Nimi"]);
            }*/
            //cbc.Value = com_f;
            connect_to_DB.Close();
            this.Controls.Add(dataGridView_p);
            //this.Controls.Add(com_f);
        }
        int Id = 0;

        private void DataGridView_p_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Id = Convert.ToInt32(dataGridView_p.Rows[e.RowIndex].Cells[0].Value.ToString());
            Rida_txt.Text = dataGridView_p.Rows[e.RowIndex].Cells[1].Value.ToString();
            Koht_txt.Text = dataGridView_p.Rows[e.RowIndex].Cells[2].Value.ToString();
            Film_txt.Text = dataGridView_p.Rows[e.RowIndex].Cells[3].Value.ToString();
            Zaal_txt.Text = dataGridView_p.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void ocistka_piletov()
        {
            dataGridView_p.Visible = false;
        }

        private void Film_insert_Click(object sender, EventArgs e)
        {
            if (film_txt.Text != "" && aasta_txt.Text != "" && poster_txt.Text != "")
            {
                try
                {
                    command = new SqlCommand("INSERT INTO Film(Nimi,Aasta,Pilt) VALUES(@nimi,@aasta,@pilt)", connect_to_DB);
                    connect_to_DB.Open();
                    command.Parameters.AddWithValue("@nimi", film_txt.Text);
                    command.Parameters.AddWithValue("@aasta", aasta_txt.Text);
                    string file_pilt = film_txt.Text + ".jpg";
                    command.Parameters.AddWithValue("@pilt", file_pilt);

                    command.ExecuteNonQuery();
                    connect_to_DB.Close();
                    ClearData();
                    DisplayData();
                    MessageBox.Show("Filmi on lisatud");
                }
                catch (Exception)
                {

                    MessageBox.Show("Filmi viga lisamisega");
                }
            }
            else
            {
                MessageBox.Show("Viga else");
            }
        }

        private void Film_kustuta_Click(object sender, EventArgs e)
        {
            if (Id_film != 0)
            {
                command = new SqlCommand("DELETE Film WHERE Id_film=@id", connect_to_DB);
                connect_to_DB.Open();
                command.Parameters.AddWithValue("@id", Id_film);
                command.ExecuteNonQuery();
                connect_to_DB.Close();
                ClearData();
                DisplayData();
                MessageBox.Show("Filmi on kustutatud");
            }
            else
            {
                MessageBox.Show("Filmi viga kustutamisega");
            }
        }

        TextBox film_txt, aasta_txt, poster_txt;
        PictureBox poster;
        DataGridView dataGridView;

        int Id_film;
        private void Film_uuenda_Click(object sender, EventArgs e)
        {
            if (film_txt.Text != "" && aasta_txt.Text != "" && poster_txt.Text != "" && poster.Image != null)
            {
                connect_to_DB.Open();
                command = new SqlCommand("UPDATE Film  SET Nimi=@nimi,Aasta=@aasta, Pilt=@pilt WHERE Id_film=@id", connect_to_DB);

                command.Parameters.AddWithValue("@id", Id_film);
                command.Parameters.AddWithValue("@nimi", film_txt.Text);
                command.Parameters.AddWithValue("@aasta", aasta_txt.Text);
                command.Parameters.AddWithValue("@pilt", poster_txt.Text);
                //string file_pilt = poster_txt.Text + ".jpg";
                //command.Parameters.AddWithValue("@pilt", file_pilt);
                command.ExecuteNonQuery();
                connect_to_DB.Close();
                ClearData();
                DisplayData();
                MessageBox.Show("Filmi uuendatud");

            }
            else
            {
                MessageBox.Show("Viga");
            }

        }
        int chet = 0;
        private void Film_naita_Click(object sender, EventArgs e)
        {
            if (chet == 0)
            {
                film_insert.Visible = true;
                film_uuenda.Visible = true;
                film_kustuta.Visible = true;

                lbl1.Visible = true;
                lbl2.Visible = true;
                lbl3.Visible = true;
                film_txt = new TextBox
                {
                    Location = new System.Drawing.Point(450, 75),
                };
                aasta_txt = new TextBox
                {
                    Location = new System.Drawing.Point(450, 100),
                };
                poster_txt = new TextBox
                {
                    Location = new System.Drawing.Point(450, 125),
                };
                poster = new PictureBox
                {
                    Size = new System.Drawing.Size(180, 250),
                    Location = new System.Drawing.Point(450, 150),
                    SizeMode = PictureBoxSizeMode.StretchImage
                };
                Data();
                chet++;
            }
            else if (chet == 1)
            {
                film_insert.Visible = false;
                film_uuenda.Visible = false;
                film_kustuta.Visible = false;

                film_txt.Visible = false;
                aasta_txt.Visible = false;
                poster_txt.Visible = false;
                poster.Visible = false;

                lbl1.Visible = false;
                lbl2.Visible = false;
                lbl3.Visible = false;
                OcistkaData();
                //ocistka_piletov();

                chet = 0;
            }


            /*connect_to_DB.Open();
            DataTable tabel = new DataTable();
            dataGridView = new DataGridView();
            dataGridView.RowHeaderMouseClick += DataGridView_RowHeaderMouseClick;
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT Id_film,Nimi,Aasta,Pilt FROM [dbo].[Film]", connect_to_DB);
            adapter.Fill(tabel);
            dataGridView.DataSource = tabel;
            dataGridView.Location = new System.Drawing.Point(10, 75);
            dataGridView.Size = new System.Drawing.Size(400, 200);*/

            this.Controls.Add(dataGridView);
            this.Controls.Add(film_txt);
            this.Controls.Add(aasta_txt);
            this.Controls.Add(poster_txt);
            this.Controls.Add(poster);

            //connect_to_DB.Close();
        }
        
        public void Data()
        {
            connect_to_DB.Open();
            DataTable tabel = new DataTable();
            dataGridView = new DataGridView();
            dataGridView.RowHeaderMouseClick += DataGridView_RowHeaderMouseClick;
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM [dbo].[Film]", connect_to_DB);
            adapter.Fill(tabel);
            dataGridView.DataSource = tabel;
            dataGridView.Location = new System.Drawing.Point(10, 170);
            dataGridView.Size = new System.Drawing.Size(430, 200);
            
            connect_to_DB.Close();

        }



        public void OcistkaData()
        {
            dataGridView.Visible = false;
        }
        private void DataGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            poster.Visible = true;
            Id_film = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString());
            film_txt.Text = dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
            aasta_txt.Text = dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
            poster_txt.Text = dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
            if (dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString() == "" /*|| poster_txt.Text == (@"C:..\..\Posterid\" + dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString())*/)
            {
                poster.Image = Image.FromFile(@"C:..\..\Posterid\ezik.jpg");
            }
            else
            {
                poster.Image = Image.FromFile(@"C:..\..\Posterid\" + dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString());
            }



            //string v = dataGridView.Rows[e.RowIndex].Cells[5].Value.ToString();
            //comboBox1.SelectedIndex = Int32.Parse(v) - 1;
        }

        private void DisplayData()
        {

            connect_to_DB.Open();
            DataTable tabel = new DataTable();
            adapter = new SqlDataAdapter("SELECT * FROM Film", connect_to_DB);
            adapter.Fill(tabel);
            dataGridView.DataSource = tabel;
            connect_to_DB.Close();

        }


        private void DisplayPiletidData()
        {

            connect_to_DB.Open();
            DataTable tabele = new DataTable();
            adapter = new SqlDataAdapter("SELECT * FROM Piletid", connect_to_DB);
            adapter.Fill(tabele);
            dataGridView_p.DataSource = tabele;
            connect_to_DB.Close();

        }

        private void ClearData()
        {
            //Id_film = 0;
            film_txt.Text = "";
            aasta_txt.Text = "";
            poster_txt.Text = "";
            //save.FileName = "";
            poster.Visible = false;
            //poster.Image = Image.FromFile("../../Posterid/ezik.jpg");
        }

        private void ClearPiletidData()
        {
            Rida_txt.Text = "";
            Koht_txt.Text = "";
            Film_txt.Text = "";
            Zaal_txt.Text = "";

        }

    }
}
