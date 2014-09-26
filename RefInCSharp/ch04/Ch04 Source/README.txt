Rent-a-Wheels Chapter 4 Installation Instructions

You will need to perform following steps in order to get the Rent-a-wheel application going:
1. Create a database named RENTAWHEELS in your MS SQL Server.
2. Execute RENTAWHEEL.sql script in RENTAWHEELS database created in step 1 in order to create necesarry database object.
3. Optional: Import the data to RENTAWHEELS database from RENTAWHEELS.xls using Data Transformation Services in MS SQL Server (Enable identity insert).
4. Replace Server name in connection string with your server name:
For example:
In FrmFleetView.cs, FrmFleetView_Load event handling routine:
Replace the line:
oCn = New SqlConnection("Data Source=TESLA-DAN;" + _
"Initial Catalog=RENTAWHEELS;User ID=sa")
With 
oCn = New SqlConnection("Data Source=[YOUR_COMPUTER_NAME];" + _
"Initial Catalog=RENTAWHEELS;User ID=sa")
where [YOUR_COMPUTER_NAME] is the name of the server where you have MS SQL Server installed.
5. Replace Server name in connection string with your server name in the rest of the forms.