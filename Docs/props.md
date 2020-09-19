# Props
Props are customizable objects that are used to create minigames. These are dev tools, prefabs with lots of variables to tweak to change behaviour. Examples include could be a prop spawner, a ball, a goal, a death plane, a respawn point. The idea is to create general objects that can be used for multiple mini-games by tweaking a couple numbers. Ideally, minigames could be quickly and easily created using only props, but I imagine that a few custom objects will need to be created.

## TagList
Props are identified by tags in the tagList object. This allows a Gameobject to take multiple Unity tags at once, which is helpful for defining multiple behaviours. Many props use tags to identify what to do with an object, so it's important to make sure that the tags are set correctly. Tags are set in the inspector and on prefabs

## List of Props
### Ball
This one is simple, just a ball with variable size and customizable gravity

### Goal
This is a Trigger collider that invokes another GameObject's method when something enters it. This can be specified by tag in the inspector, adding different methods to invoke for different tags. This is done in the inspector, and put the most specific tags first. For example, if you want something special to happen to balls, but a different method to happen to all other objects with the tag "prop", but not "ball", then put ball before prop in the events list. If the object that passes through has none of the tags that are specified, then the default event is invoked. Writing methods to be called in this way require the only paramter to be a GameObject, which will be the object that passed through the collider.

### Spawner
Spawner takes in a prefab to be spawned in. The spawner takes a GameObject to spawn the prefabs under, and will check for disabled objects before spawning a new one. This can be customized in alot of ways, there are a multitude of variables which are self explanitory for the most part. Of note, checking boxes such as useRandomDirection in the inspector will overwrite what is in the spawnDirectionQueue index 0 to use a random direction. Spawning an object can be set as a timer, happening at set intervals, or called as a event. In addition, a spawnDirectionQueue is can be set to determine directions in a round robin fasion, regardless of the number set. All of these variables are public as well, and can be set from a game logic controller if neccesary.

### Death Plane
The death plane is another Trigger collider, this time disabling any objects that pass through it. It has a tag list, and if that tag list has any items in it, then only those tags will be affected by the trigger. If the tag list is empty, then any item passing through it will be disabled. These are good to put beneath any level to catch anything that might fall, as well as powering our object recycling.