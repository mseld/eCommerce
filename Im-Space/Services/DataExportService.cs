using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using CsvHelper;
using Elmah;
using IM.Web.DAL;
using IM.Web.Domain;
using IM.Web.Helpers;
using Ionic.Zip;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using JsonTextWriter = Newtonsoft.Json.JsonTextWriter;

namespace IM.Web.Services
{
    public class DataExportService
    {
        private readonly DataContext db;
        private readonly IWorkProcessService workProcessService;

        public DataExportService()
        {
            // Not using structuremap as dependencies are being disposed too early

            db = DataContext.Create();
            workProcessService = new WorkProcessService(db);
        }
    }
}