extends KinematicBody2D


var _velocity := Vector2.ZERO
var speed := Vector2(75.0, 230.0)
var shotCoolDownTimer := 0
var shieldOn := false
var isDead := false
var dust_flag := 0


const SHOT = preload("res://Shot/Shot.tscn")
const PARTICLE = preload("res://PlayerParticle/player-particle.tscn")
const DUST = preload("res://dust/Dust.tscn")

func _ready() -> void:
	game_state.player = self
 
	
func particle_explosion() -> void:
	var arr = [0,45, 90, 45*3, 45 * 4, 45 * 5 ]
	for item in arr:
		var particle = PARTICLE.instance()
		get_parent().add_child(particle)
		particle.rotacion = float(item)
		
func dust_manager():
	# reset dust if falling
	if _velocity.y > 40:
		dust_flag = 0 
	
	#dust flag
	if dust_flag == 0: 
		# check collision for dust
		var collide_count = get_slide_count() 
		if collide_count == 1 and _velocity.y < 20:
			dust_flag = 1
			make_dust()	
			
			
func make_dust():
	var dust = DUST.instance()
	get_parent().add_child(dust)
	dust.position = position
	Audio.play_land()	

func _process(delta: float) -> void:
	
	if isDead:
		return

	if Input.is_action_pressed("shield") and is_on_floor() :		
		shieldOn = true
		Audio.play_shield()
		
	else:
		shieldOn = false
		Audio.stop_shield()
	
		
	
	var direction = get_direction()
	_velocity = calculate_move_velocity(_velocity, direction, speed)
	_velocity = move_and_slide(_velocity, Vector2.UP)
	animation_control(_velocity)
	
	dust_manager()
	
	
	if shotCoolDownTimer > 0:
		shotCoolDownTimer -= 1
	
	if Input.is_action_just_pressed("shot") and shotCoolDownTimer <= 0 and shieldOn == false:
		shotCoolDownTimer = game_state.shotCoolDown
		var pos = 14
		if $Sprite.flip_h == false:
			$Position2D.position.x = pos
		else:
			$Position2D.position.x = -pos
			
		var shot = SHOT.instance()
		get_parent().add_child(shot)
		shot.position = $Position2D.global_position
		Audio.play_shot()
		if sign($Position2D.position.x) == 1:
			shot.set_shot_direction(1)
		else:
			shot.set_shot_direction(-1)
			
	#fall death
	if position.y > 300:
		die()
	
func animation_control(vel) -> void:
	
	
	if shieldOn:
		$Sprite.play("shield")
		return
	 
	if vel.x == 0:
		if is_on_floor():
			$Sprite.play("idle")
		else:
			$Sprite.play("jump")
		
	elif vel.x > 0:
		if is_on_floor():
			$Sprite.play("run")
		else:
			$Sprite.play("jump")
		$Sprite.flip_h = false
	elif vel.x < 0:
		if is_on_floor():
			$Sprite.play("run")
		else:
			$Sprite.play("jump")
		$Sprite.flip_h = true
		

	
func get_direction() -> Vector2:
	if shieldOn:
		return Vector2.ZERO
	else:
		return Vector2(Input.get_action_strength("move_right") 
		- Input.get_action_strength("move_left"), 
		jump())
		
func jump():
	if game_state.invinsibleDebug:
		return -1.0 if Input.is_action_just_pressed("jump")  else 1.0 
	else:
		return -1.0 if Input.is_action_just_pressed("jump") and is_on_floor() else 1.0 

func calculate_move_velocity(
		linear_velocity: Vector2,
		direction:Vector2,
		speed:Vector2
		) -> Vector2:
	var new_velocity:= linear_velocity
	new_velocity.x = speed.x * direction.x
	new_velocity.y += game_state.gravity * get_physics_process_delta_time()
	if direction.y == -1:
		new_velocity.y = speed.y * direction.y
	return new_velocity

func die() -> void:
	if game_state.invinsibleDebug:
		return
	Audio.stop_shield()
	Audio.play_death()
	isDead = true
	$CollisionShape2D.set_deferred("disabled", true)
	$Hit/CollisionShape2D.set_deferred("disabled", true)
	$Sprite.visible = false
	particle_explosion()
	$Timer.start()
	



func _on_Hit_body_entered(body: PhysicsBody2D) -> void:
	
	if body :
		print(body)
		if body.is_in_group("enemies"):
			die()


func _on_Timer_timeout() -> void:
	reload_scene()
	
func reload_scene()-> void:
	get_tree().reload_current_scene()

func label_play():
	$PowerupAlert.play("on")
	
func _on_PowerupAlert_animation_finished() -> void:
	$PowerupAlert.play("off")
