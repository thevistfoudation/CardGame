using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.UI;
using UnityEngine.EventSystems;
using LTAUnityBase.Base.Controller;
using UnityEngine.UI;
public class CardController : BehaviourController, IPointerClickHandler 
{
    public static List<CardController> listCardOpeneds = new List<CardController>();
    public bool isWin = false;
    public int index = 0;
    Image img;
    private void Awake()
    {
        img = GetComponent<Image>();
        setBackCard();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        ScaleTo(new Vector3(0, 1, 1), () =>
        {
            setCard(index);
            ScaleTo(Vector3.one, () =>
            {
                listCardOpeneds.Add(this);

                if (isWin == true)
                {
                    this.transform.GetComponent<Image>().color = Color.red;
                    GamePlay.Instance.Score = 1;
                }
                else
                    this.transform.GetComponent<Image>().color = Color.white;
                    GamePlay.Instance.Time = 1;
            });
        });
        //base.OnPointerClick(eventData);
    }
    public void FlipBack()
    {
        ScaleTo(new Vector3(0, 1, 1), () =>
        {
            setBackCard();
            ScaleTo(Vector3.one, () =>
            {
                enabled = true;
            });
        });
    }
    void setBackCard()
    {
        img.sprite = Resources.Load<Sprite>("UiPoker/card/active/12");
    }
    void setCard(int index)
    {
        img.sprite = Resources.Load<Sprite>("UiPoker/card/active/" + index);
    }
} 