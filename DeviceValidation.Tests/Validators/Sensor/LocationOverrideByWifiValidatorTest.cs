using System.Collections.Generic;
using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using DeviceV2.Validators.Sensor;
using FluentValidation.TestHelper;
using Xunit;

namespace DeviceV2Tests.Validators.Sensor
{
    public class LocationOverrideByWifiValidatorTest : BaseValidatorTest
    {
        private LocationOverrideByWifiValidator validator;

        [Fact]
        public void HappyPath()
        {
            validator = new LocationOverrideByWifiValidator("Default");
            var model = CreateLocationOverrideByWifi();
            var result = validator.TestValidate(model);

            result.ShouldNotHaveAnyValidationErrors();
        }

        [Theory]
        [InlineData(181, 91, 500)]
        [InlineData(-181, -91, 500)]
        public void InvalidLocationData(
            decimal invalidLongitude,
            decimal invalidLatitude,
            decimal invalidRadius)
        {
            validator = new LocationOverrideByWifiValidator("Default");
            var model = CreateLocationOverrideByWifi();

            model.Accuracy = invalidRadius;
            model.Latitude = invalidLatitude;
            model.Longitude = invalidLongitude;

            var result = validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor("Accuracy");
            result.ShouldHaveValidationErrorFor("Latitude");
            result.ShouldHaveValidationErrorFor("Longitude");
        }

        [Theory]
        [InlineData(99)]
        [InlineData(10)]
        public void LocationOverrideByWifi_WithValidTrackerData_HappyPath(decimal invalidRadius)
        {

            // Given
            validator = new LocationOverrideByWifiValidator("TRACKER");
            var model = CreateLocationOverrideByWifi();
            model.Accuracy = invalidRadius;
            // When
            var result = validator.TestValidate(model);

            // Than
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Theory]
        [InlineData(100)]
        [InlineData(100.1)]
        public void LocationOverrideByWifi_WithInValidTrackerData_ShouldHaveValidationErrorFor(decimal invalidRadius)
        {

            // Given
            validator = new LocationOverrideByWifiValidator("TRACKER");
            var model = CreateLocationOverrideByWifi();
            model.Accuracy = invalidRadius;
            // When
            var result = validator.TestValidate(model);

            // Than
            result.ShouldHaveValidationErrorFor("Accuracy");
        }
    }
}
