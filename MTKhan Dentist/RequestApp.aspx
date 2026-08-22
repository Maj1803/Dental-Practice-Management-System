<%@ Page Title="Request an Appointment" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RequestApp.aspx.cs" Inherits="MTKhan_Dentist.RequestApp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .appointment-hero {
            background-color: var(--bs-primary-bg-subtle);
            border: 1px solid var(--bs-primary-border-subtle);
            border-radius: 1rem;
        }
        .form-card {
            border: 1px solid var(--bs-border-color);
            border-radius: 1rem;
        }
        .info-card {
            border: 1px solid var(--bs-border-color);
            border-radius: 0.75rem;
            background-color: #fff;
            transition: transform 0.2s ease-in-out;
        }
        .info-card:hover {
            transform: translateY(-3px);
        }
        .icon-badge {
            display: inline-flex;
            align-items: center;
            justify-content: center;
            width: 42px;
            height: 42px;
            border-radius: 50%;
            background-color: var(--bs-primary-bg-subtle);
            color: var(--bs-primary);
            font-size: 1.25rem;
        }
        .emergency-card {
            background-color: var(--bs-danger-bg-subtle);
            border: 1px solid var(--bs-danger-border-subtle);
            border-radius: 0.75rem;
        }
    </style>

    <div class="container py-5">
        <!-- Friendly Intro Banner -->
        <div class="appointment-hero p-4 p-md-5 mb-5 text-center shadow-sm">
            <h1 class="display-6 fw-bold text-dark mb-3">Book Your Visit with Dr MT Khan</h1>
            <p class="lead text-secondary-emphasis mx-auto mb-0" style="max-width: 720px;">
                Looking after your oral health shouldn't be stressful. Let us know when suits you best and what you need help with, and our Port Shepstone team will get in touch to confirm your chair time.
            </p>
        </div>

        <div class="row g-5">
            <!-- Left Column: Booking Request Form -->
            <div class="col-lg-8">
                <div class="card form-card shadow-sm p-4 p-md-5">
                    <h3 class="fw-bold text-dark mb-4">Your Appointment Details</h3>

                    <!-- Feedback Alert -->
                    <asp:Panel ID="pnlFeedback" runat="server" Visible="false" role="alert">
                        <asp:Literal ID="litFeedback" runat="server" />
                        <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                    </asp:Panel>

                    <!-- Contact Details -->
                    <div class="row g-3 mb-4">
                        <div class="col-md-6">
                            <label for="txtName" class="form-label fw-semibold text-muted">Full Name</label>
                            <asp:TextBox ID="txtName" runat="server" CssClass="form-control" placeholder="e.g. John Doe" MaxLength="100"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" ErrorMessage="Please provide your full name." CssClass="text-danger small" Display="Dynamic" ValidationGroup="ApptGroup" />
                        </div>
                        <div class="col-md-6">
                            <label for="txtPhone" class="form-label fw-semibold text-muted">Phone Number</label>
                            <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" placeholder="e.g. 082 123 4567" MaxLength="20"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvPhone" runat="server" ControlToValidate="txtPhone" ErrorMessage="Please provide a contact number." CssClass="text-danger small" Display="Dynamic" ValidationGroup="ApptGroup" />
                        </div>
                        <div class="col-12">
                            <label for="txtEmail" class="form-label fw-semibold text-muted">Email Address</label>
                            <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" CssClass="form-control" placeholder="e.g. name@example.com" MaxLength="150"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Please provide your email address." CssClass="text-danger small" Display="Dynamic" ValidationGroup="ApptGroup" />
                            <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Enter a valid email address." ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$" CssClass="text-danger small" Display="Dynamic" ValidationGroup="ApptGroup" />
                        </div>
                    </div>

                    <hr class="my-4" />

                    <!-- Schedule Preferences -->
                    <h5 class="fw-bold text-dark mb-3">When would you like to come in?</h5>
                    <div class="row g-3 mb-4">
                        <div class="col-md-6">
                            <label for="txtDatePref" class="form-label fw-semibold text-muted">Preferred Day / Date</label>
                            <asp:TextBox ID="txtDatePref" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvDatePref" runat="server" ControlToValidate="txtDatePref" ErrorMessage="Please pick a preferred date." CssClass="text-danger small" Display="Dynamic" ValidationGroup="ApptGroup" />
                        </div>
                        <div class="col-md-6">
                            <label for="ddlTimePref" class="form-label fw-semibold text-muted">Time of Day Preference</label>
                            <asp:DropDownList ID="ddlTimePref" runat="server" CssClass="form-select">
                                <asp:ListItem Text="Any time of day" Value="Any Time" />
                                <asp:ListItem Text="Morning (08:00 – 12:00)" Value="Morning (08:00 - 12:00)" />
                                <asp:ListItem Text="Midday (12:00 – 14:00)" Value="Midday (12:00 - 14:00)" />
                                <asp:ListItem Text="Afternoon (14:00 – 17:00)" Value="Afternoon (14:00 - 17:00)" />
                            </asp:DropDownList>
                        </div>
                    </div>

                    <hr class="my-4" />

                    <!-- Dental Concerns & Notes -->
                    <h5 class="fw-bold text-dark mb-3">How can we help your smile?</h5>
                    <div class="mb-3">
                        <label for="ddlConcern" class="form-label fw-semibold text-muted">Primary Concern or Reason</label>
                        <asp:DropDownList ID="ddlConcern" runat="server" CssClass="form-select">
                            <asp:ListItem Text="Routine Checkup, Scale & Polish" Value="Routine Checkup / Cleaning" />
                            <asp:ListItem Text="Toothache, Throbbing, or Acute Discomfort" Value="Toothache / Dental Pain" />
                            <asp:ListItem Text="Broken, Chipped, or Loose Tooth" Value="Broken or Chipped Tooth" />
                            <asp:ListItem Text="Sensitive Teeth or Gum Bleeding" Value="Gum Issues / Sensitivity" />
                            <asp:ListItem Text="Filling, Crown, or Bridge Consultation" Value="Restorations" />
                            <asp:ListItem Text="Wisdom Teeth or Extraction Assessment" Value="Extraction Assessment" />
                            <asp:ListItem Text="Other / General Consultation" Value="General Consultation" />
                        </asp:DropDownList>
                    </div>

                    <div class="mb-4">
                        <label for="txtNotes" class="form-label fw-semibold text-muted">Additional Notes or Symptoms (Optional)</label>
                        <asp:TextBox ID="txtNotes" runat="server" TextMode="MultiLine" Rows="3" CssClass="form-control" placeholder="Tell us about any past medical history, dental anxieties, or details about the issue..."></asp:TextBox>
                    </div>

                    <asp:Button ID="btnSubmitAppt" runat="server" Text="Submit Appointment Request" CssClass="btn btn-primary btn-lg w-100 fw-bold shadow-sm" ValidationGroup="ApptGroup" OnClick="btnSubmitAppt_Click" />
                </div>
            </div>

            <!-- Right Column: Reassurances & Emergency Contact -->
            <div class="col-lg-4">
                <div class="d-flex flex-column gap-3">
                    <div class="info-card p-4 shadow-sm">
                        <div class="icon-badge mb-3">&#10003;</div>
                        <h5 class="fw-bold text-dark mb-2">What Happens Next?</h5>
                        <p class="text-secondary small mb-0">
                            Our front desk reviews incoming requests during office hours. We will phone or email you directly to lock in your confirmed slot.
                        </p>
                    </div>

                    <div class="info-card p-4 shadow-sm">
                        <div class="icon-badge mb-3">&#10084;</div>
                        <h5 class="fw-bold text-dark mb-2">Gentle & Anxiety-Free</h5>
                        <p class="text-secondary small mb-0">
                            Nervous about your visit? Let us know. Dr MT Khan takes a gentle, paced approach to ensure you always feel relaxed and in control.
                        </p>
                    </div>

                    <div class="emergency-card p-4 shadow-sm">
                        <div class="d-flex align-items-center mb-2">
                            <span class="fs-4 me-2">&#9888;</span>
                            <h5 class="fw-bold text-danger mb-0">Severe Pain or Emergency?</h5>
                        </div>
                        <p class="text-secondary small mb-3">
                            For acute swelling, trauma, or emergency toothache requiring same-day care, please phone the practice immediately.
                        </p>
                        <a href="tel:+27396820000" class="btn btn-danger btn-sm fw-bold w-100">
                            Call Practice: (039) 682 0000
                        </a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>