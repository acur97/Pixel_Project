extends StaticBody2D

var originalPosition := Vector2()
var closed := true

func _ready() -> void:
	originalPosition = position
	
func open_door():
	$Timer.start()
	
	if position.y > originalPosition.y - 8 * 4:
		position.y -= 4


func _process(delta: float) -> void:
	
	if position == originalPosition:
		closed = true
	else:
		closed = false
		

func _on_Timer_timeout() -> void:
	if not closed :
		position.y += 2


func _on_Area2D_body_entered(body: PhysicsBody2D) -> void:
	if body.name == "Player":
		body.die()
