using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] private Image iconimage;
    public Sprite hiddeniconsprite;
    public Sprite iconsprite;
    public bool isSelected = false;
    public void seticonsprite(Sprite sp)
    {
        iconsprite = sp;
    }
    public void show()
    {
        iconimage.sprite = iconsprite;
        isSelected = true;
    }
    public void hide()
    {
        iconimage.sprite = hiddeniconsprite;
        isSelected = false;
    }
}
