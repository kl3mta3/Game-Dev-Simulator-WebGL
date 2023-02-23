using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PortfolioPrefab : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    internal TextMeshProUGUI gameNameText;

    [SerializeField]
    internal TextMeshProUGUI gameProfitText;
    [SerializeField]
    internal TextMeshProUGUI gameCostText;
    [SerializeField]
    internal TextMeshProUGUI unitsSoldText;

    [SerializeField]
    internal TextMeshProUGUI popularityText;

    [SerializeField]
    internal Toggle steem;

    [SerializeField]
    internal Toggle epik;

    [SerializeField]
    internal Toggle pear;

    [SerializeField]
    internal Toggle cyborg;

    [SerializeField]
    internal Toggle playBox;

    [SerializeField]
    internal Toggle xStation;
}
