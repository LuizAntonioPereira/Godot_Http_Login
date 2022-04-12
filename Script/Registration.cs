using Godot;
using System;

public class Cadastro : HBoxContainer
{
	// Declare member variables here. Examples:
	private const string UrlSend = "http:";	
	private HTTPRequest Send;
	private LineEdit Name,Password;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Send = GetNode<HTTPRequest>("HTTP_Send");
		Send.Connect("request_completed", this,nameof(OnRequestCompleted));		
		Name = GetNode<LineEdit>("VBoxContainer2/HBoxContainer/VBoxContainer/EditName");
		Password = GetNode<LineEdit>("VBoxContainer2/HBoxContainer/VBoxContainer/EditPassword");
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
private void _on_BtnNext_pressed()
{
	GetTree().ChangeScene("res://Script/Login.cs");
}

private void _on_BtnRegistration_pressed()
{
	Send = GetNode<HTTPRequest>("HTTP_Send");
	var query = "nome=" + Name.Text + "Password=" + Password.Text;
	string[] headers = new string[] { "Content-Type: application/json" };
	Send.Request(UrlSend);
	
	GetTree().ChangeScene("res://Script/Login.cs");
}

private void OnRequestCompleted(int result, int response_code, string[] headers, byte[] body){

	JSONParseResult json = JSON.Parse( System.Text.UTF8Encoding.Default.GetString(body));
		
	if (result == (int)HTTPRequest.Result.Success){
		
		if (response_code == 200){
				
				// aceitarHighScore();
				
			}
		else{
				
				//negarHighScore();
				
			}
			
		}
	}
}
