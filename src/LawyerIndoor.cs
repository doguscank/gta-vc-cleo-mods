    � V �  T��BN}O��*A  �A  �A  �@ M ���� ����  �T��BN}O��*A  @?   ����  �  �  T��BN}O��*A  �?  �?   @ M ���� _���  �U  ;�C���W�RA�  ���C=l��W�RA  @?  ���  �  �  ��C=l��W�RA  �?  �?   @ M ��� ����  � U  ��BBtN��i'A�  ����VAR '   ARENA_DOOR_1    ARENA_DOOR_2    CAR_SHOWROOM_ASSET �  CURRENT_TIME_IN_MS �  CUT_SCENE_TIME |   DEFAULT_WAIT_TIME    FILM_STUDIO_ASSET �  FILM_STUDIO_BACK_GATE_CLOSED   FILM_STUDIO_BACK_GATE_OPEN   FILM_STUDIO_FRONT_GATE_CLOSED   FILM_STUDIO_FRONT_GATE_OPEN   ICE_CREAM_FACTORY_ASSET �  LANCE_VANCE �   ONMISSION 9  PASSED_ASS1_RUB_OUT �   PASSED_COK1_THE_CHASE �   PASSED_COK2_PHNOM_PENH_86 �   PASSED_COK3_THE_FASTEST_BOAT �   PASSED_COK4_SUPPLY_AND_DEMAND �   PASSED_COL1_TREACHEROUS_SWINE �   PASSED_COL2_MALL_SHOOTOUT �   PASSED_COL3_GUARDIAN_ANGELS �   PASSED_COL4_SIR_YES_SIR �   PASSED_COL5_ALL_HANDS_ON_DECK �   PASSED_HAT1_JUJU_SCRAMBLE   PASSED_HAT2_BOMBS_AWAY   PASSED_HAT3_DIRTY_LICKINS   PASSED_KENT1_DEATH_ROW �   PASSED_LAW1_THE_PARTY �   PASSED_LAW2_BACK_ALLEY_BRAWL �   PASSED_LAW3_JURY_FURY �   PASSED_LAW4_RIOT �   PASSED_ROCK1_LOVE_JUICE    PASSED_ROCK2_PSYCHO_KILLER !  PASSED_ROCK3_PUBLICITY_TOUR "  PASSED_TEX1_FOUR_IRON �   PLAYER_ACTOR    PLAYER_CHAR    PRINT_WORKS_ASSET �  FLAG   SRC �  {$CLEO .cs} // Directive to compile as a CLEO script

:start
0000: NOP // NOP is used in order to avoid jump-at-zero offset error

:player_loop
0001: wait 0 ms
00D6: if and
0256:   player $PLAYER_CHAR defined
00F5: player $PLAYER_CHAR 0 123.319 -829.9579 10.6286 radius 20.0 20.0 4.0
004D: jf @player_loop
0002: jump @lawyer_outdoor

:lawyer_outdoor
0001: wait 0 ms
03BC: 0@ = create_sphere 123.319 -829.9579 10.6286 0.75
0002: jump @sphere_check_outdoor

:sphere_check_outdoor
0001: wait 0 ms
00D6: if
00F5:   player $PLAYER_CHAR 0 123.319 -829.9579 10.6286 radius 1.0 1.0 2.0
004D: jf @sphere_check_outdoor
0002: jump @lawyer_indoor

:lawyer_indoor
0001: wait 0 ms
04BB: select_interiour 6
0055: put_player $PLAYER_CHAR at 139.8095 -1368.9276 13.1827
03BD: destroy_sphere 0@
03BC: 1@ = create_sphere 140.6784 -1371.3824 13.1827 0.75
0002: jump @sphere_check_indoor

:sphere_check_indoor
0001: wait 0 ms
00D6: if
00F5:   player $PLAYER_CHAR 0 140.6784 -1371.3824 13.1827 radius 1.0 1.0 2.0
004D: jf @sphere_check_indoor
0002: jump @teleport_outdoor

:teleport_outdoor
0001: wait 0 ms
04BB: select_interiour 0
0055: put_player $PLAYER_CHAR at 117.8497 -825.8165 10.4633
03BD: destroy_sphere 1@
0002: jump @player_loopE  __SBFTR 