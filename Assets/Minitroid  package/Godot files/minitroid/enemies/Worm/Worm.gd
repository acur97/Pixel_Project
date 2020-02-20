extends KinematicBody2D


var death := false
var health:= 4
export var hidden := true
onready var animPlayer: AnimationPlayer = get_node("AnimationPlayer")

var KILL := preload("res://enemies/kill.tscn")

# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	if hidden :
		$CollisionShape2D.set_deferred("disabled", true)	
		$Sprite.play("hidden")
	
	
	
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

# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta: float) -> void:
#	pass

func _on_Sprite_animation_finished() -> void:
	if death:
		queue_free()


func _on_Detect_body_entered(body: PhysicsBody2D) -> void:
	
	if body and hidden:
		if body.name == "Player":
			$Detect.queue_free()
			Audio.play_reveal()
			hidden = false
			$CollisionShape2D.set_deferred("disabled", false)	
			$Sprite.play("idle")
			$AnimationPlayer.play("out")
