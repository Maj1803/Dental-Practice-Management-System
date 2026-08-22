<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StaffDashboard.aspx.cs" Inherits="MTKhan_Dentist.StaffDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-4 mb-5">
        <div class="mb-4">
            <h2 class="mb-0">Staff Dashboard</h2>
            <p class="text-muted mb-0">Staff view — daily operations overview (mock data)</p>
        </div>

        <div class="row mb-4">
            <div class="col-md-4 mb-3">
                <div class="card shadow-sm border-0 h-100">
                    <div class="card-body">
                        <p class="text-muted mb-1 small">Today's Patients</p>
                        <h3 class="mb-0">14</h3>
                    </div>
                </div>
            </div>
            <div class="col-md-4 mb-3">
                <div class="card shadow-sm border-0 h-100">
                    <div class="card-body">
                        <p class="text-muted mb-1 small">Appointments Remaining</p>
                        <h3 class="mb-0 text-success">6</h3>
                    </div>
                </div>
            </div>
            <div class="col-md-4 mb-3">
                <div class="card shadow-sm border-0 h-100">
                    <div class="card-body">
                        <p class="text-muted mb-1 small">Cancellations Today</p>
                        <h3 class="mb-0 text-danger">1</h3>
                    </div>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-7 mb-3">
                <div class="card shadow-sm border-0">
                    <div class="card-header bg-white fw-semibold">Today's Appointments</div>
                    <ul class="list-group list-group-flush">
                        <li class="list-group-item d-flex justify-content-between align-items-center">
                            <span>Thabo Mokoena — Check-up</span>
                            <span class="badge bg-success">08:00</span>
                        </li>
                        <li class="list-group-item d-flex justify-content-between align-items-center">
                            <span>Priya Naidoo — Filling</span>
                            <span class="badge bg-success">09:00</span>
                        </li>
                        <li class="list-group-item d-flex justify-content-between align-items-center">
                            <span>Sipho Dlamini — Root Canal</span>
                            <span class="badge bg-warning text-dark">10:00 (Pending)</span>
                        </li>
                        <li class="list-group-item d-flex justify-content-between align-items-center">
                            <span>Nomvula Zulu — Check-up</span>
                            <span class="badge bg-warning text-dark">14:00 (Pending)</span>
                        </li>
                    </ul>
                </div>
            </div>
            <div class="col-md-5 mb-3">
                <div class="card shadow-sm border-0">
                    <div class="card-header bg-white fw-semibold">Quick Actions</div>
                    <div class="card-body d-flex flex-column gap-2">
                        <a href="ManageSchedule.aspx" class="btn btn-primary">Manage Schedule</a>
                        <a href="Reports.aspx" class="btn btn-outline-primary">View Reports</a>
                    </div>
                </div>
            </div>
        </div>

        <p class="text-muted small mt-3">
            Note: This is a mock screen for M3 — statistics shown are static placeholder content.
            Role-restricted access will be implemented for M4.
        </p>
    </div>

</asp:Content>