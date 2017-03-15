

///-----------------------------------------------------------------
///   Namespace:      CheckReview
///   Class:          CheckReviewClass
///   Description:    Windows Console Application/Task Scheduler Executed. Application will check for Employee Review Date and determines whether it is within "n" days and kicks off 
///                                                                        a K2 Process accordingly. It will create a flag "Active = yes" for future checks. When each process is started the application will
///                                                                        pass the "ID" (record id) for the employee. 
///   Author:         David J. Shilkret                    Date: 11/6/2016
///   Notes:          
///   Revision History:
///   Name:           Date:        Description:
///   version 1.0     11/6/2016    Initial Release
///-----------------------------------------------------------------

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SourceCode.Hosting.Client;
using SourceCode.Workflow.Client;
using SourceCode.SmartObjects.Client;


namespace CheckReview
{
    public class CheckReviewClass
    {
        public static void Main(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
          {
              System.Console.WriteLine("Arg[{0}] = [{1}]", i, args[i]);
            }
            Console.ReadLine();
            if (args == null)
            {
                Console.WriteLine("You need to pass in parameters."); // Check for null array
            }
            else if (args.Length != 5)
            {
                Console.WriteLine("You need to pass in 5 parameters.");
              
            }
            else
            {

                string _serverName = args[0];
                string _domain = args[1];
                string _smartobject = args[2];
                string _smoListMethod = args[3];
                Console.Write("args length is ");
                Console.WriteLine(args.Length); // Write array length
                ExecuteSmartobject(_serverName, _domain, _smartobject, _smoListMethod);
                
            }
            Console.ReadLine();
        
        }

        public static void CallSmartobject(string domain, string server, string smoName)
        {
            //smoListMethod = "GetListItem";
            //smoUpdateMethod = "UpdateListItem";
            string _domain = domain;
            string _serverName = server;
            string _user = "K2Service";
            string _password = "K2pass!";
            string _smoName = smoName;
            string _smoMethodName = smoMethodName;
            //string _smoUpdateMethod = smoUpdateMethod;
            
            

            SourceCode.SmartObjects.Client.SmartObjectClientServer serverName = new SmartObjectClientServer();

            SourceCode.Hosting.Client.BaseAPI.SCConnectionStringBuilder connectionString = new SourceCode.Hosting.Client.BaseAPI.SCConnectionStringBuilder();


            // build up a connection string
            connectionString.Authenticate = true;
            connectionString.Host = _serverName;
            connectionString.Integrated = true;
            connectionString.IsPrimaryLogin = true;
            connectionString.Port = 5555;
            connectionString.UserID = _user;
            connectionString.WindowsDomain = _domain;
            connectionString.Password = _password;
            connectionString.SecurityLabelName = "K2"; //the default label
            

            // open a K2 Server connection
            serverName.CreateConnection();
            serverName.Connection.Open(connectionString.ToString());

            try
            {
                // Access the '_smartobject' value in order to get the  smartObject name passed in via parameter.
                SmartObject smartObject = serverName.GetSmartObject(_smoName);

                // specify which method will be called
                smartObject.MethodToExecute = _smoMethodName;

                // call the method
                 SmartObjectList smoList = serverName.ExecuteList(smartObject);
                 SmartObject smoScaler = serverName.ExecuteScalar(smartObject);
               }

         
           catch (Exception ex)
            {
                // write exceptions to the console
                Console.WriteLine("Error: " + ex.Message);
                Console.ReadLine();
            }

            finally
          {
                // close the connection. Alternatively wrap in a using statement, which will close the connection automatically.
               serverName.Connection.Close();
           }
        }
        public static void CallWorkflow(string domain, string server, string wfName, string dataFieldName, string dataFieldValue)
        {
            // SCConnection string local variables

            string _domain = domain;
            string _serverName = server;
            string _user = "K2Service";
            string _password = "K2pass!";
            //string _smartobject = smartobject;
            //string _smoListMethod = smoListMethod;
            //string _smoUpdateMethod = smoUpdateMethod;
            string _wfName = wfName;
            string _dataFieldName = dataFieldName;
            string _dataFieldValue = dataFieldValue;

            SourceCode.Hosting.Client.BaseAPI.SCConnectionStringBuilder connectionString = new SourceCode.Hosting.Client.BaseAPI.SCConnectionStringBuilder();
            connectionString.Authenticate = true;
            connectionString.Host = "l";
            connectionString.Integrated = true;
            connectionString.IsPrimaryLogin = true;
            connectionString.Port = 5252;
            connectionString.UserID = _user;
            connectionString.WindowsDomain = _domain;
            connectionString.Password = _password;
            connectionString.SecurityLabelName = "K2"; 
            Connection connection = new Connection();
            try
            {
                //open connection to K2 server   
                connection.Open(_serverName, connectionString.ToString());
                //create process instance  
                ProcessInstance processInstance = connection.CreateProcessInstance(_wfName);
                //populate data fields  
                //int id = Convert.ToInt32(_employeeID);
                processInstance.DataFields[_dataFieldName].Value = _dataFieldValue;
                //set the folio  
                processInstance.Folio = DateTime.Now.ToString();
                //start the process  
                connection.StartProcessInstance(processInstance, false);
                Console.WriteLine("Folio:" + processInstance.Folio.ToString());
                Console.WriteLine("ID: " + processInstance.ID.ToString());
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); 
                Console.ReadLine();
            }
            finally
            {
                // close the connection  
                connection.Close();
            }
        }

