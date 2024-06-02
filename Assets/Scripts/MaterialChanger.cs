using System.Collections.Generic;
using UnityEngine;

public class MaterialChanger : MonoBehaviour
{
   // get the material component of the object  
   MeshRenderer meshRenderer;
   public Material highlightMaterial;
   public Material LiquidLevelMaterial;
   List<Material> materials = new List<Material>();
   private void Start() {
      meshRenderer = GetComponent<MeshRenderer>();
      meshRenderer.GetMaterials(materials); 
      Debug.Log(materials.Count);
   }
   public void Highlight(){
      if(!(materials.Contains(highlightMaterial))){
         materials.Insert(1,highlightMaterial);
         meshRenderer.SetMaterials(materials);
         Debug.Log(materials.Count);
      }
   }
   public void RemoveHighlight(){
      if (materials.Contains(highlightMaterial))
      {
         materials.RemoveAt(1);
         meshRenderer.SetMaterials(materials);
         Debug.Log(materials.Count);
      }
     
   }
   public void ChangeHighlightColor(Color color){
      materials[1].SetColor("_Color",color);
      Debug.Log("Color changed");
   }
   
   public void ChangeLiquidlevel(){
      materials.Add(LiquidLevelMaterial);
      meshRenderer.SetMaterials(materials);
      Debug.Log(materials.Count);

   }
}
