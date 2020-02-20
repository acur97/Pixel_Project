tool
extends Area2D

export var next_scene: PackedScene

func _ready() -> void:
	pass # Replace with function body.
	
func _get_configuration_warning() -> String:
	return "EMpty Scene" if not next_scene else ""
	
func teleport() -> void:
	get_tree().change_scene_to(next_scene)


func _on_Area2D_body_entered(body: PhysicsBody2D) -> void:
	teleport()
