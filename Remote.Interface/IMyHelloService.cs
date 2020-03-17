using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Remote.Interface
{
    [ServiceContract]
    public interface IMyHelloService
    {
        [OperationContract]
        string SayHello(string name); 
    }
}
