# Player Docs

These docs deal with how player actions and input are handled

## Input Maps
Unity Documentation: https://docs.unity3d.com/Packages/com.unity.inputsystem@1.1/manual/QuickStartGuide.html

Input maps will have movement, jump, and action1, action2, action3. The extra actions I plan on using on a per-minigame basis. Each action,
say Grab, is its own script component. These are all on the player, and will be disabled and enabled as minigames are loaded in. On that note, movement and jumping will also 
have their own scripts.

## Action Scripts
