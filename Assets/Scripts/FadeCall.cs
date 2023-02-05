using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;
using Image = UnityEngine.UI.Image;

public class FadeCall : MonoBehaviour
{
   public Image blackfade;
   public Animator animFade;
   private string lvlName;
   public GameObject optionsPanel;
   
   public void Fade(string scene)
   {
      Debug.Log("Clicou");
      lvlName = scene;
      StartCoroutine(GoToNextLevel());
   }
   
   IEnumerator GoToNextLevel()
   {
      animFade.SetBool("fade", true);
      yield return new WaitUntil(() => blackfade.color.a == 1);
      SceneManager.LoadScene(lvlName);
   }

   public void Restart()
   {
      SceneManager.LoadScene("Test-Eduardo");
      CloseOptionsPanel();
   }

   public void OpenOptionsPanel()
   {
      Time.timeScale = 0;
      optionsPanel.SetActive(true);
   }
   public void CloseOptionsPanel()
   {
      Time.timeScale = 1;
      optionsPanel.SetActive(false);
   }
   public void Quit()
   {
      
      Application.Quit();
   }
    
}
