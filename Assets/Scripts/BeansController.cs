using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BeansController : MonoBehaviour
{
    #region Serialized Fields

    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private Image beanImage;
    [SerializeField]
    private Image whiteBean;
    [SerializeField]
    private TextMeshProUGUI beansText;
    [SerializeField]
    private Vector2Int beansSpawnRange;
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private List<Color> beanColorsList;

    #endregion

    private int BeansCount { get; set; } = 0;
    
    private void Start()
    {
        beansText.text = "0";
    }

    public void AddBeans()
    {
        int beansCount = Random.Range(beansSpawnRange.x, beansSpawnRange.y);

        StartCoroutine(SpawnBeans(beansCount));
    }

    private IEnumerator SpawnBeans(int beansCount)
    {
        for (int i = 0; i < beansCount; i++)
        {
            Image newBean = Instantiate(whiteBean, spawnPoint.position, Quaternion.identity, canvas.transform);
            newBean.rectTransform.localScale = Vector3.zero;
            
            int colorIndex = Random.Range(0, beanColorsList.Count);
            newBean.color = beanColorsList[colorIndex];

            Sequence sequence = DOTween.Sequence();
            sequence.Join(newBean.transform.DOScale(Vector3.one, 0.2f));
            sequence.Append(newBean.transform.DOMove(beanImage.transform.position, 0.4f));
            sequence.Append(newBean.transform.DOScale(Vector3.zero, 0.2f));
            sequence.OnComplete(() =>
                                {
                                    UpdateBeansCount();
                                    Destroy(newBean.gameObject);
                                });
            

            yield return new WaitForSeconds(0.3f);
        }
    }

    private void UpdateBeansCount()
    {
        BeansCount++;
        beansText.text = BeansCount.ToString();
    }

}