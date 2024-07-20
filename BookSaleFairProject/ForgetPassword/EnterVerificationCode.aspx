<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EnterVerificationCode.aspx.cs" Inherits="BookSaleFairProject.ForgetPassword.EnterVerificationCode" MasterPageFile="~/Site.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        /* General styling */
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

        /* Styling for ASPxPanel1 */
        .main-panel {
            border: 1px solid #ccc; 
            padding: 20px; 
            max-width: 400px; 
            margin: auto; 
            background-color: #f9f9f9; 
        }

        /* Forgot password link */
        .forgot-password {
            text-align: right;
            margin-top: 10px;
        }
    </style>

    <dx:ASPxPanel ID="ASPxPanel1" runat="server" CssClass="centered main-panel">
        <PanelCollection>
            <dx:PanelContent>
                <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Enter The Verification Code" Font-Size="X-Large"></dx:ASPxLabel>
                <br /><br />
                <dx:ASPxPanel ID="ASPxPanel2" runat="server" CssClass="ss">
                    <PanelCollection>
                        <dx:PanelContent CssClass="center-content">
                            <dx:ASPxTextBox ID="txtCode" runat="server" Style="margin-left: 100px;" Placeholder="Username"  Width="100%" Height="35px" NullText="Enter The Code">
                                <ValidationSettings>
                                    <RequiredField IsRequired="true" ErrorText="Code is required." />
                                </ValidationSettings>
                            </dx:ASPxTextBox>


                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxPanel>
                <br /><br />
                <dx:ASPxButton ID="btnLogin" runat="server" Text="Send" Width="200px" Style="margin-right: 20px;" OnClick="btnLogin_Click" CausesValidation="true"></dx:ASPxButton>
               
            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxPanel>
</asp:Content>
