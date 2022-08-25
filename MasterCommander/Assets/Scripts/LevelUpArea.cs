using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.Events;

public class LevelUpArea : MonoBehaviour
{
    public Image progressFill;
    public TextMeshProUGUI progressText;
    public TextMeshProUGUI levelText;

    public GameObject levelUpArea;

    public float cost;
    public float currentCost;
    public float necessaryCost;
    public float progress;

    public int level;
    public int maxLevel = 2;

    private bool isLevelUp;

    public UnityEvent toBe;

    private void Awake()
    {
        progressText = GetComponentInChildren<TextMeshProUGUI>();
        necessaryCost = cost - currentCost;
        progressText.text = necessaryCost.ToString();
        progressFill.fillAmount = 0;
    }

    private void Start()
    {
        StartCoroutine(LevelUpCoroutine());
    }

    public void LevelUp()
    {
        isLevelUp = true;
    }

    public void NotLevelUp()
    {
        isLevelUp = false;
    }

    public IEnumerator LevelUpCoroutine()
    {
        while (true)
        {
            if (isLevelUp)
            {
                if (StackManager.stack.GetSilver() >= 1)
                {
                    StackManager.stack.RemoveLastSilver();
                    currentCost++;
                    necessaryCost = cost - currentCost;
                    progressText.text = necessaryCost.ToString();
                    progress = currentCost / cost;
                    progressFill.fillAmount = progress;
                    if (progress >= 1 && level < maxLevel)
                    {
                        level++;
                        currentCost = 0;
                        cost = (int)((15 * cost) / 10);
                        necessaryCost = cost - currentCost;
                        progress = currentCost / cost;
                        progressFill.fillAmount = progress;
                        toBe.Invoke();
                        levelText.text = "Level - " + (level + 1);
                    }
                    else if (level >= maxLevel)
                    {
                        levelUpArea.SetActive(false);
                        this.enabled = false;
                        Destroy(this);
                    }
                }
                else
                {
                    // Debug.Log("Not enough silver");
                }
            }
            yield return new WaitForSeconds(0.25f);
        }
    }
}
