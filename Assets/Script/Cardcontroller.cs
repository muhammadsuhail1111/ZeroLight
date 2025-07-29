using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;


public class Cardcontroller : MonoBehaviour
{
    private void Start()
    {
        // Initialize the card controller
        PrepareSprites();
        InstantiateCards();
        StartCoroutine(Setgridlayout());

    }
    [SerializeField] private Card cardPrefab;
    public Transform gridtransform;

    [SerializeField] Sprite[] sprites;
    private List<Sprite> spritepairs;
    Card firstSelectedCard;
    Card secondSelectedCard;
    bool ischecking = false;
    public GridLayoutGroup gridLayoutGroup;
    public void PrepareSprites()

    {
        spritepairs = new List<Sprite>();
        for (int i = 0; i < sprites.Length; i++)
        {
            spritepairs.Add(sprites[i]);
            spritepairs.Add(sprites[i]);
        }
        ShuffleSprites(spritepairs);
    }
    public void InstantiateCards()
    {

        for (int i = 0; i < spritepairs.Count; i++)
        {
            Card card = Instantiate(cardPrefab, gridtransform);
            card.seticonsprite(spritepairs[i]);
            card.controller = this;
        }

    }
    public void ShuffleSprites(List<Sprite> spritelist)
    {
        for (int i = spritelist.Count - 1; i > 0; i--)
        {
            int randomindex = Random.Range(0, i + 1);

            Sprite temp = spritelist[i];
            spritelist[i] = spritelist[randomindex];
            spritelist[randomindex] = temp;
        }
    }
    public void SetSelected(Card card)
    {
        if (ischecking == true) return;

        if (card.isSelected == false)
        {
            card.show();
            if (firstSelectedCard == null)
            {
                firstSelectedCard = card;
                return;
            }
            if (secondSelectedCard == null)
            {
                secondSelectedCard = card;
                StartCoroutine(Checkmatching(firstSelectedCard, secondSelectedCard));
                firstSelectedCard = null;
                secondSelectedCard = null;

            }
        }

    }
    IEnumerator Checkmatching(Card a, Card b)
    {
        ischecking = true;
        yield return new WaitForSeconds(1f);
        if (a.iconsprite == b.iconsprite)
        {
            Destroy(a.gameObject);
            Destroy(b.gameObject);
        }
        else
        {
            a.hide();
            b.hide();
        }
        ischecking = false;
    }
    public IEnumerator Setgridlayout()
    {
        yield return new WaitForSeconds(0.3f);
        gridLayoutGroup.enabled = false;
    }
   
}