<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="MTKhan_Dentist.Reports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        .hero-banner { background: #e8f5f0; text-align: center; padding: 3rem 2rem; }
        .pill-label { background: #56cc9d; color: #fff; font-size: 0.75rem; font-weight: 700; letter-spacing: 0.05em; padding: 6px 18px; border-radius: 999px; display: inline-block; }
        .icon-circle { width: 52px; height: 52px; border-radius: 50%; display: flex; align-items: center; justify-content: center; flex-shrink: 0; }
        .rank-badge { width: 28px; height: 28px; border-radius: 50%; display: flex; align-items: center; justify-content: center; font-size: 0.8rem; font-weight: 700; flex-shrink: 0; }
        .report-tile { border: 1px solid #eee; border-radius: 12px; padding: 16px; text-align: center; }
    </style>

    <div class="container mt-4 mb-5">

        <div class="hero-banner rounded-4 mb-4">
            <span class="pill-label mb-2">PRACTICE REPORTS</span>
            <h2 class="fw-bold mt-3 mb-2" style="color:#2b2b2b;">Reports Overview</h2>
            <p class="mb-0 text-muted">Monthly performance summary for Dr MT Khan Dental Practice.</p>
        </div>

        <div class="row mb-4">
            <div class="col-md-4 mb-3">
                <div class="card shadow-sm border-0 h-100">
                    <div class="card-body d-flex gap-3 align-items-center">
                        <div class="icon-circle bg-primary bg-opacity-10 text-primary">
                            <svg width="22" height="22" fill="none" stroke="currentColor" stroke-width="1.8" viewBox="0 0 24 24">
                                <path d="M17 21v-2a4 4 0 0 0-4-4H5a4 4 0 0 0-4 4v2"/><circle cx="9" cy="7" r="4"/>
                            </svg>
                        </div>
                        <div>
                            <p class="text-muted mb-1 small">Patient Volume (Month)</p>
                            <h3 class="mb-0 fw-bold">312</h3>
                            <span class="text-success small">▲ 12% from last month</span>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-4 mb-3">
                <div class="card shadow-sm border-0 h-100">
                    <div class="card-body d-flex gap-3 align-items-center">
                        <div class="icon-circle bg-success bg-opacity-10 text-success">
                            <svg width="22" height="22" fill="none" stroke="currentColor" stroke-width="1.8" viewBox="0 0 24 24">
                                <path d="M12 1v22M17 5H9.5a3.5 3.5 0 0 0 0 7h5a3.5 3.5 0 0 1 0 7H6"/>
                            </svg>
                        </div>
                        <div>
                            <p class="text-muted mb-1 small">Revenue (Month)</p>
                            <h3 class="mb-0 fw-bold">R184,600</h3>
                            <span class="text-success small">▲ 8% from last month</span>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-4 mb-3">
                <div class="card shadow-sm border-0 h-100">
                    <div class="card-body d-flex gap-3 align-items-center">
                        <div class="icon-circle bg-secondary bg-opacity-10 text-secondary">
                            <svg width="22" height="22" fill="none" stroke="currentColor" stroke-width="1.8" viewBox="0 0 24 24">
                                <circle cx="12" cy="12" r="9"/><path d="M12 7v5l3 2"/>
                            </svg>
                        </div>
                        <div>
                            <p class="text-muted mb-1 small">Most Popular Code</p>
                            <h3 class="mb-0 fw-bold">Check-up</h3>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-6 mb-3">
                <div class="card shadow-sm border-0 h-100">
                    <div class="card-header bg-white fw-semibold">Top Treatments This Month</div>
                    <ul class="list-group list-group-flush">
                        <li class="list-group-item d-flex align-items-center gap-3">
                            <div class="rank-badge bg-secondary bg-opacity-25 text-secondary">1</div>
                            <span class="flex-grow-1">Routine Check-up</span>
                            <span class="fw-semibold">128</span>
                        </li>
                        <li class="list-group-item d-flex align-items-center gap-3">
                            <div class="rank-badge bg-primary bg-opacity-10 text-primary">2</div>
                            <span class="flex-grow-1">Filling</span>
                            <span class="fw-semibold">76</span>
                        </li>
                        <li class="list-group-item d-flex align-items-center gap-3">
                            <div class="rank-badge bg-danger bg-opacity-10 text-danger">3</div>
                            <span class="flex-grow-1">Extraction</span>
                            <span class="fw-semibold">34</span>
                        </li>
                    </ul>
                </div>
            </div>

            <div class="col-md-6 mb-3">
                <div class="card shadow-sm border-0 h-100">
                    <div class="card-header bg-white fw-semibold">Crystal Reports Suite</div>
                    <div class="card-body">
                        <div class="row g-2">
                            <div class="col-4">
                                <div class="report-tile">
                                    <div class="icon-circle bg-primary bg-opacity-10 text-primary mx-auto mb-2">
                                        <svg width="20" height="20" fill="none" stroke="currentColor" stroke-width="1.8" viewBox="0 0 24 24"><path d="M12 1v22M17 5H9.5a3.5 3.5 0 0 0 0 7h5a3.5 3.5 0 0 1 0 7H6"/></svg>
                                    </div>
                                    <p class="small mb-0">Revenue</p>
                                </div>
                            </div>
                            <div class="col-4">
                                <div class="report-tile">
                                    <div class="icon-circle bg-success bg-opacity-10 text-success mx-auto mb-2">
                                        <svg width="20" height="20" fill="none" stroke="currentColor" stroke-width="1.8" viewBox="0 0 24 24"><rect x="3" y="4" width="18" height="17" rx="2"/><path d="M16 2v4M8 2v4M3 9h18"/></svg>
                                    </div>
                                    <p class="small mb-0">Treatments</p>
                                </div>
                            </div>
                            <div class="col-4">
                                <div class="report-tile">
                                    <div class="icon-circle bg-secondary bg-opacity-10 text-secondary mx-auto mb-2">
                                        <svg width="20" height="20" fill="none" stroke="currentColor" stroke-width="1.8" viewBox="0 0 24 24"><path d="M17 21v-2a4 4 0 0 0-4-4H5a4 4 0 0 0-4 4v2"/><circle cx="9" cy="7" r="4"/></svg>
                                    </div>
                                    <p class="small mb-0">Patients</p>
                                </div>
                            </div>
                        </div>
                        <button class="btn btn-outline-primary btn-sm w-100 mt-3" disabled>Open Full Suite</button>
                    </div>
                </div>
            </div>
        </div>

        <p class="text-muted small mt-3">
            Note: This is a mock screen for M3 — figures shown are static placeholder content.
            Live report generation via Crystal Reports will be implemented for M4.
        </p>
    </div>

</asp:Content>