/* ===========================================
   WellnessPro AI
   Premium Navigation
=========================================== */

document.addEventListener("DOMContentLoaded", function () {

    const header = document.getElementById("mainHeader");

    /* ===============================
       Sticky Header
    =============================== */

    window.addEventListener("scroll", function () {

        if (window.scrollY > 60) {

            header.classList.add("header-scrolled");

        } else {

            header.classList.remove("header-scrolled");

        }

    });

    /* ===============================
       Active Navigation
    =============================== */

    const navLinks = document.querySelectorAll(".nav-link");

    navLinks.forEach(link => {

        link.addEventListener("click", function () {

            navLinks.forEach(item => {

                item.classList.remove("active");

            });

            this.classList.add("active");

        });

    });

    /* ===============================
       Smooth Scroll
    =============================== */

    document.querySelectorAll('a[href^="#"]').forEach(anchor => {

        anchor.addEventListener("click", function (e) {

            const target = document.querySelector(this.getAttribute("href"));

            if (target) {

                e.preventDefault();

                target.scrollIntoView({

                    behavior: "smooth"

                });

            }

        });

    });

    /* ===============================
       Close Mobile Menu
    =============================== */

    const menu = document.querySelector(".navbar-collapse");

    const bsCollapse = menu
        ? new bootstrap.Collapse(menu, { toggle: false })
        : null;

    document.querySelectorAll(".navbar-collapse .nav-link")
        .forEach(link => {

            link.addEventListener("click", () => {

                if (window.innerWidth < 992 && bsCollapse) {

                    bsCollapse.hide();

                }

            });

        });

});