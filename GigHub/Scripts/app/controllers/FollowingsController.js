var FollowingController = function (followingsService) {

    var button;
    var init = function (container) {
        $(container).on("click", ".js-toggle-follow", toggleFollowing)


    }
    var toggleFollowing = function (e) {
        button = $(e.target)
        var followeeId = button.attr("data-user-id")

        followingsService.addFollowing(followeeId, done, fail);
        followingsService.deleteFollowing(followeeId.done, fail);

    }

    var done = function () {
        var text = (button.text() == "following") ? "follow" : "following";
        button.toggleclass("btn-info").toggleclass("btn-default").text(text);

    }

    var fail = function () {
        alert("SomeThing went Wrong")
    }

    return {
        init:init
    }

}(FollowingService);