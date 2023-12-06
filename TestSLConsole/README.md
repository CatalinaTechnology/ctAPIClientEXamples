You will need several things from your adminstrator to be able to make calls to the Catalina API
- license key (license key that was given to you by Catalina Technology)
- Site Key (also known as the encryption key)
- license expiration date (if there is one.  leave blank if it is a non-expiring license)
- license name (this is the name of your company as it was encrypted against the license key)
- Site ID (this points to a site configuration)
- CpnyID (company ID in Dynamics SL)

## app.config or web.config
We often store settings like license information in the app.config or web.config.  In all of these examples, you will see this in the app.config.  This allows you to update the app.config in the example and replace that information with your own.

  
  
    <add key="SITEID" value="Your SiteID"/>
    
    <add key="CPNYID" value="Your Company ID"/>
    
    <add key="LICENSEKEY" value="Your License Key"/>
    
    <add key="LICENSENAME" value="Your License Name" />
    
    <add key="LICENSEEXPIRATION" value="Your license expiration date -- leave blank if non-expiring" />
    
    <add key="SITEKEY" value="Encryption site key"/>
