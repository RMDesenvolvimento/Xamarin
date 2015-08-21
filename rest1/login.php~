<?php

require_once("Rest.inc.php");

if ((isset($_GET['usuario'])) || (isset($_GET['senha'])))
{
	$usuario = strtoupper($_GET['usuario']);
	$senha = strtoupper($_GET['senha']);

	if ((strlen($usuario) < 1) || (strlen($senha) < 1)) {
		echo 'Usuario ou Senha sem preenchimento';
	} else {

		$sql = 'SELECT id, nome, usuario, email FROM web_usuario WHERE UPPER(usuario) = :usuario AND UPPER(senha) = :senha LIMIT 1';

		$pesquisa = $GLOBALS['banco']->prepare($sql);
		$pesquisa->bindvalue(':usuario',$usuario,PDO::PARAM_STR);
		$pesquisa->bindvalue(':senha',$senha,PDO::PARAM_STR);
		$pesquisa->execute();

		if (!$pesquisa) {
			echo 'Usuario ou Senha nao encontrado';
		} else {

			$registro = $pesquisa->fetchAll();
			$status = 0;
			$result = array();
			foreach ($registro as $rlt) {
				$status = 1;
				// temp produto array
				$id = $rlt["id"];
				$nome = $rlt["nome"];
				$usuario = $rlt["usuario"];
				$email = $rlt["email"];

				$login = array( "id" => $id,  "nome" => $nome,  "usuario" => $usuario,  "email" => $email );
				array_push( $result, $login );
			}
			if ($status == 1) {
				echo json_encode( $result );
			} else {
				echo 'Usuario ou Senha nao encontrado';
			}
		}
	}
} else {
	echo 'Usuario ou Senha sem preenchimento';
}

?>