using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.ctQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            client.ctQueue.Program myProgram = new client.ctQueue.Program();
            myProgram.RunIt();
        }
        
        public void RunIt()
        {
            GetCustomers();
            GetAddresses();
        }
        public void GetCustomers()
        {
            // set up the parms
            List<ctDynamicsSL.queue.nameValuePairs> customerParms = new List<ctDynamicsSL.queue.nameValuePairs>();

            // we are going to be retrieving CUSTOMER records
            customerParms.Add(new ctDynamicsSL.queue.nameValuePairs
            {
                name = "ITEMTYPE",
                value = "CUSTOMER"
            });

            // we are going to be retrieving status of UPDATE.  We coould also be dealing with DELETE, ADD, etc.
            customerParms.Add(new ctDynamicsSL.queue.nameValuePairs
            {
                name = "STATUS",
                value = "UPDATE"
            });

            // all queue item records will be set to RETRIEVED so that they wont be returned again (until the source record is updated again)
            customerParms.Add(new ctDynamicsSL.queue.nameValuePairs
            {
                name = "CHANGESTATUS",
                value = "RETRIEVED"
            });

            try
            {
                // retrieve all the queue records for the parameters
                var customerQueueItems = QueueSvc.getDSLXMLs(0, 0, customerParms.ToArray());
                
                // parse through each record returned
                foreach (var queueItem in customerQueueItems)
                {
                    try
                    {
                        // retrieve the customer in the queue
                        var customer = CustomerSvc.getCustomerByExactID(queueItem.itemID);
                    }
                    catch (Exception ex)
                    {
                        // handle record exceptions
                    }
                }
            }
            catch(Exception ex)
            {
                // handle overall processing exceptions
            }
        }

        public void GetAddresses()
        {
            // set up the parms
            List<ctDynamicsSL.queue.nameValuePairs> addressParms = new List<ctDynamicsSL.queue.nameValuePairs>();

            // we are going to be retrieving SOADDRESS (Customer Shipto Address) records
            addressParms.Add(new ctDynamicsSL.queue.nameValuePairs
            {
                name = "ITEMTYPE",
                value = "SOADDRESS"
            });
            // we are going to be retrieving status of UPDATE.  We coould also be dealing with DELETE, ADD, etc.
            addressParms.Add(new ctDynamicsSL.queue.nameValuePairs
            {
                name = "STATUS",
                value = "UPDATE"
            });
            // all queue item records will be set to RETRIEVED so that they wont be returned again (until the source record is updated again)
            addressParms.Add(new ctDynamicsSL.queue.nameValuePairs
            {
                name = "CHANGESTATUS",
                value = "RETRIEVED"
            });

            try
            {
                // retrieve all the queue records for the parameters
                var addressQueueItems = QueueSvc.getDSLXMLs(0, 0, addressParms.ToArray());

                // parse through each record returned
                foreach (var queueItem in addressQueueItems)
                {
                    try
                    {
                        // in this case, there are 2 fields for the key: CustID + AddressID (pipe | delimited)
                        var addrKeyArray = queueItem.itemID.Split('|');

                        // if there arent 2 fields in the itemID, then something is wrong and throw an exception
                        if (addrKeyArray.Length != 2)
                        {
                            throw new Exception("Error, not a valid key for address (" + queueItem.itemID + ")");
                        }

                        // retrieve the address by the keys stored in the queueItem.itemID
                        var address = CustomerSvc.getSOAddressByExactID(addrKeyArray[0], addrKeyArray[1]);

                        // NOTE:  before you do anything with your address (say saving it to another system) it is a good idea to make sure it
                        // exists in that other system.  so, it is always a good idea to retrieve the customer from SL first before acting
                        // on the address.
                    }
                    catch (Exception ex)
                    {
                        // handle record exception
                    }
                }
            }
            catch (Exception ex)
            {
                // handle overall processing exceptions
            }
        }

        private ctDynamicsSL.queue.queue _queueSvc = null;

        public ctDynamicsSL.queue.queue QueueSvc
        {
            get
            {
                if(_queueSvc == null)
                {
                    _queueSvc = new ctDynamicsSL.queue.queue
                    {
                        ctDynamicsSLHeaderValue = new ctDynamicsSL.queue.ctDynamicsSLHeader
                        {
                            licenseExpiration = Properties.Settings.Default.licenseExpiration,
                            licenseKey = Properties.Settings.Default.licenseKey,
                            licenseName = Properties.Settings.Default.licenseName,
                            siteKey = Properties.Settings.Default.siteKey,
                            siteID = Properties.Settings.Default.siteID,
                            cpnyID = Properties.Settings.Default.cpnyID,
                            softwareName = "CTAPI",
                },
                    };
                }
                return _queueSvc;
            }
        }


        private ctDynamicsSL.customerMaintenance.customerMaintenance _customerSvc = null;

        public ctDynamicsSL.customerMaintenance.customerMaintenance CustomerSvc
        {
            get
            {
                if (_customerSvc == null)
                {
                    _customerSvc = new ctDynamicsSL.customerMaintenance.customerMaintenance
                    {
                        ctDynamicsSLHeaderValue = new ctDynamicsSL.customerMaintenance.ctDynamicsSLHeader
                        {
                            licenseExpiration = Properties.Settings.Default.licenseExpiration,
                            licenseKey = Properties.Settings.Default.licenseKey,
                            licenseName = Properties.Settings.Default.licenseName,
                            siteKey = Properties.Settings.Default.siteKey,
                            siteID = Properties.Settings.Default.siteID,
                            cpnyID = Properties.Settings.Default.cpnyID,
                            softwareName = "CTAPI",
                        },
                    };
                }
                return _customerSvc;
            }
        }

    }
}
