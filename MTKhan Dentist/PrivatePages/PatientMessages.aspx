
<%@ Page Title="Messages" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="PatientMessages.aspx.cs"
    Inherits="MTKhan_Dentist.PatientMessages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-4 mb-5">

        <!-- Page Header -->
        <div class="card shadow-sm border-0 mb-4">
            <div class="card-body p-4">
                <h2 class="fw-bold">Message Reception</h2>
                <p class="text-muted mb-0">
                    Send a message to the dental practice and view replies from staff.
                </p>
            </div>
        </div>

        <asp:Label ID="lblStatus" runat="server"
            EnableViewState="false"
            CssClass="d-block mb-3" />

        <!-- Conversation -->
        <div class="card shadow-sm border-0 mb-4">

            <div class="card-header bg-white fw-semibold">
                Your Conversation
            </div>

            <div class="card-body">

                <asp:Panel ID="pnlNoMessages" runat="server" Visible="false">
                    <p class="text-muted mb-0">
                        No messages yet. Send your first message below.
                    </p>
                </asp:Panel>

                <asp:Repeater ID="rptConversation" runat="server">
                    <ItemTemplate>

                        <div class='p-3 rounded mb-3 <%# Convert.ToString(Eval("Sender_Type")) == "Patient" ? "bg-primary bg-opacity-10 ms-md-5" : "bg-light me-md-5" %>'>

                            <div class="d-flex justify-content-between flex-wrap gap-2 mb-2">

                                <strong>
                                    <%# Convert.ToString(Eval("Sender_Type")) == "Patient"
                                        ? "You"
                                        : "Practice Staff" %>
                                </strong>

                                <small class="text-muted">
                                    <%# Eval("Sent_At", "{0:dd MMM yyyy, HH:mm}") %>
                                </small>

                            </div>

                            <div style="white-space:pre-wrap; overflow-wrap:anywhere">
                                <%#: Eval("Message_Text") %>
                            </div>

                        </div>

                    </ItemTemplate>
                </asp:Repeater>

            </div>
        </div>

        <!-- Send Message -->
        <div class="card shadow-sm border-0">

            <div class="card-header bg-white fw-semibold">
                Send a Message
            </div>

            <div class="card-body p-4">

                <asp:TextBox ID="txtMessage" runat="server"
                    TextMode="MultiLine"
                    Rows="4"
                    MaxLength="1000"
                    CssClass="form-control"
                    placeholder="Type your message here..." />

                <!-- Character Counter -->
                <div class="text-end text-muted small mb-3 mt-1">
                    <span id="patientCharCount">0</span> / 1000 characters
                </div>

                <!-- Buttons -->
                <asp:Button ID="btnSend" runat="server"
                    Text="Send Message"
                    CssClass="btn btn-success px-4"
                    OnClick="btnSend_Click" />

                <asp:Button ID="btnRefreshMessages" runat="server"
                    Text="Refresh Messages"
                    CssClass="btn btn-outline-primary px-4 ms-2"
                    CausesValidation="false"
                    OnClick="btnRefreshMessages_Click" />

                <a href="PatientDashboard.aspx"
                    class="btn btn-outline-secondary ms-2">
                    Back to Dashboard
                </a>

            </div>
        </div>

    </div>

    <!-- Character Counter Script -->
    <script>
        document.addEventListener("DOMContentLoaded", function () {

            var messageBox = document.getElementById("<%= txtMessage.ClientID %>");
            var counter = document.getElementById("patientCharCount");

            if (messageBox && counter) {

                function updateCounter() {
                    counter.textContent = messageBox.value.length;
                }

                messageBox.addEventListener("input", updateCounter);

                updateCounter();
            }

        });
    </script>

</asp:Content>

