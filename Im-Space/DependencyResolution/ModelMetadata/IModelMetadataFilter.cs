using System;
using System.Collections.Generic;

namespace IM.Web.DependencyResolution.ModelMetadata
{
    public interface IModelMetadataFilter
    {
        void TransformMetadata(System.Web.Mvc.ModelMetadata metadata,
            IEnumerable<Attribute> attributes);
    }
}