using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
namespace Entities
{
    public class ShapedEntity
{
 public  ShapedEntity()
 {
 Entity = new Entity();
 }
 public Guid Id { get; set; }
 public Entity Entity { get; set; }
 
}
}