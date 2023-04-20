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
***THE DEMO***

Currently the demo code in this project consists of 2 concrete skills and basic movement/fighting behaviors with corresonponding cursor types. This project is designed so that it is easier to add more skills with different targeting/filtering/effecting techniques. In addition, it is also easy to extend the functionality or add more behaviors to the skills through decorator and composite pattern.

The skills I created in this demo project:

<b>1. Skill 00: </b> a jump slash with a delayed click targeting. This targeting allows you to determine a circled area of targeting before clicking to apply your skill. Press 1 to use this skill.
<p align="center">
  <img src="https://github.com/ngol0/unity3D-designPatterns/blob/main/skill1.gif" width="900" title="skill 1 demo">
</p>

<b>2. Skill 01:</b> a fire sword slash with a directional targeting. This targeting prompts the fireball to shoot toward where your cursor is the moment you press 2 to apply the skill.
<p align="center">
  <img src="https://github.com/ngol0/unity3D-designPatterns/blob/main/skill2.gif" width="900" title="skill 2 demo">
</p>
