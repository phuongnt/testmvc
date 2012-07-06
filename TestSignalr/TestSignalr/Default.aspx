<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TestSignalr.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="Scripts/jquery-1.6.4.min.js"></script>
    <script type="text/javascript" src="Scripts/jquery.signalR-0.5.2.min.js"></script>
   <script src="/signalr/hubs" type="text/javascript"></script>
 
   <script type="text/javascript">
       $(function () {
           //var connection = $.connection('echo');

           //connection.received(function (data) {
           //    $('#messages').append('<li>' + data + '</li>');
           //});

           //connection.start();

           //$("#broadcast").click(function () {
           //    connection.send($('#msg').val());
           //});


           // Proxy created on the fly
           var chat = $.connection.chat1;

           // Declare a function on the chat hub so the server can invoke it
           chat.addMessage = function (message) {
               $('#messages').append('<li>' + message + '');
           };

           $("#broadcast").click(function () {
               // Call the chat method on the server
               chat.send($('#msg').val());
           });
          
           // Start the connection
           $.connection.hub.start();
       });
    </script>
</head>
<body>
    <input id="msg"/>
    <input id="broadcast" type="button"/>
    <ul id="messages"></ul>
</body>
</html>






