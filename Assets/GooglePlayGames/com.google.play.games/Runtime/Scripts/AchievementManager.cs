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

    public void ShowAchievements()
    {
            Social.ShowAchievementsUI();
    }

    public static void UnlockTutorial1Achievement()
    {
        if (Social.localUser.authenticated)
        {
            Social.ReportProgress(GPGSIds.achievement_its_showtime, 100.0f, success =>
            {
                if (success)
                {
                    Debug.Log("Achievement débloqué !");
                }
                else
                {
                    Debug.Log("Échec du déblocage !");
                }
            });
        }
        else
        {
            Debug.Log("Utilisateur non connecté !");
        }

    }

    public static void UnlockTutorial2Achievement()
    {
        if (Social.localUser.authenticated)
        {
            Social.ReportProgress(GPGSIds.achievement_first_act__exposition, 100.0f, success =>
            {
                if (success)
                {
                    Debug.Log("Achievement débloqué !");
                }
                else
                {
                    Debug.Log("Échec du déblocage !");
                }
            });
        }
        else
        {
            Debug.Log("Utilisateur non connecté !");
        }

    }

    public static void UnlockTutorial3Achievement()
    {
        if (Social.localUser.authenticated)
        {
            Social.ReportProgress(GPGSIds.achievement_get_the_hang_of_it, 100.0f, success =>
            {
                if (success)
                {
                    Debug.Log("Achievement débloqué !");
                }
                else
                {
                    Debug.Log("Échec du déblocage !");
                }
            });
        }
        else
        {
            Debug.Log("Utilisateur non connecté !");
        }

    }

    public static void UnlockTutorial4Achievement()
    {
        if (Social.localUser.authenticated)
        {
            Social.ReportProgress(GPGSIds.achievement_second_act__plot_point, 100.0f, success =>
            {
                if (success)
                {
                    Debug.Log("Achievement débloqué !");
                }
                else
                {
                    Debug.Log("Échec du déblocage !");
                }
            });
        }
        else
        {
            Debug.Log("Utilisateur non connecté !");
        }

    }

    public static void UnlockTutorial5Achievement()
    {
        if (Social.localUser.authenticated)
        {
            Social.ReportProgress(GPGSIds.achievement_youre_a_smart_one, 100.0f, success =>
            {
                if (success)
                {
                    Debug.Log("Achievement débloqué !");
                }
                else
                {
                    Debug.Log("Échec du déblocage !");
                }
            });
        }
        else
        {
            Debug.Log("Utilisateur non connecté !");
        }

    }

    public static void UnlockTutorial6Achievement()
    {
        if (Social.localUser.authenticated)
        {
            Social.ReportProgress(GPGSIds.achievement_final_act__outcome, 100.0f, success =>
            {
                if (success)
                {
                    Debug.Log("Achievement débloqué !");
                }
                else
                {
                    Debug.Log("Échec du déblocage !");
                }
            });
        }
        else
        {
            Debug.Log("Utilisateur non connecté !");
        }

    }

    public static void UnlockTutorial7Achievement()
    {
        if (Social.localUser.authenticated)
        {
            Social.ReportProgress(GPGSIds.achievement_star_psycho, 100.0f, success =>
            {
                if (success)
                {
                    Debug.Log("Achievement débloqué !");
                }
                else
                {
                    Debug.Log("Échec du déblocage !");
                }
            });
        }
        else
        {
            Debug.Log("Utilisateur non connecté !");
        }

    }

    public static void UnlockTutorial8Achievement()
    {
        if (Social.localUser.authenticated)
        {
            Social.ReportProgress(GPGSIds.achievement_catppetite, 100.0f, success =>
            {
                if (success)
                {
                    Debug.Log("Achievement débloqué !");
                }
                else
                {
                    Debug.Log("Échec du déblocage !");
                }
            });
        }
        else
        {
            Debug.Log("Utilisateur non connecté !");
        }

    }
}

