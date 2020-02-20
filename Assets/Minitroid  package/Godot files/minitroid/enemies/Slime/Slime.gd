extends KinematicBody2D

const JUMP_SPEED := Vector2(60,300)

var direction := 1
var velocity := Vector2()
var jumpTimer := 0
var jumpTrigger := 100
var readyFlag := false
var death := false
var health:= 3
var KILL := preload("res://enemies/kill.tscn")


# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	jumpTimer = jumpTrigger
	pass # Replace with function body.
	
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
func _process(delta: float) -> void:
	
	if death:
		return
	
	if readyFlag == false and is_on_floor():
		readyFlag = true
	
	jumpTimer -= 1
	velocity.y +=  20
	
	
	if jumpTimer <= 0 and is_on_floor():
		jumpTimer = jumpTrigger
		velocity.y = - JUMP_SPEED.y
		direction *= -1
		
	# anim
	if direction == -1:
		$Sprite.flip_h = true
	else:
		$Sprite.flip_h = false
		
		
	#move on x axis
	
	if  is_on_floor() == true:
		velocity.x = 0
	elif readyFlag :
		velocity.x = -JUMP_SPEED.x * direction
		

	velocity = move_and_slide(velocity, Vector2.UP)
	
	
	if is_on_floor():
		$Sprite.play("idle")
	else:
		if velocity.y > 0:
			$Sprite.play("fall")
		else:
			$Sprite.play("jump")
			
	
	


func _on_Sprite_animation_finished() -> void:
	if death:
		queue_free()
