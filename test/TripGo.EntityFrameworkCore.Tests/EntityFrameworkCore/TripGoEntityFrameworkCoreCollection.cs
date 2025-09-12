using Xunit;

namespace TripGo.EntityFrameworkCore;

[CollectionDefinition(TripGoTestConsts.CollectionDefinitionName)]
public class TripGoEntityFrameworkCoreCollection : ICollectionFixture<TripGoEntityFrameworkCoreFixture>
{

}
