using UnityEngine;
using UnityEngine.UI;

public class CardView : MonoBehaviour
{
    private Image img;

    private void Awake()
    {
        img = GetComponent<Image>();
    }

    public void SetCardImg(Sprite sprite)
    {
        img.sprite = sprite;
    }
}
