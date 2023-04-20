# unity3D-designPatterns
A 3D demo that implements strategy, decorator and composite design pattern to create a skill system for an RPG type

<b>1. Strategy Pattern:</b> This pattern is used to create different targeting, effect and filtering techniques for different skills.

<b>2. Decorator Pattern:</b> This pattern is used to add additional behaviors to animation effect. The behaviors include:
- Disables the character controller when the animation effect is applied and enables it again once finished.
- Disables the animation when the animation action is cancelled

<b>3. Composite Pattern:</b> This pattern is used as a complex container for the effects. The composite effects include:
  - Sequence: allows each effect in an array of effects to be called after the previous effect is finished
  - Action after anim: allows an array of effects to be called after an event in animation is called
----------------------------------------------------------------------------------------------------------------------------------------------------------------
***The demo****
I made two skills and basic movement/fighting behaviors. There are 2 skills and in order to use the skill, press 1 or 2.

1. The first skill is a jump slash with a delayed click targeting:
<p align="center">
  <img src="https://github.com/ngol0/unity3D-designPatterns/blob/main/skill1.gif" width="900" title="hover text">
</p>

2. 
