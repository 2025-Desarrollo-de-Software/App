using TripGo.Samples;
using Xunit;

namespace TripGo.EntityFrameworkCore.Applications;

[Collection(TripGoTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<TripGoEntityFrameworkCoreTestModule>
{

}
