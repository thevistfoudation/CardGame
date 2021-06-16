using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LTAUnityBase.Base.DesignPattern;

public class ShareSocial : MonoBehaviour
{
    
    private void Awake()
    {
        
    }
    public void ShareBtnPress()
    {
        StartCoroutine(TakeSSAndShare());
    }


    private IEnumerator TakeSSAndShare()
    {
        yield return new WaitForEndOfFrame();

        Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        ss.Apply();

        string filePath = Path.Combine(Application.temporaryCachePath, "sharedImg.png");
        File.WriteAllBytes(filePath, ss.EncodeToPNG());

        // To avoid memory leaks
        Destroy(ss);

        new NativeShare().AddFile(filePath).SetSubject("Subject goes here").SetText("Hello world!").Share();


    }
}
public class FaceBook : SingletonMonoBehaviour<ShareSocial>
{ }