using System;
using CDK;
using System.Collections;
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

    public const string CrimeSceneName = "SceneCarTransition - To crime scene";
    public const string PericiaSceneName = "SceneCarTransition - To pericia scene";
    int WaitTime = 5;

    #endregion <<---------- Properties and Fields ---------->>



    
    #region <<---------- Mono Behaviour ---------->>
    
    private void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }
    
    #endregion <<---------- Mono Behaviour ---------->>

    
    

    #region <<---------- General ---------->>

    public void LoadCrimeScene(CSceneField nextScene) {
        StartCoroutine(WaitThenLoadScene(true, nextScene));
    }

    public void LoadPericiaScene(CSceneField nextScene) {
        StartCoroutine(WaitThenLoadScene(false, nextScene));
    }

    private IEnumerator WaitThenLoadScene(bool crimeScene, CSceneField nextScene) {
        SceneManager.LoadScene(crimeScene ? CrimeSceneName : PericiaSceneName, LoadSceneMode.Single);
        yield return new WaitForSeconds(WaitTime);
        SceneManager.LoadScene(nextScene, LoadSceneMode.Single);
    }

    #endregion <<---------- General ---------->>

}
