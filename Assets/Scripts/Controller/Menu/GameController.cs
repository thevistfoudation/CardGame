using System.Collections;
using LTAUnityBase.Base.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject SoundGame;
    
    [SerializeField] ButtonController Game1;
    [SerializeField] ButtonController Game2;
    // Start is called before the first frame update

    private void Start()
    {
       
        Game1.OnClick((ButtonController btn) =>
        {
            GlobalVar.currentGame = 0;
            SceneManager.LoadScene(1);
        });
        Game2.OnClick((ButtonController btn) =>
        {
            GlobalVar.currentGame = 1;
            SceneManager.LoadScene(2);
        });
        
    }

  
}

 