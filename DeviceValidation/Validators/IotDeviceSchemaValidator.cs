using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using DeviceV2.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceValidation.Validators
{
    public class IotDeviceSchemaValidator : AbstractValidator<IotDeviceSchema>
    {
        public IotDeviceSchemaValidator()
        {
            RuleFor(x => x.Device).SetValidator(m => new DeviceValidator(m.ProductId));
        }
    }
}
