extends KinematicBody2D


export var JUMP_SPEED := Vector2(0,550)


var velocity := Vector2()
var jumpTimer := 100
var jumpTrigger := 100
var readyFlag := false
var death := false
var health:= 1
var initialPosition := Vector2()

var KILL := preload("res://enemies/kill.tscn")


func _ready() -> void:
	initialPosition = position
	
func hurt() -> void:
	health -= 1
	if health <= 0:
		die()
	
func die() -> void:
	var kill = KILL.instance()
	get_parent().add_child(kill)
	death = true
	queue_free()


func _process(delta: float) -> void:
	
	if position.y >= initialPosition.y:
		jumpTimer -= 1
		position.y = initialPosition.y
		if jumpTimer <= 0:
			jumpTimer = jumpTrigger
			velocity.y = - JUMP_SPEED.y
	else:
		velocity.y +=  20
	
	velocity = move_and_slide(velocity, Vector2.UP)
	