<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageSchedule.aspx.cs" Inherits="MTKhan_Dentist.ManageSchedule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-4 mb-5">
        <div class="d-flex justify-content-between align-items-center mb-3">
            <div>
                <h2 class="mb-0">Manage Schedule</h2>
                <p class="text-muted mb-0">Staff view — appointment schedule overview (mock data)</p>
            </div>
            <button class="btn btn-primary" disabled>+ Mark Unavailable</button>
        </div>

        <div class="row mb-4">
            <div class="col-md-3 mb-3">
                <div class="card text-center h-100 border-primary">
                    <div class="card-body">
                        <h6 class="text-muted">Today's Appointments</h6>
                        <h3 class="mb-0">8</h3>
                    </div>
                </div>
            </div>
            <div class="col-md-3 mb-3">
                <div class="card text-center h-100 border-success">
                    <div class="card-body">
                        <h6 class="text-muted">Confirmed</h6>
                        <h3 class="mb-0 text-success">5</h3>
                    </div>
                </div>
            </div>
            <div class="col-md-3 mb-3">
                <div class="card text-center h-100 border-warning">
                    <div class="card-body">
                        <h6 class="text-muted">Pending</h6>
                        <h3 class="mb-0 text-warning">2</h3>
                    </div>
                </div>
            </div>
            <div class="col-md-3 mb-3">
                <div class="card text-center h-100 border-danger">
                    <div class="card-body">
                        <h6 class="text-muted">Cancelled</h6>
                        <h3 class="mb-0 text-danger">1</h3>
                    </div>
                </div>
            </div>
        </div>

        <div class="d-flex align-items-center gap-2 mb-3 flex-wrap">
            <label class="form-label mb-0">Practitioner:</label>
            <select class="form-select" style="max-width:180px;" disabled>
                <option>All Practitioners</option>
                <option>Dr. Khan</option>
                <option>Dr. Naidoo</option>
            </select>
            <label class="form-label mb-0">Date:</label>
            <input type="date" class="form-control" style="max-width:180px;" value="2026-08-21" disabled>
        </div>

        <div class="card border-primary shadow-sm">
            <div class="card-header bg-primary text-white d-flex justify-content-between align-items-center">
                <span>Today's Schedule — 21 August 2026</span>
            </div>
            <div class="px-3 pt-3">
                <div class="d-flex gap-3 flex-wrap mb-3">
                    <span class="badge bg-success">Dr. Khan — Available</span>
                    <span class="badge bg-secondary">Dr. Naidoo — On Leave (Override)</span>
                </div>
            </div>
            <div class="table-responsive">
                <table class="table table-bordered mb-0 text-center align-middle">
                    <thead class="table-primary">
                        <tr>
                            <th style="width:100px;">Time</th>
                            <th>Dr. Khan</th>
                            <th>Dr. Naidoo</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td class="fw-bold">08:00</td>
                            <td class="bg-success bg-opacity-25">Thabo Mokoena<br><small class="text-muted">Check-up</small></td>
                            <td class="bg-light text-muted">—</td>
                        </tr>
                        <tr>
                            <td class="fw-bold">09:00</td>
                            <td class="bg-success bg-opacity-25">Priya Naidoo<br><small class="text-muted">Filling</small></td>
                            <td class="bg-light text-muted">—</td>
                        </tr>
                        <tr>
                            <td class="fw-bold">10:00</td>
                            <td class="bg-light text-muted">—</td>
                            <td class="bg-warning bg-opacity-25">Sipho Dlamini<br><small class="text-muted">Root Canal (Pending)</small></td>
                        </tr>
                        <tr>
                            <td class="fw-bold">11:00</td>
                            <td class="bg-success bg-opacity-25">Lerato Mahlangu<br><small class="text-muted">Cleaning</small></td>
                            <td class="bg-light text-muted">—</td>
                        </tr>
                        <tr>
                            <td class="fw-bold">13:00</td>
                            <td class="bg-light text-muted">—</td>
                            <td class="bg-danger bg-opacity-25">John van der Merwe<br><small class="text-muted">Extraction (Cancelled)</small></td>
                        </tr>
                        <tr>
                            <td class="fw-bold">14:00</td>
                            <td class="bg-warning bg-opacity-25">Nomvula Zulu<br><small class="text-muted">Check-up (Pending)</small></td>
                            <td class="bg-light text-muted">—</td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>

        <p class="text-muted small mt-3">
            Note: This is a mock screen for M3 — appointment data shown is static placeholder content.
            Full CRUD functionality (add/edit/cancel appointments) will be implemented for M4.
        </p>
    </div>

</asp:Content>