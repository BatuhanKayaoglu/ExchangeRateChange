﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRateChange.Common.ViewModels.User
{
    public class ChangePasswordViewModel
    {
        public string? email { get; set; }
        public string? oldPassword { get; set; }
        public string? newPassword { get; set; }
        public string? confirmNewPassword { get; set; }
    }
}
