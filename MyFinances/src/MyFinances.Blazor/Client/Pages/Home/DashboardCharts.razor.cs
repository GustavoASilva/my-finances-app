using ChartJs.Blazor.Common;
using ChartJs.Blazor.Common.Axes;
using ChartJs.Blazor.Common.Enums;
using ChartJs.Blazor.LineChart;
using ChartJs.Blazor.PieChart;
using ChartJs.Blazor.Util;
using Microsoft.AspNetCore.Components;
using MyFinances.Blazor.Shared.Transaction;
using System.Drawing;
using System.Globalization;

namespace MyFinances.Blazor.Client.Pages.Home
{
    public partial class DashboardCharts
    {
        [Parameter]
        public List<TransactionDto> Transactions { get; set; } = new List<TransactionDto>();

        readonly IndexableOption<string> Colors = new[]
        {
            ColorUtil.FromDrawingColor(Color.Red),
            ColorUtil.FromDrawingColor(Color.Yellow),
            ColorUtil.FromDrawingColor(Color.Green),
            ColorUtil.FromDrawingColor(Color.Blue),
        };

        PieConfig? TransactionsByCategoryRank;
        LineConfig? TransactionsEvolution;

        protected override void OnParametersSet()
        {
            SetTransactionsByCategoryRank();
            SetTransactionsEvolution();
        }

        private void SetTransactionsEvolution()
        {
            LineConfig lineConfig = new()
            {
                Options = new LineOptions
                {
                    Responsive = true,
                    MaintainAspectRatio = false,
                    Title = new OptionsTitle
                    {
                        Display = true,
                        Text = "Evolução do Saldo"
                    },
                    Tooltips = new Tooltips
                    {
                        Mode = InteractionMode.Nearest,
                        Intersect = true
                    },
                    Hover = new Hover
                    {
                        Mode = InteractionMode.Nearest,
                        Intersect = true
                    },
                    Scales = new Scales
                    {
                        XAxes = new List<CartesianAxis>
                        {
                            new CategoryAxis
                            {
                                ScaleLabel = new ScaleLabel
                                {
                                    LabelString = "Mês"
                                }
                            }
                        },
                        YAxes = new List<CartesianAxis>
                        {
                            new LinearCartesianAxis
                            {
                                ScaleLabel = new ScaleLabel
                                {
                                    LabelString = "Valor"
                                }
                            }
                        }
                    }
                }
            };

            var culture = CultureInfo.GetCultureInfo("pt-BR");
            var dateTimeFormat = culture.DateTimeFormat;

            var monthNameGroupings = Transactions
                .GroupBy(x => dateTimeFormat.GetMonthName(x.ConfirmedDate!.Value.Month).ToUpper());

            var labels = monthNameGroupings.Select(x => x.Key);

            foreach (string category in labels)
            {
                lineConfig.Data.Labels.Add(category);
            }

            IEnumerable<decimal> sumData = monthNameGroupings.Select(x => x.Sum(y => y.Value));

            LineDataset<decimal> dataset = new(sumData)
            {
                Label = "Saldo por Mês",
                BackgroundColor = ColorUtil.FromDrawingColor(Color.Blue),
                BorderColor = ColorUtil.FromDrawingColor(Color.Blue),
                Fill = FillingMode.Disabled
            };

            lineConfig.Data.Datasets.Add(dataset);

            TransactionsEvolution = lineConfig;
        }

        private void SetTransactionsByCategoryRank()
        {
            PieConfig pieConfig = new()
            {
                Options = new PieOptions
                {
                    Responsive = true,
                    MaintainAspectRatio = false,
                    Title = new OptionsTitle
                    {
                        Display = true,
                        Text = "Ranking por Categoria"
                    },
                }
            };

            var categoryGroupings = Transactions
                .GroupBy(x => x.Category);

            var labels = categoryGroupings.Select(x => x.Key);

            foreach (string category in labels)
            {
                pieConfig.Data.Labels.Add(category);
            }

            IEnumerable<decimal> sumData = categoryGroupings.Select(x => x.Sum(y => y.Value));

            PieDataset<decimal> dataset = new(sumData)
            {
                BackgroundColor = Colors,
            };

            pieConfig.Data.Datasets.Add(dataset);
            TransactionsByCategoryRank = pieConfig;
        }
    }
}