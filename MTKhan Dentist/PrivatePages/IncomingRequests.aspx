<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IncomingRequests.aspx.cs" Inherits="MTKhan_Dentist.IncomingRequests" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        .hero-banner { background: #e8f5f0; text-align: center; padding: 2.5rem 2rem; }
        .pill-label { background: #56cc9d; color: #fff; font-size: 0.75rem; font-weight: 700; letter-spacing: 0.05em; padding: 6px 18px; border-radius: 999px; display: inline-block; }
        .icon-circle { width: 52px; height: 52px; border-radius: 50%; display: flex; align-items: center; justify-content: center; flex-shrink: 0; }
        .request-card { border-left: 4px solid #adb5bd; }
        .request-card.pending { border-left-color: #f4b740; }
        .request-card.confirmed { border-left-color: #2a9d8f; }
        .request-card.declined { border-left-color: #e76f51; }
    </style>

    <a href="StaffDashboard.aspx" class="btn btn-outline-primary mb-4">
    ← Back to Dashboard
</a>

    <asp:Label ID="lblPageError" runat="server" CssClass="alert alert-danger d-block" Visible="false"></asp:Label>

    <asp:PlaceHolder ID="phMain" runat="server">
    <div class="container mt-4 mb-5">

        <div class="hero-banner rounded-4 mb-4">
            <span class="pill-label mb-2">STAFF PORTAL</span>
            <h2 class="fw-bold mt-3 mb-2" style="color:#2b2b2b;">Incoming Requests</h2>
            <p class="mb-0 text-muted">Appointment requests made on the website. This view is read-only: requests are confirmed or declined in the FES at the practice.</p>
        </div>

        <div class="row mb-4">
            <div class="col-md-4 mb-3">
                <div class="card shadow-sm border-0 h-100">
                    <div class="card-body d-flex gap-3 align-items-center">
                        <div class="icon-circle" style="background:#fff3d6; color:#d99100;">
                            <svg width="24" height="24" fill="none" stroke="currentColor" stroke-width="1.8" viewBox="0 0 24 24"><circle cx="12" cy="12" r="10"/><path d="M12 6v6l4 2"/></svg>
                        </div>
                        <div><p class="text-muted mb-1 small">Pending</p><h3 class="mb-0 fw-bold" style="color:#d99100;"><asp:Label ID="lblPending" runat="server" Text="0"></asp:Label></h3></div>
                    </div>
                </div>
            </div>
            <div class="col-md-4 mb-3">
                <div class="card shadow-sm border-0 h-100">
                    <div class="card-body d-flex gap-3 align-items-center">
                        <div class="icon-circle" style="background:#e6f4f1; color:#2a9d8f;">
                            <svg width="24" height="24" fill="none" stroke="currentColor" stroke-width="1.8" viewBox="0 0 24 24"><circle cx="12" cy="12" r="10"/><path d="M8 12.5l3 3 5-6"/></svg>
                        </div>
                        <div><p class="text-muted mb-1 small">Confirmed</p><h3 class="mb-0 fw-bold" style="color:#2a9d8f;"><asp:Label ID="lblConfirmed" runat="server" Text="0"></asp:Label></h3></div>
                    </div>
                </div>
            </div>
            <div class="col-md-4 mb-3">
                <div class="card shadow-sm border-0 h-100">
                    <div class="card-body d-flex gap-3 align-items-center">
                        <div class="icon-circle" style="background:#fde8e8; color:#e76f51;">
                            <svg width="24" height="24" fill="none" stroke="currentColor" stroke-width="1.8" viewBox="0 0 24 24"><circle cx="12" cy="12" r="10"/><path d="M15 9l-6 6M9 9l6 6"/></svg>
                        </div>
                        <div><p class="text-muted mb-1 small">Declined</p><h3 class="mb-0 fw-bold" style="color:#e76f51;"><asp:Label ID="lblDeclined" runat="server" Text="0"></asp:Label></h3></div>
                    </div>
                </div>
            </div>
        </div>

        <div class="card shadow-sm border-0 mb-3">
            <asp:Panel ID="pnlToolbar" runat="server" DefaultButton="btnSearch" CssClass="card-body">
                <asp:HiddenField ID="hfFilter" runat="server" Value="All" />
                <div class="row g-2 align-items-center">
                    <div class="col-lg-5 d-flex flex-wrap gap-2">
                        <asp:Button ID="btnAll" runat="server" Text="All" CommandArgument="All" OnClick="btnFilter_Click" CssClass="btn btn-sm btn-primary" />
                        <asp:Button ID="btnPending" runat="server" Text="Pending" CommandArgument="Pending" OnClick="btnFilter_Click" CssClass="btn btn-sm btn-outline-primary" />
                        <asp:Button ID="btnConfirmed" runat="server" Text="Confirmed" CommandArgument="Confirmed" OnClick="btnFilter_Click" CssClass="btn btn-sm btn-outline-primary" />
                        <asp:Button ID="btnDeclined" runat="server" Text="Declined" CommandArgument="Declined" OnClick="btnFilter_Click" CssClass="btn btn-sm btn-outline-primary" />
                    </div>
                    <div class="col-lg-7">
                        <div class="d-flex gap-2">
                            <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control form-control-sm" placeholder="Search by reference or patient name"></asp:TextBox>
                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-sm btn-primary" />
                            <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" CssClass="btn btn-sm btn-outline-secondary" />
                            <asp:Button ID="btnRefresh" runat="server" Text="Refresh" CssClass="btn btn-sm btn-outline-secondary" />
                        </div>
                    </div>
                </div>
                <asp:Label ID="lblResultInfo" runat="server" CssClass="small text-muted mt-2 d-block"></asp:Label>
            </asp:Panel>
        </div>

        <asp:Repeater ID="rptRequests" runat="server">
            <ItemTemplate>
                <div class='card shadow-sm border-0 mb-3 <%# Eval("CardClass") %>'>
                    <div class="card-body">
                        <div class="d-flex justify-content-between align-items-center mb-1">
                            <span class="fw-semibold"><%#: Eval("Reference_No") %></span>
                            <span class='<%# Eval("BadgeClass") %>'><%#: Eval("Request_Status") %></span>
                        </div>
                        <p class="mb-1 text-muted"><%#: Eval("Message_Text") %></p>
                        <span class="small text-muted"><%#: Eval("ReceivedText") %></span>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

        <asp:Label ID="lblEmpty" runat="server" CssClass="text-muted small d-block text-center py-4" Visible="false" Text="No requests match your search."></asp:Label>

    </div>
    </asp:PlaceHolder>

</asp:Content>