<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PatientDashboard.aspx.cs" Inherits="MTKhan_Dentist.PatientDashboard" %>

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

        .mock-card {
            transition: transform 0.2s ease, box-shadow 0.2s ease;
        }

        .mock-card:hover {
            transform: translateY(-4px);
            box-shadow: 0 14px 28px rgba(0,0,0,0.09);
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

        <div class="hero-banner rounded-4 mb-4">
            <span class="pill-label mb-2">PATIENT PORTAL</span>

            <h2 class="fw-bold mt-3 mb-2" style="color:#2b2b2b;">
                Welcome back, Jane
            </h2>

            <p class="mb-0 text-muted">
                Here's an overview of your patient account and upcoming appointment.
            </p>
        </div>

        <div class="row mb-4">

            <!-- Next Appointment -->
            <div class="col-md-6 mb-3">
                <div class="card shadow-sm border-0 h-100 mock-card">
                    <div class="card-body d-flex gap-3">

                        <div class="icon-circle bg-success bg-opacity-10 text-success">
                            <svg width="24" height="24" fill="none"
                                 stroke="currentColor" stroke-width="1.8"
                                 viewBox="0 0 24 24">
                                <rect x="3" y="4" width="18" height="17" rx="2"/>
                                <path d="M16 2v4M8 2v4M3 9h18"/>
                            </svg>
                        </div>

                        <div>
                            <p class="text-muted mb-1 small">
                                Next Appointment
                            </p>

                            <p class="mb-0 fw-semibold fs-5">
                                28 Aug 2026, 10:30
                            </p>

                            <p class="mb-0 small text-muted">
                                Dr. Khan — Routine Check-up
                            </p>

                            <span class="badge bg-success mt-2">
                                Confirmed
                            </span>
                        </div>

                    </div>
                </div>
            </div>

            <!-- Patient Profile -->
            <div class="col-md-6 mb-3">
                <div class="card shadow-sm border-0 h-100 mock-card">
                    <div class="card-body d-flex gap-3 align-items-center">

                        <div class="icon-circle bg-primary bg-opacity-10 text-primary">
                            <svg width="24" height="24" fill="none"
                                 stroke="currentColor" stroke-width="1.8"
                                 viewBox="0 0 24 24">
                                <path d="M20 21a8 8 0 0 0-16 0"/>
                                <circle cx="12" cy="7" r="4"/>
                            </svg>
                        </div>

                        <div>
                            <p class="text-muted mb-1 small">
                                Patient Profile
                            </p>

                            <p class="mb-1 fw-semibold fs-5">
                                Jane Smith
                            </p>

                            <span class="badge bg-success">
                                Active Patient
                            </span>

                            <p class="text-muted small mt-2 mb-0">
                                Patient since March 2024
                            </p>
                        </div>

                    </div>
                </div>
            </div>

        </div>

        <a href="MyAppointments.aspx" class="btn btn-primary px-4">
            View Appointment Schedule
        </a>

        <p class="text-muted small mt-4">
            Note: This is a mock screen for M3 — patient information and appointment
            details shown are static placeholder content. Full account functionality
            will be implemented for M4.
        </p>

    </div>

</asp:Content>