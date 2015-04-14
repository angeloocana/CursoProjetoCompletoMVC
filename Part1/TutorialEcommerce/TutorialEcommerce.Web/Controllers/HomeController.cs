using System.IO;
using System.Net;
using System.Text;
using System.Web.Mvc;

namespace TutorialEcommerce.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Teste
        public string Index()
        {
            string UrlCorreios = "http://www2.correios.com.br/sistemas/rastreamento/resultado.cfm";
            string numero = "XX123456789XX";
            string codigoFonte = "";

            ASCIIEncoding encoding = new ASCIIEncoding();

            HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(UrlCorreios);
            httpRequest.Method = "POST";
            httpRequest.ContentType = "application/x-www-form-urlencoded";

            StreamWriter requestWriter = new StreamWriter(httpRequest.GetRequestStream());
            requestWriter.Write("objetos=" + numero);
            requestWriter.Close();

            StreamReader responseReader = new StreamReader(httpRequest.GetResponse().GetResponseStream());
            codigoFonte = responseReader.ReadToEnd();
            responseReader.Close();

            return codigoFonte;
        }
    }
}