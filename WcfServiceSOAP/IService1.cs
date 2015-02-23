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
   // [ServiceContract(Namespace="http://craigwoollett.com/servicesV1")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://KnockKnock.readify.net", ConfigurationName="IRedPill")]

  //  [ServiceContract]
    public interface IRedPill
    {
       // [System.ServiceModel.OperationContractAttribute(Action = "http://KnockKnock.readify.net/IRedPill/WhatIsYourToken", ReplyAction = "http://KnockKnock.readify.net/IRedPill/WhatIsYourTokenResponse")]
       // this operations_contract has explicit defintions as generated with the svcutil , normally defined in the service contract attribute
        [OperationContract]
        System.Guid WhatIsYourToken();
       
        [OperationContract]
        [FaultContract(typeof(ArgumentOutOfRangeException))]
        long FibonacciNumber(long n);
        
        // need to define an exception to be returned to the soap client
        

        [OperationContract]
        [FaultContract(typeof(NullReferenceException))]
        [FaultContract(typeof(ArgumentNullException))]
        string ReverseWords(string s);   

        [OperationContract]
        TriangleType WhatShapeIsThis(int a, int b, int c);


            
        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class NullReferenceFault
    {
         [DataMember]
    public bool Result { get; set; }
    [DataMember]
    public string Message { get; set; }
    [DataMember]
    public string Description { get; set; }
    }

    [DataContract]
    public class ArgumentNullFault
    {
         [DataMember]
    public bool Result { get; set; }
    [DataMember]
    public string Message { get; set; }
    [DataMember]
    public string Description { get; set; }
    }
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



    [DataContract]
        public enum TriangleType : int
    {
        
        [EnumMember]
        Error = 0,
        [EnumMember]      
        Equilateral = 1,
        
        [EnumMember]
        Isosceles = 2,
        
        [EnumMember]
        Scalene = 3,
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
