﻿
namespace CenturyLinkCloudSDK.ServiceModels
{
    public class ServerBilling
    {
        //public string Id { get; set; }

        public float TemplateCost { get; set; }

        public float ArchiveCost { get; set; }

        public float MonthlyEstimate { get; set; }

        public float MonthToDate { get; set; }

        public float CurrentHour { get; set; }

    }
}
