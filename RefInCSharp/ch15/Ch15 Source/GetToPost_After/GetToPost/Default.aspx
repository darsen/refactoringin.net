<%@ Page Language="C#" AutoEventWireup="true" 
CodeBehind="Default.aspx.cs" Inherits="GetToPost._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Order your coffee</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Repeater ID="Repeater1" runat="server" 
        DataSourceID="ObjectDataSource1">
            <ItemTemplate>
                <asp:Label runat="server">Product: 
                <%# Eval("Name") %></asp:Label>
                <asp:Label runat="server">Price: 
                <%# Eval("Price") %></asp:Label>
                <asp:LinkButton runat="server" 
                OnCommand="LinkButton_Command"
                CommandName="Order"                
                CommandArgument='<%# Eval("Id") %>' >
                One Click Order</asp:LinkButton>
                <br />
            </ItemTemplate>
        </asp:Repeater>
    
        <br />
        <br />
        <asp:Label ID="OrderConfirmation" runat="server" 
        Text="None"></asp:Label>
    
    </div>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="ListAllProducts" 
        TypeName="GetToPost._Default"></asp:ObjectDataSource>
    </form>
</body>
</html>
