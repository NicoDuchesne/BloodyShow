using GooglePlayGames;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    //public GameObject on;
    //public GameObject off;


    void Start()
    {
        // Initialisation de Google Play Games
        PlayGamesPlatform.Activate();
    }

    //public void ShowAchievements()
    //{
    //    if (Social.localUser.authenticated)
    //    {
    //        Social.ShowAchievementsUI();
    //        on.SetActive(true);
    //        off.SetActive(false);
    //    }
    //    else
    //    {
    //        Debug.Log("Utilisateur non connect� !");
    //        on.SetActive(false);
    //        off.SetActive(true);
    //    }
    //}

    public void ShowAchievements()
    {
            Social.ShowAchievementsUI();
    }

    public void UnlockTutorialAchievement()
    {
        if (Social.localUser.authenticated)
        {
            // D�verrouiller l'achievement "Complete the tutorial"
            Social.ReportProgress(GPGSIds.achievement_complete_the_tutorial, 100.0f, success =>
            {
                if (success)
                {
                    Debug.Log("Achievement d�bloqu� !");
                }
                else
                {
                    Debug.Log("�chec du d�blocage !");
                }
            });
        }
        else
        {
            Debug.Log("Utilisateur non connect� !");
        }
    }
}

