using LayerDemo.Model;
using LayerDemo.Repository;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace LayerDemo.WebUI
{
    public class BootStrapper
    {
        public static void ConfigureStructureMap() 
        {
            ObjectFactory.Initialize(x => x.AddRegistry<ProductRegistry>());
        }
    }

    public class ProductRegistry : Registry 
    {
        public ProductRegistry() 
        {
            ForRequestedType<IProductRepository>().TheDefaultIsConcreteType<ProductRepository>();
        }
    }
}