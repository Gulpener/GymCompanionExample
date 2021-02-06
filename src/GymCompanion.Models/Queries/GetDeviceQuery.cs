using System;

namespace GymCompanion.Models.Queries
{
    public class GetDeviceQuery
    {
        public GetDeviceQuery(string id)
        {
            Id = id;
        }

        public string Id { get;}
    }
}
