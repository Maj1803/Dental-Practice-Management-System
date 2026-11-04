<%@ Page Title="My Profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="MTKhan_Dentist.Account.Manage" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %>.</h2>

        <div>
            <asp:PlaceHolder runat="server" ID="successMessage" Visible="false" ViewStateMode="Disabled">
                <p class="text-success"><%: SuccessMessage %></p>
            </asp:PlaceHolder>
        </div>

        <div class="col-md-12">
            <div class="row">
                <dl class="dl-horizontal">
                    <div class="col-md-8">
                        <hr />

                        <asp:Label ID="lblStatus" runat="server" CssClass="d-block mb-3" EnableViewState="false" />

                        <div class="mb-3">
                            <label class="form-label">Email address</label>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" MaxLength="150" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmail" ValidationGroup="Profile"
                                ErrorMessage="Email is required." CssClass="text-danger small" Display="Dynamic" />
                            <asp:RegularExpressionValidator runat="server" ControlToValidate="txtEmail" ValidationGroup="Profile"
                                ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$" ErrorMessage="Enter a valid email."
                                CssClass="text-danger small" Display="Dynamic" />
                        </div>

                        <div class="mb-3">
                            <label class="form-label">Phone number</label>
                            <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" TextMode="Phone" MaxLength="20" />
                            <asp:RegularExpressionValidator runat="server" ControlToValidate="txtPhone" ValidationGroup="Profile"
                                ValidationExpression="^[0-9+\s\-()]{7,20}$" ErrorMessage="Enter a valid phone number."
                                CssClass="text-danger small" Display="Dynamic" />
                        </div>

                        <div class="py-4">
                        <asp:Button ID="btnSaveProfile" runat="server" Text="Save changes" ValidationGroup="Profile"
                            CssClass="btn btn-success px-4" OnClick="btnSaveProfile_Click" />

                        <h4 class="mt-5">Password</h4>
                        <hr />
                        <asp:HyperLink NavigateUrl="/Account/ManagePassword" Text="Change my password" Visible="false"
                            ID="ChangePassword" runat="server" CssClass="btn btn-outline-dark" />
                        <asp:HyperLink NavigateUrl="/Account/ManagePassword" Text="Create a password" Visible="false"
                            ID="CreatePassword" runat="server" CssClass="btn btn-outline-dark" />

                        </div>

                        <div class="py-4">
                            <hr />
                            <a href="~/PrivatePages/PatientDashboard.aspx" runat="server" class="btn btn-primary px-4">← Back to dashboard</a>

                        </div>
                    </div>
                </dl>
            </div>
        </div>
    </main>
</asp:Content>
