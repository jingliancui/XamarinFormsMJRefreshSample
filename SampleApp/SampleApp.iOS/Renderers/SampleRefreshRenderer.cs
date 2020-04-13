using System;
using SampleApp.Controls;
using SampleApp.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using MJRefresh;
using System.Threading.Tasks;

[assembly: ExportRenderer(typeof(SampleRefresh), typeof(SampleRefreshRenderer))]
namespace SampleApp.iOS.Renderers
{
    public class SampleRefreshRenderer: ViewRenderer<SampleRefresh, UIKit.UIScrollView>
    {
        private MJRefreshNormalHeader header;
        private UIKit.UIScrollView view;

        protected override void OnElementChanged(ElementChangedEventArgs<SampleRefresh> e)
        {
            if (view == null)
            {
                view = new UIKit.UIScrollView();
            }
            if (header == null)
            {
                header = new MJRefreshNormalHeader
                {
                    RefreshingBlock = new MJRefreshComponentAction(async () =>
                    {
                        await Task.Delay(TimeSpan.FromSeconds(3d));
                        view.Mj_header().EndRefreshing();
                    })
                };
            }
            view.Mj_header(header);
            SetNativeControl(view);
        }
    }
}
