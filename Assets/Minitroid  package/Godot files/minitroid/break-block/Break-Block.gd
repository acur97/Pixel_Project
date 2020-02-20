extends StaticBody2D

export var health := 3

func hurt()-> void:
	Audio.play_vanish()
	health -= 1
	
func _process(delta: float) -> void:
	
	if $Sprite :
	
		if health == 2:
			$Sprite.play("two")
		
		if health == 1:
			$Sprite.play("three")
			

	if health == 0:
		queue_free()
