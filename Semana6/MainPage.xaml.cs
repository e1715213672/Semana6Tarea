using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Semana6
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }


        private void btnInsertar_Clicked(object sender, EventArgs e)
        {
            try {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("codigo", txtCodigo.Text);
                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("apellido", txtApellido.Text);
                parametros.Add("edad", txtEdad.Text);
                cliente.UploadValues("http://192.168.0.4/moviles/post.php", "POST", parametros);
                DisplayAlert("Mensaje de Alerta", "Registro Almacenado correctamente", "Ok");

            }
            catch (Exception ex)
            {
                DisplayAlert("Mensaje de Alerta", ex.Message, "Ok");
            }
        }

        private void btnRegresar_Clicked(object sender, EventArgs e)
        {

        }

        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                const string uri = "http://192.168.0.4/moviles/post.php";
                WebClient cliente = new WebClient();
                
                Datos data = new Datos();
                data.codigo = int.Parse(txtCodigo.Text);
                data.nombre = txtNombre.Text;
                data.apellido = txtApellido.Text;
                data.edad = int.Parse(txtEdad.Text);
                var content = JsonConvert.SerializeObject(data);

                var parametros = "";
                parametros = "?codigo=" + txtCodigo.Text + "&nombre=" + txtNombre.Text + "&apellido=" + txtApellido.Text + "&edad=" + txtEdad.Text;
                var urlPost = new Uri(uri + parametros);

                cliente.UploadString(urlPost, "PUT", content);
                DisplayAlert("Mensaje de Alerta", "Registro Actualizado correctamente", "Ok");

            }
            catch (Exception ex)
            {
                DisplayAlert("Mensaje de Alerta", ex.Message, "Ok");
            }
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                const string uri = "http://192.168.0.4/moviles/post.php";
                
                WebClient cliente = new WebClient();
                string parametros = "?codigo=" + txtCodigo.Text;
                var urlPost = new Uri(uri + parametros);
                
                cliente.UploadStringAsync(urlPost,"DELETE","");
                DisplayAlert("Mensaje de Alerta", "Registro Eliminado", "Ok");

            }
            catch (Exception ex)
            {
                DisplayAlert("Mensaje de Alerta", ex.Message, "Ok");
            }
        }
    }
}

