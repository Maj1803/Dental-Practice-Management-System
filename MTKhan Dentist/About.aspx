<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="MTKhan_Dentist.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">

        <!-- Hero / Intro Banner -->
        <section class="p-5 mb-5 text-center bg-primary-subtle rounded-3 border border-primary-subtle shadow-sm">
            <span class="badge bg-primary text-uppercase px-3 py-2 mb-2">Our Practice</span>
            <h1 id="title" class="display-6 fw-bold text-dark mb-3">About Dr MT Khan Dental Practice</h1>
            <p class="lead text-muted mx-auto mb-0" style="max-width: 720px;">
                Delivering trusted, gentle, and award-winning dental healthcare to the South Coast community for over two decades.
            </p>
        </section>

        <!-- Practice Overview & Legacy Section -->
        <section class="container mb-5">
            <div class="row align-items-center g-5">
                <div class="col-lg-7">
                    <span class="text-primary fw-bold text-uppercase small">A Legacy of Care</span>
                    <h2 class="fw-bold text-dark mt-1 mb-3">Modern Dentistry with a Community Heart</h2>
                    <p class="text-muted">
                        In 2005, a new chapter began at the long-standing Anerley Road practice rooms when <strong>Dr Mohummed Tahir Khan</strong> took over the practice from Dr Andrew Roberts. Over the past 20+ years, Dr Khan has dedicated his practice to providing gentle, high-quality, and patient-centered dentistry across Port Shepstone, Anerley, Southport, and the greater South Coast region.
                    </p>
                    <p class="text-muted">
                        For Dr Khan, dentistry has never been just a profession—it is a lifelong calling rooted in patient comfort, clinical precision, and community wellness.
                    </p>
                    
                    <div class="row g-3 pt-2">
                        <div class="col-sm-6">
                            <div class="d-flex align-items-center">
                                <span class="badge bg-success rounded-circle me-2 p-2">✓</span>
                                <span class="fw-semibold text-dark">Over 20 Years Experience</span>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="d-flex align-items-center">
                                <span class="badge bg-success rounded-circle me-2 p-2">✓</span>
                                <span class="fw-semibold text-dark">Family & Emergency Care</span>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Award Highlight Card -->
                <div class="col-lg-5">
                    <div class="card border-0 bg-light shadow-sm p-4 text-center">
                        <div class="display-4 mb-2">🏆</div>
                        <h4 class="fw-bold text-dark mb-1">Award-Winning Care</h4>
                        <p class="text-primary fw-semibold mb-3">Best of South Coast (BOSC) Winner</p>
                        <p class="text-muted small mb-0">
                            Proudly voted <strong>Best Dentist</strong> in the <em>South Coast Herald Readers' Choice Awards</em> by our local community.
                        </p>
                    </div>
                </div>
            </div>
        </section>

        <!-- Core Pillars / Why Choose Us -->
        <section class="py-5 bg-light rounded-4 mb-5 shadow-sm">
            <div class="container">
                <div class="text-center mb-5">
                    <h2 class="fw-bold text-dark">Why Choose Us</h2>
                    <p class="text-muted">What makes our dental practice unique</p>
                </div>
                <div class="row g-4">
                    <div class="col-md-4">
                        <div class="card h-100 border-primary-subtle shadow-sm p-4 text-center">
                            <div class="badge bg-primary align-self-center mb-3 p-2 px-3">Compassion</div>
                            <h5 class="card-title fw-bold text-dark">Gentle & Anxiety-Free</h5>
                            <p class="card-text text-muted">
                                We prioritize patient relaxation, gentle techniques, and compassionate care to make every dental visit stress-free.
                            </p>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="card h-100 border-primary-subtle shadow-sm p-4 text-center">
                            <div class="badge bg-secondary align-self-center mb-3 p-2 px-3">Treatment</div>
                            <h5 class="card-title fw-bold text-dark">Comprehensive Solutions</h5>
                            <p class="card-text text-muted">
                                From routine cleanings and restorations to specialized aesthetic procedures and urgent dental relief.
                            </p>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="card h-100 border-primary-subtle shadow-sm p-4 text-center">
                            <div class="badge bg-info align-self-center mb-3 p-2 px-3">Convenience</div>
                            <h5 class="card-title fw-bold text-dark">Community-Centered</h5>
                            <p class="card-text text-muted">
                                Conveniently located on Anerley Road with accessible hours tailored to busy family and work schedules.
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </section>

        <!-- Dentist Profile Card -->
        <section class="container mb-5">
            <div class="text-center mb-4">
                <h2 class="fw-bold text-dark">Meet Your Dentist</h2>
                <p class="text-muted">Dedicated clinical expertise on the South Coast</p>
            </div>
            <div class="row justify-content-center">
                <div class="col-lg-9">
                    <div class="card border-0 shadow-sm overflow-hidden">
                        <div class="card-body p-4 p-md-5">
                            <h3 class="card-title fw-bold text-dark mb-1">Dr Mohummed Tahir Khan</h3>
                            <p class="text-primary fw-semibold mb-3">Dental Surgeon &bull; General Dental Practitioner</p>
                            <p class="card-text text-muted">
                                With over two decades of experience serving the South Coast, Dr Khan focuses on preventative health, pain-free dental procedures, and building long-lasting relationships with generations of patients.
                            </p>
                            <hr class="my-4" />
                            <div class="row g-2 text-muted small">
                                <div class="col-md-6">
                                    <strong>📍 Practice:</strong> 6 Anerley Road, Anerley / Southport
                                </div>
                                <div class="col-md-6">
                                    <strong>🏆 Accolade:</strong> Best of South Coast Readers' Choice Winner
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>

        <!-- CTA Bar (Links to Appointment & Contact Pages) -->
        <section class="p-4 bg-primary text-white rounded-3 mb-4 shadow-sm">
            <div class="container">
                <div class="row align-items-center justify-content-between g-3">
                    <div class="col-md-8">
                        <h4 class="fw-bold mb-1 text-white">Need to schedule a checkup or treatment?</h4>
                        <p class="mb-0 text-white-50">Mon – Thu: 08:00 – 16:30 | Fri: 08:00 – 11:30, 14:00 – 16:30 | Sat: 08:00 - 12:00</p>
                    </div>
                    <div class="col-md-4 text-md-end">
                        <a href="RequestApp.aspx" class="btn btn-secondary fw-semibold me-2">Book Appointment</a>
                        <a href="Contact.aspx" class="btn btn-light fw-semibold">Contact Us</a>
                    </div>
                </div>
            </div>
        </section>

    </main>
</asp:Content>