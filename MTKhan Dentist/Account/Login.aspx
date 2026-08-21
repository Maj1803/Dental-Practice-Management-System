<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MTKhan_Dentist.Account.Login" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
      <main aria-labelledby="title">
        <div class="row justify-content-center">
            <div class="col-md-6 col-lg-5">
                <div class="card shadow-sm mt-4">
                    <div class="card-body p-4">
                        <h2 class="card-title text-center mb-4">Dr MT Khan Dental Practice</h2>

                        <!-- Welcome Back Message -->
                        <p class="text-center mb-2" style="color: #78C2AD; font-weight: 600; font-size: 1.1rem;">Welcome Back!</p>

                        <!-- Log in as text -->
                        <p class="text-center text-muted mb-3" style="font-size: 0.9rem; letter-spacing: 1px;">Log in as</p>
                        
                        <!-- Role Selection -->
                        <div class="text-center mb-4">
                        <div class="btn-group" role="group" aria-label="Role selection">
                        <input type="radio" class="btn-check" name="role" id="roleReceptionist" autocomplete="off" checked>
                        <label class="btn btn-info" for="roleReceptionist">Receptionist</label>
        
                        <input type="radio" class="btn-check" name="role" id="roleDentist" autocomplete="off">
                        <label class="btn btn-info" for="roleDentist">Dentist</label>
                        </div>
                        </div>
                        
                        

                        <!-- Error Message -->
                        <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                            <p class="text-danger">
                                <asp:Literal runat="server" ID="FailureText" />
                            </p>
                        </asp:PlaceHolder>

                        <!-- USERNAME -->
                        <div class="mb-3">
                            <asp:Label runat="server" AssociatedControlID="Email" CssClass="form-label">
                                Username
                            </asp:Label>
                            <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" placeholder="Enter your username" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Email" CssClass="text-danger" ErrorMessage="The email field is required." />
                        </div>

                        <!-- PASSWORD -->
                        <div class="mb-3">
                            <asp:Label runat="server" AssociatedControlID="Password" CssClass="form-label">
                                Password
                            </asp:Label>
                            <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" placeholder="Enter your password" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="The password field is required." />
                        </div>

                        <!-- FORGOT PASSWORD -->
                        <div class="text-end mb-3">
                            <asp:HyperLink runat="server" ID="ForgotPasswordHyperLink">
                                Forgot Password?
                            </asp:HyperLink>
                        </div>

                        <!-- REMEMBER ME -->
                        <div class="mb-3">
                            <asp:CheckBox runat="server" ID="RememberMe" Text="Remember me?" />
                        </div>

                        <!-- LOGIN BUTTON -->
                        <div class="d-grid">
                            <asp:Button runat="server" OnClick="LogIn" Text="Login" CssClass="btn btn-primary btn-lg" />
                        </div>

                        
                    </div>
                </div>
            </div>
        </div>
    </main>
</asp:Content>