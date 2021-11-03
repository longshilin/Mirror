Several sample scenes to display functionality surrounding the asset reference class.

- Scenes/BasicReference
    - Simplest example using a reference to spawn and destroy a game object
    - Each object is instantiated directly via the `AssetReference` which will increment the ref count.
    - Each object spawned has a script on it that will cause it to release itself after a certain amount of time. This
      destroys the object and decrements the ref count.
    - Any instances still around when the scene closes will automatically be released (decrementing ref count) by the
      scene closing process (even if their self-destruct script were disabled).
- Scenes/ListOfReferences
    - Showcases using references within a list.
    - Key feature: once an `AssetReference` is loaded it keeps a member called `.Asset`. In this example, you would not
      want to use the on-complete callback to save off the asset as the loads may not complete in the same order as they
      were triggered. Thus, it's useful that the reference keeps up with its own loaded asset.
    - Here the objects are instantiated via the traditional `GameObject.Instantiate` which will not increment the
      Addressables ref count. These objects still call into Addressables to release themselves, but since they were not
      instantiated via Addressables, the release only destroys the object, and does not decrement the ref count.
    - The manager of these AssetReferences must release them in `OnDestroy` or the ref count will survive the closing of
      the scene.
- Scenes/FilteredReferences
    - Showcases utilizing the various filtering options on the `AssetReference` class.
    - This scene also shows an alternative loading patter to the one used in other scenes. It shows how you can utilize
      the Asset property. It is recommended that you only use the Asset for ease of load. You could theoretically also
      use it to poll completion, but you would never find out about errors in that usage.
    - This sample shows loading via the `AssetReference` but instantiating via Unity's built in method. This will only
      increment the ref count once (for the load).
    - Currently, the objects created are being destroyed with Addressables.ReleaseInstance even though they were not
      created that way. As of version 0.8, this will throw a warning, but still delete the asset. In the future, our
      intent is to make this method not destroy the asset, or print a warning. Instead it will return a boolean so you
      can destroy manually if needed.
- Scenes/SubobjectReference
    - Showcases using references with sub objects.
    - An `AssetReference` contains an main asset (`editorAsset`) and an optional sub object. Certain reference types (
      for example, references to sprite sheets and sprite atlases) can use sub objects. If the reference uses a sub
      object, then it will load the main asset during edit mode and load the sub object during runtime.
    - This scene shows loading a sprite from a sprite sheet (main asset) and loading a sprite as a sub object during
      runtime.

