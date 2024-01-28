using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerFimDoJogo : MonoBehaviour
{
    [SerializeField] GameObject fim; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 9)
        {
            GalinhaController.gc.gameObject.SetActive(false);
            fim.SetActive(true);
        }
    }

    public void mudaCena()
    {
        SceneManager.LoadScene(3);
    }

}
