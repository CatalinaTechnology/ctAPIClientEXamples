#The Queue API requires triggers on tables to "feed" it
In order for an object/table in SQL Server to become available by the Queue API calls, a trigger needs to be added to the table in question.  We have several examples of these triggers here: [https://github.com/CatalinaTechnology/ctAPIClientExamples/tree/master/client.ctQueue/QueueTriggers](https://github.com/CatalinaTechnology/ctAPIClientExamples/tree/master/client.ctQueue/QueueTriggers "Queue Trigger Examples")

What these triggers do is save a record in our Queue Table based on what type of transaction occurred on the table (Create, Update, Delete).

##The Sample Triggers
The sample triggers allow the following actions to be tracked against the Customer table and the SOAddress Table

|Object    |ItemType    | Status | Notes
|--------- |----------- |------- | --------------------------------------------------------
|Customer  |CUSTOMER    | ADD    | Creates a record if a new customer is added
|Customer  |CUSTOMER    | UPDATE | Creates a new record if an existing customer is updated
|Customer  |CUSTOMER    | DELETE | Creates a new record if a customer is deleted
|SOAddress |SOADDRESS   | ADD    | Creates a record if a new Customer Ship Address is added
|SOAddress |SOADDRESS   | UPDATE | Creates a record if a new Customer Ship Address is updated
|SOAddress |SOADDRESS   | DELETE | Creates a record if a new Customer Ship Address is deleted


##Example:
If you want to pull all new customers that have been added to the system since last time you called the queue, you would do the below.  Note, that I put the ITEMTYPE = CUSTOMER and the STATUS = ADD to accommodate.

```csharp
	// set up the parms
	List<ctDynamicsSL.queue.nameValuePairs> customerParms = new List<ctDynamicsSL.queue.nameValuePairs>();
	
	// we are going to be retrieving CUSTOMER records
	customerParms.Add(new ctDynamicsSL.queue.nameValuePairs
	{
	name = "ITEMTYPE",
	value = "CUSTOMER"
	});
	
	// we are going to be retrieving status of UPDATE. We coould also be dealing with DELETE, ADD, etc.
	customerParms.Add(new ctDynamicsSL.queue.nameValuePairs
	{
	name = "STATUS",
	value = "ADD"
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
```
