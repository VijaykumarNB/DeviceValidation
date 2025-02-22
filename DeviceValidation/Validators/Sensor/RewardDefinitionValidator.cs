﻿using System;
using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using FluentValidation;

namespace DeviceV2.Validators.Sensor
{
    public class RewardDefinitionValidator : AbstractValidator<RewardDefinition>
    {
        public RewardDefinitionValidator()
        {
            RuleFor(x => x.Metadata).SetValidator(new MetaDataValidator());
            RuleForEach(x => x.Rewards).SetValidator(new RewardValidation());
        }
    }
}
