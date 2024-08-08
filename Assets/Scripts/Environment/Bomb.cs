using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Bomb : MonoBehaviour,Iobserver
{
    [SerializeField] private GameObject BombGame;
    [SerializeField] private string ID_Bomb;

    private void Awake()
    {
        SubJect.Register(this);
    }
    public void onNotify(string key)
    {
        if (key != "OnOpenDoor"+ID_Bomb) { return; }


        StartCoroutine(Notify_KickBomb());


    }

    public IEnumerator Notify_KickBomb()
    {
       
        yield return new WaitForSeconds(1.5f);
        KickBomb();
    }
    public void KickBomb()
    {
      
       BombGame.SetActive(true);
    }
}
