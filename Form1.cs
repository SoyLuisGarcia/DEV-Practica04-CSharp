using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace practica4_py
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ConfigurarFondoEInterfaz();
        }

        private void ConfigurarFondoEInterfaz()
        {
            this.BackgroundImageLayout = ImageLayout.Stretch;
            string rutaImagen = @"C:\Ruta\De\Tu\Imagen.jpg";
            if (File.Exists(rutaImagen))
            {
                this.BackgroundImage = Image.FromFile(rutaImagen);
            }

            lblNombre.BackColor = Color.Transparent;
            lblApellido.BackColor = Color.Transparent;
            lblTelefono.BackColor = Color.Transparent;
            lblEdad.BackColor = Color.Transparent;
            lblEstatus.BackColor = Color.Transparent;
            gbGenero.BackColor = Color.Transparent;
            rbMasculino.BackColor = Color.Transparent;
            rbFemenino.BackColor = Color.Transparent;
            rbOtro.BackColor = Color.Transparent;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("Por favor, ingrese al menos el nombre y el apellido del usuario.",
                    "Campos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nombres = txtNombre.Text.Trim();
            string apellido = txtApellido.Text.Trim();
            string telefono = txtTelefono.Text.Trim();
            string edad = txtEdad.Text.Trim();
            string estatus = txtEstatus.Text.Trim();
            string genero = rbMasculino.Checked ? "Masculino" : (rbFemenino.Checked ? "Femenino" : (rbOtro.Checked ? "Otro" : "No especificado"));

            string registro = $"Nombres: {nombres}\nApellidos: {apellido}\nGénero: {genero}\nEdad: {edad}\nTeléfono: {telefono}\nEstatus: {estatus}\n----------------------------------------\n";

            string carpetaDocumentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string rutaFile = Path.Combine(carpetaDocumentos, "Datos.txt");

            try
            {
                using (StreamWriter escritor = new StreamWriter(rutaFile, append: true, encoding: Encoding.UTF8))
                {
                    escritor.WriteLine(registro);
                }
                MessageBox.Show($"Registro guardado con éxito en:\n{rutaFile}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnLimpiar_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al escribir archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            txtEdad.Clear();
            txtEstatus.Clear();
            rbMasculino.Checked = false;
            rbFemenino.Checked = false;
            rbOtro.Checked = false;
            txtNombre.Focus();
        }
    }
}