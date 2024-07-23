<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BookSaleFairProject.Login" MasterPageFile="~/Site.master" %>

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

       
        .move-right {
            margin-left: 60px; 
        }

       
        .forgot-password {
            margin-left: 160px; 
            text-align: right;
            margin-top: 10px;
        }
    </style>

    <dx:ASPxPanel ID="ASPxPanel1" runat="server" CssClass="centered main-panel">
        <PanelCollection>
            <dx:PanelContent>
                <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Login Page" Font-Size="X-Large"></dx:ASPxLabel>
                <br /><br />
                <dx:ASPxPanel ID="ASPxPanel2" runat="server" CssClass="ss">
                    <PanelCollection>
                        <dx:PanelContent CssClass="center-content">
                            <dx:ASPxTextBox ID="txtUsername" runat="server" Placeholder="Username" Width="100%" Height="35px" NullText="Enter Your Username" CssClass="move-right">
                                <ValidationSettings>
                                    <RequiredField IsRequired="true" ErrorText="Username is required." />
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                            <br /><br />
                            <dx:ASPxTextBox ID="txtPassword" runat="server" Placeholder="Password" Width="100%" Password="true" Height="35px" NullText="Enter Your Password" CssClass="move-right">
                                <ValidationSettings>
                                    <RequiredField IsRequired="true" ErrorText="Password is required." />
                                    <RegularExpression ValidationExpression=".{8,}" ErrorText="Password must be at least 8 characters long." />
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                            <div class="forgot-password">
                                <asp:HyperLink ID="lnkForgotPassword" runat="server" NavigateUrl="./ForgetPassword/EnterEmail.aspx" Text="Forgot Password?" CssClass="forgot-password-link"></asp:HyperLink>
                            </div>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxPanel>
                <br /><br />
                <dx:ASPxButton ID="btnLogin" runat="server" Text="Login" Style="margin-right: 20px;" OnClick="btnLogin_Click" CausesValidation="true"></dx:ASPxButton>
                <asp:HyperLink ID="lnkSignUp" runat="server" NavigateUrl="SignUp.aspx" Text="Sign Up"></asp:HyperLink>
            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxPanel>
</asp:Content>
