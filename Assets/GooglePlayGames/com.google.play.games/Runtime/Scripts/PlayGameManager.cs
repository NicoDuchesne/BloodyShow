using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class PlayGameManager : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Tentative de connexion...");
        SignIn();
    }

    public void SignIn()
    {
        PlayGamesPlatform.Activate();
        PlayGamesPlatform.Instance.Authenticate(ProcessAuthentication);
        Debug.Log("Authentification en cours...");
    }

    internal void ProcessAuthentication(SignInStatus status)
    {
        Debug.Log("Statut de connexion : " + status);

        if (status == SignInStatus.Success)
        {
            string name = PlayGamesPlatform.Instance.GetUserDisplayName();
            string id = PlayGamesPlatform.Instance.GetUserId();
            string ImmgUrl = PlayGamesPlatform.Instance.GetUserImageUrl();

            Debug.Log("Connexion réussie !");
            Debug.Log("Nom: " + name);
            Debug.Log("ID: " + id);
            Debug.Log("URL Image: " + ImmgUrl);
        }
        else
        {
            Debug.LogError("Échec de l'authentification : " + status);
        }
    }
}

