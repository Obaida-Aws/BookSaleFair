<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="BookSaleFairProject.HomePage" MasterPageFile="~/Site.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        /* Navigationbar styling */
        /*
            i remove the padding
        */
        .navbar {
            background-color: #333;
            display: flex;
            justify-content: space-between;
            align-items: center;
        }

            .navbar .dxm-item {
                color: white;
                margin: 0 15px;
                text-decoration: none;
                font-size: 16px;
                padding: 10px 15px;
                transition: background-color 0.3s;
                border-radius: 5px;
            }

                .navbar .dxm-item:hover {
                    background-color: #ddd;
                    color: black;
                }

        .centered {
            text-align: center;
            margin-bottom: 20px;
        }

        .welcome-text {
            font-size: 24px;
            font-weight: bold;
            color: #333;
            margin-bottom: 20px;
        }

        .label-book-sale-fair {
            font-weight: bold;
            font-size: 24px;
            color: orange;
            margin-left: 10px;
        }

        .main-panel {
            background-color: #f9f9f9;
            padding: 20px;
            border: 1px solid #ddd;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }
    </style>

    <dx:ASPxPanel ID="navbarPanel" runat="server" CssClass="navbar">
        <PanelCollection>
            <dx:PanelContent>
                <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="BookSaleFair" CssClass="label-book-sale-fair"></dx:ASPxLabel>
                <dx:ASPxMenu ID="ASPxMenu1" runat="server" CssClass="navbar">
                    <Items>

                        <dx:MenuItem Text="Home" NavigateUrl="#home" />
                        <dx:MenuItem Text="Chart" NavigateUrl="#chart" />
                        <dx:MenuItem Text="Services" NavigateUrl="#services" />
                        <dx:MenuItem Text="Logout" NavigateUrl="#logout" />
                    </Items>
                </dx:ASPxMenu>
            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxPanel>

    <dx:ASPxPanel ID="ASPxPanel1" runat="server" CssClass="main-panel">
        <PanelCollection>
            <dx:PanelContent>
                <dx:ASPxMenu ID="ASPxMenu2" runat="server" CssClass="slider">
                    <Items>
                        <dx:MenuItem Text="Fiction" NavigateUrl="#home" />
                        <dx:MenuItem Text="History" NavigateUrl="#chart" />
                        <dx:MenuItem Text="Science" NavigateUrl="#services" />
                        <dx:MenuItem Text="Children’s " NavigateUrl="#logout" />
                        <dx:MenuItem Text="Poetry" NavigateUrl="#logout" />
                        <dx:MenuItem Text="Young Adult (YA)" NavigateUrl="#logout" />
                    </Items>
                </dx:ASPxMenu>
            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxPanel>
</asp:Content>
