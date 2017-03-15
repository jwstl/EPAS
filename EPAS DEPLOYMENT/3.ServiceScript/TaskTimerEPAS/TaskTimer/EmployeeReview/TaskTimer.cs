///------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
///   Namespace:      TaskTimer
///   Class:          TaskTimer
///   Description:    Windows Console Application/Task Scheduler
///                   Application to execute stored procedure K2 smartobjects or K2 workflows based on submission entry.
///   Author:         David J. Shilkret                    Date: 12/30/2016
///   Notes:          
///   Revision History:
///   Name:           Date:        Description:          										Notes:
///   version 1.0     12/30/2016    Initial Release     									    Only one datafield or input parameter currently supported. Future state will include "N" datafields or input parameters
///   version 1.1     1/9/2017      Both SMOs and WFs may accept "N" datafields                                           
///------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

using System;
using System.IO; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using SourceCode.Hosting.Client;
using SourceCode.Workflow.Client;
using SourceCode.SmartObjects.Client;


namespace TaskTimer
{
    public class TaskTimer
    {
        Dictionary<string, string> pair = new Dictionary<string, string>();
        public static void Main(string[] args)
        {
            int argsNum = args.Length;
            //string server = "dlx";// args[0];
            //string _smoName = "GetReviewNames";
            
            // The Length property is used to obtain the length of the array. 
            // Notice that Length is a read-only property:
            Console.WriteLine("Number of command line parameters = {0}", args.Length);
            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine("Arg[{0}] = [{1}]", i, args[i]);
            }
            
