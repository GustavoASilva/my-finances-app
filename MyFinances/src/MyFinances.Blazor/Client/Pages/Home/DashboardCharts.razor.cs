using ChartJs.Blazor.BarChart;
using ChartJs.Blazor.Common;
using ChartJs.Blazor.Common.Axes;
using ChartJs.Blazor.Common.Enums;
using ChartJs.Blazor.Common.Time;
using ChartJs.Blazor.LineChart;
using ChartJs.Blazor.PieChart;
using ChartJs.Blazor.Util;
using Microsoft.AspNetCore.Components;
using MyFinances.Blazor.Shared.Transaction;
using System.Drawing;

namespace MyFinances.Blazor.Client.Pages.Home
{
    public partial class DashboardCharts
    {
        IndexableOption<string> Colors = new[]
                {
                    ColorUtil.ColorHexString(255, 99, 132), // Slice 1 aka "Red"
                    ColorUtil.ColorHexString(255, 205, 86), // Slice 2 aka "Yellow"
                    ColorUtil.ColorHexString(75, 192, 192), // Slice 3 aka "Green"
                    ColorUtil.ColorHexString(54, 162, 235), // Slice 4 aka "Blue"
                };
        List<ConfigBase> ChartConfigs = new List<ConfigBase>();

        [Parameter]
        public List<TransactionDto> Transactions { get; set; } = new List<TransactionDto>();

        protected override void OnParametersSet()
        {
            var pie = GetPieConfig();

            ChartConfigs.Add(pie);

            var line = GetBarConfig();
            ChartConfigs.Add(line);

        }

        LineConfig GetBarConfig()
        {
            var map = Transactions
                .GroupBy(x => x.ConfirmedDate.Value.ToString("dd/MM/yyyy"))
                .ToDictionary(x => x.Key, y => y.Sum(z => z.Value));

            var barConfig = new LineConfig
            {
                Options = new LineOptions
                {
                    Responsive = true,
                    MaintainAspectRatio = false,
                    Title = new OptionsTitle
                    {
                        Display = true,
                        Text = "Ranking por Categoria"
                    },
                    Scales = new Scales
                    {
                        XAxes = new List<CartesianAxis>
                    {
                        new TimeAxis
                        {
                            ScaleLabel = new ScaleLabel
                            {
                                LabelString = "Data"
                            },
                            Time = new TimeOptions
                            {
                                TooltipFormat = "dd/MM/yyyy"
                            },
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

            foreach (string category in map.Keys)
            {
                barConfig.Data.Labels.Add(category);
            }

            IEnumerable<decimal> data = map.Select(x => x.Value);

            LineDataset<decimal> dataset = new LineDataset<decimal>(data)
            {
                Label = "My first dataset",
                BackgroundColor = ColorUtil.FromDrawingColor(Color.Red),
                BorderColor = ColorUtil.FromDrawingColor(Color.Red),
                Fill = FillingMode.Disabled
            };

            barConfig.Data.Datasets.Add(dataset);

            return barConfig;
        }

        PieConfig GetPieConfig()
        {
            var map = Transactions
                .GroupBy(x => x.Category)
                .ToDictionary(x => x.Key, y => y.Sum(z => z.Value));

            var pieConfig = new PieConfig
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
            foreach (string category in map.Keys)
            {
                pieConfig.Data.Labels.Add(category);
            }

            IEnumerable<decimal> data = map.Select(x => x.Value);

            PieDataset<decimal> dataset = new PieDataset<decimal>(data)
            {
                BackgroundColor = Colors,
            };

            pieConfig.Data.Datasets.Add(dataset);
            return pieConfig;
        }

    }


}
