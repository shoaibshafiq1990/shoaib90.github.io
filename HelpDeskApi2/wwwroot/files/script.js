
var typed = new Typed(".text", {
    strings: ["Flutter" , "Oracle Apex" , "Web Development" , "Oracle EBS" , "C#, Blazor,MVC,.Net MAUI"],
    typeSpeed:100,
    backSpeed:100,
    backDelay:1000,
    loop:true
});


const toTop = document.querySelector(".top");
window.addEventListener("scroll",() =>{
    if (window.pageYOffset > 100){
        toTop.classList.add("active");
    }
    else{
        toTop.classList.remove("active");
    }
})