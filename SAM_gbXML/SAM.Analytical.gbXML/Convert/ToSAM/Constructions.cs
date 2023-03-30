﻿using SAM.Core;
using System.Collections.Generic;

namespace SAM.Analytical.gbXML
{
    public static partial class Convert
    {
        public static List<Construction> ToSAM_Constructions(this gbXMLSerializer.gbXML gbXML)
        {
            if (gbXML == null)
            {
                return null;
            }

            gbXMLSerializer.Construction[] constructions = gbXML.Constructions;
            if(constructions == null)
            {
                return null;
            }

            List<Construction> result = new List<Construction>();
            foreach(gbXMLSerializer.Construction construction_gbXML in constructions)
            {


                Construction construction = ToSAM(construction_gbXML, gbXML);
                if(construction != null)
                {
                    result.Add(construction);
                }
            }

            return result;
        }

    }
}
