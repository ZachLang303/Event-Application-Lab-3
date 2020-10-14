<%@ Page Title="Main Menu - Brian & Zach" Language="C#" MasterPageFile="~/Lab2.Master" AutoEventWireup="true" CodeBehind="MainMenu.aspx.cs" Inherits="Lab3.MainMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />

    <%--Table for Running Complex Queries on Data -- Is visible to ALL users--%>
    <asp:Table runat="server" HorizontalAlign="Center">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblSelectEvent" runat="server" Text="Select Event"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList ID="ddlEvent" runat="server" Width="150px" DataSourceID="datasrcEventList" DataTextField="EventList"></asp:DropDownList>
                <asp:SqlDataSource 
                    runat="server" 
                    ID="datasrcEventList" 
                    ConnectionString ="<%$ ConnectionStrings:Lab3 %>"
                    SelectCommand = "Select EventName as EventList from Event order by EventID ASC" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="btnEventQuery" runat="server" Text="Run Event Query" Width="150px" OnClick="btnEventQuery_Click"/>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblSelectVolunteer" runat="server" Text="Select Personnel"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList ID="ddlVolunteer" runat="server" Width="150px" DataSourceID="datasrcPersonnelList" DataTextField="PersonnelList"></asp:DropDownList>
                  <asp:SqlDataSource 
                      runat="server" 
                      ID="datasrcPersonnelList" 
                      ConnectionString="<%$ ConnectionStrings:Lab3 %>"
                      SelectCommand = "Select PersonnelID, FirstName + ' ' + LastName as PersonnelList from EventPersonnel order by PersonnelID ASC" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="btnVolunteerQuery" runat="server" Text="Run Personnel Query" Width="150px" OnClick="btnVolunteerQuery_Click"/>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblSelectStudent" runat="server" Text="Select Student"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList ID="ddlStudent" runat="server" Width="150px" DataSourceID="datasrcStudentList" DataTextField="StudentList"></asp:DropDownList>
                <asp:SqlDataSource 
                    runat="server" 
                    ID="datasrcStudentList" 
                    ConnectionString="<%$ ConnectionStrings:Lab3 %>"
                     SelectCommand = "Select StudentID, FirstName + ' ' + LastName as StudentList from Student Order by StudentID ASC" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="btnStudentQuery" runat="server" Text="Run Student Query" Width="150px" OnClick="btnStudentQuery_Click" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblSelectTeacher" runat="server" Text="Select Teacher"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList ID="ddlTeacher" runat="server" Width="150px" DataSourceID="datasrcTeacherList" DataTextField="TeacherList"></asp:DropDownList>
                <asp:SqlDataSource 
                    runat="server" 
                    ID="datasrcTeacherList" 
                    ConnectionString="<%$ ConnectionStrings:Lab3 %>"
                    SelectCommand = "Select TeacherID, FirstName + ' ' + LastName as TeacherList from Teacher order by TeacherID ASC" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="btnSelectTeacher" runat="server" Text="Run Teacher Query" Width="150px" OnClick="btnSelectTeacher_Click" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <br />
    <br />
    
    <%--Displays the Results--%>
    <asp:GridView ID="grdSelected"
        runat="server" 
        HorizontalAlign="Center" 
        Width="600px" 
        RowStyle-HorizontalAlign="Center" 
        Caption = "" 
        CaptionAlign="Left"></asp:GridView>

    <br />

    <asp:GridView ID="grdResults" 
        runat="server" 
        HorizontalAlign="Center" 
        Width="600px" 
        RowStyle-HorizontalAlign="Center" 
        Caption="" 
        CaptionAlign="Left"></asp:GridView>
    <br />

    <asp:GridView ID="grdResults2" 
        runat="server" 
        HorizontalAlign="Center" 
        Width="600px" 
        RowStyle-HorizontalAlign="Center" 
        Visible="true" 
        Caption="" 
        CaptionAlign="Left"></asp:GridView>
</asp:Content>