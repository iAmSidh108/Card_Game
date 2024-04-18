using UnityEngine;
using UnityEngine.UI;

public class CardView : MonoBehaviour
{
    [Header("Card Properties")]
    private Image _img;
    public int childIndex;
    public Transform currentGroupContainer;
    public Image selectedCheckMark;
    
    private void Awake()
    {
        _img = GetComponent<Image>();
    }

    public void SetCardImg(Sprite sprite)
    {
        _img.sprite = sprite;
    }
}
