using StriveFrameData.PresentationObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StriveFrameData.ViewInterfaces
{
    public interface IMainFrameDataView
    {
        List<MainFrameDataPO> MainFrameDataList();
    }
}
