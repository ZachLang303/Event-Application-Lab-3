<%@ Page Title="New Student - Brian & Zach" Language="C#" MasterPageFile="~/Lab2.Master" AutoEventWireup="true" CodeBehind="NewStudent.aspx.cs" Inherits="Lab3.NewStudent" %>
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
            <asp:Label ID="lblAge" runat="server" Text="Age"></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox ID="txtbxAge" runat="server"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorAge" runat="server" ControlToValidate ="txtbxAge" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" Text="This is a required field" ></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="RequiredNumberValidatorAge" runat="server" ControlToValidate ="txtbxAge" Display ="Dynamic" ForeColor="Red" Operator="DataTypeCheck" Type="Integer" SetFocusOnError="true" Text="Field must be a number"></asp:CompareValidator>
        </asp:TableCell>
        <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
            <asp:Button ID="btnEnter" runat="server" Text="Enter" Font-Size="X-Large" BackColor="#50C89D" BorderColor="#50C89D" CssClass="button" OnClick="btnEnter_Click"/>
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
            <asp:Button ID="btnClearInfo" runat="server" Text="Clear Info" Font-Size="X-Large" BackColor="#50C89D" BorderColor="#50C89D" CausesValidation="false" CssClass="button" OnClick="btnClearInfo_Click"/>
        </asp:TableCell>
    </asp:TableRow>

    <%-- Row 6 --%>
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="center">
            <asp:Label ID="lblNotes" runat="server" Text="Notes"></asp:Label>
        </asp:TableCell>
        <asp:TableCell RowSpan="2">
            <asp:TextBox ID="txtbxNotes" runat="server" Height="50px" Textmode="MultiLine" Row="3" Wrap="true"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldNotes" runat="server" ControlToValidate ="txtbxNotes" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" Text="This is a required field" ></asp:RequiredFieldValidator>
        </asp:TableCell>
        <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
            <asp:Button ID="btnPopulateFields" runat="server" Text="Populate Fields" Font-Size="X-Large" BackColor="#50C89D" BorderColor="#50C89D" CausesValidation="false" CssClass="button" OnClick="btnPopulateFields_Click"/>
        </asp:TableCell>
    </asp:TableRow>

    <%-- Row 7 --%>
    <asp:TableRow>
        <asp:TableCell></asp:TableCell>
    </asp:TableRow>

    <%-- Row 8 --%>
    <asp:TableRow>
        <asp:TableCell Rowspan="2" HorizontalAlign="center">
            <asp:Label ID="lblSelectTeacher" runat="server" Text="Select Teacher"></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:DropDownList ID="ddlTeacherList" runat="server" DataSourceID="datasrcTeacherList" DataTextField="TeacherList"></asp:DropDownList>
            <asp:SqlDataSource 
                runat="server" 
                ID="datasrcTeacherList" 
                ConnectionString="<%$ ConnectionStrings:Lab3 %>"
                SelectCommand = "Select TeacherId, FirstName + ' ' + LastName as TeacherList from Teacher order by TeacherID ASC" />
        </asp:TableCell>
    </asp:TableRow>
    </asp:Table>

    <br />
    <br />
    <%-- Confirmation Table --%> 
    <asp:Table runat="server" HorizontalAlign="Center">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblConfirmation" runat="server" Text="Student Successfully Created!" ForeColor="#13B100" Font-Bold="true" Font-Size="Large" Visible="false"></asp:Label>
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
