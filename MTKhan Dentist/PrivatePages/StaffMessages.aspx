
<%@ Page Title="Staff Messages" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="StaffMessages.aspx.cs"
    Inherits="MTKhan_Dentist.StaffMessages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-4 mb-5">

        <!-- Page Header -->
        <div class="card shadow-sm border-0 mb-4">
            <div class="card-body p-4">
                <h2 class="fw-bold">Patient Message Board</h2>
                <p class="text-muted mb-0">
                    View patient enquiries and reply on behalf of the practice.
                </p>
            </div>
        </div>

        <asp:Label ID="lblStatus" runat="server"
            EnableViewState="false"
            CssClass="d-block mb-3" />

        <!-- Active Conversations -->
        <div class="card shadow-sm border-0 mb-4">

            <div class="card-header bg-white fw-semibold">
                Active Conversations
            </div>

            <div class="card-body">

                <asp:Panel ID="pnlNoConversations" runat="server" Visible="false">
                    <p class="text-muted mb-0">
                        There are no active patient messages.
                    </p>
                </asp:Panel>

                <asp:GridView ID="gvConversations" runat="server"
                    AutoGenerateColumns="False"
                    CssClass="table table-hover align-middle"
                    GridLines="None"
                    DataKeyNames="Patient_ID"
                    OnSelectedIndexChanged="gvConversations_SelectedIndexChanged">

                    <Columns>

                        <asp:BoundField DataField="Patient_ID"
                            HeaderText="Patient ID" />

                        <asp:BoundField DataField="PatientName"
                            HeaderText="Patient" />

                        <asp:BoundField DataField="LastMessage"
                            HeaderText="Latest Message" />

                        <asp:BoundField DataField="LastMessageAt"
                            HeaderText="Date"
                            DataFormatString="{0:dd MMM yyyy HH:mm}" />

                        <asp:TemplateField HeaderText="Unread Messages">
                            <ItemTemplate>

                                <asp:Label ID="lblUnread" runat="server"
                                    Text='<%# Convert.ToInt32(Eval("UnreadCount")) > 0
                                        ? Eval("UnreadCount") + " unread"
                                        : "All read" %>'
                                    CssClass='<%# Convert.ToInt32(Eval("UnreadCount")) > 0
                                        ? "badge bg-danger"
                                        : "badge bg-secondary" %>' />

                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:CommandField ShowSelectButton="True"
                            SelectText="Open Conversation" />

                    </Columns>

                </asp:GridView>

            </div>
        </div>

        <!-- Archived Conversations -->
        <div class="card shadow-sm border-0 mb-4">

            <div class="card-header bg-white fw-semibold">
                Archived Conversations
            </div>

            <div class="card-body">

                <asp:Panel ID="pnlNoArchivedConversations" runat="server"
                    Visible="false">

                    <p class="text-muted mb-0">
                        You have no archived conversations.
                    </p>

                </asp:Panel>

                <asp:GridView ID="gvArchivedConversations" runat="server"
                    AutoGenerateColumns="False"
                    CssClass="table table-hover align-middle"
                    GridLines="None"
                    DataKeyNames="Patient_ID"
                    OnSelectedIndexChanged="gvArchivedConversations_SelectedIndexChanged">

                    <Columns>

                        <asp:BoundField DataField="Patient_ID"
                            HeaderText="Patient ID" />

                        <asp:BoundField DataField="PatientName"
                            HeaderText="Patient" />

                        <asp:BoundField DataField="LastMessage"
                            HeaderText="Latest Message" />

                        <asp:BoundField DataField="LastMessageAt"
                            HeaderText="Date"
                            DataFormatString="{0:dd MMM yyyy HH:mm}" />

                        <asp:CommandField ShowSelectButton="True"
                            SelectText="Open Conversation" />

                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>

                                <asp:Button ID="btnUnarchive" runat="server"
                                    Text="Unarchive"
                                    CssClass="btn btn-outline-success btn-sm"
                                    CommandArgument='<%# Eval("Patient_ID") %>'
                                    OnClick="btnUnarchive_Click"
                                    CausesValidation="false" />

                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>

                </asp:GridView>

            </div>
        </div>

        <!-- Selected Conversation -->
        <asp:Panel ID="pnlConversation" runat="server" Visible="false">

            <div class="card shadow-sm border-0 mb-4">

                <div class="card-header bg-white fw-semibold">
                    Conversation with
                    <asp:Label ID="lblSelectedPatient" runat="server" />
                </div>

                <div class="card-body">

                    <asp:Repeater ID="rptConversation" runat="server">

                        <ItemTemplate>

                            <div class='p-3 rounded mb-3 <%# Convert.ToString(Eval("Sender_Type")) == "Staff" ? "bg-success bg-opacity-10 ms-md-5" : "bg-light me-md-5" %>'>

                                <div class="d-flex justify-content-between flex-wrap gap-2 mb-2">

                                    <strong>
                                        <%# Convert.ToString(Eval("Sender_Type")) == "Staff"
                                            ? Eval("StaffName")
                                            : "Patient" %>
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

            <!-- Reply -->
            <div class="card shadow-sm border-0">

                <div class="card-header bg-white fw-semibold">
                    Reply to Patient
                </div>

                <div class="card-body p-4">

                    <asp:TextBox ID="txtReply" runat="server"
                        TextMode="MultiLine"
                        Rows="4"
                        MaxLength="1000"
                        CssClass="form-control"
                        placeholder="Type your reply here..." />

                    <!-- Character Counter -->
                    <div class="text-end text-muted small mb-3 mt-1">
                        <span id="staffCharCount">0</span> / 1000 characters
                    </div>

                    <asp:Button ID="btnSendReply" runat="server"
                        Text="Send Reply"
                        CssClass="btn btn-success px-4"
                        OnClick="btnSendReply_Click" />

                    <asp:Button ID="btnRefreshConversation" runat="server"
                        Text="Refresh Messages"
                        CssClass="btn btn-outline-primary px-4 ms-2"
                        CausesValidation="false"
                        OnClick="btnRefreshConversation_Click" />

                    <!-- Archive Chat: no confirmation popup -->
                    <asp:Button ID="btnArchiveConversation" runat="server"
                        Text="Archive Chat"
                        CssClass="btn btn-outline-warning px-4 ms-2"
                        CausesValidation="false"
                        OnClick="btnArchiveConversation_Click" />

                    <asp:Button ID="btnCloseConversation" runat="server"
                        Text="Close Conversation"
                        CssClass="btn btn-outline-secondary ms-2"
                        CausesValidation="false"
                        OnClick="btnCloseConversation_Click" />

                </div>
            </div>

        </asp:Panel>

        <!-- Back -->
        <div class="mt-4">
            <a href="StaffDashboard.aspx" class="btn btn-outline-secondary">
                Back to Staff Dashboard
            </a>
        </div>

    </div>

    <!-- Character Counter -->
    <script>
        document.addEventListener("DOMContentLoaded", function () {

            var messageBox = document.getElementById("<%= txtReply.ClientID %>");
            var counter = document.getElementById("staffCharCount");

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
