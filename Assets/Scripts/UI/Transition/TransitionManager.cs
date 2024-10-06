using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{
    public static TransitionManager instance;
    private Animator animator;

    void Awake()
    {
        if(instance == null) {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchScene(string nameScene) {
        StartCoroutine(TransitionCoroutine(nameScene));
    }

    private IEnumerator TransitionCoroutine(string nameScene) {
        animator.SetTrigger("Switch");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(nameScene);
    }
}
