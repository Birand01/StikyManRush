using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text diamondText,tapToPlayText;
    [SerializeField] GameObject failPanel,successPanel;

    public static UIManager Instance { get; private set; }
   

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        PlayerMovement.OnLevelStart += TapToPlayTxtInvisibility;
        Collector.OnDiamondCollect += DiamondToAdd;
    }

    private void DiamondToAdd(int diamond)
    {
        diamondText.text = diamond.ToString();
    }
    private void TapToPlayTxtInvisibility()
    {
        tapToPlayText.gameObject.SetActive(false);
    }
    public void FailPanel()
    {
        StartCoroutine(PanelDelay(failPanel));
    }
    public void SuccessPanel()
    {
        StartCoroutine(PanelDelay(successPanel));
    }

    IEnumerator PanelDelay(GameObject panelType)
    {
        yield return new WaitForSeconds(2f);
        panelType.SetActive(true);
    }

   

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    private void OnDestroy()
    {
        PlayerMovement.OnLevelStart -= TapToPlayTxtInvisibility;
        Collector.OnDiamondCollect -= DiamondToAdd;
    }
  
}
