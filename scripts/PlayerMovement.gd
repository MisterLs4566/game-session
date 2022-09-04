extends RigidBody2D

var hor_input = 0.0

export var movement_speed = 100.0
export var jump_height = 100.0

export var max_jumps = 1
var current_jumps = 0

var was_in_air = false

func _physics_process(delta):
	hor_input = Input.get_action_strength("move_right") - Input.get_action_strength("move_left")
	
	linear_velocity = linear_velocity.linear_interpolate(Vector2(hor_input * movement_speed, linear_velocity.y), delta * 5)
	
	if !was_in_air:
		$PlayerAnim.play("slime_idle_anim")
	
	if hor_input == -1:
		$Sprite.set_flip_h(true)
		$PlayerAnim.playback_speed = 2.2
	elif hor_input == 1:
		$Sprite.set_flip_h(false)
		$PlayerAnim.playback_speed = 2.2
	else:
		$PlayerAnim.playback_speed = 1.0
	
	if Input.is_action_just_pressed("jump") and current_jumps < max_jumps:
		current_jumps += 1
		apply_central_impulse(Vector2.UP * jump_height)
		
	if $RayCast2D.is_colliding():
			var groundObject = $RayCast2D.get_collider()
			if groundObject.is_in_group("Ground") and groundObject != null:
				current_jumps = 0
			if was_in_air:
				$Sprite.frame = 3
				yield(get_tree().create_timer(0.1),"timeout")
				was_in_air = false
	else:
		$PlayerAnim.stop()
		$Sprite.frame = 2
		was_in_air = true
