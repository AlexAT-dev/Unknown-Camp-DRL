using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartupController : MonoBehaviourPunCallbacks
{
    [SerializeField] private TextMeshProUGUI textVersion;
    [SerializeField] private TextMeshProUGUI textNickName;
    [SerializeField] private GameObject ConnectionHUD;
    [SerializeField] private TextMeshProUGUI textError;

    private void Start()
    {
        textVersion.text = "Game Version: " + MasterManager.Version;
    }

    public void OnClick_Login()
    {
        if (textNickName.text.Length < 5)
        {
            textError.gameObject.SetActive(true);
            Invoke("HideErrorText", 2f);
            return;
        }

        textError.gameObject.SetActive(false);
        ConnectionHUD.SetActive(true);
        Debug.Log("Connecting...");
        PunManager.Connect(textNickName.text);
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master!");
        PhotonNetwork.JoinLobby();
        SceneManager.LoadScene(MasterManager.SceneNames.MainMenu);
    }

    public override void OnDisconnected(DisconnectCause cause) 
    {
        Debug.Log($"Disconnected ({cause})");
    }

    private void HideErrorText()
    {
        textError.gameObject.SetActive(false);
    }
}
