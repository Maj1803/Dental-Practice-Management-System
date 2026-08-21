<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="MTKhan_Dentist.Reports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-4 mb-5">
        <div class="mb-3">
            <h2 class="mb-0">Reports</h2>
            <p class="text-muted mb-0">Staff view — business intelligence overview (mock data)</p>
        </div>

        <div class="row mb-4">
            <div class="col-md-4 mb-3">
                <div class="card text-center h-100 border-primary">
                    <div class="card-body">
                        <h6 class="text-muted">Patient Volume (Month)</h6>
                        <h3 class="mb-0">312</h3>
                    </div>
                </div>
            </div>
            <div class="col-md-4 mb-3">
                <div class="card text-center h-100 border-success">
                    <div class="card-body">
                        <h6 class="text-muted">Revenue (Month)</h6>
                        <h3 class="mb-0 text-success">R184,600</h3>
                    </div>
                </div>
            </div>
            <div class="col-md-4 mb-3">
                <div class="card text-center h-100 border-primary">
                    <div class="card-body">
                        <h6 class="text-muted">Most Popular Code</h6>
                        <h3 class="mb-0">Check-up</h3>
                    </div>
                </div>
            </div>
        </div>

        <div class="card border-primary shadow-sm">
            <div class="card-header bg-primary text-white">Crystal Reports Suite</div>
            <div class="list-group list-group-flush">
                <button class="list-group-item list-group-item-action" disabled>Revenue Report</button>
                <button class="list-group-item list-group-item-action" disabled>Treatment Popularity Report</button>
                <button class="list-group-item list-group-item-action" disabled>Patient Demographics Report</button>
            </div>
        </div>

        <p class="text-muted small mt-3">
            Note: This is a mock screen for M3 — figures shown are static placeholder content.
            Live report generation via Crystal Reports will be implemented for M4.
        </p>
    </div>

</asp:Content>