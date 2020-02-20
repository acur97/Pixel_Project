extends Node

var shieldPlaying := false


func _ready() -> void:
	#play_music()
	pass


func play_music():
	
	$Music.play()

func play_shot():
	$ShotAudio.play()
	
func play_death():
	$Death.play()

func play_kill():
	$Kill.play()
	
func play_powerUp():
	$PowerUp.play()
	
func play_reveal():
	$Reveal.play()
	
func play_hurt():
	$Hurt.play()
	
func play_bounce():
	$bounce.play()
	
func play_enemy_shot():
	$EnemyShot.play()
	
func play_vanish():
	$Vanish.play()
	
func play_found():
	$Found.play()
	
func play_land():
	$Land.play()
	
func play_shield():
	if shieldPlaying == false:
		shieldPlaying = true
		$Shield.play()
	
func stop_shield():
	$Shield.stop()
	shieldPlaying = false
