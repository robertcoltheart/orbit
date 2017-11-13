using System.Windows;
using Prism.Regions;

namespace Orbit.RegionAdapters
{
    public class WindowRegionAdapter : RegionAdapterBase<Window>
    {
        public WindowRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory)
            : base(regionBehaviorFactory)
        {
        }

        protected override void Adapt(IRegion region, Window regionTarget)
        {
        }

        protected override IRegion CreateRegion()
        {
            return new SingleActiveRegion();
        }
    }
}
