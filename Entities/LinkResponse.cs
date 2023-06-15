using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Linkmodels;

namespace Entities
{
    public class LinkResponse
    {
        public bool HasLinks { get; set; }
        public List<Entity> ShapedEntities { get; set; }
        public LinkCollectionWrapper<Entity> LinkedEntities { get; set; }
        public LinkResponse()
        {
            LinkedEntities = new LinkCollectionWrapper<Entity>();
            ShapedEntities = new List<Entity>();

        }
    }
}