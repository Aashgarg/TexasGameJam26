using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class PoolBall : MonoBehaviour
{
    public int baseValue = 1;
    public TextMeshProUGUI ballText;
    [SerializeField] private int currentMultiplier = 1;
    public AudioSource source;
    public AudioClip hitSound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball") || collision.gameObject.CompareTag("Wall"))
        {
            source.PlayOneShot(hitSound);
            currentMultiplier++;
            ballText.text = "" + baseValue * currentMultiplier;
            Debug.Log($"{gameObject.name} multiplier is now x{currentMultiplier}!");
        }
    }
    public int GetFinalScoreValue()
    {
        return baseValue * currentMultiplier;
    }

}
