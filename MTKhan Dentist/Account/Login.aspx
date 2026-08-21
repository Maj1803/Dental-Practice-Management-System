<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MTKhan_Dentist.Account.Login" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <main aria-labelledby="title">

        <h2 id="title"><%: Title %>.</h2>

        <div class="row">

            <div class="col-md-8">

                <section id="loginForm">

                    <div class="row">

                        <h4>Use a local account to log in.</h4>

                        <hr />

                        <!-- Error Message -->

                        <asp:PlaceHolder
                            runat="server"
                            ID="ErrorMessage"
                            Visible="false">

                            <p class="text-danger">

                                <asp:Literal
                                    runat="server"
                                    ID="FailureText" />

                            </p>

                        </asp:PlaceHolder>


                        <!-- EMAIL -->

                        <div class="row">

                            <asp:Label
                                runat="server"
                                AssociatedControlID="Email"
                                CssClass="col-md-2 col-form-label">

                                Email

                            </asp:Label>

                            <div class="col-md-10">

                                <asp:TextBox
                                    runat="server"
                                    ID="Email"
                                    CssClass="form-control"
                                    TextMode="Email" />

                                <asp:RequiredFieldValidator
                                    runat="server"
                                    ControlToValidate="Email"
                                    CssClass="text-danger"
                                    ErrorMessage="The email field is required." />

                            </div>

                        </div>


                        <br />


                        <!-- PASSWORD -->

                        <div class="row">

                            <asp:Label
                                runat="server"
                                AssociatedControlID="Password"
                                CssClass="col-md-2 col-form-label">

                                Password

                            </asp:Label>

                            <div class="col-md-10">

                                <asp:TextBox
                                    runat="server"
                                    ID="Password"
                                    TextMode="Password"
                                    CssClass="form-control" />

                                <asp:RequiredFieldValidator
                                    runat="server"
                                    ControlToValidate="Password"
                                    CssClass="text-danger"
                                    ErrorMessage="The password field is required." />

                            </div>

                        </div>


                        <br />


                        <!-- FORGOT PASSWORD -->

                        <div class="row">

                            <div class="offset-md-2 col-md-10">

                                <asp:HyperLink
                                    runat="server"
                                    ID="ForgotPasswordHyperLink">

                                    Forgot password?

                                </asp:HyperLink>

                            </div>

                        </div>


                        <br />


                        <!-- REMEMBER ME -->

                        <div class="row">

                            <div class="offset-md-2 col-md-10">

                                <asp:CheckBox
                                    runat="server"
                                    ID="RememberMe"
                                    Text="Remember me?" />

                            </div>

                        </div>


                        <br />


                        <!-- LOGIN BUTTON -->

                        <div class="row">

                            <div class="offset-md-2 col-md-10">

                                <asp:Button
                                    runat="server"
                                    OnClick="LogIn"
                                    Text="Log in"
                                    CssClass="btn btn-primary" />

                            </div>

                        </div>


                        <br />


                        <!-- REGISTER -->

                        <p>

                            Don't have an account?

                            <asp:HyperLink
                                runat="server"
                                ID="RegisterHyperLink">

                                Register

                            </asp:HyperLink>

                        </p>

                    </div>

                </section>

            </div>

        </div>

    </main>

</asp:Content>