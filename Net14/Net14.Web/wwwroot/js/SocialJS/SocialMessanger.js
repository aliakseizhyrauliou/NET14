﻿$(document).ready(function () {
    var isWorking = false;


    $(".main-message-container").scrollTop($(".main-message-container").prop('scrollHeight'));

    const hubConnection = new signalR.HubConnectionBuilder()
        .withUrl("/messages")
        .build();


    $(".message-input").keyup(function () {
        if ($(".message-input").val() === "")
        {
            return;
        }
        let userId = $(".dialog-user-info").data("id");
        hubConnection.invoke("IsTyping", userId.toString());
    });

    hubConnection.on("IsTyping", function () {
        if (isWorking)
        {
            return;
        }

        isWorking = true;

        var pointCount = 0;
        var element = $(".is-typing");
        element.show();

        const showPoints = setInterval(startPoints, 500);

        setTimeout(stopPoints, 6000);
        

        function startPoints() {
            if (pointCount == 3) {
                element.text("Is typing");
                pointCount = 0;
            }
            else {
                element.text(element.text() + ".");
                pointCount++;
            }
        }

        function stopPoints()
        {
            clearInterval(showPoints);
            element.text("Is typing");
            isWorking = false;
            element.hide();
        }


    })

    $(".message-send-button").click(function (e) {
        e.preventDefault();
        var time = new Date();
        let messageText = $(".message-input").val().toString();
        if (isEmpty(messageText))
        {
            return;
        }
        $(".message-input").val('');
        let userId = $(".dialog-user-info").data("id");
        let data = { Message: messageText, UserId: userId };

        jQuery.ajax({
            url: "/api/SocialMessages/SendMessage",
            type: "POST",
            data: JSON.stringify(data),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
        }).done(function () {
            sentMessage.find(".check-mark-left.template").removeClass("template");
        });

        hubConnection.invoke("SendMessage", messageText, userId.toString());
        let sentMessage = $(".single-message-sent.template").clone();
        let text = $("<span>").text(messageText);
        sentMessage.find(".txt").append(text);
        sentMessage.find(".text-time").text(time.toLocaleTimeString().slice(0, -3));
        sentMessage.appendTo(".main-message-container");
        sentMessage.removeClass("template");
        $(".main-message-container").scrollTop($(".main-message-container").prop('scrollHeight'));
    });


    hubConnection.on("RecievedMessage", function (recievedMessage, date) {
        let dialogFriendId = $(".dialog-user-info").attr("data-id");
        let messageRecieved = $(".single-message-recieved.template").clone();
        messageRecieved.find(".txt").text(recievedMessage);
        messageRecieved.find(".recieved-time").text(date);
        messageRecieved.appendTo(".main-message-container");
        messageRecieved.removeClass("template");
        $(".main-message-container").scrollTop($(".main-message-container").prop('scrollHeight'));
        $.get("/api/SocialMessages/ViewMessage", { userId: parseInt(dialogFriendId)})
            .done(function () {
                hubConnection.invoke("MessagesAreViewed", dialogFriendId);
            });
    });

    hubConnection.on("MessagesAreViewed", function () {
        $("div[class=single-message-sent]").each(function (index) {
            $(this).find(".check-mark-right.template").removeClass("template");
        });

    });


    hubConnection.start();
});


function isEmpty(str) {
    if (str.trim() == '')
        return true;

    return false;
}
