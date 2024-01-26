using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InitiationUI : MonoBehaviour
{
    [SerializeField]
    private GameObject _player0Gun;
    [SerializeField]
    private GameObject _player1Gun;
    [SerializeField]
    private GameObject _player0Heart;
    [SerializeField]
    private GameObject _player1Heart;
    [SerializeField]
    private GameObject _player0Character;
    [SerializeField]
    private GameObject _player1Character;
    [SerializeField]
    private List<Image> _gunList;
    [SerializeField]
    private List<Image> _characterList;
    [SerializeField]
    private List<GameObject> _heartImageList;
}
