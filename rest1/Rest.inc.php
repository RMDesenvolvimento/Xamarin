<?php

/*
 * Configura variaveis banco
 */
$config["banco"]["servidor"] = "127.0.0.1";
$config["banco"]["usuario"] = "root";
$config["banco"]["senha"] = "zadroqfim";
$config["banco"]["banco"] = "rm";

/*
 * Configura conexao banco
 */
try
{
    $opcao = array(
        PDO::ERRMODE_SILENT => true,
        PDO::ATTR_PERSISTENT => true,
        PDO::ATTR_DEFAULT_FETCH_MODE => PDO::FETCH_ASSOC,
        PDO::MYSQL_ATTR_INIT_COMMAND => 'SET NAMES utf8',
    );
       $GLOBALS["banco"] = new PDO("mysql:host={$config["banco"]["servidor"]};dbname={$config["banco"]["banco"]}",
                               $config["banco"]["usuario"],$config["banco"]["senha"],$opcao);

    unset($opcao);
} catch (PDOException $e) {
    exit('Erro conexao do banco de dados');
}

?>