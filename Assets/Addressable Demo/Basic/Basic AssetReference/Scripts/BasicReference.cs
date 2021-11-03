using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement;

public class BasicReference : MonoBehaviour
{
    public AssetReference baseCube;

    public void SpawnThing()
    {
        baseCube.InstantiateAsync();
    }
}