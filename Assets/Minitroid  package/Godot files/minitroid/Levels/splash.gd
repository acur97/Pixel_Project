extends Node2D


func _process(delta: float) -> void:
	
	if game_state.player.position.x > 70:

		$INSTRUCTIONS.visible = false
		
	if game_state.player.position.x > 150:
	
		$INSTRUCTIONS2.visible = false
