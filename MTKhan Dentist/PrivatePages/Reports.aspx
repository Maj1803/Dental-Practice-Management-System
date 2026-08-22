<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="MTKhan_Dentist.Reports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-4 mb-5">
        <div class="mb-4">
            <h2 class="mb-0">Reports</h2>
            <p class="text-muted mb-0">Staff view — business intelligence overview (mock data)</p>
        </div>

        <div class="row mb-4">
            <div class="col-md-4 mb-3">
                <div class="card shadow-sm border-0 h-100">
                    <div class="card-body">
                        <p class="text-muted mb-1 small">Patient Volume (Month)</p>
                        <h3 class="mb-1">312</h3>
                        <span class="text-success small">▲ 12% from last month</span>
                    </div>
                </div>
            </div>
            <div class="col-md-4 mb-3">
                <div class="card shadow-sm border-0 h-100">
                    <div class="card-body">
                        <p class="text-muted mb-1 small">Revenue (Month)</p>
                        <h3 class="mb-1">R184,600</h3>
                        <span class="text-success small">▲ 8% from last month</span>
                    </div>
                </div>
            </div>
            <div class="col-md-4 mb-3">
                <div class="card shadow-sm border-0 h-100">
                    <div class="card-body">
                        <p class="text-muted mb-1 small">Most Popular Code</p>
                        <h3 class="mb-0">Check-up</h3>
                    </div>
                </div>
            </div>
        </div>

        <div class="card shadow-sm border-0 mb-4">
            <div class="card-header bg-white fw-semibold">Top Treatments This Month</div>
            <div class="card-body">
                <div class="mb-3">
                    <div class="d-flex justify-content-between small mb-1"><span>Routine Check-up</span><span>128</span></div>
                    <div class="progress" style="height:8px;"><div class="progress-bar bg-primary" style="width:80%"></div></div>
                </div>
                <div class="mb-3">
                    <div class="d-flex justify-content-between small mb-1"><span>Filling</span><span>76</span></div>
                    <div class="progress" style="height:8px;"><div class="progress-bar bg-success" style="width:48%"></div></div>
                </div>
                <div>
                    <div class="d-flex justify-content-between small mb-1"><span>Extraction</span><span>34</span></div>
                    <div class="progress" style="height:8px;"><div class="progress-bar bg-warning" style="width:22%"></div></div>
                </div>
            </div>
        </div>

        <div class="card shadow-sm border-0">
            <div class="card-header bg-white fw-semibold">Crystal Reports Suite</div>
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