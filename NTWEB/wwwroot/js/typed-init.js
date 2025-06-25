document.addEventListener("DOMContentLoaded", function () {
    const typedElement = document.querySelector('.typed');
    if (!typedElement) {
        /*        console.error("Element .typed not found in the DOM!");*/
        return;
    }

    const menuTexts = {
        "home": ["درود، به سایتم خوش اومدی!"],
        "resume": ["برنامه‌نویس ASP.NET"],
        "about": ["دانش آموخته مولتی‌مدیا!", "علاقه‌مند به تکنولوژی و هنر"],
        "portfolio": ["معمار صداهای خاص!", "تولیدکننده پادکست‌های حرفه‌ای"],
        "serviceRequest": ["ارائه خدمات برنامه‌نویسی و طراحی!"],
        "contact": ["منتظر پیام شما هستم!"]
    };

    let currentStrings = ["درود، به سایتم خوش اومدی!"];

    let typed = new Typed('.typed', {
        strings: currentStrings,
        typeSpeed: 30,
        backSpeed: 30,
        backDelay: 1000,
        startDelay: 500,
        loop: true,
        smartBackspace: true,
        showCursor: true,
        cursorChar: '▌',
    });

    let lastMenuType = "home";
    let isChanging = false;
    let changeTimeout;

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

            if (isChanging || menuType === lastMenuType) {
                return;
            }

            clearTimeout(changeTimeout);
            isChanging = true;

            changeTimeout = setTimeout(() => {
                typed.destroy();

                typed = new Typed('.typed', {
                    strings: menuTexts[menuType],
                    typeSpeed: 30,
                    backSpeed: 30,
                    backDelay: 1000,
                    startDelay: 100,
                    loop: true,
                    smartBackspace: true,
                    showCursor: true,
                    cursorChar: '▌',
                });

                lastMenuType = menuType;
                isChanging = false;
            }, 200);
        });
    });

    document.querySelector('.navmenu').addEventListener('mouseleave', function () {
        if (isChanging || lastMenuType === "home") {
            return;
        }

        clearTimeout(changeTimeout);
        isChanging = true;

        changeTimeout = setTimeout(() => {
            typed.destroy();

            typed = new Typed('.typed', {
                strings: menuTexts["home"],
                typeSpeed: 30,
                backSpeed: 30,
                backDelay: 1000,
                startDelay: 100,
                loop: true,
                smartBackspace: true,
                showCursor: true,
                cursorChar: '▌',
            });

            lastMenuType = "home";
            isChanging = false;
        }, 200);
    });
});