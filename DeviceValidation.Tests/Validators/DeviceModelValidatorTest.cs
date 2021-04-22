using System;
using System.Collections.Generic;
using DeviceV2.Validators;
using FluentValidation.TestHelper;
using Xunit;

namespace DeviceV2Tests.Validators
{
    public class DeviceModelValidatorTest : BaseValidatorTest
    {
        private DeviceValidator validator;

        [Fact]
        public void DeviceModel_WithValidData_HappyPath()
        {
            // Given
            validator = new DeviceValidator("Default");
            var device = CreateDeviceData();

            // When
            var result = validator.TestValidate(device);

            // Than
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Theory]
        [InlineData(99)]
        [InlineData(10)]
        public void DeviceModel_WithValidTrackData_HappyPath(decimal invalidRadius)
        {
            // Given
            validator = new DeviceValidator("TRACKER");

            // Given
            var device = CreateDeviceData();
            device.Location.Accuracy = invalidRadius;

            // When
            var result = validator.TestValidate(device);

            // Than
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Theory]
        [InlineData(100)]
        [InlineData(100.1)]
        public void DeviceModel_WithValidTrackData_ShouldHaveValidationErrorFor(decimal invalidRadius)
        {
            // Given
            validator = new DeviceValidator("TRACKER");

            // Given
            var device = CreateDeviceData();
            device.Location.Accuracy = invalidRadius;

            // When
            var result = validator.TestValidate(device);

            // Than
            result.ShouldHaveValidationErrorFor("Location.Accuracy");
        }
    }
}
