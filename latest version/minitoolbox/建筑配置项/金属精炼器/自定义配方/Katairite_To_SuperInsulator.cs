using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using STRINGS;

namespace minitoolbox.建筑配置项.金属精炼器
{
    [HarmonyPatch(typeof(MetalRefineryConfig), "ConfigureBuildingTemplate")]
    public class Katairite_To_SuperInsulator  // 深渊晶石 1000/kg > 隔热质 600/kg - Time：40S
    {
        public static void Postfix(MetalRefineryConfig __instance, ref GameObject go)
        {
            if (SingletonOptions<ConfigurationItem>.Instance.MetalRefinery_Recipe)
            {
                Element element = ElementLoader.FindElementByHash(SimHashes.Katairite);
                ComplexRecipe.RecipeElement[] array = new ComplexRecipe.RecipeElement[]
                {
                    new ComplexRecipe.RecipeElement(ElementLoader.FindElementByHash(SimHashes.Katairite).tag, 1000f)
                };
                ComplexRecipe.RecipeElement[] array2 = new ComplexRecipe.RecipeElement[]
                {
                    new ComplexRecipe.RecipeElement(ElementLoader.FindElementByHash(SimHashes.SuperInsulator).tag, 600f, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature, false)
                };
                string obsolete_id = ComplexRecipeManager.MakeObsoleteRecipeID("MetalRefinery", element.tag);
                string text = ComplexRecipeManager.MakeRecipeID("MetalRefinery", array, array2);
                ComplexRecipe complexRecipe = new ComplexRecipe(text, array, array2);
                complexRecipe.time = 40f;
                complexRecipe.nameDisplay = ComplexRecipe.RecipeNameDisplay.IngredientToResult;
                complexRecipe.description = string.Format(BUILDINGS.PREFABS.METALREFINERY.RECIPE_DESCRIPTION, ElementLoader.FindElementByHash(SimHashes.SuperInsulator).name, ElementLoader.FindElementByHash(SimHashes.Katairite).name);
                complexRecipe.fabricators = new List<Tag>
                {
                    TagManager.Create("MetalRefinery")
                };
                ComplexRecipeManager.Get().AddObsoleteIDMapping(obsolete_id, text);
            }
        }
    }
}