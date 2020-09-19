
var GigsController = function (attendanceService) {

    var button;

    var init = function (container) {                              // private

        $(container).on("click", ".js-toggle-attendance", toggleAttendance)
    };

    var toggleAttendance = function (e) {
         button = $(e.target);
        var gigId = button.attr("data-gig-id")
        if (button.hasClass("btn-default")) {

            attendanceService.createAttendance(gigId, done, fail)
        }
         else {

            attendanceService.deleteAttendance(gigId, done, fail)
        }
    }


    var done = function () {
        var text = (button.text() == "going?") ? "going" : "going?"
        button.toggleClass("btn-info").toggleClass("btn-default").text(text);
    }

    var fail = function () {
        alert("Something went Wrong")
    }


    return {
        init: init     //public 
    }

}(AttendanceService);
