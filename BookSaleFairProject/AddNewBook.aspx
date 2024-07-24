<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddNewBook.aspx.cs" Inherits="BookSaleFairProject.AddNewBook" MasterPageFile="~/Site.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .centered {
            margin-top: 50px;
            text-align: center;
        }

        .ss {
            display: flex;
            flex-direction: column;
            align-items: center;
            margin-top: 50px;
            margin-bottom: 20px;
        }

        .center-content {
            display: flex;
            flex-direction: column;
            align-items: center;
            width: 100%;
        }


        .main-panel {
            border: 1px solid #ccc;
            padding: 20px;
            max-width: 400px;
            margin: auto;
            background-color: #f9f9f9;
        }


        .forgot-password {
            text-align: right;
            margin-top: 10px;
        }

        .type-container {
            display: flex;
            margin: 20px 60px 0 30px;
        }

        .type-label {
            margin-right: 25px;
        }
    </style>

    <script type="text/javascript">
        function OnFileUploadComplete(s, e) {
            document.getElementById('image').src = e.callbackData;
        }

        function BeforeFileUpload() {
            var title = document.getElementById('txtTitle').value;
            if (!title) {
                alert("Title is required!");
                return false;
            }
            hfTitle.Set("title", title);
            alert("Title set to hidden field: " + title);
        }
    </script>

    <dx:ASPxPanel ID="ASPxPanel1" runat="server" CssClass="centered main-panel">
        <PanelCollection>
            <dx:PanelContent>
                <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Add New Book" Font-Size="X-Large"></dx:ASPxLabel>
                <br />
                <br />
                <dx:ASPxPanel ID="ASPxPanel2" runat="server" CssClass="ss">
                    <PanelCollection>
                        <dx:PanelContent CssClass="center-content">

                            <dx:ASPxTextBox ID="txtTitle" runat="server" Style="margin-left: 100px;" Placeholder="Title" Width="100%" Height="35px" NullText="Enter The Book Title">
                                <ValidationSettings>
                                    <RequiredField IsRequired="true" ErrorText="Title is required." />
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                            <br />
                            <dx:ASPxTextBox ID="txtAuthor" runat="server" Style="margin-left: 100px;" Placeholder="Author" Width="100%" Height="35px" NullText="Enter The Book Author">
                                <ValidationSettings>
                                    <RequiredField IsRequired="true" ErrorText="Author is required." />
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                            <br />
                            <dx:ASPxTextBox ID="txtPrice" runat="server" Style="margin-left: 100px;" Placeholder="Price" Width="100%" Height="35px" NullText="Enter The Book Price">
                                <ValidationSettings>
                                    <RequiredField IsRequired="true" ErrorText="Price is required." />
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                            <br />
                            <dx:ASPxTextBox ID="txtCount" runat="server" Style="margin-left: 100px;" Placeholder="Count" Width="100%" Height="35px" NullText="Enter The Book Quantity">
                                <ValidationSettings>
                                    <RequiredField IsRequired="true" ErrorText="Quantity is required." />
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                            <br />
                            <dx:ASPxTextBox ID="txtDescription" runat="server" Style="margin-left: 100px;" Placeholder="Description" Width="100%" Height="35px" NullText="Enter The Book Description">
                                <ValidationSettings>
                                    <RequiredField IsRequired="true" ErrorText="Description is required." />
                                </ValidationSettings>
                            </dx:ASPxTextBox>

                            <dx:ASPxPanel ID="ASPxPanelGender" runat="server" CssClass="type-container">
                                <PanelCollection>
                                    <dx:PanelContent>
                                        <dx:ASPxLabel ID="lblType" runat="server" Text="Type:" CssClass="type-label"></dx:ASPxLabel>
                                        <dx:ASPxComboBox ID="types" Width="220px" runat="server" ClientInstanceName="types" AutoPostBack="true" OnSelectedIndexChanged="cites_SelectedIndexChanged">
                                            <ClientSideEvents SelectedIndexChanged="function(s, e) { }" />
                                        </dx:ASPxComboBox>
                                    </dx:PanelContent>
                                </PanelCollection>
                            </dx:ASPxPanel>
                            <br />

                            <dx:ASPxUploadControl ID="Upload" runat="server" ShowUploadButton="False">
                                <ValidationSettings AllowedFileExtensions=".jpg,.jpeg,.jpe,.gif">
                                </ValidationSettings>
                            </dx:ASPxUploadControl>

                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxPanel>
                <br />
                <br />
                <dx:ASPxButton ID="btnLogin" runat="server" Text="Add" Width="200px" Style="margin-right: 20px;" OnClick="btnAdd_Click" CausesValidation="true"></dx:ASPxButton>

            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxPanel>
</asp:Content>
