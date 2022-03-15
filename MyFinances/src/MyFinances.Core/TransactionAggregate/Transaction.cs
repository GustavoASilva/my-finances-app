﻿using Ardalis.GuardClauses;
using MyFinances.Core.Interfaces;
using MyFinances.Core.SyncedAggregates;

namespace MyFinances.Core.TransactionAggregate
{
    public class Transaction : BaseEntity<Guid>, IAggregateRoot
    {
        public Transaction()
        {
        }

        public Transaction(decimal value, Category category, int householdId, int originId, string description, DateTime estimatedDate)
        {
            Value = Guard.Against.Zero(value, nameof(Value));
            Category = category;
            HouseholdId = householdId;
            Description = description;
            EstimatedDate = estimatedDate;
            OriginId = originId;
        }

        public decimal Value { get; private set; }
        public string Description { get; private set; }
        public Category Category { get; private set; }
        public int HouseholdId { get; }
        public int OriginId { get; private set; }
        public DateTime EstimatedDate { get; private set; }
        public DateTime? ConfirmedDate { get; private set; }
        public bool IsConfirmed { get; private set; }

        public void UpdateValue(decimal value)
        {
            Value = value;
        }
        public void UpdateDescription(string description)
        {
            Description = description;
        }

        public void SetConfirmed(bool confirmed)
        {
            if (confirmed)
                Confirm();
            else
                Unconfirm();
        }

        public void UpdateEstimatedDate(DateTime estimatedDate)
        {
            EstimatedDate = estimatedDate;
        }

        private void Confirm()
        {
            if (IsConfirmed) return;

            ConfirmedDate = DateTime.Now;
            IsConfirmed = true;
        }

        private void Unconfirm()
        {
            if (!IsConfirmed) return;
            IsConfirmed = false;
            ConfirmedDate = null;
        }
    }
}