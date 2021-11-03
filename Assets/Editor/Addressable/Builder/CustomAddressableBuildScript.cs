using System.Collections;
using System.Collections.Generic;
using UnityEditor.AddressableAssets.Build;
using UnityEditor.AddressableAssets.Build.DataBuilders;
using UnityEditor.AddressableAssets.Settings;
using UnityEngine;

public class CustomAddressableBuildScript : BuildScriptBase
{
    protected override TResult BuildDataImplementation<TResult>(AddressablesDataBuilderInput builderInput)
    {
        return base.BuildDataImplementation<TResult>(builderInput);
    }

    protected override string ProcessAllGroups(AddressableAssetsBuildContext aaContext)
    {
        return base.ProcessAllGroups(aaContext);
    }

    protected override string ProcessGroup(AddressableAssetGroup assetGroup, AddressableAssetsBuildContext aaContext)
    {
        return base.ProcessGroup(assetGroup, aaContext);
    }

    public override bool CanBuildData<T>()
    {
        return base.CanBuildData<T>();
    }

    public override void ClearCachedData()
    {
        base.ClearCachedData();
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}