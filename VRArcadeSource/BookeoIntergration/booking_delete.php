<?php 
//header("Content-Type: application/json; charset=UTF-8");
include 'database.php';

$data = json_decode(file_get_contents('php://input'), false);

/**/
if($ISDEBUG == true){
	file_put_contents("DeletePost.log", "\r\n".date("D M d, Y G:i")." ".file_get_contents('php://input'), FILE_APPEND | LOCK_EX);

	ob_start();
	print_r($data);
	file_put_contents("DeletePostAjax.log", "\r\n".date("D M d, Y G:i")." ".ob_get_clean(), FILE_APPEND | LOCK_EX);
}
/**/


$booking_id = intval($data->item->bookingNumber);

$pdo = Database::connect();

$pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
$sql = "UPDATE `Bookings` SET `booking_deleted`=UTC_TIMESTAMP() WHERE `booking_id`=?";
$q = $pdo->prepare($sql);
$q->execute(array($booking_id));
Database::disconnect();


?>