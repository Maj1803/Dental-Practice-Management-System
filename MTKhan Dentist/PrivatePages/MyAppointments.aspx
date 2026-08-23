<%@ Page Title="My Appointments" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="MyAppointments.aspx.cs"
    Inherits="MTKhan_Dentist.MyAppointments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        .hero-banner {
            background: #e8f5f0;
            text-align: center;
            padding: 3rem 2rem;
        }

        .pill-label {
            background: #56cc9d;
            color: #fff;
            font-size: 0.75rem;
            font-weight: 700;
            letter-spacing: 0.05em;
            padding: 6px 18px;
            border-radius: 999px;
            display: inline-block;
        }

        .appointment-table {
            background: white;
            border-radius: 12px;
            overflow: hidden;
        }

        .appointment-table th {
            background: #f1f8f5;
            color: #2b2b2b;
            font-weight: 600;
        }

        .appointment-table td,
        .appointment-table th {
            padding: 14px;
            vertical-align: middle;
        }
    </style>

    <a href="PatientDashboard.aspx" class="btn btn-outline-primary mb-4">
    ← Back to Dashboard
</a>

    <div class="container mt-4 mb-5">

        <div class="hero-banner rounded-4 mb-4">
            <span class="pill-label">PATIENT PORTAL</span>

            <h2 class="fw-bold mt-3 mb-2" style="color:#2b2b2b;">
                My Appointments
            </h2>

            <p class="mb-0 text-muted">
                View your upcoming and past dental appointments.
            </p>
        </div>


        
        <div class="card shadow-sm border-0 mb-4">

            <div class="card-body">

                <h5 class="fw-bold mb-3">
                    Upcoming Appointments
                </h5>

                <div class="table-responsive">

                    <table class="table appointment-table mb-0">

                        <thead>
                            <tr>
                                <th>Date</th>
                                <th>Time</th>
                                <th>Dentist</th>
                                <th>Appointment</th>
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

                                <td>
                                    <span class="badge bg-success">
                                        Scheduled
                                    </span>
                                </td>

                                <td>
                                    <button type="button"
                                            class="btn btn-sm btn-outline-primary rounded-pill"
                                            disabled>
                                        Reschedule
                                    </button>

                                    <button type="button"
                                            class="btn btn-sm btn-outline-danger rounded-pill"
                                            disabled>
                                        Cancel
                                    </button>
                                </td>

                            </tr>

                        </tbody>

                    </table>

                </div>

            </div>

        </div>


        <div class="card shadow-sm border-0">

            <div class="card-body">

                <h5 class="fw-bold mb-3">
                    Past Appointments
                </h5>

                <div class="table-responsive">

                    <table class="table appointment-table mb-0">

                        <thead>
                            <tr>
                                <th>Date</th>
                                <th>Time</th>
                                <th>Dentist</th>
                                <th>Appointment</th>
                                <th>Status</th>
                            </tr>
                        </thead>

                        <tbody>

                            <tr>

                                <td>14 Jun 2026</td>

                                <td>09:00</td>

                                <td>Dr. Khan</td>

                                <td>Filling Replacement</td>

                                <td>
                                    <span class="badge bg-secondary">
                                        Completed
                                    </span>
                                </td>

                            </tr>

                            <tr>

                                <td>02 Mar 2026</td>

                                <td>11:15</td>

                                <td>Dr. Khan</td>

                                <td>Routine Check-up</td>

                                <td>
                                    <span class="badge bg-danger">
                                        Cancelled
                                    </span>
                                </td>

                            </tr>

                        </tbody>

                    </table>

                </div>

            </div>

        </div>


        
        <p class="text-muted small mt-4">
            Note: This is a mock M3 screen using static appointment data.
            Reschedule and cancellation actions are displayed for demonstration
            and will be implemented in M4.
        </p>

    </div>

</asp:Content>