﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab03
{
    public partial class Persona : Form
    {
        SqlConnection conn = new SqlConnection("Data Source = LAPTOP-GM45TMSI\\SQLEXPRESS; Initial Catalog = db_lab03; Integrated Security = True");

        public Persona(SqlConnection conn)
        {
            this.conn = conn;
            InitializeComponent();
        }   
            
        private void btnListar_Click(object sender, EventArgs e) 
        {
            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                String sql = "select * from tbl_usuario";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);
                dgvListado.DataSource = dt;
                dgvListado.Refresh();
            }
            else
            {
                MessageBox.Show("La conexión esta cerrada");
            }
        }
    }
}
