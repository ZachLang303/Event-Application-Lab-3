<%@ Page Title="New Teacher - Brian & Zach" Language="C#" MasterPageFile="~/Lab2.Master" AutoEventWireup="true" CodeBehind="NewTeacher.aspx.cs" Inherits="Event_Application_Lab_2.NewTeacher" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <br />
    <br />
    <br />

    <asp:Table runat="server" Style="width:50%; margin: 0 auto; text-align:left">

    <%-- Row 1 --%>
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" Font-Underline="True" ColumnSpan="2"> 
            <asp:Label ID="lblPersonalInfo" runat="server" Text="Personal Information" Font-Size="X-Large" Font-Bold="true"></asp:Label>
        </asp:TableCell>
        <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" Font-Underline="true" ColumnSpan="2">
            <asp:Label ID="lblTshirtInfo" runat="server" Text="T-Shirt Information" Font-Size="X-Large" Font-Bold="true"></asp:Label>
        </asp:TableCell>
    </asp:TableRow>

    <%-- Row 2 --%>
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="center">
            <asp:Label ID="lblFirstName" runat="server" Text="First Name"></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox ID="txtbxFirstName" runat="server"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorFirstName" runat="server" ControlToValidate ="txtbxFirstName" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" Text="This is a required field"></asp:RequiredFieldValidator>
        </asp:TableCell>
        <asp:TableCell HorizontalAlign="center" >
            <asp:Label ID="lblShirtSize" runat="server" Text="T-Shirt Size"></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:DropDownList ID="listShirtSize" runat="server">
                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                <asp:ListItem Value="Small" Text="Small"></asp:ListItem>
                <asp:ListItem Value="Medium" Text="Medium"></asp:ListItem>
                <asp:ListItem Value="Large" Text="Large"></asp:ListItem>
                <asp:ListItem Value="X-Large" Text="X-Large"></asp:ListItem>
                <asp:ListItem Value="XX-Large" Text="XX-Large"></asp:ListItem>
            </asp:DropDownList>
        </asp:TableCell>
    </asp:TableRow>

    <%-- Row 3 --%>
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="center">
            <asp:Label ID="lblLastName" runat="server" Text="Last Name"></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox ID="txtbxLastName" runat="server"></asp:TextBox>   
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorLastName" runat="server" ControlToValidate ="txtbxLastName" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" Text="This is a required field" ></asp:RequiredFieldValidator>                        
        </asp:TableCell>
        <asp:TableCell HorizontalAlign="center" >
            <asp:Label ID="lblShirtColor" runat="server" Text="Shirt Color"></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:DropDownList ID="listShirtColor" runat="server">
                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                <asp:ListItem Value="Green" Text="Green"></asp:ListItem>
                <asp:ListItem Value="Yellow" Text="Yellow"></asp:ListItem>
                <asp:ListItem Value="Blue" Text="Blue"></asp:ListItem>
                <asp:ListItem Value="Black" Text="Black"></asp:ListItem>
            </asp:DropDownList>
        </asp:TableCell>
    </asp:TableRow>

    <%-- Row 4 --%>
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="center">
            <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox ID="txtbxEmail" runat="server"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server" ControlToValidate ="txtbxEmail" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" Text="This is a required field" ></asp:RequiredFieldValidator>
         
        </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
        <asp:TableCell HorizontalAlign="center">
            <asp:Label ID="lblgradetaught" runat="server" Text="Grade Taught"></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox ID="txtbxgradetaught" runat="server"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate ="txtbxEmail" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" Text="This is a required field" ></asp:RequiredFieldValidator>
         
        </asp:TableCell>
        <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
            <asp:Button ID="btnEnter" runat="server" OnClick="btnEnter_Click" Text="Enter" Font-Size="X-Large" BackColor="#50C89D" BorderColor="#50C89D" CssClass="button"/>
        </asp:TableCell>
            
    </asp:TableRow>

    <%-- Row 5 --%>
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="center">
            <asp:Label ID="lblLunchTicket" runat="server" Text="Lunch Ticket?"></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:CheckBox ID="chbxLunchTicket" runat="server" />
        </asp:TableCell>
        <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
            <asp:Button ID="btnClearInfo" runat="server" OnClick="btnClearInfo_Click" Text="Clear Info" Font-Size="X-Large" BackColor="#50C89D" BorderColor="#50C89D" CausesValidation="false" CssClass="button"/>
        </asp:TableCell>
    </asp:TableRow>

  

    <%-- Row 7 --%>
    <asp:TableRow>
        <asp:TableCell></asp:TableCell>
    </asp:TableRow>
    
    <asp:TableRow>
        <asp:TableCell Rowspan="2" HorizontalAlign="center">
            <asp:Label ID="lblSelectSchool" runat="server" Text="Select School"></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:DropDownList ID="ddlSchoolList" runat="server" DataSourceID="datasrcSchoolList" DataTextField="Name" DataValueField="SchoolID"></asp:DropDownList>
            <asp:SqlDataSource 
                runat="server" 
                ID="datasrcSchoolList" 
                ConnectionString="<%$ ConnectionStrings:Lab3 %>"
                SelectCommand = "Select SchoolID, Name from School order by SchoolID" />
        </asp:TableCell>
        <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
            <asp:Button ID="btnPopulateFields" runat="server" OnClick="btnPopulateFields_Click" Text="Populate Fields" Font-Size="X-Large" BackColor="#50C89D" BorderColor="#50C89D" CausesValidation="false" CssClass="button"/>
        </asp:TableCell>
    </asp:TableRow>
    </asp:Table>

    <br />
    <br />

       <%-- Login Information Table --%>
    <asp:Table ID="tblLogin" runat="server" Style="width:350px; margin: 0 auto; text-align:left">
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" Font-Underline="True" ColumnSpan="2"> 
            <asp:Label ID="lblLoginInfo" runat="server" Text="Login Information" Font-Size="X-Large" Font-Bold="true"></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Center" Width="150px">
            <asp:Label ID="lblNewUsername" runat="server" Text=" New Username"></asp:Label>
        </asp:TableCell>
        <asp:TableCell HorizontalAlign="left" Width="200px">
            <asp:TextBox ID="txtNewUsername" runat="server" Width="175px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvNewUserName" runat="server" ControlToValidate ="txtNewPassword" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" Text="This is a required field" ></asp:RequiredFieldValidator>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Center" Width="150px">
            <asp:Label ID="lblNewPassword" runat="server" Text="New Password"></asp:Label>
        </asp:TableCell>
        <asp:TableCell HorizontalAlign="left" Width="200px">
            <asp:TextBox ID="txtNewPassword" runat="server" Width="175px" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvNewPassword" runat="server" ControlToValidate ="txtNewPassword" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" Text="This is a required field" ></asp:RequiredFieldValidator>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Center" Width="150px">
            <asp:Label ID="lblReenterPassword" runat="server" Text="Re-Enter Password"></asp:Label>
        </asp:TableCell>
        <asp:TableCell HorizontalAlign="left" Width="200px">
            <asp:TextBox ID="txtReenterPassword" runat="server" Width="175px" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvReenterPassword" runat="server" ControlToValidate ="txtReenterPassword" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" Text="This is a required field" ></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="cdReenterPassword" runat="server" ControlToValidate="txtReenterPassword" ControlToCompare="txtNewPassword" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" Text="Passwords must match!" ></asp:CompareValidator>
        </asp:TableCell>
    </asp:TableRow>
    </asp:Table>    
    <br />
    <br />
    <%-- Confirmation Table --%> 
    <asp:Table runat="server" HorizontalAlign="Center">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblConfirmation" runat="server" Text="User Created!" ForeColor="#13B100" Font-Bold="true" Font-Size="Large" Visible="false"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <style type="text/css"> 
    .button{
        width:200px;
    }
    .button:hover {
        font-weight:bold;
    }
    </style>
</asp:Content>
