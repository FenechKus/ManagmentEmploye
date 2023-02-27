<?php
    session_start();
    require_once '../vendor/connect.php';
    
     $FirstName_arg = $_GET['FName'];
    $LastName_arg = $_GET['LName'];
    $Age_arg = (int)$_GET['Age'];
    $Position_arg = $_GET['Position'];
    $Salary_arg = (int)$_GET['Salary'];
    
    mysqli_query($connect, "INSERT INTO `Employees` (`Id`, `FirstName`, `LastName`, `Age`, `Position`, `Salary`) 
    VALUES (NULL, '$FirstName_arg', '$LastName_arg', '$Age_arg', '$Position_arg', '$Salary_arg');");
    echo "Success";
php?>
