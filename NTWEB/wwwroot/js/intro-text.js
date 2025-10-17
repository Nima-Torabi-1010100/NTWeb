document.addEventListener("DOMContentLoaded", function () {
    const typedElement = document.querySelector('.intro-text');
    if (!typedElement) {
        return;
    }

    const menuTexts = {
        "home": "جایی برای آشنایی با من",
        "resume": "تجربه و مسیر من",
        "about": "کمی درباره من",
        "portfolio": "به تدوینم گوش بده",
        "serviceRequest": "در ارتباط باشیم؟",
        "contact": "شروع یه همکاری جدید؟"
    };

    let lastMenuType = "home";
    let isChanging = false;

    // Set initial text
    typedElement.textContent = menuTexts["home"];

    function changeText(menuType) {
        if (isChanging || menuType === lastMenuType) {
            return;
        }

        isChanging = true;

        // Fade out
        typedElement.classList.add('fade-out');

        setTimeout(() => {
            // Change text
            typedElement.textContent = menuTexts[menuType];

            // Fade in
            typedElement.classList.remove('fade-out');

            lastMenuType = menuType;
            isChanging = false;
        }, 500);
    }

    const menuItems = document.querySelectorAll('.navmenu ul li a');
    menuItems.forEach(item => {
        let menuType = "";
        if (item.textContent.includes("خانه")) menuType = "home";
        else if (item.textContent.includes("رزومه")) menuType = "resume";
        else if (item.textContent.includes("بیوگرافی")) menuType = "about";
        else if (item.textContent.includes("پادکست")) menuType = "portfolio";
        else if (item.textContent.includes("سفارش")) menuType = "serviceRequest";
        else if (item.textContent.includes("تماس")) menuType = "contact";

        item.addEventListener('mouseenter', function () {
            changeText(menuType);
        });
    });

    document.querySelector('.navmenu').addEventListener('mouseleave', function () {
        changeText("home");
    });
});