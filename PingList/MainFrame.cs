
using iPinger.Application.Factories.Pingers;
using iPinger.Application.Services;
using iPinger.Application.Services.Pinger;
using iPinger.Domain.Models;
using iPinger.Factories.Pingers;
using iPinger.Infrastructure.Config.Managers;
using iPinger.Infrastructure.Config.Parsers;
using iPinger.Infrastructure.Config.Providers;

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

            hostStatusGrid.Columns.Add(hostColumn);
            hostStatusGrid.Columns.Add(responseTimeColumn);
            hostStatusGrid.Columns.Add(statusColumn);
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
            if (configManager.LoadedConfig is null)
            {
                try
                {
                    configManager.LoadConfig();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Load config error");
                    return;
                }
            }

            IEnumerable<PingResult> pingResults = await pingService.PingHostGroupAsync(configManager.LoadedConfig.Hosts);

            BindingSource bindingSource = new BindingSource();

            foreach(var pingResult in pingResults)
            {
                bindingSource.Add(new
                {
                    Host = $"{pingResult.Host.Host}:{pingResult.Host.Port} / {pingResult.Host.Protocol}",
                    ResponseTime = pingResult.ResponseTime,
                    StatusImage = GetStatusImage(pingResult)
                });
            }

            hostStatusGrid.DataSource = bindingSource;

            GC.Collect();
        }

        private Image GetStatusImage(PingResult pingResult)
        {
            return pingResult.Available
                ? Properties.Resources.SuccessPing
                : Properties.Resources.FailedPing;
        }
    }
}
