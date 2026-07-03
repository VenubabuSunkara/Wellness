document.addEventListener("DOMContentLoaded", () => {

    const counters = document.querySelectorAll(".counter");

    counters.forEach(counter => {

        const target = +counter.dataset.count;

        let count = 0;

        const speed = target / 100;

        function update() {

            if (count < target) {

                count += speed;

                counter.innerText = Math.ceil(count);

                requestAnimationFrame(update);

            }
            else {

                counter.innerText = target + "+";

            }

        }

        update();

    });

});