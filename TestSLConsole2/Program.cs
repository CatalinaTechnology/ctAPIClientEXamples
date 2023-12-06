using System;
using System.Collections.Generic;

namespace TestSLConsole
{
    class Program
    {
        public Program()
        {
            // note: Emile has an unsigned SSL cert.  we handle it this way
            // you will need to handle unsigned certs whichever way works best
            HandleCertificate();
        }
        static void Main(string[] args)
        {
            var myObject = new Program();
            myObject.RunVoucherAndAdjustment();
        }

        public void RunIt()
        {
            // Test retrieving an order
            //var orderReturn = OrderService.getOrder("EO0246175");


            // Test placing an order with the bare minimum
            ctDynamicsSL.orders.order oOrder = new ctDynamicsSL.orders.order
            {
                SOTypeID = "SO",        // set your order type (must be a valid soTypeID)
                CustID = "C300",        // which customer are you creating an order for (must be a valid CustID)
                ShipViaID = "BEST",     // how are you shipping it (ust be a valid shipViaID)
                ShiptoID = "DEFAULT",   // Which ShipToID for the customer are you shipping to (must be a valid shipto address for the customer)
                AdminHold = true,       // for kicks, we are going to put it on admin hold
            };

            // create an array of orderItems with the bare minimum (this allows SL to price)
            List<ctDynamicsSL.orders.orderItem> orderItems = new List<ctDynamicsSL.orders.orderItem>();
            orderItems.Add(new ctDynamicsSL.orders.orderItem
            {
                InvtID = "0RCRANK",      // which invtID are you sending this to? (must be a valid InvtID)
                CurySlsPrice = -999876, // -999876 is a secret number that will tell the web services to allow SL to price the item
                CuryCost = -999876,     // if you want to price this yourself, just put in the amount you want to price
                Taxable = 1
            });
            oOrder.orderItems = orderItems.ToArray();

            // lets place the order using placeOrder()
            var placedOrder = OrderService.placeOrder(oOrder);

            // if there is a value in the errorString property of the returned object, then there was an error
            if (placedOrder.errorString.Trim() != "")
            {
                Console.WriteLine("An Error Occurred: " + placedOrder.errorString.Trim());
            }
            else
            {
                Console.WriteLine("Order Created: " + placedOrder.OrdNbr);
            }

        }

        public void RunInvoiceAndMemo()
        {
            var returnScreen = InvoiceAndMemoService.getNewscreen(null);
        }

        public void RunPurchaseOrders()
        {
            var returnScreen = PurchaseOrdersService.editPurchOrd("ADD", new ctDynamicsSL.purchaseOrders.PurchOrd
            {
            });
        }

        public void RunProjectMaintenance()
        {
            var returnVal = ProjectMaintenanceService.getProjectByExactID("CO123000");

            string subAccount = returnVal.gl_subacct;
        }

        public void RunVoucherAndAdjustment()
        {
            // lets get a blank APDoc and have it get defaults
            var apDoc = VoucherAndAdjustmentEntrySvc.getNewAPDoc(null);

            int OpenDoc = apDoc.OpenDoc;

        }

        ctDynamicsSL.voucherAndAdjustmentEntry.voucherAndAdjustmentEntry _voucherAndAdjustmentEntrySvc = null;
        public ctDynamicsSL.voucherAndAdjustmentEntry.voucherAndAdjustmentEntry VoucherAndAdjustmentEntrySvc
        {
            get
            {
                if (_voucherAndAdjustmentEntrySvc == null)
                {
                    _voucherAndAdjustmentEntrySvc = new ctDynamicsSL.voucherAndAdjustmentEntry.voucherAndAdjustmentEntry
                    {
                        Timeout = 300000,

                        // Below is setting the SOAP headers.  This is coming from a config file.  
                        // you would fill this using some type of configuration
                        ctDynamicsSLHeaderValue = new ctDynamicsSL.voucherAndAdjustmentEntry.ctDynamicsSLHeader
                        {
                            siteID = Properties.Settings.Default.SiteID,
                            cpnyID = Properties.Settings.Default.CpnyID,
                            licenseKey = Properties.Settings.Default.LicenseKey,
                            licenseName = Properties.Settings.Default.LicenseName,
                            softwareName = Properties.Settings.Default.SoftwareName,
                            siteKey = Properties.Settings.Default.SiteKey,
                            licenseExpiration = Properties.Settings.Default.LicenseExpiration
                        }
                    };
                }
                return _voucherAndAdjustmentEntrySvc;
            }

        }

