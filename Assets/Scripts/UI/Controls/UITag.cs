using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UITag : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _caption;

    public void Init(Sprite image, string caption)
    {
        _image.sprite = image;
        _caption.text = caption;
    }
}
