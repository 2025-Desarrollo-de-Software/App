using TripGo.Samples;
using Xunit;

namespace TripGo.EntityFrameworkCore.Domains;

[Collection(TripGoTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<TripGoEntityFrameworkCoreTestModule>
{

}
