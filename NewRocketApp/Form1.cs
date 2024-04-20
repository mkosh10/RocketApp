using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RocketLibrary;
using Newtonsoft.Json;
using System.Net.Mail;
using System.Data.SqlClient;
using static RocketLibrary.RocketApiModel;


namespace NewRocketApp
{
    public partial class Form1 : Form
    {

        List<RocketDbModel> upcomingRockets = new List<RocketDbModel>();

        public Form1()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();
            SetListView();
            ShowDB();
            _ = GetLaunchesInTheNext7Days();
        }


        private void emailBtnClick(object sender, EventArgs e)
        {
            SqliteDataAccess.ResetAllRocketsAsNotUpdated(); 
            ShowDB();
            FillUpdateDb();
            SendEmail(GetUpcomoingLaunchesFromDB()); 
        }

        private void ShowDB()
        {
            listViewDB.Items.Clear();   
            List<RocketDbModel> RocketsInDB = SqliteDataAccess.LoadRockets();
            foreach(RocketDbModel r in RocketsInDB)
            {
                ListViewItem listItem = new ListViewItem(new string[] { $"{r.name}", $"{r.is_updated}", $"{r.launch_date_time}", $"{r.status}" });
                listViewDB.Items.Add(listItem);
            }
        }

        private async void FillUpdateDb()
        {
            var RocketListFromApi = await LaunchesInTheNextXDays(7);

            foreach(RocketDbModel rocket in RocketListFromApi)
            {
                if (SqliteDataAccess.CheckIfRocketExistsInDb(rocket))
                {
                    SqliteDataAccess.UpdateRocketLaunch(rocket);
                    SqliteDataAccess.UpdateRocketStatus(rocket);
                } else
                {
                    SqliteDataAccess.SaveRocket(rocket);
                }
            }
        }

        private List<RocketDbModel> GetUpcomoingLaunchesFromDB()
        {
            List<RocketDbModel> RocketsFromDb = SqliteDataAccess.LoadRockets(); 
            List<RocketDbModel> UpdatedItems = new List<RocketDbModel>();

            DateTime dateNow = DateTime.Now;
            TimeZoneInfo zoneInfo = TimeZoneInfo.Local;

            foreach (RocketDbModel Item in  RocketsFromDb)
            {
                DateTime rocketLaunchDate = TimeZoneInfo.ConvertTimeFromUtc(Item.launch_date_time, zoneInfo);
                if (rocketLaunchDate >= dateNow)
                {
                    UpdatedItems.Add(Item);
                }
            }

            return UpdatedItems;    
        }


        private async Task GetLaunchesInTheNext7Days()
        {
           
            var rocketList = await LaunchesInTheNextXDays(7);
            foreach (var rocket in rocketList)
            {
                ListViewItem listItem = new ListViewItem(new string[] { $"{rocket.name}", $"{rocket.launch_date_time}" });
                listViewAPI.Items.Add(listItem);
            }
        }

        private async Task<List<RocketDbModel>> LaunchesInTheNextXDays(int days)
        {
            var rocketList = await ApiHelper.GetUpcomingRocketsFromApi();
            DateTime dateNow = DateTime.Now;
            DateTime nextWeek = dateNow.AddDays(days);
            TimeZoneInfo zoneInfo = TimeZoneInfo.Local;
            List<RocketDbModel> rocketsLaunchedInNextXDays = new List<RocketDbModel>();
            foreach (var rocket in rocketList.results)
            {
                DateTime rocketLaunchDate = TimeZoneInfo.ConvertTimeFromUtc(rocket.net, zoneInfo);
                if (rocketLaunchDate >= dateNow && rocketLaunchDate <= nextWeek)
                {
                    rocketsLaunchedInNextXDays.Add(new RocketDbModel()
                    {
                        id = rocket.id,
                        name = rocket.name,
                        last_updated = rocket.last_updated,
                        launch_date_time = rocketLaunchDate,
                        img_url = rocket.image,
                        status = rocket.status.name,
                        provider_name = rocket.launch_service_provider.name,
                        is_updated = 0
                    });
                }
            }
            return rocketsLaunchedInNextXDays;  
        }



        public void SendEmail(List<RocketDbModel> UpdatedItems)
        {
            string json = File.ReadAllText("emails.json");
            Console.WriteLine(json);
            dynamic emailJsonObject = JsonConvert.DeserializeObject(json);

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("demoenaslov@gmail.com", "dspf rski sgaf pygw"),
                EnableSsl = true,
            };

            StringBuilder MailBody = new StringBuilder();

            if (UpdatedItems.Count() == 0)
            {
                MailBody.Append("<html><body>No updates<body><html>");
            }
            else
            {
                MailBody.AppendFormat("<html><body>");
                foreach (RocketDbModel rocket in UpdatedItems)
                {
                    MailBody.Append("<h3 color=\"red\">" + rocket.name + "</h3>");
                    MailBody.Append("<h4> Status: " + rocket.status + "</h4>");
                    MailBody.Append("<h4> Launch Date: " + rocket.launch_date_time + "</h4>");
                    MailBody.Append($"<img src=\"{rocket.img_url}\"  width=\"350\" height=\"300\"/>");
                }
                MailBody.AppendFormat("<body><html>");
            }

            MailMessage mailMessage = new MailMessage()
            {
                From = new MailAddress("demoenaslov@gmail.com"),
                Subject = "New Rocket List",
                IsBodyHtml = true,
                Body = MailBody.ToString(),
            };

            foreach(var email in  emailJsonObject.addresses) {
                string cleanedEmail = ((string)email).Trim('{', '}');
                mailMessage.To.Add(cleanedEmail);
                smtpClient.Send(mailMessage);
                mailMessage.To.Clear();
            }
        }

        private void SetListView()
        {
            listViewAPI.View = View.Details;
            listViewDB.View = View.Details;
            listViewDB.Columns.Add("Rocket name", 150);
            listViewDB.Columns.Add("Updated", 100);
            listViewDB.Columns.Add("Launch date", 150);
            listViewDB.Columns.Add("Rocket status", 170);
            listViewAPI.Columns.Add("Rocket name", 200);
            listViewAPI.Columns.Add("Upcoming launch dates", 170);
        }


        private void RefreshDb_Click(object sender, EventArgs e)
        {
            ShowDB();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

    }
}
