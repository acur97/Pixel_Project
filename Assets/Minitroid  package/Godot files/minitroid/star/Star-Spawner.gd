
extends Area2D


export var starId := ""
const STAR := preload("res://star/Star.tscn")

# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	pass # Replace with function body.
	


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta: float) -> void:
	#remove if already taken
	if game_state.stars_arr.has(starId):
		queue_free()


func _on_StarSpawner_body_entered(body: PhysicsBody2D) -> void:
	if body.name == "Player":
		spawnStar()	
		
		
func spawnStar() -> void:
	var star = STAR.instance()
	get_parent().add_child(star)
	star.position = position
	star.starId = starId
	
	queue_free()