        ctDynamicsSL.projectMaintenance.projectMaintenance _projectMaintenanceService = null;
        public ctDynamicsSL.projectMaintenance.projectMaintenance ProjectMaintenanceService
        {
            get
            {
                if (_projectMaintenanceService == null)
                {
                    _projectMaintenanceService = new ctDynamicsSL.projectMaintenance.projectMaintenance
                    {
                        Timeout = 300000,

                        // Below is setting the SOAP headers.  This is coming from a config file.  
                        // you would fill this using some type of configuration
                        ctDynamicsSLHeaderValue = new ctDynamicsSL.projectMaintenance.ctDynamicsSLHeader
                        {
                            siteID = Properties.Settings.Default.SiteID,
                            cpnyID = Properties.Settings.Default.CpnyID,
                            licenseKey = Properties.Settings.Default.LicenseKey,
                            licenseName = Properties.Settings.Default.LicenseName,
                            softwareName = Properties.Settings.Default.SoftwareName,
                            siteKey = Properties.Settings.Default.SiteKey,
                            licenseExpiration = Properties.Settings.Default.LicenseExpiration
                        }
                    };
                }
                return _projectMaintenanceService;
            }

        }




        // Create a reference to my web service for Sales Orders
        ctDynamicsSL.orders.orders _orderService = null;
        public ctDynamicsSL.orders.orders OrderService
        {
            get
            {
                if (_orderService == null)
                {
                    _orderService = new ctDynamicsSL.orders.orders
                    {
                        Timeout = 300000,

                        // Below is setting the SOAP headers.  This is coming from a config file.  
                        // you would fill this using some type of configuration
                        ctDynamicsSLHeaderValue = new ctDynamicsSL.orders.ctDynamicsSLHeader
                        {
                            siteID = Properties.Settings.Default.SiteID,
                            cpnyID = Properties.Settings.Default.CpnyID,
                            licenseKey = Properties.Settings.Default.LicenseKey,
                            licenseName = Properties.Settings.Default.LicenseName,
                            softwareName = Properties.Settings.Default.SoftwareName,
                            siteKey = Properties.Settings.Default.SiteKey,
                            licenseExpiration = Properties.Settings.Default.LicenseExpiration
                        }
                    };
                }
                return _orderService;
            }
            
        }


        ctDynamicsSL.invoiceAndMemo.invoiceAndMemo _invoiceAndMemoService = null;
        public ctDynamicsSL.invoiceAndMemo.invoiceAndMemo InvoiceAndMemoService
        {
            get
            {
                if (_invoiceAndMemoService == null)
                {
                    _invoiceAndMemoService = new ctDynamicsSL.invoiceAndMemo.invoiceAndMemo
                    {
                        Timeout = 300000,

                        // Below is setting the SOAP headers.  This is coming from a config file.  
                        // you would fill this using some type of configuration
                        ctDynamicsSLHeaderValue = new ctDynamicsSL.invoiceAndMemo.ctDynamicsSLHeader
                        {
                            siteID = Properties.Settings.Default.SiteID,
                            cpnyID = Properties.Settings.Default.CpnyID,
                            licenseKey = Properties.Settings.Default.LicenseKey,
                            licenseName = Properties.Settings.Default.LicenseName,
                            softwareName = Properties.Settings.Default.SoftwareName,
                            siteKey = Properties.Settings.Default.SiteKey,
                            licenseExpiration = Properties.Settings.Default.LicenseExpiration
                        }
                    };
                }
                return _invoiceAndMemoService;
            }

        }



        ctDynamicsSL.purchaseOrders.purchaseOrders _purchaseOrdersService = null;
        public ctDynamicsSL.purchaseOrders.purchaseOrders PurchaseOrdersService
        {
            get
            {
                if (_purchaseOrdersService == null)
                {
                    _purchaseOrdersService = new ctDynamicsSL.purchaseOrders.purchaseOrders
                    {
                        Timeout = 300000,

                        // Below is setting the SOAP headers.  This is coming from a config file.  
                        // you would fill this using some type of configuration
                        ctDynamicsSLHeaderValue = new ctDynamicsSL.purchaseOrders.ctDynamicsSLHeader
                        {
                            siteID = Properties.Settings.Default.SiteID,
                            cpnyID = Properties.Settings.Default.CpnyID,
                            licenseKey = Properties.Settings.Default.LicenseKey,
                            licenseName = Properties.Settings.Default.LicenseName,
                            softwareName = Properties.Settings.Default.SoftwareName,
                            siteKey = Properties.Settings.Default.SiteKey,
                            licenseExpiration = Properties.Settings.Default.LicenseExpiration
                        }
                    };
                }
                return _purchaseOrdersService;
            }

        }


        public void HandleCertificate()
        {
            try
            {
                if (Properties.Settings.Default.AllowSelfSignedServiceCalls)
                {
                    System.Net.ServicePointManager.ServerCertificateValidationCallback = 
                        new System.Net.Security.RemoteCertificateValidationCallback(doApproveCertificate);
                }
            }
            catch { }
        }

        public bool doApproveCertificate(object sender, 
            System.Security.Cryptography.X509Certificates.X509Certificate c, 
            System.Security.Cryptography.X509Certificates.X509Chain chain, 
            System.Net.Security.SslPolicyErrors sllPolicyErrors)
        {
            return true;
        }

    }
}
