using Autodesk.PlatformServices.Auth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace APSAPITest
{
    public class LocalRedirectUri3LO : I3LOStorage
    {
        HttpListener _listener;
        public LocalRedirectUri3LO()
        {
            _listener = new HttpListener();
            _listener.Prefixes.Add("http://127.0.0.1:7001/");
        }
        public string GetCode()
        {
            while (true)
            {
                HttpListenerContext ctx = _listener.GetContext();
                HttpListenerRequest req = ctx.Request;
                var code = req.QueryString["code"];

                if (code != null)
                {
                    using (HttpListenerResponse resp = ctx.Response)
                    {
                        resp.StatusCode = 200;
                        resp.StatusDescription = "OK";
                        string data = "Authenticated! You can close this window now";
                        byte[] buffer = Encoding.UTF8.GetBytes(data);
                        resp.ContentLength64 = buffer.Length;

                        using (Stream ros = resp.OutputStream)
                        {
                            ros.Write(buffer, 0, buffer.Length);
                        }
                    }
                    return code;
                }
                Thread.Sleep(500);
            }
        }

        public string GetRefreshToken(string identifier)
        {
            var t = Obtain(identifier);
            return t.Refresh_Token;
        }

        public ThreeLeggedToken Obtain(string identifier)
        {
            ThreeLeggedToken t;
            using (var sw = new StreamReader(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "token.json")))
            {
                var j = sw.ReadToEnd();
                t = JsonConvert.DeserializeObject<ThreeLeggedToken>(j);
            }
            return t;
        }

        public void ObtainCode(string url)
        {
            _listener.Start();
            System.Diagnostics.Process.Start(url);
        }

        public string ResponseType()
        {
            return "code";
        }

        public void Store(ThreeLeggedToken t, string identifier)
        {
            var j = JsonConvert.SerializeObject(t);
            using (var sw = new StreamWriter(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "token.json")))
            {
                sw.WriteLine(j);
            }
        }
    }
}
