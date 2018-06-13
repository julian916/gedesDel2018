﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FrbaHotel.Repositorios
{
    public class RepositorioRoles
    {
        public SqlConnection sqlConnection = null;

        public RepositorioRoles(SqlConnection sqlConnection)
        {
            this.sqlConnection = sqlConnection;
            if (this.sqlConnection.State != ConnectionState.Open)
            {
                this.sqlConnection.Open();
            }
        }

        public DataTable getAll() {
            SqlCommand scRol = new SqlCommand("sp_RolesComboBox", sqlConnection);
            DataTable dtRol = new DataTable();
            dtRol.Load(scRol.ExecuteReader());
            return dtRol;
        }
    }
}