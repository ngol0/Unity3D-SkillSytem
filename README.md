# unity3D-designPatterns
A 3D demo that implements strategy, decorator and composite design pattern to create a skill system for an RPG type

1. Strategy Pattern: This pattern is used to create different targeting, effect and filtering techniques for different skills.

2. Decorator Pattern: This pattern is used to add an additional behavior to animation effect. It disables the character controller when the effect is applied and enables it again once finished.

3. Composite Pattern: This pattern is used as a complex container for the effects. The composite effects include:
  - Sequence: allows each effect in an array of effects to be called after the previous effect is finished
  - Action after anim: allows an array of effects to be called after an event in animation is called

