using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using JetBrains.Annotations;

public class Card : MonoBehaviour
{
    [SerializeField] private Image iconimage;
    public Sprite hiddeniconsprite;
    public Sprite iconsprite;
    public bool isSelected = false;
    public Cardcontroller controller;
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
    public void OnClick()
    {
        controller.SetSelected(this);
    }
}
