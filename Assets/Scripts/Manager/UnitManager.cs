using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public Unit_Ally currentUnit_Ally { get; private set; }
    private Unit_Ally lastUnit_Ally;

    private GridManager m_gridManager;

    private void Awake()
    {
        m_gridManager = GetComponent<GridManager>();
    }

    private void Update()
    {
        if (currentUnit_Ally == null)
            return;

        m_gridManager.UpdatePath(currentUnit_Ally.path);
    }

    public void SetCurrentUnit(Unit_Ally _newUnit) {
        lastUnit_Ally = currentUnit_Ally;
        currentUnit_Ally = _newUnit;
        currentUnit_Ally.SelectUnit(true);

        if (lastUnit_Ally != null) { 
            lastUnit_Ally.SelectUnit(false);
            lastUnit_Ally = null;
        }
    }

    public void CancelUnitSelection() {
        if (currentUnit_Ally == null)
            return;

        currentUnit_Ally.SelectUnit(false);
        currentUnit_Ally = null;
    }
}
