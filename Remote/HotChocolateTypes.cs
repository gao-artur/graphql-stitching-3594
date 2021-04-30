using System.Collections.Generic;
using HotChocolate.Types;

namespace Remote
{
    public class HotChocolateQuery
    {
    }

    public class QueryType : ObjectType<HotChocolateQuery>
    {
        protected override void Configure(IObjectTypeDescriptor<HotChocolateQuery> descriptor)
        {
            descriptor.Field("test").Type<ListType<BaseType>>().Resolve(new List<Concrete>{null});

        }
    }

    public class BaseType : InterfaceType<Base>
    {
        protected override void Configure(IInterfaceTypeDescriptor<Base> descriptor)
        {
            descriptor.Name("BaseType");
            descriptor.BindFieldsExplicitly();
            descriptor.Field(x => x.Name);
        }
    }

    public class ConcreteType : ObjectType<Concrete>
    {
        protected override void Configure(IObjectTypeDescriptor<Concrete> descriptor)
        {
            descriptor.Name("ConcreteType");
            descriptor.Implements<BaseType>();
        }
    }


    public class Base
    {
        public string Name { get; set; }
    }

    public class Concrete : Base
    {

    }
}