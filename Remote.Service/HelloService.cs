using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using Remote.Interface;

namespace Remote.Service
{
    public class HelloService : ClientBase<IMyHelloService>, IService
    {
        public static readonly Binding binding = new NetNamedPipeBinding();
        public static readonly EndpointAddress endpointAddress = new EndpointAddress(new Uri("net.pipe://localhost/Hello"));

        public HelloService():base(binding,endpointAddress)
        {

        }
        public string Say(string name)
        {
            return Channel.SayHello(name);
        }
    }
}
