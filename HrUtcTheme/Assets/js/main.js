
$(document).ready(function () { $(document).on("click", "#button1", function () { $("#modal1").modl("hide"), $("#modal2").modal("show") }), $(".projects-carousel").slick({ dots: !1, infinite: !1, speed: 300, slidesToShow: 5, slidesToScroll: 1, responsive: [{ breakpoint: 1200, settings: { slidesToShow: 4 } }, { breakpoint: 992, settings: { slidesToShow: 3 } }, { breakpoint: 600, settings: { slidesToShow: 2 } }] }), $(document).on("click", "#test .question .btn-prev", function () { $("#test .question.active").prev().addClass("prev"), $("#test .question").removeClass("active"), $("#test .question.prev").addClass("active").removeClass("prev") }), $(document).on("click", "#test .question .btn-next", function () { $("#test .question.active").next().addClass("next"), $("#test .question").removeClass("active"), $("#test .question.next").addClass("active").removeClass("next") }) });