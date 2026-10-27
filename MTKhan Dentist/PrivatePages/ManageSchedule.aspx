<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageSchedule.aspx.cs" Inherits="MTKhan_Dentist.ManageSchedule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        .hero-banner { background: #e8f5f0; text-align: center; padding: 3rem 2rem; }
        .pill-label { background: #56cc9d; color: #fff; font-size: 0.75rem; font-weight: 700; letter-spacing: 0.05em; padding: 6px 18px; border-radius: 999px; display: inline-block; }
        .schedule-calendar { font-size: 0.8rem; }
        .schedule-calendar td, .schedule-calendar th { padding: 4px 0; }
        .schedule-calendar a { text-decoration: none; }
        .doctor-header { display: flex; align-items: center; gap: 8px; padding: 10px; }
        .doctor-avatar { width: 30px; height: 30px; border-radius: 50%; display: flex; align-items: center; justify-content: center; font-size: 0.75rem; font-weight: 700; color: #fff; flex-shrink: 0; }
        .appt-block { border-radius: 8px; padding: 8px 10px; margin: 4px 0; font-size: 0.8rem; }
        .icon-circle { width: 52px; height: 52px; border-radius: 50%; display: flex; align-items: center; justify-content: center; flex-shrink: 0; }
    </style>

    <a href="StaffDashboard.aspx" class="btn btn-outline-primary mb-4">
    ← Back to Dashboard
</a>

    <asp:Label ID="lblPageError" runat="server" CssClass="alert alert-danger d-block" Visible="false"></asp:Label>

    <asp:PlaceHolder ID="phMain" runat="server">
    <div class="container mt-4 mb-5">

        <div class="hero-banner rounded-4 mb-4">
            <span class="pill-label mb-2">STAFF PORTAL</span>
            <h2 class="fw-bold mt-3 mb-2" style="color:#2b2b2b;">Manage Schedule</h2>
            <p class="mb-0 text-muted">Appointment schedule and practitioner availability overview.</p>
        </div>

        <div class="row mb-4">
            <div class="col-md-3 mb-3">
                <div class="card shadow-sm border-0 h-100">
                    <div class="card-body d-flex gap-3 align-items-center">
                        <div class="icon-circle" style="background:#e6f4f1; color:#2a9d8f;">
                            <svg width="24" height="24" fill="none" stroke="currentColor" stroke-width="1.8" viewBox="0 0 24 24"><rect x="3" y="4" width="18" height="18" rx="2"/><path d="M16 2v4M8 2v4M3 10h18"/></svg>
                        </div>
                        <div><p class="text-muted mb-1 small">Today's Appointments</p><h3 class="mb-0 fw-bold"><asp:Label ID="lblTodayCount" runat="server" Text="0"></asp:Label></h3></div>
                    </div>
                </div>
            </div>
            <div class="col-md-3 mb-3">
                <div class="card shadow-sm border-0 h-100">
                    <div class="card-body d-flex gap-3 align-items-center">
                        <div class="icon-circle" style="background:#e6f4f1; color:#2a9d8f;">
                            <svg width="24" height="24" fill="none" stroke="currentColor" stroke-width="1.8" viewBox="0 0 24 24"><circle cx="12" cy="12" r="10"/><path d="M12 6v6l4 2"/></svg>
                        </div>
                        <div><p class="text-muted mb-1 small">Scheduled</p><h3 class="mb-0 fw-bold text-success"><asp:Label ID="lblScheduled" runat="server" Text="0"></asp:Label></h3></div>
                    </div>
                </div>
            </div>
            <div class="col-md-3 mb-3">
                <div class="card shadow-sm border-0 h-100">
                    <div class="card-body d-flex gap-3 align-items-center">
                        <div class="icon-circle" style="background:#eef0f2; color:#6c757d;">
                            <svg width="24" height="24" fill="none" stroke="currentColor" stroke-width="1.8" viewBox="0 0 24 24"><circle cx="12" cy="12" r="10"/><path d="M8 12.5l3 3 5-6"/></svg>
                        </div>
                        <div><p class="text-muted mb-1 small">Completed</p><h3 class="mb-0 fw-bold text-secondary"><asp:Label ID="lblCompleted" runat="server" Text="0"></asp:Label></h3></div>
                    </div>
                </div>
            </div>
            <div class="col-md-3 mb-3">
                <div class="card shadow-sm border-0 h-100">
                    <div class="card-body d-flex gap-3 align-items-center">
                        <div class="icon-circle" style="background:#fde8e8; color:#e76f51;">
                            <svg width="24" height="24" fill="none" stroke="currentColor" stroke-width="1.8" viewBox="0 0 24 24"><circle cx="12" cy="12" r="10"/><path d="M15 9l-6 6M9 9l6 6"/></svg>
                        </div>
                        <div><p class="text-muted mb-1 small">Cancelled</p><h3 class="mb-0 fw-bold text-danger"><asp:Label ID="lblCancelled" runat="server" Text="0"></asp:Label></h3></div>
                    </div>
                </div>
            </div>
        </div>

        <div class="row">

            <div class="col-md-3 mb-3">
                <div class="card shadow-sm border-0 mb-3">
                    <div class="card-body">
                        <asp:Calendar ID="calSchedule" runat="server" CssClass="schedule-calendar w-100" BorderStyle="None" ShowGridLines="False" DayNameFormat="FirstLetter" FirstDayOfWeek="Monday" OnSelectionChanged="calSchedule_SelectionChanged">
                            <TitleStyle BackColor="White" Font-Bold="True" ForeColor="#2B2B2B" />
                            <DayHeaderStyle ForeColor="#8A8A8A" Font-Bold="True" />
                            <DayStyle HorizontalAlign="Center" ForeColor="#444444" />
                            <OtherMonthDayStyle ForeColor="#CFCFCF" />
                            <SelectedDayStyle BackColor="#56CC9D" ForeColor="White" Font-Bold="True" />
                            <TodayDayStyle Font-Bold="True" />
                        </asp:Calendar>
                    </div>
                </div>

                <asp:Panel ID="pnlFilter" runat="server" CssClass="card shadow-sm border-0">
                    <div class="card-body">
                        <p class="fw-semibold small mb-2">Filters</p>
                        <label class="form-label small text-muted mb-1">Practitioner</label>
                        <asp:DropDownList ID="ddlPractitioner" runat="server" CssClass="form-select form-select-sm" AutoPostBack="True"></asp:DropDownList>
                    </div>
                </asp:Panel>

                <asp:Panel ID="pnlMarkUnavailable" runat="server" CssClass="card shadow-sm border-0 mt-3">
                    <div class="card-body">
                        <p class="fw-semibold small mb-1">Mark Unavailable</p>
                        <p class="small text-muted mb-2"><asp:Label ID="lblBlockDate" runat="server"></asp:Label></p>

                        <label class="form-label small text-muted mb-1">Reason</label>
                        <asp:DropDownList ID="ddlReason" runat="server" CssClass="form-select form-select-sm mb-2">
                            <asp:ListItem Value="" Text="Select a reason"></asp:ListItem>
                            <asp:ListItem>Emergency</asp:ListItem>
                            <asp:ListItem>Personal Matter</asp:ListItem>
                            <asp:ListItem>Leave</asp:ListItem>
                            <asp:ListItem>Dental Conference / Training</asp:ListItem>
                            <asp:ListItem>Meeting / Admin Work</asp:ListItem>
                            <asp:ListItem>Complex Surgery Preparation</asp:ListItem>
                            <asp:ListItem>Lunch Break</asp:ListItem>
                            <asp:ListItem>Other</asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox ID="txtReason" runat="server" CssClass="form-control form-control-sm mb-2" placeholder="If Other, type the reason"></asp:TextBox>

                        <label class="form-label small text-muted mb-1">Timeslot</label>
                        <asp:DropDownList ID="ddlTimeslot" runat="server" CssClass="form-select form-select-sm mb-2"></asp:DropDownList>

                        <asp:CheckBox ID="chkFullDay" runat="server" Text=" Full day" CssClass="small d-block mb-3" />

                        <asp:Panel ID="pnlConflict" runat="server" Visible="false" CssClass="alert alert-warning small p-2 mb-2">
                            <asp:Label ID="lblConflict" runat="server"></asp:Label>
                            <div class="d-flex gap-2 mt-2">
                                <asp:Button ID="btnConfirmBlock" runat="server" Text="Block and notify" CssClass="btn btn-sm btn-warning" OnClick="btnConfirmBlock_Click" />
                                <asp:Button ID="btnCancelBlock" runat="server" Text="Cancel" CssClass="btn btn-sm btn-outline-secondary" OnClick="btnCancelBlock_Click" />
                            </div>
                        </asp:Panel>

                        <asp:Button ID="btnMarkUnavailable" runat="server" Text="+ Mark Unavailable" CssClass="btn btn-primary btn-sm w-100" OnClick="btnMarkUnavailable_Click" />
                        <asp:Label ID="lblOverrideMsg" runat="server" CssClass="small mt-2 d-block"></asp:Label>

                        <asp:PlaceHolder ID="phMyOverrides" runat="server" Visible="false">
                            <hr />
                            <p class="fw-semibold small mb-1">Blocked on this date</p>
                            <asp:Repeater ID="rptMyOverrides" runat="server" OnItemCommand="rptMyOverrides_ItemCommand">
                                <ItemTemplate>
                                    <div class="d-flex justify-content-between align-items-center small border-bottom py-1">
                                        <span><%#: Eval("Label") %></span>
                                        <asp:LinkButton ID="btnRemove" runat="server" CommandName="Remove" CommandArgument='<%# Eval("Override_ID") %>' CssClass="text-danger small" OnClientClick="return confirm('Remove this unavailability?');">Remove</asp:LinkButton>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </asp:PlaceHolder>
                    </div>
                </asp:Panel>
            </div>

            <div class="col-md-9 mb-3">
                <div class="card shadow-sm border-0">
                    <div class="card-header bg-white d-flex justify-content-between align-items-center">
                        <span class="fw-semibold"><asp:Label ID="lblSelectedDate" runat="server"></asp:Label></span>
                        <span><asp:Literal ID="litOverrideBadges" runat="server"></asp:Literal></span>
                    </div>
                    <div class="table-responsive">
                        <table class="table mb-0 align-middle" style="table-layout:fixed;">
                            <thead>
                                <tr class="border-bottom">
                                    <th style="width:80px;"></th>
                                    <asp:Literal ID="litDoctorHeaders" runat="server"></asp:Literal>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Literal ID="litScheduleRows" runat="server"></asp:Literal>
                            </tbody>
                        </table>
                    </div>
                </div>
                <asp:Label ID="lblSearchInfo" runat="server" CssClass="small text-muted mt-3 d-block"></asp:Label>
            </div>

        </div>
    </div>
    </asp:PlaceHolder>

</asp:Content>