﻿using Core.Security.Entities;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Messages.Dtos
{
    public class MessageListDto
    {
        public int Id { get; set; }
        public int? UserName { get; set; }

        public string MessageText { get; set; }
    }
}
