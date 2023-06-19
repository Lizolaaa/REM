using CDK;
using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScenesCarTransition : MonoBehaviour {

    #region <<---------- Singleton ---------->>

    public static GameScenesCarTransition get {
        get {
            if (_instance != null) return _instance;
            return (_instance = new GameObject("Car transition controller").AddComponent<GameScenesCarTransition>());
        }
    }
    private static GameScenesCarTransition _instance;

    #endregion <<---------- Singleton ---------->>

    
    
    
    #region <<---------- Properties and Fields ---------->>

    public const string CarTransitionSceneName = "SceneCarTransition";
    int WaitTime = 5;

    #endregion <<---------- Properties and Fields ---------->>



    
    #region <<---------- Mono Behaviour ---------->>
    
    private void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }
    
    #endregion <<---------- Mono Behaviour ---------->>

    
    

    #region <<---------- General ---------->>

    public void LoadCarScene(string mensagem, CSceneField nextScene) {
        StartCoroutine(WaitThenLoadScene(mensagem, nextScene));
    }

    private IEnumerator WaitThenLoadScene(string mensagem, CSceneField nextScene) {
        if (mensagem.CIsNotNullOrWhitespace()) {
            SceneManager.LoadScene(CarTransitionSceneName, LoadSceneMode.Single);
            var txt = GameObject.FindObjectsOfType<TextMeshProUGUI>().First(t => t.name == "Text - A caminho");
            txt.text = mensagem;
            yield return new WaitForSeconds(WaitTime);
        }
        SceneManager.LoadScene(nextScene, LoadSceneMode.Single);
    }

    #endregion <<---------- General ---------->>

}
