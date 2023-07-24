using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class QuoteManager : MonoBehaviour
{
    public string[] Quotes;
    [SerializeField] TextMeshProUGUI quoteText;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ChooseRandomQuote",0,20);
    }
    void ChooseRandomQuote(){
        int index=Random.Range(0,Quotes.Length);
        string quote=Quotes[index];
        quoteText.text=quote;
    }
}
