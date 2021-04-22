using System;
using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using DeviceV2.Validators.CustomValidationRules;
using FluentValidation;

namespace DeviceV2.Validators.Sensor
{
    public class LocationValidator : AbstractValidator<Location>
    {
        public LocationValidator(string productID)
        {
            RuleFor(x => x.Metadata).SetValidator(new MetaDataValidator());
            RuleFor(x => x.Accuracy)
                .TransformToNotNullableDecimal()
                .ValidateRadius(productID);
            RuleFor(x => x.Altitude);
            RuleFor(x => x.DeviceId);
            RuleFor(x => x.Speed);
            RuleFor(x => x.Longitude)
                .TransformToNotNullableDecimal()
                .ValidateLongitude();
            RuleFor(x => x.Latitude)
                .TransformToNotNullableDecimal()
                .ValidateLatitude();
        }
    }
}
