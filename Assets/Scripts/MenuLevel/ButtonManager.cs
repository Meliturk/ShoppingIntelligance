using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonManager : MonoBehaviour
{
    public Button baslaBtn; 
    public float ziplamaYuksekligi = 10f; 
    public float ziplamaSuresi = 0.2f; 
    public float ziplamaAraligi = 1f; 

    private Vector3 originalPosition;
    private bool ziplamayiKontrolEt = false; 

    void Start()
    {
        StartCoroutine(WaitAndStartJumping());
    }

    IEnumerator WaitAndStartJumping()
    {
        yield return new WaitForSeconds(2f);

        originalPosition = baslaBtn.transform.position;
        ziplamayiKontrolEt = true;

        StartCoroutine(JumpRoutine());
    }

    IEnumerator JumpRoutine()
    {
        while (ziplamayiKontrolEt)
        {
            float elapsedTime = 0f;
            Vector3 targetPosition = originalPosition + Vector3.up * ziplamaYuksekligi;
            while (elapsedTime < ziplamaSuresi)
            {
                baslaBtn.transform.position = Vector3.Lerp(originalPosition, targetPosition, elapsedTime / ziplamaSuresi);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            baslaBtn.transform.position = targetPosition;

            elapsedTime = 0f;
            while (elapsedTime < ziplamaSuresi)
            {
                baslaBtn.transform.position = Vector3.Lerp(targetPosition, originalPosition, elapsedTime / ziplamaSuresi);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            baslaBtn.transform.position = originalPosition;

            yield return new WaitForSeconds(ziplamaAraligi);
        }
    }
}
