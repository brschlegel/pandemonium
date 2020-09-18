# Props
Props are customizable objects that are used to create minigames. These are dev tools, prefabs with lots of variables to tweak to change behaviour. Examples include could be a prop spawner, a ball, a goal, a death plane, a respawn point. The idea is to create general objects that can be used for multiple mini-games by tweaking a couple numbers. Ideally, minigames could be quickly and easily created using only props, but I imagine that a few custom objects will need to be created.

## TagList
Props are identified by tags in the tagList object. This allows a Gameobject to take multiple Unity tags at once, which is helpful for defining multiple behaviours. Many props use tags to identify what to do with an object, so it's important to make sure that the tags are set correctly. Tags are set in the inspector and on prefabs

## List of Props
### Ball
This one is simple, just a ball with variable size and customizable gravity

### Goal
This is a Trigger collider that invokes another GameObject's method when something enters it 