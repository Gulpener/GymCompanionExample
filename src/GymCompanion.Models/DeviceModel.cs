using GJ.CQRSCore;
using System.Collections.Generic;

namespace GymCompanion.Models
{
    public class DeviceModel : BaseModel
    {
        public string Name { get; set; }
        public IList<FunctionModel> FunctionCollection { get; set; }
    }
}
