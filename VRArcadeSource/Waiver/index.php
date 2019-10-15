<?php 

require_once 'Phery.php';

PheryResponse::set_global('global', true);



function form($data)
{	
	$firstname = ""; $lastname = ""; $address = ""; $city = ""; $province = ""; 
	$postcode = ""; $cell = ""; $dob = ""; $email = ""; $signfilename = "";
	
	$soapClient = new SoapClient('http://localhost:20017/VRArcadeDashboardService/?wsdl');
	
	$servername = "localhost";
	$username = "vrarcade";
	$password = "vrarcade";
	$dbname = "vrarcade";
	
	$conn = new mysqli($servername, $username, $password, $dbname) OR die("Connection failed: " . $conn->connect_error);
	
	foreach ($data as $key => $ditem){
		switch($key){
			case "first-name":
				$firstname = mysqli_real_escape_string($conn, $ditem);
			break;
			case "last-name":
				$lastname = mysqli_real_escape_string($conn, $ditem);
			break;
			case "postcode":
				$postcode = mysqli_real_escape_string($conn, $ditem);
			break;
			case "cell":
				$cell = mysqli_real_escape_string($conn, $ditem);
			break;
			case "dob":
				$dob = mysqli_real_escape_string($conn, date("Y-m-d H:i:s", strtotime($ditem)));
			break;
			case "email":
				$email = mysqli_real_escape_string($conn, $ditem);
			break;
			case "reference":
				$reference = mysqli_real_escape_string($conn, $ditem);
			break;
			case "signdata":
				if( substr( $ditem, 0, 5 ) === "data:" ) {  
					$signfilename=save_base64_image($ditem, "", getcwd() . "\\signatures\\"); 
				}
			break;
		}
	}

	// get booking reference
	$refID = 'NULL';	
	$sql = "SELECT id FROM vrbookingreferences WHERE reference = '".trim($reference)."' AND numberofbookingleft > 0 AND TIMESTAMPDIFF(MINUTE, bookingstarttime, NOW()) < 60 AND bookingdeleted IS NULL LIMIT 1";
	$result = $conn->query($sql);
	if ($result && $result->num_rows > 0) {
		while($row = $result->fetch_assoc()) {
			$refID = $row["id"];
		}
	}
	
	// insert waiver data
	$insert_id = 0;
	$sql = "INSERT INTO `vrarcade`.`vrwaiverlogs`(`firstname`,`lastname`,`postcode`,`cell`,`dob`,`email`,`signfilename`, `timestampcreate`, `isnewentry`, `isdeleted`, `bookingreferenceid`)
		VALUES('".$firstname."','".$lastname."','".$postcode."','".$cell."','".$dob."','".$email."','".$signfilename."','".date('Y-m-d H:i:s')."', 1, 0, ".$refID.");";
	$conn->query($sql);
	$insert_id = $conn->insert_id;
	
	if($refID != 'NULL'){
		//$sql = "UPDATE bookingreferences SET numberofbookingleft = numberofbookingleft - 1 WHERE id = ".$refID; // TODO: should do this in server
		//$conn->query($sql);
		
		$result = $soapClient->PrintBarcodeWithBookingReference(array('bookingRef' => trim($reference), 'waiverID' => $insert_id));
	
		/*if (!empty($result->PrintBarcodeWithBookingReferenceResult)) {
			echo 'The username is: '.$result->PrintBarcodeWithBookingReferenceResult;
		}*/
	}
	
	$conn->close();

	
	/**/return
		PheryResponse::factory('div.test:eq(0)')
		->text(print_r($sql, true));/**/

}

function timeout($data, $parameters)
{
	$r = PheryResponse::factory();	session_write_close(); // Needed because it will hang future calls, when using CSRF

	if (isset($data['callback']) && !empty($parameters['retries']))
	{
		// The URL will have a retries when doing a retry
		return $r->dump_vars('Second time it worked, no error callback call ;)');
	}
	sleep(5); // Sleep for 5 seconds to timeout the AJAX request, and trigger our retry
	return $r;
}

