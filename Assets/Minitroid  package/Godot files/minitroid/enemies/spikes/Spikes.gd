extends Area2D


func _on_Spikes_body_entered(body: PhysicsBody2D) -> void:
	if body:
		if body.name == "Player":
			body.die()
