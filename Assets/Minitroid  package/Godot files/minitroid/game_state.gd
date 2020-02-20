# PERSISTENT DATA AND GLOBL VAIABLES 

extends Node

var initMusic := false

const gravity:= 800.0
var player
var invinsibleDebug = false


var stars_arr = []

#Weapon status
var shotCoolDown:= 50  # default 50 inc -10 # total 5 items
var shotCoolDownMin := 0
var shotCoolDownUpgrade := -10

var shot_duration := 10 # default 10  inc 3 # 6
var shot_durationMax := 28
var shot_duration_upgrade := 3


# total upgrades 5 + 6 = 11 stars