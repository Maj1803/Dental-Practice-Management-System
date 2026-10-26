
<%@ Page Title="Staff Messages" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="StaffMessages.aspx.cs"
    Inherits="MTKhan_Dentist.StaffMessages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-4 mb-5">

        <div class="card shadow-sm border-0 mb-4">
            <div class="card-body p-4">
                <h2 class="fw-bold">Patient Message Board</h2>
                <p class="text-muted mb-0">
                    View patient enquiries and reply on behalf of the practice.
                </p>
            </div>
        </div>

        <asp:Label ID="lblStatus" runat="server"
            EnableViewState="false" CssClass="d-block mb-3" />

        <div class="card shadow-sm border-0 mb-4">
            <div class="card-header bg-white fw-semibold">
                Patient Conversations
            </div>

            <div class="card-body">

                <asp:Panel ID="pnlNoConversations" runat="server" Visible="false">
                    <p class="text-muted mb-0">
                        There are no patient messages yet.
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

                        <asp:BoundField DataField="UnreadCount"
                            HeaderText="Unread" />

                        <asp:CommandField ShowSelectButton="True"
                            SelectText="Open Conversation" />
                    </Columns>

                </asp:GridView>

            </div>
        </div>

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
                                        <%# Convert.ToString(Eval("Sender_Type")) == "Staff" ? "Practice Staff" : "Patient" %>
                                    </strong>

                                    <small class="text-muted">
                                        <%# Eval("Sent_At", "{0:dd MMM yyyy, HH:mm}") %>
                                    </small>
                                </div>

                                <div style="white-space:pre-wrap; overflow-wrap:anywhere"><%#: Eval("Message_Text") %></div>

                            </div>
                        </ItemTemplate>
                    </asp:Repeater>

                </div>
            </div>

            <div class="card shadow-sm border-0">
                <div class="card-header bg-white fw-semibold">
                    Reply to Patient
                </div>

                <div class="card-body p-4">

                    <asp:TextBox ID="txtReply" runat="server"
                        TextMode="MultiLine" Rows="4"
                        MaxLength="1000"
                        CssClass="form-control mb-3"
                        placeholder="Type your reply here..." />

                    <asp:Button ID="btnSendReply" runat="server"
                        Text="Send Reply"
                        CssClass="btn btn-success px-4"
                        OnClick="btnSendReply_Click" />

                    <asp:Button ID="btnCloseConversation" runat="server"
                        Text="Close Conversation"
                        CssClass="btn btn-outline-secondary ms-2"
                        CausesValidation="false"
                        OnClick="btnCloseConversation_Click" />

                </div>
            </div>

        </asp:Panel>

        <div class="mt-4">
            <a href="StaffDashboard.aspx" class="btn btn-outline-secondary">
                Back to Staff Dashboard
            </a>
        </div>

    </div>

</asp:Content>
