using System;
using System.Collections.Generic;
using System.Text;

namespace GeneralModels.General
{
    public class LoginResponseModel
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public object token { get; set; }
        public long TotalGamePlayed { get; set; } = 0;
        public decimal TotalWinAmount { get; set; } = 0;
        public decimal TotalWinningCurrencyAmount { get; set; } = 0;
        public bool Status { get; set; } = false;
        public decimal CurrentCurrencyAmount { get; set; } = 0;

    }
}
