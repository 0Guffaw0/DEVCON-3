using UnityEngine;
using UnityEngine.SceneManagement;
public class RestartTrigger : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
       
    }
}