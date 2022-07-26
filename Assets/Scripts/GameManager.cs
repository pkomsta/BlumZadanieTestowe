using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] Heart heartToSpawn;
    [SerializeField] int heartsNumber;
    [SerializeField] TextMeshProUGUI coinNumber;
    [SerializeField] GameObject heartsContainer;
    [SerializeField] GameObject gameoverScreen;
    [HideInInspector] public Stack<Heart> hearts = new Stack<Heart>();
    int coins = 0;


    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        for (int i = 0; i < heartsNumber; i++)
        {
            var heart = Instantiate(heartToSpawn, heartsContainer.transform);
            hearts.Push(heart);
        }
    }

    public void GetHeartAndPopIt()
    {
        if (hearts != null)
        {
            hearts.Peek().DestroyHeart();
            hearts.Pop();
        }
    }

    public void AddToCoins()
    {
        coins++;
        coinNumber.text = "" + coins.ToString("0000");
    }


    public void GameOver()
    {
        StartCoroutine(FadeIn());

    }

    private IEnumerator FadeIn()
    {
        var go = gameoverScreen.GetComponent<Image>().color;
        var gotxt = gameoverScreen.transform.Find("GameOverText").GetComponent<TextMeshProUGUI>().color;
        float duration = 2f;
        float currentTime = 0f;
        while (currentTime < duration)
        {
            float alpha = Mathf.Lerp(0f, 0.8f, currentTime / duration);
            gameoverScreen.GetComponent<Image>().color = new Color(go.r, go.g, go.b, alpha);
            gameoverScreen.transform.Find("GameOverText").GetComponent<TextMeshProUGUI>().color = new Color(gotxt.r, gotxt.g, gotxt.b, alpha);
            currentTime += Time.deltaTime;

            yield return null;
        }
        gameoverScreen.transform.Find("Restart").gameObject.SetActive(true);
        yield break;
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
    public void DestroyOnDeath(GameObject gameObject)
    {
        Destroy(gameObject);
    }
}

