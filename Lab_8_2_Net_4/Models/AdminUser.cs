using System;
using System.Collections.Generic;

namespace Lab_8_2_Net_4.Models;

public partial class AdminUser
{
    public string UserName { get; set; } = null!;

    public string? Pasword { get; set; }

    public string? FullName { get; set; }

    public string? PhoneNumber { get; set; }
}
