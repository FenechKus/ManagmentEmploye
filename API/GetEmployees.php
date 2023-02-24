<?php
    session_start();
    require_once '../vendor/connect.php';
    
  if ($mysqli->connect_errno) {
    printf("Соединение не удалось: %s\n", $mysqli->connect_error);
    exit();
}
    
  
    $employees = mysqli_query($connect, "SELECT * FROM `Employees`;");

    foreach ($employees as $row)
    {	
        $employeesJson[] = $row;
    
        
    }
echo json_encode($employeesJson);
php?>
