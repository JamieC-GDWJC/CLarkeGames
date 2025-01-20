using System.Collections;
using UnityEngine;

public class AnimationCom : MonoBehaviour
{
    private bool firstClick = false;
    private Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!firstClick && Input.GetMouseButtonDown(0))
        {
            firstClick = true;
            playAnim("Greet");
            StartCoroutine(ResetWeightAfterDelay("Greet", 2f)); 
        }
    }
    
    public void playAnim(string AnimName)
    {
        if (anim.GetLayerIndex(AnimName) == null)
        {
            return;
        }
        StartCoroutine(SetWeightSlowly(anim.GetLayerIndex(AnimName), .9f, .5f));

    }

    IEnumerator SetWeightSlowly(int animIndex, float targetWeight, float duration)
    {
        float startWeight = anim.GetLayerWeight(animIndex);
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float newWeight = Mathf.Lerp(startWeight, targetWeight, elapsedTime / duration);
            anim.SetLayerWeight(animIndex, newWeight);
            yield return null;  // Wait for the next frame
        }

        // Ensure the final value is set to avoid precision errors
        anim.SetLayerWeight(animIndex, targetWeight);
    }
    IEnumerator ResetWeightAfterDelay(string animName, float delay)
    {
        yield return new WaitForSeconds(delay);
        int animIndex = anim.GetLayerIndex(animName);

        if (animIndex != -1)
        {
            StartCoroutine(SetWeightSlowly(animIndex, 0f, 0.5f)); // Fade out weight to 0 over 0.5 seconds
        }
    }
}
