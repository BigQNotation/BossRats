using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class BossStrategyConfigGenerator : NetworkBehaviour
{
    public GeneratedStrategy generatedStrategy = new GeneratedStrategy();

    private BossAccumulationStrategy[] allAccumulationStrats;
    private BossChargeStrategy[] allChargeStrats;
    private BossDevastationStrategy[] allDevastationStrats;
    private BossMetricStrategy[] allMetricStrats;

    public void GenerateRandomStrategyList()
    {
        generatedStrategy.accumulationStrategy = allAccumulationStrats[Random.Range(0, allAccumulationStrats.Length)];
        generatedStrategy.chargeStrategy = allChargeStrats[Random.Range(0, allChargeStrats.Length)];
        generatedStrategy.devastationStrategy = allDevastationStrats[Random.Range(0, allDevastationStrats.Length)];
        generatedStrategy.metricStrategy = allMetricStrats[Random.Range(0, allMetricStrats.Length)];

        Debug.Log("accum strat: " + generatedStrategy.accumulationStrategy.ToString());
        Debug.Log("charge strat: " + generatedStrategy.chargeStrategy.ToString());
        Debug.Log("devast strat: " + generatedStrategy.devastationStrategy.ToString());
        Debug.Log("metric strat: " + generatedStrategy.metricStrategy.ToString());
    }
    public GeneratedStrategy GetRandomStrategyList()
    {
        return generatedStrategy;
    }
    public class GeneratedStrategy
    {
        public BossAccumulationStrategy accumulationStrategy;
        public BossChargeStrategy chargeStrategy;
        public BossDevastationStrategy devastationStrategy;
        public BossMetricStrategy metricStrategy;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!isServer)
            return;
        SetAllStrategyArrays();
    }
    // Update is called once per frame
    void Update()
    {
        if (!isServer)
            return;
    }

    private void SetAllStrategyArrays()
    {
        BossAccumulationStrategy[] accumList = { gameObject.GetComponent<AccumulationDamageOut>(), gameObject.GetComponent<AccumulationSpeedIncrease>() };
        allAccumulationStrats = accumList;

        BossChargeStrategy[] chargeList = { gameObject.GetComponent<ChargeMeter>() };
        allChargeStrats = chargeList;

        BossDevastationStrategy[] devastationList = { gameObject.GetComponent<DevastationSpeed>() };
        allDevastationStrats = devastationList;

        BossMetricStrategy[] metricList = { gameObject.GetComponent<MetricAbilityUsage>(), gameObject.GetComponent<MetricDistanceTraveled>() };
        allMetricStrats = metricList;
    }

    
}
