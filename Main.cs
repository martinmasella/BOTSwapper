using Primary;
using Newtonsoft.Json.Linq;
using Primary;
using Primary.Data;
using Microsoft.Extensions.Configuration;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;
using System.Configuration;
using System.Media;

namespace BOTSwapper

{
    public partial class Main : Form
    {
        const string sURL = "https://api.invertironline.com";
        const string SURLOper = "https://www.invertironline.com";
        const string sURLVETA = "https://api.veta.xoms.com.ar";
        const string prefijoPrimary = "MERV - XMEV - ";
        const string sufijoCI = " - CI";
        const string sufijo24 = " - 24hs";
        string tokenVETA;
        string bearer;
        string refresh;
        DateTime expires;
        List<string> nombres;
        List<Ticker> tickers;


        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.Top = 10;
            this.Text = "BOT Swapper intrgaday - Copyright 2022 Tinchex Capital";
            DoubleBuffered = true;
            CheckForIllegalCrossThreadCalls = false;
            nombres = new List<string>();
            tickers = new List<Ticker>();

            cboTicker1.Items.Add("GD30");
            cboTicker1.Text = "GD30";
            cboTicker2.Items.Add("AL30");
            cboTicker2.Text = "AL30";
            double umbral;
            for (umbral = 0.01; umbral <= 2; umbral += 0.01)
            {
                cboUmbral.Items.Add(Math.Round(umbral, 2));
            }
            cboUmbral.Text = "0,3";

            cboPlazo.Items.Clear();
            cboPlazo.Items.AddRange(new string[] { "t0", "t2" });
            cboPlazo.Text = "t0";

            var configuracion = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
            try
            {
                cboUmbral.Text= configuracion.GetSection("MiConfiguracion:Umbral").Value;
                txtUsuarioIOL.Text = configuracion.GetSection("MiConfiguracion:UsuarioIOL").Value;
                txtClaveIOL.Text = configuracion.GetSection("MiConfiguracion:ClaveIOL").Value;
                txtUsuarioVETA.Text = configuracion.GetSection("MiConfiguracion:UsuarioVETA").Value;
                txtClaveVETA.Text = configuracion.GetSection("MiConfiguracion:ClaveVETA").Value;
            }
            catch (Exception ex)
            {

            }

            SystemSounds.Exclamation.Play();
        }
        private void Login()
        {
            if (expires == DateTime.MinValue)
            {
                string postData = "username=" + txtUsuarioIOL.Text + "&password=" + txtClaveIOL.Text + "&grant_type=password";
                string response;
                response = GetResponsePOST(sURL + "/token", postData);
                dynamic json = JObject.Parse(response);
                bearer = "Bearer " + json.access_token;
                expires = DateTime.Now.AddSeconds((double)json.expires_in - 100);
                refresh = json.refresh_token;
                txtBearer.Text = json.access_token;
                //ToLog(bearer);
            }
            else
            {
                if (DateTime.Now >= expires)
                {
                    string postData = "refresh_token=" + refresh + "&grant_type=refresh_token";
                    string response;
                    response = GetResponsePOST(sURL + "/token", postData);
                    dynamic json = JObject.Parse(response);
                    bearer = "Bearer " + json.access_token;
                    expires = DateTime.Now.AddSeconds((double)json.expires_in - 100);
                    refresh = json.refresh_token;
                    txtBearer.Text = json.access_token;
                    //ToLog(bearer);
                }
            }
            tmrToken.Interval = 1000;
            tmrToken.Enabled = true;
            tmrToken.Start();
            ToLog("Logoneado en IOL");
        }

