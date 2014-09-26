In order for Chapter 13 RentAWheel code to work, you need to 
perform the following changes to RENTAWHEEL database:
1. Change the type of following columns in table 
Vehicle from Tinyint to Integer:
- Tank
- Available
- Operational
If performing this change through Sql Server Designer 2008, be sure to deactivate "Prevent saving changes that require table re-creation" on Tools -> Options -> Designers -> Table and Database Designers page.