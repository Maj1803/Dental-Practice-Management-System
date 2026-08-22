<%@ Page Title="Contact Us" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="MTKhan_Dentist.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .contact-hero-img {
            width: 100%;
            height: 100%;
            min-height: 420px;
            object-fit: cover;
            border-top-right-radius: 180px;
            border-bottom-right-radius: 180px;
        }
        .contact-card {
            background-color: var(--bs-danger); /* Minty coral tone */
            color: #fff;
            border: none;
            border-radius: 1rem;
            transition: transform 0.2s ease-in-out;
        }
        .contact-card:hover {
            transform: translateY(-4px);
        }
        .contact-card a {
            color: #fff;
            text-decoration: none;
        }
        .contact-card a:hover {
            text-decoration: underline;
        }
        .form-underlined {
            border: none;
            border-bottom: 1.5px solid var(--bs-gray-400);
            border-radius: 0;
            padding-left: 0;
            background-color: transparent;
        }
        .form-underlined:focus {
            box-shadow: none;
            border-bottom-color: var(--bs-danger);
            background-color: transparent;
        }
    </style>

    <div class="container py-5">
        <!-- Top Section: Visual & Form -->
        <div class="row align-items-center g-5 mb-5">
            <!-- Left Side: Hero Image with Asymmetric Curve -->
            <div class="col-lg-6 d-none d-lg-block">
                <div class="pe-lg-4">
                    <img src="" alt="Dr MT Khan Dental Practice" class="contact-hero-img shadow-sm" />
                </div>
            </div>

            <!-- Right Side: Contact Form -->
            <div class="col-lg-6">
                <div class="ps-lg-3">
                    <h1 class="display-6 fw-bold text-dark mb-4">Contact Us</h1>

                    <!-- Feedback Alert -->
                    <asp:Panel ID="pnlFeedback" runat="server" Visible="false" CssClass="alert alert-success alert-dismissible fade show" role="alert">
                        <asp:Literal ID="litFeedback" runat="server" />
                        <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                    </asp:Panel>

                    <div class="mb-3">
                        <label for="txtName" class="form-label text-muted fw-semibold mb-1">Name</label>
                        <asp:TextBox ID="txtName" runat="server" CssClass="form-control form-underlined" placeholder="Enter your Name" MaxLength="100"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" ErrorMessage="Name is required." CssClass="text-danger small" Display="Dynamic" ValidationGroup="ContactForm" />
                    </div>

                    <div class="mb-3">
                        <label for="txtEmail" class="form-label text-muted fw-semibold mb-1">Email</label>
                        <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" CssClass="form-control form-underlined" placeholder="Enter a valid email address" MaxLength="150"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email is required." CssClass="text-danger small" Display="Dynamic" ValidationGroup="ContactForm" />
                        <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Invalid email address format." ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$" CssClass="text-danger small" Display="Dynamic" ValidationGroup="ContactForm" />
                    </div>

                    <div class="mb-4">
                        <label for="txtMessage" class="form-label text-muted fw-semibold mb-1">Message</label>
                        <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control form-underlined" placeholder="How can we assist you?"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvMessage" runat="server" ControlToValidate="txtMessage" ErrorMessage="Message is required." CssClass="text-danger small" Display="Dynamic" ValidationGroup="ContactForm" />
                    </div>

                    <div class="form-check mb-4">
                        <asp:CheckBox ID="chkTerms" runat="server" CssClass="form-check-input" />
                        <label class="form-check-label text-muted small" for="<%= chkTerms.ClientID %>">
                            I accept the <a href="Terms.aspx" class="text-danger text-decoration-none">Terms of Service</a>
                        </label>
                        <asp:CustomValidator ID="cvTerms" runat="server" ErrorMessage="<br/>You must accept the terms before submitting." ClientValidationFunction="validateTerms" OnServerValidate="cvTerms_ServerValidate" CssClass="text-danger small" Display="Dynamic" ValidationGroup="ContactForm" />
                    </div>

                    <asp:Button ID="btnSubmit" runat="server" Text="SUBMIT" CssClass="btn btn-danger w-100 py-3 fw-bold text-uppercase shadow-sm" ValidationGroup="ContactForm" OnClick="btnSubmit_Click" />
                </div>
            </div>
        </div>

        <!-- Bottom Section: 3 Info Cards -->
        <div class="row g-4 pt-4">
            <!-- Card 1: Call Us -->
            <div class="col-md-4">
                <div class="card contact-card h-100 p-4 shadow-sm">
                    <div class="card-body d-flex flex-column justify-content-center">
                        <h5 class="card-title fw-bold text-uppercase mb-3">
                             Call Us
                        </h5>
                        <p class="card-text mb-1">
                            <a href="tel:+27396820000">+27 (0)39 681 2670</a>
                        </p>
                    </div>
                </div>
            </div>

            <!-- Card 2: Location -->
            <div class="col-md-4">
                <div class="card contact-card h-100 p-4 shadow-sm">
                    <div class="card-body d-flex flex-column justify-content-center">
                        <h5 class="card-title fw-bold text-uppercase mb-3">
                            Location
                        </h5>
                        <p class="card-text mb-0">
                            Dr MT Khan Dental Practice<br />
                            6 Anerly Rd, Anerly<br />
                            Port Shepstone, 4230, KZN
                        </p>
                    </div>
                </div>
            </div>

            <!-- Card 3: Hours -->
            <div class="col-md-4">
                <div class="card contact-card h-100 p-4 shadow-sm">
                    <div class="card-body d-flex flex-column justify-content-center">
                        <h5 class="card-title fw-bold text-uppercase mb-3">
                            Hours
                        </h5>
                        <p class="card-text mb-1">
                            <strong>Mon – Thurs:</strong> 08:00 - 16:30
                        </p>
                        <p class="card-text mb-1">
                            <strong>Fri:</strong> 08:00 - 11:30, 14:00 - 16:30
                        </p>
                        <p class="card-text mb-0">
                            <strong>Sat:</strong> 08:30 - 13:00 | <strong>Sun:</strong> Closed
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        function validateTerms(source, args) {
            var chk = document.getElementById('<%= chkTerms.ClientID %>');
            args.IsValid = chk && chk.checked;
        }
    </script>
</asp:Content>