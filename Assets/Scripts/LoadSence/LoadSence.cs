using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSence : Singleton<LoadSence>
{
  
    void Start()
    {
       
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.E) && PlayerLaser.Instance.hit.collider.CompareTag("Door" + 80) && PlayerLaser.Instance.targetDistance < 5 && Phone.Instance.timePhone==32)
        {
          

            StartCoroutine(LoadGameWithDelay());
        }
    }

    private IEnumerator LoadGameWithDelay()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("LoadGame");

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        yield return new WaitForSeconds(5f);

        SceneManager.LoadScene("MainGame");
    }
}
