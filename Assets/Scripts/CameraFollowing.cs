using System.Collections;
using TMPro;
using UnityEngine;
using Zenject;

public class CameraFollowing : MonoBehaviour
{
    [Inject] TowerManager towerManager;
    [SerializeField] GameObject spawnPoint;
    [SerializeField] float cameraOffset = 0f;
    [SerializeField] float spawnOffset = 4f;
    [SerializeField] float smoothTime = 0.3f;

    private void OnEnable()
    {
        towerManager.OnBlockAdded += UpdatePosition;
    }

    private void OnDisable()
    {
        towerManager.OnBlockAdded -= UpdatePosition;
    }

    public void ResetPosition(Vector3 cameraPos, Vector3 spawnPos)
    {
        transform.position = cameraPos;
        spawnPoint.transform.position = spawnPos;
    }

    private void UpdatePosition(GameObject newBlock)
    {
        Debug.Log($"Camera received {newBlock.name} pos {newBlock.transform.position}");
        StartCoroutine(UpdatePositionCoroutine(newBlock));
    }
    private IEnumerator UpdatePositionCoroutine(GameObject block)
    {
        float elapsed = 0f;

        Vector3 startCam = transform.position;
        Vector3 targetCam = new Vector3(transform.position.x, block.transform.position.y + cameraOffset, transform.position.z);

        while (elapsed < smoothTime)
        {
            elapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(startCam, targetCam, elapsed / smoothTime);
            yield return null;
        }
        transform.position = targetCam;
        spawnPoint.transform.position = new Vector3(spawnPoint.transform.position.x,
            block.transform.position.y + spawnOffset,
            spawnPoint.transform.position.z);
    }

}
