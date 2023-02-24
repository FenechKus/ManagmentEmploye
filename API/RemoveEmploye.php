<?php
    session_start();
    require_once '../vendor/connect.php';
    
     $Id_Arg = $_GET['id'];
    
    $result = mysqli_query($connect, "DELETE FROM `Employees` WHERE `Employees`.`Id` = $Id_Arg");
    
php?>
