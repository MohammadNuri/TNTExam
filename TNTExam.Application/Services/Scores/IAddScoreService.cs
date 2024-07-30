﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNTExam.Application.Dtos;
using TNTExam.Common;

namespace TNTExam.Application.Services.Scores
{
    public interface IAddScoreService
    {
        ServiceResult Execute(RequestScoreDto request);
    }
}
