﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_da_Biblioteca
{
    public partial class Livros : Form
    {
        public Livros()
        {
            InitializeComponent();
        }

        private void Livros_Load(object sender, EventArgs e)
        {
            CarregarDadosBanco();
        }

        private void CarregarDadosBanco()
        {

            string strconn = "server=localhost;database=db_bibliotea;uid=root;pwd=";
            MySqlConnection conexaoMYSQL = null ;
            
            MySqlDataAdapter mda = null;
            try
            {
                conexaoMYSQL = new MySqlConnection(strconn);
                conexaoMYSQL.Open();

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    if (textBoxPesquisa.Text!=string.Empty)
                    {
                        cmd.Parameters.AddWithValue("@nome", textBoxPesquisa.Text + "%");
                    }
                    string msql = "select * from tb_livro";
                    if (textBoxPesquisa.Text != string.Empty)
                    {
                        msql += " where nome like @nome ";
                    }

                    mda = new MySqlDataAdapter(cmd);
                    DataTable mdt = new DataTable();
                    mda.Fill(mdt);
                    dataGridLivro.DataSource = mda;

                }

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CarregarDadosBanco();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Telauser telauser = new Telauser();
            telauser.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
         telainicial1 telainicial = new telainicial1();
            telainicial.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddNewBook addNewBook = new AddNewBook();
            addNewBook.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridLivro_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            telainicial1 Telainicial1 = new telainicial1();
            Telainicial1.Show();
            this.Close();
        }
    }
}
