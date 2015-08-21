<?php

require_once("Rest.inc.php");

if (isset($_GET['nome']))
{
	$produto = strtoupper($_GET['nome']);

	$sql = 'SELECT id, descricao, preco_venda FROM produtos where venda <> "C" AND descricao like :produto order by descricao';

    $pesquisa = $GLOBALS['banco']->prepare($sql);
    $pesquisa->bindvalue(':produto',"%".$produto."%",PDO::PARAM_STR);
    $pesquisa->execute();

	if (!$pesquisa) {
		echo 'Sem Registro';
	} else {

		$status = 0;
		$registro = $pesquisa->fetchAll();

		$result = array();
		foreach ($registro as $rlt) {

			$status = 1;
			// temp produto array

			$id = $rlt["id"];
			$nome = $rlt["descricao"];
			$preco = number_format((float) $rlt["preco_venda"], 2,'.',',');

			$produto = array( "id" => $id,  "nome" => $nome,  "preco" => $preco );
			array_push( $result, $produto );
		}
		if ($status == 1) {
			echo json_encode( $result );
		} else {
			echo 'Sem Registro';
		}
	}
}

?>