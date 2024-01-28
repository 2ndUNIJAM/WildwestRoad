using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VersionUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _version;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        _version.text = $"Version: {Application.version}";
    }
}
