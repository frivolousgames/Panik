using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectMoney : MonoBehaviour
{
    GameObject player;
    public int value;
    public GameObject moneyTrail;
    Text amountText;
    GameObject money;

    private void Awake()
    {
        amountText = moneyTrail.GetComponentInChildren<Text>();
    }
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerHitCollider");
        
    }

    private void Update()
    {
        //Debug.Log("Value " + value);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            MoneyAmount.moneyAmount += value;
            amountText.text = value.ToString();
            Instantiate(moneyTrail, transform.position, Quaternion.identity, null);
            StartCoroutine("MoneyDestroy");
        }
    }

    IEnumerator MoneyDestroy()
    {

        yield return new WaitForSeconds(.1f);
        Destroy(gameObject);
    }
}
