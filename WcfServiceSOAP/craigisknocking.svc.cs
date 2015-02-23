using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfServiceSOAP
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(Namespace="http://craigwoollett.com/servicesV1")]
   // [ServiceBehavior]
    public class CraigService : IRedPill
    {
        public long FibonacciNumber(long value)
        {

            
            long a = 1;
            long b = 0;
            try
            {
                if (value > 92) 
                {throw new FaultException<ArgumentOutOfRangeException>( new ArgumentOutOfRangeException("value"," greater than FIB(92) will cause 64bit integer overflow"), new FaultReason("FIB(92) or greater will cause 64bit integer overflow"));
                }

                // by definition fib(0) = 0
                if (value == 0) return (b);
                // In N steps compute Fibonacci sequence iteratively.
                for (int i = 1; i <= value; i++)
                {
                    long temp = a;
                    a = b;
                    b = checked(temp + b);
                }
                return b;
            }
            catch(ArgumentOutOfRangeException e)
            {

                ArgumentOutOfRangeFault fault = new ArgumentOutOfRangeFault();
                fault.Result = false;
                fault.Message = " FIb(92)> will result in a 64bit integer overflow, sorry your story is too large";
                fault.Description = " FIb(92)> will result in a 64bit integer overflow, sorry your story is too large";
                
                // now throw fault exception to be transmitted to client
               // throw new FaultException<ArgumentOutOfRangeFault>(fault);
                throw new FaultException<ArgumentOutOfRangeException>(e);
            }
        }

        public Guid  WhatIsYourToken()
    {
      //  Guid  myGuid = / Create a GUID with all zeros and compare it to Empty.
      Byte[] bytes = new Byte[16];
      Guid myguid = new Guid(bytes);
      Guid myGuid = new Guid("c1170302-8e4e-4aca-bb3b-07f8936a0458");
      return myGuid;
    }

        public TriangleType WhatShapeIsThis(int a, int b, int c)
        {

            TriangleType result =TriangleType.Error;
            int matchingsides = 0;
            // first test that the triangle is valid by passing the following tests
            if ( (a+b) > c)  matchingsides++;
            if ( (a+c) > b)  matchingsides++;
            if ( (c+b) > a)  matchingsides++;
            if (matchingsides < 3)
            {
                return result;
            }//  now test for TriangleType type
            matchingsides = 0;
            if (a == b) matchingsides++;
            if (b == c) matchingsides++;
            if (a == c) matchingsides++;
            if (matchingsides == 0) result = TriangleType.Scalene;
            if (matchingsides == 1) result = TriangleType.Isosceles ;
            if (matchingsides > 1) result = TriangleType.Equilateral;

            return result;
        }
        public string ReverseWords(string str)
        {

            try
            {

                // string str = "I am going to reverse myself.";
                string strrev = "";
                if (str == null)
                    {
                        throw new FaultException<ArgumentNullException>( new ArgumentNullException("str"," String Cannot be Null "), new FaultReason("String cannot be Null"));

                     }   
                foreach (var word in str.Split(' '))
                {
                    string temp = "";
                    foreach (var ch in word.ToCharArray())
                    {
                        temp = ch + temp;
                    }
                    strrev = strrev + temp + " ";
                }

                return (strrev);  //I ma gniog ot esrever .flesym
            }
            catch (ArgumentNullException e)
            {

                ArgumentNullFault fault = new ArgumentNullFault();
                fault.Result = false;
                fault.Message = "The String cannot be Null";
                fault.Description = "The String cannot be Null";
                
                // now throw fault exception to be transmitted to client
               // throw new FaultException<ArgumentOutOfRangeFault>(fault);
                throw new FaultException<ArgumentNullException>(e);
            }
             catch (NullReferenceException e)
            {

                NullReferenceFault fault = new NullReferenceFault();
                fault.Result = false;
                fault.Message = "The String cannot be Null";
                fault.Description = "The String cannot be Null";
                
                // now throw fault exception to be transmitted to client
               // throw new FaultException<ArgumentOutOfRangeFault>(fault);
                throw new FaultException<NullReferenceException>(e);
            }
        }

        
    }
}
