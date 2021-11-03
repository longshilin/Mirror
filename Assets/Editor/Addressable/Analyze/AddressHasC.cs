using System.Collections.Generic;
using UnityEditor;
using UnityEditor.AddressableAssets.Build;
using UnityEditor.AddressableAssets.Settings;
using UnityEditor.AddressableAssets.Settings.GroupSchemas;

/// <summary>
/// Addressable Analyze 自定义分析check规则
///     资源路径中是否包含C字符
/// </summary>
public class AddressHasC : UnityEditor.AddressableAssets.Build.AnalyzeRules.AnalyzeRule
{
    public override bool CanFix
    {
        get { return false; }
        set { }
    }

    public override string ruleName
    {
        get { return "[Custom Test] Ensure all addresses have a 'C'"; }
    }

    public override List<AnalyzeResult> RefreshAnalysis(AddressableAssetSettings settings)
    {
        List<AnalyzeResult> results = new List<AnalyzeResult>();
        foreach (var group in settings.groups)
        {
            if (group.HasSchema<PlayerDataGroupSchema>())
                continue;

            foreach (var e in group.entries)
            {
                if (!e.address.Contains("C"))
                    results.Add(new AnalyzeResult { resultName = group.Name + kDelimiter + e.address, severity = MessageType.Error });
            }
        }

        if (results.Count == 0)
            results.Add(new AnalyzeResult { resultName = ruleName + " - No issues found." });

        return results;
    }
}


[InitializeOnLoad]
class RegisterAddressHasC
{
    static RegisterAddressHasC()
    {
        AnalyzeSystem.RegisterNewRule<AddressHasC>();
    }
}