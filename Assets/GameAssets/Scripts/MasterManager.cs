using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MasterManager : MonoBehaviour
{
    public static MasterManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public enum Input
    {
        Action1,
        Action2,
        Action3
    }

    [Serializable]
    public struct CustomTagName
    {
        public string PlayerCamper;
        public string PlayerCatcher;
        public string MyCollider;
    }

    [Serializable]
    public struct SceneName
    {
        public string Startup;
        public string MainMenu;
        public string Lobby;
        public string Game;
    }

    [SerializeField] private string version;
    [SerializeField] private CustomTagName customTagNames;
    [SerializeField] private SceneName sceneNames;
    [SerializeField] private CharactersList charactersList;

    public static string Version => Instance.version;
    public static CustomTagName CustomTagNames => Instance.customTagNames;
    public static SceneName SceneNames => Instance.sceneNames;
    public static CharactersList CharactersList => Instance.charactersList;

    public static bool ItsPlayerTag(string tag) => tag == CustomTagNames.PlayerCamper || tag == CustomTagNames.PlayerCatcher;

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
