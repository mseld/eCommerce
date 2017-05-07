﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IM.Web.Domain;

namespace IM.Web.Services
{
    public interface IWorkProcessService
    {
        int Add(WorkProcessType type);
        void Update(int id, string status, double percentageCompleted, bool? isComplete = null, string error = null);
        void Update(int id, string status, double percentageCompleted, out bool cancelRequested,
            bool? isComplete = null, string error = null);
        IQueryable<WorkProcess> Find(WorkProcessType type);
        void Cancel(int id);
        void Delete(int id);
    }
}