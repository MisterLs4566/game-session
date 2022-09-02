extends Control

var isFullscreen

func _ready():
	isFullscreen = OS.window_fullscreen

func _on_Return_button_down():
	$MainMenu.show()
	$SettingsMenu.hide()


func _on_Settings_button_down():
	$SettingsMenu.show()
	$MainMenu.hide()


func _on_Fullscreen_button_down():
	if isFullscreen:
		isFullscreen = false
		OS.window_fullscreen = false
	else:
		isFullscreen = true
		OS.window_fullscreen = true


func _on_Quit_button_down():
	get_tree().quit()
