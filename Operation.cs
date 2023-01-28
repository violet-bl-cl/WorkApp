using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class Operation : MonoBehaviour
{

    // Start is called before the first frame update
    public TMP_InputField[] breads;
    public TMP_InputField[] wraps;
    public TMP_InputField[] gluteenWraps;
    public TMP_InputField[] salads;

    public TextMeshProUGUI[] infoDisplay;

    public TextMeshProUGUI results;
    public GameObject[] menus;
    public TextMeshProUGUI dateAndTime;
    void Start()
    {

        menus = new GameObject[4];
        menus[0] = GameObject.Find("stockCalculator");
        menus[1] = GameObject.Find("fixedStockCalculator");
        menus[2] = GameObject.Find("cashHelper");
        menus[3] = GameObject.Find("infoHelper");


        infoDisplay = new TextMeshProUGUI[3];
        infoDisplay[0] = GameObject.Find("logo").transform.Find("Opening").GetComponent<TextMeshProUGUI>();
        infoDisplay[1] = GameObject.Find("logo").transform.Find("Closing").GetComponent<TextMeshProUGUI>();
        infoDisplay[2] = GameObject.Find("logo").transform.Find("subOfTheDay").GetComponent<TextMeshProUGUI>();
        dateAndTime = GameObject.Find("FixedLayer").transform.Find("dateAndTime").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame

    void Update()
    {
        getDateFormat();
        DateTime rightNow = DateTime.Now;
        dateAndTime.text = rightNow.ToString();
    }

    public void getDateFormat()
    {
        DateTimeOffset dateOffsetValue;
        DateTime now = DateTime.Now;
        dateOffsetValue = new DateTimeOffset(now, TimeZoneInfo.Local.GetUtcOffset(now));
        //Debug.Log(dateOffsetValue.ToString("ddd"));
        switch (dateOffsetValue.ToString("ddd"))
        {
            case "Mon":
                {
                    infoDisplay[2].text = "-MeatBalls-";
                    infoDisplay[0].text = dateOffsetValue.ToString("ddd") + ": 7:00AM";
                    infoDisplay[1].text = dateOffsetValue.ToString("ddd") + ": 9:00PM";
                    break;
                }
            case "Tue":
                {
                    infoDisplay[2].text = "-Leg Ham-";
                    infoDisplay[0].text = dateOffsetValue.ToString("ddd") + ": 7:00AM";
                    infoDisplay[1].text = dateOffsetValue.ToString("ddd") + ": 9:00PM";
                    break;
                }
            case "Wed":
                {
                    infoDisplay[2].text = "-Pizza Melt-";
                    infoDisplay[0].text = dateOffsetValue.ToString("ddd") + ": 7:00AM";
                    infoDisplay[1].text = dateOffsetValue.ToString("ddd") + ": 9:00PM";
                    break;
                }
            case "Thu":
                {
                    infoDisplay[2].text = "-Pork Riblet-";
                    infoDisplay[0].text = dateOffsetValue.ToString("ddd") + ": 7:00AM";
                    infoDisplay[1].text = dateOffsetValue.ToString("ddd") + ": 9:00PM";
                    break;
                }
            case "Fri":
                {
                    infoDisplay[2].text = "-??????-";
                    infoDisplay[0].text = dateOffsetValue.ToString("ddd") + ": 7:00AM";
                    infoDisplay[1].text = dateOffsetValue.ToString("ddd") + ": 9:00PM";
                    break;
                }
            case "Sat":
                {
                    infoDisplay[2].text = "-Leg Ham-";
                    infoDisplay[0].text = dateOffsetValue.ToString("ddd") + ": 8:00AM";
                    infoDisplay[1].text = dateOffsetValue.ToString("ddd") + ": 8:00PM";
                    break;
                }
            case "Sun":
                {
                    infoDisplay[2].text = "-Pork Riblet-";
                    infoDisplay[0].text = dateOffsetValue.ToString("ddd") + ": 8:00AM";
                    infoDisplay[1].text = dateOffsetValue.ToString("ddd") + ": 8:00PM";
                    break;
                }
        }


        //Debug.Log(now.ToString("dd/MM/yyyy"));

    }
    public void cashCaculateResult()
    {
        GameObject cashObject = menus[2];
        TMP_InputField[] cashTypes = new TMP_InputField[11];
        TextMeshProUGUI result = cashObject.transform.Find("result").transform.GetComponent<TextMeshProUGUI>();
        cashTypes[0] = cashObject.transform.Find("cash100").transform.GetComponent<TMP_InputField>();
        cashTypes[1] = cashObject.transform.Find("cash50").transform.GetComponent<TMP_InputField>();
        cashTypes[2] = cashObject.transform.Find("cash20").transform.GetComponent<TMP_InputField>();
        cashTypes[3] = cashObject.transform.Find("cash10").transform.GetComponent<TMP_InputField>();
        cashTypes[4] = cashObject.transform.Find("cash5").transform.GetComponent<TMP_InputField>();
        cashTypes[5] = cashObject.transform.Find("cash2").transform.GetComponent<TMP_InputField>();
        cashTypes[6] = cashObject.transform.Find("cash1").transform.GetComponent<TMP_InputField>();
        cashTypes[7] = cashObject.transform.Find("cash0.5").transform.GetComponent<TMP_InputField>();
        cashTypes[8] = cashObject.transform.Find("cash0.2").transform.GetComponent<TMP_InputField>();
        cashTypes[9] = cashObject.transform.Find("cash0.1").transform.GetComponent<TMP_InputField>();

        double totalCash = ((double.Parse(cashTypes[0].text) * 100) + (double.Parse(cashTypes[1].text) * 50) + (double.Parse(cashTypes[2].text) * 20) +
        (double.Parse(cashTypes[3].text) * 10) + (double.Parse(cashTypes[4].text) * 5) + (double.Parse(cashTypes[5].text) * 2) +
        (double.Parse(cashTypes[6].text) * 1) + (double.Parse(cashTypes[7].text) * 0.5) + (double.Parse(cashTypes[8].text) * 0.2) +
        (double.Parse(cashTypes[9].text) * 0.1));

        result.text = "\nLoose Cash:" + (totalCash - 200) +
                        "\n Total Cash:" + totalCash +
                        "\n Vault Cash:" + 200;
    }
    public void cashReset()
    {
        GameObject cashObject = menus[2];
        TMP_InputField[] cashTypes = new TMP_InputField[11];
        TextMeshProUGUI result = cashObject.transform.Find("result").transform.GetComponent<TextMeshProUGUI>();
        cashTypes[0] = cashObject.transform.Find("cash100").transform.GetComponent<TMP_InputField>();
        cashTypes[1] = cashObject.transform.Find("cash50").transform.GetComponent<TMP_InputField>();
        cashTypes[2] = cashObject.transform.Find("cash20").transform.GetComponent<TMP_InputField>();
        cashTypes[3] = cashObject.transform.Find("cash10").transform.GetComponent<TMP_InputField>();
        cashTypes[4] = cashObject.transform.Find("cash5").transform.GetComponent<TMP_InputField>();
        cashTypes[5] = cashObject.transform.Find("cash2").transform.GetComponent<TMP_InputField>();
        cashTypes[6] = cashObject.transform.Find("cash1").transform.GetComponent<TMP_InputField>();
        cashTypes[7] = cashObject.transform.Find("cash0.5").transform.GetComponent<TMP_InputField>();
        cashTypes[8] = cashObject.transform.Find("cash0.2").transform.GetComponent<TMP_InputField>();
        cashTypes[9] = cashObject.transform.Find("cash0.1").transform.GetComponent<TMP_InputField>();
        for (int i = 0; i < cashTypes.Length; i++)
        {
            cashTypes[i].text = "0";
        }
    }
    public void fixedStockCalculatorResult()
    {
        GameObject stockObject = menus[1];
        results = null;
        results = menus[1].transform.Find("Result").GetComponent<TextMeshProUGUI>();
        double[] remainings = new double[4];
        breads = new TMP_InputField[3];
        breads[0] = stockObject.transform.Find("Bread").transform.Find("Remainings").GetComponent<TMP_InputField>();
        breads[1] = stockObject.transform.Find("Bread").transform.Find("Quantity").GetComponent<TMP_InputField>();
        //   breads[2] = stockObject.transform.Find("Bread").transform.Find("Bulks").GetComponent<TMP_InputField>();
        remainings[0] = 0;
        foreach (var a in breads[0].text.Split("+"))
        {
            remainings[0] += double.Parse(a);
        }
        double totalBreads = (double.Parse(breads[1].text) * 85) + remainings[0];
        gluteenWraps = new TMP_InputField[3];
        gluteenWraps[0] = stockObject.transform.Find("GlutenWrap").transform.Find("Remainings").GetComponent<TMP_InputField>();
        gluteenWraps[1] = stockObject.transform.Find("GlutenWrap").transform.Find("Quantity").GetComponent<TMP_InputField>();

        remainings[1] = 0;
        foreach (var a in gluteenWraps[0].text.Split("+"))
        {
            remainings[1] += double.Parse(a);
        }
        double totlaGlueteen = (double.Parse(gluteenWraps[1].text) * 4) + remainings[1];

        wraps = new TMP_InputField[3];
        wraps[0] = stockObject.transform.Find("NormalWrap").transform.Find("Remainings").GetComponent<TMP_InputField>();
        wraps[1] = stockObject.transform.Find("NormalWrap").transform.Find("Quantity").GetComponent<TMP_InputField>();

        remainings[2] = 0;
        foreach (var a in wraps[0].text.Split("+"))
        {
            remainings[2] += double.Parse(a);
        }
        double totalWraps = (double.Parse(wraps[1].text) * 12) + remainings[2];

        salads = new TMP_InputField[3];
        salads[0] = stockObject.transform.Find("SaladBowl").transform.Find("Remainings").GetComponent<TMP_InputField>();
        salads[1] = stockObject.transform.Find("SaladBowl").transform.Find("Quantity").GetComponent<TMP_InputField>();

        remainings[3] = 0;
        foreach (var a in salads[0].text.Split("+"))
        {
            remainings[3] += double.Parse(a);
        }
        double totalSalads = (double.Parse(salads[1].text) * 50) + remainings[3];






        results.text = "\n| Total Breads: " + totalBreads +
         "\n|---Total Wraps: " + totalWraps +
          " \n|---Total Gluteen Wraps: " + totlaGlueteen
        + "\n| Total Wraps: " + (totalWraps + totlaGlueteen) +
        "\n| Total Salad Bowl: " + totalSalads
        + "\n---------------"
        + "\n BREADS:" + totalBreads
         + "\n WRAPS:" + totalWraps
           + "\n SALADS:" + totalSalads;
    }
    public void stockReset(int j)
    {
        GameObject stockObject = menus[j];
        breads = new TMP_InputField[3];
        breads[0] = stockObject.transform.Find("Bread").transform.Find("Remainings").GetComponent<TMP_InputField>();
        breads[1] = stockObject.transform.Find("Bread").transform.Find("Quantity").GetComponent<TMP_InputField>();
        gluteenWraps = new TMP_InputField[3];
        gluteenWraps[0] = stockObject.transform.Find("GlutenWrap").transform.Find("Remainings").GetComponent<TMP_InputField>();
        gluteenWraps[1] = stockObject.transform.Find("GlutenWrap").transform.Find("Quantity").GetComponent<TMP_InputField>();
        wraps = new TMP_InputField[3];
        wraps[0] = stockObject.transform.Find("NormalWrap").transform.Find("Remainings").GetComponent<TMP_InputField>();
        wraps[1] = stockObject.transform.Find("NormalWrap").transform.Find("Quantity").GetComponent<TMP_InputField>();
        salads = new TMP_InputField[3];
        salads[0] = stockObject.transform.Find("SaladBowl").transform.Find("Remainings").GetComponent<TMP_InputField>();
        salads[1] = stockObject.transform.Find("SaladBowl").transform.Find("Quantity").GetComponent<TMP_InputField>();
        if (j == 0)
        {
            breads[2] = stockObject.transform.Find("Bread").transform.Find("Bulks").GetComponent<TMP_InputField>();
            gluteenWraps[2] = stockObject.transform.Find("GlutenWrap").transform.Find("Bulks").GetComponent<TMP_InputField>();
            wraps[2] = stockObject.transform.Find("NormalWrap").transform.Find("Bulks").GetComponent<TMP_InputField>();
            salads[2] = stockObject.transform.Find("SaladBowl").transform.Find("Bulks").GetComponent<TMP_InputField>();
        }
        for (int i = 0; i < 3; i++)
        {
            breads[i].text = "0";
            gluteenWraps[i].text = "0";
            wraps[i].text = "0";
            salads[i].text = "0";
        }
    }
    public void stockCalculateResult()
    {
        GameObject stockObject = menus[0];
        results = null;
        results = menus[0].transform.Find("Result").GetComponent<TextMeshProUGUI>();
        double[] remainings = new double[4];
        char[] operations = new char[] { '+', '-', '/', '*' };
        breads = new TMP_InputField[3];
        breads[0] = stockObject.transform.Find("Bread").transform.Find("Remainings").GetComponent<TMP_InputField>();
        breads[1] = stockObject.transform.Find("Bread").transform.Find("Quantity").GetComponent<TMP_InputField>();
        breads[2] = stockObject.transform.Find("Bread").transform.Find("Bulks").GetComponent<TMP_InputField>();
        remainings[0] = 0;
        foreach (var a in breads[0].text.Split(operations))
        {
            // Debug.Log(a);
            remainings[0] += double.Parse(a);
        }
        double totalBreads = (double.Parse(breads[1].text) * double.Parse(breads[2].text)) + remainings[0];
        gluteenWraps = new TMP_InputField[3];
        gluteenWraps[0] = stockObject.transform.Find("GlutenWrap").transform.Find("Remainings").GetComponent<TMP_InputField>();
        gluteenWraps[1] = stockObject.transform.Find("GlutenWrap").transform.Find("Quantity").GetComponent<TMP_InputField>();
        gluteenWraps[2] = stockObject.transform.Find("GlutenWrap").transform.Find("Bulks").GetComponent<TMP_InputField>();
        remainings[1] = 0;
        foreach (var a in gluteenWraps[0].text.Split(operations))
        {
            remainings[1] += double.Parse(a);
        }
        double totlaGlueteen = (double.Parse(gluteenWraps[1].text) * double.Parse(gluteenWraps[2].text)) + remainings[1];

        wraps = new TMP_InputField[3];
        wraps[0] = stockObject.transform.Find("NormalWrap").transform.Find("Remainings").GetComponent<TMP_InputField>();
        wraps[1] = stockObject.transform.Find("NormalWrap").transform.Find("Quantity").GetComponent<TMP_InputField>();
        wraps[2] = stockObject.transform.Find("NormalWrap").transform.Find("Bulks").GetComponent<TMP_InputField>();
        remainings[2] = 0;
        foreach (var a in wraps[0].text.Split(operations))
        {
            remainings[2] += double.Parse(a);
        }
        double totalWraps = (double.Parse(wraps[1].text) * double.Parse(wraps[2].text)) + remainings[2];

        salads = new TMP_InputField[3];
        salads[0] = stockObject.transform.Find("SaladBowl").transform.Find("Remainings").GetComponent<TMP_InputField>();
        salads[1] = stockObject.transform.Find("SaladBowl").transform.Find("Quantity").GetComponent<TMP_InputField>();
        salads[2] = stockObject.transform.Find("SaladBowl").transform.Find("Bulks").GetComponent<TMP_InputField>();
        remainings[3] = 0;
        foreach (var a in salads[0].text.Split(operations))
        {
            remainings[3] += double.Parse(a);
        }
        double totalSalads = (double.Parse(salads[1].text) * double.Parse(salads[2].text)) + remainings[3];






        results.text = "\n| Total Breads: " + totalBreads +
         "\n|---Total Wraps: " + totalWraps +
          " \n|---Total Gluteen Wraps: " + totlaGlueteen
        + "\n| Total Wraps: " + (totalWraps + totlaGlueteen) +
        "\n| Total Salad Bowl: " + totalSalads
        + "\n---------------"
        + "\n BREADS:" + totalBreads
         + "\n WRAPS:" + totalWraps
           + "\n SALADS:" + totalSalads;
    }

    public void stockCalculator()
    {
        menus[0].SetActive(true);
        menus[1].SetActive(false);
        menus[2].SetActive(false);
        menus[3].SetActive(false);
    }
    public void fixedStockCalculator()
    {
        menus[0].SetActive(false);
        menus[1].SetActive(true);
        menus[2].SetActive(false);
        menus[3].SetActive(false);

    }
    public void infoWork()
    {
        menus[0].SetActive(false);
        menus[1].SetActive(false);
        menus[2].SetActive(false);
        menus[3].SetActive(true);
    }
    public void cashHelper()
    {
        menus[0].SetActive(false);
        menus[1].SetActive(false);
        menus[2].SetActive(true);
        menus[3].SetActive(false);
    }

}
