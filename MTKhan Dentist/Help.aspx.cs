using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using System.Web.UI;

namespace MTKhan_Dentist
{
    public partial class Help : Page
    {
        // JSON copy of the FAQ list, read by the chatbot script on the page
        protected string FaqJson = "[]";

        protected void Page_Load(object sender, EventArgs e)
        {
            List<FaqItem> faqs = GetFaqs();

            if (!IsPostBack)
            {
                // Same list feeds the accordion (works without JavaScript) and the chatbot
                rptFaq.DataSource = faqs;
                rptFaq.DataBind();
            }

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            FaqJson = serializer.Serialize(faqs.Select(f => new
            {
                id = f.Id,
                category = f.Category,
                question = f.Question,
                answer = f.Answer,
                keywords = f.Keywords
            }));
        }

        /// <summary>
        /// Single source of FAQ content. To change an answer, edit it here and both
        /// the chatbot and the FAQ list update. Could later be moved to a FAQ table in the DB.
        /// </summary>
        private List<FaqItem> GetFaqs()
        {
            string requestUrl = ResolveUrl("~/RequestApp");
            string contactUrl = ResolveUrl("~/Contact");
            string loginUrl = ResolveUrl("~/Account/Login");
            string registerUrl = ResolveUrl("~/Account/Register");
            string forgotUrl = ResolveUrl("~/Account/Forgot");

            return new List<FaqItem>
            {
                // ---------- Appointments ----------
                new FaqItem("book", "Appointments",
                    "How do I book an appointment?",
                    "Use the <a href=\"" + requestUrl + "\">Request Appointment</a> page. Choose your preferred date, time of day and reason for the visit. " +
                    "Our reception team checks the dentist's availability and confirms your booking by message and email.",
                    "book booking appointment request schedule make new visit slot"),

                new FaqItem("confirm", "Appointments",
                    "How will I know my appointment is confirmed?",
                    "Once reception confirms your slot, you receive an email and a message on your patient portal. " +
                    "If your requested time is taken, we suggest the nearest available time instead.",
                    "confirm confirmed confirmation status pending declined know email message"),

                new FaqItem("cancel", "Appointments",
                    "How do I cancel or reschedule?",
                    "<a href=\"" + loginUrl + "\">Log in</a>, open <strong>My Appointments</strong> and choose <strong>Request Cancellation</strong>. " +
                    "Reception will contact you to arrange a new time. You can also phone the practice on (039) 681 2670.",
                    "cancel cancellation reschedule change move postpone different time"),

                new FaqItem("bring", "Appointments",
                    "What should I bring to my first visit?",
                    "Please bring your ID, your medical aid card (if you have one), and a list of any medication you take. " +
                    "Tell us about any allergies so we can record them on your file.",
                    "bring first visit new patient id medical aid card documents allergies medication"),

                // ---------- Account & Login ----------
                new FaqItem("register", "Account & Login",
                    "How do I create a patient account?",
                    "Go to <a href=\"" + registerUrl + "\">Register</a> and fill in your details. " +
                    "Use an email address you check often, because confirmations and password resets are sent there.",
                    "register sign up create account new patient join"),

                new FaqItem("forgot", "Account & Login",
                    "I forgot my password. What do I do?",
                    "Go to <a href=\"" + forgotUrl + "\">Forgot Password</a> and enter the email you registered with. " +
                    "We send a one-time code (OTP) to that email. Enter the code to set a new password.",
                    "forgot password reset otp code locked cant login can't log in"),

                new FaqItem("login", "Account & Login",
                    "Why can't I log in?",
                    "Check that you're using the same email you registered with and that Caps Lock is off. " +
                    "If you still can't get in, use <a href=\"" + forgotUrl + "\">Forgot Password</a> or contact reception.",
                    "login log in sign in cant access error wrong account"),

                // ---------- Patient Portal ----------
                new FaqItem("history", "Patient Portal",
                    "How do I view my past appointments?",
                    "After you <a href=\"" + loginUrl + "\">log in</a>, open <strong>My Appointments</strong>. " +
                    "It lists upcoming and past visits with their status (Pending, Confirmed or Declined).",
                    "past history previous appointments view see list"),

                new FaqItem("prescriptions", "Patient Portal",
                    "Can I view my prescriptions?",
                    "Yes. Log in and open <strong>Prescription History</strong> to see the medication the dentist has prescribed you, with dosage instructions.",
                    "prescription prescriptions medicine medication dosage history"),

                new FaqItem("messages", "Patient Portal",
                    "How do I message the practice?",
                    "Log in and open <strong>Messages</strong> to chat with reception. You can also use the <a href=\"" + contactUrl + "\">Contact</a> form.",
                    "message messages chat contact reception talk ask question"),

                new FaqItem("profile", "Patient Portal",
                    "How do I update my contact details?",
                    "Log in and open <strong>My Profile</strong> to update your phone number, email or address.",
                    "update change profile details phone number email address edit"),

                // ---------- Practice Info ----------
                new FaqItem("hours", "Practice Info",
                    "What are your opening hours?",
                    "<strong>Mon – Thurs:</strong> 08:00 – 16:30<br /><strong>Fri:</strong> 08:00 – 11:30, 14:00 – 16:30<br />" +
                    "<strong>Sat:</strong> 08:30 – 13:00<br /><strong>Sun:</strong> Closed",
                    "hours open opening times close closed when time today weekend saturday sunday friday"),

                new FaqItem("location", "Practice Info",
                    "Where are you located?",
                    "6 Anerley Road, Anerley, Port Shepstone, 4230, KZN. See the <a href=\"" + contactUrl + "\">Contact</a> page for directions.",
                    "where location address directions find located map port shepstone anerley"),

                new FaqItem("services", "Practice Info",
                    "What treatments do you offer?",
                    "Check-ups, scale and polish, fillings, crowns and bridges, extractions (including wisdom teeth) and treatment for gum problems and sensitivity. " +
                    "For anything else, choose <em>Other / General Consultation</em> when you request an appointment.",
                    "services treatments offer cleaning filling crown bridge extraction wisdom teeth gum checkup polish"),

                new FaqItem("cost", "Practice Info",
                    "How much does treatment cost, and how can I pay?",
                    "Costs depend on the treatment you need, so the dentist will discuss them with you at your visit. " +
                    "You can pay by cash, card or EFT. For a quote before booking, phone reception on (039) 681 2670.",
                    "cost costs price prices much fee fees pay payment paying cash card eft quote expensive charge"),

                // ---------- Emergencies ----------
                new FaqItem("emergency", "Emergencies",
                    "I have a dental emergency. What should I do?",
                    "For severe pain, swelling, bleeding or a knocked-out tooth, <strong>phone the practice immediately on (039) 681 2670</strong>. " +
                    "Don't use the online request form for emergencies. If the practice is closed and it's serious, go to your nearest hospital emergency unit.",
                    "emergency urgent pain swelling bleeding knocked broken accident severe toothache now")
            };
        }
    }

    public class FaqItem
    {
        public string Id { get; set; }
        public string Category { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }       // Trusted HTML written by the team, never user input
        public string[] Keywords { get; set; }

        public FaqItem(string id, string category, string question, string answer, string keywords)
        {
            Id = id;
            Category = category;
            Question = question;
            Answer = answer;
            Keywords = keywords.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
