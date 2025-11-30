using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripGo.Destinations;
using Xunit;

namespace TripGo.EntityFrameworkCore.Applications.Destinations;
[Collection(TripGoTestConsts.CollectionDefinitionName)]
public class EfCoreDestinationAppService_Tests : DestinationAppService_Tests<TripGoEntityFrameworkCoreTestModule>

{
}
