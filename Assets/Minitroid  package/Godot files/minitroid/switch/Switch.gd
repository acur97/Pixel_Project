extends StaticBody2D

# Declare member variables here. Examples:
# var a: int = 2
# var b: String = "text"
var door


func activate() -> void:
	door = get_parent().get_node("Door")
	door.open_door()
	Audio.play_hurt()
	
	
# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta: float) -> void:
	
	pass
