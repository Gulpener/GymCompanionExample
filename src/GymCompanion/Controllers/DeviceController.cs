﻿using GJ.CQRSCore.Interfaces;
using GymCompanion.Models;
using GymCompanion.Models.Commands;
using GymCompanion.Models.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace GymCompanion.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeviceController : ControllerBase
    {
        private readonly ILogger<DeviceController> _logger;
        private readonly ICommandHandler<UpdateOrAddDeviceCommand> _updateOrAddDeviceCommandHandler;
        private readonly ICommandHandler<RemoveDeviceCommand> _removeDeviceCommandHandler;
        private readonly IQueryHandler<GetDeviceListQuery, IList<DeviceModel>> _getDeviceListQueryHandler;
        private readonly IQueryHandler<GetDeviceQuery, DeviceModel> _getDeviceQueryHandler;

        public DeviceController(
            ILogger<DeviceController> logger,
            ICommandHandler<RemoveDeviceCommand> removeDeviceCommandHandler,
            ICommandHandler<UpdateOrAddDeviceCommand> updateOrAddDeviceCommandHandler,
            IQueryHandler<GetDeviceListQuery, IList<DeviceModel>> getDeviceListQueryHandler,
            IQueryHandler<GetDeviceQuery, DeviceModel> getDeviceQueryHandler)
        {
            _logger = logger;
            _updateOrAddDeviceCommandHandler = updateOrAddDeviceCommandHandler;
            _removeDeviceCommandHandler = removeDeviceCommandHandler;
            _getDeviceListQueryHandler = getDeviceListQueryHandler;
            _getDeviceQueryHandler = getDeviceQueryHandler;
        }

        [HttpGet("devices")]
        public IEnumerable<DeviceModel> Get()
        {
            return _getDeviceListQueryHandler.Execute(new GetDeviceListQuery());
        }

        [HttpGet]
        public DeviceModel Get(string id)
        {
            return _getDeviceQueryHandler.Execute(new GetDeviceQuery(id));
        }

        [HttpPost("remove")]
        public IActionResult Remove(string id)
        {
            _removeDeviceCommandHandler.Execute(new RemoveDeviceCommand(id));

            return Ok();
        }

        [HttpPost("updateoradd")]
        public IActionResult UpdateOrAdd([FromBody]DeviceModel device)
        {
            if (device==null) throw new ArgumentNullException();

            _updateOrAddDeviceCommandHandler.Execute(new UpdateOrAddDeviceCommand(device));

            return Ok();
        }
    }
}
