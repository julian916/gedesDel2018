using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.Login
{
    public partial class SeleccionNuevoHotel_RolForm : Form
    {
        private int id_usuario;
        public int id_hotelIngresado;
        public int id_rolIngresado;
        private SqlConnection connection;
        public SeleccionNuevoHotel_RolForm(int idUsuario, SqlConnection con)
        {
            
            this.id_usuario = idUsuario;
            this.connection= con;
            InitializeComponent();
        }

        private void SeleccionNuevoHotel_RolFormcs_Load(object sender, EventArgs e)
        {
            Repositorios.RepositorioRoles repoRoles = new Repositorios.RepositorioRoles();
            Repositorios.RepositorioHoteles repoHoteles = new Repositorios.RepositorioHoteles();

            rolesComboBox.DisplayMember = "nombre";
            rolesComboBox.ValueMember = "id_rol";
            rolesComboBox.DataSource = repoRoles.getAll();

            hotelesComboBox.DisplayMember = "dir_Hotel";
            hotelesComboBox.ValueMember = "id_Hotel";
            hotelesComboBox.DataSource = repoHoteles.getAll();
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            SqlCommand spCommand = new SqlCommand("CUATROGDD2018.sp_asignarHotelYRolAUsuario", connection);
            spCommand.CommandType = CommandType.StoredProcedure;
            spCommand.Parameters.Clear();
            spCommand.Parameters.Add(new SqlParameter("@idUsuario", id_usuario));
            spCommand.Parameters.Add(new SqlParameter("@idRol", rolesComboBox.SelectedValue));
            spCommand.Parameters.Add(new SqlParameter("@idHotel", hotelesComboBox.SelectedValue));

            try
            {
                int filasAfectadas = spCommand.ExecuteNonQuery();
                if (filasAfectadas >1) // Se actulizò correctamente
                {
                    MessageBox.Show("Se actualizaron permisos");
                    id_hotelIngresado = Int32.Parse(hotelesComboBox.SelectedValue.ToString());
                    id_rolIngresado = Int32.Parse(rolesComboBox.SelectedValue.ToString());
                   
                }
                else
                {
                    throw new System.ArgumentException("Reingrese los datos. Falla al actualizar");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Error al actualizar. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
       
        }

    }
}
