$(document).ready(function () {
    /* function called when you click of the button */
    $("btnrespnav").click(function () {

        /* this if else to change the text in the button */
        if ($("btnrespnav").text() == "☰") {
            $("btnrespnav").text("🞬");
        } else {
            $("btnrespnav").text("☰");
        }

        /* this function toggle the visibility of our "li" elements */
        $("li").toggle("slow");
    });
});