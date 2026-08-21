<%@ Page Title="Forgot Password"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Forgot.aspx.cs"
    Inherits="MTKhan_Dentist.Account.ForgotPassword" %>

<asp:Content
    runat="server"
    ID="BodyContent"
    ContentPlaceHolderID="MainContent">

    <main aria-labelledby="title">

        <h2 id="title">Forgot Password</h2>

        <div class="row">

            <div class="col-md-8">

                <!-- RESET PASSWORD FORM -->

                <asp:PlaceHolder
                    ID="loginForm"
                    runat="server">

                    <h4>Reset your password</h4>

                    <hr />


                    <!-- ERROR MESSAGE -->

                    <asp:PlaceHolder
                        runat="server"
                        ID="ErrorMessage"
                        Visible="false">

                        <div class="alert alert-danger">

                            <asp:Literal
                                runat="server"
                                ID="FailureText" />

                        </div>

                    </asp:PlaceHolder>


                    <!-- EMAIL -->

                    <div class="row mb-3">

                        <asp:Label
                            runat="server"
                            AssociatedControlID="Email"
                            CssClass="col-md-3 col-form-label">

                            Email

                        </asp:Label>

                        <div class="col-md-9">

                            <asp:TextBox
                                runat="server"
                                ID="Email"
                                CssClass="form-control"
                                TextMode="Email" />

                            <asp:RequiredFieldValidator
                                runat="server"
                                ControlToValidate="Email"
                                CssClass="text-danger"
                                ErrorMessage="Email is required." />

                        </div>

                    </div>


                    <!-- NEW PASSWORD -->

                    <div class="row mb-3">

                        <asp:Label
                            runat="server"
                            AssociatedControlID="NewPassword"
                            CssClass="col-md-3 col-form-label">

                            New Password

                        </asp:Label>

                        <div class="col-md-9">

                            <asp:TextBox
                                runat="server"
                                ID="NewPassword"
                                CssClass="form-control"
                                TextMode="Password" />

                            <asp:RequiredFieldValidator
                                runat="server"
                                ControlToValidate="NewPassword"
                                CssClass="text-danger"
                                ErrorMessage="New password is required." />

                        </div>

                    </div>


                    <!-- CONFIRM PASSWORD -->

                    <div class="row mb-3">

                        <asp:Label
                            runat="server"
                            AssociatedControlID="ConfirmPassword"
                            CssClass="col-md-3 col-form-label">

                            Confirm Password

                        </asp:Label>

                        <div class="col-md-9">

                            <asp:TextBox
                                runat="server"
                                ID="ConfirmPassword"
                                CssClass="form-control"
                                TextMode="Password" />

                            <asp:RequiredFieldValidator
                                runat="server"
                                ControlToValidate="ConfirmPassword"
                                CssClass="text-danger"
                                ErrorMessage="Please confirm your password." />

                        </div>

                    </div>


                    <br />


                    <!-- RESET BUTTON -->

                    <div class="row">

                        <div class="offset-md-3 col-md-9">

                            <asp:Button
                                runat="server"
                                ID="ResetButton"
                                Text="Reset Password"
                                OnClick="Forgot"
                                CssClass="btn btn-primary" />

                        </div>

                    </div>


                    <br />


                    <!-- BACK TO LOGIN -->

                    <div class="row">

                        <div class="offset-md-3 col-md-9">

                            <a href="Login.aspx">
                                Back to Login
                            </a>

                        </div>

                    </div>

                </asp:PlaceHolder>


                <!-- SUCCESS MESSAGE -->

                <asp:PlaceHolder
                    runat="server"
                    ID="DisplayEmail"
                    Visible="false">

                    <div class="alert alert-success">

                        <h4>Password Reset Successful</h4>

                        <p>
                            Your password has been successfully changed.
                        </p>

                        <a
                            href="Login.aspx"
                            class="btn btn-primary">

                            Go to Login

                        </a>

                    </div>

                </asp:PlaceHolder>

            </div>

        </div>

    </main>

</asp:Content>