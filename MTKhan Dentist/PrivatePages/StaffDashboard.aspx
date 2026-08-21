<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StaffDashboard.aspx.cs" Inherits="MTKhan_Dentist.StaffDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-4 mb-5">
        <div class="mb-3">
            <h2 class="mb-0">Staff Dashboard</h2>
            <p class="text-muted mb-0">Staff view — daily operations overview (mock data)</p>
        </div>

        <div class="row mb-4">
            <div class="col-md-4 mb-3">
                <div class="card text-center h-100 border-primary">
                    <div class="card-body">
                        <h6 class="text-muted">Today's Patients</h6>
                        <h3 class="mb-0">14</h3>
                    </div>
                </div>
            </div>
            <div class="col-md-4 mb-3">
                <div class="card text-center h-100 border-success">
                    <div class="card-body">
                        <h6 class="text-muted">Appointments Remaining</h6>
                        <h3 class="mb-0 text-success">6</h3>
                    </div>
                </div>
            </div>
            <div class="col-md-4 mb-3">
                <div class="card text-center h-100 border-warning">
                    <div class="card-body">
                        <h6 class="text-muted">Cancellations</h6>
                        <h3 class="mb-0 text-warning">1</h3>
                    </div>
                </div>
            </div>
        </div>

        <div class="card border-primary shadow-sm mb-3">
            <div class="card-header bg-primary text-white">Staff Menu</div>
            <div class="list-group list-group-flush">
                <a href="ManageSchedule.aspx" class="list-group-item list-group-item-action">Manage Schedule</a>
                <a href="Reports.aspx" class="list-group-item list-group-item-action">Reports</a>
            </div>
        </div>

        <p class="text-muted small mt-3">
            Note: This is a mock screen for M3 — statistics shown are static placeholder content.
            Role-restricted access will be implemented for M4.
        </p>
    </div>

</asp:Content>