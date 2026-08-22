<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyAppointments.aspx.cs" Inherits="MTKhan_Dentist.MyAppointments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-4 mb-5">
        <div class="mb-4">
            <h2 class="mb-0">My Appointments</h2>
            <p class="text-muted mb-0">Patient view — appointment history (mock data)</p>
        </div>

        <div class="d-flex flex-column gap-3">

            <div class="card shadow-sm border-0">
                <div class="card-body d-flex justify-content-between align-items-center flex-wrap gap-2">
                    <div class="d-flex align-items-center gap-3">
                        <div class="bg-primary bg-opacity-25 text-primary rounded-circle d-flex align-items-center justify-content-center" style="width:48px;height:48px;font-weight:600;">28</div>
                        <div>
                            <p class="mb-0 fw-semibold">28 Aug 2026, 10:30 <span class="badge bg-success ms-1">Scheduled</span></p>
                            <p class="text-muted mb-0 small">Dr. Khan — Routine Check-up</p>
                        </div>
                    </div>
                    <div class="d-flex gap-2">
                        <button class="btn btn-sm btn-outline-primary rounded-pill" disabled>Reschedule</button>
                        <button class="btn btn-sm btn-outline-danger rounded-pill" disabled>Cancel</button>
                    </div>
                </div>
            </div>

            <div class="card shadow-sm border-0">
                <div class="card-body d-flex justify-content-between align-items-center flex-wrap gap-2">
                    <div class="d-flex align-items-center gap-3">
                        <div class="bg-secondary bg-opacity-25 text-secondary rounded-circle d-flex align-items-center justify-content-center" style="width:48px;height:48px;font-weight:600;">14</div>
                        <div>
                            <p class="mb-0 fw-semibold">14 Jun 2026, 09:00 <span class="badge bg-secondary ms-1">Completed</span></p>
                            <p class="text-muted mb-0 small">Dr. Khan — Filling Replacement</p>
                        </div>
                    </div>
                    <span class="text-muted small">No actions available</span>
                </div>
            </div>

            <div class="card shadow-sm border-0">
                <div class="card-body d-flex justify-content-between align-items-center flex-wrap gap-2">
                    <div class="d-flex align-items-center gap-3">
                        <div class="bg-danger bg-opacity-25 text-danger rounded-circle d-flex align-items-center justify-content-center" style="width:48px;height:48px;font-weight:600;">02</div>
                        <div>
                            <p class="mb-0 fw-semibold">02 Mar 2026, 11:15 <span class="badge bg-danger ms-1">Cancelled</span></p>
                            <p class="text-muted mb-0 small">Dr. Khan — Routine Check-up</p>
                        </div>
                    </div>
                    <span class="text-muted small">No actions available</span>
                </div>
            </div>

        </div>

        <p class="text-muted small mt-4">
            Note: This is a mock screen for M3 — appointment data shown is static placeholder content.
            Reschedule and cancel functionality will be implemented for M4.
        </p>
    </div>

</asp:Content>