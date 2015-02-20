using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfServiceSOAP
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(Namespace="http://craigwoollett.com/servicesV1")]
  //  [ServiceContract]
    public interface ICraig
    {

        [OperationContract]
        [FaultContract(typeof(ArgumentOutOfRangeException))]
        long fibonacci(long i);
        
        // need to define an exception to be returned to the soap client
        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        [OperationContract]
        Guid WhatIsYourToken();
    
        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class ArgumentOutOfRangeFault
    {
         [DataMember]
    public bool Result { get; set; }
    [DataMember]
    public string Message { get; set; }
    [DataMember]
    public string Description { get; set; }
    }
    
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
