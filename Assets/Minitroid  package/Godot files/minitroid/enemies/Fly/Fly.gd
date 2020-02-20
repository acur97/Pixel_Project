extends KinematicBody2D

var velocity := Vector2()
var speed := 40
var origin := Vector2.ZERO
var targetPos := Vector2()
var health := 1
var death := false
var followFlag := -1

var KILL := preload("res://enemies/kill.tscn")


func _ready() -> void:
	origin = position
	
	
func hurt() -> void:
	health -= 1
	 
	if health <= 0:
		die()
	
func die() -> void:
	var kill = KILL.instance()
	get_parent().add_child(kill)
	queue_free()


func _process(delta: float) -> void:
	

	targetPos = (game_state.player.position - position)
	
	 
	if ( abs(targetPos.x)  > 1 or abs(targetPos.y) > 1 ):
	 
		velocity = (targetPos).normalized() * speed
		
		if followFlag == 1:
			velocity = move_and_slide(velocity)
	
 

func _on_Timer_timeout() -> void:
	
	followFlag *= -1
