<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MTKhan_Dentist.Account.Login" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <main aria-labelledby="title">
        <div class="row justify-content-center">
            <div class="col-md-6 col-lg-5">
                <div class="card shadow-sm mt-4">
                    <div class="card-body p-4">
                        <h2 class="card-title text-center mb-4">Dr MT Khan Dental Practice</h2>

                        <p class="text-center mb-2" style="color: #78C2AD; font-weight: 600; font-size: 1.1rem;">Welcome Back!</p>
                        <p class="text-center text-muted mb-4" style="font-size: 0.9rem; letter-spacing: 1px;">Please log in to continue</p>

                        <!-- Error Message -->
                        <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                            <p class="text-danger">
                                <asp:Literal runat="server" ID="FailureText" />
                            </p>
                        </asp:PlaceHolder>

                        <!-- USERNAME -->
                        <div class="mb-3">
                            <asp:Label runat="server" AssociatedControlID="Email" CssClass="form-label">Username</asp:Label>
                            <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" placeholder="Enter your username" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Email" CssClass="text-danger" ErrorMessage="The email field is required." />
                        </div>

                        <!-- PASSWORD -->
                        <div class="mb-3">
                            <asp:Label runat="server" AssociatedControlID="Password" CssClass="form-label">Password</asp:Label>
                            <div class="input-group">
                                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" placeholder="Enter your password" ClientIDMode="Static" />
                                <button type="button" class="btn btn-outline-secondary" id="togglePassword" tabindex="-1" aria-label="Show password">
                                    <svg id="eyeIcon" xmlns="http://www.w3.org/2000/svg" width="18" height="18" fill="none" stroke="currentColor" stroke-width="1.8" viewBox="0 0 24 24">
                                        <path d="M1 12s4-8 11-8 11 8 11 8-4 8-11 8-11-8-11-8z"/>
                                        <circle cx="12" cy="12" r="3"/>
                                    </svg>
                                </button>
                            </div>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="The password field is required." />
                        </div>

                        <!-- FORGOT PASSWORD -->
                        <div class="text-end mb-3">
                            <asp:HyperLink runat="server" ID="ForgotPasswordHyperLink">Forgot Password?</asp:HyperLink>
                        </div>

                        <!-- LOGIN BUTTON -->
                        <div class="d-grid">
                            <asp:Button runat="server" OnClick="LogIn" Text="Login" CssClass="btn btn-primary btn-lg" />
                        </div>

                        <!-- REGISTER LINK — remove if you have no working Register page -->
                        <div class="text-center mt-3">
                            <asp:HyperLink runat="server" NavigateUrl="~/Account/Register" Text="Register as a new patient" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </main>

    <style>
        #togglePassword { border-color: #ced4da; background-color: #fff; color: #6c757d; }
        #togglePassword:hover { background-color: #f8f9fa; color: #495057; }
        #togglePassword:focus { box-shadow: none; outline: none; }
    </style>

    <script type="text/javascript">
        document.addEventListener("DOMContentLoaded", function () {
            var toggleBtn = document.getElementById("togglePassword");
            var pwdInput = document.getElementById("Password");
            var eyeIcon = document.getElementById("eyeIcon");
            if (!toggleBtn || !pwdInput || !eyeIcon) return;

            toggleBtn.addEventListener("click", function () {
                if (pwdInput.type === "password") {
                    pwdInput.type = "text";
                    toggleBtn.setAttribute("aria-label", "Hide password");
                    eyeIcon.innerHTML = '<path d="M17.94 17.94A10.07 10.07 0 0 1 12 20c-7 0-11-8-11-8a18.45 18.45 0 0 1 5.06-5.94M9.9 4.24A9.12 9.12 0 0 1 12 4c7 0 11 8 11 8a18.5 18.5 0 0 1-2.16 3.19m-6.72-1.07a3 3 0 1 1-4.24-4.24"/><line x1="1" y1="1" x2="23" y2="23"/>';
                } else {
                    pwdInput.type = "password";
                    toggleBtn.setAttribute("aria-label", "Show password");
                    eyeIcon.innerHTML = '<path d="M1 12s4-8 11-8 11 8 11 8-4 8-11 8-11-8-11-8z"/><circle cx="12" cy="12" r="3"/>';
                }
            });
        });
    </script>
</asp:Content>