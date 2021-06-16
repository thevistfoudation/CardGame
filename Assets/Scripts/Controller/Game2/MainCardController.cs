using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.Controller;
using LTAUnityBase.Base.DesignPattern;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class MainCardController : BehaviourController, IPointerClickHandler
{
    public static List<MainCardController> listCardOpeneds = new List<MainCardController>();
    Image img;
    public int index = 0;
    
    private void Awake()
    {
        img = GetComponent<Image>();
        setBackCard();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        
        if (listCardOpeneds.Count >= 2) return;
        enabled = false;

        ScaleTo(new Vector3(0, 1, 1), () =>
        {
            Game.Instance.Clicky += 1;
            Debug.Log("bam vao");
            setCard(index);
            ScaleTo(Vector3.one, () =>
            {
                listCardOpeneds.Add(this);
                if (listCardOpeneds.Count == 2)
                {
                    if (!GameCardController.CheckWin())
                    {
                        foreach (MainCardController card in listCardOpeneds)
                        {
                            card.FlipBack();
                        }
                    }
                    listCardOpeneds.Clear();
                }
            });
        });
        Game.Instance.Time= 1;
        Debug.Log("Time = " + Game.Instance.time);
        Observer.Instance.Notify(TOPICNAME.CLICK);
    }
    private void Update()
    {
        Game.Instance.Click.text = "you have clicked  " + Game.Instance.Clicky.ToString() + " times";
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