function save_base64_image($base64_image_string, $output_file_without_extentnion, $path_with_end_slash="" ) {
    //usage:  if( substr( $img_src, 0, 5 ) === "data:" ) {  $filename=save_base64_image($base64_image_string, $output_file_without_extentnion, getcwd() . "/application/assets/pins/$user_id/"); }      
    //
    //data is like:    data:image/png;base64,asdfasdfasdf
    $output_file_with_extentnion = "";
	
	if($output_file_without_extentnion == ""){
		$output_file_without_extentnion = time().uniqid(); 
	}
	$splited = explode(',', substr( $base64_image_string , 5 ) , 2);
    $mime=$splited[0];
    $data=$splited[1];

    $mime_split_without_base64=explode(';', $mime,2);
    $mime_split=explode('/', $mime_split_without_base64[0],2);
    if(count($mime_split)==2)
    {
        $extension=$mime_split[1];
        if($extension=='png')$extension='png';
        if($extension=='jpeg')$extension='jpg';
        if($extension=='svg+xml')$extension='svg';
        $output_file_with_extentnion.=$output_file_without_extentnion.'.'.$extension;
    }
    file_put_contents( $path_with_end_slash . $output_file_with_extentnion, base64_decode($data) );
    return $output_file_with_extentnion;
}





$phery = new Phery;

try
{
	$phery->config(
		array(
			/**
			 * Throw exceptions and return them in form of PheryException,
			 * usually for debug purposes. If set to false (default), it fails
			 * silently
			 */
			'exceptions' => true,
			/**
			 * Enable CSRF protection, needs to use Phery::instance()->csrf() on your
			 * HTML head, to print the meta
			 */
			'csrf' => false
		)
	)
	/**
	 * Set the aliases for the AJAX calls
	 */
	->set(array(
		// Trigger even on another element
		'form' => 'form',
		// Timeout
		'timeout' => 'timeout',

	))
	/**
	 * process(false) mean we will call phery again with
	 * process(true)/process() to end the processing, so it doesn't
	 * block the execution of the other process() call
	 */
	->process(false);	$csrf_token = $phery->csrf();

	/**
	 * To separate the callback from the rest of the other functions,
	 * just call a second process()
	 */
	

	$phery
	->config(array(
		// Catch ALL the errors and use the internal error handler
		'error_reporting' => E_ALL
	))
	->callback(array('before' => array(), 'after' => array()))
	->set(array(
		
	))
	->process();
}
catch (PheryException $exc)
{
	/**
	 * will trigger for "nonexistant" call
	 * This will only be reached if 'exceptions' is set to TRUE
	 * Otherwise it will fail silently, and return an empty
	 * JSON response object {}
	 */
	Phery::respond(
		PheryResponse::factory()
		->renew_csrf($phery)
		->exception($exc->getMessage())
	);
	exit;
}