        private string GetResponsePOST(string sUrl, string sData, string sHeaders)
        {
            WebRequest request = WebRequest.Create(sURL);
            var data = Encoding.ASCII.GetBytes(sData);
            request.Timeout = 5000;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = sData.Length;

            if (bearer != null)
            {
                request.Headers.Add("Authorization", bearer);
            }
            try
            {
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
                WebResponse response = request.GetResponse();
                return new StreamReader(response.GetResponseStream()).ReadToEnd();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        private string GetResponsePOST(string sURL, string sData)
        {
            WebRequest request = WebRequest.Create(sURL);
            var data = Encoding.ASCII.GetBytes(sData);
            request.Timeout = 5000;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = sData.Length;

            if (bearer != null)
            {
                request.Headers.Add("Authorization", bearer);
            }
            try
            {
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
                WebResponse response = request.GetResponse();
                return new StreamReader(response.GetResponseStream()).ReadToEnd();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        private string GetResponseGET(string sURL, string sHeader)
        {
            WebRequest request = WebRequest.Create(sURL);
            request.Timeout = 5000;
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Headers.Add("Authorization", sHeader);
            try
            {
                WebResponse response = request.GetResponse();
                return new StreamReader(response.GetResponseStream()).ReadToEnd();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        private string GetResponseGETVETA(string sURL)
        {
            WebRequest request = WebRequest.Create(sURL);
            request.Timeout = 5000;
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Headers.Add("X-Auth-Token", tokenVETA);
            try
            {
                WebResponse response = request.GetResponse();
                return new StreamReader(response.GetResponseStream()).ReadToEnd();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        private void ToLog(string s)
        {
            lstLog.Items.Add(DateTime.Now.ToLongTimeString() + ": " + s);
            lstLog.SelectedIndex = lstLog.Items.Count - 1;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            Inicio();
        }

        private async Task Inicio()
        {
            var api = new Api(new Uri(sURLVETA));
            await api.Login(txtUsuarioVETA.Text, txtClaveVETA.Text);
            ToLog("Login VETA Ok");
            var allInstruments = await api.GetAllInstruments();
            var entries = new[] { Entry.Last, Entry.Bids, Entry.Offers };
            FillListaTickers();
            var instrumentos = allInstruments.Where(c => tickers.Any(t => t.NombreLargo == c.Symbol));
            using var socket = api.CreateMarketDataSocket(instrumentos, entries, 1, 1);
            socket.OnData = OnMarketData;
            var socketTask = socket.Start();
            socketTask.Wait(1000);
            ToLog("Websocket Ok");
            tmrRefresh.Interval = 10000;
            tmrRefresh.Enabled = true;
            tmrRefresh.Start();

            await socketTask;
        }

        private async void OnMarketData(Api api, MarketData marketData)
        {
            try
            {
                //En la versión Alpha era así. Gracias Juan Manuel Álvarez.
                //var ticker = marketData.Instrument.Symbol;
                var ticker = marketData.InstrumentId.Symbol;
                decimal bid = 0;
                if (marketData.Data.Bids != null)
                {
                    bid = marketData.Data.Bids.FirstOrDefault().Price;
                }
                decimal offer = 0;
                if (marketData.Data.Offers != null)
                {
                    offer = marketData.Data.Offers.FirstOrDefault().Price;
                }
                decimal last = 0;
                if (marketData.Data.Last != null)
                {
                    last = marketData.Data.Last.Price;
                }

                var elemento = tickers.Where<Ticker>(t => t.NombreLargo == ticker).FirstOrDefault<Ticker>();
                elemento.bid = bid;
                elemento.offer = offer;
                elemento.last = last;

                ToLog(ticker);
            }
            catch (Exception ex)
            {
                ToLog(ex.Message);
            }
        }

        private void FillListaTickers()
        {
            nombres.Add(cboTicker1.Text);
            nombres.Add(cboTicker2.Text);

            foreach (var nombre in nombres)
            {
                tickers.Add(new Ticker(prefijoPrimary + nombre + sufijoCI, nombre + "CI", nombre));
                tickers.Add(new Ticker(prefijoPrimary + nombre + sufijo24, nombre + "24", nombre));
            }
        }

    }

    public class Ticker
    {
        public string NombreLargo { get; set; }
        public string NombreMedio { get; set; }
        public string NombreCorto { get; set; }
        public int bidSize;
        public decimal bid;
        public decimal last;
        public decimal offer;
        public int offerSize;
        public Ticker(string nombrelargo, string nombremedio, string nombrecorto)
        {
            NombreLargo = nombrelargo;
            NombreMedio = nombremedio;
            NombreCorto = nombrecorto;
            bidSize = 0;
            bid = 0;
            last = 0;
            offer = 0;
        }
    }

}
