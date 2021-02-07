using CQRSCore;
using System;

namespace GymCompanion.Models.Queries
{
    public class GetDeviceQuery : IQuery
    {
        public GetDeviceQuery(string id)
        {
            Id = id;
        }

        public string Id { get;}
    }
}
