﻿namespace MyFinances.Blazor.Shared
{
    public class AddNewTransactionRequest
    {
        public AddNewTransactionRequest()
        {
        }

        public int HouseholdId { get; set; }
        public decimal Value { get; set; }
        public DateTime EstimatedDate { get; set; }
        public DateTime? ConfirmedDate { get; set; }
    }
}
