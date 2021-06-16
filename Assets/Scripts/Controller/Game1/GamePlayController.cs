using LTAUnityBase.Base.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlayController : MonoBehaviour
{
    public GameObject PanelInfor;
    [SerializeField]
    CardController[] ListBtn;
    [SerializeField]
    ButtonController BtnStart;
    [SerializeField] Sprite[] images;
    [SerializeField] ButtonController Infor1;
    [SerializeField] ButtonController Exit1;
    private int score = 0;
    private int time = 3;

    public int Score
    {
        set
        {
            score += value;
            if (score == 3)
            {
                Debug.Log("WIN");
                SceneManager.LoadScene(3);
            }
                
        }
    }
   
public int Time
    {
        set
        {
            time -= value;
            if (time == 0 && score < 3)
            {
                Debug.Log("Lose");
                SceneManager.LoadScene(4);
            }
            
        }
    }

    int numWinCards = 3;
    void Start()
    {
        BtnStart.OnClick((ButtonController btn) => {
            MyRandom();
            score = 0;
            time = 3;
            foreach (CardController card in ListBtn)
            {
                card.GetComponent<Image>().color = Color.blue;
            }
        });
        Infor1.OnClick((ButtonController btn) =>
        {
            PanelInfor.SetActive(true);
        });
        Exit1.OnClick((ButtonController btn) =>
        {
            GamePlay.Instance.PanelInfor.SetActive(false);
        });

        MyRandom();
    }
    void MyRandom()
    {
        foreach(CardController card in ListBtn)
        {
            card.isWin = false;
        }
        List<int> listIndexs = new List<int>();

        for (int i = 0; i < ListBtn.Length; i++)
        {
            listIndexs.Add(i);
        }

        for (int i = 0; i < numWinCards; i++)
        {
            int index = Random.Range(0, listIndexs.Count-1);
            Debug.Log(index + " " + listIndexs[index]);
            ListBtn[listIndexs[index]].isWin = true;
            listIndexs.RemoveAt(index);
        }
    }
    
}
public class GamePlay : SingletonMonoBehaviour<GamePlayController>
{ }
