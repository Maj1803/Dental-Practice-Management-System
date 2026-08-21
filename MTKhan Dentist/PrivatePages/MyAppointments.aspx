<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyAppointments.aspx.cs" Inherits="MTKhan_Dentist.MyAppointments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-4 mb-5">
        <div class="mb-3">
            <h2 class="mb-0">My Appointments</h2>
            <p class="text-muted mb-0">Patient view — appointment history (mock data)</p>
        </div>

        <div class="table-responsive">
            <table class="table table-bordered align-middle">
                <thead class="table-primary">
                    <tr>
                        <th>Date</th>
                        <th>Time</th>
                        <th>Dentist</th>
                        <th>Treatment</th>
                        <th>Status</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>28 Aug 2026</td>
                        <td>10:30</td>
                        <td>Dr. Khan</td>
                        <td>Routine Check-up</td>
                        <td><span class="badge bg-success">Confirmed</span></td>
                        <td>
                            <button class="btn btn-sm btn-outline-primary" disabled>Reschedule</button>
                            <button class="btn btn-sm btn-outline-danger" disabled>Cancel</button>
                        </td>
                    </tr>
                    <tr>
                        <td>14 Jun 2026</td>
                        <td>09:00</td>
                        <td>Dr. Khan</td>
                        <td>Filling Replacement</td>
                        <td><span class="badge bg-secondary">Completed</span></td>
                        <td class="text-muted">—</td>
                    </tr>
                    <tr>
                        <td>02 Mar 2026</td>
                        <td>11:15</td>
                        <td>Dr. Khan</td>
                        <td>Routine Check-up</td>
                        <td><span class="badge bg-secondary">Completed</span></td>
                        <td class="text-muted">—</td>
                    </tr>
                </tbody>
            </table>
        </div>

        <p class="text-muted small mt-3">
            Note: This is a mock screen for M3 — appointment data shown is static placeholder content.
            Reschedule and cancel functionality will be implemented for M4.
        </p>
    </div>

</asp:Content>