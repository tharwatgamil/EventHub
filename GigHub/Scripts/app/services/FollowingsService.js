var FollowingService = function () {

    var addFollowing = function (followeeId, done, fail) {

        $.post("/api/followings", { followeeId: followeeId })
            .done(done)
            .fail(fail);
    }

    var deleteFollowing = function (followeeId, done, fail) {

        $.ajax({

            url: "/api/followings/" + followeeId,
            method: "DELETE"
        })
            .done(done)
            .fail(fail)
    }

    return {

        addFollowing: addFollowing,
        deleteFollowing: deleteFollowing


    }
}();