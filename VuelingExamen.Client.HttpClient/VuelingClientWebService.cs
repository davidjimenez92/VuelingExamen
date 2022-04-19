using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuelingExamen.Client.HttpClient
{
    public class VuelingClientWebService
    {
        public bool Add(IEnumerable<string> data, WebReference.FileType type)
        {
            WebReference.IVuelingWebService  vuelingWebService = new WebReference.VuelingWebServiceClient();
            return vuelingWebService.Add(data.ToArray(), type);
        }
    }
}
