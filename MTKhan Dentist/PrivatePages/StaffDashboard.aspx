
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StaffDashboard.aspx.cs" Inherits="MTKhan_Dentist.StaffDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .hero-banner { background: #e8f5f0; text-align: center; padding: 2rem 1.5rem; }
        .pill-label { background: #56cc9d; color: #fff; font-size: 0.75rem; font-weight: 700; letter-spacing: 0.05em; padding: 6px 18px; border-radius: 999px; display: inline-block; }
        .role-badge { background: #eafaff; color: #1597ad; font-size: 0.8rem; font-weight: 600; padding: 7px 16px; border-radius: 999px; display: inline-block; border: 1px solid #98e9fb; }
        .icon-circle { width: 52px; height: 52px; border-radius: 50%; display: flex; align-items: center; justify-content: center; flex-shrink: 0; }
    </style>

    <div class="container mt-4 mb-5">
        <div class="hero-banner rounded-4 mb-4">
            <span class="pill-label mb-2">STAFF PORTAL</span>
            <h2 class="fw-bold mt-3 mb-2" style="color:#2b2b2b;"><asp:Label ID="lblWelcome" runat="server" Text="Welcome back"></asp:Label></h2>
            <span class="role-badge mt-1"><asp:Label ID="lblRole" runat="server" Text="Receptionist"></asp:Label></span>
            <p class="mb-0 mt-3 text-muted">Here's an overview of today's appointments and practice activity.</p>
        </div>

        <div class="row mb-4">
            <div class="col-md-4 mb-3">
                <div class="card shadow-sm border-0 h-100">
                    <div class="card-body d-flex gap-3 align-items-center">
                        <div class="icon-circle" style="background:#e6f4f1; color:#2a9d8f;">
                            <svg width="24" height="24" fill="none" stroke="currentColor" stroke-width="1.8" viewBox="0 0 24 24"><path d="M17 21v-2a4 4 0 0 0-4-4H5a4 4 0 0 0-4 4v2"/><circle cx="9" cy="7" r="4"/><path d="M23 21v-2a4 4 0 0 0-3-3.87"/><path d="M16 3.13a4 4 0 0 1 0 7.75"/></svg>
                        </div>
                        <div><p class="text-muted mb-1 small">Today's Patients</p><h3 class="mb-0 fw-bold"><asp:Label ID="lblTodayPatients" runat="server" Text="0"></asp:Label></h3></div>
                    </div>
                </div>
            </div>

            <div class="col-md-4 mb-3">
                <div class="card shadow-sm border-0 h-100">
                    <div class="card-body d-flex gap-3 align-items-center">
                        <div class="icon-circle" style="background:#e6f4f1; color:#2a9d8f;">
                            <svg width="24" height="24" fill="none" stroke="currentColor" stroke-width="1.8" viewBox="0 0 24 24"><rect x="3" y="4" width="18" height="18" rx="2"/><path d="M16 2v4M8 2v4M3 10h18"/></svg>
                        </div>
                        <div><p class="text-muted mb-1 small">Appointments Remaining</p><h3 class="mb-0 fw-bold" style="color:#2a9d8f;"><asp:Label ID="lblRemaining" runat="server" Text="0"></asp:Label></h3></div>
                    </div>
                </div>
            </div>

            <div class="col-md-4 mb-3">
                <div class="card shadow-sm border-0 h-100">
                    <div class="card-body d-flex gap-3 align-items-center">
                        <div class="icon-circle" style="background:#fde8e8; color:#e76f51;">
                            <svg width="24" height="24" fill="none" stroke="currentColor" stroke-width="1.8" viewBox="0 0 24 24"><circle cx="12" cy="12" r="10"/><path d="M15 9l-6 6M9 9l6 6"/></svg>
                        </div>
                        <div><p class="text-muted mb-1 small">Cancellations Today</p><h3 class="mb-0 fw-bold" style="color:#e76f51;"><asp:Label ID="lblCancellations" runat="server" Text="0"></asp:Label></h3></div>
                    </div>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-8 mb-3">
                <div class="card shadow-sm border-0">
                    <div class="card-header bg-white fw-semibold">Today's Appointments</div>
                    <div class="card-body">
                        <div class="row g-2 align-items-end">
                            <div class="col-md-3">
                                <label class="form-label small text-muted mb-1">Patient Name</label>
                                <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" placeholder="e.g. Smith"></asp:TextBox>
                            </div>

                            <div class="col-md-2">
                                <label class="form-label small text-muted mb-1">Status</label>
                                <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="btnSearch_Click">
                                    <asp:ListItem Text="All Status" Value=""></asp:ListItem>
                                    <asp:ListItem Text="Scheduled" Value="Scheduled"></asp:ListItem>
                                    <asp:ListItem Text="Completed" Value="Completed"></asp:ListItem>
                                    <asp:ListItem Text="Cancelled" Value="Cancelled"></asp:ListItem>
                                </asp:DropDownList>
                            </div>

                            <div class="col-md-3" id="divDentistFilter" runat="server">
                                <label class="form-label small text-muted mb-1">Dentist</label>
                                <asp:DropDownList ID="ddlDentist" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="btnSearch_Click">
                                    <asp:ListItem Text="All Dentists" Value=""></asp:ListItem>
                                </asp:DropDownList>
                            </div>

                            <div class="col-md-2">
                                <label class="form-label small text-muted mb-1">&nbsp;</label>
                                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary w-100" OnClick="btnSearch_Click" />
                            </div>

                            <div class="col-md-2">
                                <label class="form-label small text-muted mb-1">&nbsp;</label>
                                <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-outline-secondary w-100" OnClick="btnClear_Click" />
                            </div>
                        </div>

                        <asp:Label ID="lblSearchInfo" runat="server" CssClass="small text-muted mt-2 d-block"></asp:Label>
                    </div>

                    <asp:GridView ID="GVToday" runat="server" AutoGenerateColumns="False" CssClass="table mb-0" GridLines="None">
                        <Columns>
                            <asp:BoundField DataField="Patient" HeaderText="Patient" />
                            <asp:BoundField DataField="Dentist" HeaderText="Dentist" />
                            <asp:BoundField DataField="Appointment_Date" HeaderText="Date" DataFormatString="{0:dd MMM yyyy}" />
                            <asp:BoundField DataField="Slot_Start_Time" HeaderText="Time" />
                            <asp:BoundField DataField="Appointment_Status" HeaderText="Status" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>

            <!-- Quick Actions -->
            <div class="col-md-4 mb-3">
                <div class="card shadow-sm border-0">
                    <div class="card-header bg-white fw-semibold">Quick Actions</div>
                    <div class="card-body d-flex flex-column gap-2">
                        <a href="ManageSchedule.aspx" class="btn btn-primary">Manage Schedule</a>

                        <a href="StaffMessages.aspx" class="btn btn-success">Message Board</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
