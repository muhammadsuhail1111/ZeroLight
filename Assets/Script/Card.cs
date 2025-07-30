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
    public AudioSource audioSource;
    public float flipDuration = 0.2f;

    private bool isAnimating = false;
    private void Start()
    {
        StartCoroutine(FirstShow());
    }
    public void seticonsprite(Sprite sp)
    {
        iconsprite = sp;
    }
    public void show()
    {
        if (isAnimating) return;
        StartCoroutine(FlipCard(iconsprite));
        isSelected = true;
    }
    public void hide()
    {
        StartCoroutine(FlipCard(hiddeniconsprite));
        isSelected = false;
    }
    public void OnClick()
    {
        controller.SetSelected(this);
        audioSource.Play();
    }
    IEnumerator FirstShow()
    {
        show();
        yield return new WaitForSeconds(4f);
        hide();
    }
    IEnumerator FlipCard(Sprite sprite)
{
    isAnimating = true;
    float time = 0f;

    Quaternion startRotation = transform.rotation;
    Quaternion endRotation = Quaternion.Euler(0, isSelected ? 0 : 180, 0);
    while (time < flipDuration)
    {
        time += Time.deltaTime;
        float t = time / flipDuration;
        transform.rotation = Quaternion.Lerp(startRotation, endRotation, t);
        yield return null;
    }
    iconimage.sprite = sprite;
    isAnimating = false;
}
}
