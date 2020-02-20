extends KinematicBody2D

var velocity := Vector2()
var speed := 36
var follow := false
var origin := Vector2.ZERO
var targetPos := Vector2()
var health := 2
var death := false
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
	death = true
	$Sprite.play("die")
	$CollisionShape2D.set_deferred("disabled", true)

func _process(delta: float) -> void:

	if death:
		return

	if follow:
		targetPos = (game_state.player.position - position)
		
	else:
		targetPos = (origin - position) 
		
	
	$Sprite.flip_h = true if velocity.x > 0 else false

	if ( abs(targetPos.x)  > 1 or abs(targetPos.y) > 1 ):
	 
		velocity = (targetPos).normalized() * speed
		velocity = move_and_slide(velocity)
	

func _on_Area2D_body_entered(body: PhysicsBody2D) -> void:
	follow = true


func _on_Area2D_body_exited(body: PhysicsBody2D) -> void:
	follow = false


func _on_Sprite_animation_finished() -> void:
	if death:
		queue_free()
