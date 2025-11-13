module.exports = {
    content: ["./Pages/**/*.cshtml", "./wwwroot/js/**/*.js"],
    css: [
        "./wwwroot/css/main.css",
        "./wwwroot/lib/bootstrap/dist/css/bootstrap.min.css"
    ],
    output: "./wwwroot/lib/bootstrap/dist/custom/",
    safelist: [
        // Bootstrap core classes
        /^show$/,
        /^collapse$/,
        /^collapsing$/,
        /^fade$/,
        /^modal/,
        /^dropdown/,
        /^nav/,
        /^navbar/,
        /^btn/,
        /^alert/,
        /^toast/,
        /^tooltip/,
        /^offcanvas/,
        /^active$/,
        /^was-validated$/,
        /^is-invalid$/,
        /^is-valid$/,

        // Form and layout related
        /^form-/,
        /^col-/,
        /^row$/,
        /^g-/,
        /^container/,
        /^text-/,
        /^bg-/,

        // Animation or JS-injected classes
        /^aos-/,
    ],
};