extends KinematicBody2D


const JUMP_SPEED := Vector2(60,300)
var velocity := Vector2()
var readyFlag := false
var starId := ""



func _ready() -> void:
	velocity.y = -200
	Audio.play_found()


func _process(delta: float) -> void:
	
	velocity = move_and_slide(velocity, Vector2.UP)
	velocity.y += 20
	
	if $Area2D.overlaps_body(game_state.player) and game_state.player.is_on_floor() and readyFlag :
		takeStar()
		queue_free()


func takeStar():
	game_state.stars_arr.append(starId) 
	Audio.play_powerUp()
	selectUpgradeType()
	game_state.player.label_play()
	
	
func selectUpgradeType():

	#if game_state.stars_arr.size() % 2 == 0:
	if game_state.stars_arr.size() < 6:
		upgrade_coolDown()
		#print("cooldown upgraded")
	else:
		upgrade_duration()
		#print("duration upgraded")
		
	#print("upgrades taken " + str(game_state.stars_arr.size()) )
	#print("COOL" + str(game_state.shotCoolDown))
	

func upgrade_coolDown():
	game_state.shotCoolDown += game_state.shotCoolDownUpgrade
	if game_state.shotCoolDown < game_state.shotCoolDownMin:
		game_state.shotCoolDown = game_state.shotCoolDownMin
		
	
func upgrade_duration():
	game_state.shot_duration += game_state.shot_duration_upgrade
	if game_state.shotCoolDown > game_state.shot_durationMax:
		game_state.shotCoolDown = game_state.shot_durationMax




func _on_Timer_timeout() -> void:
	readyFlag = true
