#### *Basic/Scene Loading*

The ins and outs of scene loading.

- Scenes/Bootstrap
    - This is the scene to start with. From this one you can transition to the other scenes.
    - "Transition to Next Scene" will open a new scene (non-additively), which will close the current scene.
    - "Add Object" will instantiate an addressable prefab into the scene. The point of this button is to show that these items do not need ReleaseInstance called on them. Should you use the Profiler,
      you will see they get cleaned up on scene close.
- Scenes/Foundation
    - This is the scene you transition to from Bootstrap.
    - "Load *" buttons will open other scenes additively.
    - "Unload *" buttons will unload scenes that have been additively loaded.
- Scenes/ItemScenes/*
    - These scenes just contain items with no code. Their purpose is to be additively loaded by the Foundation scene.