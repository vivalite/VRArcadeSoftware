<?php 
//header("Content-Type: application/json; charset=UTF-8");
include 'database.php';

$data = json_decode(file_get_contents('php://input'), false);

/**/
if($ISDEBUG == true){
	file_put_contents("UpdatePost.log", "\r\n".date("D M d, Y G:i")." ".file_get_contents('php://input'), FILE_APPEND | LOCK_EX);

	ob_start();
	print_r($data);
	file_put_contents("UpdatePostAjax.log", "\r\n".date("D M d, Y G:i")." ".ob_get_clean(), FILE_APPEND | LOCK_EX);
}
/**/


$booking_id = intval($data->item->bookingNumber);
$booking_start_time = gmdate('Y-m-d H:i:s',strtotime($data->item->startTime));
$booking_end_time = gmdate('Y-m-d H:i:s',strtotime($data->item->endTime));
$customer_id = $data->item->customerId;
$booking_num_total = intval($data->item->participants->numbers[0]->number);
$customer_name = $data->item->title;
$customer_email = $data->item->customer->emailAddress;
$customer_phone = $data->item->customer->phoneNumbers[0]->number;
$booking_creation_time = gmdate("Y-m-d H:i:s", time());
$booking_prod_name = $data->item->productName;
$booking_prod_id = $data->item->productId;
$total_paid = floatval($data->item->price->totalPaid->amount);


$pdo = Database::connect();

$pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
$sql = "UPDATE `Bookings` SET `booking_start_time`=?,`booking_end_time`=?,`customer_id`=?,`booking_num_total`=?,`customer_name`=?,`customer_email`=?,`customer_phone`=?,`booking_creation_time`=?,`booking_prod_name`=?,`booking_prod_id`=?,`total_paid`=?,`booking_updated`=UTC_TIMESTAMP() WHERE `booking_id`=?";
$q = $pdo->prepare($sql);
$q->execute(array($booking_start_time,$booking_end_time,$customer_id,$booking_num_total,$customer_name,$customer_email,$customer_phone,$booking_creation_time,$booking_prod_name,$booking_prod_id,$total_paid,$booking_id));
Database::disconnect();


?>