?>
<!doctype html>
<html lang="en">
<!--div class="test" style="border:solid 1px #000; padding: 20px;">Div.test</div-->
	<head>
		<meta name="viewport" content="initial-scale=1,user-scalable=no,maximum-scale=1">
		<meta content-type="application/xhtml+xml" charset="utf-8" />
		<meta name="description" content="">
		<title>VR Zone Virtual Reality Arcade : Waiver</title>
		<?php echo $csrf_token; ?>
		
		<script src="js/jquery.min.js"></script>
		<script src="js/jquery.validate.min.js"></script>
		<script src="js/toastr.min.js"></script>
		<script src="js/owl.carousel.js"></script>
		<script src="js/signature_pad.js"></script>
		<script src="js/phery.min.js" type="text/javascript"></script>
		<script src="js/app.js"></script>

		<script>
			phery.config({
				/*
				 * Retry one more time, if fails, then trigger events.error
				 */
				'ajax.retries':1,
				/* 2 seconds timeout for AJAX
				/* any AJAX option can be set through jQuery
				 */
				'ajax.timeout': 5000,
				/*
				 * Enable phery:* events on elements
				 */
				'enable.per_element.events':true,
				/*
				 * Enable logging and output to console.log.
				 * Shouldn't be enabled on production because
				 * of building up an internal log of messages
				 */
				'enable.log':true,
				/*
				 * Log messages that can be accessed on phery.log()
				 */
				'enable.log_history':true,
				/*
				 * Enable inline loading of responses
				 */
				'inline.enabled': true
			});
			
			function Validatize() {
				
				jQuery.validator.addMethod("cdnPostal", function(postal, element) {
					return this.optional(element) || 
					postal.match(/[a-zA-Z][0-9][a-zA-Z](-| |)[0-9][a-zA-Z][0-9]/);
				}, "Please specify a valid postal code.");
				
				$('#waiverform').validate({
					onfocusout: function (element) {
						$(element).valid();
					},
					onkeyup: false,
					rules: {
						postal_code: true,
						cdnPostal: true,
						reference:{
							//ReferenceCheck: true,					
							remote:  {
									url: "check_ref.php",
									type: "post",
									data: {
										BookingReference: function() {
											return $("#reference").val();
										}
									}
							}
						} 
					},
					errorPlacement: function(error, element) { },			
					invalidHandler: function(event, validator) {
						var errors = validator.numberOfInvalids();
						if (errors) {
						  var message = errors == 1
							? 'You have error in 1 field. It has been highlighted.'
							: 'You have error in ' + errors + ' fields. They have been highlighted.';
						  setTimeout("doGoToErrorTab()", 100);
						  
						  toastr["warning"](message);
						}
					},			
					submitHandler: function(form) {
						
						if (!$("#checkbox").is(':checked')) {
							toastr["warning"]("Please check the box if you agree.");
						}else if (signaturePad.isEmpty()) {
							toastr["warning"]("Please provide your signature use your finger.");
						}else{
							$("#signdata").val(signaturePad.toDataURL());
							$("Button.save").attr('disabled','disabled');
							$(form).phery('remote');
							playSuccess();
							toastr["success"]("Submitted!");
							setTimeout("location.reload();",5000);
						}
						
					}
				});
			}
			
			$(function () {
				var $form = $('#waiverform');

				var $submit = $form.phery('data', 'submit');
				//$submit["disabled"] = true;
				//$submit["all"] = true;
				$form.phery('data', 'submit', $submit);
				
				Validatize();
			});
		</script>
		
		<link rel="stylesheet" href="stylesheets/owl.carousel.css">
		<!-- <link rel="stylesheet" href="stylesheets/signature-pad.css"> -->
		<link rel="stylesheet" href="stylesheets/toastr.min.css">
		<link rel="stylesheet" href="stylesheets/style.css">
		

	</head>

	<body class="waiver">
	<?php
	/* form_for is a helper function that will create a form that is ready to be submitted through phery
	 * any additional arguments can be passed through 'args', works kinda like an input hidden,
	 * but will only be submitted if javascript is enabled
	 * -------
	 * 'all' on 'submit' will submit every field, even checkboxes that are not checked
	 * 'disabled' on 'submit' will submit fields that are disabled
	 */
	echo Phery::form_for('', 'form', array('id' => 'waiverform', 'submit' => array('disabled' => false, 'all' => true), 'related' => null, 'args' => null));
	?>
		<header>
			<hgroup>
				<h3>VR Zone Virtual Reality Arcade</h3>
				<h1>Waiver &amp; Release of Liability</h1>
			</hgroup>
		</header>
		<form id="waiver" action="/patrons" method="post">
			<div id="carousel">
				<div class="details wtab tab1">
					<table cellpadding="0" cellspacing="0" width="100%">
						<tr>
							<td width="48%">
								
									<label for="first-name">First Name</label>
									<input type="text" name="first-name" id="first-name" placeholder="First Name" autocomplete="off" required />
								
							</td>
							<td width="48%">
								<label for="last-name">Last Name</label>
								<input type="text" name="last-name" id="last-name" placeholder="Last Name" autocomplete="off" required />
							</td>
						</tr>
						<tr>
							<td>
								<label for="postcode">Postcode</label>
								<input type="text" name="postcode" id="postcode" placeholder="Postcode" autocomplete="off" style="text-transform: uppercase" required data-rule-cdnPostal="true"/>
							</td>
							<td>
								<label for="cell">Phone Number</label>
								 <input type="tel" inputmode="tel" name="cell" id="cell" placeholder="Phone Number" autocomplete="off" required />
							</td>
						</tr>
						<tr>
							<td>
								<label for="email">Email Address</label>
								 <input type="email" inputmode="email" name="email" id="email" placeholder="yourname@email.com" autocomplete="off" required />
							</td>
							<td>
								<label for="dob">Date of Birth</label>
								<input type="date" name="dob" id="dob" required />
							</td>
						</tr>
						<tr>
							<td width="48%">
								<label for="dob">Booking Reference <span style="font-weight:normal;font-style: italic;">(If you don't have one with you, please leave this box empty and let our staff know upon finish the waiver.)</span></label>
								<input type="number" min="0" inputmode="numeric" pattern="[0-9]*" name="reference" id="reference" autocomplete="off"/>
							</td>
							<td width="48%">
								
							</td>
						</tr>
					</table>
				</div> <!-- End Details Form -->

				<div class="waiver one wtab tab3">
					
					<p class="highlight">
						In consideration of being allowed to participate in any way in VR Zone Virtual Reality Arcade, related events and activities, I <span id="divParName"></span>, the undersigned acknowledge, appreciate, and agree that:
					</p>

					<ol>
						<li>The risk of injury from the activities involved in this program exist, including the potential for permanent paralysis and death, and while particular rules, equipment, and personal discipline may reduce this risk, the risk of serious injury does exist: and,</li>

						<li>I am aware that the usual risks, hazards and dangers of personal injury, death and disability increase when using equipment or device. I also understand that these risks, hazards and dangers are further increased when other persons, whether of the same level of experience or skill, are using the same facilities; and,</li>
					</ol>
				</div> <!-- End Page 1 -->

				<div class="waiver two wtab tab4">
					<ol start="3">
						<li>I KNOWINGLY AND FREELY ASSUME ALL SUCH RISKS, both known and unknown, EVEN IF ARISING FROM THE NEGLIGENCE OF RELEASEES or others, and assume full responsibility for my participation; and,</li>

						<li>I willingly agree to comply with the stated and customary terms and conditions for participation. If, however, I observe any unusual significant hazard during my presence or participation, I will remove myself from participation and bring such to the attention of the nearest official immediately; and,</li>

						<li>By this Agreement, it is my intention to surrender and waive any rights to sue or exercise any legal right to seek damages from VR Zone Inc. and their agents, servants, employees, officers, directors, trustees and all other persons or entities acting on their behalf; and,</li>
					</ol>
				</div> <!-- End Page 2 -->

				<div class="waiver three wtab tab5">
					<ol start="6">
						<li>I acknowledge that my participation in or the viewing and spectating of activities at VR Zone Virtual Reality Arcade is strictly voluntary in spite of the risks and dangers and that no one is forcing me to participate or view and spectate; and,</li>

						<li>I give my consent and permission to VR Zone Inc. to obtain on my behalf of myself any emergency medical treatment in case of sickness, accident or injury and to secure such medical attention at my expense; and,</li>

						<li>I, for myself and on behalf of my heirs, assigns, personal representatives, and next of kin, HEREBY RELEASE AND HOLD HARMLESS VR Zone Inc., their officers, officials, agents and/or employees, other participants, sponsoring agencies, sponsors, advertisers, and, if applicable, owners and lessors of premises used to conduct the event (Releases). WITH RESPECT TO ANY AND ALL INURY, DISABILITY, DEATH, or loss or damage to person or property, WHETHER ARISING FROM THE NEGLIGENCE OF THE RELEASEES OR OTHERWISE.</li>
					</ol>
				</div> <!-- End Page 3 -->

				<div class="waiver confirmation wtab tab6">
					<label>
						<div class="checkbox">
							<input type="checkbox" value="yes" id="checkbox" name="agree" />
							<label for="checkbox"></label>
						</div> <!-- End Checkbox -->

						<p class="highlight">By checking this box, I hereby certify that I have read this Release of Liability and Assumption of Risk Agreement, fully understand its terms, understand that I have given up substantial rights by signing it, and sign it freely and voluntarily without any inducement. I am aware that by signing this agreement, I assume all risks and waive and release certain substantial rights that I may possess.</p>
					</label>

					<div id="signature-pad" class="m-signature-pad">
						
						<div class="m-signature-pad--body">
							<canvas> </canvas>
						</div> <!-- End Signature Body -->

						<div class="m-signature-pad--footer">
							<div class="description">Please Use Finger Sign Here</div>
							
							<button class="button clear" type="button" data-action="clear">Clear the signature</button>
							<button class="button save" type="button" data-action="save">I'm done! Submit the waiver</button>
						</div> <!-- End Signature Footer -->
						
					</div> <!-- End Signature Pad -->
					<input type="hidden" name="signdata" id="signdata" value="">
				</div> <!-- End Waiver Confirmation -->
			</div> <!-- End Carousel -->    
		<?php echo '</form>'; ?>
		
		<audio id="audioSuccess" src="audio/success.wav" ></audio>
	</body>
</html>