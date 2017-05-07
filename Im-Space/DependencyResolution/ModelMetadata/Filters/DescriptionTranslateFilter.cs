using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using IM.Web.Helpers;

namespace IM.Web.DependencyResolution.ModelMetadata.Filters
{
    public class DescriptionTranslateFilter : IModelMetadataFilter
    {
        public void TransformMetadata(System.Web.Mvc.ModelMetadata metadata,
            IEnumerable<Attribute> attributes)
        {
            if (!string.IsNullOrEmpty(metadata.PropertyName) &&
                !string.IsNullOrEmpty(metadata.DisplayName))
            {
                metadata.DisplayName = metadata.DisplayName.TA();
            }
        }
    }
}