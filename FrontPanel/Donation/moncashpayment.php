<!DOCTYPE html>
<html lang="en">
<head>
	<title>Plaza49</title>
	<meta charset="UTF-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">
<!--===============================================================================================-->	
	<link rel="icon" type="image/png" href="images/icons/favicon.png"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendor/bootstrap/css/bootstrap.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="fonts/fontawesome-5.0.8/css/fontawesome-all.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="fonts/iconic/css/material-design-iconic-font.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendor/animate/animate.css">
<!--===============================================================================================-->	
	<link rel="stylesheet" type="text/css" href="vendor/css-hamburgers/hamburgers.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendor/animsition/css/animsition.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="css/util.min.css">
<!--===============================================================================================-->	
	<link rel="stylesheet" type="text/css" href="css/main.css">
<!--===============================================================================================-->
</head>
<body class="animsition">
	
	<!-- Header -->
	<header>
		
	</header>
		
	<!-- Headline -->
	<div class="container">
		<div class="bg0 flex-wr-sb-c p-rl-20 p-tb-8">
			<div class="f2-s-1 p-r-30 size-w-0 m-tb-6 flex-wr-s-c">
				<span class="text-uppercase cl2 p-r-8">
					Plaza 49:
				</span>

				<span class="dis-inline-block cl6 slide100-txt pos-relative size-w-0" data-in="fadeInDown" data-out="fadeOutDown">
					<span class="dis-inline-block slide100-txt-item animated visible-false">
						Ecommerce website
					</span>
					
					<span class="dis-inline-block slide100-txt-item animated visible-false">
					Pay with Moncash
					</span>

					<span class="dis-inline-block slide100-txt-item animated visible-false">
						Pay with Stripe
					</span>
				</span>
			</div>

			<div class="pos-relative size-a-2 bo-1-rad-22 of-hidden bocl11 m-tb-6">
				<input class="f1-s-1 cl6 plh9 s-full p-l-25 p-r-45" type="text" name="search" placeholder="Search">
				<button class="flex-c-c size-a-1 ab-t-r fs-20 cl2 hov-cl10 trans-03">
					<i class="zmdi zmdi-search"></i>
				</button>
			</div>
		</div>
	</div>
	
	<?php 

			ini_set('display_errors', 1);

		    require_once 'moncash/vendor/autoload.php';

		    use DGCGroup\MonCashPHPSDK\Credentials;
		    use DGCGroup\MonCashPHPSDK\Configuration;
		    use DGCGroup\MonCashPHPSDK\PaymentMaker;
		    use DGCGroup\MonCashPHPSDK\Order;
		    use DGCGroup\MonCashPHPSDK\TransactionCaller;
		    use DGCGroup\MonCashPHPSDK\TransactionDetails;
		    use DGCGroup\MonCashPHPSDK\TransactionPayment;

		    // Instanciation of the payment class
		    $client = "66524410431d03d57aeaa91d104b71b4";
		    $secret = "jPeUogoUmS7nsqNEwE_zuQ16sCm-eZb39Iy1gMtv9zSuUPs1wbEEXMVlcQn1ROEp";
		    $configArray = Configuration::getSandboxConfigs();
		    $test = new Credentials($client, $secret, $configArray);
			
			// Connexion à la base de données
try
{
	$bdd = new PDO('mysql:host=50.62.209.17:3306;dbname=taux;charset=utf8', 'taux', 'Opulence1234$');
}
catch(Exception $e)
{
        die('Erreur : '.$e->getMessage());
}

// Récupération des 10 derniers messages
$reponse = $bdd->query('SELECT taux FROM taux where id=1');

// Affichage de chaque message (toutes les données sont protégées par htmlspecialchars)
while ($donnees = $reponse->fetch())
{
	$Letaux= $donnees['taux'] ;
	
}

