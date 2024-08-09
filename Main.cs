using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;
using System.Configuration;
using System.Media;
using Primary;
using Primary.Data;

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
            this.Top = 10;
            this.Text = "BOT Swapper intraday - Copyright 2022 Tinchex Capital";
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
            cboPlazo.Items.AddRange(new string[] { "CI", "24" });
            cboPlazo.Text = "24";

            var configuracion = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
            try
            {
                cboUmbral.Text = configuracion.GetSection("MiConfiguracion:Umbral").Value;
                txtUsuarioIOL.Text = configuracion.GetSection("MiConfiguracion:UsuarioIOL").Value;
                txtClaveIOL.Text = configuracion.GetSection("MiConfiguracion:ClaveIOL").Value;
                txtUsuarioVETA.Text = configuracion.GetSection("MiConfiguracion:UsuarioVETA").Value;
                txtClaveVETA.Text = configuracion.GetSection("MiConfiguracion:ClaveVETA").Value;
            }
            catch (Exception ex)
            {

            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
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
            var socketTask = await socket.Start();
            socketTask.Wait(1000);
            ToLog("Websocket Ok");
            LoginIOL();
            ToLog("Login IOL Ok");
            tmrRefresh.Interval = 10000;
            tmrRefresh.Enabled = true;
            tmrRefresh.Start();
            await socketTask;

        }
        private void LoginIOL()
        {
            try
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
                    ToLog(bearer);
                }
                else
                {
                    if (DateTime.Now >= expires)
                    {
                        string postData = "refresh_token=" + refresh + "&grant_type=refresh_token";
                        string response;
                        response = GetResponsePOST(sURL + "/token", postData);
                        if (response.Contains("Error") || response.Contains("excedi"))
                        {
                            ToLog(response);
                        }
                        else
                        {
                            dynamic json = JObject.Parse(response);
                            bearer = "Bearer " + json.access_token;
                            expires = DateTime.Now.AddSeconds((double)json.expires_in - 100);
                            refresh = json.refresh_token;
                            ToLog(bearer);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ToLog(e.Message);
            }

        }


        private async void OnMarketData(Api api, MarketData marketData)
        {
            try
            {
                //En la versión Alpha era así. Gracias Juan Manuel Álvarez.
                //var ticker = marketData.Instrument.Symbol;
                var ticker = marketData.InstrumentId.Symbol;
                decimal bid = 0;
                decimal bidSize = 0;
                if (marketData.Data.Bids.Length>0)
                {
                    bid = marketData.Data.Bids.FirstOrDefault().Price;
                    bidSize = marketData.Data.Bids[0].Size;
                }
                decimal offer = 0;
                decimal offerSize = 0;
                if (marketData.Data.Offers.Length>0)
                {
                    offer = marketData.Data.Offers.FirstOrDefault().Price;
                    offerSize = marketData.Data.Offers[0].Size;
                }
                decimal last = 0;
                if (marketData.Data.Last != null)
                {
                    last = marketData.Data.Last.Price;
                }

                var elemento = tickers.Where<Ticker>(t => t.NombreLargo == ticker).FirstOrDefault<Ticker>();
                elemento.bidSize = (int)bidSize;
                elemento.bid = bid;
                elemento.offer = offer;
                elemento.offerSize = (int)offerSize;
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

        private void tmrRefresh_Tick(object sender, EventArgs e)
        {
            string ticker1, ticker2;
            int ticker1bidSize = 0, ticker2bidSize = 0;
            double ticker1Bid = 0, ticker2Bid = 0;
            double ticker1Last = 0, ticker2Last = 0;
            double ticker1Ask = 0, ticker2Ask = 0;
            int ticker1askSize = 0, ticker2askSize = 0;
            int iTenenciaTicker1 = 0, iTenenciaTicker2 = 0;
            double ventaTicker1 = 0, ventaTicker2 = 0;
            double compraTicker1 = 0, compraTicker2 = 0;
            double delta1a2 = 0, delta2a1 = 0;
            string response;

            Ticker ticker;
            //Login();

            ticker1 = cboTicker1.Text;
            ticker = tickers.FirstOrDefault(t => t.NombreMedio == ticker1 + cboPlazo.Text);

            ticker1Last = (double)ticker.last;
            txtTicker1Last.Text = ticker.last.ToString();

            ticker1bidSize = ticker.bidSize;
            txtTicker1bidSize.Text = ticker.bidSize.ToString();
            
            ticker1Bid = (double)ticker.bid;
            txtTicker1Bid.Text = ticker.bid.ToString();

            ticker1Ask = (double)ticker.offer;
            txtTicker1Ask.Text = ticker.offer.ToString();

            ticker1askSize=ticker.offerSize;
            txtTicker1askSize.Text = ticker.offerSize.ToString();

            ticker2 = cboTicker2.Text;
            ticker = tickers.FirstOrDefault(t=>t.NombreMedio==ticker2 + cboPlazo.Text);

            ticker2Last = (double)ticker.last;
            txtTicker2Last.Text = ticker.last.ToString();

            ticker2bidSize = ticker.bidSize;
            txtTicker2bidSize.Text = ticker.bidSize.ToString();

            ticker2Bid = (double)ticker.bid;
            txtTicker2Bid.Text = ticker.bid.ToString();

            ticker2Ask = (double)ticker.offer;
            txtTicker2Ask.Text = ticker.offer.ToString();

            ticker2askSize = ticker.offerSize;
            txtTicker2askSize.Text = ticker.offerSize.ToString();


            txtTenenciaTicker1.Text = "0";
            txtTenenciaTicker2.Text = "0";

            response = GetResponseGET(sURL + "/api/v2/portafolio/argentina", bearer);
            if (response.Contains("Error") || response.Contains("Anulada") || response.Contains("tiempo de espera") || response.Contains("remoto"))
            { Application.DoEvents(); }
            else
            {
                dynamic respuesta;
                respuesta = JArray.Parse("[" + response + "]");
                foreach (dynamic activo in respuesta[0].activos)
                {
                    if (activo.titulo.simbolo == ticker1)
                    {
                        iTenenciaTicker1 = (int)activo.cantidad;
                        txtTenenciaTicker1.Text = iTenenciaTicker1.ToString();
                    }
                    if (activo.titulo.simbolo == ticker2)
                    {
                        iTenenciaTicker2 = (int)activo.cantidad;
                        txtTenenciaTicker2.Text = iTenenciaTicker2.ToString();
                    }
                }
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
