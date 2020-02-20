extends KinematicBody2D


func _process(delta: float) -> void:
	
	if position.y > -336:
		position.y -= .3
	
