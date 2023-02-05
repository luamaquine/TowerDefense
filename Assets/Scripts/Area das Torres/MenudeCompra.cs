using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenudeCompra : MonoBehaviour
{
    [SerializeField] private GameObject towerPrefab;
    [SerializeField] private int towerPrice;

    private bool isBuying = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && isBuying)
        {
            if (HasEnoughMoney(towerPrice))
            {
                BuyTower();
            }
            else
            {
                Debug.Log("Você não tem dinheiro suficiente para comprar esta torre.");
            }
        }
    }

    public void StartBuying()
    {
        isBuying = true;
    }

    public void StopBuying()
    {
        isBuying = false;
    }

    private void BuyTower()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        mousePos.z = 0;

        GameObject newTower = Instantiate(towerPrefab, mousePos, Quaternion.identity);

        DeductMoney(towerPrice);
    }

    private bool HasEnoughMoney(int amount)
    {
        //lógica para verificar se o jogador tem dinheiro suficiente
        return true;
    }

    private void DeductMoney(int amount)
    {
        //lógica para deduzir o dinheiro do jogador
    }
}
