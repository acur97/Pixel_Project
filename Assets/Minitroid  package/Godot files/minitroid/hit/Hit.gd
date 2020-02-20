extends Node2D


var isEnemyHit := false
var bounce = false
var velocity = Vector2()
var speed = 222
var direction = 1


func _ready() -> void:
	$Sprite.play("Default")
	
	
func _process(delta: float) -> void:
	
	if isEnemyHit:
		$Sprite.modulate = "#ff8426"
		
		
	if bounce:
		$Sprite.play("bounce")
		velocity.x = speed * delta * -direction
		velocity.y = -speed * delta 
		translate(velocity)
	 
	if position.y < -100:
		queue_free()
		

func _on_Sprite_animation_finished() -> void:
	if bounce == false:
		queue_free()
