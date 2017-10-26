using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdmissionsEditor : UIPanel {

    public Slider genSlider;
    public Slider gpaSlider;
    public Slider satSlider;
    public Slider extraSlider;
    public Slider divSlider;

    public override void Start()
    {
        base.Start();
       
        genSlider.value = ModelController.modelController.genSelect;
        gpaSlider.value = ModelController.modelController.genGPA;

        satSlider.value = ModelController.modelController.genSAT;

        extraSlider.value = ModelController.modelController.genExtra;
        divSlider.value = ModelController.modelController.genDiv;

    }

    IEnumerator LateStart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        
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
    public void UpdateGPAAdmissions ()
    {
        ModelController.modelController.genGPA = gpaSlider.value;
    }

    public void UpdateSATAdmissions ()
    {
        ModelController.modelController.genSAT = satSlider.value;
    }
     
    public void UpdateExtraAdmissions ()
    {
        ModelController.modelController.genExtra = extraSlider.value;
    }

    public void UpdateDivAdmissions ()
    {
        ModelController.modelController.genDiv = divSlider.value;
    }
}
