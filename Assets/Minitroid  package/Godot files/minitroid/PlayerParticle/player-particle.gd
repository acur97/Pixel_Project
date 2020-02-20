extends Node2D

var velocity:= Vector2(-1,-1)
var speed := 100
var setUp := false
export var rotacion := 0.0


func _ready() -> void:
	if game_state.player:
		position = game_state.player.position
		
func set_speed(spd):
	speed = spd


func _process(delta: float) -> void:
	
	if setUp == false:
		setUp = true
		position = game_state.player.position
		z_index = 100
		
	velocity.x = speed * delta 
	translate(velocity.rotated(rotacion))
	
