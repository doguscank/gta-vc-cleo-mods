    � V �  ���(���A�A  �A  �A  �@ M ���� ����  <IGBUDDY G!� ����  � =H!M ���� ����  � t���(���A�A  s    4CP  �   '#  ��  F  ����(R��A�A  @? �I! �����    M �����  H���  � �  ���(R��A�A  �?  �?   @ 
 �M ��� ����  	 x� 
P   �   �  ����  �    M f��� H���  �   �   M ���� H���  P   �   �: �����
VAR '   ARENA_DOOR_1    ARENA_DOOR_2    CAR_SHOWROOM_ASSET �  CURRENT_TIME_IN_MS �  CUT_SCENE_TIME |   DEFAULT_WAIT_TIME    FILM_STUDIO_ASSET �  FILM_STUDIO_BACK_GATE_CLOSED   FILM_STUDIO_BACK_GATE_OPEN   FILM_STUDIO_FRONT_GATE_CLOSED   FILM_STUDIO_FRONT_GATE_OPEN   ICE_CREAM_FACTORY_ASSET �  LANCE_VANCE �   ONMISSION 9  PASSED_ASS1_RUB_OUT �   PASSED_COK1_THE_CHASE �   PASSED_COK2_PHNOM_PENH_86 �   PASSED_COK3_THE_FASTEST_BOAT �   PASSED_COK4_SUPPLY_AND_DEMAND �   PASSED_COL1_TREACHEROUS_SWINE �   PASSED_COL2_MALL_SHOOTOUT �   PASSED_COL3_GUARDIAN_ANGELS �   PASSED_COL4_SIR_YES_SIR �   PASSED_COL5_ALL_HANDS_ON_DECK �   PASSED_HAT1_JUJU_SCRAMBLE   PASSED_HAT2_BOMBS_AWAY   PASSED_HAT3_DIRTY_LICKINS   PASSED_KENT1_DEATH_ROW �   PASSED_LAW1_THE_PARTY �   PASSED_LAW2_BACK_ALLEY_BRAWL �   PASSED_LAW3_JURY_FURY �   PASSED_LAW4_RIOT �   PASSED_ROCK1_LOVE_JUICE    PASSED_ROCK2_PSYCHO_KILLER !  PASSED_ROCK3_PUBLICITY_TOUR "  PASSED_TEX1_FOUR_IRON �   PLAYER_ACTOR    PLAYER_CHAR    PRINT_WORKS_ASSET �  FLAG   SRC M	  {$CLEO .cs} // Directive to compile as a CLEO script

:start
0000: NOP // NOP is used in order to avoid jump-at-zero offset error

:player_loop
0001: wait 0 ms
00D6: if and
0256:   player $PLAYER_CHAR defined
00F5: player $PLAYER_CHAR 0 -367.4766 -535.7837 17.282 radius 20.0 20.0 4.0
004D: jf @player_loop
0002: jump @request_models

:request_models
0001: wait 0 ms
023C: load_special_actor 8 'IGBUDDY' // 8 is Lance Vance
0247: request_model #M60
038B: load_requested_models 
0002: jump @check_models

:check_models
0001: wait 0 ms
00D6: if and
023D:   special_actor 8 loaded
0248:   model #M60 available
004D: jf @request_models
0002: jump @spawn_recruit

:spawn_recruit
0001: wait 0 ms
009A: 0@ = create_actor_pedtype 4 model #SPECIAL08 at -367.4766 -535.7837 17.282
0173: set_actor 0@ z_angle_to 180.0
0350: set_actor 0@ maintain_position_when_attacked 1
// M60 weapon id = 32
01B2: give_actor 0@ weapon 32 ammo 9999 // Load the weapon model before using this
0223: set_actor 0@ health_to 1000
02E2: set_actor 0@ weapon_accuracy_to 70
0319: set_actor 0@ running 1
03BC: 1@ = create_sphere -367.4766 -537.2837 17.282 0.75
0296: unload_special_actor 8
0249: release_model #M60
0002: jump @check_sphere

:check_before_recruit_dead
00D6: if
0118:   actor 0@ dead
004D: jf @check_sphere
03BD: destroy_sphere 1@
0002: jump @remove_recruit

:check_sphere
0001: wait 0 ms
00D6: if and
00F5:   player $PLAYER_CHAR 0 -367.4766 -537.2837 17.282 radius 1.0 1.0 2.0
010A: player $PLAYER_CHAR money > 4999
004D: jf @check_before_recruit_dead
0002: jump @buy_recruit

:buy_recruit
0001: wait 0 ms
0109: player $PLAYER_CHAR money += -5000
0001: wait 10 ms
0350: set_actor 0@ maintain_position_when_attacked 0
01DF: tie_actor 0@ to_player $PLAYER_CHAR
03BD: destroy_sphere 1@
0002: jump @check_after_recruit_dead

:check_after_recruit_dead
0001: wait 0 ms
00D6: if
0118:   actor 0@ dead
004D: jf @check_recruit_group
0002: jump @remove_recruit

:check_recruit_group
0001: wait 0 ms
00D6: if
8320:   not actor 0@ in_range_of_player $PLAYER_CHAR
004D: jf @check_after_recruit_dead
0002: jump @remove_recruit

:remove_recruit
0001: wait 0 ms
0350: set_actor 0@ maintain_position_when_attacked 0
01C2: mark_actor_as_no_longer_needed 0@
0001: wait 15000 ms
0002: jump @request_models

0A93: end_custom_thread
�  __SBFTR 