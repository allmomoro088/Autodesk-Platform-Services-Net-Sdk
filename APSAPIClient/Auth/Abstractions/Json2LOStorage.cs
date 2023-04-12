using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Autodesk.PlatformServices.Auth
{
    /// <summary>
    /// A basic implementation of <see cref="I2LOStorage"/> to storage the Two Legged token in a .json file
    /// </summary>
    public class Json2LOStorage : I2LOStorage
    {
        string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "auth.json");

        public TwoLeggedToken Obtain()
        {
            TwoLeggedToken t = null;
            try
            {
                using (StreamReader streamReader = new StreamReader(path))
                {
                    t = JsonConvert.DeserializeObject<TwoLeggedToken>(streamReader.ReadToEnd());
                }
            }
            catch { }
            return t;
        }

        public void Store(TwoLeggedToken t)
        {
            using(StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(JsonConvert.SerializeObject(t));
            }
        }
    }
}
