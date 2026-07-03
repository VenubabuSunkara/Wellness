/* ===========================================
   WellnessPro AI
   Theme Engine v1.0
=========================================== */

document.addEventListener("DOMContentLoaded", () => {

    const html = document.documentElement;

    const STORAGE_KEY = "wellness-theme";

    // Load saved theme
    const savedTheme = localStorage.getItem(STORAGE_KEY);

    if (savedTheme) {
        html.setAttribute("data-theme", savedTheme);
    }

    // Default theme button
    const themeButton = document.getElementById("themeSwitcher");

    if (themeButton) {

        themeButton.addEventListener("click", () => {

            const current = html.getAttribute("data-theme") || "dark";

            const next = current === "dark" ? "light" : "dark";

            html.setAttribute("data-theme", next);

            localStorage.setItem(STORAGE_KEY, next);

            updateThemeIcon(next);

        });

    }

    updateThemeIcon(html.getAttribute("data-theme") || "dark");

});

/* Change theme manually */

function setTheme(theme) {

    document.documentElement.setAttribute("data-theme", theme);

    localStorage.setItem("wellness-theme", theme);

    updateThemeIcon(theme);

}

/* Update icon */

function updateThemeIcon(theme) {

    const icon = document.querySelector("#themeSwitcher i");

    if (!icon) return;

    if (theme === "light") {

        icon.className = "bi bi-sun-fill";

    }
    else {

        icon.className = "bi bi-moon-stars-fill";

    }

}