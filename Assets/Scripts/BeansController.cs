using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BeansController : MonoBehaviour
{
    #region Serialized Fields

    [SerializeField]
    private Image beanImage;
    [SerializeField]
    private TextMeshProUGUI beansText;
    [SerializeField]
    private Vector2Int beansSpawnRange;
    [SerializeField]
    private Transform spawnPoint;
    
    #endregion

    public void AddBeans()
    {
        int beansCount = Random.Range(beansSpawnRange.x, beansSpawnRange.y);
        StartCoroutine(SpawnBeans(beansCount));
    }

    private IEnumerator SpawnBeans(int beansCount)
    {
        for (int i = 0; i < beansCount; i++)
        {
            Image newBean = Instantiate(beanImage, spawnPoint);
            newBean.transform.DOMove(beanImage.transform.position, 0.5f).OnComplete(()=>Destroy(newBean.gameObject));

            yield return new WaitForEndOfFrame();
        }
    }

}