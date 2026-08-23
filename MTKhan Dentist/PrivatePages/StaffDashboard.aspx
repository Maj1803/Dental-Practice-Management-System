<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StaffDashboard.aspx.cs" Inherits="MTKhan_Dentist.StaffDashboard" %>

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

        .role-badge {
            background: #eafaff;
            color: #1597ad;
            font-size: 0.8rem;
            font-weight: 600;
            padding: 7px 16px;
            border-radius: 999px;
            display: inline-block;
            border: 1px solid #98e9fb;
        }

        .icon-circle {
            width: 52px;
            height: 52px;
            border-radius: 50%;
            display: flex;
            align-items: center;
            justify-content: center;
            flex-shrink: 0;
        }
    </style>

    <div class="container mt-4 mb-5">

        <!-- Staff Welcome -->
        <div class="hero-banner rounded-4 mb-4">

            <span class="pill-label mb-2">
                STAFF PORTAL
            </span>

            <h2 class="fw-bold mt-3 mb-2" style="color:#2b2b2b;">
                Welcome back, Alex
            </h2>

            <span class="role-badge mt-1">
                Receptionist
            </span>

            <p class="mb-0 mt-3 text-muted">
                Here's an overview of today's appointments and practice activity.
            </p>

        </div>


        <!-- Daily Operational Indicators -->
        <div class="row mb-4">

            <!-- Today's Patients -->
            <div class="col-md-4 mb-3">

                <div class="card shadow-sm border-0 h-100">

                    <div class="card-body d-flex gap-3 align-items-center">

                        <div class="icon-circle bg-primary bg-opacity-10 text-primary">

                            <svg width="22" height="22"
                                 fill="none"
                                 stroke="currentColor"
                                 stroke-width="1.8"
                                 viewBox="0 0 24 24">

                                <path d="M17 21v-2a4 4 0 0 0-4-4H5a4 4 0 0 0-4 4v2"/>
                                <circle cx="9" cy="7" r="4"/>
                                <path d="M23 21v-2a4 4 0 0 0-3-3.87M16 3.13a4 4 0 0 1 0 7.75"/>

                            </svg>

                        </div>

                        <div>

                            <p class="text-muted mb-1 small">
                                Today's Patients
                            </p>

                            <h3 class="mb-0 fw-bold">
                                14
                            </h3>

                        </div>

                    </div>

                </div>

            </div>


            <!-- Appointments Remaining -->
            <div class="col-md-4 mb-3">

                <div class="card shadow-sm border-0 h-100">

                    <div class="card-body d-flex gap-3 align-items-center">

                        <div class="icon-circle bg-success bg-opacity-10 text-success">

                            <svg width="22" height="22"
                                 fill="none"
                                 stroke="currentColor"
                                 stroke-width="1.8"
                                 viewBox="0 0 24 24">

                                <rect x="3" y="4" width="18" height="17" rx="2"/>
                                <path d="M16 2v4M8 2v4M3 9h18"/>

                            </svg>

                        </div>

                        <div>

                            <p class="text-muted mb-1 small">
                                Appointments Remaining
                            </p>

                            <h3 class="mb-0 fw-bold text-success">
                                6
                            </h3>

                        </div>

                    </div>

                </div>

            </div>


            <!-- Cancellations -->
            <div class="col-md-4 mb-3">

                <div class="card shadow-sm border-0 h-100">

                    <div class="card-body d-flex gap-3 align-items-center">

                        <div class="icon-circle bg-danger bg-opacity-10 text-danger">

                            <svg width="22" height="22"
                                 fill="none"
                                 stroke="currentColor"
                                 stroke-width="1.8"
                                 viewBox="0 0 24 24">

                                <path d="M18 6L6 18M6 6l12 12"/>

                            </svg>

                        </div>

                        <div>

                            <p class="text-muted mb-1 small">
                                Cancellations Today
                            </p>

                            <h3 class="mb-0 fw-bold text-danger">
                                1
                            </h3>

                        </div>

                    </div>

                </div>

            </div>

        </div>


        <!-- Today's Appointments and Quick Actions -->
        <div class="row">

            <!-- Today's Appointments -->
            <div class="col-md-7 mb-3">

                <div class="card shadow-sm border-0">

                    <div class="card-header bg-white fw-semibold">
                        Today's Appointments
                    </div>

                    <ul class="list-group list-group-flush">

                        <li class="list-group-item d-flex justify-content-between align-items-center">

                            <span>
                                Thabo Mokoena — Check-up
                            </span>

                            <span class="badge bg-success">
                                08:00
                            </span>

                        </li>


                        <li class="list-group-item d-flex justify-content-between align-items-center">

                            <span>
                                Priya Naidoo — Filling
                            </span>

                            <span class="badge bg-success">
                                09:00
                            </span>

                        </li>


                        <li class="list-group-item d-flex justify-content-between align-items-center">

                            <span>
                                Sipho Dlamini — Root Canal
                            </span>

                            <span class="badge bg-success">
                                10:00 (Scheduled)
                            </span>

                        </li>


                        <li class="list-group-item d-flex justify-content-between align-items-center">

                            <span>
                                Nomvula Zulu — Check-up
                            </span>

                            <span class="badge bg-success">
                                14:00 (Scheduled)
                            </span>

                        </li>

                    </ul>

                </div>

            </div>


            <!-- Receptionist Quick Actions -->
            <div class="col-md-5 mb-3">

                <div class="card shadow-sm border-0">

                    <div class="card-header bg-white fw-semibold">
                        Receptionist Quick Actions
                    </div>

                    <div class="card-body d-flex flex-column gap-2">

                        <a href="ManageSchedule.aspx" class="btn btn-primary">
                            Manage Schedule
                        </a>

                    </div>

                </div>

            </div>

        </div>


        <!-- M3 Note -->
        <p class="text-muted small mt-3">
            Note: This is a mock screen for M3 — statistics and appointment data shown
            are static placeholder content. Role-specific access controls and
            permissions will be implemented in M4.
        </p>

    </div>

</asp:Content>