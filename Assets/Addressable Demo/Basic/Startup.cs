using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Startup : MonoBehaviour
{
    public Dropdown m_SceneDropdown;

    Button _nextButton;
    private List<Dropdown.OptionData> _optionDatas;

    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(10, 10, 200, 500));
        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Back To Startup"))
        {
            Addressables.LoadSceneAsync("Startup");
        }

        GUILayout.EndHorizontal();

        GUILayout.EndArea();
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);

        _optionDatas = m_SceneDropdown.options;

#if UNITY_EDITOR
        _optionDatas.Clear();

        foreach (var scene in EditorBuildSettings.scenes)
        {
            _optionDatas.Add(new Dropdown.OptionData(System.IO.Path.GetFileNameWithoutExtension(scene.path)));
        }
#endif
    }

    // Use this for initialization
    void Start()
    {
        _nextButton = GetComponent<Button>();
        _nextButton.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        var scene = _optionDatas[m_SceneDropdown.value].text;
        Addressables.LoadSceneAsync(scene, LoadSceneMode.Additive).Completed += handle => { _nextButton.interactable = scene == "Startup"; };
    }
}