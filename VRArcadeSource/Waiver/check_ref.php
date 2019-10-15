<?php
	
	$return = $_POST;

	$servername = "localhost";
	$username = "vrzone";
	$password = "vrzone";
	$dbname = "vrzone";
	
	$conn = new mysqli($servername, $username, $password, $dbname) OR die("Connection failed: " . $conn->connect_error);
	
	$bookRef = mysqli_real_escape_string($conn, $_POST['BookingReference']);
	
	$sql = "SELECT id FROM vrbookingreferences WHERE reference = '".trim($bookRef)."' AND numberofbookingleft > 0 AND TIMESTAMPDIFF(MINUTE, bookingstarttime, NOW()) < 60 AND bookingdeleted IS NULL LIMIT 1";
	$result = $conn->query($sql);
	if ($result && $result->num_rows > 0) {
		echo "true";
	}else{
		echo "false";
	}
	
	$conn->close();	

?>