using ChartJs.Blazor.Common;
using ChartJs.Blazor.PieChart;
using ChartJs.Blazor.Util;
using Microsoft.AspNetCore.Components;
using MyFinances.Blazor.Client.Services;
using MyFinances.Blazor.Shared.Transaction;

namespace MyFinances.Blazor.Client.Pages.Home
{
    public partial class Index
    {
        [Inject]
        TransactionService TransactionService { get; set; }

        PieConfig _config;
        List<TransactionDto> Transactions = new List<TransactionDto>();

        decimal ActualBalance = 0;
        decimal EstimatedBalance = 0;

        protected override async Task OnInitializedAsync()
        {
            Transactions = await TransactionService.ListAsync();

            foreach (TransactionDto transaction in Transactions)
            {
                if (transaction.ConfirmedDate != null)
                    ActualBalance += transaction.Value;
                else
                    EstimatedBalance += transaction.Value;
            }

            _config = new PieConfig
            {
                Options = new PieOptions
                {
                    Responsive = true,
                    MaintainAspectRatio = false,
                    Title = new OptionsTitle
                    {
                        Display = true,
                        Text = "ChartJs.Blazor Pie Chart"
                    },
                }
            };

            var map = Transactions
                .GroupBy(x => x.Category)
                .ToDictionary(x => x.Key, y => y.Sum(z => z.Value));

            foreach (string category in map.Keys)
            {
                _config.Data.Labels.Add(category);
            }

            IEnumerable<decimal> data = map.Select(x => x.Value);

            PieDataset<decimal> dataset = new PieDataset<decimal>(data)
            {
                BackgroundColor = new[]
                {
                    ColorUtil.ColorHexString(255, 99, 132), // Slice 1 aka "Red"
                    ColorUtil.ColorHexString(255, 205, 86), // Slice 2 aka "Yellow"
                    ColorUtil.ColorHexString(75, 192, 192), // Slice 3 aka "Green"
                    ColorUtil.ColorHexString(54, 162, 235), // Slice 4 aka "Blue"
                }
            };

            _config.Data.Datasets.Add(dataset);
        }
    }
}
