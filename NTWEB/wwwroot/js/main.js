(function () {
    "use strict";

    /* ===========================
       Header Toggle (Mobile Menu)
       =========================== */
    const headerToggleBtn = document.getElementById('header-toggle');
    const header = document.getElementById('header');
    const toggleWrapper = document.getElementById('header-toggle-wrapper');

    /* Toggle the mobile header visibility */
    headerToggleBtn.addEventListener('click', () => {
        const isActive = header.classList.toggle('header-show');
        headerToggleBtn.classList.toggle('active', isActive);
        toggleWrapper.classList.toggle('active', isActive);
    });

    /* ===========================
       Scroll to Top After Reload
       =========================== */
    window.addEventListener('load', function () {
        window.scrollTo(0, 0);
    });

    /* ===========================
       Hide Mobile Nav on Same-Page Links
       =========================== */
    document.querySelectorAll('#navmenu a').forEach(link => {
        link.addEventListener('click', () => {
            header.classList.remove('header-show');
            headerToggleBtn.classList.remove('active');
            toggleWrapper.classList.remove('active');
        });
    });

    /* ===========================
       Mobile Dropdown Toggle
       =========================== */
    document.querySelectorAll('.navmenu .toggle-dropdown').forEach(navmenu => {
        navmenu.addEventListener('click', function (e) {
            e.preventDefault();
            this.parentNode.classList.toggle('active');
            this.parentNode.nextElementSibling.classList.toggle('dropdown-active');
            e.stopImmediatePropagation();
        });
    });

    /* ===========================
       Preloader Animation
       =========================== */
    const preloader = document.querySelector('#preloader');
    if (preloader) {
        window.addEventListener('load', () => {
            preloader.classList.add('hidden');

            setTimeout(() => {
                preloader.remove();
            }, 300);
        });
    }

    /* ===========================
       Scroll-to-Top Button
       =========================== */
    let scrollTop = document.querySelector('.scroll-top');

    /* Show or hide the scroll-to-top button based on scroll position */
    function toggleScrollTop() {
        if (scrollTop) {
            window.scrollY > 100 ? scrollTop.classList.add('active') : scrollTop.classList.remove('active');
        }
    }

    /* Smoothly scroll to the top when the button is clicked */
    scrollTop.addEventListener('click', (e) => {
        e.preventDefault();
        window.scrollTo({
            top: 0,
            behavior: 'smooth'
        });
    });

    window.addEventListener('load', toggleScrollTop);
    document.addEventListener('scroll', toggleScrollTop);

    /* ===========================
       AOS (Animate On Scroll) Initialization
       =========================== */
    function aosInit() {
        AOS.init({
            duration: 600,
            easing: 'ease-in-out',
            once: true,
            mirror: false
        });
    }
    window.addEventListener('load', aosInit);

    /* ===========================
       Pure Counter Initialization
       =========================== */
    window.addEventListener('load', function () {
        new PureCounter();
    });

    /* ===========================
       Animate Skill Progress Bars
       =========================== */
    document.addEventListener("DOMContentLoaded", function () {
        let skillsSection = document.querySelector('.skills');
        if (skillsSection) {
            new Waypoint({
                element: skillsSection,
                offset: '80%',
                handler: function () {
                    let progressBars = document.querySelectorAll('.progress .progress-bar');
                    progressBars.forEach(el => {
                        el.style.width = el.getAttribute('aria-valuenow') + '%';
                    });
                    this.destroy();
                }
            });
        }
    });

    /* ===========================
       GLightbox Initialization (Gallery)
       =========================== */
    const glightbox = GLightbox({
        selector: '.glightbox'
    });

    /* ===========================
       Isotope Layout & Filter
       =========================== */
    document.querySelectorAll('.isotope-layout').forEach(function (isotopeItem) {
        let layout = isotopeItem.getAttribute('data-layout') ?? 'masonry';
        let filter = isotopeItem.getAttribute('data-default-filter') ?? '*';
        let sort = isotopeItem.getAttribute('data-sort') ?? 'original-order';

        let initIsotope;
        imagesLoaded(isotopeItem.querySelector('.isotope-container'), function () {
            initIsotope = new Isotope(isotopeItem.querySelector('.isotope-container'), {
                itemSelector: '.isotope-item',
                layoutMode: layout,
                filter: filter,
                sortBy: sort
            });
        });

        /* Handle filter buttons click */
        isotopeItem.querySelectorAll('.isotope-filters li').forEach(function (filters) {
            filters.addEventListener('click', function () {
                isotopeItem.querySelector('.isotope-filters .filter-active').classList.remove('filter-active');
                this.classList.add('filter-active');
                initIsotope.arrange({
                    filter: this.getAttribute('data-filter')
                });
                if (typeof aosInit === 'function') {
                    aosInit();
                }
            }, false);
        });

    });

    /* ===========================
       Swiper Sliders Initialization
       =========================== */
    function initSwiper() {
        document.querySelectorAll(".init-swiper").forEach(function (swiperElement) {
            let config = JSON.parse(
                swiperElement.querySelector(".swiper-config").innerHTML.trim()
            );

            if (swiperElement.classList.contains("swiper-tab")) {
                initSwiperWithCustomPagination(swiperElement, config);
            } else {
                new Swiper(swiperElement, config);
            }
        });
    }

    window.addEventListener("load", initSwiper);


    /* ===========================
      Correct Scroll Position on Hash Links
      =========================== */
    window.addEventListener('load', function (e) {
        if (window.location.hash) {
            if (document.querySelector(window.location.hash)) {
                setTimeout(() => {
                    let section = document.querySelector(window.location.hash);
                    let scrollMarginTop = getComputedStyle(section).scrollMarginTop;
                    window.scrollTo({
                        top: section.offsetTop - parseInt(scrollMarginTop),
                        behavior: 'smooth'
                    });
                }, 100);
            }
        }
    });


    /* ===========================
      Navigation Menu Scrollspy
      =========================== */
    let navmenulinks = document.querySelectorAll('.navmenu a');

    function navmenuScrollspy() {
        navmenulinks.forEach(navmenulink => {
            if (!navmenulink.hash) return;
            let section = document.querySelector(navmenulink.hash);
            if (!section) return;
            let position = window.scrollY + 200;
            if (position >= section.offsetTop && position <= (section.offsetTop + section.offsetHeight)) {
                document.querySelectorAll('.navmenu a.active').forEach(link => link.classList.remove('active'));
                navmenulink.classList.add('active');
            } else {
                navmenulink.classList.remove('active');
            }
        })
    }
    window.addEventListener('load', navmenuScrollspy);
    document.addEventListener('scroll', navmenuScrollspy);

    /* ===========================
       Popup Message Positioning
       =========================== */
    const popup = document.getElementById("popupMessage");
    const form = document.getElementById("form");

    if (popup && form) {
        const formRect = form.getBoundingClientRect();
        popup.style.left = `${formRect.left + formRect.width / 2}px`;
        popup.style.maxWidth = `${formRect.width}px`;
    }

    /* ===========================
       Footer Image Reveal on Scroll
       =========================== */
    const footerImage = document.querySelector(".footer-image");
    if (footerImage) {
        let ticking = false;

        function updateFooterImage() {
            const scrollY = window.scrollY;
            const docHeight = document.documentElement.scrollHeight;
            const winHeight = window.innerHeight;
            const scrollBottom = docHeight - (scrollY + winHeight);

            if (scrollBottom < 120) {
                footerImage.classList.add("show");
            } else {
                footerImage.classList.remove("show");
            }
            ticking = false;
        }

        window.addEventListener("scroll", () => {
            if (!ticking) {
                window.requestAnimationFrame(updateFooterImage);
                ticking = true;
            }
        });

        updateFooterImage();
    }

    /* ===========================
       FAQ Accordion Toggle
       =========================== */
    const faqItems = document.querySelectorAll('.faq-item');
    if (faqItems.length > 0) {
        faqItems.forEach(item => {
            const question = item.querySelector('.faq-question');
            question.addEventListener('click', () => {
                item.classList.toggle('active');
            });
        });
    }
})();