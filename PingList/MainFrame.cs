
using iPinger.Application.Factories.Pingers;
using iPinger.Application.Managers;
using iPinger.Application.Services;
using iPinger.Application.Services.Pinger;
using iPinger.Domain.Models;
using iPinger.Factories.Pingers;
using iPinger.Infrastructure.Config.Managers;
using iPinger.Infrastructure.Config.Parsers;
using iPinger.Infrastructure.Config.Providers;

using PingList.Model;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PingList
{
    public partial class MainFrame : Form
    {
        private readonly IConfigParser configParser;

        private IConfigProvider configProvider;

        private readonly IConfigManager configManager;

        private readonly IPingerFactory pingerFactory;

        private readonly IPingService pingService;

        public MainFrame()
        {
            InitializeComponent();

            configParser = new JsonConfigParser();
            configProvider = new FileConfigProvider(configParser, $"./config.json");
            configManager = new ConfigManager(configProvider);

            pingerFactory = new PingerFactory();
            pingService = new PingService(pingerFactory);

            DataGridViewColumn hostColumn = new DataGridViewTextBoxColumn();
            hostColumn.Name = "hostColumn";
            hostColumn.DataPropertyName = "Host";
            hostColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            hostColumn.HeaderText = "Host";

            DataGridViewColumn statusColumn = new DataGridViewImageColumn();
            statusColumn.Name = "statusColumn";
            statusColumn.DataPropertyName = "StatusImage";
            statusColumn.HeaderText = "Status";
            statusColumn.ReadOnly = true;

            DataGridViewColumn responseTimeColumn = new DataGridViewTextBoxColumn()
            {
                Name = "responseTimeColumn",
                DataPropertyName = "ResponseTime",
                HeaderText = "Time, ms",
                ReadOnly = true
            };

            DataGridViewColumn innerIdColumn = new DataGridViewTextBoxColumn()
            {
                Name = "innerIdCoumn",
                DataPropertyName = "InnerId",
                Visible = false,
                HeaderText = "Id",
                ReadOnly = true
            };

            hostStatusGrid.Columns.AddRange(
                hostColumn,
                responseTimeColumn,
                statusColumn,
                innerIdColumn
            );

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = new List<GridHostStatusItemModel>();

            hostStatusGrid.DataSource = bindingSource;
            
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await refreshPingList();
        }

        private async void refresh_button_Click(object sender, EventArgs e)
        {
            await refreshPingList();
        }

        private async Task refreshPingList()
        {
            ParsedConfig? loadedConfig = configManager.LoadedConfig;

            if (loadedConfig is null)
            {
                try
                {
                    configManager.LoadConfig();
                    loadedConfig = configManager.LoadedConfig;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Load config error");
                    return;
                }
            }

            List<GridHostStatusItemModel> dataSource = ((BindingSource)hostStatusGrid.DataSource).DataSource as List<GridHostStatusItemModel>;
            HostModel[] configHosts = loadedConfig!.Hosts.ToArray();

            for (int i = 0; i < configHosts.Length; i++)
            {
                int foundIndex = dataSource.FindIndex(0, x => x.InnerId == configHosts[i].InnerId);

                if (foundIndex == -1)
                {
                    HostModel hostModel = configHosts[i];

                    dataSource.Add(new GridHostStatusItemModel(
                        hostModel.InnerId,
                        $"{hostModel.Host}:{hostModel.Port} / {hostModel.Protocol}",
                        Properties.Resources.InProcessingPing
                    ));
                }
                else
                {
                    dataSource[foundIndex].StatusImage = Properties.Resources.InProcessingPing;
                    dataSource[foundIndex].ResponseTime = 0;
                }
            }

            await Parallel.ForEachAsync(configHosts, async (host, cancelationToken) =>
            {
                PingResult pingResult = await pingService.PingHostAsync(host, loadedConfig.Timeout);

                int foundHostIndex = dataSource.FindIndex(0, x => x.InnerId == host.InnerId);
                GridHostStatusItemModel hostItemModel = dataSource[foundHostIndex];

                hostItemModel.StatusImage = GetStatusImage(pingResult);
                hostItemModel.ResponseTime = pingResult.ResponseTime;

                hostStatusGrid.Invoke(() =>
                {
                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = dataSource;

                    hostStatusGrid.DataSource = bindingSource;

                });
            });

            GC.Collect();
        }

        private Image GetStatusImage(PingResult pingResult)
        {
            return pingResult.Available
                ? Properties.Resources.SuccessPing
                : Properties.Resources.FailedPing;
        }

        private async void refreshToolStripMenuItem_ClickAsync(object sender, EventArgs e)
        {
            await refreshPingList();
        }
    }
}
