using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartUI : MonoBehaviour
{
    [SerializeField]
    private List<Sprite> _sprites;
    [SerializeField]
    private float _delay;
    private Image _image;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void PlayAnimation()
        => StartCoroutine(DestroyCoroutine());

    private IEnumerator DestroyCoroutine()
    {
        var wfs = new WaitForSeconds(_delay);

        for (int i = 0; i < _sprites.Count; i++)
        {
            _image.sprite = _sprites[i];
            yield return wfs;
        }

        Destroy(gameObject);
    }
}
