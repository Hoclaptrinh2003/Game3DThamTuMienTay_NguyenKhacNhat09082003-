using System.Collections;
using UnityEngine;
using TMPro;

public class NotifyMission : Singleton<NotifyMission>
{
    public GameObject Mission;
    public TextMeshProUGUI TextMission; 
    [SerializeField] private string NameMission;

    void Start()
    {
        UpdateMissionText();
    }

    void UpdateMissionText()
    {
        if (TextMission != null)
        {
            TextMission.text = NameMission;
        }
    }

    private IEnumerator Notify_NameMission()
    {
        Mission.SetActive(true);
        yield return new WaitForSeconds(4f);
        Mission.SetActive(false);
    }


    public void TriggerNotification()
    {
        StartCoroutine(Notify_NameMission());
    }
}
