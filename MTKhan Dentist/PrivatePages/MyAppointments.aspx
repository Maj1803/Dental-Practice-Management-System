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
        <asp:Repeater ID="rptUpcoming" runat="server">
            <ItemTemplate>
                <tr>
                    <td><%# Eval("Appointment_Date", "{0:dd MMM yyyy}") %></td>
                    <td><%# Eval("Time") %></td>
                    <td><%# Eval("Dentist") %></td>
                    <td><%# Eval("TreatmentName") %></td>
                    <td>
                        <span class='badge <%# Eval("StatusBadgeClass") %>'>
                            <%# Eval("Appointment_Status") %>
                        </span>
                    </td>
                    <td>
                        <button type="button" class="btn btn-sm btn-outline-primary rounded-pill" disabled>Reschedule</button>
                        <button type="button" class="btn btn-sm btn-outline-danger rounded-pill" disabled>Cancel</button>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </tbody>
</table>

<asp:Panel ID="pnlNoUpcoming" runat="server" Visible="false" CssClass="text-muted p-3">
    No upcoming appointments.
</asp:Panel>

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
        <asp:Repeater ID="rptPast" runat="server">
            <ItemTemplate>
                <tr>
                    <td><%# Eval("Appointment_Date", "{0:dd MMM yyyy}") %></td>
                    <td><%# Eval("Time") %></td>
                    <td><%# Eval("Dentist") %></td>
                    <td><%# Eval("TreatmentName") %></td>
                    <td>
                        <span class='badge <%# Eval("StatusBadgeClass") %>'>
                            <%# Eval("Appointment_Status") %>
                        </span>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </tbody>
</table>

<asp:Panel ID="pnlNoPast" runat="server" Visible="false" CssClass="text-muted p-3">
    No past appointments.
</asp:Panel>

                </div>

            </div>

        </div>


        
        

    </div>

</asp:Content>