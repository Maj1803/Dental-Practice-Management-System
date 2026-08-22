<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MTKhan_Dentist._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <div class="dental-hero">
            <div class="hero-text">
                <p class="hero-eyebrow">WELCOME TO</p>
                <h1>DR MT. KHAN DENTAL PRACTICE</h1>
                <p class="hero-slogan">Your trusted dental provider.</p>
            </div>
        </div>

        <section class="intro-section">
            <div class="row align-items-start">
                <div class="col-md-6 intro-left">
                    <h2 class="intro-headline">Compassionate Care.<br />Healthy Smiles.<br />Confident You.</h2>
                    <p class="intro-text">At Dr. MT Khan Dental Practice, we believe that visiting the dentist should feel comfortable, welcoming, and stress-free. Our team is committed to providing compassionate and professional dental care.</p>
                    <p class="intro-text">Whether you are visiting us for a routine check-up, preventive care, or to improve your smile, we take the time to understand your needs and provide exceptional dental care.</p>
                    <p class="intro-text">Our practice is built around creating positive dental experiences while helping you make informed decisions about your oral health.</p>
                </div>
                <div class="col-md-6 intro-right">
                    <h2 class="intro-right-headline">🦷 Where your smile comes first</h2>
                    <ul class="intro-features">
                        <li><strong>Compassionate Care</strong> - A gentle and caring approach</li>
                        <li><strong>Patient-Centred</strong> - Care tailored to your individual needs</li>
                        <li><strong>Quality Dental Care</strong> - Professional care for a healthy smile</li>
                        <li><strong>Family Friendly</strong> - Welcoming care for the whole family</li>
                    </ul>
                    <p class="intro-closing">Your journey to a healthier, brighter smile starts here!</p>
                </div>
            </div>
        </section>
                <section class="testimonials-section">
            <div class="testimonials-header">
               <a href="https://maps.app.goo.gl/nxCHtw9niYAqECgNA" class="view-more-btn" target="_blank" rel="noopener noreferrer">View More +</a>
            </div>
            <div class="row testimonials-row">
                <div class="col-md-4">
                    <div class="review-card">
                        <div class="review-google-icon">
                          <img src="~/Images/google-icon.jpeg" alt="Google" runat="server" />
                        </div>
                        <div class="review-stars">★★★★★</div>
                        <p class="review-text">"Dr. Khan's gentle manner made all my anxieties disappear. His office was incredibly clean and modern. I barely felt the needle! Highly recommend for anyone looking for a great dentist."</p>
                        <p class="review-name">Fatima Zahra</p>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="review-card">
                        <div class="review-google-icon">
                           <img src="~/Images/google-icon.jpeg" alt="Google" runat="server" />
                        </div>
                        <div class="review-stars">★★★★★</div>
                        <p class="review-text">"My family and I have been seeing Dr. Khan for years. From cleanings to crowns, the care is exceptional. His team is friendly, and the results are always top-notch. Simply the best."</p>
                        <p class="review-name">Isaac Thomas</p>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="review-card">
                        <div class="review-google-icon">
                           <img src="~/Images/google-icon.jpeg" alt="Google" runat="server" />
                        </div>
                        <div class="review-stars">★★★★★</div>
                        <p class="review-text">"I came in for an emergency and Dr. Khan saw me right away. He explained everything clearly and got me out of pain quickly. I can't thank him and his professional staff enough. Truly caring."</p>
                        <p class="review-name">Chloe Singh</p>
                    </div>
                </div>
            </div>
        </section>
    </main>

</asp:Content>