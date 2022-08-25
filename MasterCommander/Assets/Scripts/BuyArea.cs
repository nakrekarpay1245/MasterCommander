using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class BuyArea : MonoBehaviour
{
    public Image progressFill;
    public TextMeshProUGUI progressText;

    public GameObject mainPart;
    public GameObject buyArea;

    public float cost;
    public float currentCost;
    public float necessaryCost;
    public float progress;

    private bool isBuying;

    private void Awake()
    {
        progressText = GetComponentInChildren<TextMeshProUGUI>();
        necessaryCost = cost - currentCost;
        progressText.text = necessaryCost.ToString();
        progressFill.fillAmount = 0;
    }

    private void Start()
    {
        StartCoroutine(BuyCoroutine());
    }

    public void Buy()
    {
        isBuying = true;
    }

    public void NotBuy()
    {
        isBuying = false;
    }

    public IEnumerator BuyCoroutine()
    {
        while (true)
        {
            if (isBuying)
            {
                if (StackManager.stack.GetSilver() >= 1)
                {
                    StackManager.stack.RemoveLastSilver();
                    currentCost++;
                    necessaryCost = cost - currentCost;
                    progressText.text = necessaryCost.ToString();
                    progress = currentCost / cost;
                    progressFill.fillAmount = progress;
                    if (progress >= 1)
                    {
                        buyArea.SetActive(false);
                        mainPart.SetActive(true);
                        this.enabled = false;
                        Destroy(this);
                    }
                }
                else
                {
                    Debug.Log("Not enough silver");
                }
            }
            yield return new WaitForSeconds(0.25f);
        }
    }
}
