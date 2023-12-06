using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSLConsole
{
    class VoucherTesting
    {

        //public void voucherTest()
        //{
        //    var returnVal = VoucherService.about();
        //    Console.WriteLine(returnVal);

        //    var pingReturn = VoucherService.ping("SQL",
        //        VoucherService.ctDynamicsSLHeaderValue.siteID,
        //        VoucherService.ctDynamicsSLHeaderValue.siteKey,
        //        VoucherService.ctDynamicsSLHeaderValue.licenseKey,
        //        VoucherService.ctDynamicsSLHeaderValue.licenseName,
        //        VoucherService.ctDynamicsSLHeaderValue.licenseExpiration,
        //        VoucherService.ctDynamicsSLHeaderValue.softwareName);

        //    if (pingReturn.Tables[0].Rows.Count == 0)
        //    {
        //        Console.WriteLine("Error retrieving data");
        //    }
        //    else
        //    {
        //        Console.Write(pingReturn.Tables[0].Columns[0].ColumnName + " = ");
        //        Console.WriteLine(pingReturn.Tables[0].Rows[0][0].ToString());
        //        Console.Write(pingReturn.Tables[0].Columns[1].ColumnName + " = ");
        //        Console.WriteLine(pingReturn.Tables[0].Rows[0][1].ToString());
        //        Console.Write(pingReturn.Tables[0].Columns[2].ColumnName + " = ");
        //        Console.WriteLine(pingReturn.Tables[0].Rows[0][2].ToString());
        //    }

        //    var batches = VoucherService.getBatchesByBatNbr("000118");
        //    if (batches.Length > 0)
        //    {
        //        var returnItem = VoucherService.editBatch("UPDATE", batches[0]);
        //        Console.WriteLine(returnItem.BatNbr);
        //    }
        //}

        //private voucherRef.voucherAndAdjustmentEntry _voucherSvc = null;

        //public voucherRef.voucherAndAdjustmentEntry VoucherService
        //{
        //    get
        //    {
        //        if (_voucherSvc == null)
        //        {
        //            _voucherSvc = new voucherRef.voucherAndAdjustmentEntry
        //            {
        //                Timeout = 300000,
        //                ctDynamicsSLHeaderValue = new voucherRef.ctDynamicsSLHeader
        //                {
        //                    siteID = Properties.Settings.Default.SiteID,
        //                    cpnyID = Properties.Settings.Default.CpnyID,
        //                    licenseKey = Properties.Settings.Default.LicenseKey,
        //                    licenseName = Properties.Settings.Default.LicenseName,
        //                    softwareName = Properties.Settings.Default.SoftwareName,
        //                    siteKey = Properties.Settings.Default.SiteKey,
        //                    licenseExpiration = Properties.Settings.Default.LicenseExpiration
        //                }
        //            };
        //        }
        //        return _voucherSvc;
        //    }

        //}
    }
}
