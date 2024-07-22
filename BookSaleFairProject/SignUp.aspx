<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="BookSaleFairProject.SignUp" MasterPageFile="~/Site.master" %>

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
            border: 1px solid #ccc; /* Add border */
            padding: 20px; /* Add padding inside the panel */
            max-width: 500px; /* Limit the maximum width of the panel */
            margin: auto; /* Center the panel horizontally */
            background-color: #f9f9f9; /* Background color */
        }

        /* Add margin-left to move text boxes right */
        .move-right {
            margin-left: 150px; /* Adjust this value to move the text boxes further right or left */
        }

         /* Styling for inline label and combo box */
        .gender-container {
            display: flex;            
            margin-left: 30px; /* Adjust this value as needed */
        }

        .gender-label {
            margin-right: 25px; /* Adjust spacing between label and combo box */
        }
    </style>

    <dx:ASPxPanel ID="ASPxPanel1" runat="server" CssClass="centered main-panel">
        <PanelCollection>
            <dx:PanelContent>
                <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Sign Up" Font-Size="X-Large"></dx:ASPxLabel>
                <br />
                <br />
                <dx:ASPxPanel ID="ASPxPanel2" runat="server" CssClass="ss">
                    <PanelCollection>
                        <dx:PanelContent CssClass="center-content">
                            <dx:ASPxTextBox ID="txtFirstName" runat="server" Placeholder="First Name" Width="250px" Height="35px" NullText="Enter Your First Name" CssClass="move-right">
                                <ValidationSettings>
                                    <RequiredField IsRequired="true" ErrorText="First Name is required." />
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                            <br />
                            <br />
                            <dx:ASPxTextBox ID="txtLastName" runat="server" Placeholder="Last Name" Width="250px" Height="35px" NullText="Enter Your Last Name" CssClass="move-right">
                                <ValidationSettings>
                                    <RequiredField IsRequired="true" ErrorText="Last Name is required." />
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                            <br />
                            <br />
                            <dx:ASPxTextBox ID="txtEmail" runat="server" Placeholder="Email" Width="250px" Height="35px" NullText="Enter Your Email" CssClass="move-right">
                                <ValidationSettings>
                                    <RequiredField IsRequired="true" ErrorText="Email is required." />
                                    <RegularExpression ValidationExpression="^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$" ErrorText="Invalid email format." />
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                            <br />
                            <br />
                            <dx:ASPxPanel ID="ASPxPanelGender" runat="server" CssClass="gender-container">
                                <PanelCollection>
                                    <dx:PanelContent>
                                        <dx:ASPxLabel ID="lblGender" runat="server" Text="Gender:" CssClass="gender-label"></dx:ASPxLabel>
                                        <dx:ASPxComboBox ID="genders" runat="server" ClientInstanceName="genders" AutoPostBack="true" OnSelectedIndexChanged="cites_SelectedIndexChanged">
                                            <ClientSideEvents SelectedIndexChanged="function(s, e) { }" />
                                        </dx:ASPxComboBox>
                                    </dx:PanelContent>
                                </PanelCollection>
                            </dx:ASPxPanel>
                            <br />
                            <br />
                            <dx:ASPxTextBox ID="txtUsername" runat="server" Placeholder="Username" Width="250px" Height="35px" NullText="Enter Your Username" CssClass="move-right">
                                <ValidationSettings>
                                    <RequiredField IsRequired="true" ErrorText="Username is required." />
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                            <br />
                            <br />
                            <dx:ASPxTextBox ID="txtPassword" runat="server" Placeholder="Password" Width="250px" Password="true" Height="35px" NullText="Enter Your Password" CssClass="move-right">
                                <ValidationSettings>
                                    <RequiredField IsRequired="true" ErrorText="Password is required." />
                                    <RegularExpression ValidationExpression=".{8,}" ErrorText="Password must be at least 8 characters long." />
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                            <br />
                            <br />
                            <dx:ASPxTextBox ID="txtPassword2" runat="server" Placeholder="Re-enter Password" Width="250px" Password="true" Height="35px" NullText="Re-enter Your Password" CssClass="move-right">
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
