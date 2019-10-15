<?php

if(!isset($_GET['passcode']) || $_GET['passcode'] != 'D4fgf23]{3'){
	http_response_code(404);
	die();
}

include 'database.php';

$pdo = Database::connect();
$sql = 'SELECT * FROM Bookings WHERE booking_start_time>= UTC_TIMESTAMP()';

$pdo->query("SET NAMES utf8");

if($stmt = $pdo->prepare($sql)){

	$stmt->execute();
	$data = $stmt->fetchAll(PDO::FETCH_ASSOC);
	$stmt->closeCursor();

	header("content-type:application/json");

	echo json_encode($data);
}

?>