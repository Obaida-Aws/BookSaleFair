<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="BookSaleFairProject.ForgetPassword.ResetPassword" MasterPageFile="~/Site.master" %>

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
                <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Reset Password" Font-Size="X-Large"></dx:ASPxLabel>
                <br />
                <br />
                <dx:ASPxPanel ID="ASPxPanel2" runat="server" CssClass="ss">
                    <PanelCollection>
                        <dx:PanelContent CssClass="center-content">
                            <dx:ASPxTextBox ID="txtPassword1" runat="server" Style="margin-left: 100px;" Placeholder="Username" Width="100%" Password="true" Height="35px" NullText="Enter Your New Password">
                                <ValidationSettings>
                                    <RequiredField IsRequired="true" ErrorText="Email is required." />
                                    <RegularExpression ValidationExpression=".{5,}" ErrorText="Password must be at least 5 characters long." />
                                </ValidationSettings>
                            </dx:ASPxTextBox>

                            <br />
                            <br />
                            <dx:ASPxTextBox ID="txtPassword2" runat="server" Placeholder="Password" Style="margin-left: 100px;" Width="100%" Password="true" Height="35px" NullText="Re-Enter Your New Password">
                                <ValidationSettings>
                                    <RequiredField IsRequired="true" ErrorText="Password is required." />
                                    <RegularExpression ValidationExpression=".{5,}" ErrorText="Password must be at least 5 characters long." />
                                </ValidationSettings>
                            </dx:ASPxTextBox>

                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxPanel>
                <br />
                <br />
                <dx:ASPxButton ID="btnLogin" runat="server" Text="Confirm" Width="200px" Style="margin-right: 20px;" OnClick="btnLogin_Click" CausesValidation="true"></dx:ASPxButton>

            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxPanel>
</asp:Content>
