using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element_Script : MonoBehaviour
{

    Vector2 initPosition, initScale;

    float MARGE = 10;
    float SCALE_MARGE = 0.1f;

    float floatSpeed = 5;
    float scaleLoopableSpeed = 0.03f;

    bool isLoopablePlayed = false;

    void OnEnable()
    {
        StopAllCoroutines();
        isLoopablePlayed = false;

        initScale = Vector2.one;

        initPosition = transform.position;

        /*Vector2 randRange = initPosition;
        randRange.y += Random.Range(-MARGE, MARGE);

        transform.position = randRange;*/

        StartCoroutine(Spawn_Anim());
    }

    void Update()
    {
        if (isLoopablePlayed)
        {
            isLoopablePlayed = false;
            StartCoroutine(Loopable_Scale());
        }
    }

    IEnumerator Spawn_Anim()
    {
        Vector2 currentScale = initScale;

        transform.localScale = Vector2.zero;
        currentScale = transform.localScale;

        while (transform.localScale.x < initScale.x)
        {
            float randSpeed = Random.Range(2f, floatSpeed);
            currentScale.x += Time.deltaTime * randSpeed;
            currentScale.y += Time.deltaTime * randSpeed;

            transform.localScale = currentScale;
            yield return new WaitForEndOfFrame();
        }

        transform.localScale = initScale;

       isLoopablePlayed = true;
    }

    IEnumerator Loopable_Float()
    {
        Vector2 targetPos = initPosition;
        Vector2 currentPos = transform.position;

        while (true)
        {

            targetPos = initPosition;
            targetPos.y += MARGE;

            while (transform.position.y < targetPos.y)
            {
                currentPos.y += Time.deltaTime * floatSpeed;
                transform.position = currentPos;
                yield return new WaitForEndOfFrame();
            }

            targetPos = initPosition;
            targetPos.y -= MARGE;

            while (transform.position.y > targetPos.y)
            {
                currentPos.y -= Time.deltaTime * floatSpeed;
                transform.position = currentPos;
                yield return new WaitForEndOfFrame();
            }
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator Loopable_Scale()
    {
        Vector2 targetScale = initScale;
        Vector2 currentScale = transform.localScale;

        while (true)
        {

            targetScale = initScale;
            targetScale.x += SCALE_MARGE;

            while (transform.localScale.x < targetScale.x)
            {
                currentScale.x += Time.deltaTime * scaleLoopableSpeed;
                currentScale.y += Time.deltaTime * scaleLoopableSpeed;
                transform.localScale = currentScale;
                yield return new WaitForEndOfFrame();
            }

            targetScale = initScale;
            initScale.y -= SCALE_MARGE;

            while (transform.localScale.x > targetScale.x)
            {
                currentScale.x -= Time.deltaTime * scaleLoopableSpeed;
                currentScale.y -= Time.deltaTime * scaleLoopableSpeed;
                transform.localScale = currentScale;
                yield return new WaitForEndOfFrame();
            }
            yield return new WaitForEndOfFrame();
        }
    }

}
