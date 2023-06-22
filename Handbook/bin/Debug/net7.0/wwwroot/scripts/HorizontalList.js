console.log("Connecting")
document.addEventListener("DOMContentLoaded", function () {
    let buttons = document.querySelectorAll(".vertical-list li button");
    for (let button of buttons) {
        button.addEventListener("click", function () {
            console.log("click");
            let sublist = this.nextElementSibling;
            sublist.classList.toggle("show");
        });
    }
});