using UnityEngine;
using UnityEngine.UI;

public class CardView : MonoBehaviour
{
    private Image img;
    public int childIndex;
    public Transform currentGroupContainer;
    //public Image selectedCheckMark;

    private void Awake()
    {
        img = GetComponent<Image>();
    }

    public void SetCardImg(Sprite sprite)
    {
        img.sprite = sprite;
    }
}
