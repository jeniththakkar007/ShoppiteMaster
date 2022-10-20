<?php


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
	echo $donnees['taux'] ;
}

$reponse->closeCursor();
?>