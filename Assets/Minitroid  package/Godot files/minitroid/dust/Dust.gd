extends Node2D


func _ready() -> void:
	$AnimatedSprite.play("Default")

func _on_AnimatedSprite_animation_finished() -> void:
	queue_free()
