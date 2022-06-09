using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheModels.Models;

namespace TheModels.Helper_Services
{
    public class ItemInvioce
    {
        public Materials? Materials { get; set; }

        public string? NameMaterial => Materials is not null ? Materials.NameMaterial : "";

        public double WeightsCount { get; set; }

        public string? WeightName
        {
            get
            {
                if (Materials is not null)
                {
                    if (Materials.Weight.Weightsmall is not null)
                    {
                        if (WeightsCount < 1)
                        {
                            return $"{(WeightsCount * Materials.Weight.CountOfSmall)} {Materials.Weight.Weightsmall.NameWeight}";
                        }
                        else
                        {
                            return $"{WeightsCount} ({Materials.Weight.NameWeight})";
                        }

                    }
                    return $"{WeightsCount} ({Materials.Weight.NameWeight})";
                }

                return "";
            }
        }



        public static implicit operator ItemInvioce (BuildingCost buildingCosts)
        {
            var item = new ItemInvioce();
            if(buildingCosts != null)
            {
                if(buildingCosts.Material is not null)
                {
                    item.Materials = buildingCosts.Material;
                    item.WeightsCount = buildingCosts.CountWeight;
                }
            }
            return item;
        }

        public static implicit operator ItemInvioce(FinishCost finishCost)
        {
            var item = new ItemInvioce();
            if (finishCost != null)
            {
                if (finishCost.Material is not null)
                {
                    item.Materials = finishCost.Material;
                    item.WeightsCount = finishCost.Weight;
                }
            }
            return item;
        }


    }
}
