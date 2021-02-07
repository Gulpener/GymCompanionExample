using System;

namespace GymCompanion.Models.Commands
{
    public class RemoveDeviceCommand : ICommand
    {
        public RemoveDeviceCommand(string id)
        {
            Id = id;
        }

        public string Id { get;}
    }
}
