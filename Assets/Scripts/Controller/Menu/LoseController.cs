using LTAUnityBase.Base.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseController : MonoBehaviour
{
    [SerializeField] ButtonController Home;
    [SerializeField] ButtonController Replay;
    [SerializeField] ButtonController Share;
    void Start()
    {
        Replay.OnClick((ButtonController btn) =>
        {
            if(GlobalVar.currentGame == 0)
                SceneManager.LoadScene(1);
            else
                SceneManager.LoadScene(2);
        });
        Home.OnClick((ButtonController btn) =>
        {
            SceneManager.LoadScene(0);
        });
        Share.OnClick((ButtonController btn) =>
        {
            //FaceBook.Instance.ShareBtnPress();
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