$reponse->closeCursor();


	?>
		
	<!-- Feature post -->
	<section class="bg0">
		<div class="container">
			<div class="row m-rl--1">
				<div class="col-sm-6 col-lg-4 p-rl-1 p-b-2">

					<div class="bg-img1 size-a-12 how1 pos-relative" style="background-image: url(images/pR1.jpg);">
						<a href="blog-detail-01.html" class="dis-block how1-child1 trans-03"></a>
						
						
									<?php							    

									    if(!isset($_GET['paymentDetails'])){
											$prix= 10;
											$calTaux= $Letaux * $prix;
									    	$amount = $calTaux;
											
										    $orderId = 9876543253;

										    $theOrder = new Order( $orderId, $amount );

										    $paymentObj = PaymentMaker::makePaymentRequest( $theOrder, $test, $configArray );
									    }    

  									?>

						<div class="flex-col-e-s s-full p-rl-25 p-tb-11">
							<a href='<?php echo $paymentObj->getRedirect();?>' class="dis-block how1-child2 f1-s-2 cl0 bo-all-1 bocl0 hov-btn1 trans-03 p-rl-5 p-t-2">
							10$ :
											<img style="width: 100px;" src='https://moncashbutton.digicelgroup.com/Moncash-middleware/resources/assets/images/MC_button.png' >
							</a>

							<h3 class="how1-child2 m-t-10">
								<a href="blog-detail-01.html" class="f1-m-1 cl0 hov-cl10 trans-03">
						             Bright Vibe Knit Necktie
								</a>
							</h3>
						</div>
					</div>
				</div>
				
				<div class="col-sm-6 col-lg-4 p-rl-1 p-b-2">
					<div class="bg-img1 size-a-12 how1 pos-relative" style="background-image: url(images/pR2.jpg);">
						<a href="blog-detail-01.html" class="dis-block how1-child1 trans-03"></a>
                              <?php							    

									    if(!isset($_GET['paymentDetails'])){
									    	$prix= 15;
											$calTaux= $Letaux * $prix;
									    	$amount = $calTaux;
											
										    $orderId = 9876543252;

										    $theOrder = new Order( $orderId, $amount );

										    $paymentObj = PaymentMaker::makePaymentRequest( $theOrder, $test, $configArray );
									    }    

  									?>
						<div class="flex-col-e-s s-full p-rl-25 p-tb-11">
							<a href='<?php echo $paymentObj->getRedirect();?>' class="dis-block how1-child2 f1-s-2 cl0 bo-all-1 bocl0 hov-btn1 trans-03 p-rl-5 p-t-2">
									 15$: 
											<img style="width: 100px;" src='https://moncashbutton.digicelgroup.com/Moncash-middleware/resources/assets/images/MC_button.png' >
							</a>

							<h3 class="how1-child2 m-t-10">
								<a href="blog-detail-01.html" class="f1-m-1 cl0 hov-cl10 trans-03">
									Blue Yellow Jazz Necktie
								</a>
							</h3>
						</div>
					</div>
				</div>

				<div class="col-sm-6 col-lg-4 p-rl-1 p-b-2">
					<div class="bg-img1 size-a-12 how1 pos-relative" style="background-image: url(images/pR3.jpg);">
						<a href="blog-detail-01.html" class="dis-block how1-child1 trans-03"></a>
						     <?php							    

									    if(!isset($_GET['paymentDetails'])){
									         $prix= 15;
											$calTaux= $Letaux * $prix;
									    	$amount = $calTaux;
											
										    $orderId = 9876543251;

										    $theOrder = new Order( $orderId, $amount );

										    $paymentObj = PaymentMaker::makePaymentRequest( $theOrder, $test, $configArray );
									    }    

  									?>

						<div class="flex-col-e-s s-full p-rl-25 p-tb-11">
							<a href='<?php echo $paymentObj->getRedirect();?>' class="dis-block how1-child2 f1-s-2 cl0 bo-all-1 bocl0 hov-btn1 trans-03 p-rl-5 p-t-2">
									 25$: 
											<img style="width: 100px;" src='https://moncashbutton.digicelgroup.com/Moncash-middleware/resources/assets/images/MC_button.png' >
							</a>

							<h3 class="how1-child2 m-t-10">
								<a href="blog-detail-01.html" class="f1-m-1 cl0 hov-cl10 trans-03">
									Peach Paisley Necktie
								</a>
							</h3>
						</div>
					</div>
				</div>

				

	
	<!-- Back to top -->
	<div class="btn-back-to-top" id="myBtn">
		<span class="symbol-btn-back-to-top">
			<span class="fas fa-angle-up"></span>
		</span>
	</div>

	<!-- Modal Video 01-->
	<div class="modal fade" id="modal-video-01" tabindex="-1" role="dialog" aria-hidden="true">
		<div class="modal-dialog" role="document" data-dismiss="modal">
			<div class="close-mo-video-01 trans-0-4" data-dismiss="modal" aria-label="Close">&times;</div>

			<div class="wrap-video-mo-01">
				<div class="video-mo-01">
					<iframe src="#" allowfullscreen></iframe>
				</div>
			</div>
		</div>
	</div>

<!--===============================================================================================-->	
	<script src="vendor/jquery/jquery-3.2.1.min.js"></script>
<!--===============================================================================================-->
	<script src="vendor/animsition/js/animsition.min.js"></script>
<!--===============================================================================================-->
	<script src="vendor/bootstrap/js/popper.js"></script>
	<script src="vendor/bootstrap/js/bootstrap.min.js"></script>
<!--===============================================================================================-->
	<script src="js/main.js"></script>

</body>
</html>