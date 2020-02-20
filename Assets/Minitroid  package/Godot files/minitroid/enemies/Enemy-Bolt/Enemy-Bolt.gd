extends Area2D

const speed = 100
var velocity = Vector2()
var targetPos = Vector2()
var initFlag := false
var direction = 1
 
const HIT := preload("res://hit/Hit.tscn")


func _ready() -> void:
	Audio.play_enemy_shot()
	pass

func _process(delta: float) -> void:
	
	if initFlag == false:
		initFlag = true
		
		targetPos = (game_state.player.position - position)

	velocity = (targetPos).normalized() * speed * delta	
	translate(velocity)
	 

func _on_VisibilityNotifier2D_screen_exited() -> void:
	queue_free()


func _on_EnemyBolt_body_entered(body: PhysicsBody2D) -> void:
	 
		
		
	if body:
		if body.name == "Player":

			if  body.shieldOn == false:
				body.die()
				
			else:
				if velocity.x > 0:
					direction = -1
				
				bounceShot(direction)
				Audio.play_bounce()	
		else:
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
