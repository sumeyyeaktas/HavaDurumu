using System;
using System.Linq;
using System.Xml.Linq;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace HavaDurumu
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            HavaDurumu();
        }
        async void HavaDurumu()
        {
            string api = "e903931fa1caa64ce82d87fa68bc2a47";
            string baglanti = "http://api.openweathermap.org/data/2.5/weather?q=Mersin&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument Hava = System.Xml.Linq.XDocument.Load(baglanti);
            var sehir = Hava.Descendants("city").ElementAt(0).Attribute("name").Value;
            var sicaklik = Hava.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            var minSicaklik = Hava.Descendants("temperature").ElementAt(0).Attribute("min").Value;
            var maxSicaklik = Hava.Descendants("temperature").ElementAt(0).Attribute("max").Value;
            var icon = Hava.Descendants("weather").ElementAt(0).Attribute("icon").Value;
            var nem = Hava.Descendants("humidity").ElementAt(0).Attribute("value").Value;
            var basinc = Hava.Descendants("pressure").ElementAt(0).Attribute("value").Value;
            var bulut = Hava.Descendants("clouds").ElementAt(0).Attribute("value").Value;
            var ruzgar = Hava.Descendants("wind").ElementAt(0).Element("speed").Attribute("value").Value;
            imgWeather.Source = new Windows.UI.Xaml.Media.Imaging.BitmapImage(
                new Uri("http://openweathermap.org/img/w/" + icon + ".png", UriKind.Absolute));
            txtSehir.Text = sehir;
            txtSicaklik.Text = "Hava Sıcaklığı: " + sicaklik + " ºC";
            txtNem.Text = "Nem yüzdesi: % " + nem;
            txtBasinc.Text = "Basınç değeri: " + basinc;
            txtBulut.Text = "Bulut Yüzdesi:" + bulut;
            txtRuzgar.Text = "Rüzgar Oranı:" + ruzgar;
            txtMinSicaklik.Text = "Minimum Sıcaklık:" + minSicaklik;
            txtMaxSicaklik.Text = "Maximum Sıcaklık:" + maxSicaklik;
        }
    }

}
