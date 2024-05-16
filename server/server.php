<?php
use PHPMailer\PHPMailer\PHPMailer;
use PHPMailer\PHPMailer\Exception;

require 'phpmailer/src/Exception.php';
require 'phpmailer/src/PHPMailer.php';
require 'phpmailer/src/SMTP.php';

$mail = new PHPMailer(true);

$name = $_REQUEST["name"];
$email = $_REQUEST["email"];
$message = $_REQUEST["message"];
$date = $_REQUEST["date"];

$mail->isSMTP();
$mail->isHTML(true);
$mail->Host = 'smtp.gmail.com';
$mail->SMTPAuth = true;
$mail->Username = 'myipshit@gmail.com';
$mail->Password = 'gvydnegtqushkutn';
$mail->SMTPSecure = 'ssl';
$mail->Port = 465;

$mail->setFrom($email, 'From ' . $name);
$mail->addAddress($email, 'Recipient Name');

$mail->isHTML(false);
$mail->Subject = 'Feedback message';
$mail->Body = $message. "\n". $date;

if(!$mail->send()){
    echo 'Message could not be sent. Mailer Error: ' . $mail->ErrorInfo;
} else {
    echo 'Message has been sent';
}