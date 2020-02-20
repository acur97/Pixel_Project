extends StaticBody2D

var death := false
var health:= 6
export var delay: = 0
var readyFlag:= false

export var direction := 1

onready var animPlayer : AnimationPlayer = get_node("AnimationPlayer")

const SHOT = preload("res://enemies/enemy-shot/Enemy-Shot.tscn")

func _ready() -> void:
	if direction == -1:
		$Sprite.flip_h = true
	
func hurt() -> void:
	health -= 1
	if health <= 0:
		return #invincible
		die()
	
func die() -> void:
	death = true
	queue_free()
	#$Sprite.play("die")
	$CollisionShape2D.set_deferred("disabled", true)


func _process(delta: float) -> void:
	
	if delay == 0 and readyFlag == false:
		readyFlag = true
		animPlayer.play("idle")
	delay -= 1


func shoot_cannon()->void:
	var shot = SHOT.instance()
	get_parent().add_child(shot)
	
	if direction == 1:
		shot.position = position	
	else:
		shot.position = position
		shot.position.x = position.x + 16	
	shot.direction = direction
	shot.position.y = position.y + 9
		
	
	
	
