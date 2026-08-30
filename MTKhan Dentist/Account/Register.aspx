<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="MTKhan_Dentist.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <main aria-labelledby="title">
        <div class="row justify-content-center">
            <div class="col-md-6 col-lg-5">
                <div class="card shadow-sm mt-4">
                    <div class="card-body p-4">
                        <h2 class="card-title text-center mb-4">Dr MT Khan Dental Practice</h2>

                        <!-- Create Account Message -->
                        <p class="text-center mb-2" style="color: #78C2AD; font-weight: 600; font-size: 1.1rem;">Create an Account</p>

                        <!-- Error Message -->
                        <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                            <p class="text-danger">
                                <asp:Literal runat="server" ID="FailureText" />
                            </p>
                        </asp:PlaceHolder>

                        <!-- FIRST NAME -->
                            <div class="mb-3">
                                <asp:Label runat="server" AssociatedControlID="PatientFirstName" CssClass="form-label">First Name</asp:Label>
                                <asp:TextBox runat="server" ID="PatientFirstName" CssClass="form-control" placeholder="Enter first name" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="PatientFirstName" ValidationGroup="PatientValidation" CssClass="text-danger" ErrorMessage="First name is required." Display="Dynamic" />
                            </div>

                            <!-- LAST NAME -->
                            <div class="mb-3">
                                <asp:Label runat="server" AssociatedControlID="PatientLastName" CssClass="form-label">Last Name</asp:Label>
                                <asp:TextBox runat="server" ID="PatientLastName" CssClass="form-control" placeholder="Enter last name" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="PatientLastName" ValidationGroup="PatientValidation" CssClass="text-danger" ErrorMessage="Last name is required." Display="Dynamic" />
                            </div>

                            <!-- PHONE NUMBER -->
                            <div class="mb-3">
                                <asp:Label runat="server" AssociatedControlID="PatientPhone" CssClass="form-label">Phone Number</asp:Label>
                                <asp:TextBox runat="server" ID="PatientPhone" CssClass="form-control" placeholder="Enter phone number" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="PatientPhone" ValidationGroup="PatientValidation" CssClass="text-danger" ErrorMessage="Phone number is required." Display="Dynamic" />
                            </div>

                            <!-- EMAIL -->
                            <div class="mb-3">
                                <asp:Label runat="server" AssociatedControlID="PatientEmail" CssClass="form-label">Email</asp:Label>
                                <asp:TextBox runat="server" ID="PatientEmail" CssClass="form-control" TextMode="Email" placeholder="Enter email address" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="PatientEmail" ValidationGroup="PatientValidation" CssClass="text-danger" ErrorMessage="Email is required." Display="Dynamic" />
                            </div>

                            <!-- DATE OF BIRTH -->
                            <div class="mb-3">
                                <asp:Label runat="server" AssociatedControlID="PatientDOB" CssClass="form-label">Date of Birth</asp:Label>
                                <asp:TextBox runat="server" ID="PatientDOB" CssClass="form-control" TextMode="Date" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="PatientDOB" ValidationGroup="PatientValidation" CssClass="text-danger" ErrorMessage="Date of birth is required." Display="Dynamic" />
                            </div>

                            <!-- ALLERGIES -->
                            <div class="mb-3">
                                <asp:Label runat="server" AssociatedControlID="PatientAllergies" CssClass="form-label">Allergies</asp:Label>
                                <asp:TextBox runat="server" ID="PatientAllergies" CssClass="form-control" TextMode="MultiLine" Rows="2" placeholder="List any known allergies (or None)" />
                            </div>

                            <!-- ADDRESS SECTION -->
                            <p class="text-muted mb-2" style="font-size: 0.85rem; letter-spacing: 1px; border-bottom: 1px solid #dee2e6; padding-bottom: 6px;">Address</p>

                            <!-- STREET -->
                            <div class="mb-3">
                                <asp:Label runat="server" AssociatedControlID="PatientStreet" CssClass="form-label">Street</asp:Label>
                                <asp:TextBox runat="server" ID="PatientStreet" CssClass="form-control" placeholder="Enter street address" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="PatientStreet" ValidationGroup="PatientValidation" CssClass="text-danger" ErrorMessage="Street is required." Display="Dynamic" />
                            </div>

                            <!-- SUBURB -->
                            <div class="mb-3">
                                <asp:Label runat="server" AssociatedControlID="PatientSuburb" CssClass="form-label">Suburb</asp:Label>
                                <asp:TextBox runat="server" ID="PatientSuburb" CssClass="form-control" placeholder="Enter suburb" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="PatientSuburb" ValidationGroup="PatientValidation" CssClass="text-danger" ErrorMessage="Suburb is required." Display="Dynamic" />
                            </div>

                            <!-- CITY -->
                            <div class="mb-3">
                                <asp:Label runat="server" AssociatedControlID="PatientCity" CssClass="form-label">City</asp:Label>
                                <asp:TextBox runat="server" ID="PatientCity" CssClass="form-control" placeholder="Enter city" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="PatientCity" ValidationGroup="PatientValidation" CssClass="text-danger" ErrorMessage="City is required." Display="Dynamic" />
                            </div>

                            <!-- POSTAL CODE -->
                            <div class="mb-3">
                                <asp:Label runat="server" AssociatedControlID="PatientCode" CssClass="form-label">Postal Code</asp:Label>
                                <asp:TextBox runat="server" ID="PatientCode" CssClass="form-control" placeholder="Enter postal code" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="PatientCode" ValidationGroup="PatientValidation" CssClass="text-danger" ErrorMessage="Postal code is required." Display="Dynamic" />
                            </div>

                            <!-- REGISTER PATIENT BUTTON -->
                            <div class="d-grid">
                                <asp:Button runat="server" ID="BtnRegisterPatient" OnClick="BtnRegisterPatient_Click" Text="Register" CssClass="btn btn-primary btn-lg" ValidationGroup="PatientValidation" />
                            </div>

                        <!-- LINK TO LOGIN -->
                        <div class="text-center mt-3">
                            <p class="text-muted mb-0" style="font-size: 0.9rem;">
                                Already have an account?
                                <asp:HyperLink runat="server" ID="LoginHyperLink" NavigateUrl="~/Account/Login">Log in</asp:HyperLink>
                            </p>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </main>
</asp:Content>
