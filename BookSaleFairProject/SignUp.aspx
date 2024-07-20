<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="BookSaleFairProject.SignUp" MasterPageFile="~/Site.master" %>

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
    </style>
    <dx:ASPxPanel ID="ASPxPanel1" runat="server" CssClass="centered">
        <PanelCollection>
            <dx:PanelContent>
                <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Sign Up" Font-Size="X-Large"></dx:ASPxLabel>
                <br />
                <br />
                <dx:ASPxPanel ID="ASPxPanel2" runat="server" CssClass="ss">
                    <PanelCollection>
                        <dx:PanelContent CssClass="center-content">
                            <dx:ASPxTextBox ID="txtFirstName" runat="server" Placeholder="firstName" Width="250px" Height="35px" NullText="Enter Your First Name">
                                <ValidationSettings>
                                    <RequiredField IsRequired="true" ErrorText="First Name is required." />
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                            <br />
                            <br />
                            <dx:ASPxTextBox ID="txtLastName" runat="server" Placeholder="lastName" Width="250px" Height="35px" NullText="Enter Your Last Name">
                                <ValidationSettings>
                                    <RequiredField IsRequired="true" ErrorText="Last Name is required." />
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                            <br />
                            <br />
                            <dx:ASPxTextBox ID="txtEmail" runat="server" Placeholder="email" Width="250px" Height="35px" NullText="Enter Your Email">
                                <ValidationSettings>
                                    <RequiredField IsRequired="true" ErrorText="Email is required." />
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                            <br />
                            <br />

                            <dx:ASPxComboBox ID="genders" runat="server" ClientInstanceName="genders" AutoPostBack="true" OnSelectedIndexChanged="cites_SelectedIndexChanged">
                                <ClientSideEvents SelectedIndexChanged="function(s, e) {
                                      
                                     
                                  }" />
                            </dx:ASPxComboBox>



                            <dx:ASPxTextBox ID="txtUsername" runat="server" Placeholder="Username" Width="250px" Height="35px" NullText="Enter Your Username">
                                <ValidationSettings>
                                    <RequiredField IsRequired="true" ErrorText="Username is required." />
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                            <br />
                            <br />
                            <dx:ASPxTextBox ID="txtPassword" runat="server" Placeholder="Password" Width="250px" Password="true" Height="35px" NullText="Enter Your Password">
                                <ValidationSettings>
                                    <RequiredField IsRequired="true" ErrorText="Password is required." />
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                            <br />
                            <br />
                            <dx:ASPxTextBox ID="txtPassword2" runat="server" Placeholder="Re-enter Password" Width="250px" Password="true" Height="35px" NullText="Re-enter Your Password">
                                <ValidationSettings>
                                    <RequiredField IsRequired="true" ErrorText="Password is required." />
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                            <br />
                            <br />
                            <dx:ASPxLabel ID="lblMessage" runat="server" ForeColor="Red"></dx:ASPxLabel>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxPanel>
                <br />
                <dx:ASPxButton ID="btnSignUp" runat="server" Text="Sign Up" Style="margin-right: 20px;" OnClick="btnSignUp_Click"></dx:ASPxButton>
                <asp:HyperLink ID="lnkSignIn" runat="server" NavigateUrl="SignIn.aspx" Text="Sign In"></asp:HyperLink>
            </dx:PanelContent>
        </PanelCollection>

    </dx:ASPxPanel>


</asp:Content>
