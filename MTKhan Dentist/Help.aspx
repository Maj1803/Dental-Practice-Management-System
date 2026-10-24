<%@ Page Title="Help & FAQ" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Help.aspx.cs" Inherits="MTKhan_Dentist.Help" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .chat-card { border-radius: 1rem; overflow: hidden; }
        .chat-header { background: var(--bs-primary); color: #fff; }
        .bot-avatar {
            width: 40px; height: 40px; border-radius: 50%;
            background: rgba(255,255,255,0.25);
            display: flex; align-items: center; justify-content: center; flex-shrink: 0;
        }
        .chat-log {
            height: 420px; overflow-y: auto; padding: 1rem;
            background: var(--bs-tertiary-bg, #f8f9fa);
        }
        .msg { display: flex; margin-bottom: 0.75rem; }
        .msg-bubble {
            max-width: 82%; padding: 0.6rem 0.9rem; border-radius: 1rem;
            font-size: 0.95rem; line-height: 1.45; word-wrap: break-word;
        }
        .msg.bot .msg-bubble { background: #fff; border: 1px solid var(--bs-border-color); border-top-left-radius: 0.25rem; }
        .msg.user { justify-content: flex-end; }
        .msg.user .msg-bubble { background: var(--bs-primary); color: #fff; border-top-right-radius: 0.25rem; }
        .msg.bot .msg-bubble a { color: var(--bs-primary-text-emphasis, #2f6b5a); font-weight: 600; }
        .chip-row { display: flex; flex-wrap: wrap; gap: 0.4rem; margin: -0.25rem 0 0.75rem 0; }
        .chip-row .btn { border-radius: 999px; font-size: 0.85rem; }
        .typing span {
            display: inline-block; width: 7px; height: 7px; margin: 0 2px; border-radius: 50%;
            background: var(--bs-secondary-color, #888); animation: blink 1.2s infinite both;
        }
        .typing span:nth-child(2) { animation-delay: 0.2s; }
        .typing span:nth-child(3) { animation-delay: 0.4s; }
        @keyframes blink { 0%, 80%, 100% { opacity: 0.25; } 40% { opacity: 1; } }
        @media (prefers-reduced-motion: reduce) { .typing span { animation: none; } }
        .help-side-card { border-radius: 1rem; }
        .faq-cat { font-size: 0.7rem; letter-spacing: 0.04em; }
    </style>

    <main aria-labelledby="title">

        <!-- Hero (matches About page) -->
        <section class="p-5 mb-5 text-center bg-primary-subtle rounded-3 border border-primary-subtle shadow-sm">
            <span class="badge bg-primary text-uppercase px-3 py-2 mb-2">Help Centre</span>
            <h1 id="title" class="display-6 fw-bold text-dark mb-3">How can we help?</h1>
            <p class="lead text-muted mx-auto mb-0" style="max-width: 720px;">
                Ask our help assistant a question, or browse the frequently asked questions below.
            </p>
        </section>

        <div class="container mb-5">
            <div class="row g-4">

                <!-- Chatbot -->
                <div class="col-lg-8">
                    <div class="card chat-card shadow-sm border-0">
                        <div class="chat-header d-flex align-items-center gap-3 p-3">
                            <div class="bot-avatar" aria-hidden="true">
                                <svg width="22" height="22" fill="none" stroke="currentColor" stroke-width="1.8" viewBox="0 0 24 24">
                                    <path d="M21 15a2 2 0 0 1-2 2H7l-4 4V5a2 2 0 0 1 2-2h14a2 2 0 0 1 2 2z" />
                                </svg>
                            </div>
                            <div>
                                <p class="mb-0 fw-bold">Help Assistant</p>
                                <p class="mb-0 small" style="opacity: 0.85;">Answers to common questions about the practice</p>
                            </div>
                            <button type="button" id="btnRestart" class="btn btn-sm btn-light ms-auto rounded-pill text-nowrap">Start over</button>
                        </div>

                        <div id="chatLog" class="chat-log" role="log" aria-live="polite" aria-label="Help assistant conversation"></div>

                        <div class="card-body border-top p-3">
                            <label for="chatInput" class="visually-hidden">Type your question</label>
                            <div class="input-group">
                                <input type="text" id="chatInput" class="form-control" maxlength="200"
                                       placeholder="Type a question, e.g. &quot;How do I cancel?&quot;" autocomplete="off" />
                                <button type="button" id="btnSend" class="btn btn-primary px-4">Send</button>
                            </div>
                            <p class="small text-muted mt-2 mb-0">
                                This assistant answers general questions only. It can't see your appointments or medical records.
                            </p>
                        </div>
                    </div>
                </div>

                <!-- Still need help -->
                <div class="col-lg-4">
                    <div class="card help-side-card shadow-sm border-0 mb-4">
                        <div class="card-body p-4">
                            <h2 class="h5 fw-bold mb-3">Still need help?</h2>
                            <p class="text-muted small mb-3">Our reception team is happy to assist during office hours.</p>
                            <a href="tel:+27396812670" class="btn btn-primary w-100 mb-2">Call (039) 681 2670</a>
                            <a runat="server" href="~/Contact" class="btn btn-outline-primary w-100 mb-2">Send us a message</a>
                            <a runat="server" href="~/RequestApp" class="btn btn-outline-primary w-100">Request an appointment</a>
                        </div>
                    </div>

                    <div class="card help-side-card shadow-sm border-0 border-start border-danger border-4">
                        <div class="card-body p-4">
                            <h2 class="h6 fw-bold text-danger mb-2">Dental emergency?</h2>
                            <p class="small text-muted mb-0">
                                For severe pain, swelling or a knocked-out tooth, phone the practice immediately.
                                Don't use the online forms for emergencies.
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- FAQ list (works without JavaScript, same content as the chatbot) -->
        <section class="container mb-5" aria-labelledby="faqTitle">
            <h2 id="faqTitle" class="fw-bold mb-3">Frequently Asked Questions</h2>
            <div class="accordion shadow-sm" id="faqAccordion">
                <asp:Repeater ID="rptFaq" runat="server">
                    <ItemTemplate>
                        <div class="accordion-item">
                            <h3 class="accordion-header" id="faqHead<%# Container.ItemIndex %>">
                                <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse"
                                        data-bs-target="#faqBody<%# Container.ItemIndex %>" aria-expanded="false"
                                        aria-controls="faqBody<%# Container.ItemIndex %>">
                                    <span class="badge bg-primary-subtle text-primary-emphasis text-uppercase faq-cat me-2"><%#: Eval("Category") %></span>
                                    <%#: Eval("Question") %>
                                </button>
                            </h3>
                            <div id="faqBody<%# Container.ItemIndex %>" class="accordion-collapse collapse"
                                 aria-labelledby="faqHead<%# Container.ItemIndex %>" data-bs-parent="#faqAccordion">
                                <div class="accordion-body text-muted">
                                    <%# Eval("Answer") %>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </section>
    </main>

    <script>
        (function () {
            // FAQ content comes from Help.aspx.cs, so the chatbot and the accordion always match
            var faqs = <%= FaqJson %>;

            var log = document.getElementById('chatLog');
            var input = document.getElementById('chatInput');
            var sendBtn = document.getElementById('btnSend');
            var restartBtn = document.getElementById('btnRestart');
            var reduceMotion = window.matchMedia && window.matchMedia('(prefers-reduced-motion: reduce)').matches;
            var delay = reduceMotion ? 0 : 450;

            var categories = [];
            faqs.forEach(function (f) { if (categories.indexOf(f.category) === -1) categories.push(f.category); });

            function scrollDown() { log.scrollTop = log.scrollHeight; }

            // User text is added with textContent so typed HTML is never run
            function addUser(text) {
                var row = document.createElement('div');
                row.className = 'msg user';
                var bubble = document.createElement('div');
                bubble.className = 'msg-bubble';
                bubble.textContent = text;
                row.appendChild(bubble);
                log.appendChild(row);
                scrollDown();
            }

            // Bot HTML is only ever the team-written answers from the code-behind
            function addBot(html, chips) {
                var typing = document.createElement('div');
                typing.className = 'msg bot';
                typing.innerHTML = '<div class="msg-bubble typing" aria-label="Assistant is typing"><span></span><span></span><span></span></div>';
                log.appendChild(typing);
                scrollDown();
                setControls(false);

                setTimeout(function () {
                    log.removeChild(typing);
                    var row = document.createElement('div');
                    row.className = 'msg bot';
                    var bubble = document.createElement('div');
                    bubble.className = 'msg-bubble';
                    bubble.innerHTML = html;
                    row.appendChild(bubble);
                    log.appendChild(row);
                    if (chips && chips.length) addChips(chips);
                    setControls(true);
                    scrollDown();
                }, delay);
            }

            function setControls(enabled) {
                sendBtn.disabled = !enabled;
                var old = log.querySelectorAll('.chip-row .btn');
                for (var i = 0; i < old.length; i++) old[i].disabled = !enabled;
            }

            function addChips(chips) {
                var row = document.createElement('div');
                row.className = 'chip-row';
                chips.forEach(function (c) {
                    var b = document.createElement('button');
                    b.type = 'button'; // stops a WebForms postback
                    b.className = 'btn btn-sm ' + (c.primary ? 'btn-primary' : 'btn-outline-primary');
                    b.textContent = c.label;
                    b.addEventListener('click', function () {
                        row.remove();
                        c.action();
                    });
                    row.appendChild(b);
                });
                log.appendChild(row);
            }

            function topicChips() {
                return categories.map(function (cat) {
                    return { label: cat, action: function () { showCategory(cat); } };
                });
            }

            function afterAnswerChips() {
                return [
                    { label: 'Ask something else', primary: true, action: function () { input.focus(); } },
                    { label: 'Browse topics', action: function () { addUser('Browse topics'); addBot('Pick a topic:', topicChips()); } }
                ];
            }

            function showCategory(cat) {
                addUser(cat);
                var list = faqs.filter(function (f) { return f.category === cat; });
                addBot('Here are common questions about <strong>' + cat + '</strong>:', list.map(function (f) {
                    return { label: f.question, action: function () { answer(f); } };
                }).concat([{ label: '← Back to topics', action: function () { addBot('Pick a topic:', topicChips()); } }]));
            }

            function answer(f, alsoAsked) {
                addUser(f.question);
                var chips = afterAnswerChips();
                if (alsoAsked) {
                    chips.unshift({ label: 'Related: ' + alsoAsked.question, action: function () { answer(alsoAsked); } });
                }
                addBot(f.answer, chips);
            }

            // Simple keyword matching: score each FAQ by how many words in the question match its keywords
            function normalise(text) {
                return text.toLowerCase().replace(/[^a-z0-9\s']/g, ' ').split(/\s+/).filter(function (w) { return w.length > 1; });
            }

            var stopWords = ['how', 'do', 'can', 'the', 'my', 'is', 'are', 'what', 'to', 'an', 'of', 'for', 'and', 'you', 'your', 'me', 'it', 'in', 'on', 'at', 'there', 'does', 'why', 'have', 'need', 'want', 'get', 'see', 'with'];

            // Each FAQ's searchable words = its keywords + the words in its question
            faqs.forEach(function (f) { f.words = f.keywords.concat(normalise(f.question)); });

            // Words that appear in many FAQs (like "appointment") count for less than rare ones (like "cancel")
            var freq = {};
            faqs.forEach(function (f) {
                var seen = {};
                f.words.forEach(function (k) { if (!seen[k]) { seen[k] = true; freq[k] = (freq[k] || 0) + 1; } });
            });

            function sameStem(a, b) {
                // Shared start of at least 4 letters, so "cancelling" matches "cancel"
                return a.length >= 4 && b.length >= 4 && a.substr(0, 4) === b.substr(0, 4);
            }

            function score(words, f) {
                var s = 0;
                words.forEach(function (w) {
                    if (stopWords.indexOf(w) !== -1) return;
                    if (f.words.indexOf(w) !== -1) {
                        s += 2 / freq[w];                 // exact match
                        return;
                    }
                    for (var i = 0; i < f.words.length; i++) {
                        if (sameStem(w, f.words[i])) {
                            s += 1 / freq[f.words[i]];    // partial match
                            return;
                        }
                    }
                });
                return s;
            }

            function handleTyped(text) {
                addUser(text);
                var words = normalise(text);

                var greetings = ['hi', 'hello', 'hey', 'howzit', 'morning', 'afternoon'];
                if (words.length && words.every(function (w) { return greetings.indexOf(w) !== -1; })) {
                    addBot('Hello! What can I help you with?', topicChips());
                    return;
                }
                if (words.some(function (w) { return w === 'thanks' || w === 'thank'; })) {
                    addBot("You're welcome. Is there anything else?", afterAnswerChips());
                    return;
                }

                var ranked = faqs.map(function (f) { return { f: f, s: score(words, f) }; })
                                 .filter(function (r) { return r.s > 0; })
                                 .sort(function (a, b) { return b.s - a.s; });

                // Emergencies take priority, but only when an actual emergency word was typed
                var emergencyFaq = faqs.filter(function (f) { return f.id === 'emergency'; })[0];
                var isEmergency = emergencyFaq && words.some(function (w) { return emergencyFaq.keywords.indexOf(w) !== -1; });
                var emergency = isEmergency ? ranked.filter(function (r) { return r.f.id === 'emergency'; })[0] : null;
                var best = emergency || ranked[0];

                if (!best) {
                    addBot("Sorry, I don't have an answer for that yet. You can phone reception on <strong>(039) 681 2670</strong> " +
                           "or send us a message on the <a href=\"<%= ResolveUrl("~/Contact") %>\">Contact</a> page. Or pick a topic:", topicChips());
                    return;
                }

                // Offer a second answer if it scored nearly as well, in case we picked the wrong one
                var related = ranked.filter(function (r) { return r.f !== best.f && r.s >= best.s * 0.8; })[0];
                var chips = afterAnswerChips();
                if (related) {
                    chips.unshift({ label: 'Related: ' + related.f.question, action: function () { answer(related.f); } });
                }
                addBot(best.f.answer, chips);
            }

            function send() {
                var text = input.value.trim();
                if (!text || sendBtn.disabled) return;
                input.value = '';
                handleTyped(text);
            }

            function start() {
                log.innerHTML = '';
                addBot('Hi! I\'m the Dr MT Khan Dental help assistant. Type a question below, or choose a topic:', topicChips());
            }

            sendBtn.addEventListener('click', send);
            input.addEventListener('keydown', function (e) {
                // Enter would otherwise submit the page's WebForms form
                if (e.key === 'Enter') { e.preventDefault(); send(); }
            });
            restartBtn.addEventListener('click', start);

            start();
        })();
    </script>
</asp:Content>
