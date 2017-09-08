$(document).ready(function () {

    $('.action').click(function () {
        var id = $(this).attr("id")
        $.get("/" + id, function (res) {
            var img = "<img src='/images/" + res.img + ".png'>";
            if (res.status == "gameover" || res.status == "win")
                {
                    var html_str = "<form action='/restart'><input type='submit' value='Restart?'></form>"
                    $("#buttons").html(html_str);
                    $("#energy").text(res.pet.energy);
                    $("#fullness").text(res.pet.fullness);
                    $("#meals").text(res.pet.meals);
                    $("#happiness").text(res.pet.happiness);
                    $("#image").html(img);
                    $("#msg").text(res.message);
                }
            else
                {
                    $("#energy").text(res.pet.energy);
                    $("#fullness").text(res.pet.fullness);
                    $("#meals").text(res.pet.meals);
                    $("#happiness").text(res.pet.happiness);
                    $("#image").html(img);
                    $("#msg").text(res.message);
                }
        }, 'json');
    });
});