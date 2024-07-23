<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="BookSaleFairProject.HomePage" MasterPageFile="~/Site.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        body, html {
            margin: 0;
            padding: 0;
        }


        .full-width-content {
            width: 100%;
            margin: 0;
            padding: 0;
        }


        .navbar {
            background-color: #333;
            display: flex;
            justify-content: space-between;
            align-items: center;
            padding: 10px 20px;
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

        .label-book-sale-fair {
            font-weight: bold;
            font-size: 24px;
            color: orange;
            margin-left: 10px;
        }

        .main-panel {
            background-color: #f9f9f9;
            padding: 20px 50px;
            border: 1px solid #ddd;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            margin-top: 20px;
        }

        .myCards {
            display: flex;
            justify-content: space-between;
            align-items: center;
        }

        .action-buttons2 {
            display: flex;
            gap: 10px;
            margin-left: 20px;
        }

        .p1 {
            display: flex;
            gap: 10px;
            margin-left: 100px;
        }

        .Search1 {
            width: 380px;
            height: 35px;
            padding: 6px;
            font-size: 16px;
            border: 1px solid #ccc;
            border-radius: 25px;
            outline: none;
            box-sizing: border-box;
        }

            .Search1::placeholder {
                color: #aaa;
            }

            .Search1:hover {
                border-color: #999;
            }

            .Search1:focus {
                border-color: #66afe9;
                box-shadow: 0 0 5px rgba(0, 123, 255, 0.5);
            }

        .button-style {
            border-radius: 25px;
            padding: 6px 20px;
            font-size: 16px;
            font-weight: bold;
            background-color: #007bff;
            color: white;
            border: none;
            cursor: pointer;
            transition: background-color 0.3s;
        }

            .button-style:hover {
                background-color: #0056b3;
            }

        .action-buttons {
            display: flex;
            gap: 10px;
        }

        .slider {
            margin-left: 100px;
        }

        .centered {
            text-align: center;
        }

        .centered-textbox {
            display: flex;
            justify-content: center;
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
    <dx:ASPxPopupControl ID="popupCart" runat="server" PopupElementID="ASPxButton1" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" HeaderText="Order Content">
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
                <div class="centered">
                    <dx:ASPxGridView ID="gridProducts" runat="server" AutoGenerateColumns="False" KeyFieldName="Name">
                        <Columns>
                            <dx:GridViewDataTextColumn FieldName="Name" Caption="Name" />
                            <dx:GridViewDataTextColumn FieldName="Price" Caption="Price" />
                            <dx:GridViewDataColumn Caption="Actions">
                                <DataItemTemplate>
                                    <dx:ASPxButton runat="server" Text="Cancel" OnClick="btn_Click" ClientInstanceName="btnAction" CssClass="plain-text-button" />

                                </DataItemTemplate>
                            </dx:GridViewDataColumn>
                        </Columns>
                    </dx:ASPxGridView>
                </div>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>



    <dx:ASPxPanel ID="navbarPanel" runat="server" CssClass="navbar">
        <PanelCollection>
            <dx:PanelContent>
                <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="BookSaleFair" CssClass="label-book-sale-fair"></dx:ASPxLabel>
                <dx:ASPxMenu ID="ASPxMenu1" runat="server" CssClass="navbar">
                    <Items>
                        <dx:MenuItem Text="Home" NavigateUrl="#home" />
                        <dx:MenuItem Text="Services" NavigateUrl="#services" />
                        <dx:MenuItem Text="Logout" NavigateUrl="Login.aspx" />
                    </Items>
                </dx:ASPxMenu>
                <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Cart" OnClick="ASPxok1_Click"></dx:ASPxButton>
                 <dx:ASPxButton ID="ASPxButton2" runat="server" Text="Show Orders" OnClick="ASPxorder1_Click"></dx:ASPxButton>
            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxPanel>

    <dx:ASPxPanel ID="ASPxPanel1" runat="server" CssClass="main-panel">
        <PanelCollection>
            <dx:PanelContent>
                <dx:ASPxMenu ID="ASPxMenu2" runat="server" CssClass="slider" OnItemClick="ASPxMenu2_ItemClick">
                    <Items>
                        <dx:MenuItem Text="Fiction" Name="Fiction" NavigateUrl="#home" />
                        <dx:MenuItem Text="History" Name="History" NavigateUrl="#chart" />
                        <dx:MenuItem Text="Science" Name="Science" NavigateUrl="#services" />
                        <dx:MenuItem Text="Children’s Books" Name="Children" NavigateUrl="#logout" />
                        <dx:MenuItem Text="Poetry" Name="Poetry" NavigateUrl="#logout" />
                        <dx:MenuItem Text="Young Adult (YA)" Name="YoungAdult" NavigateUrl="#logout" />
                    </Items>
                </dx:ASPxMenu>

                <dx:ASPxPanel ID="ASPxPanel2" runat="server" CssClass="p1">
                    <PanelCollection>
                        <dx:PanelContent>
                            <dx:ASPxTextBox CssClass="Search1" ID="ASPxTextBox1" runat="server" Style="margin-top: 20px;" NullText="Search">
                            </dx:ASPxTextBox>
                            <dx:ASPxPanel ID="ASPxPanel3" runat="server" CssClass="action-buttons2">
                                <PanelCollection>
                                    <dx:PanelContent>
                                        <dx:ASPxButton ID="btnSearch" runat="server" Text="Search" Style="margin-top: 20px;" Height="35px" CssClass="button-style" OnClick="btnSearch_Click" />
                                        <dx:ASPxButton ID="btnAdd" runat="server" Text="Add Book" Style="margin-top: 20px;" Height="35px" CssClass="button-style" OnClick="ASPxButton1_Click" />
                                    </dx:PanelContent>
                                </PanelCollection>
                            </dx:ASPxPanel>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxPanel>

            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxPanel>

    <!-- ASPxCardView without Layout Group and Layout Item -->
    <dx:ASPxCardView ID="ASPxCardView1" runat="server" Width="100%" CssClass="myCards">
        <Columns>
            <dx:CardViewTextColumn FieldName="ID" Caption="ID" VisibleIndex="1">
            </dx:CardViewTextColumn>
            <dx:CardViewTextColumn FieldName="Title" Caption="Title" VisibleIndex="2" />
            <dx:CardViewTextColumn FieldName="Description" Caption="Description" VisibleIndex="3" />
            <dx:CardViewTextColumn FieldName="Price" Caption="Price" VisibleIndex="4" />
            <dx:CardViewColumn Caption="Actions" VisibleIndex="5">
                <DataItemTemplate>
                    <div class="action-buttons">
                        <dx:ASPxButton ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" CommandArgument='<%# Container.VisibleIndex %>' />
                        <dx:ASPxButton ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" CommandArgument='<%# Container.VisibleIndex %>' />
                    </div>
                </DataItemTemplate>
            </dx:CardViewColumn>
        </Columns>
    </dx:ASPxCardView>

</asp:Content>
