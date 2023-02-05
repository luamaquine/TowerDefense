using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyController : MonoBehaviour
{
    public Button shooterButton, mageButton, tankButton;

    public GameObject shooterArea;
    public GameObject tankerArea;
    [SerializeField] private GameObject shooterPrefab;

    public static bool isBuying = false;
    public static string charSelected;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isBuying == false)
        {
            shooterArea.SetActive(false);
            tankerArea.SetActive(false);
        }
        
        if (GameController.coins <= 39)
        {
            shooterButton.enabled = false;
            shooterButton.image.color = Color.gray;
        }
        else
        {
            shooterButton.enabled = true;
            shooterButton.image.color = Color.white;
        }
        if (GameController.coins <= 89)
        {
            mageButton.enabled = false;
            mageButton.image.color = Color.gray;
        }
        else
        {
            mageButton.enabled = true;
            mageButton.image.color = Color.white;
        }
        if (GameController.coins <= 119)
        {
            tankButton.enabled = false;
            tankButton.image.color = Color.gray;
        }
        else
        {
            tankButton.enabled = true;
            tankButton.image.color = Color.white;
        }
    }

    public void buyChar(string defender)
    {
        if (defender == "shooter")
        {
           shooterArea.SetActive(true);
           charSelected = "shooter";
           isBuying = true;
        }
        if (defender == "mage")
        {
            shooterArea.SetActive(true);
            charSelected = "mage";
            isBuying = true;
        }
        if (defender == "tanker")
        {
            tankerArea.SetActive(true);
            charSelected = "tank";
            isBuying = true;
        }
    }
}
