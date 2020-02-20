extends StaticBody2D


var wake := false

func _ready() -> void:
	pass # Replace with function body.


func _process(delta: float) -> void:
	pass
		

func vanish() -> void:
	$Sprite.play("wake")
	wake = true
	$Timer.start()
	Audio.play_vanish()


func _on_Area2D_body_entered(body: PhysicsBody2D) -> void:
	if body.name == "Player" and body.is_on_floor() and wake == false:
		
		vanish()


func _on_Timer_timeout() -> void:
	queue_free()
