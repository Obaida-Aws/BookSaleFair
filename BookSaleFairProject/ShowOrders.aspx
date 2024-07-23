<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowOrders.aspx.cs" Inherits="BookSaleFairProject.ShowOrders" MasterPageFile="~/Site.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .centered {
            text-align: center;
            margin-bottom: 20px;
            width: 100%; 
        }

        .page-title {
            font-size: 24px;
            font-weight: bold;
            margin-bottom: 20px;
            display: block; 
            margin: 0 auto; 
            text-align: center; 
        }

        .panel-container {
            display: block; 
            margin: 0 auto; 
            text-align: left; 
        }

        .plain-text-button {
            border: none;
            background-color: transparent;
            padding: 0;
            margin: 0;
            font-size: inherit;
            font-family: inherit;
            color: green;
            cursor: pointer;
        }

        .plain-text-button2 {
            border: none;
            background-color: transparent;
            padding: 0;
            margin: 0;
            font-size: inherit;
            font-family: inherit;
            color: red;
            cursor: pointer;
        }
    </style>

    <dx:ASPxLabel ID="lblPageTitle" runat="server" Text="Customers Orders" CssClass="page-title" ClientInstanceName="lblPageTitle" />

    <dx:ASPxPanel ID="ASPxPanel1" runat="server" CssClass="panel-container">
        <PanelCollection>
            <dx:PanelContent>
                <dx:ASPxGridView ID="gridOrders" runat="server" AutoGenerateColumns="False" KeyFieldName="OrderId">
                    <Columns>
                        <dx:GridViewDataTextColumn FieldName="OrderId" Caption="Order Id" />
                        <dx:GridViewDataTextColumn FieldName="Name" Caption="Customer Name" />
                        <dx:GridViewDataTextColumn FieldName="Price" Caption="Total Price" />
                        <dx:GridViewDataTextColumn FieldName="Date" Caption="Order Date" />

                        <dx:GridViewDataCheckColumn Caption="Actions">
                            <DataItemTemplate>
                                <dx:ASPxButton runat="server" Text="Accept" OnClick="btnAccept_Click" ClientInstanceName="btnAction" CssClass="plain-text-button" />
                                <dx:ASPxButton runat="server" Text="Reject" OnClick="btnReject_Click" ClientInstanceName="btnAction" CssClass="plain-text-button2" />
                            </DataItemTemplate>
                        </dx:GridViewDataCheckColumn>
                    </Columns>
                </dx:ASPxGridView>
            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxPanel>

</asp:Content>
