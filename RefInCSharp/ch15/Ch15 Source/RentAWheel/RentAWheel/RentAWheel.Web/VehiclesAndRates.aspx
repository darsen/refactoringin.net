<%@ Page Language="C#" AutoEventWireup="true" 
CodeBehind="VehiclesAndRates.aspx.cs" 
Inherits="RentAWheel.Web._VehiclesAndRates" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
  <title>Price List of Available Vehicles </title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" 
            Text="Vehicles and Prices:"></asp:Label>        
        <br />
        <br />
            <asp:Repeater ID="Repeater1" runat="server" 
                DataSourceID="ObjectDataSource1">
            <ItemTemplate>
                <asp:Label ID="Label2" runat="server">Model: 
                <%# Eval("Name") %></asp:Label>
                <asp:Label ID="Label3" runat="server">Daily Price: 
                <%# Eval("Category.DailyPrice") %></asp:Label>
                <asp:Label ID="Label4" runat="server">Weekly Price: 
                <%# Eval("Category.WeeklyPrice") %></asp:Label>
                <asp:Label ID="Label5" runat="server">Monthly Price: 
                <%# Eval("Category.MonthlyPrice") %></asp:Label>
                <br />
            </ItemTemplate>
        </asp:Repeater>

    </div>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="GetAllModels" 
        TypeName="RentAWheel.Web._VehiclesAndRates">
    </asp:ObjectDataSource>
    </form>
</body>
</html>
