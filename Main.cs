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
using Microsoft.Data.SqlClient;
using System.Data;
using ScottPlot;

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
        double umbral;
        SqlConnection oCnn;
        string cs;
        SqlCommand sqlCommand;
        SqlDataReader rdr;
        double timeOffset;


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
                timeOffset = 0; //double.Parse(configuracion.GetSection("MiConfiguracion:TimeOffset").Value);
                cs = configuracion.GetSection("MiConfiguracion:CS").Value;
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

        private void ToLog(string s)
        {
            lstLog.Items.Add(DateTime.Now.ToLongTimeString() + ": " + s);
            lstLog.SelectedIndex = lstLog.Items.Count - 1;
        }

        private async void btnIngresar_Click(object sender, EventArgs e)
        {
            await Inicio();
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

            oCnn = new SqlConnection(cs);
            await oCnn.OpenAsync();
            //oCnn = new SqlConnection(ConfigurationSettings.AppSettings["Cnn"]);
            //oCnn = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=ArbitradorGDAL;Integrated Security=SSPI;");
            ToLog("SQL Server conectado Ok");

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
                if (marketData.Data.Bids.Length > 0)
                {
                    bid = marketData.Data.Bids.FirstOrDefault().Price;
                    bidSize = marketData.Data.Bids[0].Size;
                }
                decimal offer = 0;
                decimal offerSize = 0;
                if (marketData.Data.Offers.Length > 0)
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

                //ToLog(ticker);
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

            ticker1askSize = ticker.offerSize;
            txtTicker1askSize.Text = ticker.offerSize.ToString();

            ticker2 = cboTicker2.Text;
            ticker = tickers.FirstOrDefault(t => t.NombreMedio == ticker2 + cboPlazo.Text);

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

            RefreshChart();

            //DB
            if (int.Parse(Ahora().ToString("HHmm")) >= 1102 && int.Parse(Ahora().ToString("HHmm")) <= 1700)
            {
                if (ticker1Bid > 0 && ticker1Last > 0 && ticker1Ask > 0 && ticker2Bid > 0 && ticker2Last > 0 && ticker2Ask > 0)
                {
                    SqlCommand sqlCommand = oCnn.CreateCommand();
                    sqlCommand.CommandText = "sp_MD_INS";
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@dt", Ahora());
                    sqlCommand.Parameters.AddWithValue("@GD30Bid", ticker1Bid);
                    sqlCommand.Parameters.AddWithValue("@GD30Last", ticker1Last);
                    sqlCommand.Parameters.AddWithValue("@GD30Ask", ticker1Ask);
                    sqlCommand.Parameters.AddWithValue("@AL30Bid", ticker2Bid);
                    sqlCommand.Parameters.AddWithValue("@AL30Last", ticker2Last);
                    sqlCommand.Parameters.AddWithValue("@AL30Ask", ticker2Ask);
                    sqlCommand.ExecuteNonQuery();
                }
            }



            txtTenenciaTicker1.Text = "0";
            txtTenenciaTicker2.Text = "0";

            response = GetResponseGET(sURL + "/api/v2/portafolio/argentina", bearer);
            if (response.Contains("Error") || response.Contains("timed out") || 
                response.Contains("tiempo de espera") || response.Contains("remoto") ||
                response.Contains("401"))
            { ToLog("Error de obtención de tenencia: " + response); }
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

            if (iTenenciaTicker1 <= ticker1bidSize)
            {
                ventaTicker1 = (ticker1Bid * iTenenciaTicker1) / 100;
                txtVentaTicker1.Text = ventaTicker1.ToString();

                compraTicker2 = (ventaTicker1 / ticker2Ask) * 100;
                if (compraTicker2 <= ticker2askSize)
                {
                    txtCompraTicker2.Text = compraTicker2.ToString();
                }
                else
                {
                    txtCompraTicker2.Text = "0";
                    txtVentaTicker1.Text = "0";
                }
            }
            else
            {
                txtVentaTicker1.Text = "0";
                txtCompraTicker2.Text = "0";
            }

            if (iTenenciaTicker2 <= ticker2bidSize)
            {
                ventaTicker2 = (ticker2Bid * iTenenciaTicker2) / 100;
                txtVentaTicker2.Text = ventaTicker2.ToString();

                compraTicker1 = (ventaTicker2 / ticker1Ask) * 100;
                if (compraTicker1 <= ticker1askSize)
                {
                    txtCompraTicker1.Text = compraTicker1.ToString();
                }
                else
                {
                    txtCompraTicker1.Text = "0";
                    txtVentaTicker2.Text = "0";
                }
            }
            else
            {
                txtCompraTicker1.Text = "0";
                txtVentaTicker2.Text = "0";
            }
            if (txtMM.Text != "")
            {
                delta1a2 = Math.Round(double.Parse(txtDelta1a2.Text) - double.Parse(txtMM.Text), 2);
                txtDelta1a2.Text = delta1a2.ToString();
                delta2a1 = Math.Round(double.Parse(txtMM.Text) - double.Parse(txtDelta2a1.Text), 2);
                txtDelta2a1.Text = delta2a1.ToString();

                if (int.Parse(DateTime.Now.ToString("HHmm")) >= 1110 && int.Parse(DateTime.Now.ToString("HHmm")) <= 1655)
                {
                    if (chkAuto.Checked)
                    {
                        umbral = double.Parse(cboUmbral.Text);

                        if (iTenenciaTicker2 > 0 && compraTicker1 > 0)
                        {
                            if (delta2a1 >= umbral)
                            {
                                if (chkBandas.Checked == false ||
                                    (chkBandas.Checked == true && double.Parse(txtBandaInf.Text) >= double.Parse(txtDelta2a1.Text)))
                                {
                                    SystemSounds.Asterisk.Play();
                                    Rotar2a1();
                                }
                            }
                        }



                        if (iTenenciaTicker1 > 0 && compraTicker2 > 0)
                        {
                            if (delta2a1 >= umbral)
                            {
                                if (chkBandas.Checked == false ||
                                (chkBandas.Checked == true && double.Parse(txtBandaSup.Text) <= double.Parse(txtDelta2a1.Text)))
                                {
                                    SystemSounds.Asterisk.Play();
                                    Rotar1a2();
                                }
                            }
                        }
                    }
                }
            }

        }
        private void RefreshChart()
        {
            sqlCommand = oCnn.CreateCommand();
            sqlCommand.CommandText = "sp_GetDataSet";
            sqlCommand.Parameters.Add("@dt", SqlDbType.DateTime).Value = Ahora();
            rdr = sqlCommand.ExecuteReader();

            var dtList = new List<DateTime>();
            var ratioList = new List<double>();
            var mm180List = new List<double>();
            var gdalList = new List<double>();
            var algdList = new List<double>();
            while (rdr.Read())
            {
                dtList.Add(Convert.ToDateTime(rdr["DT"]));
                ratioList.Add(Convert.ToDouble(rdr["Ratio"]));
                mm180List.Add(Convert.ToDouble(rdr["MM180"]));
                gdalList.Add(Convert.ToDouble(rdr["GDAL"]));
                algdList.Add(Convert.ToDouble(rdr["ALGD"]));
            }
            rdr.Close();
            double[] xs = dtList.Select(dt => dt.ToOADate()).ToArray();
            double[] ratioYs = ratioList.ToArray();
            double[] mm180Ys = mm180List.ToArray();
            double[] gdalYs = gdalList.ToArray();
            double[] algdYs = algdList.ToArray();

            crtGrafico.Plot.Clear();
            //crtGrafico.Plot.Add.Scatter(xs, ratioYs, label: "Ratio");
            crtGrafico.Plot.Add.Scatter(xs, ratioYs);
            /*
            crtGrafico.Plot.AddScatter(xs, mm180Ys, label: "MM180");
            crtGrafico.Plot.AddScatter(xs, gdalYs, label: "GDAL");
            crtGrafico.Plot.AddScatter(xs, algdYs, label: "ALGD");
            */
            // Configure plot (optional)
            crtGrafico.Plot.Title("My Plot");
            crtGrafico.Plot.XLabel("Date");
            crtGrafico.Plot.YLabel("Values");
            //crtGrafico.Plot.Legend();
            /*
            crtGrafico.Series[0].XValueMember = "DT";
            crtGrafico.Series[0].YValueMembers = "Ratio";
            crtGrafico.Series[1].YValueMembers = "MM180";
            crtGrafico.Series[2].YValueMembers = "GDAL";
            crtGrafico.Series[3].YValueMembers = "ALGD";
            crtGrafico.DataSource = rdr;
            crtGrafico.DataBind();
            */
            crtGrafico.Refresh();
            rdr.Close();

            sqlCommand = oCnn.CreateCommand();
            sqlCommand.CommandText = "sp_GetData";
            sqlCommand.Parameters.Add("@dt", SqlDbType.DateTime).Value = Ahora();
            rdr = sqlCommand.ExecuteReader();
            double Max;
            double Min;
            if (rdr.Read())
            {
                Min = Math.Floor(double.Parse(rdr["Piso"].ToString()));
                Max = Math.Ceiling(double.Parse(rdr["Techo"].ToString()));

                //crtGrafico.ChartAreas[0].AxisY.Minimum = Min;
                //crtGrafico.ChartAreas[0].AxisY.Maximum = Max;

                txtLastData.Text = rdr["DT"].ToString();
                //txtMax.Text = rdr["Techo"].ToString();
                //txtMin.Text = rdr["Piso"].ToString();
                //txtRatio.Text = rdr["Ratio"].ToString();
                //txtMM.Text = rdr["MM180"].ToString();
                //txtGDAL.Text = rdr["GDAL"].ToString();
                //txtALGD.Text = rdr["ALGD"].ToString();
                decimal vol = decimal.Parse(rdr["Desvio"].ToString());
                txtVolatilidad.Text = vol.ToString();
                if (chkAutoVol.Checked == true)
                {
                    if (vol > decimal.Parse("0,3"))
                    {
                        cboUmbral.Text = vol.ToString();
                    }
                    else
                    {
                        cboUmbral.Text = "0,3";
                    }
                }
            }
            rdr.Close();
        }

        private void btnRotar1a2_Click(object sender, EventArgs e)
        {
            Rotar1a2();
        }

        private void Rotar1a2()
        {
            int cantidadDesde;
            int cantidadHasta;
            double precioDesde;
            double precioHasta;

            cantidadDesde = int.Parse(txtTenenciaTicker1.Text);
            precioDesde = double.Parse(txtTicker1Bid.Text);
            //precioDesde += 2;

            cantidadHasta = (int)Math.Ceiling(double.Parse(txtCompraTicker2.Text));
            precioHasta = double.Parse(txtTicker2Ask.Text);

            if (cantidadDesde > 0 && precioDesde > 0 && precioHasta > 0 && cantidadHasta > 0)
            {
                Operar("GD30", cantidadDesde, precioDesde, "AL30", cantidadHasta, precioHasta);
            }

        }

        private void btnRotar2a1_Click(object sender, EventArgs e)
        {
            Rotar2a1();
        }

        private void Rotar2a1()
        {
            int cantidadDesde;
            int cantidadHasta;
            double precioDesde;
            double precioHasta;

            cantidadDesde = int.Parse(txtTenenciaTicker2.Text);
            precioDesde = double.Parse(txtTicker2Bid.Text);
            //precioDesde += 2;

            cantidadHasta = (int)Math.Ceiling(double.Parse(txtCompraTicker1.Text));
            precioHasta = double.Parse(txtTicker1Ask.Text);

            if (cantidadDesde > 0 && precioDesde > 0 && precioHasta > 0 && cantidadHasta > 0)
            {
                Operar("AL30", cantidadDesde, precioDesde, "GD30", cantidadHasta, precioHasta);
            }
        }

        private void Operar(string ticker1, int cantidadTicker1, double precioTicker1, string ticker2, int cantidadTicker2, double precioTicker2)
        {
            Login();
            ToLog("Iniciando");

            ToLog(ticker1 + " Q:" + cantidadTicker1 + " P:" + precioTicker1 + " -> "
                + ticker2 + " Q:" + cantidadTicker2 + " P:" + precioTicker2);

            Application.DoEvents();
            tmrRefresh.Enabled = false;
            tmrRefresh.Stop();

            int intentos = int.Parse(ConfigurationSettings.AppSettings["Intentos"]);
            ToLog("Venta de " + ticker1 + " Q: " + cantidadTicker1 + " P: " + precioTicker1);
            string operacionVenta = Vender(ticker1, cantidadTicker1, precioTicker1);
            if (operacionVenta != "Error")
            {
                string estadooperacion = "";
                for (int i = 1; i <= intentos; i++)
                {
                    ToLog("Intento de venta " + i.ToString() + " de " + ticker1);
                    estadooperacion = GetEstadoOperacion(operacionVenta);
                    ToLog("Intento " + i.ToString() + " estado " + estadooperacion);
                    if (estadooperacion == "terminada")
                    {
                        ToLog("Terminada venta");
                        break;
                    }
                    Application.DoEvents();
                }
                if (estadooperacion == "terminada")
                {
                    string operacionCompra = Comprar(ticker2, cantidadTicker2, precioTicker2);
                    ToLog("Compra de " + ticker2 + " Q: " + cantidadTicker2 + " P: " + precioTicker2);
                    if (operacionCompra != "Error")
                    {
                        estadooperacion = GetEstadoOperacion(operacionCompra);

                    }
                }
                else
                {
                    ToLog("Vencio la venta de " + ticker1);
                    ToLog("------------------------------");
                    WebRequest request = WebRequest.Create(sURL + "/api/v2/operaciones/" + operacionVenta);
                    request.Method = "DELETE";
                    request.ContentType = "application/json";
                    request.Headers.Add("Authorization", bearer);

                    try
                    {
                        WebResponse response = request.GetResponse();
                    }
                    catch (Exception e)
                    {
                        ToLog(e.Message);
                    }
                }
            }
            else
            {
                ToLog("Error en compra de " + ticker1);
                ToLog("------------------------------");
            }
            tmrRefresh.Enabled = true;
            tmrRefresh.Start();
            ToLog("Desocupado");
            ToLog("Fin--------------------------");
        }
        private string GetEstadoOperacion(string idoperacion)
        {
            string response;
            response = GetResponseGET(sURL + "/api/v2/operaciones/" + idoperacion, bearer);
            if (response.Contains("Error") || response.Contains("Se exced"))
            {
                return "Error";
            }
            else
            {
                dynamic json = JObject.Parse(response);
                return json.estadoActual.Value;
            }
        }

        private string Comprar(string simbolo, int cantidad, double precio)
        {
            ToLog("Comprando " + simbolo);
            Application.DoEvents();
            string validez = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "T17:59:59.000Z";
            string postData = "mercado=bCBA&simbolo=" + simbolo + "&cantidad=" + cantidad.ToString() + "&precio=" + precio.ToString().Replace(",", ".") + "&validez=" + validez + "&plazo=" + cboPlazo.Text;
            string response;
            response = GetResponsePOST(sURL + "/api/v2/operar/Comprar", postData);
            if (response.Contains("Error") || response.Contains("Se exced"))
            {
                return "Error";
            }
            else
            {
                dynamic json = JObject.Parse(response);
                string operacion = json.numeroOperacion;
                if (json.ok == "false")
                {
                    return "Error";
                }
                else
                {
                    return operacion;
                }
            }
        }

        private string Vender(string simbolo, int cantidad, double precio)
        {
            ToLog( "Vendiendo " + simbolo);
            Application.DoEvents();
            string validez = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "T17:59:59.000Z";
            string postData = "mercado=bCBA&simbolo=" + simbolo + "&cantidad=" + cantidad.ToString() + "&precio=" + precio.ToString().Replace(",", ".") + "&validez=" + validez + "&plazo=" + cboPlazo.Text;
            string response;
            response = GetResponsePOST(sURL + "/api/v2/operar/Vender", postData);
            dynamic json = JObject.Parse(response);
            string operacion = json.numeroOperacion;
            if (json.ok == "false")
            {
                return "Error";
            }
            else
            {
                return operacion;
            }
        }
        private DateTime Ahora()
        {
            TimeSpan timeSpan = TimeSpan.FromHours(timeOffset);
            DateTime ahora = DateTime.Now.Add(timeSpan);
            return ahora;
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
