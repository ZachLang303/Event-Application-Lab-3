<%@ Page Title="New User - Brian & Zach" Language="C#" MasterPageFile="~/Lab2.Master" AutoEventWireup="true" CodeBehind="AddNewUserNavigation.aspx.cs" Inherits="Event_Application_Lab_2.AddNewUserNavigation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--Navigation Bar Table--%>
    <style type="text/css"> 
        .button:hover {
            font-weight:bold;
        }
    </style>
    <asp:Table ID="navbar" runat="server" HorizontalAlign="Center" Style ="margin-top: 52px">
        <asp:TableRow>
            <asp:TableCell ColumnSpan ="4" HorizontalAlign="Center" VerticalAlign="Top">
                <asp:Label ID="lblAddNewUserNavigation" runat="server" Text="Please Select an Option" Font-Names="Comic Sans MS" Font-Size="25px" Font-Bold="true"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                    <asp:Button ID="btnTeacher" runat="server" onclick="btnTeacher_Click" Text="I'm a Teacher" Font-Size="X-Large" Width="200px" BackColor="#50C89D" BorderColor="#50C89D" CssClass="button"   CausesValidation="false"/>
            </asp:TableCell>
                <asp:TableCell HorizontalAlign = "Center" VerticalAlign="Middle">
                    <asp:Button ID="btnVolunteer" runat="server" OnClick="btnVolunteer_Click" Text="I'm a Volunteer" Font-Size="X-Large" Width="200px" BackColor="#50C89D" BorderColor="#50C89D" CssClass="button" CausesValidation="false"/>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign = "Center" VerticalAlign="Middle">
                    <asp:Button ID="btnCoordinator" runat="server" OnClick="btnCoordinator_Click" Text="I'm a Coordinator " Font-Size="X-Large" Width="200px" BackColor="#50C89D" BorderColor="#50C89D" CssClass="button" CausesValidation="false"/>
                </asp:TableCell>                     
        </asp:TableRow>
    </asp:Table>
    <br />
    <br />

    <%--Tells the user one teacher creation is available at this time--%>
    <asp:Table runat ="server" ID="tblNotAvailabe" HorizontalAlign="Center" Visible="false">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblNotAvailable" runat="server" 
                    Text="Unfortunatley only teacher creation is available at this time :(. Please come back later if you would like to select a different option!" 
                    Font-Bold ="true" 
                    Font-Italic="true"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
 
</asp:Content>
