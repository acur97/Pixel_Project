extends Area2D

const SPEED = -100
var velocity = Vector2()
var direction = 1

const HIT := preload("res://hit/Hit.tscn")


func _ready() -> void:
	Audio.play_enemy_shot()
	pass


func set_shot_direction(dir):
	direction = dir
	if dir == -1:
		$Sprite.flip_h = true

func _process(delta: float) -> void:
	
	
	velocity.x = SPEED * delta * direction
	translate(velocity)
	
	if direction == -1:
		$Sprite.flip_h = true


func _on_VisibilityNotifier2D_screen_exited() -> void:
	queue_free()


func _on_EnemyShot_body_entered(body: PhysicsBody2D) -> void:
	

	if body:
		if body.name == "Player":

			if  body.shieldOn == false:
				body.die()
				
			else:
				bounceShot(direction)
				Audio.play_bounce()	
			return
	
	hitShot()
				
				
			

func bounceShot(direction):
	var hit = HIT.instance()
	get_parent().add_child(hit)
	hit.direction = direction *-1
	hit.position = position
	hit.bounce = true
	hit.isEnemyHit = true
	queue_free()	

func hitShot():
	
	var hit = HIT.instance()
	get_parent().add_child(hit)
	hit.position = position
	hit.isEnemyHit = true
	queue_free()
	
