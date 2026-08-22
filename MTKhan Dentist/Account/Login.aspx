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
                        
                        <!-- User Type Selection: Staff or Patient (ALWAYS VISIBLE) -->
                        <div class="text-center mb-3">
                            <div class="btn-group" role="group" aria-label="User type selection">
                                <asp:RadioButton ID="rbStaff" runat="server" GroupName="UserType" CssClass="btn-check" AutoPostBack="true" OnCheckedChanged="UserType_Changed" />
                                <asp:Label ID="lblStaff" runat="server" AssociatedControlID="rbStaff" CssClass="btn btn-outline-info" Text="Staff"></asp:Label>
                                
                                <asp:RadioButton ID="rbPatient" runat="server" GroupName="UserType" CssClass="btn-check" AutoPostBack="true" OnCheckedChanged="UserType_Changed" Checked="true" />
                                <asp:Label ID="lblPatient" runat="server" AssociatedControlID="rbPatient" CssClass="btn btn-info" Text="Patient"></asp:Label>
                            </div>
                        </div>

                        <!-- Staff Role Selection: Receptionist or Dentist (HIDDEN by default) -->
                        <asp:Panel ID="pnlStaffRoles" runat="server" CssClass="text-center mb-4" Visible="false">
                            <div class="btn-group" role="group" aria-label="Staff role selection">
                                <asp:RadioButton ID="rbReceptionist" runat="server" GroupName="StaffRole" CssClass="btn-check" AutoPostBack="true" OnCheckedChanged="StaffRole_Changed" Checked="true" />
                                <asp:Label ID="lblReceptionist" runat="server" AssociatedControlID="rbReceptionist" CssClass="btn btn-secondary" Text="Receptionist"></asp:Label>
                                
                                <asp:RadioButton ID="rbDentist" runat="server" GroupName="StaffRole" CssClass="btn-check" AutoPostBack="true" OnCheckedChanged="StaffRole_Changed" />
                                <asp:Label ID="lblDentist" runat="server" AssociatedControlID="rbDentist" CssClass="btn btn-outline-secondary" Text="Dentist"></asp:Label>
                            </div>
                        </asp:Panel>

                        
                        

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
    <style>
        /* Active state for Staff button - solid color */
        .btn-group .btn-check:checked + .btn-info {
            background-color: #138496 !important;
            border-color: #117a8b !important;
            color: #fff !important;
        }
        
        /* Hover state for Staff button */
        .btn-group .btn-info:hover {
            background-color: #138496 !important;
            border-color: #117a8b !important;
        }
        
        /* Active state for Patient button - solid color */
        .btn-group .btn-check:checked + .btn-outline-info {
            background-color: #17a2b8 !important;
            color: #fff !important;
        }
        
        /* Active state for Receptionist button */
        .btn-group .btn-check:checked + .btn-secondary {
            background-color: #545b62 !important;
            border-color: #4e555b !important;
            color: #fff !important;
        }
        
        /* Hover state for Receptionist */
        .btn-group .btn-secondary:hover {
            background-color: #545b62 !important;
            border-color: #4e555b !important;
        }
        
        /* Active state for Dentist button */
        .btn-group .btn-check:checked + .btn-outline-secondary {
            background-color: #6c757d !important;
            color: #fff !important;
        }
        
        /* Animation for staff roles appearing */
        #pnlStaffRoles {
            transition: all 0.3s ease;
        }
    </style>
</asp:Content>

