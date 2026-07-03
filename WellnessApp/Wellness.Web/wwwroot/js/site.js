const backToTop = document.getElementById("backToTop");

window.addEventListener("scroll", () => {

    if (window.scrollY > 400) {

        backToTop.style.display = "flex";

    } else {

        backToTop.style.display = "none";

    }

});

backToTop.addEventListener("click", () => {

    window.scrollTo({

        top: 0,

        behavior: "smooth"

    });

});

if (localStorage.getItem("cookieAccepted")) {

    document.getElementById("cookieConsent").style.display = "none";

}

document.getElementById("acceptCookies").onclick = function () {

    localStorage.setItem("cookieAccepted", true);

    document.getElementById("cookieConsent").style.display = "none";

}

window.addEventListener("load", function () {

    const preloader = document.getElementById("preloader");

    if (preloader) {

        preloader.style.opacity = "0";

        preloader.style.visibility = "hidden";

        setTimeout(() => {

            preloader.remove();

        }, 500);

    }

});

// window.onload = function () {

//     document.getElementById("preloader").classList.add("hide");

// };