        public static void GetTaskSmartobject(string domain, string server, string smoName)
        {
          
            string _domain = domain;
            string _serverName = server;
            string _user = "K2Service";
            string _password = "K2pass!";
            string _smoName = smoName;
            
            
            
            

            SourceCode.SmartObjects.Client.SmartObjectClientServer serverName = new SmartObjectClientServer();

            SourceCode.Hosting.Client.BaseAPI.SCConnectionStringBuilder connectionString = new SourceCode.Hosting.Client.BaseAPI.SCConnectionStringBuilder();


            // build up a connection string
            connectionString.Authenticate = true;
            connectionString.Host = _serverName;
            connectionString.Integrated = true;
            connectionString.IsPrimaryLogin = true;
            connectionString.Port = 5555;
            connectionString.UserID = _user;
            connectionString.WindowsDomain = _domain;
            connectionString.Password = _password;
            connectionString.SecurityLabelName = "K2"; //the default label
            

            // open a K2 Server connection
            serverName.CreateConnection();
            serverName.Connection.Open(connectionString.ToString());

            try
            {
                // Access the '_smartobject' value in order to get the  smartObject name passed in via parameter.
                SmartObject smartObject = serverName.GetSmartObject(_smoName);

                // specify which method will be called
                smartObject.MethodToExecute = "List";

                // call the method
                 SmartObjectList smoList = serverName.ExecuteList(smartObject);
                

                // read the return properties of the SmartObject
                
                foreach (SmartObject smo in smoList.SmartObjectsList)
                {
                   
                    string DataFieldName = smo.Properties["DataFieldName"].Value;
                    string DataFieldValue = smo.Properties["DataFieldValue"].Value;
                    string ArtifactType = smo.Properties["ArtifactType"].Value;
                    string ArtifactName = smo.Properties["ArtifactName"].Value;
                   
                    
                    
                   
                         if (ArtifactType == "smartObject" ){
                                    CheckReviewClass crc = new CheckReviewClass();
                                    //crc.UpdateReviewDateFlag(id,_serverName,_domain, _smartobject,_smoListMethod,_smoUpdateMethod);
                                    //crc.up
                                    StartEmployeeReview(id, _serverName, _domain, _smartobject, _smoMethodName);
                                    Console.WriteLine("Name: " + en);
                                    Console.WriteLine("Last Review Date: " + LastReviewDate);
                                    Console.WriteLine(DaysUntiLastReviewDateeview);
                                    Console.WriteLine(en + ":" + " Start Review");
                              
                          }
                         else if(active == "yes")
                         {
                             Console.WriteLine("Name: " + smo.Properties["AD_Name"].Value + ":" + " Employee Review aLastReviewDateeady started");
                             Console.WriteLine("Last Review Date: " + smo.Properties["LastReviewDate"].Value);
                             Console.WriteLine(DaysUntiLastReviewDateeview);
                         }
                         else
                         {

                                     Console.WriteLine("Name: " + smo.Properties["AD_Name"].Value  + " Not time for review yet");
                                     Console.WriteLine("Last Review Date: " + smo.Properties["LastReviewDate"].Value);
                                     Console.WriteLine(DaysUntiLastReviewDateeview);
                                     
                                     
                             
                         }
                
                    
                }

                Console.ReadLine();
           }

           catch (Exception ex)
            {
                // write exceptions to the console
                Console.WriteLine("Error: " + ex.Message);
                Console.ReadLine();
            }

            finally
          {
                // close the connection. Alternatively wrap in a using statement, which will close the connection automatically.
               serverName.Connection.Close();
           }
       }
        public void UpdateReviewDateFlag(string id, string server, string domain, string smartobject, string smoListMethod, string smoUpdateMethod)
        {

            smoListMethod = "GetListItem";
            smoUpdateMethod = "UpdateListItem";
            string _serverName = server;
            string _user = "K2Service";
            string _password = "K2pass!";
            string _domain = domain;
            string _smartobject = smartobject;
            string _smoListMethod = smoListMethod;
            string _smoUpdateMethod = smoUpdateMethod;


            SourceCode.SmartObjects.Client.SmartObjectClientServer serverName = new SmartObjectClientServer();

            SourceCode.Hosting.Client.BaseAPI.SCConnectionStringBuilder connectionString = new SourceCode.Hosting.Client.BaseAPI.SCConnectionStringBuilder();


            // build up a connection string
            connectionString.Authenticate = true;
            connectionString.Host = _serverName;
            connectionString.Integrated = true;
            connectionString.IsPrimaryLogin = true;
            connectionString.Port = 5555;
            connectionString.UserID = _user;
            connectionString.WindowsDomain = _domain;
            connectionString.Password = _password;
            connectionString.SecurityLabelName = "K2"; //the default label

            // open a K2 Server connection
            serverName.CreateConnection();
            serverName.Connection.Open(connectionString.ToString());

            try
            {
                // Access the '_smartobject' value in order to get the  smartObject name passed in via parameter.
                SmartObject smartObject = serverName.GetSmartObject(_smartobject);

                // specify which method will be called
                smartObject.MethodToExecute = "Update";

                // specify input parameters for the method
                smartObject.Properties["ID"].Value = id;
                smartObject.Properties["Active"].Value = "yes";
                
                
                
             
                // call the method
                serverName.ExecuteScalar(smartObject);
                // update
                string link = smartObject.Properties["LinkToItem"].Value;
                Console.WriteLine("Name: " + smartObject.Properties["Employee_Name"].Value);
                Console.WriteLine("Link to Item: " + link);
                Console.WriteLine("Active: " + smartObject.Properties["Active"].Value);
                Console.WriteLine("ID: " + smartObject.Properties["ID"].Value);
               
               
                
            }
                
            catch (Exception ex)
            {
                // write exceptions to the console
                Console.WriteLine("Error: " + ex.Message);
                Console.ReadLine();
               
            }

            finally
            {
                // close the connection. Alternatively wrap in a using statement, which will close the connection automatically.
                serverName.Connection.Close();
            }
        }
       
        public static int DaysBetween(DateTime d1, DateTime d2)
        {
            TimeSpan span = d2.Subtract(d1);
            return (int)span.TotalDays;
        }
        
    }
}
