extends StaticBody2D


var death := false
var health:= 6
onready var animPlayer : AnimationPlayer = get_node("AnimationPlayer")

export var activeFlag := false


const SHOT = preload("res://enemies/Enemy-Bolt/Enemy-Bolt.tscn")

func ready():
	animPlayer.play("stop")
	
func hurt() -> void:
	health -= 1
	if health <= 0:
		return #invincible
		die()
	
func die() -> void:
	death = true
	queue_free()
	$CollisionShape2D.set_deferred("disabled", true)

func shoot_Bolt()->void:
	var shot = SHOT.instance()
	get_parent().add_child(shot)
	
	shot.position = $Position2D.global_position
		
func _on_Area2D_body_entered(body: PhysicsBody2D) -> void:
	animPlayer.play("active")


func _on_Area2D_body_exited(body: PhysicsBody2D) -> void:
	animPlayer.play("stop")
