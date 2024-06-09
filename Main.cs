using Primary;
using Newtonsoft.Json.Linq;
using Primary.Data;
using Microsoft.Extensions.Configuration;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net;
using System.Text;

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
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.Top = 10;
            this.Text = "BOT Swapper intraday - Copyright 2022 Tinchex Capital";
            DoubleBuffered = true;

        }
        private void Login()
        {
            if (expires == DateTime.MinValue)
            {
                string postData = "username=" + txtUsuario.Text + "&password=" + txtClave.Text + "&grant_type=password";
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
            txtStatus.Text = "Logoneado";
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
