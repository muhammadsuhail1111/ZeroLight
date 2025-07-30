using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using TMPro;


public class Cardcontroller : MonoBehaviour
{
    private void Start()
    {
        PrepareSprites();
        InstantiateCards();
        StartCoroutine(Setgridlayout());
        gridLayoutGroup.constraintCount = column;
        textturnsleft.text = "Turns Left: " + numberofturns;
    }
    [SerializeField] private Card cardPrefab;
    public Transform gridtransform;
    public string NextLevel ;
    public GameObject gameoverpanel;
    [SerializeField] Sprite[] sprites;
    private List<Sprite> spritepairs;
    Card firstSelectedCard;
    Card secondSelectedCard;
    bool ischecking = false;
    public GridLayoutGroup gridLayoutGroup;
    public int numberofturns = 5;
    public TextMeshProUGUI textturnsleft;
    LockLevels lockLevels = new LockLevels();
    public int row = 2;
    public int column = 2;
    public void PrepareSprites()
    {
        spritepairs = new List<Sprite>();
        for (int i = 0; i < (row * column)/2; i++)
        {
            // Add each sprite twice to create pairs
            spritepairs.Add(sprites[i]);
            spritepairs.Add(sprites[i]);
        }
        // Shuffle the sprite pairs
        ShuffleSprites(spritepairs);
    }
    //method to instantiate cards
    public void InstantiateCards()
    {

        for (int i = 0; i < row * column; i++)
        {
            Card card = Instantiate(cardPrefab, gridtransform);
            card.seticonsprite(spritepairs[i]);
            card.controller = this;
        }

    }
    //method to shuffle the sprites
    public void ShuffleSprites(List<Sprite> spritelist)
    {
        for (int i = spritelist.Count - 1; i > 0; i--)
        {
            int randomindex = Random.Range(0, i + 1);
            // Swap spritelist[i] with the element at random index
            Sprite temp = spritelist[i];
            spritelist[i] = spritelist[randomindex];
            spritelist[randomindex] = temp;
        }
    }
    public void SetSelected(Card card)
    {
        if (ischecking == true) return;
        // Logic to handle card selection
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
            winningcheck();
            textturnsleft.text = "Turns Left: " + numberofturns;
        }
        else
        {
            a.hide();
            b.hide();
            turnsleft();
            textturnsleft.text = "Turns Left: " + numberofturns;
        }
        ischecking = false;
    }
    public IEnumerator Setgridlayout()
    {
        yield return new WaitForSeconds(0.3f);
        gridLayoutGroup.enabled = false;
    }
    public void turnsleft()
    {
        numberofturns--;

        if (numberofturns <= 0)
        {
            Debug.Log("Game Over! No turns left.");
            gameoverpanel.SetActive(true);
        }
    }
    public void winningcheck()
    {
        if (gridtransform.childCount == 2)
        {
            Debug.Log("You win!");
            gameoverpanel.SetActive(true);
            PlayerPrefs.SetInt(NextLevel, 1);
            PlayerPrefs.Save();
        }

    }
 
   
}