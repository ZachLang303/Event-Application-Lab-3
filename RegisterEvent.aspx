<%@ Page Title="Register Event - Brian & Zach" Language="C#" MasterPageFile="~/Lab2.Master" AutoEventWireup="true" CodeBehind="RegisterEvent.aspx.cs" Inherits="Lab3.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />

    <asp:Table runat = "server" Style="width:50%; margin: 0 auto; text-align:left">

        <%-- Row 1 --%>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="center">
                <asp:Label ID="lblSelectEvent" runat="server" Text="Select Event" Font-Bold ="true" Font-Size ="X-Large" Width="150px" ></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList ID="ddrEvent" runat="server" DataSourceID="datasrcEventList" DataTextField="EventList" Width="225px"></asp:DropDownList>
                <asp:SqlDataSource 
                    runat="server" 
                    ID="datasrcEventList" 
                    ConnectionString= "<%$ ConnectionStrings:Lab3 %>"
                    SelectCommand = "Select EventID, EventName as EventList from Event Order by EventID ASC"/>
            </asp:TableCell>
        </asp:TableRow>

        <%-- Row 2 --%>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="center" >
                <asp:Label ID="lblSelectTeacher" runat="server" Text="Select Teacher"  Font-Size="X-Large" Font-Bold="true"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList ID="ddlTeacher" runat="server" DataSourceID="datasrcTeacherList" DataTextField="TeacherName" Width="225px"></asp:DropDownList>
                <asp:SqlDataSource 
                    runat="server" 
                    ID="datasrcTeacherList" 
                    ConnectionString="<%$ ConnectionStrings:Lab3 %>"
                    SelectCommand = "Select TeacherID, FirstName + ' ' + LastName as TeacherName from Teacher order by TeacherID ASC" />
            </asp:TableCell>
            <asp:TableCell>
                    <asp:Button ID="btnRegisterTeacher" runat="server" Text="Register Teacher" Font-Size="X-Large" BackColor="#50C89D" BorderColor="#50C89D" CssClass="button" OnClick="btnRegisterTeacher_Click"/>
            </asp:TableCell>
        </asp:TableRow>

        <%-- Row 3 --%>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="center">
                <asp:Label ID="lblSelectVolunteer" runat="server" Text="Select Volunteer"  Font-Size="X-Large" Font-Bold="true"></asp:Label>                        
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList ID="ddlSelectVolunteer" runat="server" DataSourceID="datasrcVolunteerList" DataTextField="PersonnelList" Width="225px"></asp:DropDownList>
                <asp:SqlDataSource 
                    runat="server" 
                    ID="datasrcVolunteerList" 
                    ConnectionString="<%$ ConnectionStrings:Lab3 %>"
                    SelectCommand = "Select PersonnelID, FirstName + ' ' + LastName as PersonnelList from EventPersonnel Order by PersonnelID ASC"/>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="btnRegisterVolunteer" runat="server" Text="Register Volunteer" Font-Size="X-Large" BackColor="#50C89D" BorderColor="#50C89D" CssClass="button" OnClick="btnRegisterVolunteer_Click"/>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <br />

    <%-- Confirmation Table --%> 
    <asp:Table runat="server" HorizontalAlign="Center">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblConfirmation" runat="server" Text="" ForeColor="#13B100" Font-Bold="true" Font-Size="Large" Visible="false"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <br />

    <%-- Shows all options in the system--%>
    <asp:Table HorizontalAlign= "Center" runat = "server">
        <asp:TableRow>
            <asp:TableCell ColumnSpan ="3">
                <asp:Label ID="lblOptions" runat="server" Text="Click a Button Below to View all the Options"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Button ID ="btnViewEvents" runat="server" Text="View Events" OnClick="btnViewEvents_Click"/>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID ="btnViewTeachers" runat="server" Text="View Teachers" OnClick="btnViewTeachers_Click"/>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID ="btnViewVoluneers" runat="server" Text="View Volunteers" OnClick="btnViewVoluneers_Click"/>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <br />
    <br />
    <asp:GridView ID="grdOptions" runat="server" HorizontalAlign="Center" Width="750px" RowStyle-HorizontalAlign="Center"></asp:GridView>
    <style type="text/css"> 
        .button{
            width:250px;
        }
        .button:hover {
            font-weight:bold;
        }
    </style>

</asp:Content>
