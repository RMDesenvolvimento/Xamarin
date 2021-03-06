<?php
    
	/* 
		This is an example class script proceeding secured API
		To use this class you should keep same as query string and function name
		Ex: If the query string value rquest=delete_user Access modifiers doesn't matter but function should be
		     function delete_user(){
				 You code goes here
			 }
		Class will execute the function dynamically;
		
		usage :
		
		    $object->response(output_data, status_code);
			$object->_request	- to get santinized input 	
			
			output_data : JSON (I am using)
			status_code : Send status message for headers
			
		Add This extension for localhost checking :
			Chrome Extension : Advanced REST client Application
			URL : https://chrome.google.com/webstore/detail/hgmloofddffdnphfgcellkdfbfbjeloo
		
 	*/
	
	require_once("Rest.inc.php");
	
	class API extends REST {
	
		public $data = "";
		
		const DB_SERVER = "localhost";
		const DB_USER = "root";
		const DB_PASSWORD = "zadroqfim";
		const DB = "rm";
		
		private $db = NULL;
	
		public function __construct(){
			parent::__construct();				// Init parent contructor
			$this->dbConnect();					// Initiate Database connection
		}
		
		/*
		 *  Database connection 
		*/
		private function dbConnect(){
			$this->db = mysql_connect(self::DB_SERVER,self::DB_USER,self::DB_PASSWORD);
			if($this->db)
				mysql_select_db(self::DB,$this->db);
		}
		
		/*
		 * Public method for access api.
		 * This method dynmically call the method based on the query string
		 *
		 */
		public function processApi(){
			$func = strtolower(trim(str_replace("/","",$_REQUEST['rquest'])));
			if((int)method_exists($this,$func) > 0)
				$this->$func();
			else
				$this->response('',404);				// If the method not exist with in this class, response would be "Page not found".
		}
		
		/* 
		 *  Login must be POST method
		 *  usuario : <USER usuario>
		 *  senha : <USER PASSWORD>
		 */
		
		private function login(){
			// Cross validation if the request method is POST else it will return "Not Acceptable" status
			if($this->get_request_method() != "POST"){
				$this->response('',406);
			}
			
			$usuario = strtoupper($this->_request['usuario']);		
			$password = $this->_request['senha'];
			
			// Input validations
			if(!empty($usuario) and !empty($password)){
				$sql = mysql_query("SELECT id, nome, usuario, email FROM web_usuario WHERE UPPER(usuario) = '$usuario' AND senha = '".$password."' LIMIT 1", $this->db);
				if(mysql_num_rows($sql) > 0){
					$result['data_usuario'] = array();
					while($rlt = mysql_fetch_array($sql,MYSQL_ASSOC)){
 						// temp user array
 						$user[] = array();
  						$user["id"] = $rlt["id"]; 						
  						$user["nome"] = $rlt["nome"];
  						$user["usuario"] = $rlt["usuario"];
  						$user["email"] = $rlt["email"];

    					// push single product into final response array
   						array_push($result['data_usuario'], $user);
						unset($user);
					}
					
					// If success everythig is good send header as "OK" and user details
					$this->response($this->json($result), 200);
				} else {
					// If invalid inputs "Bad Request" status message and reason
					$error = array('status' => "Erro", "msg" => "usuario ou Senha Invalido !!!");
					$this->response($this->json($error), 400);	// If no records "No Content" status
				}

			} else {
					$error = array('status' => "Erro", "msg" => "usuario ou Senha vazio !!!");				
					$this->response($this->json($error), 400);	// If no records "No Content" status
			}
			
		}
		
		private function users(){	
			// Cross validation if the request method is GET else it will return "Not Acceptable" status
			if($this->get_request_method() != "GET"){
				$this->response('',406);
			}
			$sql = mysql_query("SELECT id, nome, usuario, email FROM web_usuario", $this->db);
			if($sql === FALSE) { 
				$error = array('status' => "Erro", "msg" => "Banco de Usuario Vazio !!!");				
				$this->response($this->json($error),204);	// If no records "No Content" status
			} 
			else
			{
				if(mysql_num_rows($sql) > 0){
					$result['data_usuario'] = array();
					while($rlt = mysql_fetch_array($sql,MYSQL_ASSOC)){
						// temp user array
 						$user[] = array();
  						$user["id"] = $rlt["id"]; 						
  						$user["nome"] = $rlt["nome"];
  						$user["usuario"] = $rlt["usuario"];
  						$user["email"] = $rlt["email"];

						// push single product into final response array
   						array_push($result['data_usuario'], $user);
						unset($user);

					}

					// If success everythig is good send header as "OK" and return list of users in JSON format
					$this->response($this->json($result), 200);

				} else {
					$error = array('status' => "Erro", "msg" => "Banco de Usuario Vazio !!!");				
					$this->response($this->json($error),204);	// If no records "No Content" status
				}
			}
		}
		
		private function deleteUser(){
			// Cross validation if the request method is DELETE else it will return "Not Acceptable" status
			if($this->get_request_method() != "DELETE"){
				$error = array('status' => "Erro", "msg" => "Metodo Resquest Invalido !!!");				
				$this->response($this->json($error),406);
			}
			$id = $this->_request['codigo'];
			if($id > 0){				
				mysql_query("DELETE FROM web_usuario WHERE id = $id");
				$success = array('status' => "Success", "msg" => "Registro Eliminado com sucesso.");
				$this->response($this->json($success),200);
			} else {
				$error = array('status' => "Erro", "msg" => "ID do usuario nao Informado !!!");				
				$this->response($this->json($error),204);	// If no records "No Content" status
			}
		}

		private function produtos(){	
			// Cross validation if the request method is GET else it will return "Not Acceptable" status
			if($this->get_request_method() != "GET"){
				$this->response('',406);
			}
			$produto = strtoupper($this->_request['nome']);
			$sql = mysql_query("SELECT id, descricao, preco_venda FROM produtos where venda <> 'C' AND descricao like '%".$produto."%' order by descricao", $this->db);
			if($sql === FALSE) { 
				$error = array('status' => "Erro", "msg" => "Banco de Usuario Vazio !!!");				
				$this->response($this->json($error),204);	// If no records "No Content" status
			} 
			else
			{
				if(mysql_num_rows($sql) > 0){
					$result['data_produto'] = array();
					while($rlt = mysql_fetch_array($sql,MYSQL_ASSOC)){
						// temp user array
 						$user[] = array();
  						$user["id"] = $rlt["id"]; 						
  						$user["nome"] = $rlt["descricao"];
  						$user["preco"] = number_format((float)$rlt["preco_venda"],2,'.',',');

						// push single product into final response array
   						array_push($result['data_produto'], $user);
					}
					// If success everythig is good send header as "OK" and return list of users in JSON format
					$this->response($this->json($result), 200);
				} else {
					$error = array('status' => "Erro", "msg" => "Banco de Usuario Vazio !!!");				
					$this->response($this->json($error),204);	// If no records "No Content" status
				}
			}
		}
				
		/*
		 *	Encode array into JSON
		*/
		private function json($data){
			if(is_array($data)){
				return json_encode($data);
			}
		}
	}
	
	// Initiiate Library
	
	$api = new API;
	$api->processApi();
?>