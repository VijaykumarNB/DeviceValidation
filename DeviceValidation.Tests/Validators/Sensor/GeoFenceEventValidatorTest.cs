﻿using System.Collections.Generic;
using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using DeviceV2.Validators.Sensor;
using FluentValidation.TestHelper;
using Xunit;

namespace DeviceV2Tests.Validators.Sensor
{
    public class GeoFenceEventValidatorTest : BaseValidatorTest
    {
        private readonly GeoFenceEventValidator validator =
            new GeoFenceEventValidator();

        [Fact]
        public void HappyPath()
        {
            var model = CreateGeoFenceEvent();
            var result = validator.TestValidate(model);

            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
