<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PatientDashboard.aspx.cs" Inherits="MTKhan_Dentist.PatientDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-4 mb-5">
        <div class="mb-4">
            <h2 class="mb-0">Patient Dashboard</h2>
            <p class="text-muted mb-0">Patient view — account overview (mock data)</p>
        </div>

        <div class="card shadow-sm border-0 mb-4">
            <div class="card-body">
                <h4 class="mb-1">Welcome back, Jane Doe</h4>
                <p class="text-muted mb-0">Patient since March 2024 · Account in good standing</p>
            </div>
        </div>

        <div class="row mb-4">
            <div class="col-md-6 mb-3">
                <div class="card shadow-sm border-0 h-100">
                    <div class="card-body d-flex align-items-center gap-3">
                        <div class="bg-success bg-opacity-25 text-success rounded-circle d-flex align-items-center justify-content-center" style="width:48px;height:48px;font-weight:600;">28</div>
                        <div>
                            <p class="text-muted mb-1 small">Next Appointment</p>
                            <p class="mb-0 fw-semibold">28 Aug 2026, 10:30</p>
                            <p class="mb-0 small text-muted">Dr. Khan — Routine Check-up</p>
                            <span class="badge bg-success mt-1">Confirmed</span>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-6 mb-3">
                <div class="card shadow-sm border-0 h-100">
                    <div class="card-body">
                        <p class="text-muted mb-1 small">Total Visits</p>
                        <h3 class="mb-0">6</h3>
                    </div>
                </div>
            </div>
        </div>

        <a href="MyAppointments.aspx" class="btn btn-primary">View Appointment Schedule</a>

        <p class="text-muted small mt-4">
            Note: This is a mock screen for M3 — patient data shown is static placeholder content.
            Full account functionality will be implemented for M4.
        </p>
    </div>

</asp:Content>