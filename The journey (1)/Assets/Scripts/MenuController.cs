using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField]
        GameObject gmMenu;
    [SerializeField]
        GameObject gmMenuWin;
    [SerializeField]
        GameObject boss;

    GameObject player;

    bool playerIsDead;
    bool bossIsDead;
    bool isRestart = false;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerIsDead = player.GetComponent<PlayerController>().isDead; 
    }

    void Update()
    {
        playerIsDead = player.GetComponent<PlayerController>().isDead;
        bossIsDead = boss.GetComponent<EnemyController>().isDead;

        //Solo los llama una vez
        if (!isRestart)
            if (playerIsDead)
                StartCoroutine(GameOverMenu());
            if (bossIsDead)
                StartCoroutine(WinMenu());

        //Si se acabó el juego, y presiona R se reinicia
        if (Input.GetKeyDown(KeyCode.R) && isRestart)
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }

    IEnumerator GameOverMenu()
    {
        yield return new WaitForSeconds(3);
        gmMenu.SetActive(true);

        isRestart = true;
    }

    IEnumerator WinMenu()
    {
        yield return new WaitForSeconds(2);
        gmMenuWin.SetActive(true);

        isRestart = true;
    }

}
