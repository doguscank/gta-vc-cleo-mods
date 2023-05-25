    � V �  ����g����A  �A  �A  �@ M ���� ����  GOG/� ����� HOH/M ���� ����  � /���������A  s       
P   U��������G����A  @? I/ ���  �    M ���P   �  �: ����  �  �  ����g����A  �?  �?   @ M 1��� ����  � O���������A IO ����  �   M ���� ����    �:�    M U��� ����VAR '   ARENA_DOOR_1    ARENA_DOOR_2    CAR_SHOWROOM_ASSET �  CURRENT_TIME_IN_MS �  CUT_SCENE_TIME |   DEFAULT_WAIT_TIME    FILM_STUDIO_ASSET �  FILM_STUDIO_BACK_GATE_CLOSED   FILM_STUDIO_BACK_GATE_OPEN   FILM_STUDIO_FRONT_GATE_CLOSED   FILM_STUDIO_FRONT_GATE_OPEN   ICE_CREAM_FACTORY_ASSET �  LANCE_VANCE �   ONMISSION 9  PASSED_ASS1_RUB_OUT �   PASSED_COK1_THE_CHASE �   PASSED_COK2_PHNOM_PENH_86 �   PASSED_COK3_THE_FASTEST_BOAT �   PASSED_COK4_SUPPLY_AND_DEMAND �   PASSED_COL1_TREACHEROUS_SWINE �   PASSED_COL2_MALL_SHOOTOUT �   PASSED_COL3_GUARDIAN_ANGELS �   PASSED_COL4_SIR_YES_SIR �   PASSED_COL5_ALL_HANDS_ON_DECK �   PASSED_HAT1_JUJU_SCRAMBLE   PASSED_HAT2_BOMBS_AWAY   PASSED_HAT3_DIRTY_LICKINS   PASSED_KENT1_DEATH_ROW �   PASSED_LAW1_THE_PARTY �   PASSED_LAW2_BACK_ALLEY_BRAWL �   PASSED_LAW3_JURY_FURY �   PASSED_LAW4_RIOT �   PASSED_ROCK1_LOVE_JUICE    PASSED_ROCK2_PSYCHO_KILLER !  PASSED_ROCK3_PUBLICITY_TOUR "  PASSED_TEX1_FOUR_IRON �   PLAYER_ACTOR    PLAYER_CHAR    PRINT_WORKS_ASSET �  FLAG   SRC �  {$CLEO .cs} // Directive to compile as a CLEO script

:start
0000: NOP // NOP is used in order to avoid jump-at-zero offset error

:player_loop
0001: wait 0 ms
00D6: if and
0256:   player $PLAYER_CHAR defined
00F5: player $PLAYER_CHAR 0 -395.1632 -581.6179 19.5742 radius 20.0 20.0 4.0
004D: jf @player_loop
0002: jump @request_models

:request_models
0001: wait 0 ms
0247: request_model #BRIEFCASE
0247: request_model #BMYBB // dealer ped
038B: load_requested_models
0002: jump @check_models

:check_models
00D6: if and
0248:   model #BRIEFCASE available
0248: model #BMYBB available
004D: jf @request_models
0002: jump @create_dealer

:create_dealer
0001: wait 0 ms
// -395.1842 -582.9283 19.5742 dealer coords 0.0 dealer angle
009A: 0@ = create_actor_pedtype 4 model #BMYBB at -395.1526 -583.0482 19.5742
0173: set_actor 0@ z_angle_to 0.0
0001: wait 10 ms
0350: set_actor 0@ maintain_position_when_attacked 1
0002: jump @create_sphere

:create_sphere
03BC: 1@ = create_sphere -395.1632 -581.1179 19.5742 0.75
0249: release_model #BMYBB
0002: jump @check_sphere

:check_dealer_dead
0001: wait 0 ms
00D6: if
0118:   actor 0@ dead
004D: jf @check_sphere
0350: set_actor 0@ maintain_position_when_attacked 0
03BD: destroy_sphere 1@
0001: wait 15000 ms
0002: jump @request_models

:check_sphere
0001: wait 0 ms
00D6: if
00F5:   player $PLAYER_CHAR 0 -395.1632 -581.6179 19.5742 radius 1.0 1.0 2.0
004D: jf @check_dealer_dead
0002: jump @create_pickup_1

:create_pickup_1
0001: wait 0 ms
03BD: destroy_sphere 1@
// -385.2228 -579.6104 25.3226 pickup coords
0213: 2@ = create_pickup #BRIEFCASE type 3 at -385.2228 -579.6104 25.3226
0249: release_model #BRIEFCASE
0002: jump @check_pickup_1

:check_pickup_1
0001: wait 0 ms
00D6: if
0214:   pickup 2@ picked_up
004D: jf @check_pickup_1
0002: jump @remove_pickup_1

:remove_pickup_1
0001: wait 0 ms
0215: destroy_pickup 2@
0001: wait 15000 ms
00D6: if
0118:   actor 0@ dead
004D: jf @create_sphere
0002: jump @player_loop
�  __SBFTR 