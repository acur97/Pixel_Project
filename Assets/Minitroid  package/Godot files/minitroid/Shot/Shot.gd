extends Area2D

const SPEED = 250
var velocity = Vector2()
var direction = 1
var duration 


const HIT = preload("res://hit/Hit.tscn")


func _ready() -> void:
	duration = game_state.shot_duration

	pass # Replace with function body.


func set_shot_direction(dir):
	direction = dir
	if dir == -1:
		$Sprite.flip_h = true

func _process(delta: float) -> void:
	velocity.x = SPEED * delta * direction
	translate(velocity)
	
	#remove after a while
	duration -= 1
	if duration  < 0:
		hitShot()



func _on_VisibilityNotifier2D_screen_exited() -> void:
	queue_free()


func _on_Shot_body_entered(body: PhysicsBody2D) -> void:
	
	
	if body:
		if body.is_in_group("invencibles"):
				bounceShot(direction)
				Audio.play_bounce()	
				return
				
		elif body.is_in_group("enemies"):
			Audio.play_hurt()
			body.hurt()	


			
		if body.is_in_group("switches"):
			body.activate()
			
		
		if body.is_in_group("break"):
			body.hurt()
		
		
	hitShot()

func bounceShot(direction):
	var hit = HIT.instance()
	get_parent().add_child(hit)
	hit.direction = direction
	hit.position = position
	hit.bounce = true
	queue_free()	

func hitShot():
	
	var hit = HIT.instance()
	get_parent().add_child(hit)
	hit.position = position
	queue_free()
	
	
	

