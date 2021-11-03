#### *Basic/ComponentReference*

This example creates an AssetReference that is restricted to having a specific Component.

- Scenes/SampleScene
    - This scene has a Spawner game object that alternates between spawning a direct reference prefab and an addressable one.
    - Both the direct reference and the addressable ComponentReference can only be set to one of the prefabs with the component ColorChanger on it.
- Scripts/ComponentReference - ComponentReference
    - This is the class that inherits from AssetReference. It is generic and does not specify which Components it might care about. A concrete child of this class is required for serialization to work.
    - At edit-time it validates that the asset set on it is a GameObject with the required Component.
    - At runtime it can load/instantiate the GameObject, then return the desired component. API matches base class (LoadAssetAsync & InstantiateAsync).
- Scripts/ColorChanger - ColorChanger & ComponentReferenceColorChanger
    - The component type we chose to care about.
    - Note that this file includes a concrete version of the ComponentReference. This is needed because if your game code just specified a ComponentReference it could not serialize or show up in the inspector. This
      ComponentReferenceColorChanger is what makes serialization and the inspector UI work.
    - Releasing a ComponentReference should be done through `ReleaseInstance()` in the ComponentReference class. To release an instance directly, see our implementation of ReleaseInstance to understand the requirements.