                //GetTaskSmartobject(server, _smoName);
            
           
                GetTaskSmartobject("dlx", "NextReviewDate");
            

            
           // Console.ReadLine();

        }
        public static String SoConnString()
        {
            // SCConnection string local variables - Smartobjects
            SourceCode.Hosting.Client.BaseAPI.SCConnectionStringBuilder builder = new SourceCode.Hosting.Client.BaseAPI.SCConnectionStringBuilder();
            builder.Authenticate = true;
            builder.Host = "dlx";
            builder.Port = 5555; //use port 5252 for SourceCode.SmartObjects.Client connections
            builder.Integrated = true;
            builder.IsPrimaryLogin = true;
            builder.SecurityLabelName = "K2";

            return builder.ToString();

        }
        public static String WFConnString()
        {
            // SCConnection string local variables - Workflow
            SourceCode.Hosting.Client.BaseAPI.SCConnectionStringBuilder builder = new SourceCode.Hosting.Client.BaseAPI.SCConnectionStringBuilder();
            builder.Authenticate = true;
            builder.Host = "dlx";
            builder.Port = 5252; //use port 5252 for SourceCode.Workflow.Client connections
            builder.Integrated = true;
            builder.IsPrimaryLogin = true;
            builder.SecurityLabelName = "K2";

            return builder.ToString();

        }
        public static void GetTaskSmartobject(string server, string smoName)
        {

            string _smoName = smoName;
            string _server = server;
            

            SourceCode.SmartObjects.Client.SmartObjectClientServer serverName = new SmartObjectClientServer();

            // open a K2 Server connection - sourcecode.SmartObjects.client
            serverName.CreateConnection();
            serverName.Connection.Open(SoConnString());


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

                    string DataFieldName = smo.Properties["AD_Name"].Value;
                    //string DataFieldValue = smo.Properties["DataFieldName"].Value;
                    if ((DataFieldName != null) & (DataFieldName != string.Empty))
                    {
                        CallWorkflow(_server, "Employee Performance\\Employee Performance Appraisal","EmployeeADName",DataFieldName);
                        Console.WriteLine("Call workflow with a single parameter." + DataFieldName);
                    }
                    else
                    {
                        Console.WriteLine("You need to specify either a single datafield (Key, Value pair) or alternatively an xml defined listing of datafields.");
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
        
        public static void CallSmartobject(string smoName, string smoMethodName)
        {
            string _smoName = smoName;
            string _smoMethodName = smoMethodName;

            SourceCode.SmartObjects.Client.SmartObjectClientServer serverName = new SmartObjectClientServer();


            // open a K2 Server connection
            serverName.CreateConnection();
            serverName.Connection.Open(SoConnString());

            try
            {
                // Access the '_smartobject' value in order to get the  smartObject name passed in via parameter.
                SmartObject smartObject = serverName.GetSmartObject(_smoName);

                // specify which method will be called
                smartObject.MethodToExecute = _smoMethodName;

                // call the method
                //SmartObjectList smoList = serverName.ExecuteList(smartObject);
                serverName.ExecuteScalar(smartObject);

            }


            catch (Exception ex)
            {
                // write exceptions to the console
                Console.WriteLine("Error: " + ex.Message);
                //Console.ReadLine();
            }

            finally
            {
                // close the connection. Alternatively wrap in a using statement, which will close the connection automatically.
                serverName.Connection.Close();
            }
        }

        public static void CallSmartobject(string smoName, string smoMethodName, string smoInputParameterName, string smoInputParameterValue)
        {

            string _smoName = smoName;
            string _smoMethodName = smoMethodName;
            _smoMethodName = "Execute";
            string _smoInputParameterName = smoInputParameterName;
            string _smoInputParameterValue = smoInputParameterValue;
            SourceCode.SmartObjects.Client.SmartObjectClientServer serverName = new SmartObjectClientServer();

            // open a K2 Server connection
            serverName.CreateConnection();
            serverName.Connection.Open(SoConnString());

            try
            {
                // Access the '_smartobject' value in order to get the  smartObject name passed in via parameter.
                SmartObject smartObject = serverName.GetSmartObject(_smoName);

                // specify which method will be called
                smartObject.MethodToExecute = _smoMethodName;
                if (smartObject.Properties.Count != 0 || smoInputParameterName != null || smoInputParameterValue != null)
                // specify input paramerters for the method
                {
                    smartObject.Properties[_smoInputParameterName].Value = _smoInputParameterValue;
                    serverName.ExecuteScalar(smartObject);
                }
                else
                {
                    // call the method
                    //SmartObjectList smoList = serverName.ExecuteList(smartObject);
                    serverName.ExecuteScalar(smartObject);
                }
            }


            catch (Exception ex)
            {
                // write exceptions to the console
                Console.WriteLine("Error: " + ex.Message);
                //Console.ReadLine();
            }

            finally
            {
                // close the connection. Alternatively wrap in a using statement, which will close the connection automatically.
                serverName.Connection.Close();
            }
        }
        public static void CallSmartobject(string smoName, string smoMethodName, string _xmlString)
        {

            string xmlString = _xmlString;
            string _smoName = smoName;
            string _smoMethodName = smoMethodName;
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(xmlString); // suppose that myXmlString contains "<Names>...</Names>"

            XmlNodeList xnList = xml.SelectNodes("/datafields/datafield");

            SourceCode.SmartObjects.Client.SmartObjectClientServer serverName = new SmartObjectClientServer();

            // open a K2 Server connection
            serverName.CreateConnection();
            serverName.Connection.Open(SoConnString());

            try
            {
                // Access the '_smartobject' value in order to get the  smartObject name passed in via parameter.
                SmartObject smartObject = serverName.GetSmartObject(_smoName);
                foreach (XmlNode xn in xnList)
                {
                    string name = xn["name"].InnerText;
                    string val = xn["value"].InnerText;
                    Dictionary<string, string> dict = new Dictionary<string, string>();
                    dict.Add(name, val);
                    Console.WriteLine("{0} {1}", name, val);
                    smartObject.Properties[name].Value = val;


                }


                smartObject.MethodToExecute = _smoMethodName;

                serverName.ExecuteScalar(smartObject);

            }
            catch (Exception ex)
            {
                // write exceptions to the console
                Console.WriteLine("Error: " + ex.Message);
                //Console.ReadLine();
            }

            finally
            {
                // close the connection. Alternatively wrap in a using statement, which will close the connection automatically.
                serverName.Connection.Close();
            }

        }
        public static void CallWorkflow(string server, string wfName)
        {
            string _server = server;
            string _wfName = wfName;


            Connection connection = new Connection();
            try
            {
                //open connection to K2 server   sourcecode.Workflow.client
                connection.Open(_server, WFConnString());
                //create process instance  
                ProcessInstance processInstance = connection.CreateProcessInstance(_wfName);

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



        public static void CallWorkflow(string server, string wfName, string dataFieldName, string dataFieldValue)
        {
            string _server = server;
            string _wfName = wfName;
            string _dataFieldName = dataFieldName;
            string _dataFieldValue = dataFieldValue;

            Connection connection = new Connection();
            try
            {
                //open connection to K2 server   sourcecode.Workflow.client
                connection.Open(_server, WFConnString());
                //create process instance  
                ProcessInstance processInstance = connection.CreateProcessInstance(_wfName);
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
        public static void CallWorkflow(string server, string wfName, string _xmlString)
        {
            string _server = server;
            string _wfName = wfName;
            string xmlString = _xmlString;

            XmlDocument xml = new XmlDocument();
            xml.LoadXml(xmlString); // suppose that myXmlString contains "<Names>...</Names>"

            XmlNodeList xnList = xml.SelectNodes("/datafields/datafield");

            Connection connection = new Connection();
            try
            {
                //open connection to K2 server   sourcecode.Workflow.client
                connection.Open(_server, WFConnString());
                //create process instance  
                ProcessInstance processInstance = connection.CreateProcessInstance(_wfName);
                foreach (XmlNode xn in xnList)
                {
                    string name = xn["name"].InnerText;
                    string val = xn["value"].InnerText;
                    Dictionary<string, string> dict = new Dictionary<string, string>();
                    dict.Add(name, val);
                    Console.WriteLine("{0} {1}", name, val);
                    processInstance.DataFields[name].Value = val;

                }

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


    }
}
