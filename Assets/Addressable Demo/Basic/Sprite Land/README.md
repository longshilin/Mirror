#### *Basic/Sprite Land*

*2019.3.0a11+* - Sprite demo is back. There was an engine bug causing a crash when loading out of sprite sheets that caused us to remove this demo. This is in 2019.3 alpha, and is being backported to 2019.2 and 2018.4. If you use this demo,
and your game crashes, or you get warnings about "gfx" not on main thread, you don't have a fixed version of the platform. There are three sprite access methods currently demo'd in this sample. The on-screen button will change functionality
with each click, so you can demo the methods in order.

- Scenes/SampleScene
    - First is having an AssetReference directly to a single sprite. Since this sprite is a single entry, we can reference the asset directly and get the sprite. This is the most simple case.
    - Second is accessing a sprite from within a sprite sheet. This is the one that was causing a crash, but should be fixed now. Here we load the sprite sheet asset as type IList. This tells addressables to load all the sub-objects that
      are sprites, and return them as a list.
    - Third is accessing a sprite from within an atlas. In this case, you have to use addressables to load the sprite atlas, then use the normal atlas API to load a given sprite from it. This example also shows extending the AssetReference
      to provide a typed reference that Addressables doesn't come with (AssetReferenceT in this case).
- All code is in Scripts/SpriteControlTest.cs