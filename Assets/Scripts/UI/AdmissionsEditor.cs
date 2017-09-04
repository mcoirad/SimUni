using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdmissionsEditor : UIPanel {

    public Slider genSlider;

    public override void Start()
    {
        base.Start();
        genSlider.value = ModelController.modelController.genSelect;
    }

    public void OpenAdmissionsMenu()
    {
        uiController.OpenAdmissionsMenu();
        CloseWindow();
    }

    public void UpdateGeneralAdmissions ()
    {
        ModelController.modelController.genSelect = genSlider.value;
    }
}
