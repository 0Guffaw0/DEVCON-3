using UnityEngine;
using UnityEngine.SceneManagement; 

public class FrogWin : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Frog"))
        {
           
            Win();
        }
    }

    
    private void Win()
    {
        Debug.Log("You win!");
       
        SceneManager.LoadScene("YouWin");
    }
}
