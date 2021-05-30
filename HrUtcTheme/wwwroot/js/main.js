function generateQuizClickHandler(quizId) {
    $(document).on("click", `${quizId} .question .btn-prev`, function () {
        $(`${quizId} .question.active`).prev().addClass("prev");
        $(`${quizId} .question`).removeClass("active");
        $(`${quizId} .question.prev`).addClass("active").removeClass("prev");
    });
    $(document).on("click", `${quizId} .question .btn-next`, function () {
        $(`${quizId} .question.active`).next().addClass("next");
        $(`${quizId} .question`).removeClass("active");
        $(`${quizId} .question.next`).addClass("active").removeClass("next");
    })
}

$(document).ready(function () {


    $(document).on("click", "#button1", function () {
        $("#modal1").modal("hide");
        $("#modal2").modal("show");
    });

    $(".projects-carousel").slick({
        dots: !1,
        infinite: !1,
        speed: 300,
        slidesToShow: 5,
        slidesToScroll: 1,
        responsive: [{breakpoint: 1200, settings: {slidesToShow: 4}}, {
            breakpoint: 992,
            settings: {slidesToShow: 3}
        }, {breakpoint: 600, settings: {slidesToShow: 2}}]
    });

});