using System.Collections;
using UnityEngine;

public class MonkeyController : MonoBehaviour
{
    [SerializeField] AudioDetection audioDetection;
    [SerializeField] float loudnessSensibility = 100f;
    [SerializeField] float threshold = 0.4f;
    [SerializeField] float quietPoint = 1f;
    [SerializeField] float mediumPoint = 7f;
    [SerializeField] Sprite[] instructions;
    [SerializeField] Sprite yourTurn;
    [SerializeField] Sprite wrong;
    [SerializeField] Sprite win;
    [SerializeField] Sprite yay;
    [SerializeField] float instructionTime = 0.5f;
    [SerializeField] GameObject exitButton;
    SpriteRenderer spriteRenderer;
    int[] volumeIndices = new int[3];
    bool listening;
    int currentVolumeIndex;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(MonkeySay());
    }

    private void Update()
    {
        if (listening)
        {
            float loudness = audioDetection.GetLoudnessFromMicrophone() * loudnessSensibility;

            if (loudness > threshold)
            {
                listening = false;

                if ((volumeIndices[currentVolumeIndex] == 2 && loudness > mediumPoint) ||
                    (volumeIndices[currentVolumeIndex] == 1 && loudness > quietPoint) ||
                    (volumeIndices[currentVolumeIndex] == 0))
                {
                    StartCoroutine(WaitToListen());
                    print("point");
                }
                else
                {
                    //if (loudness > mediumPoint)
                    //{
                    //    print("lose: loud");
                    //}
                    //else if (loudness > quietPoint)
                    //{
                    //    print("lose: medium");
                    //}
                    //else if (loudness > threshold)
                    //{
                    //    print("lose: quiet");
                    //}

                    spriteRenderer.sprite = wrong;

                    exitButton.SetActive(true);

                    listening = false;
                    return;
                }
            }
        }
    }

    IEnumerator MonkeySay()
    {
        spriteRenderer.sprite = null;

        yield return new WaitForSeconds(instructionTime * 2f);

        for (int i = 0; i < volumeIndices.Length; i++)
        {
            volumeIndices[i] = Random.Range(0, 3);

            spriteRenderer.sprite = instructions[volumeIndices[i]];

            yield return new WaitForSeconds(instructionTime);

            spriteRenderer.sprite = null;

            yield return new WaitForSeconds(instructionTime / 2f);
        }

        spriteRenderer.sprite = yourTurn;

        yield return new WaitForSeconds(instructionTime);

        currentVolumeIndex = 0;
        listening = true;
    }

    IEnumerator WaitToListen()
    {
        if (currentVolumeIndex < 2)
        {
            currentVolumeIndex++;
            spriteRenderer.sprite = yay;
            yield return new WaitForSeconds(instructionTime * 2f);
            spriteRenderer.sprite = null;
            listening = true;
        }
        else
        {
            print("win");
            spriteRenderer.sprite = win;
            StartCoroutine(MonkeySay());
        }
    }
}
