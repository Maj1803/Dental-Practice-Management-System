<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageSchedule.aspx.cs" Inherits="MTKhan_Dentist.ManageSchedule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        .hero-banner { background: #e8f5f0; text-align: center; padding: 3rem 2rem; }
        .pill-label { background: #56cc9d; color: #fff; font-size: 0.75rem; font-weight: 700; letter-spacing: 0.05em; padding: 6px 18px; border-radius: 999px; display: inline-block; }
        .mini-cal { width: 100%; border-collapse: collapse; font-size: 0.8rem; }
        .mini-cal th { color: #8a8a8a; font-weight: 600; padding: 4px 0; }
        .mini-cal td { text-align: center; padding: 6px 0; color: #444; }
        .mini-cal td.muted { color: #cfcfcf; }
        .mini-cal td.selected { background: #56cc9d; color: #fff; border-radius: 50%; font-weight: 700; }
        .view-toggle .btn { border-radius: 999px; }
        .doctor-header { display: flex; align-items: center; gap: 8px; padding: 10px; }
        .doctor-avatar { width: 30px; height: 30px; border-radius: 50%; display: flex; align-items: center; justify-content: center; font-size: 0.75rem; font-weight: 700; color: #fff; flex-shrink: 0; }
        .appt-block { border-radius: 8px; padding: 8px 10px; margin: 4px 0; font-size: 0.8rem; }
    </style>

    <a href="StaffDashboard.aspx" class="btn btn-outline-primary mb-4">
    ← Back to Dashboard
</a>

    <div class="container mt-4 mb-5">

        <div class="hero-banner rounded-4 mb-4">
            <span class="pill-label mb-2">STAFF PORTAL</span>
            <h2 class="fw-bold mt-3 mb-2" style="color:#2b2b2b;">Manage Schedule</h2>
            <p class="mb-0 text-muted">Appointment schedule and practitioner availability overview.</p>
        </div>

        <div class="row mb-4">
            <div class="col-md-3 mb-3">
                <div class="card shadow-sm border-0 h-100">
                    <div class="card-body">
                        <p class="text-muted mb-1 small">Today's Appointments</p>
                        <h3 class="mb-0 fw-bold">6</h3>
                    </div>
                </div>
            </div>
            <div class="col-md-3 mb-3">
                <div class="card shadow-sm border-0 h-100">
                    <div class="card-body">
                        <p class="text-muted mb-1 small">Scheduled</p>
                        <h3 class="mb-0 fw-bold text-success">3</h3>
                    </div>
                </div>
            </div>
            <div class="col-md-3 mb-3">
                <div class="card shadow-sm border-0 h-100">
                    <div class="card-body">
                        <p class="text-muted mb-1 small">Completed</p>
                        <h3 class="mb-0 fw-bold text-secondary">2</h3>
                    </div>
                </div>
            </div>
            <div class="col-md-3 mb-3">
                <div class="card shadow-sm border-0 h-100">
                    <div class="card-body">
                        <p class="text-muted mb-1 small">Cancelled</p>
                        <h3 class="mb-0 fw-bold text-danger">1</h3>
                    </div>
                </div>
            </div>
        </div>

        <div class="row">

            <div class="col-md-3 mb-3">
                <div class="card shadow-sm border-0 mb-3">
                    <div class="card-body">
                        <div class="d-flex justify-content-between align-items-center mb-2">
                            <span class="fw-semibold small">August 2026</span>
                        </div>
                        <table class="mini-cal">
                            <thead><tr><th>M</th><th>T</th><th>W</th><th>T</th><th>F</th><th>S</th><th>S</th></tr></thead>
                            <tbody>
                                <tr><td class="muted">27</td><td class="muted">28</td><td class="muted">29</td><td class="muted">30</td><td class="muted">31</td><td>1</td><td>2</td></tr>
                                <tr><td>3</td><td>4</td><td>5</td><td>6</td><td>7</td><td>8</td><td>9</td></tr>
                                <tr><td>10</td><td>11</td><td>12</td><td>13</td><td>14</td><td>15</td><td>16</td></tr>
                                <tr><td>17</td><td>18</td><td>19</td><td>20</td><td class="selected">21</td><td>22</td><td>23</td></tr>
                                <tr><td>24</td><td>25</td><td>26</td><td>27</td><td>28</td><td>29</td><td>30</td></tr>
                            </tbody>
                        </table>
                    </div>
                </div>

                <div class="card shadow-sm border-0">
                    <div class="card-body">
                        <p class="fw-semibold small mb-2">Filters</p>
                        <label class="form-label small text-muted mb-1">Practitioner</label>
                        <select class="form-select form-select-sm mb-3" disabled>
                            <option>All Practitioners</option>
                            <option>Dr. Khan</option>
                            <option>Dr. Naidoo</option>
                        </select>
                        <label class="form-label small text-muted mb-1">View</label>
                        <div class="d-flex gap-2 view-toggle">
                            <button class="btn btn-sm btn-primary" disabled>Day</button>
                            <button class="btn btn-sm btn-outline-secondary" disabled>Week</button>
                            <button class="btn btn-sm btn-outline-secondary" disabled>Month</button>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-md-9 mb-3">
                <div class="card shadow-sm border-0">
                    <div class="card-header bg-white d-flex justify-content-between align-items-center">
                        <span class="fw-semibold">Friday, 21 August 2026</span>
                        <span class="badge bg-secondary">Dr. Naidoo — On Leave (Override)</span>
                    </div>
                    <div class="table-responsive">
                        <table class="table mb-0 align-middle" style="table-layout:fixed;">
                            <thead>
                                <tr class="border-bottom">
                                    <th style="width:80px;"></th>
                                    <th>
                                        <div class="doctor-header">
                                            <div class="doctor-avatar bg-success">MK</div>
                                            <span class="fw-semibold small">Dr. Khan</span>
                                        </div>
                                    </th>
                                    <th>
                                        <div class="doctor-header">
                                            <div class="doctor-avatar bg-secondary">AN</div>
                                            <span class="fw-semibold small">Dr. Naidoo</span>
                                        </div>
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr class="border-bottom">
                                    <td class="text-muted small">08:00</td>
                                    <td><div class="appt-block bg-secondary bg-opacity-25">Thabo Mokoena<br><small class="text-muted">Check-up · Completed</small></div></td>
                                    <td></td>
                                </tr>
                                <tr class="border-bottom">
                                    <td class="text-muted small">09:00</td>
                                    <td><div class="appt-block bg-secondary bg-opacity-25">Priya Naidoo<br><small class="text-muted">Filling · Completed</small></div></td>
                                    <td></td>
                                </tr>
                                <tr class="border-bottom">
                                    <td class="text-muted small">10:00</td>
                                    <td></td>
                                    <td><div class="appt-block bg-success bg-opacity-25">Sipho Dlamini<br><small class="text-muted">Root Canal · Scheduled</small></div></td>
                                </tr>
                                <tr class="border-bottom">
                                    <td class="text-muted small">11:00</td>
                                    <td><div class="appt-block bg-success bg-opacity-25">Lerato Mahlangu<br><small class="text-muted">Cleaning · Scheduled</small></div></td>
                                    <td></td>
                                </tr>
                                <tr class="border-bottom">
                                    <td class="text-muted small">13:00</td>
                                    <td></td>
                                    <td><div class="appt-block bg-danger bg-opacity-25">John van der Merwe<br><small class="text-muted">Extraction · Cancelled</small></div></td>
                                </tr>
                                <tr>
                                    <td class="text-muted small">14:00</td>
                                    <td><div class="appt-block bg-success bg-opacity-25">Nomvula Zulu<br><small class="text-muted">Check-up · Scheduled</small></div></td>
                                    <td></td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
                <div class="text-end mt-3">
                    <button class="btn btn-primary" disabled>+ Mark Unavailable</button>
                </div>
            </div>

        </div>

        <p class="text-muted small mt-3">
            Note: This is a mock screen for M3 — appointment data shown is static placeholder content.
            Full CRUD functionality (add/edit/cancel appointments) will be implemented for M4.
        </p>
    </div>

</asp:Content>