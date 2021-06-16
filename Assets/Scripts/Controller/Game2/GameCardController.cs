using System.Collections;
using LTAUnityBase.Base.UI;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameCardController : MonoBehaviour
{
    [SerializeField] ButtonController Infor2;
    [SerializeField] ButtonController Exit2;
    [SerializeField]
    MainCardController[] cardControllers;
    public GameObject PopUpInfor;
    //public Text Timetxt;
    static int score = 0;
    public int time = 15;
    public int Clicky ;
    public Text Click;
    private void Awake()
    {
        score = 0;
        List<MainCardController> cards = new List<MainCardController>(cardControllers);
        for (int i = 0; i < 4; i++)
        {
            int index = Random.Range(0, cards.Count);
            cards[index].index = i;
            cards.RemoveAt(index);
            index = Random.Range(0, cards.Count);
            cards[index].index = i;
            cards.RemoveAt(index);
        }
        Infor2.OnClick((ButtonController btn) =>
        {
            Game.Instance.PopUpInfor.SetActive(true);
        });
        Exit2.OnClick((ButtonController btn) =>
        {
            PopUpInfor.SetActive(false);
        });
        
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
    public static bool CheckWin()
    {
        List<MainCardController> listCards = MainCardController.listCardOpeneds;
        bool result = listCards[0].index == listCards[1].index;
        if (result)
            score++;
        if (score == 4)
        {
            Debug.Log("You Win");
            SceneManager.LoadScene(3);
        }
        return result;
    }
}

public class Game : SingletonMonoBehaviour<GameCardController>
{

}
