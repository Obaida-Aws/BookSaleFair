<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowOrderContent.aspx.cs" Inherits="BookSaleFairProject.ShowOrderContent" MasterPageFile="~/Site.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        .centered22 {
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
            margin-top: 40px;
            margin-left:200px;
            text-align: left;
        }

        .plain-text-button {
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

    <dx:ASPxLabel ID="lblPageTitle" runat="server" Text="Order Content" CssClass="page-title" ClientInstanceName="lblPageTitle" />

    <dx:ASPxPanel ID="ASPxPanel1" runat="server" CssClass="panel-container">
        <PanelCollection>
            <dx:PanelContent>
                <dx:ASPxGridView ID="gridOrders" runat="server" AutoGenerateColumns="False" KeyFieldName="OrderId">
                    <Columns>
                        <dx:GridViewDataTextColumn FieldName="OrderId" Caption="Book Name" />
                        <dx:GridViewDataTextColumn FieldName="Name" Caption="Price" />
                        <dx:GridViewDataTextColumn FieldName="Price" Caption="Total Price" />
                        <dx:GridViewDataTextColumn FieldName="Date" Caption="Order Date" />

                        <dx:GridViewDataCheckColumn Caption="Actions">
                            <DataItemTemplate>
                                <dx:ASPxButton runat="server" Text="Cancel" OnClick="btnAccept_Click" ClientInstanceName="btnAction" CssClass="plain-text-button" />

                            </DataItemTemplate>
                        </dx:GridViewDataCheckColumn>
                    </Columns>
                </dx:ASPxGridView>
            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxPanel>



</asp:Content>
