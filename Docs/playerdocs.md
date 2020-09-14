# Player Docs

These docs deal with how player actions and input are handled

## Input Maps
Unity Documentation: https://docs.unity3d.com/Packages/com.unity.inputsystem@1.1/manual/QuickStartGuide.html

Input maps will have movement, jump, and action1, action2, action3. The extra actions I plan on using on a per-minigame basis. Right now, all movement is stored in the basic movement script. Players are managed in the Input Manager gameobject by the Player Input Manager component. Players are added by pressing a button on their respective controllers/keyboard.

## Movement
Movement is done with forces and a rigidbody component. Here are the variables and what they change

speed: This is just the max speed of the character
maxVelocityChange: This affects more of the turning speed/braking speed of the character
frictionCoeff: In contrast to actual physics, the higher this is, the less friction slows you down
gravity: What it says on the tin
jumpForce: Force applied up
maxJumps: Max number of jumps allowed before grounding
jumpMaxVelocityChange: Control in the air


