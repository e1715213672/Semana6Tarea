using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Semana6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Consulta : ContentPage
    {
        private const string Url = "http://192.168.0.4/moviles/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Semana6.Datos> _post;
        public Consulta()
        {
            InitializeComponent();
        }

        private async void btnGet_Clicked(object sender, EventArgs e)
        {
            var content = await client.GetStringAsync(Url);
            List<Semana6.Datos> posts = JsonConvert.DeserializeObject<List<Semana6.Datos>>(content);
            _post = new ObservableCollection<Semana6.Datos>(posts);
            MyListView.ItemsSource = _post;
        }
    }
}