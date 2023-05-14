using CDK;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScenesCarTransition : MonoBehaviour
{
    const string CrimeSceneName = "SceneCarTransition - To crime scene";
    const string PericiaSceneName = "SceneCarTransition - To pericia scene";
    [SerializeField] int WaitTime = 5;

    public void LoadCrimeScene(CSceneField nextScene)
    {
        StartCoroutine(WaitThenLoadScene(true, nextScene));
    }

    public void LoadPericiaScene(CSceneField nextScene)
    {
        StartCoroutine(WaitThenLoadScene(false, nextScene));
    }

    private IEnumerator WaitThenLoadScene(bool crimeScene, CSceneField nextScene)
    {
        SceneManager.LoadScene(crimeScene ? CrimeSceneName : PericiaSceneName, LoadSceneMode.Single);
        yield return new WaitForSeconds(WaitTime);
        SceneManager.LoadScene(nextScene, LoadSceneMode.Single);
    }


}
