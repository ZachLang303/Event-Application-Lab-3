<%@ Page Title="Edit Student - Brian & Zach" Language="C#" MasterPageFile="~/Lab2.Master" AutoEventWireup="true" CodeBehind="EditStudent.aspx.cs" Inherits="Lab3.EditStudent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />

    <%--Student Search Table--%>
    <asp:Table ID="tblStudentSearch" runat="server" Style="width:50%; margin: 0 auto; text-align:left">
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="right" Width="200px">
                <asp:Label ID="lblFirstName" runat="server" Text="Student First Name"></asp:Label>
            </asp:TableCell>
            <asp:TableCell HorizontalAlign="left" Width="200px">
                <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="right">
                <asp:Label ID="lblLastName" runat="server" Text="Student Last Name"></asp:Label>
            </asp:TableCell>
            <asp:TableCell HorizontalAlign ="left">
                <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="2" HorizontalAlign="center">
                <asp:Button ID="btnSearchStudent" runat="server" Text="Search" Font-Size="X-Large" Width="200px" BackColor="#50C89D" BorderColor="#50C89D" CssClass="button" OnClick="btnSearchStudent_Click"/>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <%--Search Results Error Feedback--%>
    <asp:Table ID="tblSearchFeedback" runat="server" Style="width:50%; margin: 0 auto; text-align:left" Visible="false">
        <asp:TableRow>
            <asp:TableCell HorizontalAlign ="center">
                <asp:Label ID="lblSearchFeedback" runat="server" Text="Student is not in the system. Please try again!" ForeColor="Red" Font-Bold="true"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <%--Selected Student Display Table--%>
    <asp:Table ID="tblSelectedStudent" runat="server" Style="width:50%; margin: 0 auto; text-align:left" Visible="false">
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Center">
                <asp:Label ID="lblSelectedStudent" runat="server" Text="" Font-Size="18px" Font-Bold="true"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <br />
    <br />

    <%--Student Edit Table--%>
    <asp:Table ID="tblEditStudent" runat="server" Style="width:50%; margin: 0 auto; text-align:left" Visible="false">

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
            <asp:Label ID="Label1" runat="server" Text="First Name"></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox ID="txtbxFirstName" runat="server"></asp:TextBox>
            <br />
             <asp:RequiredFieldValidator ID="RequiredFieldValidatorFirstName" runat="server" ControlToValidate ="txtbxFirstName" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" Text="This is a required field" ></asp:RequiredFieldValidator>
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
            <asp:Label ID="Label2" runat="server" Text="Last Name"></asp:Label>
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
            <asp:Button ID="btnUpdateStudent" runat="server" Text="Update Student" Font-Size="X-Large" BackColor="#50C89D" BorderColor="#50C89D" CssClass="button" OnClick="btnUpdateStudent_Click"/>
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
            <asp:Button ID="btnChangeStudent" runat="server" Text="Change Student" Font-Size="X-Large" BackColor="#50C89D" BorderColor="#50C89D" CausesValidation="false" CssClass="button" OnClick="btnChangeStudent_Click"/>
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

    <style type="text/css"> 
    .button{
        width:200px;
    }
    .button:hover {
        font-weight:bold;
    }
    </style>
</asp:Content>
